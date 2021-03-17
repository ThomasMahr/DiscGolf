﻿using System;
using System.ComponentModel.DataAnnotations;

namespace DiscGolf.Models
{
    public class Player
    {
        public int PlayerID { get; set; }//auto-generated by EF

        [Required(ErrorMessage = "Please enter your name.")]
        public string Name { get; set; }
        
        [Required(ErrorMessage = "Please enter your username.")]
        public string Username { get; set; }

        [Required(ErrorMessage = "Please enter your password.")]
        public string Password { get; set; }

        public string Slug =>
            Name?.Replace(' ', '-').ToLower();
    }
}
