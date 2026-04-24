using MinesweeperClassLibrary.DataAccessLayer;
using MinesweeperClassLibrary.Models;
using System.Collections.Generic;

namespace MinesweeperClassLibrary.BusinessLogicLayer
{
    /// <summary>
    /// Handles business logic for saving, loading, and sorting game statistics.
    /// </summary>
    public class GameStatLogic
    {
        private GameStatDAO gameStatDAO = new GameStatDAO();

        /// <summary>
        /// Sends game statistics to the Data Access Layer to be saved.
        /// </summary>
        public void SaveGameStats(string filePath, List<GameStat> gameStats)
        {
            gameStatDAO.SaveGameStats(filePath, gameStats);
        }

        /// <summary>
        /// Requests game statistics from the Data Access Layer.
        /// </summary>
        public List<GameStat> LoadGameStats(string filePath)
        {
            return gameStatDAO.LoadGameStats(filePath);
        }
        /// <summary>
        /// Saves game statistics to the default scores file.
        /// </summary>
        /// <param name="gameStats">The list of game statistics to save.</param>
        public void SaveGameStats(List<GameStat> gameStats)
        {
            gameStatDAO.SaveGameStats(gameStats);
        }

        /// <summary>
        /// Loads game statistics from the default scores file.
        /// </summary>
        /// <returns>A list of saved game statistics.</returns>
        public List<GameStat> LoadGameStats()
        {
            return gameStatDAO.LoadGameStats();
        }

        /// <summary>
        /// Sorts game statistics by player name.
        /// </summary>
        public List<GameStat> SortByName(List<GameStat> gameStats)
        {
            gameStats.Sort(CompareByName);
            return gameStats;
        }

        /// <summary>
        /// Sorts game statistics by score from highest to lowest.
        /// </summary>
        public List<GameStat> SortByScore(List<GameStat> gameStats)
        {
            gameStats.Sort(CompareByScore);
            return gameStats;
        }

        /// <summary>
        /// Sorts game statistics by date from newest to oldest.
        /// </summary>
        public List<GameStat> SortByDate(List<GameStat> gameStats)
        {
            gameStats.Sort(CompareByDate);
            return gameStats;
        }

        /// <summary>
        /// Compares two game statistics by player name.
        /// </summary>
        private int CompareByName(GameStat firstStat, GameStat secondStat)
        {
            return firstStat.Name.CompareTo(secondStat.Name);
        }

        /// <summary>
        /// Compares two game statistics by score from highest to lowest.
        /// </summary>
        private int CompareByScore(GameStat firstStat, GameStat secondStat)
        {
            return secondStat.Score.CompareTo(firstStat.Score);
        }

        /// <summary>
        /// Compares two game statistics by date from newest to oldest.
        /// </summary>
        private int CompareByDate(GameStat firstStat, GameStat secondStat)
        {
            return secondStat.DatePlayed.CompareTo(firstStat.DatePlayed);
        }
    }
}