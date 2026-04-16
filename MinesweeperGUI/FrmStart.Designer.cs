/*
 * William Castellanos
 * CST-250
 * Milestone 4
 * 4/1/2026
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
            lblBoardSize = new Label();
            txtSize = new TextBox();
            btnStart = new Button();
            cmbDifficulty = new ComboBox();
            label1 = new Label();
            SuspendLayout();
            // 
            // lblBoardSize
            // 
            lblBoardSize.AutoSize = true;
            lblBoardSize.Location = new Point(954, 232);
            lblBoardSize.Margin = new Padding(5, 0, 5, 0);
            lblBoardSize.Name = "lblBoardSize";
            lblBoardSize.Size = new Size(95, 25);
            lblBoardSize.TabIndex = 0;
            lblBoardSize.Text = "Board Size";
            // 
            // txtSize
            // 
            txtSize.Location = new Point(931, 308);
            txtSize.Margin = new Padding(5, 5, 5, 5);
            txtSize.Name = "txtSize";
            txtSize.Size = new Size(141, 31);
            txtSize.TabIndex = 1;
            // 
            // btnStart
            // 
            btnStart.Location = new Point(942, 382);
            btnStart.Margin = new Padding(5, 5, 5, 5);
            btnStart.Name = "btnStart";
            btnStart.Size = new Size(107, 38);
            btnStart.TabIndex = 2;
            btnStart.Text = "Start Game";
            btnStart.UseVisualStyleBackColor = true;
            btnStart.Click += btnStartGame_ClickEH;
            // 
            // cmbDifficulty
            // 
            cmbDifficulty.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbDifficulty.FormattingEnabled = true;
            cmbDifficulty.Items.AddRange(new object[] { "Easy", "Medium", "Hard" });
            cmbDifficulty.Location = new Point(422, 329);
            cmbDifficulty.Margin = new Padding(2, 2, 2, 2);
            cmbDifficulty.Name = "cmbDifficulty";
            cmbDifficulty.Size = new Size(187, 33);
            cmbDifficulty.TabIndex = 3;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(422, 214);
            label1.Margin = new Padding(2, 0, 2, 0);
            label1.Name = "label1";
            label1.Size = new Size(82, 25);
            label1.TabIndex = 4;
            label1.Text = "Difficulty";
            // 
            // FrmStart
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1480, 820);
            Controls.Add(label1);
            Controls.Add(cmbDifficulty);
            Controls.Add(btnStart);
            Controls.Add(txtSize);
            Controls.Add(lblBoardSize);
            Margin = new Padding(5, 5, 5, 5);
            Name = "FrmStart";
            Text = "Start Game";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblBoardSize;
        private TextBox txtSize;
        private Button btnStart;
        private ComboBox cmbDifficulty;
        private Label label1;
    }
}