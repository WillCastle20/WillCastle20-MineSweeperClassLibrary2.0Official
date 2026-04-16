/*Darius Drake William Castellanos
 * CST-250
 * Milestone 5
 * Updated by Will Castellanos
 * 2/17/26
 */

namespace MinesweeperGUI
{
    partial class FrmGame
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Cleans up any resources being used.
        /// </summary>
        /// <param name="disposing">True if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }

            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support.
        /// </summary>
        private void InitializeComponent()
        {
            PanelBoard = new Panel();
            SuspendLayout();
            // 
            // PanelBoard
            // 
            PanelBoard.Location = new Point(896, 327);
            PanelBoard.Margin = new Padding(4, 5, 4, 5);
            PanelBoard.Name = "PanelBoard";
            PanelBoard.Size = new Size(806, 765);
            PanelBoard.TabIndex = 0;
            // 
            // FrmGame
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1924, 1050);
            Controls.Add(PanelBoard);
            Margin = new Padding(4, 5, 4, 5);
            Name = "FrmGame";
            Text = "Minesweeper";
            ResumeLayout(false);
        }

        #endregion

        private Panel PanelBoard;
    }
}