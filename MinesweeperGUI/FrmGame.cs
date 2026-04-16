/*Darius Drake
 * CST-250
 * Milestone 4
 * Darius Drake
 * 3/31/26
 */


using System;
using System.Drawing;
using System.Windows.Forms;
using MinesweeperClassLibrary.Models;
using MinesweeperClassLibrary.BusinessLogicLayer;
using System.IO;
using Timer = System.Windows.Forms.Timer;


namespace MinesweeperGUI
{
    public partial class FrmGame : Form
    {
        int size;
        int difficultyLevel;
        private int gridSize;
        private Button[,]? buttons;

        private BoardModel board;
        private BoardLogic logic;

        private Image hiddenTileImage;
        private Image revealedTileImage;
        private Image bombImage;
        private Image flagImage;
        private Image[] numberImages;
        private DateTime startTime;
        private Timer gameTimer = new Timer();
       

        /// <summary>
        /// Wires the difficulty level
        /// </summary>
        /// <param name="size"></param>
        /// <param name="difficultyLevel"></param>
        public FrmGame(int size, int difficultyLevel)
        {
            InitializeComponent();
            gameTimer = new Timer();
            gameTimer.Interval = 1000;

            startTime = DateTime.Now;
            gameTimer.Start();

            this.size = size;
            this.difficultyLevel = difficultyLevel;

            gridSize = size;

            board = new BoardModel(gridSize);
            logic = new BoardLogic();

            string imagePath = Path.Combine(Application.StartupPath, "Images");

            hiddenTileImage = Image.FromFile(Path.Combine(imagePath, "TileHidden.png"));
            revealedTileImage = Image.FromFile(Path.Combine(imagePath, "TileRevealed.png"));
            bombImage = Image.FromFile(Path.Combine(imagePath, "Bomb.png"));
            flagImage = Image.FromFile(Path.Combine(imagePath, "Flag.png"));

            numberImages = new Image[9];
            for (int i = 1; i <= 8; i++)
            {
                numberImages[i] = Image.FromFile(Path.Combine(imagePath, $"{i}.png"));
            }

            //THIS is where difficulty will matter
            logic.SetUpBombs(board, difficultyLevel);
            logic.CountBombsNearby(board);

            CreateGrid();
            UpdateBoardUI();
            startTime = DateTime.Now;

            gameTimer.Interval = 1000; // 1 second
            gameTimer.Tick += GameTimer_Tick;
            gameTimer.Start();
        }

        /// <summary>
        /// Creates the grid of buttons
        /// </summary>
        private void CreateGrid()
        {
            buttons = new Button[gridSize, gridSize];

            int buttonSize = 40;

            panelBoard.Controls.Clear();

            for (int row = 0; row < gridSize; row++)
            {
                for (int col = 0; col < gridSize; col++)
                {
                    Button btn = new Button();

                    btn.Width = buttonSize;
                    btn.Height = buttonSize;
                    btn.Left = col * buttonSize;
                    btn.Top = row * buttonSize;

                    btn.Tag = new Point(row, col);

                    btn.MouseUp += Button_MouseUp;

                    panelBoard.Controls.Add(btn);
                    buttons[row, col] = btn;

                    btn.BackgroundImageLayout = ImageLayout.Stretch;
                    btn.BackgroundImage = hiddenTileImage;
                    btn.Text = "";
                }
            }

            panelBoard.Width = gridSize * buttonSize;
            panelBoard.Height = gridSize * buttonSize;
        }

        /// <summary>
        /// Handles button click and visits the selected cell
        /// </summary>
        private void Button_MouseUp(object? sender, MouseEventArgs e)
        {
            Button btn = (Button)sender;
            Point p = (Point)btn.Tag;

            int row = p.X;
            int col = p.Y;

            if (e.Button == MouseButtons.Right)
            {
                logic.FlagCell(board, row, col);
            }
            else if (e.Button == MouseButtons.Left)
            {
                logic.VisitCell(board, row, col);
            }

            UpdateBoardUI();
            CheckGameState();
            gameTimer.Stop();
            gameTimer.Start();
        }

        /// <summary>
        /// Updates all buttons based on the board state
        /// </summary>
        private void UpdateBoardUI()
        {
            for (int row = 0; row < gridSize; row++)
            {
                for (int col = 0; col < gridSize; col++)
                {
                    CellModel cell = board.Cells[row, col];
                    Button btn = buttons[row, col];

                    btn.Text = "";
                    btn.ForeColor = Color.Black;
                    btn.BackgroundImageLayout = ImageLayout.Stretch;

                    if (cell.IsVisited)
                    {
                        btn.Enabled = false;

                        if (cell.IsBomb)
                        {
                            btn.BackgroundImage = bombImage;
                        }
                        else if (cell.NumberOfBombNeighbors > 0)
                        {
                            btn.BackgroundImage = numberImages[cell.NumberOfBombNeighbors];
                        }
                        else
                        {
                            btn.BackgroundImage = revealedTileImage;
                        }
                    }
                    else if (cell.IsFlagged)
                    {
                        btn.BackgroundImage = flagImage;
                        btn.Enabled = true;
                    }
                    else
                    {
                        btn.BackgroundImage = hiddenTileImage;
                        btn.Enabled = true;
                    }
                }
            }
        }

        /// <summary>
        /// Checks whether the player won, lost, or is still playing
        /// </summary>
        private void CheckGameState()
        {
            GameState state = logic.DetermineGameState(board);

            if (state == GameState.Lost)
            {
                RevealBombs();
                MessageBox.Show("Game Over! You hit a bomb.");
                DisableBoard();
            }
            else if (state == GameState.Won)
            {
                MessageBox.Show("You win!");

                int score = CalculateScore();
                TimeSpan gameTime = DateTime.Now - startTime;

                FrmWinner winnerForm = new FrmWinner(score, gameTime);
                winnerForm.ShowDialog();

                DisableBoard();
            }
        }

        /// <summary>
        /// Reveals all bomb locations
        /// </summary>
        private void RevealBombs()
        {
            for (int row = 0; row < gridSize; row++)
            {
                for (int col = 0; col < gridSize; col++)
                {
                    if (board.Cells[row, col].IsBomb)
                    {
                        buttons[row, col].BackgroundImage = bombImage;
                        buttons[row, col].BackgroundImageLayout = ImageLayout.Stretch;
                        buttons[row, col].Text = "";
                    }
                }
            }
        }

        /// <summary>
        /// Disables all buttons after game ends
        /// </summary>
        private void DisableBoard()
        {
            for (int row = 0; row < gridSize; row++)
            {
                for (int col = 0; col < gridSize; col++)
                {
                    buttons[row, col].Enabled = false;
                }
            }
        }

        /// <summary>
        /// GameTimer
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void GameTimer_Tick(object? sender, EventArgs e)
        {
            
        }

        /// <summary>
        /// Calculates the score and adds diffuclty level for bonus
        /// </summary>
        /// <returns></returns>
        private int CalculateScore()
        {
            int baseScore = 1000;
            int difficultyBonus = difficultyLevel * 100;

            TimeSpan gameTime = DateTime.Now - startTime;
            int timePenalty = (int)gameTime.TotalSeconds;

            return baseScore + difficultyBonus - timePenalty;
        }

    }
}


