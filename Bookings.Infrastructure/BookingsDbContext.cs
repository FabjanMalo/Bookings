using Bookings.Application.Abstractions.Database;
using Bookings.Domain.Apartments;
using Bookings.Domain.Bookings;
using Bookings.Domain.Reviews;
using Bookings.Domain.Users;
using Microsoft.EntityFrameworkCore;
using System;
using System.Reflection;

namespace Bookings.Infrastructure;
public class BookingsDbContext : DbContext, IApplicationContext
{
    public BookingsDbContext(DbContextOptions<BookingsDbContext> options) : base(options)
    { }

    public DbSet<Apartment> Apartments => Set<Apartment>();
    public DbSet<BookingEntity> Bookings => Set<BookingEntity>();
    public DbSet<User> Users => Set<User>();
    public DbSet<Review> Reviews => Set<Review>();
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

        base.OnModelCreating(modelBuilder);
    }
}
