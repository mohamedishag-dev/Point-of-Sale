using POS_Business.DTOs.Users;
using POS_Business.Interfaces;
using POS_Business.Security;
using POS_Business.Validations;
using POS_DataAccess.Interfaces;
using POS_DataAccess.Models;
using System;
using System.Data;
using System.Threading.Tasks;

namespace POS_Business.Services
{
    public class UserService : IUserService, IAuthorizationService
    {
        internal UserDto toDto(User user)
        {
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
        internal User toUser(CreateUserDto userDto)
        {
            return new User
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
                RoleID = userDto.RoleID,
                CreatedBy = userDto.UserID
            };
        }

        private readonly IUserRepository _userRepository;
        private readonly IRoleService _roleService;
        public UserService(IUserRepository userRepository, IRoleService roleService)
        {
            _userRepository = userRepository;
            _roleService = roleService;
        }


        public DataTable GetAll()
        {
            return _userRepository.GetAll();

        }

        public bool Delete(int userID)
        {
            Session.Require("");

            if (!_userRepository.IsUserExists(userID))
                return false;

            return _userRepository.Delete(userID);

        }

        public bool IsUserExists(int userID)
        {
            return _userRepository.IsUserExists(userID);
        }

        public UserDto GetUserByID(int userID)
        {
            User user = _userRepository.GetUserById(userID);
            if (user == null)
                return null;

            UserDto userDto = toDto(user);
            userDto.Role = _roleService.GetRoleByID(user.RoleID);

            return userDto;
        }

        public bool IsUserExists(string Username)
        {
            return _userRepository.IsUserExists(Username);
        }

        public bool UpdateUser(CreateUserDto userDto)
        {
            if (userDto == null)
                return false;

            User user = toUser(userDto);

            return _userRepository.UpdateUser(user);
        }

        public bool AddUser(CreateUserDto userDto)
        {
            Session.Require(Perm.UsersManage);

            UserValidator.Validate(userDto).ThrowIfInvalid();

            if (IsUserExists(userDto.Username))
                throw new ValidationException("اسم المستخدم موجود بالفعل");


            userDto.UserID = Session.CurrentUser.UserID;
            User user = toUser(userDto);

            user.UserID = _userRepository.AddUser(user);
            return (user.UserID != -1);
        }

        public bool ChangePassword(int userID, string password)
        {
            Session.Require(Perm.UsersManage);

            return _userRepository.ChangePassword(userID, PasswordHasher.HashPassword(password));
        }

        public async Task<AuthResult> Login(string username, string password)
        {
            if (string.IsNullOrWhiteSpace(username) || string.IsNullOrEmpty(password))
                return new AuthResult { Status = LoginStatus.InvalidCredentials };

            User user = _userRepository.GetByUsernameAndPassword(username, password);

            if (user == null)
                return new AuthResult { Status = LoginStatus.InvalidCredentials };

            if (!user.IsActive)
                return new AuthResult { Status = LoginStatus.Inactive };

            Session.Start(toDto(user));
            Session.CurrentUser.Role = _roleService.GetRoleByID(user.RoleID);
            return new AuthResult { Status = LoginStatus.Success };

        }

        public UserDto GetByUsernameAndPassword(string username, string password)
        {

            User user = _userRepository.GetByUsernameAndPassword(username, PasswordHasher.HashPassword(password));

            if (user == null) return null;

            if (!user.IsActive) return null;

            return toDto(user);
        }

    }
}
