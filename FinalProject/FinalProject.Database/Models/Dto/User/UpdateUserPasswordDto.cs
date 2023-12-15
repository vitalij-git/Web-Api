using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject.BusinessLogic.Models.Dto.User
{
    public class UpdateUserPasswordDto
    {
        public string OldPassword { get; set; }

        public string NewPassword { get; set; }

        public Guid UserId { get; set; }
    }
}
