using POS_Business.DTOs.Users;
using POS_Business.Servicies;
using POS_DataAccess;
using POS_DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace POS_Business.Services
{
    public interface IUserService
    {
        DataTable GetAll();
        bool Delete(int userID);
        bool AddNewUser(ref CreateUserDto user);
        UserDto GetUserById(int userID);
        bool IsUserExists(int userID);
        bool IsUserExists(string Username);
        bool ChangePassword(int userID, string password);
        UserDto GetByUsernameAndPassword(string Username, string Password);

    }
}
