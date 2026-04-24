/*Darius Drake William Castellanos
 * CST-250
 * Milestone 5
 * Updated by Will Castellanos
 * 2/17/26
 */

using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using MinesweeperClassLibrary.BusinessLogicLayer;
using MinesweeperClassLibrary.Models;
using Timer = System.Windows.Forms.Timer;

namespace MinesweeperGUI
{
    /// <summary>
    /// Represents the main game form where the player interacts with the Minesweeper board.
    /// </summary>
    public partial class FrmGame : Form
    {
        /// <summary>
        /// Stores the selected board size.
        /// </summary>
        private int size;

        /// <summary>
        /// Stores the selected difficulty level.
        /// </summary>
        private int difficultyLevel;

        /// <summary>
        /// Stores the current grid size.
        /// </summary>
        private int gridSize;

        /// <summary>
        /// Stores the button grid used to display the game board.
        /// </summary>
        private Button[,]? buttons;

        /// <summary>
        /// Stores the board model for the current game.
        /// </summary>
        private BoardModel board;

        /// <summary>
        /// Stores the business logic object for the game.
        /// </summary>
        private BoardLogic logic;

        /// <summary>
        /// Stores the image used for hidden tiles.
        /// </summary>
        private Image hiddenTileImage;

        /// <summary>
        /// Stores the image used for revealed empty tiles.
        /// </summary>
        private Image revealedTileImage;

        /// <summary>
        /// Stores the image used for bomb tiles.
        /// </summary>
        private Image bombImage;

        /// <summary>
        /// Stores the image used for flagged tiles.
        /// </summary>
        private Image flagImage;

        /// <summary>
        /// Stores the images used for numbered tiles.
        /// </summary>
        private Image[] numberImages;

        /// <summary>
        /// Stores the time when the game started.
        /// </summary>
        private DateTime startTime;

        /// <summary>
        /// Stores the game timer.
        /// </summary>
        private Timer gameTimer = new Timer();

        /// <summary>
        /// Initializes a new instance of the FrmGame form using the selected size and difficulty.
        /// </summary>
        /// <param name="size">The selected board size.</param>
        /// <param name="difficultyLevel">The selected difficulty level.</param>
        public FrmGame(int size, int difficultyLevel)
        {
            InitializeComponent();
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
            // Initialize board with bombs, rewards, neighbor counts, then build and display the UI
            logic.SetUpBombs(board, difficultyLevel);
            logic.SetUpRewards(board);
            logic.CountBombsNearby(board);

            CreateGrid();
            UpdateBoardUI();

            startTime = DateTime.Now;
            gameTimer.Interval = 1000;
            gameTimer.Tick += GameTimerTick;
            gameTimer.Start();
        }

        /// <summary>
        /// Creates the grid of buttons used to display the board.
        /// </summary>
        private void CreateGrid()
        {
            buttons = new Button[gridSize, gridSize];
            int buttonSize = 40;

            PanelBoard.Controls.Clear();

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
                    btn.MouseUp += ButtonMouseUp;
                    btn.BackgroundImageLayout = ImageLayout.Stretch;
                    btn.BackgroundImage = hiddenTileImage;
                    btn.Text = "";

                    PanelBoard.Controls.Add(btn);
                    buttons[row, col] = btn;
                }
            }

            PanelBoard.Width = gridSize * buttonSize;
            PanelBoard.Height = gridSize * buttonSize;
        }

        /// <summary>
        /// Handles mouse clicks on board buttons and updates the selected cell.
        /// </summary>
        /// <param name="sender">The button that triggered the event.</param>
        /// <param name="e">Mouse event data.</param>
        private void ButtonMouseUp(object? sender, MouseEventArgs e)
        {
            Button btn = (Button)sender!;
            Point point = (Point)btn.Tag!;

            int row = point.X;
            int col = point.Y;

            if (e.Button == MouseButtons.Right)
            {
                logic.FlagCell(board, row, col);
            }
            else if (e.Button == MouseButtons.Left)
            {
              // Hold Shift and left-click to use a reward peek instead of visiting the cell.
                if ((ModifierKeys & Keys.Shift) == Keys.Shift)
                {
                    bool? isBomb = logic.UseRewardPeek(board, row, col);

                    if (isBomb == null)
                    {
                        MessageBox.Show("You do not have any rewards to use.");
                    }
                    else if (isBomb == true)
                    {
                        MessageBox.Show("Reward used: This cell has a bomb!");
                    }
                    else
                    {
                        MessageBox.Show("Reward used: This cell is safe.");
                    }
                }
                else
                {
                    logic.VisitCell(board, row, col);
                }
            }

            UpdateBoardUI();
            CheckGameState();
            gameTimer.Stop();
            gameTimer.Start();
        }

        /// <summary>
        /// Updates the user interface based on the current board state.
        /// </summary>
        private void UpdateBoardUI()
        {
            if (buttons == null)
            {
                return;
            }

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
        /// Checks the current game state and handles win or loss conditions.
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
        /// Reveals all bomb locations after the game is lost.
        /// </summary>
        private void RevealBombs()
        {
            if (buttons == null)
            {
                return;
            }

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
        /// Disables all buttons after the game ends.
        /// </summary>
        private void DisableBoard()
        {
            if (buttons == null)
            {
                return;
            }

            for (int row = 0; row < gridSize; row++)
            {
                for (int col = 0; col < gridSize; col++)
                {
                    buttons[row, col].Enabled = false;
                }
            }
        }

        /// <summary>
        /// Handles timer tick events during the game.
        /// </summary>
        /// <param name="sender">The timer that triggered the event.</param>
        /// <param name="e">Event data.</param>
        private void GameTimerTick(object? sender, EventArgs e)
        {
        }

        /// <summary>
        /// Calculates the final score based on difficulty and elapsed time.
        /// </summary>
        /// <returns>The calculated player score.</returns>
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