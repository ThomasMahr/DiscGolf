using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DiscGolf.Models
{
    internal class CourseConfig : IEntityTypeConfiguration<Course>
    {
        public void Configure(EntityTypeBuilder<Course> entity)
        {
            entity.HasData(
                new Course { CourseID = 1, CourseName = "Capitol Technology University", ZipCode = 20708 },
                new Course { CourseID = 2, CourseName = "Turkey Hill Park", ZipCode = 20646 }
            );
        }
    }
}
