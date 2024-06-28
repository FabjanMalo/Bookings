using Bookings.Application.Bookings;
using Bookings.Domain.Bookings;
using Bookings.Infrastructure.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookings.Infrastructure.Bookings;
public class BookingRepository : GenericRepository<BookingEntity>,IBookingRepository
{
    private readonly BookingsDbContext _dbContext;
    public BookingRepository(BookingsDbContext dbContext) : base(dbContext)
    {
        _dbContext = dbContext;
    }
}
