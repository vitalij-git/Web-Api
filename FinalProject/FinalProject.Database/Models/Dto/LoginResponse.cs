using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject.Database.Models.Dto
{
    public record class LoginResponse(bool IsSuccess, Role? Role=null, Guid? userId=null);
  
}
