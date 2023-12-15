using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject.Database.Models.Dto.User
{
    public class ChangeUserRoleDto
    {
        public Guid AdminId { get; set; }

        public Role AdminRole { get; set; }

        public Guid UserId { get; set; }

        public Role UserRole { get; set; }
    }
}
