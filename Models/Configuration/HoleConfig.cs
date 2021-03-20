using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DiscGolf.Models
{
    internal class HoleConfig : IEntityTypeConfiguration<Hole>
    {
        public void Configure(EntityTypeBuilder<Hole> entity)
        {
            entity.HasData(
                new Hole { HoleID = 1, CourseID = 1, Par = 3, Distance = 317.02, SequenceNumber = 1 },
                new Hole { HoleID = 2, CourseID = 1, Par = 3, Distance = 305.48, SequenceNumber = 2 },
                new Hole { HoleID = 3, CourseID = 1, Par = 3, Distance = 297.37, SequenceNumber = 3 },
                new Hole { HoleID = 4, CourseID = 1, Par = 3, Distance = 188.97, SequenceNumber = 4 },
                new Hole { HoleID = 5, CourseID = 1, Par = 2, Distance = 253.04, SequenceNumber = 5 },
                new Hole { HoleID = 6, CourseID = 1, Par = 6, Distance = 360.47, SequenceNumber = 6 },
                new Hole { HoleID = 7, CourseID = 1, Par = 3, Distance = 172.59, SequenceNumber = 7 },
                new Hole { HoleID = 8, CourseID = 1, Par = 4, Distance = 348.94, SequenceNumber = 8 },
                new Hole { HoleID = 9, CourseID = 1, Par = 3, Distance = 186.06, SequenceNumber = 9 }
            );
        }
    }
}
