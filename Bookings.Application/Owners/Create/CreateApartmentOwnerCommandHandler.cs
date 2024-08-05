using Bookings.Application.Abstractions.Database;
using Bookings.Application.Exceptions;
using Bookings.Domain.ApartmentOwners;
using Bookings.Domain.Apartments;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookings.Application.Owners.Create;
public class CreateApartmentOwnerCommandHandler(
    IApplicationContext _applicationContext,
    IApartmentOwnerRepository _ownerRepository)
    : IRequestHandler<CreateOwnerCommand, Guid>
{

    private readonly CreateApartmentOwnerCommandValidation _validations = new();

    public async Task<Guid> Handle(CreateOwnerCommand request, CancellationToken cancellationToken)
    {
        var validationResult = await _validations.ValidateAsync(request, cancellationToken);

        if (!validationResult.IsValid)
        {
            throw new ValidationException(validationResult.Errors);
        }

        var uniqueOwner = await _ownerRepository
            .IsEmailUnique(request.CreateApartmentOwnerDto.Email, cancellationToken);

        if (!uniqueOwner)
        {
            throw new Exception("Email is not unique. Try another!");
        }

        var apartments = new List<Apartment>();

        foreach (Guid id in request.CreateApartmentOwnerDto.ApartmentsId)
        {

            var apartment = await _applicationContext.Apartments
              .FirstOrDefaultAsync(a => a.Id == id, cancellationToken);

            if (apartment == null)
            {
                throw new NotFoundException(nameof(apartment), id);
            }

            apartments.Add(apartment);
        }

        var apartmentOwner = ApartmentOwner.CreateOwner(request.CreateApartmentOwnerDto, apartments);

        await _ownerRepository.Add(apartmentOwner);

        await _applicationContext.SaveChangesAsync(cancellationToken);

        return apartmentOwner.Id;
    }
}
