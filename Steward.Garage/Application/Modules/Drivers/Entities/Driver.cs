using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Steward.Garage.Application.Shared.Models;
using Steward.Garage.Infrastructure.Constants;

namespace Steward.Garage.Application.Modules.Drivers.Entities
{
    public class Driver : BaseAuditableEntity
    {
        public int DriverId { get; }
        public Guid DriverGuid { get; }
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string MiddleName { get; set; } = string.Empty;
        public string FullName { get; private set; } = string.Empty;
        public string Suffix { get; set; } = string.Empty;
        public string LicenseNo { get; set; } = string.Empty;
        public DateTime? Birthdate { get; set; } = DateTime.MinValue;
        public DateTime? LicenseExpiry { get; set; } = DateTime.MinValue;

        public Driver()
        {

        }

        public Driver(string firstName = "", string lastName = "", string middleName = "",
            string suffix = "", string licenseNo = "", DateTime? birthDate = null, DateTime? licenseExpiry = null)
        {
            AssignValues(firstName, lastName, middleName, suffix, licenseNo, birthDate, licenseExpiry);
        }

        private void AssignValues(string firstName, string lastName, string middleName,
            string suffix, string licenseNo, DateTime? birthDate, DateTime? licenseExpiry
            )
        {
            FirstName = firstName.ToUpper();
            LastName = lastName.ToUpper();
            MiddleName = middleName.ToUpper();
            FullName = JoinName(firstName, lastName, middleName, suffix);
            Suffix = suffix.ToUpper();
            LicenseNo = licenseNo.ToUpper();
            Birthdate = birthDate;
            LicenseExpiry = licenseExpiry;
        }

        public static string JoinName(string firstName = "", string lastName = "", string middleName = "", string suffix = "")
        {
            return $"{lastName}, {firstName} {middleName} {suffix}".ToUpper().Trim();
        }

        public void UpdateEntity(string firstName, string lastName, string middleName,
            string suffix, string licenseNo, DateTime? birthDate, DateTime? licenseExpiry)
        {
            AssignValues(firstName, lastName, middleName, suffix, licenseNo, birthDate, licenseExpiry);
        }
    }

    public class DriverConfiguration : IEntityTypeConfiguration<Driver>
    {
        public void Configure(EntityTypeBuilder<Driver> builder)
        {
            //Change Table and Column Naming
            builder.ToTable("tbldrivers");
            builder.Property(p => p.DriverId).HasColumnName("driverid");
            builder.Property(p => p.DriverGuid).HasColumnName("driverguid");
            builder.Property(p => p.FirstName).HasColumnName("firstname");
            builder.Property(p => p.LastName).HasColumnName("lastname");
            builder.Property(p => p.MiddleName).HasColumnName("middlename");
            builder.Property(p => p.FullName).HasColumnName("fullname");
            builder.Property(p => p.Suffix).HasColumnName("suffix");
            builder.Property(p => p.LicenseNo).HasColumnName("licenseno");
            builder.Property(p => p.Birthdate).HasColumnName("birthdate");
            builder.Property(p => p.LicenseExpiry).HasColumnName("licenseexpiry");

            //Primary and Alternate Key
            builder.HasKey(p => p.DriverId).IsClustered();
            builder.HasAlternateKey(p => p.DriverGuid).IsClustered(false);
            builder.Property(p => p.DriverGuid).HasDefaultValueSql(SqlServerSpecificSyntax.UniqueId); //TODO: change this in case of different database as this function is only available in SQL Server

            //Constraints and Default Value
            builder.Property(p => p.FirstName).HasMaxLength(50).HasDefaultValue("");
            builder.Property(p => p.LastName).HasMaxLength(50).HasDefaultValue("");
            builder.Property(p => p.MiddleName).HasMaxLength(50).HasDefaultValue("");
            builder.Property(p => p.FullName).HasMaxLength(150).HasDefaultValue("");
            builder.Property(p => p.Suffix).HasMaxLength(10).HasDefaultValue("");
            builder.Property(p => p.LicenseNo).HasMaxLength(30).HasDefaultValue("");

            //Add Indexes
            builder.HasIndex(p => p.FullName).IsClustered(false);
            builder.HasIndex(p => p.LicenseNo).IsClustered(false);


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
