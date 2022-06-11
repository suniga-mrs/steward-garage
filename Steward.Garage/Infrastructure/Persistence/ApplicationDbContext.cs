using Microsoft.EntityFrameworkCore;
using Steward.Garage.Application.Shared.Interfaces;
using Steward.Garage.Application.Modules.Vehicles.Entities;
using System.Data;
using System.Reflection;
using Steward.Garage.Infrastructure.Persistence.Interceptors;
using Steward.Garage.Application.Modules.DataReferences.Entities;
using Steward.Garage.Application.Shared.Models;
using Steward.Garage.Application.Modules.BusinessProviders.Entities;

namespace Steward.Garage.Infrastructure.Persistence
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
        public DbSet<Unit> Units => Set<Unit>();
        public DbSet<GasLog> GasLogs => Set<GasLog>();
        public DbSet<Driver> Drivers => Set<Driver>();
        public DbSet<OdometerLog> OdometerLogs => Set<OdometerLog>();
        public DbSet<MaintenanceLog> MaintenanceLogs => Set<MaintenanceLog>();
        public DbSet<BusinessProvider> BusinessProviders => Set<BusinessProvider>();

        protected override void OnModelCreating(ModelBuilder builder)
        {

            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            //    builder.Entity<BaseAuditableEntity>()
            //.Property(p => )
            //.HasDefaultValue(3);

            //foreach (var entityType in builder.Model.GetEntityTypes())
            //{
            //    if (entityType.GetType() == typeof(BaseAuditableEntity))
            //    {

            //    }
            //}

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
