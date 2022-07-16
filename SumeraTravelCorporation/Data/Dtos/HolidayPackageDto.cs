using SumeraTravelCorporation.RepositoryPattern.RepositoryBase;

namespace SumeraTravelCorporation.Data.Dtos
{
    public class HolidayPackageDto : ViewDtoBase
    {
        public int HolidayPackageId { get; set; }
        public int? FromLocationRefId { get; set; }
        public int? ToLocationRefId { get; set; }
        public string? Image { get; set; }
        public int HolidayPackagePrice { get; set; }
        public int Duration { get; set; }
        public int NumberOfGuest { get; set; }
        public int? HotelRefId { get; set; }
        public string? Description { get; set; }
        public DateTime Date { get; set; }
        public string? PackageTitle { get; set; }

    }
}
