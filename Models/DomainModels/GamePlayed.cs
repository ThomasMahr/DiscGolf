using System.ComponentModel.DataAnnotations;

namespace DiscGolf.Models
{
    public class GamePlayed
    {
        public int GamePlayedID { get; set; } //Primary Key
        public bool GameFinished { get; set; }//Is the game finished yet
        public int StartedByPlayerID { get; set; }//Who started the game

        public int PlayerID { get; set; } //Foreign Key
        public int CourseID { get; set; } //Foreign Key

        [Required(ErrorMessage = "Score is required for a game submission")]
        [Range(1, 100, ErrorMessage = ("Score must be between 1 and 100"))]
        public int Score { get; set; }

        public Player Player { get; set; }
        public Course Course { get; set; }
    }
}
