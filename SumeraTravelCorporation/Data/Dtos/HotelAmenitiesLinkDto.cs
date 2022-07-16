using SumeraTravelCorporation.Data.Models;

namespace SumeraTravelCorporation.Data.Dtos
{
    public class HotelAmenitiesLinkDto 
    {
        public int Id { get; set; }
        public int? HotelRefId { get; set; }
        public Hotel? HotelRef { get; set; }
        public Amenities? AmenitiesRef { get; set; }
    }
}
