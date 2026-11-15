using POS_Business.DTOs.Users;
using System.Data;
namespace POS_Business.Services
{
    public interface IUserService
    {
        DataTable GetAll();
        bool Delete(int userID);
        bool IsUserExists(int userID);
        UserDto GetUserByID(int userID);
        bool IsUserExists(string Username);
        bool AddUser(ref CreateUserDto createUser);
        bool ChangePassword(int userID, string password);
        UserDto GetByUsernameAndPassword(string Username, string Password);

    }
}
