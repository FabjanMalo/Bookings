using Bookings.Application.Abstractions.Database;
using Bookings.Application.Exceptions;
using Bookings.Domain.Bookings;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Bookings.Application.Bookings.Confirm;
public class ConfirmBookingCommandHandler(
    IApplicationContext _applicationContext)
    : IRequestHandler<ConfirmBookingCommand>
{
    public async Task Handle(ConfirmBookingCommand request, CancellationToken cancellationToken)
    {
        var booking = await _applicationContext
            .Bookings
            .FirstOrDefaultAsync(c => c.Id == request.BookingDto.BookingId, cancellationToken);

        if (booking is null)
        {
            throw new NotFoundException(nameof(booking), request.BookingDto.BookingId);
        }

        if (booking.UserId != request.BookingDto.UserId)
        {
            throw new UnauthorizedAccessException("You are not authorized to confirm this booking.");
        }

        if (booking.Status != BookingStatus.Reserved)
        {
            throw new Exception("Booking status must be Reserved.");
        }

        if (booking.Start <= DateTime.UtcNow)
        {
            throw new Exception("The booking cannot be confirmed after the booking period has started.");
        }

        booking.SetConfirmedOnUtc(DateTime.UtcNow, BookingStatus.Confirmed);

        await _applicationContext.SaveChangesAsync(cancellationToken);

    }

}
