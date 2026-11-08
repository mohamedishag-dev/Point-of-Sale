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
        bool IsUserExists(int userID);
        UserDto GetUserById(int userID);
        bool IsUserExists(string Username);
        bool Delete(int userID, int CreatedBy);
        bool ChangePassword(int userID, string password);
        bool AddNewUser(ref CreateUserDto user, int CreatedBy);
        UserDto GetByUsernameAndPassword(string Username, string Password);

    }
}
