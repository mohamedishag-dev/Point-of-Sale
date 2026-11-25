namespace POS_Business.Security.Users
{
    public class CreateUserDto
    {
        public int UserID { get; set; }
        public string FullName { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public string ImagePath { get; set; }
        public bool IsActive { get; set; }
        public int RoleID { get; set; }
        public RoleDto Role { get; set; }

    }
}
