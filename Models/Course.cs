namespace DiscGolf.Models
{
    public class Course
    {
        public int CourseID { get; set; }
        public string CourseName { get; set; }
        public int NumberOfHoles { get; set; }
        public int CoursePar { get; set; }
        public int[] Holes { get; set; }
    }
}
