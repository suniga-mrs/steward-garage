using AutoMapper;
using MediatR;
using Steward.WheelBox.Application.Modules.Vehicles.Interfaces;
using Steward.WheelBox.Application.Modules.Vehicles.Services;
using Steward.WheelBox.Application.Shared.Interfaces;
using Steward.WheelBox.Application.Shared.Mappings;
using Steward.WheelBox.Application.Shared.Services;
using Steward.WheelBox.Infrastructure.Services;
using System.Reflection;

namespace Steward.WheelBox.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services, IConfiguration configuration)
        {

            services.AddMappingConfiguration();
            //services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
            services.AddMediatR(Assembly.GetExecutingAssembly());


            services.AddTransient<IDateTime, DateTimeService>();
            services.AddTransient<IVehicleService, VehicleService>();
       


            return services;
        }

        public static IServiceCollection AddMappingConfiguration(this IServiceCollection services)
        {

            //https://www.kafle.io/tutorials/asp-dot-net/automapper

            var configMapper = new MapperConfiguration(config =>
            {
                config.AddProfile(new MappingProfile());
            });

            var mapper = configMapper.CreateMapper();

            services.AddSingleton(mapper);

            return services;
        }
    }

}
