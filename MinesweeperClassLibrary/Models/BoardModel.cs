/*Darius Drake William Castellanos
 * CST-250
 * Milestone 5
 * Updated by Will Castellanos
 * 2/17/26
 */

using System;

namespace MinesweeperClassLibrary.Models
{
    /// <summary>
    /// Represents the Minesweeper game board and stores all board-related data.
    /// </summary>
    public class BoardModel
    {
        /// <summary>
        /// Gets or sets the size of the board.
        /// </summary>
        public int Size { get; set; }

        /// <summary>
        /// Gets or sets the two-dimensional grid of cells.
        /// </summary>
        public CellModel[,] Cells { get; set; }

        /// <summary>
        /// Gets or sets the board difficulty value.
        /// </summary>
        public int Difficulty { get; set; }

        /// <summary>
        /// Gets or sets the game start time.
        /// </summary>
        public DateTime StartTime { get; set; }

        /// <summary>
        /// Gets or sets the game end time.
        /// </summary>
        public DateTime EndTime { get; set; }

        /// <summary>
        /// Gets or sets the number of rewards remaining.
        /// </summary>
        public int RewardsRemaining { get; set; }

        /// <summary>
        /// Gets or sets the current game state.
        /// </summary>
        public GameState GameState { get; set; }

        /// <summary>
        /// Creates a board and initializes all cells.
        /// </summary>
        /// <param name="size">The size of the board.</param>
        public BoardModel(int size)
        {
            Size = size;
            Difficulty = size <= 10 ? 10 : 15;
            RewardsRemaining = 0;
            Cells = new CellModel[Size, Size];

            for (int row = 0; row < Size; row++)
            {
                for (int col = 0; col < Size; col++)
                {
                    Cells[row, col] = new CellModel
                    {
                        Row = row,
                        Column = col
                    };
                }
            }

            StartTime = DateTime.Now;
            GameState = GameState.InProgress;
        }
    }
}