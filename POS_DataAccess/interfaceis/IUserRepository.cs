using POS_DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS_DataAccess.interfaceis
{
    public interface IUserRepository 
    {
        DataTable GetAll();
        bool Delete(int ID);
        User GetUserById(int ID);
        bool IsUserExists(int ID);
        int AddNewUser(User user);
        bool UpdateUser(User user);
        bool IsUserExists(string Username);
        bool ChangePassword(int UserID, string NewPassword);
        User GetByUsernameAndPassword(string Username, string Password);

    }
}
