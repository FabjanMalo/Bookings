using Bookings.Application.Abstractions.Database;
using Bookings.Application.Exceptions;
using Bookings.Domain.Apartments;
using Bookings.Domain.Bookings;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookings.Application.Bookings.Complete;
public class CompletedBookingCommandHandler(
    IApplicationContext _applicationContext)
    : IRequestHandler<CompletedBookingCommand>
{
    public async Task Handle(CompletedBookingCommand request, CancellationToken cancellationToken)
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
            throw new UnauthorizedAccessException("You are not authorized to complete this booking.");
        }


        if (booking.Status == BookingStatus.Cancelled || booking.Status == BookingStatus.Rejected)
        {
            throw new Exception("Cannot complete booking because it has been cancelled or rejected.");
        }

        if (!(booking.End < DateTime.UtcNow))
        {
            throw new Exception("Booking has not ended yet.");
        }

        booking.SetCompletedOnUtc(DateTime.UtcNow, BookingStatus.Completed);

        await _applicationContext.SaveChangesAsync(cancellationToken);

    }
}
