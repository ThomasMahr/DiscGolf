using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace DiscGolf.Models
{
    public class DiscGolfContext : DbContext
    {
        public DiscGolfContext(DbContextOptions<DiscGolfContext> options)
            : base(options)
        { }

        public DbSet<User> Users { get; set; }
        public DbSet<Course> Courses { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasData(
                new User
                {
                    UserID = 1,
                    Name = "Thomas Mahr",
                    Username = "ThomasMahr",
                    Password = "pass"
                }
            );
            modelBuilder.Entity<Course>().HasData(
                new Course
                {
                    CourseID = 1,
                    CourseName = "Capitol Technology University",
                    NumberOfHoles = 9,
                    CoursePar = 28,
                    HolePar = "3-3-3-3-2-4-3-4-3"
                }
            );
        }
    }
}
