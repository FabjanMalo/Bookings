using AutoMapper;
using Bookings.Application.Abstractions.Database;
using Bookings.Application.Apartments;
using Bookings.Application.Exceptions;
using Bookings.Domain.Apartments;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookings.Application.Owners.Update;
public class UpdateOwnerCommandHandler(
    IApplicationContext _applicationContext,
    IMapper _mapper,
    IApartmentOwnerRepository _ownerRepository)
    : IRequestHandler<UpdateOwnerCommand, Guid>
{

    private readonly UpdateOwnerCommandValidation _validations = new();
    public async Task<Guid> Handle(UpdateOwnerCommand request, CancellationToken cancellationToken)
    {
        var validationResult = await _validations.ValidateAsync(request, cancellationToken);

        if (!validationResult.IsValid)
        {
            throw new ValidationException(validationResult.Errors);
        }

        var owner = await _applicationContext.ApartmentOwners
            .Include(x => x.Apartments)
            .FirstOrDefaultAsync(c => c.Id == request.UpdateOwnerDto.Id, cancellationToken);

        if (owner is null)
        {
            throw new NotFoundException(nameof(owner), request.UpdateOwnerDto.Id);

        }

        owner.Apartments.Clear();

        foreach (var id in request.UpdateOwnerDto.ApartmentsId)
        {
            var apartment = await _applicationContext.Apartments
               .FirstOrDefaultAsync(a => a.Id == id, cancellationToken);

            if (apartment == null)
            {
                throw new NotFoundException(nameof(apartment), id);
            }

            owner.Apartments.Add(apartment);
        }
        _mapper.Map(request.UpdateOwnerDto, owner);

        _ownerRepository.Update(owner);

        try
        {
            await _applicationContext.SaveChangesAsync(cancellationToken);

        }
        catch (Exception)
        {
            throw new Exception("An error occurred while updating the owner.");
        }

        return owner.Id;
    }
}
