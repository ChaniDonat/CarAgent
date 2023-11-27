using System;
using System.Collections.Generic;

namespace DataAccess.DBModels
{
    public partial class UserDto
    {
        public int UserId { get; set; }
        public string UserName { get; set; } = null!;
        public string? UserEmail { get; set; }
        public string UserPhoneNumber { get; set; } = null!;
    }
}
