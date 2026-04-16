/*Darius Drake William Castellanos
 * CST-250
 * Milestone 5
 * Updated by Will Castellanos
 * 2/17/26
 */

namespace MinesweeperClassLibrary.Models
{
    /// <summary>
    /// Represents a single cell on the Minesweeper board.
    /// </summary>
    public class CellModel
    {
        /// <summary>
        /// Gets or sets the row position of the cell.
        /// </summary>
        public int Row { get; set; } = -1;

        /// <summary>
        /// Gets or sets the column position of the cell.
        /// </summary>
        public int Column { get; set; } = -1;

        /// <summary>
        /// Gets or sets a value indicating whether the cell has been visited.
        /// </summary>
        public bool IsVisited { get; set; } = false;

        /// <summary>
        /// Gets or sets a value indicating whether the cell contains a bomb.
        /// </summary>
        public bool IsBomb { get; set; } = false;

        /// <summary>
        /// Gets or sets a value indicating whether the cell is flagged.
        /// </summary>
        public bool IsFlagged { get; set; } = false;

        /// <summary>
        /// Gets or sets the number of neighboring bombs.
        /// </summary>
        public int NumberOfBombNeighbors { get; set; } = 0;

        /// <summary>
        /// Gets or sets a value indicating whether the cell contains a special reward.
        /// </summary>
        public bool HasSpecialReward { get; set; } = false;
    }
}