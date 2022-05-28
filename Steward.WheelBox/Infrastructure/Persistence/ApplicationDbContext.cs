using Microsoft.EntityFrameworkCore;
using Steward.WheelBox.Application.Shared.Interfaces;
using Steward.WheelBox.Application.Shared.Models;
using Steward.WheelBox.Application.Modules.Vehicles.Entities;
using System.Data;
using System.Reflection;
using Steward.WheelBox.Application.Shared.Services;
using Steward.WheelBox.Infrastructure.Persistence.Interceptors;
using MediatR;

namespace Steward.WheelBox.Infrastructure.Persistence
{
    // dotnet ef migrations add "Initial" -o "Infrastructure/Migrations/SqlServer"

    public class ApplicationDbContext : DbContext, IApplicationDbContext
    {
        private readonly AuditableEntitySaveChangesInterceptor _auditableEntitySaveChangesInterceptor;
        public ApplicationDbContext(
            DbContextOptions<ApplicationDbContext> options,
            AuditableEntitySaveChangesInterceptor auditableEntitySaveChangesInterceptor
            )
            : base(options)
        {
            _auditableEntitySaveChangesInterceptor = auditableEntitySaveChangesInterceptor;
        }

        public IDbConnection Connection => Database.GetDbConnection();

        public DbSet<Vehicle> Vehicles => Set<Vehicle>();

        protected override void OnModelCreating(ModelBuilder builder)
        {

            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            base.OnModelCreating(builder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.AddInterceptors(_auditableEntitySaveChangesInterceptor);
        }

        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            //await _mediator.DispatchDomainEvents(this);

            return await base.SaveChangesAsync(cancellationToken);
        }


    }


 
}
