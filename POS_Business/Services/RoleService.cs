using POS_Business.DTOs;
using POS_Business.DTOs.Users;
using POS_Business.Interfaces;
using POS_Business.Validations;
using POS_DataAccess.Interfaces;
using POS_DataAccess.Models;
using System;
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
            return _roleRepository.GetAllRoles();

        }
        public bool IsExists(int roleID)
        {
            return _roleRepository.IsExists(roleID);
        }
        public bool DeleteRole(int roleID)
        {

            return _roleRepository.DeleteRole(roleID);

        }
        public bool AddRole(RoleDto roleDto)
        {

            RoleValidator.Validate(toRole(roleDto)).ThrowIfInvalid();

            Role role = toRole(roleDto);

            role.RoleID = _roleRepository.AddRole(role);
            return (role.RoleID != -1);

        }
        public DataTable GetAllPermissions()
        {
            return _permissionRepository.GetAllPermissions();

        }
        public RoleDto GetRoleByID(int roleID)
        {
            Role role = _roleRepository.GetById(roleID);
            if (role == null) return null;

            role.Permissions = _permissionRepository.GetAllPermissionsByRole(roleID);

            return toDto(role);

        }
        public bool UpdateRole(RoleDto roleDto)
        {
            if (roleDto == null) return false;

            Role role = new Role
            {
                RoleID = roleDto.RoleID,
                RoleName = roleDto.RoleName
            };

            return _roleRepository.UpdateRole(role);

        }
        public List<Permission> GetAllPermissionsByRole(int roleID)
        {
            return _permissionRepository.GetAllPermissionsByRole(roleID);
        }


    }
}
