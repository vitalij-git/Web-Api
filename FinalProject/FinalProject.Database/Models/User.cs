using FinalProject.Database.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject.BusinessLogic.Models
{
    [Table("User")]
    public class User
    {
        [Key]
        [Required]
        public Guid Id { get; set; }

        public string Username { get; set; }

        public byte[] Password { get; set; }

        public byte[] PasswordSalt { get; set; }

        public Role Role { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime? UpdatedAt { get; set; }

        [ForeignKey("PersonalInformationId")]
        public PersonalInformation? PersonalInformation { get; set; }

        public Guid  PersonalInformationId { get; set; }


    }
}
