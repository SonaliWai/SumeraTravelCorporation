using SumeraTravelCorporation.RepositoryPattern.RepositoryBase;

namespace SumeraTravelCorporation.Data.Dtos
{
    public class HolidayBookingDto : ViewDtoBase
    {
        //public int HolidayBookingId { get; set; }    
        public int? HolidayPackageRefId { get; set; }
        //public string? HolidayPackageRefName { get; set; }
        public int? CustomerRefId { get; set; }
        public string? CustomerRefName { get; set; }
        public DateTime BookingDate { get; set; }

    }
}
