/*Darius Drake
 * CST-250
 * Milestone 4
 * Darius Drake
 * 3/31/26
 */

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MinesweeperGUI
{
    public partial class FrmStart : Form
    {
        public FrmStart()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Start gamee difficulty 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnStartGame_ClickEH(object sender, EventArgs e)
{
    int size = int.TryParse(txtSize.Text, out int result) ? result : 5;

    string difficulty = cmbDifficulty.SelectedItem?.ToString() ?? "Easy";

    int difficultyLevel = 1;

    if (difficulty == "Easy")
        difficultyLevel = 1;
    else if (difficulty == "Medium")
        difficultyLevel = 2;
    else
        difficultyLevel = 3;

    FrmGame gameForm = new FrmGame(size, difficultyLevel);
    gameForm.Show();
    this.Hide();
}

        /// <summary>
        /// Loads the dropdown
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void StartForm_Load(object sender, EventArgs e)
        {
            cmbDifficulty.SelectedIndex = 0; // sets to Easy
        }

    }
}
