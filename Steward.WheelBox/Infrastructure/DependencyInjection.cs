using Microsoft.EntityFrameworkCore;
using Steward.WheelBox.Application.Shared.Interfaces;
using Steward.WheelBox.Core.Constants;
using Steward.WheelBox.Infrastructure.Persistence;
using Steward.WheelBox.Infrastructure.Persistence.Interceptors;

namespace Steward.WheelBox.Infrastructure
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

            services.AddScoped<IApplicationDbContext>
                (provider => provider.GetRequiredService<ApplicationDbContext>());

            return services;

        }
    }
}
