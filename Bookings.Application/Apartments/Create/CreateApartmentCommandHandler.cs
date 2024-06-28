using Bookings.Application.Abstractions.Database;
using Bookings.Application.Exceptions;
using Bookings.Domain.Apartments;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookings.Application.Apartments.Create;
public class CreateApartmentCommandHandler : IRequestHandler<CreateApartmentCommand, Guid>
{
    private readonly IApplicationContext _applicationContext;
    private readonly IApartmentRepository _apartmentRepository;
    private readonly CreateApartmentCommandValidation _validation;

    public CreateApartmentCommandHandler(IApplicationContext applicationContext,
        IApartmentRepository apartmentRepository)
    {
        _applicationContext = applicationContext;
        _apartmentRepository = apartmentRepository;
        _validation = new CreateApartmentCommandValidation();
    }
    public async Task<Guid> Handle(CreateApartmentCommand request, CancellationToken cancellationToken)
    {

        var validationResult = await _validation.ValidateAsync(request,cancellationToken);

        if (!validationResult.IsValid)
        {

            throw new ValidationException(validationResult.Errors);
        }

        var uniqueApartment = await _apartmentRepository
            .IsNameUnique(request.CreateApartmentDto.Name, cancellationToken);

        if (!uniqueApartment)
        {
            throw new Exception("Apartment name is not unique. Try another name!");
        }

        var apartment = Apartment.Create(request.CreateApartmentDto);

        await _apartmentRepository.Add(apartment);

        await _applicationContext.SaveChangesAsync(cancellationToken);

        return apartment.Id;
    }
}
