using Microsoft.EntityFrameworkCore;
using Steward.Garage.Application.Shared.Interfaces;
using Steward.Garage.Core.Constants;
using Steward.Garage.Infrastructure.Persistence;
using Steward.Garage.Infrastructure.Persistence.Interceptors;

namespace Steward.Garage.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration) 
        {
            services.AddScoped<AuditableEntitySaveChangesInterceptor>();

            services.AddDbContext<ApplicationDbContext>(
                options =>
                options.UseSqlServer(configuration.GetConnectionString(Settings.WheelboxDbConnection))
            );

            services.AddScoped<IApplicationDbContext, ApplicationDbContext>();

            return services;

        }
    }
}
