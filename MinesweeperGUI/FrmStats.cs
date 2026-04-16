using MinesweeperClassLibrary.Models;

namespace MinesweeperGUI
{
    public partial class FrmStats : Form
    {
        private List<GameStat> _gameStats = new List<GameStat>();

        public FrmStats()
        {
            InitializeComponent();
            RefreshGrid();
        }

        public FrmStats(GameStat stat)
        {
            InitializeComponent();
            _gameStats.Add(stat);
            RefreshGrid();
        }

        private void RefreshGrid()
        {
            DgvStats.DataSource = null;
            DgvStats.DataSource = _gameStats.Select(stat => new
            {
                stat.Id,
                stat.Name,
                stat.Score,
                GameTime = stat.GameTime.ToString(@"hh\:mm\:ss"),
                Date = stat.DatePlayed
            }).ToList();
        }

        private void MnuSaveClickEH(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Text Files (*.txt)|*.txt";
            saveFileDialog.Title = "Save High Scores";

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                using StreamWriter writer = new StreamWriter(saveFileDialog.FileName);

                foreach (GameStat stat in _gameStats)
                {
                    writer.WriteLine($"{stat.Id},{stat.Name},{stat.Score},{stat.GameTime},{stat.DatePlayed}");
                }

                MessageBox.Show("Scores saved successfully.");
            }
        }

        private void MnuLoadClickEH(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Text Files (*.txt)|*.txt";
            openFileDialog.Title = "Load High Scores";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                _gameStats.Clear();

                string[] lines = File.ReadAllLines(openFileDialog.FileName);

                foreach (string line in lines)
                {
                    string[] parts = line.Split(',');

                    if (parts.Length >= 5)
                    {
                        GameStat stat = new GameStat
                        {
                            Id = int.Parse(parts[0]),
                            Name = parts[1],
                            Score = int.Parse(parts[2]),
                            GameTime = TimeSpan.Parse(parts[3]),
                            DatePlayed = DateTime.Parse(parts[4])
                        };

                        _gameStats.Add(stat);
                    }
                }

                RefreshGrid();
                MessageBox.Show("Scores loaded successfully.");
            }
        }

        private void MnuExitClickEH(object sender, EventArgs e)
        {
            this.Close();
        }

        private void MnuSortByNameClickEH(object sender, EventArgs e)
        {
            _gameStats = _gameStats.OrderBy(stat => stat.Name).ToList();
            RefreshGrid();
        }

        private void MnuSortByScoreClickEH(object sender, EventArgs e)
        {
            _gameStats = _gameStats.OrderByDescending(stat => stat.Score).ToList();
            RefreshGrid();
        }

        private void MnuSortByDateClickEH(object sender, EventArgs e)
        {
            _gameStats = _gameStats.OrderByDescending(stat => stat.DatePlayed).ToList();
            RefreshGrid();
        }

        private void BtnCloseClickEH(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
