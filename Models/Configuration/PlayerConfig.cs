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
                new Player { PlayerID = 2, Name = "Ichabod Fletchman", Username = "IFletchman", Password = "Password" },
                new Player { PlayerID = 3, Name = "Jimmy Craig", Username = "JCraig", Password = "Hockey" },
                new Player { PlayerID = 4, Name = "Kerri Strug", Username = "KStrug", Password = "Vault" },
                new Player { PlayerID = 5, Name = "Jesse Owens", Username = "JOwens", Password = "Track" }
            );
        }
    }
}
