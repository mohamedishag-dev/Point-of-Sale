using POS_Business.DTOs.Users;
using POS_DataAccess.interfaceis;
using POS_DataAccess.Models;
using POS_DataAccess.Repositories;
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
        public UserService()
        {

            _repo = new UserRepository();

        }

        public UserDto GetUserById(int userID)
        {
            User user = _repo.GetUserById(userID);

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

        public DataTable GetAll()
        {

            return _repo.GetAll();

        }

        public bool AddNewUser(ref CreateUserDto userDto)
        {

            User user = new User { FullName = userDto.FullName, 
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


        user.UserID = _repo.AddNewUser(user);
            return (user.UserID != -1);

        }

        public bool Delete(int userID)
        {
            return _repo.Delete(userID);
        }

        public bool Update(User user)
        {

            return _repo.UpdateUser(user);
        }

        public bool IsUserExists(int userID)
        {
            return _repo.IsUserExists(userID);
        }

        public bool IsUserExists(string Username)
        {
            return _repo.IsUserExists(Username);
        }

        public bool ChangePassword(int userID, string password)
        {
            return false;
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
