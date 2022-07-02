using Microsoft.EntityFrameworkCore;
using SumeraTravelCorporation.Data.Models;

namespace SumeraTravelCorporation.Data
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Country> Countries { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<Hotel> Hotels { get; set; }
        public DbSet<Amenities> Amenitiess{ get; set; }
        public DbSet<HotelAmenitiesLink> HotelAmenitiesLinks { get; set; }
        public DbSet<Airport> Airports{ get; set; }
        public DbSet<Airline> Airlines{ get; set; }
        public DbSet<Flight> Flights{ get; set; }
        public DbSet<Customer> Customers{ get; set; }
        public DbSet<FlightBooking> FlightBookings{ get; set; }
        public DbSet<FlightCustomerDetail> FlightCustomerDetails{ get; set; }
        public DbSet<FlightSchedule> FlightSchedules{ get; set; }
        public DbSet<HotelBooking> HotelBookings{ get; set; }
        public DbSet<HotelCustomerDetail> HotelCustomerDetails{ get; set; }



        public ApplicationDbContext()
        {
        }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }
    }
}
