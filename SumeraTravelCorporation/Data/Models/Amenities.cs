using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace SumeraTravelCorporation.Data.Models
{
    [Table("Amenities", Schema = "Master")]

    public class Amenities
    {
        public int Id { get; set; }

        [Unicode(false)]
        public string? Name { get; set; }

        [Unicode(false)]
        public string? Description { get; set; }
    }
}
