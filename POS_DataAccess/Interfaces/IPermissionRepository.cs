using POS_DataAccess.Models;
using System.Collections.Generic;
using System.Data;

namespace POS_DataAccess.Interfaces
{
    public interface IPermissionRepository
    {
        DataTable GetAllPermissions();
        List<Permission> GetAllPermissionsByRole(int roleID);
    }
}
