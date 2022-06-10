using Steward.WheelBox.Application;
using Steward.WheelBox.Application.Shared.Services;
using Steward.WheelBox.Core.Extensions;
using Steward.WheelBox.Core.Middlewares;
using Steward.WheelBox.Infrastructure;

namespace Steward.WheelBox
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            var configuration = builder.Configuration;
            var services = builder.Services;

            // Add services to the container.
            services.AddApplication(configuration);
            services.AddInfrastructure(configuration);

            // Presentation services

            services.AddSingleton<ICurrentUserService, CurrentUserService>();
            services.AddHttpContextAccessor();

            // End 

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