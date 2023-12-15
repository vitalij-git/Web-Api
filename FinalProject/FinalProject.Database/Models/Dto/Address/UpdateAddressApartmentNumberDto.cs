using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject.BusinessLogic.Models.Dto.Address
{
    public class UpdateAddressApartmentNumberDto
    {
        public Guid PersonalInformationId { get; set; }

        public int ApartmentNumber { get; set; }
    }
}
 