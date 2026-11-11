using POS_DataAccess.Repositories;
using POS_DataAccess.Interfaces;
using POS_Business.DTOs.Users;
using POS_DataAccess.Models;
using System;
using System.Data;
namespace POS_Business.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _repo;
        public UserService(IUserRepository repository)
        {
            _repo = repository;
        
        }


        public DataTable GetAll()
        {

            return _repo.GetAll();

        }

        public bool IsUserExists(int userID)
        {
            return _repo.IsUserExists(userID);
        }

        public UserDto GetUserByID(int userID)
        {
            User user = _repo.GetUserById(userID);

            if (user == null) 
                return null;

            return new UserDto
            {
                UserID = user.UserID,
                FullName = user.FullName,
                Username = user.Username,
                Phone = user.Phone,
                Email = user.Email,
                Address = user.Address,
                ImagePath = user.ImagePath,
                CreatedAt = user.CreatedAt,
                IsActive = user.IsActive,
                RoleID = user.RoleID

            };

        }

        public bool IsUserExists(string Username)
        {
            return _repo.IsUserExists(Username);
        }

        public bool UpdateUser(CreateUserDto userDto)
        {
            if (userDto == null)
                return false;

            User user = new User
            {
                UserID = userDto.UserID,
                FullName = userDto.FullName,
                Username = userDto.Username,
                PasswordHash = userDto.Password,
                Phone = userDto.Phone,
                Email = userDto.Email,
                Address = userDto.Address,
                ImagePath = userDto.ImagePath,
                CreatedAt = DateTime.Now,
                IsActive = userDto.IsActive,
                RoleID = userDto.RoleID
            };

            return _repo.UpdateUser(user);
        }

        public bool Delete(int userID, int CreatedBy)
        {
            if (!GetUserByID(CreatedBy).IsActive)
                return false;

            return _repo.Delete(userID);
        }

        public bool ChangePassword(int userID, string password)
        {
            return false;
        }

        public bool AddNewUser(ref CreateUserDto userDto, int CreatedBy)
        {
            if (userDto == null)
                return false;

            if (!GetUserByID(CreatedBy).IsActive)
                return false;

            User user = new User
            {
                FullName = userDto.FullName,
                Username = userDto.Username,
                PasswordHash = userDto.Password,
                Phone = userDto.Phone,
                Email = userDto.Email,
                Address = userDto.Address,
                ImagePath = userDto.ImagePath,
                CreatedAt = DateTime.Now,
                IsActive = userDto.IsActive,
                RoleID = userDto.RoleID,
                CreatedBy = userDto.RoleID
            };

            user.UserID = _repo.AddNewUser(user);
            return (user.UserID != -1);
        }

        public UserDto GetByUsernameAndPassword(string Username, string Password)
        {

            User user = _repo.GetByUsernameAndPassword(Username, Password);

            if (user == null) return null;

            if (!user.IsActive) return null;

            return new UserDto
            {
                UserID = user.UserID,
                FullName = user.FullName,
                Phone = user.Phone,
                Email = user.Email,
                IsActive = user.IsActive,
                RoleID = user.RoleID

            };
        }

    }
}
