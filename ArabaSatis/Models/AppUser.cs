﻿using Microsoft.AspNetCore.Identity;

namespace ArabaSatis.Models
{
    public class AppUser:IdentityUser<int>
    {
        public string FirstName { get; set; }=string.Empty;
        public string LastName { get; set; }= string.Empty;
        public string City { get; set; } = string.Empty;   

        public int ? ConfirmCode { get; set;  }
    }
}
