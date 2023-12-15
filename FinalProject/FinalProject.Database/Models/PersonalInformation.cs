using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject.BusinessLogic.Models
{
    public class PersonalInformation
    {
        [Key]
        [Required]
        public Guid Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public long PersonalCode { get; set; }

        public long TelNumber { get; set; }

        public string Email { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime? UpdatedAt { get; set; }

        public IList<Image> Images { get; set; }

        
        public User User { get; set; }
        public Guid UserId { get; set; }

        [ForeignKey("AddressId")]
        public Address? Address { get; set; }
        public Guid? AddressId { get; set; }
    }
}
