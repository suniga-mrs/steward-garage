using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Steward.Garage.Application.Modules.BusinessProviders.Entities;
using Steward.Garage.Application.Shared.Models;
using Steward.Garage.Infrastructure.Constants;

namespace Steward.Garage.Application.Modules.Vehicles.Entities
{
    public class MaintenanceLog : BaseAuditableEntity
    {
        public int MaintenanceLogId { get; }
        public decimal TotalAmount { get; set; }
        public int TotalAmountUnitId { get; set; }
        public string Remarks { get; set; } = string.Empty;
        public int ServiceById { get; set; }
        public int VehicleId { get; set; }
        public int OdometerLogId { get; set; }
        public DateTime? LogDate { get; set; } = DateTime.MinValue;


        public virtual OdometerLog OdometerLog { get; set; } = null!;
        public virtual BusinessProvider ServiceBy { get; set; } = null!;
        public virtual Vehicle Vehicle { get; set; } = null!;

        public MaintenanceLog()
        {

        }


        public MaintenanceLog(decimal totalAmount, int totalAmountUnitId, string remarks, int serviceById, int vehicleId, int odometerId, DateTime? logDate)
        {
            AssignValues(totalAmount, totalAmountUnitId, remarks, serviceById, vehicleId, odometerId, logDate);

        }
        private void AssignValues(decimal totalAmount = 0, int totalAmountUnitId = 0, string remarks = "", int serviceById = 0, int vehicleId = 0, int odometerId = 0, DateTime? logDate = null)
        {
            TotalAmount = totalAmount;
            TotalAmountUnitId = totalAmountUnitId;
            Remarks = remarks;
            ServiceById = serviceById;
            VehicleId = vehicleId;
            OdometerLogId = odometerId;
            LogDate = logDate;
        }


        public void UpdateEntity(decimal totalAmount, int totalAmountUnitId, string remarks, int serviceById, int vehicleId, int odometerId, DateTime? logDate)
        {
            AssignValues(totalAmount, totalAmountUnitId, remarks, serviceById, vehicleId, odometerId, logDate);

        }
    }

    public class MaintenanceLogConfiguration : IEntityTypeConfiguration<MaintenanceLog>
    {
        public void Configure(EntityTypeBuilder<MaintenanceLog> builder)
        {
            //Change Table and Column Naming
            builder.ToTable("tblmaintenancelogs");
            builder.Property(p => p.MaintenanceLogId).HasColumnName("maintenancelogid");
            builder.Property(p => p.TotalAmount).HasColumnName("totalamount");
            builder.Property(p => p.TotalAmountUnitId).HasColumnName("totalamountunitid");
            builder.Property(p => p.Remarks).HasColumnName("remarks");
            builder.Property(p => p.ServiceById).HasColumnName("servicebyid");
            builder.Property(p => p.VehicleId).HasColumnName("vehicleid");
            builder.Property(p => p.OdometerLogId).HasColumnName("odometerlogid");
            builder.Property(p => p.LogDate).HasColumnName("logdate");


            //Keys
            builder.HasKey(p => p.MaintenanceLogId).IsClustered();
            builder.HasOne(p => p.ServiceBy).WithMany(p => p.MaintenanceLogList).HasForeignKey(p => p.VehicleId).OnDelete(DeleteBehavior.Cascade);
            builder.HasOne(p => p.Vehicle).WithMany(p => p.MaintenanceLogList).HasForeignKey(p => p.VehicleId).OnDelete(DeleteBehavior.Cascade);
            builder.HasOne(p => p.OdometerLog).WithOne(p => p.MaintenanceLog).HasForeignKey<OdometerLog>(p => p.OdometerLogId);


            //Constraints and Default Value
            builder.Property(p => p.TotalAmount)
                  .HasColumnType(SqlServerSpecificSyntax.DecimalColumn())
                  .HasDefaultValue(0);
            builder.Property(p => p.TotalAmountUnitId).HasDefaultValue(0);
            builder.Property(p => p.Remarks).HasDefaultValue("");
            builder.Property(p => p.ServiceById).HasDefaultValue(0);
            builder.Property(p => p.VehicleId)
                .IsRequired()
                .HasDefaultValue(0);
            builder.Property(p => p.OdometerLogId).HasDefaultValue(0);
            builder.Property(p => p.LogDate).HasDefaultValue(SqlServerSpecificSyntax.DefaultDateTime);


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
