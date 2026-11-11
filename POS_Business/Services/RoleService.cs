using POS_Business.DTOs;
using POS_Business.Interfaces;
using POS_DataAccess.Interfaces;
using POS_DataAccess.Models;

namespace POS_Business.Services
{
    public class RoleService : IRoleService
    {
        private readonly IRoleRepository _repo;
        public RoleService(IRoleRepository repo)
        {
            _repo = repo;
        }

        public bool IsExists(int roleID)
        {
            return _repo.IsExists(roleID);
        }
        public bool DeleteRole(int roleID)
        {

            return _repo.DeleteRole(roleID);

        }
        public bool AddRole(RoleDto roleDto)
        {
            if (string.IsNullOrWhiteSpace(roleDto.RoleName))
                return false;

            Role role = new Role { RoleName = roleDto.RoleName };
            role.RoleID = _repo.AddRole(role);
            return (role.RoleID != -1);

        }
        public RoleDto GetRoleById(int roleID)
        {
            Role role = _repo.GetById(roleID);
            if (role == null) return null;

            return new RoleDto
            {
                RoleID = roleID,
                RoleName = role.RoleName
            };

        }
        public bool UpdateRole(RoleDto roleDto)
        {
            if (roleDto == null) return false;

            Role role = new Role
            {
                RoleID = roleDto.RoleID,
                RoleName = roleDto.RoleName
            };

            return _repo.UpdateRole(role);

        }

    }
}
