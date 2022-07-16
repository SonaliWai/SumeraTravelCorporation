using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SumeraTravelCorporation.Migrations
{
    public partial class @new : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "Master");

            migrationBuilder.EnsureSchema(
                name: "Transaction");

            migrationBuilder.CreateTable(
                name: "Amenities",
                schema: "Master",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "varchar(max)", unicode: false, nullable: true),
                    Description = table.Column<string>(type: "varchar(max)", unicode: false, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Amenities", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Country",
                schema: "Master",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "varchar(max)", unicode: false, nullable: true),
                    CountryCode = table.Column<string>(type: "varchar(max)", unicode: false, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Country", x => x.Id);
                });

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
                name: "City",
                schema: "Master",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "varchar(max)", unicode: false, nullable: true),
                    CountryRefId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_City", x => x.Id);
                    table.ForeignKey(
                        name: "FK_City_Country_CountryRefId",
                        column: x => x.CountryRefId,
                        principalSchema: "Master",
                        principalTable: "Country",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Airline",
                schema: "Master",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "varchar(max)", unicode: false, nullable: true),
                    ShortName = table.Column<string>(type: "varchar(max)", unicode: false, nullable: true),
                    Logo = table.Column<string>(type: "varchar(max)", unicode: false, nullable: true),
                    Address1 = table.Column<string>(type: "varchar(max)", unicode: false, nullable: true),
                    Address2 = table.Column<string>(type: "varchar(max)", unicode: false, nullable: true),
                    Address3 = table.Column<string>(type: "varchar(max)", unicode: false, nullable: true),
                    CityRefId = table.Column<int>(type: "int", nullable: true),
                    PinCode = table.Column<int>(type: "int", nullable: false),
                    Telephone1 = table.Column<int>(type: "int", nullable: false),
                    Telephone2 = table.Column<int>(type: "int", nullable: false),
                    Email1 = table.Column<string>(type: "varchar(max)", unicode: false, nullable: true),
                    Email2 = table.Column<string>(type: "varchar(max)", unicode: false, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Airline", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Airline_City_CityRefId",
                        column: x => x.CityRefId,
                        principalSchema: "Master",
                        principalTable: "City",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Airport",
                schema: "Master",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Code = table.Column<string>(type: "varchar(max)", unicode: false, nullable: true),
                    CityRefId = table.Column<int>(type: "int", nullable: true),
                    Address1 = table.Column<string>(type: "varchar(max)", unicode: false, nullable: true),
                    Address2 = table.Column<string>(type: "varchar(max)", unicode: false, nullable: true),
                    Address3 = table.Column<string>(type: "varchar(max)", unicode: false, nullable: true),
                    PinCode = table.Column<int>(type: "int", nullable: false),
                    Telephone1 = table.Column<string>(type: "varchar(max)", unicode: false, nullable: true),
                    Telephone2 = table.Column<string>(type: "varchar(max)", unicode: false, nullable: true),
                    Email1 = table.Column<string>(type: "varchar(max)", unicode: false, nullable: true),
                    Email2 = table.Column<string>(type: "varchar(max)", unicode: false, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Airport", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Airport_City_CityRefId",
                        column: x => x.CityRefId,
                        principalSchema: "Master",
                        principalTable: "City",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Customer",
                schema: "Master",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "varchar(max)", unicode: false, nullable: true),
                    LastName = table.Column<string>(type: "varchar(max)", unicode: false, nullable: true),
                    DateOfBirth = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Address1 = table.Column<string>(type: "varchar(max)", unicode: false, nullable: true),
                    Address2 = table.Column<string>(type: "varchar(max)", unicode: false, nullable: true),
                    Address3 = table.Column<string>(type: "varchar(max)", unicode: false, nullable: true),
                    CityRefId = table.Column<int>(type: "int", nullable: true),
                    PinCode = table.Column<int>(type: "int", nullable: false),
                    Telephone1 = table.Column<int>(type: "int", nullable: false),
                    Email1 = table.Column<string>(type: "varchar(max)", unicode: false, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customer", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Customer_City_CityRefId",
                        column: x => x.CityRefId,
                        principalSchema: "Master",
                        principalTable: "City",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Hotel",
                schema: "Master",
                columns: table => new
                {
                    HotelId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "varchar(max)", unicode: false, nullable: true),
                    Star = table.Column<int>(type: "int", nullable: false),
                    CityRefId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Hotel", x => x.HotelId);
                    table.ForeignKey(
                        name: "FK_Hotel_City_CityRefId",
                        column: x => x.CityRefId,
                        principalSchema: "Master",
                        principalTable: "City",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Flight",
                schema: "Master",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "varchar(max)", unicode: false, nullable: true),
                    Code = table.Column<int>(type: "int", nullable: false),
                    AirlineRefId = table.Column<int>(type: "int", nullable: true),
                    FromAirportRefId = table.Column<int>(type: "int", nullable: true),
                    ToAirportRefId = table.Column<int>(type: "int", nullable: true),
                    Address1 = table.Column<string>(type: "varchar(max)", unicode: false, nullable: true),
                    Address2 = table.Column<string>(type: "varchar(max)", unicode: false, nullable: true),
                    Address3 = table.Column<string>(type: "varchar(max)", unicode: false, nullable: true),
                    CityRefId = table.Column<int>(type: "int", nullable: true),
                    PinCode = table.Column<int>(type: "int", nullable: false),
                    Telephone1 = table.Column<int>(type: "int", nullable: false),
                    Telephone2 = table.Column<int>(type: "int", nullable: false),
                    Email1 = table.Column<string>(type: "varchar(max)", unicode: false, nullable: true),
                    Email2 = table.Column<string>(type: "varchar(max)", unicode: false, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Flight", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Flight_Airline_AirlineRefId",
                        column: x => x.AirlineRefId,
                        principalSchema: "Master",
                        principalTable: "Airline",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Flight_Airport_FromAirportRefId",
                        column: x => x.FromAirportRefId,
                        principalSchema: "Master",
                        principalTable: "Airport",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Flight_Airport_ToAirportRefId",
                        column: x => x.ToAirportRefId,
                        principalSchema: "Master",
                        principalTable: "Airport",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Flight_City_CityRefId",
                        column: x => x.CityRefId,
                        principalSchema: "Master",
                        principalTable: "City",
                        principalColumn: "Id");
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
                name: "HotelAmenitiesLink",
                schema: "Master",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    HotelRefId = table.Column<int>(type: "int", nullable: true),
                    AmenitiesRefId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HotelAmenitiesLink", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HotelAmenitiesLink_Amenities_AmenitiesRefId",
                        column: x => x.AmenitiesRefId,
                        principalSchema: "Master",
                        principalTable: "Amenities",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_HotelAmenitiesLink_Hotel_HotelRefId",
                        column: x => x.HotelRefId,
                        principalSchema: "Master",
                        principalTable: "Hotel",
                        principalColumn: "HotelId");
                });

            migrationBuilder.CreateTable(
                name: "HotelBooking",
                schema: "Transaction",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    HotelRefId = table.Column<int>(type: "int", nullable: true),
                    ConfirmationCode = table.Column<int>(type: "int", nullable: false),
                    FromDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ToDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HotelBooking", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HotelBooking_Hotel_HotelRefId",
                        column: x => x.HotelRefId,
                        principalSchema: "Master",
                        principalTable: "Hotel",
                        principalColumn: "HotelId");
                });

            migrationBuilder.CreateTable(
                name: "FlightSchedule",
                schema: "Transaction",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FlightRefId = table.Column<int>(type: "int", nullable: true),
                    DepartureDate = table.Column<int>(type: "int", nullable: false),
                    ArrivalDate = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FlightSchedule", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FlightSchedule_Flight_FlightRefId",
                        column: x => x.FlightRefId,
                        principalSchema: "Master",
                        principalTable: "Flight",
                        principalColumn: "Id");
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

            migrationBuilder.CreateTable(
                name: "HotelCustomerDetail",
                schema: "Transaction",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    HotelBookingRefId = table.Column<int>(type: "int", nullable: true),
                    CustomerRefId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HotelCustomerDetail", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HotelCustomerDetail_Customer_CustomerRefId",
                        column: x => x.CustomerRefId,
                        principalSchema: "Master",
                        principalTable: "Customer",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_HotelCustomerDetail_HotelBooking_HotelBookingRefId",
                        column: x => x.HotelBookingRefId,
                        principalSchema: "Transaction",
                        principalTable: "HotelBooking",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "FlightBooking",
                schema: "Transaction",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PassengerNameRecord = table.Column<string>(type: "varchar(max)", unicode: false, nullable: true),
                    BookingTimeStamp = table.Column<int>(type: "int", nullable: false),
                    CustomerRefId = table.Column<int>(type: "int", nullable: true),
                    FlightScheduleRefId = table.Column<int>(type: "int", nullable: true),
                    CustomerContactMobile = table.Column<int>(type: "int", nullable: false),
                    CustomerContactEmail = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FlightBooking", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FlightBooking_Customer_CustomerRefId",
                        column: x => x.CustomerRefId,
                        principalSchema: "Master",
                        principalTable: "Customer",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_FlightBooking_FlightSchedule_FlightScheduleRefId",
                        column: x => x.FlightScheduleRefId,
                        principalSchema: "Transaction",
                        principalTable: "FlightSchedule",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "FlightCustomerDetail",
                schema: "Transaction",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FlightBookingRefId = table.Column<int>(type: "int", nullable: true),
                    CustomerRefId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FlightCustomerDetail", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FlightCustomerDetail_Customer_CustomerRefId",
                        column: x => x.CustomerRefId,
                        principalSchema: "Master",
                        principalTable: "Customer",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_FlightCustomerDetail_FlightBooking_FlightBookingRefId",
                        column: x => x.FlightBookingRefId,
                        principalSchema: "Transaction",
                        principalTable: "FlightBooking",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Airline_CityRefId",
                schema: "Master",
                table: "Airline",
                column: "CityRefId");

            migrationBuilder.CreateIndex(
                name: "IX_Airport_CityRefId",
                schema: "Master",
                table: "Airport",
                column: "CityRefId");

            migrationBuilder.CreateIndex(
                name: "IX_City_CountryRefId",
                schema: "Master",
                table: "City",
                column: "CountryRefId");

            migrationBuilder.CreateIndex(
                name: "IX_Customer_CityRefId",
                schema: "Master",
                table: "Customer",
                column: "CityRefId");

            migrationBuilder.CreateIndex(
                name: "IX_Flight_AirlineRefId",
                schema: "Master",
                table: "Flight",
                column: "AirlineRefId");

            migrationBuilder.CreateIndex(
                name: "IX_Flight_CityRefId",
                schema: "Master",
                table: "Flight",
                column: "CityRefId");

            migrationBuilder.CreateIndex(
                name: "IX_Flight_FromAirportRefId",
                schema: "Master",
                table: "Flight",
                column: "FromAirportRefId");

            migrationBuilder.CreateIndex(
                name: "IX_Flight_ToAirportRefId",
                schema: "Master",
                table: "Flight",
                column: "ToAirportRefId");

            migrationBuilder.CreateIndex(
                name: "IX_FlightBooking_CustomerRefId",
                schema: "Transaction",
                table: "FlightBooking",
                column: "CustomerRefId");

            migrationBuilder.CreateIndex(
                name: "IX_FlightBooking_FlightScheduleRefId",
                schema: "Transaction",
                table: "FlightBooking",
                column: "FlightScheduleRefId");

            migrationBuilder.CreateIndex(
                name: "IX_FlightCustomerDetail_CustomerRefId",
                schema: "Transaction",
                table: "FlightCustomerDetail",
                column: "CustomerRefId");

            migrationBuilder.CreateIndex(
                name: "IX_FlightCustomerDetail_FlightBookingRefId",
                schema: "Transaction",
                table: "FlightCustomerDetail",
                column: "FlightBookingRefId");

            migrationBuilder.CreateIndex(
                name: "IX_FlightSchedule_FlightRefId",
                schema: "Transaction",
                table: "FlightSchedule",
                column: "FlightRefId");

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

            migrationBuilder.CreateIndex(
                name: "IX_Hotel_CityRefId",
                schema: "Master",
                table: "Hotel",
                column: "CityRefId");

            migrationBuilder.CreateIndex(
                name: "IX_HotelAmenitiesLink_AmenitiesRefId",
                schema: "Master",
                table: "HotelAmenitiesLink",
                column: "AmenitiesRefId");

            migrationBuilder.CreateIndex(
                name: "IX_HotelAmenitiesLink_HotelRefId",
                schema: "Master",
                table: "HotelAmenitiesLink",
                column: "HotelRefId");

            migrationBuilder.CreateIndex(
                name: "IX_HotelBooking_HotelRefId",
                schema: "Transaction",
                table: "HotelBooking",
                column: "HotelRefId");

            migrationBuilder.CreateIndex(
                name: "IX_HotelCustomerDetail_CustomerRefId",
                schema: "Transaction",
                table: "HotelCustomerDetail",
                column: "CustomerRefId");

            migrationBuilder.CreateIndex(
                name: "IX_HotelCustomerDetail_HotelBookingRefId",
                schema: "Transaction",
                table: "HotelCustomerDetail",
                column: "HotelBookingRefId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FlightCustomerDetail",
                schema: "Transaction");

            migrationBuilder.DropTable(
                name: "HolidayBookings");

            migrationBuilder.DropTable(
                name: "HotelAmenitiesLink",
                schema: "Master");

            migrationBuilder.DropTable(
                name: "HotelCustomerDetail",
                schema: "Transaction");

            migrationBuilder.DropTable(
                name: "FlightBooking",
                schema: "Transaction");

            migrationBuilder.DropTable(
                name: "HolidayPackage",
                schema: "Master");

            migrationBuilder.DropTable(
                name: "Amenities",
                schema: "Master");

            migrationBuilder.DropTable(
                name: "HotelBooking",
                schema: "Transaction");

            migrationBuilder.DropTable(
                name: "Customer",
                schema: "Master");

            migrationBuilder.DropTable(
                name: "FlightSchedule",
                schema: "Transaction");

            migrationBuilder.DropTable(
                name: "Location",
                schema: "Master");

            migrationBuilder.DropTable(
                name: "Hotel",
                schema: "Master");

            migrationBuilder.DropTable(
                name: "Flight",
                schema: "Master");

            migrationBuilder.DropTable(
                name: "Airline",
                schema: "Master");

            migrationBuilder.DropTable(
                name: "Airport",
                schema: "Master");

            migrationBuilder.DropTable(
                name: "City",
                schema: "Master");

            migrationBuilder.DropTable(
                name: "Country",
                schema: "Master");
        }
    }
}
