using Bookings.Domain.Bookings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookings.Domain.Reviews;
public class CreateReviewDto
{
    public Guid BookingId { get; init; }
    public int Rating { get; init; }
    public string? Comment { get; init; }
}
