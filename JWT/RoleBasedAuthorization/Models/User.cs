﻿using Microsoft.AspNetCore.Identity;

namespace RoleBasedAuthorization.Models
{
    public class User :IdentityUser
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string role { get; set; }
    }
   
}
