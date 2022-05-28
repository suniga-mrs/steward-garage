﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Steward.WheelBox.Infrastructure.Persistence;

#nullable disable

namespace Steward.WheelBox.Infrastructure.Migrations.SqlServer
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20220528140822_Initial")]
    partial class Initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Steward.WheelBox.Application.Modules.Vehicles.Entities.Vehicle", b =>
                {
                    b.Property<int>("VehicleId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("VehicleId"), 1L, 1);

                    b.Property<string>("ChassisNo")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)")
                        .HasDefaultValue("");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DateDeleted")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DateLastModified")
                        .HasColumnType("datetime2");

                    b.Property<string>("EngineNo")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)")
                        .HasDefaultValue("");

                    b.Property<bool>("IsDeleted")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(false);

                    b.Property<string>("LastModifiedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Make")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasDefaultValue("");

                    b.Property<string>("Model")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasDefaultValue("");

                    b.Property<string>("NormalizedChassisNo")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)")
                        .HasDefaultValue("");

                    b.Property<string>("NormalizedEngineNo")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)")
                        .HasDefaultValue("");

                    b.Property<string>("NormalizedPlateNo")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)")
                        .HasDefaultValue("");

                    b.Property<string>("PlateNo")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)")
                        .HasDefaultValue("");

                    b.Property<Guid>("VehicleGuid")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasDefaultValueSql("NEWID()");

                    b.Property<short>("Year")
                        .HasColumnType("smallint");

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

                    b.ToTable("Vehicles");
                });
#pragma warning restore 612, 618
        }
    }
}
