using POS_DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS_Business.DTOs.Users
{
    public class UserDto
    {
        public int UserID { get; set; }
        public int RoleID { get; set; }
        public string FullName { get; set; } = string.Empty;
        public string Phone { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;
        public string ImagePath { get; set; } = string.Empty;
        public string RoleName { get; set; } = string.Empty;
        public string CreatedAt { get; set; } = string.Empty;
        public bool IsActive { get; set; }

    }

}
