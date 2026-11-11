using POS_DataAccess.Models;

namespace POS_DataAccess.Interfaces
{
    public interface IRoleRepository
    {
        int AddRole(Role role);
        Role GetById(int roleID);
        bool IsExists(int roleID);
        bool UpdateRole(Role role);
        bool DeleteRole(int roleID);
    }
}
