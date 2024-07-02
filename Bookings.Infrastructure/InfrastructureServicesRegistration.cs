using Bookings.Application.Abstractions.Database;
using Bookings.Application.Apartments;
using Bookings.Application.Bookings;
using Bookings.Application.Contracts;
using Bookings.Application.Mail;
using Bookings.Application.Users;
using Bookings.Infrastructure.Apartments;
using Bookings.Infrastructure.Bookings;
using Bookings.Infrastructure.Contracts;
using Bookings.Infrastructure.Mail;
using Bookings.Infrastructure.Users;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookings.Infrastructure;
public static class InfrastructureServicesRegistration
{
    public static IServiceCollection ConfigureInfrastructureServices(
        this IServiceCollection services,
        IConfiguration configuration)
    {
        services.AddDbContext<BookingsDbContext>(op =>
            op.UseSqlServer(
                configuration.GetConnectionString("BookingsConnectingString")));

        services.AddScoped<IApplicationContext>(
            sp => sp.GetRequiredService<BookingsDbContext>());


        services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));

        services.AddScoped<IApartmentRepository, ApartmentRepository>();

        services.AddScoped<IUserRepository, UserRepository>();

        services.AddScoped<IBookingRepository, BookingRepository>();


        services.AddTransient<IEmailSender, EmailSender>();

        services.Configure<EmailSettings>(configuration.GetSection("EmailSettings"));

        return services;
    }
}
