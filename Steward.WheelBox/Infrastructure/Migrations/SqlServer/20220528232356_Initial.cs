using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Steward.WheelBox.Infrastructure.Migrations.SqlServer
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
                    deletedby = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    isdeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    datecreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    createdby = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    datelastmodified = table.Column<DateTime>(type: "datetime2", nullable: false),
                    lastmodified = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblvehicles", x => x.vehicleid)
                        .Annotation("SqlServer:Clustered", true);
                    table.UniqueConstraint("AK_tblvehicles_vehicleguid", x => x.vehicleguid)
                        .Annotation("SqlServer:Clustered", false);
                });

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
                name: "tblvehicles");
        }
    }
}
