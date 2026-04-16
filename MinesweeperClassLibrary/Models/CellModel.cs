/*Darius Drake
 * CST-250
 * Milestone 4
 * Darius Drake
 * 3/31/26
 */

namespace MinesweeperClassLibrary.Models
{
    public class CellModel
    {
        // Row position of the cell on the board
        public int Row { get; set; } = -1;

        // Column position of the cell on the board
        public int Column { get; set; } = -1;

        // True if the player has visited the cell
        public bool IsVisited { get; set; } = false;

        // True if the cell contains a bomb
        public bool IsBomb { get; set; } = false;

        // True if the player flagged the cell
        public bool IsFlagged { get; set; } = false;

        // Number of bombs in neighboring cells (0–8; often 9 used for bombs)
        public int NumberOfBombNeighbors { get; set; } = 0;

        // True if the cell contains a special reward
        public bool HasSpecialReward { get; set; } = false;
    }
}
