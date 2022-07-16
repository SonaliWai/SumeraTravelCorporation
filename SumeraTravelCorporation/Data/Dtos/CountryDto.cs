using SumeraTravelCorporation.RepositoryPattern.RepositoryBase;

namespace SumeraTravelCorporation.Data.Dtos
{
    public class CountryDto 
    {
        public int Id { get; set; }
     
        public string? Name { get; set; }
      
        public string? CountryCode { get; set; }
    }
}
