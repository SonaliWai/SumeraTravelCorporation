using SumeraTravelCorporation.RepositoryPattern.RepositoryBase;
using System.ComponentModel.DataAnnotations.Schema;

namespace SumeraTravelCorporation.Data.Models
{
    public class HolidayBooking: DataModelBase
    {
        //public int HolidayBookingId { get; set; }
        public int? HolidayPackageRefId { get; set; }
        [ForeignKey(nameof(HolidayPackageRefId))]
        public HolidayPackage? HolidayPackageRef { get; set; } 
        public int? CustomerRefId { get; set; }
        [ForeignKey(nameof(CustomerRefId))]
        public Customer? CustomerRef { get; set; } 
        public DateTime BookingDate { get; set; }
    }
}
