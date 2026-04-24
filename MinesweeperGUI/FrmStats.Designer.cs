/*Darius Drake William Castellanos
 * CST-250
 * Milestone 5
 * Updated by Will Castellanos
 * 2/17/26
 */

namespace MinesweeperGUI
{
    partial class FrmStats
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
            MenuStats = new MenuStrip();
            MnuFile = new ToolStripMenuItem();
            MnuSave = new ToolStripMenuItem();
            MnuLoad = new ToolStripMenuItem();
            MnuExit = new ToolStripMenuItem();
            MnuSort = new ToolStripMenuItem();
            MnuSortByName = new ToolStripMenuItem();
            MnuSortByScore = new ToolStripMenuItem();
            MnuSortByDate = new ToolStripMenuItem();
            DgvStats = new DataGridView();
            BtnClose = new Button();
            LblAverageTime = new Label();
            LblAverageScore = new Label();
            MenuStats.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)DgvStats).BeginInit();
            SuspendLayout();
            // 
            // MenuStats
            // 
            MenuStats.ImageScalingSize = new Size(24, 24);
            MenuStats.Items.AddRange(new ToolStripItem[] { MnuFile, MnuSort });
            MenuStats.Location = new Point(0, 0);
            MenuStats.Name = "MenuStats";
            MenuStats.Size = new Size(1480, 33);
            MenuStats.TabIndex = 0;
            MenuStats.Text = "MenuStats";
            // 
            // MnuFile
            // 
            MnuFile.DropDownItems.AddRange(new ToolStripItem[] { MnuSave, MnuLoad, MnuExit });
            MnuFile.Name = "MnuFile";
            MnuFile.Size = new Size(54, 29);
            MnuFile.Text = "File";
            // 
            // MnuSave
            // 
            MnuSave.Name = "MnuSave";
            MnuSave.Size = new Size(153, 34);
            MnuSave.Text = "Save";
            MnuSave.Click += MnuSaveClick;
            // 
            // MnuLoad
            // 
            MnuLoad.Name = "MnuLoad";
            MnuLoad.Size = new Size(153, 34);
            MnuLoad.Text = "Load";
            MnuLoad.Click += MnuLoadClick;
            // 
            // MnuExit
            // 
            MnuExit.Name = "MnuExit";
            MnuExit.Size = new Size(153, 34);
            MnuExit.Text = "Exit";
            MnuExit.Click += MnuExitClick;
            // 
            // MnuSort
            // 
            MnuSort.DropDownItems.AddRange(new ToolStripItem[] { MnuSortByName, MnuSortByScore, MnuSortByDate });
            MnuSort.Name = "MnuSort";
            MnuSort.Size = new Size(61, 29);
            MnuSort.Text = "Sort";
            // 
            // MnuSortByName
            // 
            MnuSortByName.Name = "MnuSortByName";
            MnuSortByName.Size = new Size(185, 34);
            MnuSortByName.Text = "By Name";
            MnuSortByName.Click += MnuSortByNameClick;
            // 
            // MnuSortByScore
            // 
            MnuSortByScore.Name = "MnuSortByScore";
            MnuSortByScore.Size = new Size(185, 34);
            MnuSortByScore.Text = "By Score";
            MnuSortByScore.Click += MnuSortByScoreClick;
            // 
            // MnuSortByDate
            // 
            MnuSortByDate.Name = "MnuSortByDate";
            MnuSortByDate.Size = new Size(185, 34);
            MnuSortByDate.Text = "By Date";
            MnuSortByDate.Click += MnuSortByDateClick;
            // 
            // DgvStats
            // 
            DgvStats.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            DgvStats.Location = new Point(82, 74);
            DgvStats.Name = "DgvStats";
            DgvStats.RowHeadersWidth = 62;
            DgvStats.Size = new Size(736, 225);
            DgvStats.TabIndex = 1;
            // 
            // BtnClose
            // 
            BtnClose.Location = new Point(91, 429);
            BtnClose.Name = "BtnClose";
            BtnClose.Size = new Size(112, 34);
            BtnClose.TabIndex = 2;
            BtnClose.Text = "Close";
            BtnClose.UseVisualStyleBackColor = true;
            BtnClose.Click += BtnCloseClick;
            // 
            // LblAverageTime
            // 
            LblAverageTime.AutoSize = true;
            LblAverageTime.Location = new Point(110, 349);
            LblAverageTime.Name = "LblAverageTime";
            LblAverageTime.Size = new Size(277, 25);
            LblAverageTime.TabIndex = 3;
            LblAverageTime.Text = "Average Time Per Game: 00:00:00";
            // 
            // LblAverageScore
            // 
            LblAverageScore.AutoSize = true;
            LblAverageScore.Location = new Point(468, 349);
            LblAverageScore.Name = "LblAverageScore";
            LblAverageScore.Size = new Size(149, 25);
            LblAverageScore.TabIndex = 4;
            LblAverageScore.Text = "Average Points: 0";
            // 
            // FrmStats
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1480, 820);
            Controls.Add(LblAverageScore);
            Controls.Add(LblAverageTime);
            Controls.Add(BtnClose);
            Controls.Add(DgvStats);
            Controls.Add(MenuStats);
            MainMenuStrip = MenuStats;
            Name = "FrmStats";
            Text = "FrmStats";
            MenuStats.ResumeLayout(false);
            MenuStats.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)DgvStats).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private MenuStrip MenuStats;
        private ToolStripMenuItem MnuFile;
        private DataGridView DgvStats;
        private Button BtnClose;
        private ToolStripMenuItem MnuSave;
        private ToolStripMenuItem MnuLoad;
        private ToolStripMenuItem MnuExit;
        private ToolStripMenuItem MnuSort;
        private ToolStripMenuItem MnuSortByName;
        private ToolStripMenuItem MnuSortByScore;
        private ToolStripMenuItem MnuSortByDate;
        private Label LblAverageTime;
        private Label LblAverageScore;
    }
}