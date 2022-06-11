using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Steward.WheelBox.Application.Modules.DataReferences.Entities;
using Steward.WheelBox.Application.Shared.Models;
using Steward.WheelBox.Infrastructure.Constants;

namespace Steward.WheelBox.Application.Modules.Vehicles.Entities
{
    public class OdometerLog : BaseAuditableEntity
    {
        public int OdometerLogId { get; }
        public DateTime? DateRead { get; set; } = DateTime.MinValue;
        public decimal Reading { get; set; } 
        public int VehicleId { get; set; }        
        public int ReadingUnitId { get; set; }
        //public int GasLogId { get; set; }
        //public int MaintenanceLogId { get; set; }


        public virtual Vehicle Vehicle { get; set; } = null!;
        public virtual Unit ReadingUnit { get; set; } = null!;
        public virtual GasLog? GasLog { get; set; } = null!;
        public virtual MaintenanceLog? MaintenanceLog { get; set; } = null!;

        public OdometerLog()
        {

        }


        public OdometerLog(DateTime? dateRead = null, decimal reading = 0.0m, int vehicleId = 0, int readingUnitId = 0, int gasLogId = 0, int maintenanceLogId = 0)
        {
            AssignValues(dateRead, reading, vehicleId, readingUnitId, gasLogId, maintenanceLogId);
        }

        private void AssignValues(DateTime? dateRead = null, decimal reading = 0.0m, int vehicleId = 0, int readingUnitId = 0, int gasLogId = 0, int maintenanceLogId = 0)
        {
            DateRead = dateRead;
            Reading = reading;
            VehicleId = vehicleId;
            ReadingUnitId = readingUnitId;
            //GasLogId = gasLogId;
            //MaintenanceLogId = maintenanceLogId;
        }

        public void UpdateEntity(DateTime? dateRead = null, decimal reading = 0.0m, int vehicleId = 0, int readingUnitId = 0, int gasLogId = 0, int maintenanceLogId = 0)
        {
            AssignValues(dateRead, reading, vehicleId, readingUnitId, gasLogId, maintenanceLogId);
        }

    }

    public class OdometerConfiguration : IEntityTypeConfiguration<OdometerLog>
    {
        public void Configure(EntityTypeBuilder<OdometerLog> builder)
        {

            //Change Table and Column Naming
            builder.ToTable("tblodometerlogs");
            builder.Property(p => p.OdometerLogId).HasColumnName("odometerlogid");
            builder.Property(p => p.DateRead).HasColumnName("dateread");
            builder.Property(p => p.Reading).HasColumnName("reading");
            builder.Property(p => p.VehicleId).HasColumnName("vehicleid");
            builder.Property(p => p.ReadingUnitId).HasColumnName("readingunitid");
            //builder.Property(p => p.GasLogId).HasColumnName("gaslogid");
            //builder.Property(p => p.MaintenanceLogId).HasColumnName("maintenancelogid");

            //Primary and Alternate Key
            builder.HasKey(p => p.OdometerLogId).IsClustered();
            builder.HasOne(p => p.Vehicle).WithMany(p => p.OdometerLogList).HasForeignKey(p => p.VehicleId).OnDelete(DeleteBehavior.Cascade);
            builder.HasOne(p => p.ReadingUnit).WithMany(p => p.OdometerReadingList).HasForeignKey(p => p.ReadingUnitId).OnDelete(DeleteBehavior.ClientSetNull);

            //Constraints and Default Value
            builder.Property(p => p.DateRead).HasDefaultValue(SqlServerSpecificSyntax.DefaultDateTime);
            builder.Property(p => p.Reading)
                .HasColumnType(SqlServerSpecificSyntax.DecimalColumn())
                .HasDefaultValue(0);
            builder.Property(p => p.VehicleId).IsRequired();
            builder.Property(p => p.ReadingUnitId).IsRequired();
                

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
