using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SumeraTravelCorporation.Data.Models
{
    [Table("Hotel", Schema = "Master")]

    public class Hotel
    {
        [Key]
        public int HotelId { get; set; }

        [Unicode(false)]
        public string? Name { get; set; }
      
        public int Star { get; set; }

        public int? CityRefId { get; set; }
        [ForeignKey(nameof(CityRefId))]
        public City? CityRef { get; set; }


    }
}
