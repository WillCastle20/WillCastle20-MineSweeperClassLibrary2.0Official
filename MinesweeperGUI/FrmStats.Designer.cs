namespace MinesweeperGUI
{
    partial class FrmStats
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
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
            MenuStats.Size = new Size(800, 33);
            MenuStats.TabIndex = 0;
            MenuStats.Text = "menuStrip1";
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
            MnuSave.Size = new Size(270, 34);
            MnuSave.Text = "Save";
            MnuSave.Click += MnuSaveClickEH;
            // 
            // MnuLoad
            // 
            MnuLoad.Name = "MnuLoad";
            MnuLoad.Size = new Size(270, 34);
            MnuLoad.Text = "Load";
            MnuLoad.Click += MnuLoadClickEH;
            // 
            // MnuExit
            // 
            MnuExit.Name = "MnuExit";
            MnuExit.Size = new Size(270, 34);
            MnuExit.Text = "Exit";
            MnuExit.Click += MnuExitClickEH;
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
            MnuSortByName.Size = new Size(270, 34);
            MnuSortByName.Text = "By Name";
            MnuSortByName.Click += MnuSortByNameClickEH;
            // 
            // MnuSortByScore
            // 
            MnuSortByScore.Name = "MnuSortByScore";
            MnuSortByScore.Size = new Size(270, 34);
            MnuSortByScore.Text = "By Score";
            MnuSortByScore.Click += MnuSortByScoreClickEH;
            // 
            // MnuSortByDate
            // 
            MnuSortByDate.Name = "MnuSortByDate";
            MnuSortByDate.Size = new Size(270, 34);
            MnuSortByDate.Text = "By Date";
            MnuSortByDate.Click += MnuSortByDateClickEH;
            // 
            // DgvStats
            // 
            DgvStats.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            DgvStats.Location = new Point(82, 74);
            DgvStats.Name = "DgvStats";
            DgvStats.RowHeadersWidth = 62;
            DgvStats.Size = new Size(360, 225);
            DgvStats.TabIndex = 1;
            // 
            // BtnClose
            // 
            BtnClose.Location = new Point(90, 356);
            BtnClose.Name = "BtnClose";
            BtnClose.Size = new Size(112, 34);
            BtnClose.TabIndex = 2;
            BtnClose.Text = "Close";
            BtnClose.UseVisualStyleBackColor = true;
            BtnClose.Click += BtnCloseClickEH;
            // 
            // FrmStats
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
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
    }
}