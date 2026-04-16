/*Darius Drake William Castellanos
 * CST-250
 * Milestone 5
 * Updated by Will Castellanos
 * 2/17/26
 */

using MinesweeperClassLibrary.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace MinesweeperGUI
{
    /// <summary>
    /// Represents the statistics form used to display, save, load,
    /// and sort Minesweeper game results.
    /// </summary>
    public partial class FrmStats : Form
    {
        /// <summary>
        /// Stores the list of game statistics displayed in the grid.
        /// </summary>
        private List<GameStat> gameStats = new List<GameStat>();

        /// <summary>
        /// Initializes a new instance of the FrmStats form.
        /// </summary>
        public FrmStats()
        {
            InitializeComponent();
            RefreshGrid();
        }

        /// <summary>
        /// Initializes a new instance of the FrmStats form with a starting stat entry.
        /// </summary>
        /// <param name="stat">The game statistic to add to the grid.</param>
        public FrmStats(GameStat stat)
        {
            InitializeComponent();
            gameStats.Add(stat);
            RefreshGrid();
        }

        /// <summary>
        /// Refreshes the DataGridView with the current list of game statistics.
        /// </summary>
        private void RefreshGrid()
        {
            DgvStats.DataSource = null;
            DgvStats.DataSource = gameStats.Select(stat => new
            {
                stat.Id,
                stat.Name,
                stat.Score,
                GameTime = stat.GameTime.ToString(@"hh\:mm\:ss"),
                Date = stat.DatePlayed
            }).ToList();
        }

        /// <summary>
        /// Saves the current list of game statistics to a text file.
        /// </summary>
        /// <param name="sender">The control that triggered the event.</param>
        /// <param name="e">The event data.</param>
        private void MnuSaveClick(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog
            {
                Filter = "Text Files (*.txt)|*.txt",
                Title = "Save High Scores"
            };

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                using StreamWriter writer = new StreamWriter(saveFileDialog.FileName);

                foreach (GameStat stat in gameStats)
                {
                    writer.WriteLine($"{stat.Id},{stat.Name},{stat.Score},{stat.GameTime},{stat.DatePlayed}");
                }

                MessageBox.Show("Scores saved successfully.");
            }
        }

        /// <summary>
        /// Loads game statistics from a text file into the grid.
        /// </summary>
        /// <param name="sender">The control that triggered the event.</param>
        /// <param name="e">The event data.</param>
        private void MnuLoadClick(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                Filter = "Text Files (*.txt)|*.txt",
                Title = "Load High Scores"
            };

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                gameStats.Clear();

                string[] lines = File.ReadAllLines(openFileDialog.FileName);

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

                RefreshGrid();
                MessageBox.Show("Scores loaded successfully.");
            }
        }

        /// <summary>
        /// Closes the statistics form.
        /// </summary>
        /// <param name="sender">The control that triggered the event.</param>
        /// <param name="e">The event data.</param>
        private void MnuExitClick(object sender, EventArgs e)
        {
            Close();
        }

        /// <summary>
        /// Sorts the statistics list by player name.
        /// </summary>
        /// <param name="sender">The control that triggered the event.</param>
        /// <param name="e">The event data.</param>
        private void MnuSortByNameClick(object sender, EventArgs e)
        {
            gameStats = gameStats.OrderBy(stat => stat.Name).ToList();
            RefreshGrid();
        }

        /// <summary>
        /// Sorts the statistics list by score in descending order.
        /// </summary>
        /// <param name="sender">The control that triggered the event.</param>
        /// <param name="e">The event data.</param>
        private void MnuSortByScoreClick(object sender, EventArgs e)
        {
            gameStats = gameStats.OrderByDescending(stat => stat.Score).ToList();
            RefreshGrid();
        }

        /// <summary>
        /// Sorts the statistics list by date in descending order.
        /// </summary>
        /// <param name="sender">The control that triggered the event.</param>
        /// <param name="e">The event data.</param>
        private void MnuSortByDateClick(object sender, EventArgs e)
        {
            gameStats = gameStats.OrderByDescending(stat => stat.DatePlayed).ToList();
            RefreshGrid();
        }

        /// <summary>
        /// Closes the statistics form when the close button is clicked.
        /// </summary>
        /// <param name="sender">The control that triggered the event.</param>
        /// <param name="e">The event data.</param>
        private void BtnCloseClick(object sender, EventArgs e)
        {
            Close();
        }
    }
}