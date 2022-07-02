using SumeraTravelCorporation.Data.Models;

namespace SumeraTravelCorporation.Data.Dtos
{
    public class HotelDto
    {
        public int HotelId { get; set; }
        public string? Name { get; set; }
        public int Star { get; set; }
        public City? CityRef { get; set; }

    }
}
