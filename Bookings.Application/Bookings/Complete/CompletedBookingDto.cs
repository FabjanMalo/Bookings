using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookings.Application.Bookings.Complete;
public class CompletedBookingDto
{
    public Guid BookingId { get; init; }
    public Guid UserId { get; init; }
}
