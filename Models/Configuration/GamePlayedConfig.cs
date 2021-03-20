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
                new GamePlayed { GamePlayedID = 3, PlayerID = 2, CourseID = 1, Score = 29}
            );
        }
    }
}
