using Bookings.Application.Abstractions.Database;
using Bookings.Application.Exceptions;
using Bookings.Domain.Bookings;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookings.Application.Bookings.Cancel;
public class CancelBookingCommandHandler(
    IApplicationContext _applicationContext)
    : IRequestHandler<CancelBookingCommand>
{
    public async Task Handle(CancelBookingCommand request, CancellationToken cancellationToken)
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
            throw new UnauthorizedAccessException("You are not authorized to cancel this booking.");
        }

        if (booking.Status == BookingStatus.Completed)
        {
            throw new Exception("Cannot cancel a completed booking");
        }

        if (booking.Start < DateTime.UtcNow && booking.End > DateTime.UtcNow)
        {
            throw new Exception("Cancellations are not allowed after the booking period has started.");
        }

        booking.SetCancelledOnUtc(DateTime.UtcNow, BookingStatus.Cancelled);

        await _applicationContext.SaveChangesAsync(cancellationToken);
    }
}
