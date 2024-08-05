using Bookings.Application.Owners;
using Bookings.Domain.ApartmentOwners;
using Bookings.Infrastructure.Contracts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookings.Infrastructure.Owners;
public class ApartmentOwnerRepository
    : GenericRepository<ApartmentOwner>
    , IApartmentOwnerRepository
{
    private readonly BookingsDbContext _dbContext;

    public ApartmentOwnerRepository(BookingsDbContext dbContext) : base(dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<bool> IsEmailUnique(string email, CancellationToken cancellationToken)
    {
        var isUnique = await _dbContext.ApartmentOwners
            .Where(c => c.Email == email).ToListAsync(cancellationToken);

        return isUnique.Count == 0;
    }
}
