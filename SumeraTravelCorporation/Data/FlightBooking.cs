using Microsoft.EntityFrameworkCore;
using SumeraTravelCorporation.Data.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace SumeraTravelCorporation.Data
{
    [Table("FlightBooking", Schema = "Transaction")]
    public class FlightBooking
    {
        public int Id { get; set; }

        [Unicode(false)]
        public string? PassengerNameRecord { get; set; }
        public int BookingTimeStamp { get; set; }

        
        public int? CustomerRefId { get; set; }
        [ForeignKey(nameof(CustomerRefId))]
        public Customer? CustomerRef { get; set; }

        public int? FlightScheduleRefId { get; set; }
        [ForeignKey(nameof(FlightScheduleRefId))]
        public FlightSchedule? FlightScheduleRef { get; set; }

        public int CustomerContactMobile { get; set; }
        public string?  CustomerContactEmail { get; set; }
        public List<FlightCustomerDetail> FlightCustomerDetails { get; set; }

    }
}
