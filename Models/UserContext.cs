using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace DiscGolf.Models
{
    public class UserContext : DbContext
    {
        public UserContext(DbContextOptions<UserContext> options)
            : base(options)
        { }

        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasData(
                new User
                {
                    UserID = 1,
                    Name = "Thomas Mahr",
                    Username = "ThomasMahr",
                    Password = "pass",
                    GamesPlayed = 0,
                    GamesWon = 0,
                    AverageScore = 0,
                    BestScore = 0
                }
            );
        }
    }
}
