using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject.Database.Models.Dto.PersonalInformation
{
    public class AddPersonalInformationDto
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public long PersonalCode { get; set; }

        public long TelNumber { get; set; }

        public string Email { get; set; }

        public Guid UserId { get; set; }

    }
}
