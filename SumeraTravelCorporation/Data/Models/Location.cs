using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SumeraTravelCorporation.Data.Models
{
    [Table("Location", Schema = "Master")]
    public class Location
    {
        public int LocationId { get; set; }

        [Unicode(false)]
        [StringLength(50)]
        public string? LocationName { get; set; }

    }
}
