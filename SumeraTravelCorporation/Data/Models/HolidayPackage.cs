using Microsoft.EntityFrameworkCore;
using SumeraTravelCorporation.RepositoryPattern.RepositoryBase;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SumeraTravelCorporation.Data.Models
{
    [Table("HolidayPackage", Schema = "Master")]
    public class HolidayPackage : DataModelBase
    {
        //public int HolidayPackageId { get; set; }
        public int? FromLocationRefId { get; set; }
        [ForeignKey(nameof(FromLocationRefId))]
        public Location? FromLocationRef { get; set; } 
        public int? ToLocationRefId { get; set; }
        [ForeignKey(nameof(ToLocationRefId))]
        public Location? ToLocationRef { get; set; }

        [Unicode(false)]
        public string? Image { get; set; }
       
        public int HolidayPackagePrice { get; set; }
        public int Duration { get; set; }
        public int? HotelRefId { get; set; }
        [ForeignKey(nameof(HotelRefId))]
        public Hotel? HotelRef { get; set; } 

        public int NumberOfGuest { get; set; }

        [Unicode(false)]
        [StringLength(50)]
        public string? Description { get; set; }
        public DateTime Date { get; set; }

        [Unicode(false)]
        [StringLength(50)]
        public string? PackageTitle { get; set; }

    }
}
