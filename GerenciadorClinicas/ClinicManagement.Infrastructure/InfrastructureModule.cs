using ClinicManagement.API.Context;
using ClinicManagement.Core.Repository;
using ClinicManagement.Infrastructure.Caching;
using ClinicManagement.Infrastructure.Repository;
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

            services.AddRepository();

            return services;
        }

        public static IServiceCollection AddData(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("ClinicConnection");

            services.AddDbContext<ClinicDbContext>(e => e.UseSqlServer(connectionString));

            return services;
        }

        public static IServiceCollection AddCaching(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddSingleton<ICachingService, CachingService>();
            services.AddStackExchangeRedisCache(o =>
            {
                o.Configuration = configuration.GetConnectionString("RedisConnection");
                o.InstanceName = "ClinicApp_";
            });


            return services;
        }

        public static IServiceCollection AddRepository(this IServiceCollection services)
        {
            services.AddScoped<ClinicDbContext, ClinicDbContext>();
            services.AddScoped<IServiceRepository, ServiceRepository>();
            services.AddScoped<IMedicRepository, MedicRepository>();
            services.AddScoped<ISpecialtyRepository, SpecialtyRepository>();
            services.AddScoped<ICareRepository, CareRepository>();
            services.AddScoped<IPatientRepository, PatientRepository>();

            return services;
        }
    }
}
