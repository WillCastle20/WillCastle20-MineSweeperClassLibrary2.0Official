using MinesweeperClassLibrary.Models;

namespace MinesweeperGUI
{
    public partial class FrmWinner : Form
    {
        private readonly int _score;
        private readonly TimeSpan _gameTime;

        private int score;
        private TimeSpan gameTime;

        /// <summary>
        /// Constructor for FrmWinner that receives the player's score and time from FrmGame
        /// </summary>
        /// <param name="score"></param>
        /// <param name="gameTime"></param>
        public FrmWinner(int score, TimeSpan gameTime)
        {
            InitializeComponent();

            // Stores the score
            this.score = score;

            // Stores the game time
            this.gameTime = gameTime;

            LblScore.Text = "Score: " + score.ToString();
            //lblTime.Text = "Time: " + gameTime.TotalSeconds.ToString("0") + " sec";
        }



        private void BtnSubmitClickEH(object sender, EventArgs e)
        {
            string playerName = TxtName.Text.Trim();

            if (string.IsNullOrWhiteSpace(playerName))
            {
                MessageBox.Show("Please enter your name.");
                return;
            }

            GameStat stat = new GameStat
            {
                Id = 1,
                Name = playerName,
                Score = _score,
                GameTime = _gameTime,
                DatePlayed = DateTime.Now
            };

            FrmStats statsForm = new FrmStats(stat);
            statsForm.ShowDialog();

            this.Close();
        }
    }
}