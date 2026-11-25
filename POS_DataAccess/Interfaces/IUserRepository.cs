using POS_DataAccess.Models;
using System.Data;

namespace POS_DataAccess.Interfaces
{
    public interface IUserRepository
    {
        DataTable GetAll();
        int AddUser(User user);
        bool Delete(int userID);
        bool UpdateUser(User user);
        User GetUserByID(int userID);
        bool IsUserExists(int userID);
        bool IsUserExists(string Username);
        User GetByUsernameAndPassword(string Username, string Password);
        bool ChangePassword(int userID, string OldPassword, string NewPassword);

    }
}
