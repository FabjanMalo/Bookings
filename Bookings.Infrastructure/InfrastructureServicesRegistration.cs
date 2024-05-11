using Bookings.Application.IRepository;
using Bookings.Infrastructure.Repository;
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
    public static IServiceCollection ConfigureInfrastructureServices
        (this IServiceCollection services, IConfiguration configuration)
    {
       

        return services;
    }
}
