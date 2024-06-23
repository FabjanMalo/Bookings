using Bookings.Domain.Apartments;
using Bookings.Domain.Users;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookings.Application.Abstractions.Database;
public interface IApplicationContext
{
    public DbSet<Apartment> Apartments { get; }

    public DbSet<User> Users { get; }

    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
}
