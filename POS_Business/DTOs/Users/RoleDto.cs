using POS_Business.DTOs.Users;
using System.Collections.Generic;

namespace POS_Business.DTOs
{
    public class RoleDto
    {
        public int RoleID { get; set; }
        public string RoleName { get; set; }
        public List<PermissionDto> Permissions { get; set; } = new List<PermissionDto>();

    }
}
