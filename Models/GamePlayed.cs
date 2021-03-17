namespace DiscGolf.Models
{
    public class GamePlayed
    {
        public int GamePlayedID { get; set; }
        public int GameID { get; set; }
        public int UserID { get; set; }
        public int CourseID { get; set; }
        public int Score { get; set; }
    }
}
