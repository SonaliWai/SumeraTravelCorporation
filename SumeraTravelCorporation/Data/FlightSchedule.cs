using SumeraTravelCorporation.Data.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace SumeraTravelCorporation.Data
{
    [Table("FlightSchedule", Schema = "Transaction")]

    public class FlightSchedule
    {
        public int Id { get; set; }      
        
        public int? FlightRefId { get; set; }
        [ForeignKey(nameof(FlightRefId))]
        public Flight? FlightRef { get; set; }

        public int DepartureDate { get; set; }
        public int ArrivalDate { get; set; }
    }
}
