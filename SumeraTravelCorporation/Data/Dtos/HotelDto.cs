using SumeraTravelCorporation.Data.Models;
using SumeraTravelCorporation.RepositoryPattern.RepositoryBase;

namespace SumeraTravelCorporation.Data.Dtos
{
    public class HotelDto : ViewDtoBase
    {
        public int HotelId { get; set; }
        public string? Name { get; set; }
        public int Star { get; set; }
        public City? CityRef { get; set; }

    }
}
