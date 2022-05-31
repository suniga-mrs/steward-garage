﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Steward.WheelBox.Infrastructure.Migrations.SqlServer
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "tbldrivers",
                columns: table => new
                {
                    driverid = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    driverguid = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "NEWID()"),
                    firstname = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false, defaultValue: ""),
                    lastname = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false, defaultValue: ""),
                    middlename = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false, defaultValue: ""),
                    fullname = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false, defaultValue: ""),
                    suffix = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false, defaultValue: ""),
                    licenseno = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false, defaultValue: ""),
                    birthdate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    licenseexpiry = table.Column<DateTime>(type: "datetime2", nullable: false),
                    datedeleted = table.Column<DateTime>(type: "datetime2", nullable: false),
                    deletedby = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    isdeleted = table.Column<bool>(type: "bit", nullable: false),
                    datecreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    createdby = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    datelastmodified = table.Column<DateTime>(type: "datetime2", nullable: false),
                    lastmodifiedby = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbldrivers", x => x.driverid)
                        .Annotation("SqlServer:Clustered", true);
                    table.UniqueConstraint("AK_tbldrivers_driverguid", x => x.driverguid)
                        .Annotation("SqlServer:Clustered", false);
                });

            migrationBuilder.CreateTable(
                name: "tblunits",
                columns: table => new
                {
                    unitid = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false, defaultValue: ""),
                    prefix = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false, defaultValue: ""),
                    suffix = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false, defaultValue: ""),
                    datedeleted = table.Column<DateTime>(type: "datetime2", nullable: false),
                    deletedby = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    isdeleted = table.Column<bool>(type: "bit", nullable: false),
                    datecreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    createdby = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    datelastmodified = table.Column<DateTime>(type: "datetime2", nullable: false),
                    lastmodifiedby = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblunits", x => x.unitid)
                        .Annotation("SqlServer:Clustered", true);
                });

            migrationBuilder.CreateTable(
                name: "tblvehicles",
                columns: table => new
                {
                    vehicleid = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    vehicleguid = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "NEWID()"),
                    make = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false, defaultValue: ""),
                    model = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false, defaultValue: ""),
                    Year = table.Column<short>(type: "smallint", nullable: false),
                    plateno = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false, defaultValue: ""),
                    normalizedplateno = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false, defaultValue: ""),
                    chassisno = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false, defaultValue: ""),
                    normalizedchassisno = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false, defaultValue: ""),
                    engineno = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false, defaultValue: ""),
                    normalizedengineno = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false, defaultValue: ""),
                    datedeleted = table.Column<DateTime>(type: "datetime2", nullable: false),
                    deletedby = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    isdeleted = table.Column<bool>(type: "bit", nullable: false),
                    datecreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    createdby = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    datelastmodified = table.Column<DateTime>(type: "datetime2", nullable: false),
                    lastmodifiedby = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblvehicles", x => x.vehicleid)
                        .Annotation("SqlServer:Clustered", true);
                    table.UniqueConstraint("AK_tblvehicles_vehicleguid", x => x.vehicleguid)
                        .Annotation("SqlServer:Clustered", false);
                });

            migrationBuilder.CreateIndex(
                name: "IX_tbldrivers_fullname",
                table: "tbldrivers",
                column: "fullname")
                .Annotation("SqlServer:Clustered", false);

            migrationBuilder.CreateIndex(
                name: "IX_tbldrivers_licenseno",
                table: "tbldrivers",
                column: "licenseno")
                .Annotation("SqlServer:Clustered", false);

            migrationBuilder.CreateIndex(
                name: "IX_tblunits_name",
                table: "tblunits",
                column: "name")
                .Annotation("SqlServer:Clustered", false);

            migrationBuilder.CreateIndex(
                name: "IX_tblvehicles_normalizedchassisno",
                table: "tblvehicles",
                column: "normalizedchassisno")
                .Annotation("SqlServer:Clustered", false);

            migrationBuilder.CreateIndex(
                name: "IX_tblvehicles_normalizedengineno",
                table: "tblvehicles",
                column: "normalizedengineno")
                .Annotation("SqlServer:Clustered", false);

            migrationBuilder.CreateIndex(
                name: "IX_tblvehicles_normalizedplateno",
                table: "tblvehicles",
                column: "normalizedplateno")
                .Annotation("SqlServer:Clustered", false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tbldrivers");

            migrationBuilder.DropTable(
                name: "tblunits");

            migrationBuilder.DropTable(
                name: "tblvehicles");
        }
    }
}
