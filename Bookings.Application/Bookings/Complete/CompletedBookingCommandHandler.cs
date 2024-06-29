using Bookings.Application.Abstractions.Database;
using Bookings.Application.Exceptions;
using Bookings.Domain.Apartments;
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
           .FirstOrDefaultAsync(c => c.Id == request.CompletedBookingDto.BookingId, cancellationToken);

        if (booking is null)
        {
            throw new NotFoundException(nameof(booking), request.CompletedBookingDto.BookingId);
        }

        if (booking.UserId != request.CompletedBookingDto.UserId)
        {
            throw new NotFoundException(nameof(booking), request.CompletedBookingDto.UserId);
        }

        if (!(booking.End < DateTime.UtcNow))
        {
            throw new Exception("Booking has not ended yet.");
        }

        booking.SetCompletedOnUtc(DateTime.UtcNow);

        await _applicationContext.SaveChangesAsync(cancellationToken);

    }
}
