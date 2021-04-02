using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DiscGolf.Models
{
    internal class PlayerConfig : IEntityTypeConfiguration<Player>
    {
        public void Configure(EntityTypeBuilder<Player> entity)
        {
            entity.HasData(
                new Player { PlayerID = 1, Name = "Admin", Username = "Admin", Password = "DiscGolf" },
                new Player { PlayerID = 2, Name = "Thomas Mahr", Username = "ThomasMahr", Password = "Password" },
                new Player { PlayerID = 3, Name = "Alyssa Ader", Username = "AAder", Password = "Engineering" },
                new Player { PlayerID = 4, Name = "Aaron Morphew", Username = "AMorphew", Password = "Cyber" },
                new Player { PlayerID = 5, Name = "Charile Shin", Username = "CShin", Password = "CompSci" }
            );
        }
    }
}
