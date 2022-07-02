using SumeraTravelCorporation.Data.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace SumeraTravelCorporation.Data
{
    [Table("HotelCustomerDetail", Schema = "Transaction")]

    public class HotelCustomerDetail
    {
        public int Id { get; set; }

        
        public int? HotelBookingRefId { get; set; }
        [ForeignKey(nameof(HotelBookingRefId))]
        public HotelBooking? HotelBookingRef { get; set; }


        public int? CustomerRefId { get; set; }
        [ForeignKey(nameof(CustomerRefId))]
        public Customer? CustomerRef { get; set; }
    }
}
