using SumeraTravelCorporation.Data.Models;

namespace SumeraTravelCorporation.Data.Dtos
{
    public class FlightScheduleDto
    {
        public int Id { get; set; }
        public int? FlightRefId { get; set; }
        public Flight? FlightRef { get; set; }
        public int DepartureDate { get; set; }
        public int ArrivalDate { get; set; }
    }
}
