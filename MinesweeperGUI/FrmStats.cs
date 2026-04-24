/*Darius Drake William Castellanos
 * CST-250
 * Milestone 5
 * Updated by Will Castellanos
 * 2/17/26
 */

using MinesweeperClassLibrary.Models;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using MinesweeperClassLibrary.BusinessLogicLayer;

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
        private GameStatLogic gameStatLogic = new GameStatLogic();

        /// <summary>
        /// Initializes a new instance of the FrmStats form.
        /// </summary>
        public FrmStats()
        {
            InitializeComponent();

            // Load existing scores when opening stats
            gameStats = gameStatLogic.LoadGameStats();

            RefreshGrid();
        }

        /// <summary>
        /// Initializes a new instance of the FrmStats form, loads existing scores,
        /// adds the new game result, and updates the saved statistics.
        /// </summary>
        /// <param name="stat">The game statistic to add to the saved results.</param>
        public FrmStats(GameStat stat)
        {
            InitializeComponent();

            // Load existing scores first so previous games are not overwritten.
            gameStats = gameStatLogic.LoadGameStats();

            // Give the new score the next available ID.
            stat.Id = gameStats.Count + 1;

            // Add the new score from the completed game.
            gameStats.Add(stat);

            // Save the full updated list back to the default scores file.
            gameStatLogic.SaveGameStats(gameStats);

            RefreshGrid();
        }

        /// <summary>
        /// Refreshes the DataGridView with the current list of game statistics.
        /// </summary>
        private void RefreshGrid()
        {
            List<object> displayStats = new List<object>();

            foreach (GameStat stat in gameStats)
            {
                displayStats.Add(new
                {
                    stat.Id,
                    stat.Name,
                    stat.Score,
                    GameTime = stat.GameTime.ToString(@"hh\:mm\:ss"),
                    Date = stat.DatePlayed
                });
            }

            DgvStats.DataSource = null;
            DgvStats.DataSource = displayStats;

            UpdateAnalysisLabels();
        }


        // Needs to fix n-layer architecture we need a DAL and needs to write to the text file
        // MnuSaveClick needs to be in DAL

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
                gameStatLogic.SaveGameStats(saveFileDialog.FileName, gameStats);

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

                gameStats = gameStatLogic.LoadGameStats(openFileDialog.FileName);

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
            gameStats = gameStatLogic.SortByName(gameStats);
            RefreshGrid();
        }

        /// <summary>
        /// Sorts the statistics list by score in descending order.
        /// </summary>
        /// <param name="sender">The control that triggered the event.</param>
        /// <param name="e">The event data.</param>
        private void MnuSortByScoreClick(object sender, EventArgs e)
        {
            gameStats = gameStatLogic.SortByScore(gameStats);
            RefreshGrid();
        }

        /// <summary>
        /// Sorts the statistics list by date in descending order.
        /// </summary>
        /// <param name="sender">The control that triggered the event.</param>
        /// <param name="e">The event data.</param>
        private void MnuSortByDateClick(object sender, EventArgs e)
        {
            gameStats = gameStatLogic.SortByDate(gameStats);
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

        /// <summary>
        /// Updates the analysis labels beneath the grid with average score and average game time.
        /// </summary>
        private void UpdateAnalysisLabels()
        {
            double averageScore = gameStatLogic.CalculateAverageScore(gameStats);
            TimeSpan averageTime = gameStatLogic.CalculateAverageGameTime(gameStats);

            LblAverageScore.Text = $"Average Points: {averageScore:F2}";
            LblAverageTime.Text = $"Average Time Per Game: {averageTime:hh\\:mm\\:ss}";
        }
    }
}