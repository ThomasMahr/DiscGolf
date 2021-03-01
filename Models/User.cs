﻿using System;
using System.ComponentModel.DataAnnotations;

namespace DiscGolf.Models
{
    public class User
    {
        public int UserID { get; set; }
        public string Name { get; set; }
        
        [Required(ErrorMessage = "Please enter your username.")]
        public string Username { get; set; }

        [Required(ErrorMessage = "Please enter your password.")]
        public string Password { get; set; }

        public int GamesWon { get; set; }
        public int GamesPlayed { get; set; }
        public decimal AverageScore { get; set; }
        public int BestScore { get; set; }
        public void UpdateValues (int currentScore, bool isWin)
        {
            GamesPlayed++;
            if (isWin)
                GamesWon++;
            AverageScore = (AverageScore + currentScore) / GamesPlayed;
            if (currentScore < BestScore)
                BestScore = currentScore;
        }
        public string Slug =>
            Name?.Replace(' ', '-').ToLower();
    }
}
