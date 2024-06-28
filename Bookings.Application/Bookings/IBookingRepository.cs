using Bookings.Application.Contracts;
using Bookings.Domain.Bookings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookings.Application.Bookings;
public interface IBookingRepository : IGenericRepository<BookingEntity>
{
}
