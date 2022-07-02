using SumeraTravelCorporation.Data.Models;

namespace SumeraTravelCorporation.Data.Dtos
{
    public class FlightDto
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public int Code { get; set; }
        public int? AirlineRefId { get; set; }
        public int? FromAirportRefId { get; set; }
        public int? ToAirportRefId { get; set; }
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
