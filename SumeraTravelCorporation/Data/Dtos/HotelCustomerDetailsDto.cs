using SumeraTravelCorporation.Data.Models;

namespace SumeraTravelCorporation.Data.Dtos
{
    public class HotelCustomerDetailsDto
    {
        public int Id { get; set; }
        public int? HotelBookingRefId { get; set; }
        public HotelBooking? HotelBookingRef { get; set; }
        public int? CustomerRefId { get; set; }
        public Customer? CustomerRef { get; set; }
    }
}
