using MinesweeperClassLibrary.Models;

namespace MinesweeperGUI
{
    public partial class FrmWinner : Form
    {
        private readonly int _score;
        private readonly TimeSpan _gameTime;

        public FrmWinner()
        {
            InitializeComponent();
            _score = 0;
            _gameTime = TimeSpan.Zero;
            LblScore.Text = $"Score: {_score}";
        }

        public FrmWinner(int score, TimeSpan gameTime)
        {
            InitializeComponent();
            _score = score;
            _gameTime = gameTime;
            LblScore.Text = $"Score: {_score}";
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