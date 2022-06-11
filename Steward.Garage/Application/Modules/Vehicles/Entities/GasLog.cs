using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Steward.Garage.Application.Modules.DataReferences.Entities;
using Steward.Garage.Application.Shared.Models;
using Steward.Garage.Infrastructure.Constants;

namespace Steward.Garage.Application.Modules.Vehicles.Entities
{
    public class GasLog : BaseAuditableEntity
    {
        public int GasLogId { get; }
        public decimal GasAmount { get; set; }
        public decimal GasVolume { get; set; }
        public int VehicleId { get; set; }
        public int GasAmountUnitId { get; set; }
        public int GasVolumeUnitId { get; set; }
        public int OdometerLogId { get; set; }
        public string Remarks { get; set; } = string.Empty;
        public DateTime? LogDate { get; set; } = DateTime.MinValue;


        public virtual Vehicle Vehicle { get; set; } = null!;
        public virtual Unit GasAmountUnit { get; set; } = null!;
        public virtual Unit GasVolumeUnit { get; set; } = null!;
        public virtual OdometerLog OdometerLog { get; set; } = null!;

        //TODO: Add location, gas brand


        public GasLog(decimal gasAmount, decimal gasVolume, int vehicleId, int gasAmountUnitId, int gasVolumeUnitId, string remarks, int odometerLogId)
        {
            AssignValues(gasAmount, gasVolume, vehicleId, gasAmountUnitId, gasVolumeUnitId, remarks, odometerLogId);
        }

        private void AssignValues(decimal gasAmount = 0, decimal gasVolume = 0, int vehicleId = 0, int gasAmountUnitId = 0, int gasVolumeUnitId = 0, string remarks = "", int odometerLogId = 0)
        {
            GasAmount = gasAmount;
            GasVolume = gasVolume;
            VehicleId = vehicleId;
            GasAmountUnitId = gasAmountUnitId;
            GasVolumeUnitId = gasVolumeUnitId;
            Remarks = remarks;
            OdometerLogId = odometerLogId;
        }

        public void UpdateEntity(decimal gasAmount, decimal gasVolume, int vehicleId, int gasAmountUnitId, int gasVolumeUnitId, string remarks, int odometerLogId)
        {
            AssignValues(gasAmount, gasVolume, vehicleId, gasAmountUnitId, gasVolumeUnitId, remarks, odometerLogId);
        }

    }

    public class VehicleGasLogConfiguration : IEntityTypeConfiguration<GasLog>
    {
        public void Configure(EntityTypeBuilder<GasLog> builder)
        {
            //Change Table and Column Naming
            builder.ToTable("tblgaslogs");
            builder.Property(p => p.GasLogId).HasColumnName("gaslogid");
            builder.Property(p => p.GasAmount).HasColumnName("gasamount");
            builder.Property(p => p.GasVolume).HasColumnName("gasvolume");
            builder.Property(p => p.VehicleId).HasColumnName("vehicleid");
            builder.Property(p => p.GasAmountUnitId).HasColumnName("gasamountunitid");
            builder.Property(p => p.GasVolumeUnitId).HasColumnName("gasvolumeunitid");
            builder.Property(p => p.OdometerLogId).HasColumnName("odometerlogid");
            builder.Property(p => p.Remarks).HasColumnName("remarks");
            builder.Property(p => p.LogDate).HasColumnName("logdate");


            //Keys
            builder.HasKey(p => p.GasLogId).IsClustered();
            builder.HasOne(p => p.Vehicle).WithMany(p => p.GasLogList).HasForeignKey(p => p.VehicleId).OnDelete(DeleteBehavior.Cascade);
            builder.HasOne(p => p.GasAmountUnit).WithMany(p => p.GasAmountList).HasForeignKey(p => p.GasAmountUnitId).OnDelete(DeleteBehavior.ClientSetNull);
            builder.HasOne(p => p.GasVolumeUnit).WithMany(p => p.GasVolumeList).HasForeignKey(p => p.GasVolumeUnitId).OnDelete(DeleteBehavior.ClientSetNull);
            builder.HasOne(p => p.OdometerLog).WithOne(p => p.GasLog).HasForeignKey<OdometerLog>(p => p.OdometerLogId);


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
            builder.Property(p => p.LogDate).HasDefaultValue(SqlServerSpecificSyntax.DefaultDateTime);

            //Add Indexes
            builder.HasIndex(p => p.VehicleId).IsClustered(false);


            //Base Auditable Entity Config
            builder.Property(p => p.DateCreated).HasColumnName("datecreated").HasDefaultValue(SqlServerSpecificSyntax.DefaultDateTime);
            builder.Property(p => p.DateLastModified).HasColumnName("datelastmodified").HasDefaultValue(SqlServerSpecificSyntax.DefaultDateTime);
            builder.Property(p => p.DateDeleted).HasColumnName("datedeleted").HasDefaultValue(SqlServerSpecificSyntax.DefaultDateTime);
            builder.Property(p => p.LastModifiedBy).HasColumnName("lastmodifiedby").HasMaxLength(500).HasDefaultValue("");
            builder.Property(p => p.CreatedBy).HasColumnName("createdby").HasMaxLength(500).HasDefaultValue("");
            builder.Property(p => p.DeletedBy).HasColumnName("deletedby").HasMaxLength(500).HasDefaultValue("");
            builder.Property(p => p.IsDeleted).HasColumnName("isdeleted").HasDefaultValue(false);


        }
    }
}
