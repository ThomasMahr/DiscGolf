using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DiscGolf.Models
{
    internal class GamePlayedConfig : IEntityTypeConfiguration<GamePlayed>
    {
        public void Configure(EntityTypeBuilder<GamePlayed> entity)
        {
            entity.HasData(
                new GamePlayed { GamePlayedID = 1, PlayerID = 1, CourseID = 1, Score = 26 },
                new GamePlayed { GamePlayedID = 2, PlayerID = 1, CourseID = 1, Score = 31 },
                new GamePlayed { GamePlayedID = 3, PlayerID = 2, CourseID = 1, Score = 29 },
                new GamePlayed { GamePlayedID = 4, PlayerID = 2, CourseID = 2, Score = 31 },
                new GamePlayed { GamePlayedID = 5, PlayerID = 3, CourseID = 1, Score = 26 }
            );
        }
    }
}
