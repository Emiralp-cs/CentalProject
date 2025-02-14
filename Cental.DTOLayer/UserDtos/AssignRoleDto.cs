using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cental.DTOLayer.UserDtos
{
    public class AssignRoleDto
    {
        public int UserId { get; set; }
        public int RoleId { get; set; }
        public bool RoleExist { get; set; }
        public string RoleName { get; set; }


    }
}
