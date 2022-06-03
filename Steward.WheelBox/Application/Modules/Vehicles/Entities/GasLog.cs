using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Steward.WheelBox.Application.Modules.DataReferences.Entities;
using Steward.WheelBox.Application.Shared.Models;
using Steward.WheelBox.Infrastructure.Constants;

namespace Steward.WheelBox.Application.Modules.Vehicles.Entities
{
    public class GasLog : BaseAuditableEntity
    {
        public int DetNo { get; }
        public decimal GasAmount { get; set; }
        public decimal GasVolume { get; set; }
        public int VehicleId { get; set; }
        public int GasAmountUnitId { get; set; }
        public int GasVolumeUnitId { get; set; }
        public string Remarks { get; set; } = string.Empty;


        public virtual Vehicle Vehicle { get; set; } = null!;
        public virtual Unit GasAmountUnit { get; set; } = null!;
        public virtual Unit GasVolumeUnit { get; set; } = null!;

        //TODO: Add location, gas brand


        public GasLog(decimal gasAmount = 0, decimal gasVolume = 0, int vehicleId = 0, int gasAmountUnitId = 0, int gasVolumeUnitId = 0, string remarks = "")
        {
            AssignValues(gasAmount, gasVolume, vehicleId, gasAmountUnitId, gasVolumeUnitId, remarks);
        }

        private void AssignValues(decimal gasAmount, decimal gasVolume, int vehicleId, int gasAmountUnitId, int gasVolumeUnitId, string remarks)
        {
            GasAmount = gasAmount;
            GasVolume = gasVolume;
            VehicleId = vehicleId;
            GasAmountUnitId = gasAmountUnitId;
            GasVolumeUnitId = gasVolumeUnitId;
            Remarks = remarks;
        }

        public void UpdateEntity(decimal gasAmount, decimal gasVolume, int vehicleId, int gasAmountUnitId, int gasVolumeUnitId, string remarks)
        {
            AssignValues(gasAmount, gasVolume, vehicleId, gasAmountUnitId, gasVolumeUnitId, remarks);
        }

    }

    public class VehicleGasLogConfiguration : IEntityTypeConfiguration<GasLog>
    {
        public void Configure(EntityTypeBuilder<GasLog> builder)
        {
            //Change Table and Column Naming
            builder.ToTable("tblgaslogs");
            builder.Property(p => p.DetNo).HasColumnName("detno");
            builder.Property(p => p.GasAmount).HasColumnName("gasamount");
            builder.Property(p => p.GasVolume).HasColumnName("gasvolume");
            builder.Property(p => p.VehicleId).HasColumnName("vehicleid");
            builder.Property(p => p.GasAmountUnitId).HasColumnName("gasamountunitid");
            builder.Property(p => p.GasVolumeUnitId).HasColumnName("gasvolumeunitid");
            builder.Property(p => p.Remarks).HasColumnName("remarks");

            //Keys
            builder.HasKey(p => p.DetNo).IsClustered();
            builder.HasOne(p => p.Vehicle).WithMany(p => p.GasLog).HasForeignKey(p=> p.VehicleId);
            builder.HasOne(p => p.GasAmountUnit).WithMany(p => p.GasAmountList).HasForeignKey(p => p.GasAmountUnitId);
            builder.HasOne(p => p.GasVolumeUnit).WithMany(p => p.GasVolumeList).HasForeignKey(p => p.GasVolumeUnitId);

            //Constraints and Default Value
            builder.Property(p => p.VehicleId)
                .IsRequired();
            builder.Property(p => p.GasAmountUnitId)
                .IsRequired();
            builder.Property(p => p.GasVolumeUnitId)
                .IsRequired();
            builder.Property(p => p.GasAmount)
                .HasColumnType(SqlServerSpecificSyntax.DecimalColumn())
                .HasDefaultValue(0.0m);
            builder.Property(p => p.GasVolume)
                .HasColumnType(SqlServerSpecificSyntax.DecimalColumn())
                .HasDefaultValue(0.0m);
            builder.Property(p => p.Remarks)
                .HasMaxLength(255)
                .HasDefaultValue("");

            //Add Indexes
            builder.HasIndex(p => p.VehicleId).IsClustered(false);

        }
    }
}
