
namespace POS_Business.DTOs.Users
{
    public enum LoginStatus { Success, InvalidCredentials, Inactive, LockedOut }

    public class AuthResult
    {
        public LoginStatus Status { get; set; }
        public bool Success => Status == LoginStatus.Success;

    }

}
