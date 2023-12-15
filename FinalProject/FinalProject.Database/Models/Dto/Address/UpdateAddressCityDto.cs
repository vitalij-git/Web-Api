using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject.BusinessLogic.Models.Dto.Address
{
    public class UpdateAddressCityDto
    {
        public Guid PersonalInformationId { get; set; }

        public string City { get; set; }
    }
}
