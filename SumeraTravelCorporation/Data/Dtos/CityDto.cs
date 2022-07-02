using SumeraTravelCorporation.Data.Models;

namespace SumeraTravelCorporation.Data.Dtos
{
    public class CityDto
    {
        public int Id { get; set; }

        public string? Name { get; set; }
        public int? CountryRefId { get; set; }


    }
}
