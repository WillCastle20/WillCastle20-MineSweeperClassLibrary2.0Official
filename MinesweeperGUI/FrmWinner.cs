using MinesweeperClassLibrary.Models;

namespace MinesweeperGUI
{
    public partial class FrmWinner : Form
    {
        private readonly int _score;
        private readonly TimeSpan _gameTime;

        /// <summary>
        /// Constructor for FrmWinner that receives the player's score and game time.
        /// </summary>
        /// <param name="score">Final score from the game.</param>
        /// <param name="gameTime">Elapsed game time.</param>
        public FrmWinner(int score, TimeSpan gameTime)
        {
            InitializeComponent();

            _score = score;
            _gameTime = gameTime;

            LblScore.Text = "Score: " + _score.ToString();
        }

        /// <summary>
        /// Submits the winner name and opens the stats form.
        /// </summary>
        /// <param name="sender">Button sender.</param>
        /// <param name="e">Event arguments.</param>
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