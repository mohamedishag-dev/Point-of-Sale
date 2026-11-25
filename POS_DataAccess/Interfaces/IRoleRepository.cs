using POS_DataAccess.Models;
using System.Data;

namespace POS_DataAccess.Interfaces
{
    public interface IRoleRepository
    {
        int AddRole(Role role);
        DataTable GetAllRoles();
        Role GetByID(int roleID);
        bool IsExists(int roleID);
        bool UpdateRole(Role role);
        bool DeleteRole(int roleID);
        Role GetByRoleName(string roleName);

    }
}
