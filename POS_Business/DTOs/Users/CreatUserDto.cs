using System;

namespace POS_Business.DTOs.Users
{
    public class CreateUserDto
    {
        public int UserID { get; set; }
        public string FullName { get; set; } = string.Empty;
        public string Username { get; set; } = string.Empty;
        public string PasswordHash { get; set; } = string.Empty;
        public string Phone { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;
        public string ImagePath { get; set; } = string.Empty;
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public bool IsActive { get; set; }
        public int RoleID { get; set; }

        public string RoleName { get; set; } = string.Empty;

    }
}
