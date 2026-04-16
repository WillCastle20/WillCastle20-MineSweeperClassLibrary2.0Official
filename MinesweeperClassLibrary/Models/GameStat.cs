namespace MinesweeperClassLibrary.Models
{
    public class GameStat
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Score { get; set; }
        public TimeSpan GameTime { get; set; }
        public DateTime DatePlayed { get; set; }

        public GameStat()
        {
            Id = 0;
            Name = string.Empty;
            Score = 0;
            GameTime = TimeSpan.Zero;
            DatePlayed = DateTime.Now;
        }

        public GameStat(int id, string name, int score, TimeSpan gameTime)
        {
            Id = id;
            Name = name;
            Score = score;
            GameTime = gameTime;
            DatePlayed = DateTime.Now;
        }
    }
}