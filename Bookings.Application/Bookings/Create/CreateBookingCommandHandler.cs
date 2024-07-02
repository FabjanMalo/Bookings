using Bookings.Application.Abstractions.Database;
using Bookings.Application.Exceptions;
using Bookings.Application.Mail;
using Bookings.Domain.Apartments;
using Bookings.Domain.Bookings;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookings.Application.Bookings.Create;
public class CreateBookingCommandHandler(
    IApplicationContext _applicationContext,
    IBookingRepository _bookingRepository,
    IEmailSender _emailSender)
    : IRequestHandler<CreateBookingCommand, Guid>
{
    private readonly CreateBookingCommandValidation _validations = new();

    public async Task<Guid> Handle(CreateBookingCommand request, CancellationToken cancellationToken)
    {
        var validationResult = await _validations.ValidateAsync(request, cancellationToken);

        if (!validationResult.IsValid)
        {
            throw new ValidationException(validationResult.Errors);
        }

        var apartment = await _applicationContext
           .Apartments
           .FirstOrDefaultAsync(c => c.Id == request.CreateBookingDto.ApartmentId, cancellationToken);

        if (apartment is null)
        {
            throw new NotFoundException(nameof(apartment), request.CreateBookingDto.ApartmentId);

        }

        var user = await _applicationContext
            .Users
            .FirstOrDefaultAsync(c => c.Id == request.CreateBookingDto.UserId, cancellationToken);

        if (user is null)
        {
            throw new NotFoundException(nameof(user), request.CreateBookingDto.ApartmentId);

        }


        var bookings = await _applicationContext
            .Bookings
            .Where(c => c.ApartmentId == request.CreateBookingDto.ApartmentId
            && (request.CreateBookingDto.Start <= c.End
            && request.CreateBookingDto.End >= c.Start)
            && (c.Status != BookingStatus.Cancelled
            && c.Status != BookingStatus.Rejected))
            .ToListAsync(cancellationToken);

        if (bookings.Count != 0)
        {
            throw new Exception("The requested booking period overlaps with an existing booking.");
        }


        decimal amenitiesUpCharge = 0m;

        foreach (var amenity in apartment.Amenities)
        {

            amenitiesUpCharge += amenity switch
            {
                Amenity.Spa => 5.5m,
                Amenity.MountainView => 4.5m,
                Amenity.Gym => 3.5m,
                _ => 0
            };

        }

        var email = new Email
        {
            To = user.Email,
            Subject = "Booking Confirmation Request",
            Body = @$"Please confirm your booking from {request.CreateBookingDto.Start} 
            to {request.CreateBookingDto.End} under the name {user.FirstName}{user.LastName}.
            <a> href='http://www.example.com'>Confirm</a>
            <a> href='http://www.example.com'>Reject</a>"
        };

        try
        {
            await _emailSender.SendEmail(email);

        }
        catch (Exception)
        {

            throw new Exception("Failed to send confirmation email");
        }

        var newBooking = BookingEntity
            .CreateBooking(request.CreateBookingDto, apartment, amenitiesUpCharge);

        await _bookingRepository.Add(newBooking);

        await _applicationContext.SaveChangesAsync(cancellationToken);

        return newBooking.Id;
    }
}

