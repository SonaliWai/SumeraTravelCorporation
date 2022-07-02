using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace SumeraTravelCorporation.Data.Models
{
    [Table("Flight", Schema = "Master")]

    public class Flight
    {
        public int Id { get; set; }

        [Unicode(false)]
        public string? Name { get; set; }

        public int Code { get; set; }

        public int? AirlineRefId { get; set; }
        [ForeignKey(nameof(AirlineRefId))]
        public Airline? AirlineRef { get; set; }

        public int? FromAirportRefId { get; set; }
        [ForeignKey(nameof(FromAirportRefId))]
        public Airport? AirportRef{ get; set; }


        public int? ToAirportRefId { get; set; }
        [ForeignKey(nameof(ToAirportRefId))]
        public Airport? AirportRefid{ get; set; }


        [Unicode(false)]
        public string? Address1 { get; set; }

        [Unicode(false)]
        public string? Address2 { get; set; }

        [Unicode(false)]
        public string? Address3 { get; set; }

        public int? CityRefId { get; set; }
        [ForeignKey(nameof(CityRefId))]
        public City? CityRef { get; set; }

        public int PinCode { get; set; }
        public int Telephone1 { get; set; }
        public int Telephone2 { get; set; }

        [Unicode(false)]
        public string? Email1 { get; set; }

        [Unicode(false)]
        public string? Email2 { get; set; }
    }
}
