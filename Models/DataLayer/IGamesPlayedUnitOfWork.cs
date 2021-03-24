namespace DiscGolf.Models
{
    public interface IGamesPlayedUnitOfWork
    {
        public Repository<Course> Courses { get; }
        public Repository<Hole> Holes { get; }
        public Repository<Player> Players { get; }
        public Repository<GamePlayed> GamesPlayed { get; }

        public void Save();
    }
}
