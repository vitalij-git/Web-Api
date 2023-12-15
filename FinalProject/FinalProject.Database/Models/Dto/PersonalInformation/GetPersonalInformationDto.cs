using FinalProject.BusinessLogic.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject.Database.Models.Dto.PersonalInformation
{
    public class GetPersonalInformationDto
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public long PersonalCode { get; set; }

        public long TelNumber { get; set; }

        public string Email { get; set; }

        public Dictionary<string,byte[]>? Images { get; set; } = new Dictionary<string, byte[]>();

        public string City { get; set; }

        public string Street { get; set; }

        public int BuildingNumber { get; set; }

        public int ApartmentNumber { get; set; }

        public Guid PersonalInformationId { get; set; }
    }
}
