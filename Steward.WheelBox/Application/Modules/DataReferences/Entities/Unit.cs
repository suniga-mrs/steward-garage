using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Steward.WheelBox.Application.Modules.Vehicles.Entities;
using Steward.WheelBox.Application.Shared.Models;
using Steward.WheelBox.Infrastructure.Constants;

namespace Steward.WheelBox.Application.Modules.DataReferences.Entities
{
    public class Unit : BaseAuditableEntity
    {
        public int UnitId { get; }
        public string Name { get; set; } = string.Empty;
        public string Prefix { get; set; } = string.Empty;
        public string Suffix { get; set; } = string.Empty;

        public virtual IList<GasLog> GasAmountList { get; } = null!;
        public virtual IList<GasLog> GasVolumeList { get; } = null!;
        public virtual IList<OdometerLog> OdometerReadingList { get; } = null!;


        public Unit(string name = "", string prefix = "", string suffix = "")
        {
            AssignValues(name, prefix, suffix);
        }

        private void AssignValues(string name = "", string prefix = "", string suffix = "")
        {
            Name = name.ToUpper();
            Prefix = prefix.ToUpper();
            Suffix = suffix.ToUpper();
        }

        public void UpdateEntity(string name = "", string prefix = "", string suffix = "")
        {
            AssignValues(name, prefix, suffix);
        }

        public string FormatNumber(decimal number)
        {
            string _number = String.Format("{0:n}", number);

            if (!string.IsNullOrEmpty(Prefix)) _number = Prefix + " " + _number;
            if (!string.IsNullOrEmpty(Suffix)) _number = _number + " " + Suffix;

            return _number.ToUpper();
        }

    }

    public class UnitConfiguration : IEntityTypeConfiguration<Unit>
    {
        public void Configure(EntityTypeBuilder<Unit> builder)
        {
            //Change Table and Column Naming
            builder.ToTable("tblunits");
            builder.Property(p => p.UnitId).HasColumnName("unitid");
            builder.Property(p => p.Name).HasColumnName("name");
            builder.Property(p => p.Prefix).HasColumnName("prefix");
            builder.Property(p => p.Suffix).HasColumnName("suffix");

            //Primary and Alternate Key
            builder.HasKey(p => p.UnitId).IsClustered();

            //Constraints and Default Value
            builder.Property(p => p.Name).HasMaxLength(50).HasDefaultValue("");
            builder.Property(p => p.Prefix).HasMaxLength(10).HasDefaultValue("");
            builder.Property(p => p.Suffix).HasMaxLength(10).HasDefaultValue("");

            //Add Indexes
            builder.HasIndex(p => p.Name).IsClustered(false);

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
