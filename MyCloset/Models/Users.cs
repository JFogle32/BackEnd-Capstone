﻿using System.ComponentModel.DataAnnotations;

namespace MyCloset.Models
{
    public class Users
    {


        public int Id { get; set; }


        public string UserName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;

    }
}
