/*Darius Drake William Castellanos
 * CST-250
 * Milestone 5
 * Updated by Will Castellanos
 * 2/17/26
 */

using System;
using System.Windows.Forms;

namespace MinesweeperGUI
{
    /// <summary>
    /// Represents the start form where the player selects the board size
    /// and difficulty before beginning the game.
    /// </summary>
    public partial class FrmStart : Form
    {
        /// <summary>
        /// Initializes a new instance of the FrmStart form.
        /// </summary>
        public FrmStart()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Starts a new game using the selected board size and difficulty.
        /// </summary>
        /// <param name="sender">The control that triggered the event.</param>
        /// <param name="e">The event data.</param>
        private void BtnStartGameClick(object sender, EventArgs e)
        {
            int size = int.TryParse(TxtSize.Text, out int result) ? result : 5;
            string difficulty = CmbDifficulty.SelectedItem?.ToString() ?? "Easy";

            int difficultyLevel = 1;

            if (difficulty == "Easy")
            {
                difficultyLevel = 1;
            }
            else if (difficulty == "Medium")
            {
                difficultyLevel = 2;
            }
            else
            {
                difficultyLevel = 3;
            }

            FrmGame gameForm = new FrmGame(size, difficultyLevel);
            gameForm.Show();
            Hide();
        }

        /// <summary>
        /// Loads the default difficulty option when the form starts.
        /// </summary>
        /// <param name="sender">The control that triggered the event.</param>
        /// <param name="e">The event data.</param>
        private void FrmStartLoad(object sender, EventArgs e)
        {
            CmbDifficulty.SelectedIndex = 0;
        }
    }
}