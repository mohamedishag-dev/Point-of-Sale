using POS_Business.Security.Users;
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
        bool AddUser(CreateUserDto createUser);
        bool UpdateUser(CreateUserDto createUser);
        bool ChangePassword(int userID, string Oldpassword, string Newpassword);

    }
}
