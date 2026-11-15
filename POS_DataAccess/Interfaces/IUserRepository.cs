using POS_DataAccess.Models;
using System.Data;

namespace POS_DataAccess.Interfaces
{
    public interface IUserRepository
    {
        DataTable GetAll();
        bool Delete(int ID);
        int AddUser(User user);
        User GetUserById(int ID);
        bool IsUserExists(int ID);
        bool UpdateUser(User user);
        bool IsUserExists(string Username);
        bool ChangePassword(int UserID, string NewPassword);
        User GetByUsernameAndPassword(string Username, string Password);

    }
}
