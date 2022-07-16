using Microsoft.EntityFrameworkCore;
using SumeraTravelCorporation.RepositoryPattern.RepositoryBase;
using System.ComponentModel.DataAnnotations.Schema;

namespace SumeraTravelCorporation.Data.Models
{
    [Table("Customer", Schema = "Master")]

    public class Customer: DataModelBase
    {
        //public int Id { get; set; }

        [Unicode(false)]
        public string? FirstName { get; set; }

        [Unicode(false)]
        public string? LastName { get; set; }

        public DateTime DateOfBirth { get; set; }

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

        [Unicode(false)]
        public string? Email1 { get; set; }
    }
}
