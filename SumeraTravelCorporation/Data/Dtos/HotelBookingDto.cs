using SumeraTravelCorporation.Data.Models;

namespace SumeraTravelCorporation.Data.Dtos
{
    public class HotelBookingDto
    {
        public int Id { get; set; }
        public int? HotelRefId { get; set; }
        public Hotel? HotelRef { get; set; }
        public int ConfirmationCode { get; set; }
        public DateTime FromDate { get; set; }
        public DateTime ToDate { get; set; }
        public List<HotelCustomerDetail> HotelCustomerDetails { get; set; }
    }
}
