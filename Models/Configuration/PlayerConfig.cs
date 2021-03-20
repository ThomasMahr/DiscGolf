using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DiscGolf.Models
{
    internal class PlayerConfig : IEntityTypeConfiguration<Player>
    {
        public void Configure(EntityTypeBuilder<Player> entity)
        {
            entity.HasData(
                new Player { PlayerID = 1, Name = "Thomas Mahr", Username = "ThomasMahr", Password = "password" },
                new Player { PlayerID = 2, Name = "Alyssa Ader", Username = "AAder", Password = "Engineering"}
            );
        }
    }
}
