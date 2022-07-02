using SumeraTravelCorporation.Data.Models;

namespace SumeraTravelCorporation.Data.Dtos
{
    public class AirlineDto
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? ShortName { get; set; }
        public string? Logo { get; set; }
        public string? Address1 { get; set; }
        public string? Address2 { get; set; }
        public string? Address3 { get; set; }
        public int? CityRefId { get; set; }
        public int PinCode { get; set; }
        public int Telephone1 { get; set; }
        public int Telephone2 { get; set; }
        public string? Email1 { get; set; }
        public string? Email2 { get; set; }

    }
}
