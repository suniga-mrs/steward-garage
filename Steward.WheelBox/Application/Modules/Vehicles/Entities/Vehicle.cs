using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Steward.WheelBox.Application.Shared.Models;

namespace Steward.WheelBox.Application.Modules.Vehicles.Entities
{
    public class Vehicle : BaseAuditableEntity
    {
        public Vehicle()
        {

        }

        public Vehicle(string make, string model, short year, string plateNo, string chassisNo, string engineNo)
        {
            Make = make.ToUpper().Trim();
            Model = model.ToUpper().Trim();
            Year = year;
            PlateNo = plateNo.Trim();
            NormalizedPlateNo = plateNo.ToUpper().Trim();
            ChassisNo = chassisNo.Trim();
            NormalizedChassisNo = chassisNo.ToUpper().Trim();
            EngineNo = engineNo.Trim();
            NormalizedEngineNo = engineNo.ToUpper().Trim();
        }

        public int VehicleId { get; }
        public Guid VehicleGuid { get; }
        public string Make { get; set; } = string.Empty;
        public string Model { get; set; } = string.Empty;
        public Int16 Year { get; set; } = 0;
        public string PlateNo { get; set; } = string.Empty;
        public string NormalizedPlateNo { get; private set; } = string.Empty;
        public string ChassisNo { get; set; } = string.Empty;
        public string NormalizedChassisNo { get; private set; } = string.Empty;
        public string EngineNo { get; set; } = string.Empty;
        public string NormalizedEngineNo { get; } = string.Empty;
        
    }

    public class VehicleConfiguration : IEntityTypeConfiguration<Vehicle>
    {
        public void Configure(EntityTypeBuilder<Vehicle> builder)
        {
            builder.HasKey(p => p.VehicleId).IsClustered();
            builder.HasAlternateKey(p => p.VehicleGuid).IsClustered(false);
            builder.Property(p => p.VehicleGuid).HasDefaultValueSql("NEWID()"); //TODO: change this in case of different database

            builder.Property(p => p.Make).HasMaxLength(50).HasDefaultValue("");
            builder.Property(p => p.Model).HasMaxLength(50).HasDefaultValue("");
            builder.Property(p => p.PlateNo).HasMaxLength(100).HasDefaultValue("");
            builder.Property(p => p.ChassisNo).HasMaxLength(100).HasDefaultValue("");
            builder.Property(p => p.EngineNo).HasMaxLength(100).HasDefaultValue("");

            builder.Property(p => p.IsDeleted).HasDefaultValue(false);

            builder.Property(p => p.NormalizedPlateNo)
                .HasMaxLength(100)
                .HasDefaultValue("");

            builder.Property(p => p.NormalizedChassisNo)
               .HasMaxLength(100)
               .HasDefaultValue("");

            builder.Property(p => p.NormalizedEngineNo)
               .HasMaxLength(100)
               .HasDefaultValue("");

            builder.HasIndex(p => p.NormalizedPlateNo).IsClustered(false);
            builder.HasIndex(p => p.NormalizedChassisNo).IsClustered(false);
            builder.HasIndex(p => p.NormalizedEngineNo).IsClustered(false);

        }
    }
}
