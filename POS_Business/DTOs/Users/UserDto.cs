using System;

namespace POS_Business.DTOs.Users
{
    public class UserDto
    {
        public int UserID { get; set; }
        public string FullName { get; set; }
        public string Username { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public string ImagePath { get; set; }
        public DateTime CreatedAt { get; set; }
        public bool IsActive { get; set; }

        public string RoleName { get; set; }
        public int RoleID { get; set; }

    }

}
