using Microsoft.EntityFrameworkCore;

namespace DiscGolf.Models
{
    public class DiscGolfContext : DbContext
    {
        public DiscGolfContext(DbContextOptions<DiscGolfContext> options)
            : base(options)
        { }

        public DbSet<Player> Players { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Hole> Holes { get; set; }
        public DbSet<GamePlayed> GamesPlayed { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //One-to-many relationship between Player and GamePlayed
            modelBuilder.Entity<GamePlayed>()
                .HasOne(gp => gp.Player)
                .WithMany(p => p.GamesPlayed)
                .HasForeignKey(gp => gp.PlayerID);

            //One-to-many relationship between Course and GamePlayed
            modelBuilder.Entity<GamePlayed>()
                .HasOne(gp => gp.Course)
                .WithMany(p => p.GamesPlayed)
                .HasForeignKey(gp => gp.CourseID);

            //One-to-many relationship between Course and Hole
            modelBuilder.Entity<Hole>()
                .HasOne(gp => gp.Course)
                .WithMany(p => p.Holes)
                .HasForeignKey(gp => gp.CourseID);

            modelBuilder.ApplyConfiguration(new PlayerConfig());
            modelBuilder.ApplyConfiguration(new CourseConfig());
            modelBuilder.ApplyConfiguration(new HoleConfig());
            modelBuilder.ApplyConfiguration(new GamePlayedConfig());
        }
    }
}
