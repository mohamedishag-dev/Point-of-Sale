using POS_Business.DTOs.Users;
using System.Threading.Tasks;

namespace POS_Business.Interfaces
{
    public interface IAuthService
    {
        Task<AuthResult> Login(string username, string password);

    }

}
