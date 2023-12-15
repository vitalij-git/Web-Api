using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject.BusinessLogic.Models.Dto.User
{
    public class UpdateUserNameDto
    {
        public string OldUserName { get; set;}

        public string NewUserName { get; set;}  

        public Guid UserId { get; set;}
    }
}
