using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SumeraTravelCorporation.Migrations
{
    public partial class booking : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Location",
                schema: "Master",
                columns: table => new
                {
                    LocationId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LocationName = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Location", x => x.LocationId);
                });

            migrationBuilder.CreateTable(
                name: "HolidayPackage",
                schema: "Master",
                columns: table => new
                {
                    HolidayPackageId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FromLocationRefId = table.Column<int>(type: "int", nullable: true),
                    ToLocationRefId = table.Column<int>(type: "int", nullable: true),
                    Image = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HolidayPackagePrice = table.Column<int>(type: "int", unicode: false, nullable: false),
                    Duration = table.Column<int>(type: "int", nullable: false),
                    HotelRefId = table.Column<int>(type: "int", nullable: true),
                    NumberOfGuest = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PackageTitle = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HolidayPackage", x => x.HolidayPackageId);
                    table.ForeignKey(
                        name: "FK_HolidayPackage_Hotel_HotelRefId",
                        column: x => x.HotelRefId,
                        principalSchema: "Master",
                        principalTable: "Hotel",
                        principalColumn: "HotelId");
                    table.ForeignKey(
                        name: "FK_HolidayPackage_Location_FromLocationRefId",
                        column: x => x.FromLocationRefId,
                        principalSchema: "Master",
                        principalTable: "Location",
                        principalColumn: "LocationId");
                    table.ForeignKey(
                        name: "FK_HolidayPackage_Location_ToLocationRefId",
                        column: x => x.ToLocationRefId,
                        principalSchema: "Master",
                        principalTable: "Location",
                        principalColumn: "LocationId");
                });

            migrationBuilder.CreateTable(
                name: "HolidayBookings",
                columns: table => new
                {
                    HolidayBookingId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    HolidayPackageRefId = table.Column<int>(type: "int", nullable: true),
                    CustomerRefId = table.Column<int>(type: "int", nullable: true),
                    BookingDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HolidayBookings", x => x.HolidayBookingId);
                    table.ForeignKey(
                        name: "FK_HolidayBookings_Customer_CustomerRefId",
                        column: x => x.CustomerRefId,
                        principalSchema: "Master",
                        principalTable: "Customer",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_HolidayBookings_HolidayPackage_HolidayPackageRefId",
                        column: x => x.HolidayPackageRefId,
                        principalSchema: "Master",
                        principalTable: "HolidayPackage",
                        principalColumn: "HolidayPackageId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_HolidayBookings_CustomerRefId",
                table: "HolidayBookings",
                column: "CustomerRefId");

            migrationBuilder.CreateIndex(
                name: "IX_HolidayBookings_HolidayPackageRefId",
                table: "HolidayBookings",
                column: "HolidayPackageRefId");

            migrationBuilder.CreateIndex(
                name: "IX_HolidayPackage_FromLocationRefId",
                schema: "Master",
                table: "HolidayPackage",
                column: "FromLocationRefId");

            migrationBuilder.CreateIndex(
                name: "IX_HolidayPackage_HotelRefId",
                schema: "Master",
                table: "HolidayPackage",
                column: "HotelRefId");

            migrationBuilder.CreateIndex(
                name: "IX_HolidayPackage_ToLocationRefId",
                schema: "Master",
                table: "HolidayPackage",
                column: "ToLocationRefId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "HolidayBookings");

            migrationBuilder.DropTable(
                name: "HolidayPackage",
                schema: "Master");

            migrationBuilder.DropTable(
                name: "Location",
                schema: "Master");
        }
    }
}
