namespace MinesweeperGUI
{
    partial class FrmGame
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
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
            panelBoard = new Panel();
            SuspendLayout();
            // 
            // panelBoard
            // 
            panelBoard.Location = new Point(896, 327);
            panelBoard.Margin = new Padding(4, 5, 4, 5);
            panelBoard.Name = "panelBoard";
            panelBoard.Size = new Size(806, 765);
            panelBoard.TabIndex = 0;
            // 
            // FrmGame
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1924, 1050);
            Controls.Add(panelBoard);
            Margin = new Padding(4, 5, 4, 5);
            Name = "FrmGame";
            Text = "Minesweeper";
            ResumeLayout(false);
        }

        #endregion

        private Panel panelBoard;
    }
}