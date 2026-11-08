using POS_Business.DTOs;
using POS_DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS_Business.interfaceis
{
    public interface IRoleService
    {
        bool DeleteRole(int roleID); 
        bool UpdateRole(RoleDto role);
        bool IsExists(int roleID);
        bool AddRole(RoleDto role);
        RoleDto GetRoleById(int roleID);
    }
}
