using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject.BusinessLogic.Models
{
    [Table("Address")]
    public class Address
    {
 
        [Key]
        [Required]
        public Guid Id { get; set; }

        public string City { get; set; }

        public string Street { get; set; }

        public int BuildingNumber { get; set; }

        public int ApartmentNumber { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime? UpdatedAt { get; set; }

        
        public PersonalInformation? PersonalInformation { get; set; }
        public Guid? PersonalInformationId { get; set; }
    }
}
