using AutoMapper;
using Bookings.Application.Abstractions.Database;
using Bookings.Application.Apartments.Create;
using Bookings.Application.Exceptions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
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
    private readonly IMapper _mapper;
    private readonly ILogger<UpdateApartmentCommandHandler> _logger;

    public UpdateApartmentCommandHandler(
        IApplicationContext applicationContext,
        IApartmentRepository apartmentRepository,
        IMapper mapper,
        ILogger<UpdateApartmentCommandHandler> logger)
    {
        _applicationContext = applicationContext;
        _apartmentRepository = apartmentRepository;
        _mapper = mapper;
        _logger = logger;
        _validation = new UpdateApartmentCommandValidation();
    }
    public async Task<Guid> Handle(UpdateApartmentCommand request, CancellationToken cancellationToken)
    {
        var validationResult = await _validation.ValidateAsync(request, cancellationToken);

        if (!validationResult.IsValid)
        {
            throw new ValidationException(validationResult.Errors);
        }

        var apartment = await _applicationContext
            .Apartments
            .Where(c => c.Id == request.ApartmentDetailDto.Id)
            .FirstOrDefaultAsync(cancellationToken);

        if (apartment is null)
        {
            throw new NotFoundException(nameof(apartment), request.ApartmentDetailDto.Id);
        }

        _mapper.Map(request.ApartmentDetailDto, apartment);

        _apartmentRepository.Update(apartment);
        try
        {
            await _applicationContext.SaveChangesAsync(cancellationToken);

        }
        catch (Exception)
        {
            _logger.LogError("Error updating apartment {Id}", apartment.Id);

            throw new Exception("Duplicate Name.");
        }

        return apartment.Id;


    }
}
