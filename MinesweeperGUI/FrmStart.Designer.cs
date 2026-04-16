/*Darius Drake William Castellanos
 * CST-250
 * Milestone 5
 * Updated by Will Castellanos
 * 2/17/26
 */

namespace MinesweeperGUI
{
    partial class FrmStart
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
            LblBoardSize = new Label();
            TxtSize = new TextBox();
            BtnStart = new Button();
            CmbDifficulty = new ComboBox();
            LblDifficulty = new Label();
            SuspendLayout();
            // 
            // LblBoardSize
            // 
            LblBoardSize.AutoSize = true;
            LblBoardSize.Location = new Point(954, 232);
            LblBoardSize.Margin = new Padding(5, 0, 5, 0);
            LblBoardSize.Name = "LblBoardSize";
            LblBoardSize.Size = new Size(95, 25);
            LblBoardSize.TabIndex = 0;
            LblBoardSize.Text = "Board Size";
            // 
            // TxtSize
            // 
            TxtSize.Location = new Point(931, 308);
            TxtSize.Margin = new Padding(5, 5, 5, 5);
            TxtSize.Name = "TxtSize";
            TxtSize.Size = new Size(141, 31);
            TxtSize.TabIndex = 1;
            // 
            // BtnStart
            // 
            BtnStart.Location = new Point(942, 382);
            BtnStart.Margin = new Padding(5, 5, 5, 5);
            BtnStart.Name = "BtnStart";
            BtnStart.Size = new Size(107, 38);
            BtnStart.TabIndex = 2;
            BtnStart.Text = "Start Game";
            BtnStart.UseVisualStyleBackColor = true;
            BtnStart.Click += BtnStartGameClick;
            // 
            // CmbDifficulty
            // 
            CmbDifficulty.DropDownStyle = ComboBoxStyle.DropDownList;
            CmbDifficulty.FormattingEnabled = true;
            CmbDifficulty.Items.AddRange(new object[] { "Easy", "Medium", "Hard" });
            CmbDifficulty.Location = new Point(422, 329);
            CmbDifficulty.Margin = new Padding(2, 2, 2, 2);
            CmbDifficulty.Name = "CmbDifficulty";
            CmbDifficulty.Size = new Size(187, 33);
            CmbDifficulty.TabIndex = 3;
            // 
            // LblDifficulty
            // 
            LblDifficulty.AutoSize = true;
            LblDifficulty.Location = new Point(422, 214);
            LblDifficulty.Margin = new Padding(2, 0, 2, 0);
            LblDifficulty.Name = "LblDifficulty";
            LblDifficulty.Size = new Size(82, 25);
            LblDifficulty.TabIndex = 4;
            LblDifficulty.Text = "Difficulty";
            // 
            // FrmStart
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1480, 820);
            Controls.Add(LblDifficulty);
            Controls.Add(CmbDifficulty);
            Controls.Add(BtnStart);
            Controls.Add(TxtSize);
            Controls.Add(LblBoardSize);
            Margin = new Padding(5, 5, 5, 5);
            Name = "FrmStart";
            Text = "Start Game";
            Load += FrmStartLoad;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label LblBoardSize;
        private TextBox TxtSize;
        private Button BtnStart;
        private ComboBox CmbDifficulty;
        private Label LblDifficulty;
    }
}