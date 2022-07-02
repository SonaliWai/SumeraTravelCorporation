using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace SumeraTravelCorporation.Data.Models
{
    [Table("Airline",Schema ="Master")]
    public class Airline
    {
        public int Id { get; set; }

        [Unicode(false)]
        public string? Name { get; set; }

        [Unicode(false)]
        public string? ShortName { get; set; }

        [Unicode(false)]
        public string? Logo { get; set; }

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
