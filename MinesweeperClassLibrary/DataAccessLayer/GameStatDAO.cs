/*Darius Drake William Castellanos
 * CST-250
 * Milestone 6
 * Updated by Will Castellanos
 * 04/23/26
 */


using MinesweeperClassLibrary.Models;
using System;
using System.Collections.Generic;
using System.IO;

namespace MinesweeperClassLibrary.DataAccessLayer
{
    /// <summary>
    /// Handles saving and loading game statistics from a text file.
    /// This is the only class that directly touches the data file.
    /// </summary>
    public class GameStatDAO
    {
        // sets default file location
        private string defaultFilePath = "scores.txt";
        public void SaveGameStats(string filePath, List<GameStat> gameStats)
        {
            using StreamWriter writer = new StreamWriter(filePath);

            foreach (GameStat stat in gameStats)
            {
                writer.WriteLine($"{stat.Id},{stat.Name},{stat.Score},{stat.GameTime},{stat.DatePlayed}");
            }
        }

        public List<GameStat> LoadGameStats(string filePath)
        {
            List<GameStat> gameStats = new List<GameStat>();

            if (!File.Exists(filePath))
            {
                return gameStats;
            }

            string[] lines = File.ReadAllLines(filePath);

            foreach (string line in lines)
            {
                string[] parts = line.Split(',');

                if (parts.Length >= 5)
                {
                    GameStat stat = new GameStat
                    {
                        Id = int.Parse(parts[0]),
                        Name = parts[1],
                        Score = int.Parse(parts[2]),
                        GameTime = TimeSpan.Parse(parts[3]),
                        DatePlayed = DateTime.Parse(parts[4])
                    };

                    gameStats.Add(stat);
                }
            }

            return gameStats;
        }
        /// <summary>
        /// Saves game statistics to the default scores file.
        /// </summary>
        /// <param name="gameStats">The list of game statistics to save.</param>
        public void SaveGameStats(List<GameStat> gameStats)
        {
            SaveGameStats(defaultFilePath, gameStats);
        }

        /// <summary>
        /// Loads game statistics from the default scores file.
        /// </summary>
        /// <returns>A list of saved game statistics.</returns>
        public List<GameStat> LoadGameStats()
        {
            return LoadGameStats(defaultFilePath);
        }
    }
}