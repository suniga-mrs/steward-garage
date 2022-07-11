using Steward.Garage.Application;
using Steward.Garage.Application.Shared.Services;
using Steward.Garage.Core.Extensions;
using Steward.Garage.Core.Middlewares;
using Steward.Garage.Infrastructure;

namespace Steward.Garage
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            var configuration = builder.Configuration;
            var services = builder.Services;

            services.AddHttpContextAccessor();

            // Add services to the container.
            services.AddApplication(configuration);
            services.AddInfrastructure(configuration);
            services.AddSingleton<ICurrentUserService, CurrentUserService>();

            services.AddCors(); 

            services.AddControllersWithViews();

            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();

            //services.AddSpaStaticFiles(configuration =>
            //{
            //    configuration.RootPath = "ClientApp/build";
            //});



            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();

                app.UseCors(x => x
                   .AllowAnyOrigin()
                   .AllowAnyMethod()
                   .AllowAnyHeader());

            }

            app.UseStaticFiles();

            app.UseHttpsRedirection();

            app.UseMiddleware<ExceptionMiddleware>();

            app.UseAuthorization();    
            
            //app.UseSpa(spa =>
            //{
            //    spa.Options.SourcePath = "ClientApp";

            //    if (app.Environment.IsDevelopment())
            //    {
            //        spa.UseProxyToSpaDevelopmentServer("https://localhost:4992/");
            //        //spa.UseReactDevelopmentServer(npmScript: "start");
            //    }
            //});

            app.MapControllers();

            app.Run();
        }

        
    }
}