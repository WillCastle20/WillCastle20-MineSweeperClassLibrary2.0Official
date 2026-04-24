/*Darius Drake William Castellanos
 * CST-250
 * Milestone 5
 * Updated by Will Castellanos
 * 2/17/26
 */

using System;
using System.Windows.Forms;
using MinesweeperClassLibrary.Models;

namespace MinesweeperGUI
{
    /// <summary>
    /// Represents the winner form where the player enters a name
    /// after winning the game.
    /// </summary>
    public partial class FrmWinner : Form
    {
        /// <summary>
        /// Stores the final score from the completed game.
        /// </summary>
        private readonly int score;

        /// <summary>
        /// Stores the total game time from the completed game.
        /// </summary>
        private readonly TimeSpan gameTime;

        /// <summary>
        /// Initializes a new instance of the FrmWinner form.
        /// </summary>
        /// <param name="score">The final score from the game.</param>
        /// <param name="gameTime">The total elapsed game time.</param>
        public FrmWinner(int score, TimeSpan gameTime)
        {
            InitializeComponent();

            this.score = score;
            this.gameTime = gameTime;

            LblScore.Text = "Score: " + this.score.ToString();
        }

        /// <summary>
        /// Submits the player name and opens the statistics form.
        /// </summary>
        /// <param name="sender">The control that triggered the event.</param>
        /// <param name="e">The event data.</param>
        private void BtnSubmitClick(object sender, EventArgs e)
        {
            string playerName = TxtName.Text.Trim();

            if (string.IsNullOrWhiteSpace(playerName))
            {
                MessageBox.Show("Please enter your name.");
                return;
            }

            GameStat stat = new GameStat
            {

                Id = 0,
                Name = playerName,
                Score = score,
                GameTime = gameTime,
                DatePlayed = DateTime.Now
            };

            FrmStats statsForm = new FrmStats(stat);
            statsForm.ShowDialog();

            Close();
        }
    }
}