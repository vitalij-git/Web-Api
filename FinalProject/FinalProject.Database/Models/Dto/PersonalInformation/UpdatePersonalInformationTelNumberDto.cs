using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject.Database.Models.Dto.PersonalInformation
{
    public class UpdatePersonalInformationTelNumberDto
    {
        public Guid UserId { get; set; }

        public long TelNumber { get; set;}
    }
}
