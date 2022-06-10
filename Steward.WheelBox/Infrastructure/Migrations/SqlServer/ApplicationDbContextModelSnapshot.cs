﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Steward.WheelBox.Infrastructure.Persistence;

#nullable disable

namespace Steward.WheelBox.Infrastructure.Migrations.SqlServer
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Steward.WheelBox.Application.Modules.DataReferences.Entities.Driver", b =>
                {
                    b.Property<int>("DriverId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("driverid");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("DriverId"), 1L, 1);

                    b.Property<DateTime?>("Birthdate")
                        .HasColumnType("datetime2")
                        .HasColumnName("birthdate");

                    b.Property<string>("CreatedBy")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)")
                        .HasDefaultValue("")
                        .HasColumnName("createdby");

                    b.Property<DateTime>("DateCreated")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValue(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified))
                        .HasColumnName("datecreated");

                    b.Property<DateTime>("DateDeleted")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValue(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified))
                        .HasColumnName("datedeleted");

                    b.Property<DateTime>("DateLastModified")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValue(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified))
                        .HasColumnName("datelastmodified");

                    b.Property<string>("DeletedBy")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)")
                        .HasDefaultValue("")
                        .HasColumnName("deletedby");

                    b.Property<Guid>("DriverGuid")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("driverguid")
                        .HasDefaultValueSql("NEWID()");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasDefaultValue("")
                        .HasColumnName("firstname");

                    b.Property<string>("FullName")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)")
                        .HasDefaultValue("")
                        .HasColumnName("fullname");

                    b.Property<bool>("IsDeleted")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(false)
                        .HasColumnName("isdeleted");

                    b.Property<string>("LastModifiedBy")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)")
                        .HasDefaultValue("")
                        .HasColumnName("lastmodifiedby");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasDefaultValue("")
                        .HasColumnName("lastname");

                    b.Property<DateTime?>("LicenseExpiry")
                        .HasColumnType("datetime2")
                        .HasColumnName("licenseexpiry");

                    b.Property<string>("LicenseNo")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)")
                        .HasDefaultValue("")
                        .HasColumnName("licenseno");

                    b.Property<string>("MiddleName")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasDefaultValue("")
                        .HasColumnName("middlename");

                    b.Property<string>("Suffix")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)")
                        .HasDefaultValue("")
                        .HasColumnName("suffix");

                    b.HasKey("DriverId");

                    SqlServerKeyBuilderExtensions.IsClustered(b.HasKey("DriverId"));

                    b.HasAlternateKey("DriverGuid");

                    SqlServerKeyBuilderExtensions.IsClustered(b.HasAlternateKey("DriverGuid"), false);

                    b.HasIndex("FullName");

                    SqlServerIndexBuilderExtensions.IsClustered(b.HasIndex("FullName"), false);

                    b.HasIndex("LicenseNo");

                    SqlServerIndexBuilderExtensions.IsClustered(b.HasIndex("LicenseNo"), false);

                    b.ToTable("tbldrivers", (string)null);
                });

            modelBuilder.Entity("Steward.WheelBox.Application.Modules.DataReferences.Entities.Unit", b =>
                {
                    b.Property<int>("UnitId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("unitid");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("UnitId"), 1L, 1);

                    b.Property<string>("CreatedBy")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)")
                        .HasDefaultValue("")
                        .HasColumnName("createdby");

                    b.Property<DateTime>("DateCreated")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValue(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified))
                        .HasColumnName("datecreated");

                    b.Property<DateTime>("DateDeleted")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValue(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified))
                        .HasColumnName("datedeleted");

                    b.Property<DateTime>("DateLastModified")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValue(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified))
                        .HasColumnName("datelastmodified");

                    b.Property<string>("DeletedBy")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)")
                        .HasDefaultValue("")
                        .HasColumnName("deletedby");

                    b.Property<bool>("IsDeleted")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(false)
                        .HasColumnName("isdeleted");

                    b.Property<string>("LastModifiedBy")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)")
                        .HasDefaultValue("")
                        .HasColumnName("lastmodifiedby");

                    b.Property<string>("Name")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasDefaultValue("")
                        .HasColumnName("name");

                    b.Property<string>("Prefix")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)")
                        .HasDefaultValue("")
                        .HasColumnName("prefix");

                    b.Property<string>("Suffix")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)")
                        .HasDefaultValue("")
                        .HasColumnName("suffix");

                    b.HasKey("UnitId");

                    SqlServerKeyBuilderExtensions.IsClustered(b.HasKey("UnitId"));

                    b.HasIndex("Name");

                    SqlServerIndexBuilderExtensions.IsClustered(b.HasIndex("Name"), false);

                    b.ToTable("tblunits", (string)null);
                });

            modelBuilder.Entity("Steward.WheelBox.Application.Modules.Vehicles.Entities.GasLog", b =>
                {
                    b.Property<int>("DetNo")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("detno");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("DetNo"), 1L, 1);

                    b.Property<string>("CreatedBy")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)")
                        .HasDefaultValue("")
                        .HasColumnName("createdby");

                    b.Property<DateTime>("DateCreated")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValue(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified))
                        .HasColumnName("datecreated");

                    b.Property<DateTime>("DateDeleted")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValue(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified))
                        .HasColumnName("datedeleted");

                    b.Property<DateTime>("DateLastModified")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValue(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified))
                        .HasColumnName("datelastmodified");

                    b.Property<string>("DeletedBy")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)")
                        .HasDefaultValue("")
                        .HasColumnName("deletedby");

                    b.Property<decimal>("GasAmount")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("decimal(18,2)")
                        .HasDefaultValue(0.0m)
                        .HasColumnName("gasamount");

                    b.Property<int>("GasAmountUnitId")
                        .HasColumnType("int")
                        .HasColumnName("gasamountunitid");

                    b.Property<decimal>("GasVolume")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("decimal(18,2)")
                        .HasDefaultValue(0.0m)
                        .HasColumnName("gasvolume");

                    b.Property<int>("GasVolumeUnitId")
                        .HasColumnType("int")
                        .HasColumnName("gasvolumeunitid");

                    b.Property<bool>("IsDeleted")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(false)
                        .HasColumnName("isdeleted");

                    b.Property<string>("LastModifiedBy")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)")
                        .HasDefaultValue("")
                        .HasColumnName("lastmodifiedby");

                    b.Property<string>("Remarks")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)")
                        .HasDefaultValue("")
                        .HasColumnName("remarks");

                    b.Property<int>("VehicleId")
                        .HasColumnType("int")
                        .HasColumnName("vehicleid");

                    b.HasKey("DetNo");

                    SqlServerKeyBuilderExtensions.IsClustered(b.HasKey("DetNo"));

                    b.HasIndex("GasAmountUnitId");

                    b.HasIndex("GasVolumeUnitId");

                    b.HasIndex("VehicleId");

                    SqlServerIndexBuilderExtensions.IsClustered(b.HasIndex("VehicleId"), false);

                    b.ToTable("tblgaslogs", (string)null);
                });

            modelBuilder.Entity("Steward.WheelBox.Application.Modules.Vehicles.Entities.Vehicle", b =>
                {
                    b.Property<int>("VehicleId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("vehicleid");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("VehicleId"), 1L, 1);

                    b.Property<string>("ChassisNo")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)")
                        .HasDefaultValue("")
                        .HasColumnName("chassisno");

                    b.Property<string>("CreatedBy")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)")
                        .HasDefaultValue("")
                        .HasColumnName("createdby");

                    b.Property<DateTime>("DateCreated")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValue(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified))
                        .HasColumnName("datecreated");

                    b.Property<DateTime>("DateDeleted")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValue(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified))
                        .HasColumnName("datedeleted");

                    b.Property<DateTime>("DateLastModified")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValue(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified))
                        .HasColumnName("datelastmodified");

                    b.Property<string>("DeletedBy")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)")
                        .HasDefaultValue("")
                        .HasColumnName("deletedby");

                    b.Property<string>("EngineNo")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)")
                        .HasDefaultValue("")
                        .HasColumnName("engineno");

                    b.Property<bool>("IsDeleted")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(false)
                        .HasColumnName("isdeleted");

                    b.Property<string>("LastModifiedBy")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)")
                        .HasDefaultValue("")
                        .HasColumnName("lastmodifiedby");

                    b.Property<string>("Make")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasDefaultValue("")
                        .HasColumnName("make");

                    b.Property<string>("Model")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasDefaultValue("")
                        .HasColumnName("model");

                    b.Property<string>("NormalizedChassisNo")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)")
                        .HasDefaultValue("")
                        .HasColumnName("normalizedchassisno");

                    b.Property<string>("NormalizedEngineNo")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)")
                        .HasDefaultValue("")
                        .HasColumnName("normalizedengineno");

                    b.Property<string>("NormalizedPlateNo")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)")
                        .HasDefaultValue("")
                        .HasColumnName("normalizedplateno");

                    b.Property<string>("PlateNo")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)")
                        .HasDefaultValue("")
                        .HasColumnName("plateno");

                    b.Property<Guid>("VehicleGuid")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("vehicleguid")
                        .HasDefaultValueSql("NEWID()");

                    b.Property<short>("Year")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("smallint")
                        .HasDefaultValue((short)0)
                        .HasColumnName("year");

                    b.HasKey("VehicleId");

                    SqlServerKeyBuilderExtensions.IsClustered(b.HasKey("VehicleId"));

                    b.HasAlternateKey("VehicleGuid");

                    SqlServerKeyBuilderExtensions.IsClustered(b.HasAlternateKey("VehicleGuid"), false);

                    b.HasIndex("NormalizedChassisNo");

                    SqlServerIndexBuilderExtensions.IsClustered(b.HasIndex("NormalizedChassisNo"), false);

                    b.HasIndex("NormalizedEngineNo");

                    SqlServerIndexBuilderExtensions.IsClustered(b.HasIndex("NormalizedEngineNo"), false);

                    b.HasIndex("NormalizedPlateNo");

                    SqlServerIndexBuilderExtensions.IsClustered(b.HasIndex("NormalizedPlateNo"), false);

                    b.ToTable("tblvehicles", (string)null);
                });

            modelBuilder.Entity("Steward.WheelBox.Application.Modules.Vehicles.Entities.GasLog", b =>
                {
                    b.HasOne("Steward.WheelBox.Application.Modules.DataReferences.Entities.Unit", "GasAmountUnit")
                        .WithMany("GasAmountList")
                        .HasForeignKey("GasAmountUnitId")
                        .IsRequired();

                    b.HasOne("Steward.WheelBox.Application.Modules.DataReferences.Entities.Unit", "GasVolumeUnit")
                        .WithMany("GasVolumeList")
                        .HasForeignKey("GasVolumeUnitId")
                        .IsRequired();

                    b.HasOne("Steward.WheelBox.Application.Modules.Vehicles.Entities.Vehicle", "Vehicle")
                        .WithMany("GasLog")
                        .HasForeignKey("VehicleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("GasAmountUnit");

                    b.Navigation("GasVolumeUnit");

                    b.Navigation("Vehicle");
                });

            modelBuilder.Entity("Steward.WheelBox.Application.Modules.DataReferences.Entities.Unit", b =>
                {
                    b.Navigation("GasAmountList");

                    b.Navigation("GasVolumeList");
                });

            modelBuilder.Entity("Steward.WheelBox.Application.Modules.Vehicles.Entities.Vehicle", b =>
                {
                    b.Navigation("GasLog");
                });
#pragma warning restore 612, 618
        }
    }
}
