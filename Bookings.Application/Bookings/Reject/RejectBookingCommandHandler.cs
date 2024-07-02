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
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Bookings.Application.Bookings.Reject;
public class RejectBookingCommandHandler(IApplicationContext _applicationContext) : IRequestHandler<RejectBookingCommand>
{
    public async Task Handle(RejectBookingCommand request, CancellationToken cancellationToken)
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
            throw new UnauthorizedAccessException("You are not authorized to reject this booking.");
        }

        if (!(booking.Status == BookingStatus.Reserved || booking.Status == BookingStatus.Confirmed))
        {
            throw new Exception("Cannot reject booking because it has been cancelled or completed.");
        }


        booking.SetRejectdOnUtc(DateTime.UtcNow, BookingStatus.Rejected);

        await _applicationContext.SaveChangesAsync(cancellationToken);

    }
}
