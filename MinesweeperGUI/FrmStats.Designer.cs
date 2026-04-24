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
            MenuStats.Padding = new Padding(8, 3, 0, 3);
            MenuStats.Size = new Size(2385, 42);
            MenuStats.TabIndex = 0;
            MenuStats.Text = "MenuStats";
            // 
            // MnuFile
            // 
            MnuFile.DropDownItems.AddRange(new ToolStripItem[] { MnuSave, MnuLoad, MnuExit });
            MnuFile.Name = "MnuFile";
            MnuFile.Size = new Size(71, 36);
            MnuFile.Text = "File";
            // 
            // MnuSave
            // 
            MnuSave.Name = "MnuSave";
            MnuSave.Size = new Size(198, 44);
            MnuSave.Text = "Save";
            MnuSave.Click += MnuSaveClick;
            // 
            // MnuLoad
            // 
            MnuLoad.Name = "MnuLoad";
            MnuLoad.Size = new Size(198, 44);
            MnuLoad.Text = "Load";
            MnuLoad.Click += MnuLoadClick;
            // 
            // MnuExit
            // 
            MnuExit.Name = "MnuExit";
            MnuExit.Size = new Size(198, 44);
            MnuExit.Text = "Exit";
            MnuExit.Click += MnuExitClick;
            // 
            // MnuSort
            // 
            MnuSort.DropDownItems.AddRange(new ToolStripItem[] { MnuSortByName, MnuSortByScore, MnuSortByDate });
            MnuSort.Name = "MnuSort";
            MnuSort.Size = new Size(77, 36);
            MnuSort.Text = "Sort";
            // 
            // MnuSortByName
            // 
            MnuSortByName.Name = "MnuSortByName";
            MnuSortByName.Size = new Size(244, 44);
            MnuSortByName.Text = "By Name";
            MnuSortByName.Click += MnuSortByNameClick;
            // 
            // MnuSortByScore
            // 
            MnuSortByScore.Name = "MnuSortByScore";
            MnuSortByScore.Size = new Size(244, 44);
            MnuSortByScore.Text = "By Score";
            MnuSortByScore.Click += MnuSortByScoreClick;
            // 
            // MnuSortByDate
            // 
            MnuSortByDate.Name = "MnuSortByDate";
            MnuSortByDate.Size = new Size(244, 44);
            MnuSortByDate.Text = "By Date";
            MnuSortByDate.Click += MnuSortByDateClick;
            // 
            // DgvStats
            // 
            DgvStats.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            DgvStats.Location = new Point(107, 95);
            DgvStats.Margin = new Padding(4, 4, 4, 4);
            DgvStats.Name = "DgvStats";
            DgvStats.RowHeadersWidth = 62;
            DgvStats.Size = new Size(957, 288);
            DgvStats.TabIndex = 1;
            // 
            // BtnClose
            // 
            BtnClose.Location = new Point(117, 456);
            BtnClose.Margin = new Padding(4, 4, 4, 4);
            BtnClose.Name = "BtnClose";
            BtnClose.Size = new Size(146, 44);
            BtnClose.TabIndex = 2;
            BtnClose.Text = "Close";
            BtnClose.UseVisualStyleBackColor = true;
            BtnClose.Click += BtnCloseClick;
            // 
            // FrmStats
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(2385, 1170);
            Controls.Add(BtnClose);
            Controls.Add(DgvStats);
            Controls.Add(MenuStats);
            MainMenuStrip = MenuStats;
            Margin = new Padding(4, 4, 4, 4);
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
    }
}