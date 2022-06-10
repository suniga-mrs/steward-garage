using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Steward.WheelBox.Application.Modules.DataReferences.Entities;
using Steward.WheelBox.Application.Modules.Vehicles.Entities;
using System.Data;

namespace Steward.WheelBox.Application.Shared.Interfaces
{
    public interface IApplicationDbContext
    {

        IDbConnection Connection { get; }
        DatabaseFacade Database { get; }

        DbSet<Vehicle> Vehicles { get; }
        DbSet<Unit> Units { get; }
        DbSet<Driver> Drivers { get; }
        DbSet<GasLog> GasLogs { get; }


        Task<int> SaveChangesAsync(CancellationToken ct);
    }
}
