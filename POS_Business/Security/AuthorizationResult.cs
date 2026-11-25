
namespace POS_Business.Security
{
    public enum LoginStatus { Success, InvalidCredentials, Inactive, LockedOut }

    public class AuthorizationResult
    {
        public LoginStatus Status { get; set; }
        public bool Success => Status == LoginStatus.Success;

    }

}
