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
                new Hole { HoleID = 6, CourseID = 1, Par = 4, Distance = 360.47, SequenceNumber = 6 },
                new Hole { HoleID = 7, CourseID = 1, Par = 3, Distance = 172.59, SequenceNumber = 7 },
                new Hole { HoleID = 8, CourseID = 1, Par = 4, Distance = 348.94, SequenceNumber = 8 },
                new Hole { HoleID = 9, CourseID = 1, Par = 3, Distance = 186.06, SequenceNumber = 9 },

                new Hole { HoleID = 10, CourseID = 2, Par = 3, Distance = 285, SequenceNumber = 1 },
                new Hole { HoleID = 11, CourseID = 2, Par = 3, Distance = 246, SequenceNumber = 2 },
                new Hole { HoleID = 12, CourseID = 2, Par = 3, Distance = 266, SequenceNumber = 3 },
                new Hole { HoleID = 13, CourseID = 2, Par = 3, Distance = 154, SequenceNumber = 4 },
                new Hole { HoleID = 14, CourseID = 2, Par = 3, Distance = 203, SequenceNumber = 5 },
                new Hole { HoleID = 15, CourseID = 2, Par = 3, Distance = 262, SequenceNumber = 6 },
                new Hole { HoleID = 16, CourseID = 2, Par = 3, Distance = 213, SequenceNumber = 7 },
                new Hole { HoleID = 17, CourseID = 2, Par = 4, Distance = 420, SequenceNumber = 8 },
                new Hole { HoleID = 18, CourseID = 2, Par = 3, Distance = 256, SequenceNumber = 9 },
                new Hole { HoleID = 19, CourseID = 2, Par = 3, Distance = 164, SequenceNumber = 10 },
                new Hole { HoleID = 20, CourseID = 2, Par = 3, Distance = 141, SequenceNumber = 11 },
                new Hole { HoleID = 21, CourseID = 2, Par = 3, Distance = 141, SequenceNumber = 12 },
                new Hole { HoleID = 22, CourseID = 2, Par = 3, Distance = 266, SequenceNumber = 13 },
                new Hole { HoleID = 23, CourseID = 2, Par = 3, Distance = 203, SequenceNumber = 14 },
                new Hole { HoleID = 24, CourseID = 2, Par = 3, Distance = 246, SequenceNumber = 15 },
                new Hole { HoleID = 25, CourseID = 2, Par = 3, Distance = 226, SequenceNumber = 16 },
                new Hole { HoleID = 26, CourseID = 2, Par = 4, Distance = 417, SequenceNumber = 17 },
                new Hole { HoleID = 27, CourseID = 2, Par = 3, Distance = 269, SequenceNumber = 18 }
            );
        }
    }
}
