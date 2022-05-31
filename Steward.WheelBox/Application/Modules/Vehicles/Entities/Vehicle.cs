using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Steward.WheelBox.Application.Shared.Models;
using Steward.WheelBox.Core.Helpers;
using Steward.WheelBox.Infrastructure.Constants;

namespace Steward.WheelBox.Application.Modules.Vehicles.Entities
{
    public class Vehicle : BaseAuditableEntity
    {
        public Vehicle(string make, string model, short year, string plateNo, string chassisNo, string engineNo)
        {
            AssignValues(make, model, year, plateNo, chassisNo, engineNo);
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
        public string NormalizedEngineNo { get; private set; } = string.Empty;

        public void UpdateEntity(string make, string model, short year, string plateNo, string chassisNo, string engineNo)
        {
            AssignValues(make, model, year, plateNo, chassisNo, engineNo);
        }

        private void AssignValues(string make, string model, short year, string plateNo, string chassisNo, string engineNo)
        {
            Make = make.ToUpper().Trim();
            Model = model.ToUpper().Trim();
            Year = year;
            PlateNo = plateNo.Trim();
            ChassisNo = chassisNo.Trim();
            EngineNo = engineNo.Trim();
            NormalizedPlateNo = Utility.NormalizeValue(plateNo);
            NormalizedChassisNo = Utility.NormalizeValue(chassisNo);
            NormalizedEngineNo = Utility.NormalizeValue(engineNo);
        }
        
    }

    public class VehicleConfiguration : IEntityTypeConfiguration<Vehicle>
    {
        public void Configure(EntityTypeBuilder<Vehicle> builder)
        {

            //Change Table and Column Naming
            builder.ToTable("tblvehicles");
            builder.Property(p => p.VehicleId).HasColumnName("vehicleid");
            builder.Property(p => p.VehicleGuid).HasColumnName("vehicleguid");
            builder.Property(p => p.Make).HasColumnName("make");
            builder.Property(p => p.Model).HasColumnName("model");
            builder.Property(p => p.PlateNo).HasColumnName("plateno");
            builder.Property(p => p.NormalizedPlateNo).HasColumnName("normalizedplateno");
            builder.Property(p => p.ChassisNo).HasColumnName("chassisno");
            builder.Property(p => p.NormalizedChassisNo).HasColumnName("normalizedchassisno");
            builder.Property(p => p.EngineNo).HasColumnName("engineno");
            builder.Property(p => p.NormalizedEngineNo).HasColumnName("normalizedengineno");

            //Primary and Alternate Key
            builder.HasKey(p => p.VehicleId).IsClustered();
            builder.HasAlternateKey(p => p.VehicleGuid).IsClustered(false);
            builder.Property(p => p.VehicleGuid).HasDefaultValueSql(SqlServerSpecificSyntax.UniqueId); //TODO: change this in case of different database as this function is only available in SQL Server

            //Constraints and Default Value
            builder.Property(p => p.Make).HasMaxLength(50).HasDefaultValue("");
            builder.Property(p => p.Model).HasMaxLength(50).HasDefaultValue("");
            builder.Property(p => p.PlateNo).HasMaxLength(100).HasDefaultValue("");
            builder.Property(p => p.ChassisNo).HasMaxLength(100).HasDefaultValue("");
            builder.Property(p => p.EngineNo).HasMaxLength(100).HasDefaultValue("");

            //Setup for Normalized Columns
            builder.Property(p => p.NormalizedPlateNo)
                .HasMaxLength(100)
                .HasDefaultValue("");
            builder.Property(p => p.NormalizedChassisNo)
               .HasMaxLength(100)
               .HasDefaultValue("");
            builder.Property(p => p.NormalizedEngineNo)
               .HasMaxLength(100)
               .HasDefaultValue("");

            //Add Indexes
            builder.HasIndex(p => p.NormalizedPlateNo).IsClustered(false);
            builder.HasIndex(p => p.NormalizedChassisNo).IsClustered(false);
            builder.HasIndex(p => p.NormalizedEngineNo).IsClustered(false);

        }
    }
}
