using POS_Business.Security.Users;
using System.Collections.Generic;

namespace POS_Business.Security
{
    public class RoleDto
    {
        public int RoleID { get; set; }
        public string RoleName { get; set; }
        public List<PermissionDto> Permissions { get; set; } = new List<PermissionDto>();

    }
}
