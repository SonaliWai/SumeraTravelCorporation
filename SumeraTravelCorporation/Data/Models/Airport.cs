using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SumeraTravelCorporation.Data.Models
{
    [Table("Airport", Schema = "Master")]

    public class Airport
    {
        [Key]
        public int Id { get; set; }

        [Unicode(false)]
        public string? Code { get; set; }

        public int? CityRefId { get; set; }
        [ForeignKey(nameof(CityRefId))]
        public City? CityRef { get; set; }

        [Unicode(false)]
        public string? Address1 { get; set; }

        [Unicode(false)]
        public string? Address2 { get; set; }

        [Unicode(false)]
        public string? Address3 { get; set; }

        public int PinCode { get; set; }

        [Unicode(false)]
        public string? Telephone1 { get; set; }

        [Unicode(false)]
        public string? Telephone2 { get; set; }

        [Unicode(false)]
        public string? Email1 { get; set; }

        [Unicode(false)]
        public string? Email2 { get; set; }


    }
}
