using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject.BusinessLogic.Models
{
    [Table("Image")]
    public class Image
    {
        [Key]
        [Required]
        public Guid Id { get; set; }

        public string Title { get; set; }

        public byte[] Data { get; set; }

        public DateTime CreatedAt { get; set; }

        [ForeignKey("PersonalInformationId")]
        public PersonalInformation PersonalInformation { get; set; }
        public Guid PersonalInformationId { get; set; }
    }
}
