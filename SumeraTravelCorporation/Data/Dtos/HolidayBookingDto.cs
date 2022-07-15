namespace SumeraTravelCorporation.Data.Dtos
{
    public class HolidayBookingDto
    {
        public int HolidayBookingId { get; set; }
        public int? HolidayPackageRefId { get; set; }
        public int? CustomerRefId { get; set; }
        public DateTime BookingDate { get; set; }

    }
}
