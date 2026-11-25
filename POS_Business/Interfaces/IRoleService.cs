using POS_Business.Security;
using POS_DataAccess.Models;
using System.Collections.Generic;
using System.Data;

namespace POS_Business.Interfaces
{
    public interface IRoleService
    {
        DataTable GetAllRoles();
        bool IsExists(int roleID);
        bool AddRole(RoleDto role);
        bool DeleteRole(int roleID);
        DataTable GetAllPermissions();
        bool UpdateRole(RoleDto role);
        RoleDto GetRoleByID(int roleID);
        RoleDto GetByRoleName(string roleName);
        List<Permission> GetAllPermissionsByRole(int roleID);

    }
}
