﻿using System.ComponentModel.DataAnnotations;

namespace RoleBasedAuthorization.Models
{
    public class Login
    {
        [Required]
        public string UserName { get; set; }
        [Required]
        public string Password { get; set; }
        public string Role {  get; set; }
    }
}
