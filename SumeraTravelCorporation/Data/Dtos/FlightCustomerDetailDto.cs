using SumeraTravelCorporation.Data.Models;

namespace SumeraTravelCorporation.Data.Dtos
{
    public class FlightCustomerDetailDto
    {
        public int Id { get; set; }

        public int? FlightBookingRefId { get; set; }
       
        public FlightBooking? FlightBookingRef { get; set; }

        public int? CustomerRefId { get; set; }
      
        public Customer? CustomerRef { get; set; }
    }
}
