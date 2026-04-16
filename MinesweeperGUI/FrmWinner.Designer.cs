/*Darius Drake William Castellanos
 * CST-250
 * Milestone 5
 * Updated by Will Castellanos
 * 2/17/26
 */

namespace MinesweeperGUI
{
    partial class FrmWinner
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
            LblMessage = new Label();
            LblScore = new Label();
            TxtName = new TextBox();
            BtnSubmit = new Button();
            SuspendLayout();
            // 
            // LblMessage
            // 
            LblMessage.AutoSize = true;
            LblMessage.Location = new Point(108, 72);
            LblMessage.Margin = new Padding(4, 0, 4, 0);
            LblMessage.Name = "LblMessage";
            LblMessage.Size = new Size(473, 32);
            LblMessage.TabIndex = 0;
            LblMessage.Text = "Congratulations, you win. Enter your name.";
            // 
            // LblScore
            // 
            LblScore.AutoSize = true;
            LblScore.Location = new Point(108, 147);
            LblScore.Margin = new Padding(4, 0, 4, 0);
            LblScore.Name = "LblScore";
            LblScore.Size = new Size(78, 32);
            LblScore.TabIndex = 1;
            LblScore.Text = "Score:";
            // 
            // TxtName
            // 
            TxtName.Location = new Point(108, 244);
            TxtName.Margin = new Padding(4, 4, 4, 4);
            TxtName.Name = "TxtName";
            TxtName.Size = new Size(194, 39);
            TxtName.TabIndex = 2;
            // 
            // BtnSubmit
            // 
            BtnSubmit.Location = new Point(108, 369);
            BtnSubmit.Margin = new Padding(4, 4, 4, 4);
            BtnSubmit.Name = "BtnSubmit";
            BtnSubmit.Size = new Size(146, 44);
            BtnSubmit.TabIndex = 3;
            BtnSubmit.Text = "OK";
            BtnSubmit.UseVisualStyleBackColor = true;
            BtnSubmit.Click += BtnSubmitClick;
            // 
            // FrmWinner
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(2331, 672);
            Controls.Add(BtnSubmit);
            Controls.Add(TxtName);
            Controls.Add(LblScore);
            Controls.Add(LblMessage);
            Margin = new Padding(4, 4, 4, 4);
            Name = "FrmWinner";
            Text = "Winner";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label LblMessage;
        private Label LblScore;
        private TextBox TxtName;
        private Button BtnSubmit;
    }
}