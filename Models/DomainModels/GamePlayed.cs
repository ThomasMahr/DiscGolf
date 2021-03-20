namespace DiscGolf.Models
{
    public class GamePlayed
    {
        public int GamePlayedID { get; set; } //Primary Key

        public int PlayerID { get; set; } //Foreign Key
        public int CourseID { get; set; } //Foreign Key

        public int Score { get; set; }

        public Player Player { get; set; }
        public Course Course { get; set; }
    }
}
