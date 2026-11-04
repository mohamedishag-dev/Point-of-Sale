using System;
using System.Collections.Generic;

namespace POS_DataAccess.Models
{
    public class User
    {
        public int UserID { get; set; }
        public string FullName { get; set; }
        public string Username { get; set; }
        public string PasswordHash { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public string ImagePath { get; set; }
        public DateTime CreatedAt { get; set; }
        public bool IsActive { get; set; }
        public int RoleID { get; set; }

    }
}
