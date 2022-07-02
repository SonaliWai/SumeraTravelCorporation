using SumeraTravelCorporation.Data.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace SumeraTravelCorporation.Data
{
    [Table("HotelBooking", Schema = "Transaction")]

    public class HotelBooking
    {
        public int Id { get; set; }    
        public int? HotelRefId { get; set; }
        [ForeignKey(nameof(HotelRefId))]
        public Hotel? HotelRef { get; set; }

        public int ConfirmationCode { get; set; }
        public DateTime FromDate { get; set; }
        public DateTime ToDate { get; set; }
        public List<HotelCustomerDetail> HotelCustomerDetails { get; set; }

    }
}
