using Bookings.Application.Users;
using Bookings.Domain.Users;
using Bookings.Infrastructure.Contracts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookings.Infrastructure.Users;
public class UserRepository : GenericRepository<User>, IUserRepository
{
    private readonly BookingsDbContext _dbContext;

    public UserRepository(BookingsDbContext dbContext) : base(dbContext)
    {
        _dbContext = dbContext;
    }
    public async Task<bool> IsEmailUnique(string email, CancellationToken cancellationToken)
    {
        var isUnique = await _dbContext.Users
            .Where(u => u.Email == email)
            .ToListAsync(cancellationToken);

        return !isUnique.Any();
    }
}
