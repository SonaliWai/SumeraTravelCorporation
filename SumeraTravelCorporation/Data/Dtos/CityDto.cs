using SumeraTravelCorporation.Data.Models;
using SumeraTravelCorporation.RepositoryPattern.RepositoryBase;

namespace SumeraTravelCorporation.Data.Dtos
{
    public class CityDto : ViewDtoBase
    {
        //public int Id { get; set; }

        public string? Name { get; set; }
        public int? CountryRefId { get; set; }


    }
}
