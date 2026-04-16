/*Darius Drake
 * CST-250
 * Milestone 2
 * Updated by Will Castellanos
 * 2/17/26
 */
using System;

namespace MinesweeperClassLibrary.Models
{
    public class BoardModel
    {
        // Stores the size of the board
        public int Size { get; set; }

        // Stores the 2D grid of the cells
        public CellModel[,] Cells { get; set; }

        // Stores the difficulty (how many bombs)
        public int Difficulty { get; set; }

        // Stores the start time of the game
        public DateTime StartTime { get; set; }

        // Stores the end time of the game
        public DateTime EndTime { get; set; }

        // Stores the remaining rewards
        public int RewardsRemaining { get; set; }

        // Stores the current game state
        public GameState GameState { get; set; }

        /// <summary>
        /// Creates a board and initializes all cells.
        /// </summary>
        /// <param name="size">Board size (NxN)</param>
        public BoardModel(int size)
        {
            Size = size;

            // IMPORTANT: Default difficulty so bombs actually exist
            // You can adjust these numbers if your instructor expects something different.
            Difficulty = (size <= 10) ? 10 : 15;

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
