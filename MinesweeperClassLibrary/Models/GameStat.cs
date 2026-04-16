/*Darius Drake William Castellanos
 * CST-250
 * Milestone 5
 * Updated by Will Castellanos
 * 2/17/26
 */

using System;

namespace MinesweeperClassLibrary.Models
{
    /// <summary>
    /// Represents a saved game statistic entry for a completed game.
    /// </summary>
    public class GameStat
    {
        /// <summary>
        /// Gets or sets the unique identifier for the game stat.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the player name.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the player score.
        /// </summary>
        public int Score { get; set; }

        /// <summary>
        /// Gets or sets the total game time.
        /// </summary>
        public TimeSpan GameTime { get; set; }

        /// <summary>
        /// Gets or sets the date the game was played.
        /// </summary>
        public DateTime DatePlayed { get; set; }

        /// <summary>
        /// Creates a default game statistic object.
        /// </summary>
        public GameStat()
        {
            Id = 0;
            Name = string.Empty;
            Score = 0;
            GameTime = TimeSpan.Zero;
            DatePlayed = DateTime.Now;
        }

        /// <summary>
        /// Creates a game statistic object with the provided values.
        /// </summary>
        /// <param name="id">The game stat identifier.</param>
        /// <param name="name">The player name.</param>
        /// <param name="score">The player score.</param>
        /// <param name="gameTime">The total game time.</param>
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