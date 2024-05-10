using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookings.Domain.Bookings;
public enum BookingStatus
{
    Reserved = 1,
    Confirmed,
    Rejected,
    Cancelled,
    Completed
}
