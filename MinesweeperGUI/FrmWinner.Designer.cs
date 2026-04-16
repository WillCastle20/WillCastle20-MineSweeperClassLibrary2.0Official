namespace MinesweeperGUI
{
    partial class FrmWinner
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
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
            LblMessage.Location = new Point(83, 56);
            LblMessage.Name = "LblMessage";
            LblMessage.Size = new Size(352, 25);
            LblMessage.TabIndex = 0;
            LblMessage.Text = "Congratulations, you win. Enter your name.";
            // 
            // LblScore
            // 
            LblScore.AutoSize = true;
            LblScore.Location = new Point(83, 115);
            LblScore.Name = "LblScore";
            LblScore.Size = new Size(60, 25);
            LblScore.TabIndex = 1;
            LblScore.Text = "Score:";
            // 
            // TxtName
            // 
            TxtName.Location = new Point(83, 191);
            TxtName.Name = "TxtName";
            TxtName.Size = new Size(150, 31);
            TxtName.TabIndex = 2;
            // 
            // BtnSubmit
            // 
            BtnSubmit.Location = new Point(83, 288);
            BtnSubmit.Name = "BtnSubmit";
            BtnSubmit.Size = new Size(112, 34);
            BtnSubmit.TabIndex = 3;
            BtnSubmit.Text = "OK";
            BtnSubmit.UseVisualStyleBackColor = true;
            BtnSubmit.Click += BtnSubmitClickEH;
            // 
            // FrmWinner
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(BtnSubmit);
            Controls.Add(TxtName);
            Controls.Add(LblScore);
            Controls.Add(LblMessage);
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
