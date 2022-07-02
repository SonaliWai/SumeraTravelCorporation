using SumeraTravelCorporation.Data.Models;

namespace SumeraTravelCorporation.Data.Dtos
{
    public class FlightBookingDto
    {
        public int Id { get; set; }       
        public string? PassengerNameRecord { get; set; }
        public int BookingTimeStamp { get; set; }
        public int? CustomerRefId { get; set; }     
        public Customer? CustomerRef { get; set; }
        public int? FlightScheduleRefId { get; set; }     
        public FlightSchedule? FlightScheduleRef { get; set; }
        public int CustomerContactMobile { get; set; }
        public string? CustomerContactEmail { get; set; }
        public List<FlightCustomerDetail> FlightCustomerDetails { get; set; }
    }
}
