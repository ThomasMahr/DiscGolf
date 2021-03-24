namespace DiscGolf.Models
{
    public class GamesPlayedUnitOfWork : IGamesPlayedUnitOfWork
    {
        private DiscGolfContext context { get; set; }
        public GamesPlayedUnitOfWork(DiscGolfContext ctx) => context = ctx;

        private Repository<Course> courseData;
        public Repository<Course> Courses
        {
            get
            {
                if (courseData == null)
                    courseData = new Repository<Course>(context);
                return courseData;
            }
        }

        private Repository<Hole> holeData;
        public Repository<Hole> Holes
        {
            get
            {
                if (holeData == null)
                    holeData = new Repository<Hole>(context);
                return holeData;
            }
        }

        private Repository<Player> playerData;
        public Repository<Player> Players
        {
            get
            {
                if (playerData == null)
                    playerData = new Repository<Player>(context);
                return playerData;
            }
        }

        private Repository<GamePlayed> gamePlayedData;
        public Repository<GamePlayed> GamesPlayed
        {
            get
            {
                if (gamePlayedData == null)
                    gamePlayedData = new Repository<GamePlayed>(context);
                return gamePlayedData;
            }
        }

        public void Save() => context.SaveChanges();
    }
}
