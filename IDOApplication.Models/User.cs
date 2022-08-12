﻿using System;

namespace IDOApplication.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

        public User(string email,string password)
        {
            this.Email = email;
            this.Password = password;
        }
    }
}
