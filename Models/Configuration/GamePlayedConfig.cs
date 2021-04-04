using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DiscGolf.Models
{
    internal class GamePlayedConfig : IEntityTypeConfiguration<GamePlayed>
    {
        public void Configure(EntityTypeBuilder<GamePlayed> entity)
        {
            entity.HasData(
                new GamePlayed { GamePlayedID = 1, GameFinished = true, PlayerID = 2, CourseID = 1, Score = 26 },
                new GamePlayed { GamePlayedID = 2, GameFinished = true, PlayerID = 2, CourseID = 1, Score = 31 },
                new GamePlayed { GamePlayedID = 3, GameFinished = true, PlayerID = 3, CourseID = 1, Score = 29 },
                new GamePlayed { GamePlayedID = 4, GameFinished = true, PlayerID = 3, CourseID = 2, Score = 62 },
                new GamePlayed { GamePlayedID = 5, GameFinished = true, PlayerID = 4, CourseID = 1, Score = 26 }
            );
        }
    }
}
