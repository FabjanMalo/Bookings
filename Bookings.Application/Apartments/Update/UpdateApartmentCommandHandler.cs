using Bookings.Application.Abstractions.Database;
using Bookings.Application.Apartments.Create;
using Bookings.Application.Exceptions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookings.Application.Apartments.Update;
public class UpdateApartmentCommandHandler : IRequestHandler<UpdateApartmentCommand, Guid>
{
    private readonly IApplicationContext _applicationContext;
    private readonly IApartmentRepository _apartmentRepository;
    private readonly UpdateApartmentCommandValidation _validation;

    public UpdateApartmentCommandHandler(IApplicationContext applicationContext,
        IApartmentRepository apartmentRepository)
    {
        _applicationContext = applicationContext;
        _apartmentRepository = apartmentRepository;
        _validation = new UpdateApartmentCommandValidation();
    }
    public async Task<Guid> Handle(UpdateApartmentCommand request, CancellationToken cancellationToken)
    {
        var validationResult = await _validation.ValidateAsync(request);

        if (!validationResult.IsValid)
        {
            throw new ValidationException(validationResult.Errors);
        }

        var apartment = await _applicationContext
            .Apartments
            .Where(c => c.Id == request.ApartmentDetailDto.Id)
            .FirstOrDefaultAsync(cancellationToken);

        _apartmentRepository.Update(apartment);

        await _applicationContext.SaveChangesAsync(cancellationToken);

        return apartment.Id;


    }
}
