using Bookings.Application.Apartments;
using Bookings.Domain.Apartments;
using Bookings.Infrastructure.Contracts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookings.Infrastructure.Apartments;
public class ApartmentRepository(BookingsDbContext dbContext) : GenericRepository<Apartment>(dbContext), IApartmentRepository
{
    private readonly BookingsDbContext _dbContext = dbContext;

    public async Task<bool> IsNameUnique(string name, CancellationToken cancellationToken)
    {
        var isUnique = await _dbContext.Apartments
            .Where(c => c.Name == name).ToListAsync(cancellationToken);

        return isUnique.Count == 0;
    }
}
