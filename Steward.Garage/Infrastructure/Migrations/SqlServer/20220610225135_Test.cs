using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Steward.Garage.Infrastructure.Migrations.SqlServer
{
    public partial class Test : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "tblbusinessprovider",
                columns: table => new
                {
                    providerid = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    providername = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false, defaultValue: ""),
                    NormalizedProviderName = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false, defaultValue: ""),
                    datecreated = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified)),
                    createdby = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false, defaultValue: ""),
                    datelastmodified = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified)),
                    lastmodifiedby = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false, defaultValue: ""),
                    datedeleted = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified)),
                    deletedby = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false, defaultValue: ""),
                    isdeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblbusinessprovider", x => x.providerid)
                        .Annotation("SqlServer:Clustered", true);
                });

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
                    birthdate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    licenseexpiry = table.Column<DateTime>(type: "datetime2", nullable: true),
                    datecreated = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified)),
                    createdby = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false, defaultValue: ""),
                    datelastmodified = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified)),
                    lastmodifiedby = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false, defaultValue: ""),
                    datedeleted = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified)),
                    deletedby = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false, defaultValue: ""),
                    isdeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false)
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
                    datecreated = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified)),
                    createdby = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false, defaultValue: ""),
                    datelastmodified = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified)),
                    lastmodifiedby = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false, defaultValue: ""),
                    datedeleted = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified)),
                    deletedby = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false, defaultValue: ""),
                    isdeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false)
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
                    year = table.Column<short>(type: "smallint", nullable: false, defaultValue: (short)0),
                    plateno = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false, defaultValue: ""),
                    normalizedplateno = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false, defaultValue: ""),
                    chassisno = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false, defaultValue: ""),
                    normalizedchassisno = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false, defaultValue: ""),
                    engineno = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false, defaultValue: ""),
                    normalizedengineno = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false, defaultValue: ""),
                    datecreated = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified)),
                    createdby = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false, defaultValue: ""),
                    datelastmodified = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified)),
                    lastmodifiedby = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false, defaultValue: ""),
                    datedeleted = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified)),
                    deletedby = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false, defaultValue: ""),
                    isdeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblvehicles", x => x.vehicleid)
                        .Annotation("SqlServer:Clustered", true);
                    table.UniqueConstraint("AK_tblvehicles_vehicleguid", x => x.vehicleguid)
                        .Annotation("SqlServer:Clustered", false);
                });

            migrationBuilder.CreateTable(
                name: "tblgaslogs",
                columns: table => new
                {
                    gaslogid = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    gasamount = table.Column<decimal>(type: "decimal(18,2)", nullable: false, defaultValue: 0.0m),
                    gasvolume = table.Column<decimal>(type: "decimal(18,2)", nullable: false, defaultValue: 0.0m),
                    vehicleid = table.Column<int>(type: "int", nullable: false),
                    gasamountunitid = table.Column<int>(type: "int", nullable: false),
                    gasvolumeunitid = table.Column<int>(type: "int", nullable: false),
                    odometerlogid = table.Column<int>(type: "int", nullable: false),
                    remarks = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false, defaultValue: ""),
                    logdate = table.Column<DateTime>(type: "datetime2", nullable: true, defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified)),
                    datecreated = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified)),
                    createdby = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false, defaultValue: ""),
                    datelastmodified = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified)),
                    lastmodifiedby = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false, defaultValue: ""),
                    datedeleted = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified)),
                    deletedby = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false, defaultValue: ""),
                    isdeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblgaslogs", x => x.gaslogid)
                        .Annotation("SqlServer:Clustered", true);
                    table.ForeignKey(
                        name: "FK_tblgaslogs_tblunits_gasamountunitid",
                        column: x => x.gasamountunitid,
                        principalTable: "tblunits",
                        principalColumn: "unitid");
                    table.ForeignKey(
                        name: "FK_tblgaslogs_tblunits_gasvolumeunitid",
                        column: x => x.gasvolumeunitid,
                        principalTable: "tblunits",
                        principalColumn: "unitid");
                    table.ForeignKey(
                        name: "FK_tblgaslogs_tblvehicles_vehicleid",
                        column: x => x.vehicleid,
                        principalTable: "tblvehicles",
                        principalColumn: "vehicleid",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tblmaintenancelogs",
                columns: table => new
                {
                    maintenancelogid = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    totalamount = table.Column<decimal>(type: "decimal(18,2)", nullable: false, defaultValue: 0m),
                    totalamountunitid = table.Column<int>(type: "int", nullable: false, defaultValue: 0),
                    remarks = table.Column<string>(type: "nvarchar(max)", nullable: false, defaultValue: ""),
                    servicebyid = table.Column<int>(type: "int", nullable: false, defaultValue: 0),
                    vehicleid = table.Column<int>(type: "int", nullable: false, defaultValue: 0),
                    odometerlogid = table.Column<int>(type: "int", nullable: false, defaultValue: 0),
                    logdate = table.Column<DateTime>(type: "datetime2", nullable: true, defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified)),
                    datecreated = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified)),
                    createdby = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false, defaultValue: ""),
                    datelastmodified = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified)),
                    lastmodifiedby = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false, defaultValue: ""),
                    datedeleted = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified)),
                    deletedby = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false, defaultValue: ""),
                    isdeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblmaintenancelogs", x => x.maintenancelogid)
                        .Annotation("SqlServer:Clustered", true);
                    table.ForeignKey(
                        name: "FK_tblmaintenancelogs_tblbusinessprovider_vehicleid",
                        column: x => x.vehicleid,
                        principalTable: "tblbusinessprovider",
                        principalColumn: "providerid",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_tblmaintenancelogs_tblvehicles_vehicleid",
                        column: x => x.vehicleid,
                        principalTable: "tblvehicles",
                        principalColumn: "vehicleid",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tblodometerlogs",
                columns: table => new
                {
                    odometerlogid = table.Column<int>(type: "int", nullable: false),
                    dateread = table.Column<DateTime>(type: "datetime2", nullable: true, defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified)),
                    reading = table.Column<decimal>(type: "decimal(18,2)", nullable: false, defaultValue: 0m),
                    vehicleid = table.Column<int>(type: "int", nullable: false),
                    readingunitid = table.Column<int>(type: "int", nullable: false),
                    datecreated = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified)),
                    createdby = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false, defaultValue: ""),
                    datelastmodified = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified)),
                    lastmodifiedby = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false, defaultValue: ""),
                    datedeleted = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified)),
                    deletedby = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false, defaultValue: ""),
                    isdeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblodometerlogs", x => x.odometerlogid)
                        .Annotation("SqlServer:Clustered", true);
                    table.ForeignKey(
                        name: "FK_tblodometerlogs_tblgaslogs_odometerlogid",
                        column: x => x.odometerlogid,
                        principalTable: "tblgaslogs",
                        principalColumn: "gaslogid",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_tblodometerlogs_tblmaintenancelogs_odometerlogid",
                        column: x => x.odometerlogid,
                        principalTable: "tblmaintenancelogs",
                        principalColumn: "maintenancelogid",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_tblodometerlogs_tblunits_readingunitid",
                        column: x => x.readingunitid,
                        principalTable: "tblunits",
                        principalColumn: "unitid");
                    table.ForeignKey(
                        name: "FK_tblodometerlogs_tblvehicles_vehicleid",
                        column: x => x.vehicleid,
                        principalTable: "tblvehicles",
                        principalColumn: "vehicleid",
                        onDelete: ReferentialAction.Cascade);
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
                name: "IX_tblgaslogs_gasamountunitid",
                table: "tblgaslogs",
                column: "gasamountunitid");

            migrationBuilder.CreateIndex(
                name: "IX_tblgaslogs_gasvolumeunitid",
                table: "tblgaslogs",
                column: "gasvolumeunitid");

            migrationBuilder.CreateIndex(
                name: "IX_tblgaslogs_vehicleid",
                table: "tblgaslogs",
                column: "vehicleid")
                .Annotation("SqlServer:Clustered", false);

            migrationBuilder.CreateIndex(
                name: "IX_tblmaintenancelogs_vehicleid",
                table: "tblmaintenancelogs",
                column: "vehicleid");

            migrationBuilder.CreateIndex(
                name: "IX_tblodometerlogs_readingunitid",
                table: "tblodometerlogs",
                column: "readingunitid");

            migrationBuilder.CreateIndex(
                name: "IX_tblodometerlogs_vehicleid",
                table: "tblodometerlogs",
                column: "vehicleid");

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
                name: "tblodometerlogs");

            migrationBuilder.DropTable(
                name: "tblgaslogs");

            migrationBuilder.DropTable(
                name: "tblmaintenancelogs");

            migrationBuilder.DropTable(
                name: "tblunits");

            migrationBuilder.DropTable(
                name: "tblbusinessprovider");

            migrationBuilder.DropTable(
                name: "tblvehicles");
        }
    }
}
