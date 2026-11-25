using POS_Business.Security;
using System.Threading.Tasks;

namespace POS_Business.Interfaces
{
    public interface IAuthorizationService
    {
        Task<AuthorizationResult> Login(string username, string password);

    }

}
