using SumeraTravelCorporation.Data.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace SumeraTravelCorporation.Data
{
    [Table("FlightCustomerDetail", Schema = "Transaction")]

    public class FlightCustomerDetail
    {
        public int Id { get; set; }
     
        public int? FlightBookingRefId { get; set; }
        [ForeignKey(nameof(FlightBookingRefId))]
        public FlightBooking? FlightBookingRef { get; set; }

        public int? CustomerRefId { get; set; }
        [ForeignKey(nameof(CustomerRefId))]
        public Customer? CustomerRef { get; set; }

    }
}
