using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Steward.Garage.Application.Modules.Vehicles.Entities;
using Steward.Garage.Application.Shared.Models;
using Steward.Garage.Infrastructure.Constants;

namespace Steward.Garage.Application.Modules.BusinessProviders.Entities
{
    public class BusinessProvider : BaseAuditableEntity
    {
        public int ProviderId { get; }
        public string ProviderName { get; set; } = string.Empty;
        public string NormalizedProviderName { get; set; } = string.Empty;
        // Address
        // Google Location
        // Type - supplier, maintenance | Business Type
        public virtual IList<MaintenanceLog> MaintenanceLogList { get; set; } = null!;


        public BusinessProvider(string providerName)
        {
            AssignValues(providerName);
        }

        private void AssignValues(string providerName = "")
        {
            ProviderName = providerName.Trim();
            NormalizedProviderName = providerName.ToUpper().Trim();
        }

        public void UpdateEntity(string providerName)
        {
            AssignValues(providerName);
        }
    }

    public class BusinessProviderConfiguration : IEntityTypeConfiguration<BusinessProvider>
    {
        public void Configure(EntityTypeBuilder<BusinessProvider> builder)
        {
            //Change Table and Column Naming
            builder.ToTable("tblbusinessprovider");
            builder.Property(p => p.ProviderId).HasColumnName("providerid");
            builder.Property(p => p.ProviderName).HasColumnName("providername");

            //Primary and Alternate Key
            builder.HasKey(p => p.ProviderId).IsClustered();

            //Constraints and Default Value
            builder.Property(p => p.ProviderName).HasMaxLength(250).HasDefaultValue("");

            //Setup for Normalized Columns
            builder.Property(p => p.NormalizedProviderName)
                .HasMaxLength(250)
                .HasDefaultValue("");


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
