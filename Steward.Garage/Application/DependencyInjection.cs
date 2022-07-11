using AutoMapper;
using FluentValidation.AspNetCore;
using MediatR;
using Steward.Garage.Application.Modules.DataReferences.Interfaces;
using Steward.Garage.Application.Modules.DataReferences.Services;
using Steward.Garage.Application.Modules.Drivers.Interfaces;
using Steward.Garage.Application.Modules.Drivers.Services;
using Steward.Garage.Application.Modules.Vehicles.Interfaces;
using Steward.Garage.Application.Modules.Vehicles.Services;
using Steward.Garage.Application.Shared.Interfaces;
using Steward.Garage.Application.Shared.Mappings;
using Steward.Garage.Infrastructure.Services;
using System.Reflection;

namespace Steward.Garage.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services, IConfiguration configuration)
        {

            services.AddMappingConfiguration();
            services.AddFluentValidation(options =>
            {
                options.AutomaticValidationEnabled = true;
                options.RegisterValidatorsFromAssembly(Assembly.GetExecutingAssembly());
            });
            //services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
            services.AddMediatR(Assembly.GetExecutingAssembly());


            services.AddTransient<IDateTime, DateTimeService>();
            services.AddTransient<IVehicleService, VehicleService>();
            services.AddTransient<IDriverService, DriverService>();
            services.AddTransient<IUnitService, UnitService>();



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
