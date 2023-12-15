using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject.Database.Models.Dto.PersonalInformation
{
    public class UpdatePersonalInformationLastNameDto
    {
        public Guid UserId { get; set; }

        public string LastName { get; set; }
    }
}
