using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject.Database.Models.Dto.PersonalInformation
{
    public class UpdatePersonalInformationPersonalCodeDto
    {
        public Guid UserId { get; set; }

        public long PersonalCode { get; set; }
    }
}
