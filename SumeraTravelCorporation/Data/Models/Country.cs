using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SumeraTravelCorporation.Data.Models
{
    [Table("Country", Schema = "Master")]

    public class Country
    {
        [Key]
        public int Id { get; set; }

        [Unicode(false)]
        public string? Name { get; set; }

        [Unicode(false)]
        public string? CountryCode { get; set; }
    }
}
