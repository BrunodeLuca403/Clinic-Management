using ClinicManagement.API.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace ClinicManagement.Infrastructure
{
    public static class InfrastructureModule
    {
        public static IServiceCollection AddInfractructure(this IServiceCollection services, IConfiguration configuration)
        {
            services
                .AddData(configuration);

            return services;
        }

        public static IServiceCollection AddData(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("ClinicConnection");

            services.AddDbContext<ClinicDbContext>(e => e.UseSqlServer(connectionString));

            return services;
        }
    }
}
