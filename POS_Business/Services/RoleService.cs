using POS_Business.Interfaces;
using POS_Business.Security;
using POS_Business.Security.Users;
using POS_Business.Validations;
using POS_DataAccess.Interfaces;
using POS_DataAccess.Models;
using System.Collections.Generic;
using System.Data;

namespace POS_Business.Services
{
    public class RoleService : IRoleService
    {
        private readonly IRoleRepository _roleRepository;
        private readonly IPermissionRepository _permissionRepository;
        public RoleService(IRoleRepository repo, IPermissionRepository permissionRepository)
        {
            _roleRepository = repo;
            _permissionRepository = permissionRepository;
        }

        internal RoleDto toDto(Role role)
        {

            RoleDto roleDto = new RoleDto
            {
                RoleID = role.RoleID,
                RoleName = role.RoleName,
            };


            foreach (var item in role.Permissions)
            {
                roleDto.Permissions.Add(new PermissionDto
                {
                    ID = item.ID,
                    PermissionName = item.PermissionName
                });
            }

            return roleDto;
        }

        internal Role toRole(RoleDto roleDto)
        {

            Role role = new Role
            {
                RoleID = roleDto.RoleID,
                RoleName = roleDto.RoleName,
            };


            foreach (var item in roleDto.Permissions)
            {
                role.Permissions.Add(new Permission
                {
                    ID = item.ID,
                    PermissionName = item.PermissionName
                });
            }

            return role;
        }

        public DataTable GetAllRoles()
        {
            Session.Require(Perm.RolesManage);
            return _roleRepository.GetAllRoles();

        }

        public bool IsExists(int roleID)
        {
            Session.Require(Perm.RolesManage);
            return _roleRepository.IsExists(roleID);
        }

        public bool DeleteRole(int roleID)
        {
            Session.Require(Perm.RolesManage);
            return _roleRepository.DeleteRole(roleID);
        }

        public bool AddRole(RoleDto roleDto)
        {
            Session.Require(Perm.RolesManage);
            RoleValidator.Validate(toRole(roleDto)).ThrowIfInvalid();

            Role role = toRole(roleDto);
            role.RoleID = _roleRepository.AddRole(role);
            return (role.RoleID != -1);

        }

        public DataTable GetAllPermissions()
        {
            Session.Require(Perm.RolesManage);
            return _permissionRepository.GetAllPermissions();

        }

        public RoleDto GetRoleByID(int roleID)
        {
            Role role = _roleRepository.GetByID(roleID);
            if (role == null) return null;

            role.Permissions = _permissionRepository.GetAllPermissionsByRole(roleID);

            return toDto(role);

        }

        public bool UpdateRole(RoleDto roleDto)
        {
            Session.Require(Perm.RolesManage);

            if (roleDto == null) return false;

            Role role = toRole(roleDto);

            return _roleRepository.UpdateRole(role);

        }

        public RoleDto GetByRoleName(string roleName)
        {
            Role role = _roleRepository.GetByRoleName(roleName);
            if (role == null) return null;

            role.Permissions = _permissionRepository.GetAllPermissionsByRole(role.RoleID);

            return toDto(role);

        }

        public List<Permission> GetAllPermissionsByRole(int roleID)
        {
            Session.Require(Perm.RolesManage);
            return _permissionRepository.GetAllPermissionsByRole(roleID);
        }


    }
}
