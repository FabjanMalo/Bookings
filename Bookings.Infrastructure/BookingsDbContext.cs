﻿using Bookings.Application.Abstractions.Database;
using Bookings.Domain;
using Bookings.Domain.Apartments;
using Bookings.Domain.Bookings;
using Microsoft.EntityFrameworkCore;
using System;
using System.Reflection;

namespace Bookings.Infrastructure;
public class BookingsDbContext : DbContext, IApplicationContext
{
    public BookingsDbContext(DbContextOptions<BookingsDbContext> options) : base(options)
    { }

    public DbSet<Apartment> Apartments => Set<Apartment>();
    public DbSet<BookingEntity> Bookings { get; set; }
    public DbSet<User> Users { get; set; }
    public DbSet<Review> Reviews { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

        base.OnModelCreating(modelBuilder);
    }
}
