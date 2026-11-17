using System.Collections.Generic;

namespace POS_DataAccess.Models
{
    public class Role
    {
        public int RoleID { get; set; }
        public string RoleName { get; set; }
        public List<Permission> Permissions { get; set; } = new List<Permission>();


    }
}
