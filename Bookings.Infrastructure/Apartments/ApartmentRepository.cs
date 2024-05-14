using Bookings.Application.Apartments;
using Bookings.Domain.Apartments;
using Bookings.Infrastructure.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookings.Infrastructure.Apartments;
public class ApartmentRepository : GenericRepository<Apartment>, IApartmentRepository
{
    private readonly BookingsDbContext _dbContext;

    public ApartmentRepository(BookingsDbContext dbContext) : base(dbContext)
    {
        _dbContext = dbContext;
    }
}
