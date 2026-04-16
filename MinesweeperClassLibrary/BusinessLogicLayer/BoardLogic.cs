/*Darius Drake
 * CST-250
 * Milestone 5
 * Updated by Will Castellanos
 * 2/17/26
 */
using MinesweeperClassLibrary.Models;
using System;

namespace MinesweeperClassLibrary.BusinessLogicLayer
{
    public class BoardLogic
    {
        // Use one Random instance to avoid repeated identical random values
        private static readonly Random _rand = new Random();

        /// <summary>
        /// Places bombs on the board
        /// </summary>
        /// <param name="board"></param>
        /// <param name="difficultyLevel"></param>
        public void SetUpBombs(BoardModel board, int difficultyLevel)
        {
            int numberOfBombs;

            if (difficultyLevel == 1)
                numberOfBombs = board.Size * 2;
            else if (difficultyLevel == 2)
                numberOfBombs = board.Size * 3;
            else
                numberOfBombs = board.Size * 4;

            Random rand = new Random();
            int bombsPlaced = 0;

            while (bombsPlaced < numberOfBombs)
            {
                int row = rand.Next(0, board.Size);
                int col = rand.Next(0, board.Size);

                if (!board.Cells[row, col].IsBomb)
                {
                    board.Cells[row, col].IsBomb = true;
                    bombsPlaced++;
                }
            }
        }

        /// <summary>
        /// Randomly places special rewards on NON-bomb cells.
        /// </summary>
        public void SetUpRewards(BoardModel board, int rewardsToPlace = 3)
        {
            if (board == null)
                throw new ArgumentNullException(nameof(board));

            int size = board.Size;

            // Safety: if board is tiny, don't over-place rewards
            rewardsToPlace = Math.Max(0, Math.Min(rewardsToPlace, (size * size) - board.Difficulty));

            while (rewardsToPlace > 0)
            {
                int row = _rand.Next(size);
                int col = _rand.Next(size);

                var cell = board.Cells[row, col];

                // Don't place rewards on bombs and don't double-place
                if (!cell.IsBomb && !cell.HasSpecialReward)
                {
                    cell.HasSpecialReward = true;
                    rewardsToPlace--;
                }
            }
        }

        /// <summary>
        /// Counts neighboring bombs for each cell.
        /// Bomb cells get NumberOfBombNeighbors = 9.
        /// </summary>
        public void CountBombsNearby(BoardModel board)
        {
            if (board == null)
                throw new ArgumentNullException(nameof(board));

            int size = board.Size;

            for (int row = 0; row < size; row++)
            {
                for (int col = 0; col < size; col++)
                {
                    if (board.Cells[row, col].IsBomb)
                    {
                        board.Cells[row, col].NumberOfBombNeighbors = 9;
                        continue;
                    }

                    int bombCount = 0;

                    for (int r = row - 1; r <= row + 1; r++)
                    {
                        for (int c = col - 1; c <= col + 1; c++)
                        {
                            if (r < 0 || r >= size || c < 0 || c >= size)
                                continue;

                            if (r == row && c == col)
                                continue;

                            if (board.Cells[r, c].IsBomb)
                                bombCount++;
                        }
                    }

                    board.Cells[row, col].NumberOfBombNeighbors = bombCount;
                }
            }
        }

        /// <summary>
        /// Visits a cell (marks IsVisited true) if within bounds and not flagged.
        /// If the cell contains a special reward, increment board.RewardsRemaining and consume it.
        /// </summary>
        public void VisitCell(BoardModel board, int row, int col)
        {
            if (board == null)
                throw new ArgumentNullException(nameof(board));

            if (!InBounds(board, row, col))
                return;

            if (board.Cells[row, col].IsFlagged)
                return;

          FloodFill(board, row, col);
        }

        /// <summary>
        /// Toggles flag on a cell if within bounds and not already visited.
        /// </summary>
        public void FlagCell(BoardModel board, int row, int col)
        {
            if (board == null)
                throw new ArgumentNullException(nameof(board));

            if (!InBounds(board, row, col))
                return;

            if (board.Cells[row, col].IsVisited)
                return;

            board.Cells[row, col].IsFlagged = !board.Cells[row, col].IsFlagged;
        }

        /// <summary>
        /// Uses one reward to "peek" at a cell.
        /// Returns:
        /// - true  => cell IS a bomb
        /// - false => cell is NOT a bomb
        /// - null  => cannot peek (no rewards or out of bounds)
        /// </summary>
        public bool? UseRewardPeek(BoardModel board, int row, int col)
        {
            if (board == null)
                throw new ArgumentNullException(nameof(board));

            if (!InBounds(board, row, col))
                return null;

            if (board.RewardsRemaining <= 0)
                return null;

            board.RewardsRemaining--;

            return board.Cells[row, col].IsBomb;
        }

        /// <summary>
        /// Determines if the game is Won, Lost, or InProgress.
        /// Lost: any bomb cell visited.
        /// Won: all non-bomb cells visited AND all bomb cells flagged.
        /// InProgress: otherwise.
        /// </summary>
        public GameState DetermineGameState(BoardModel board)
        {
            if (board == null)
                throw new ArgumentNullException(nameof(board));

            int size = board.Size;

            // Lost if any bomb is visited
            for (int row = 0; row < size; row++)
            {
                for (int col = 0; col < size; col++)
                {
                    var cell = board.Cells[row, col];
                    if (cell.IsBomb && cell.IsVisited)
                    {
                        board.GameState = GameState.Lost;
                        return GameState.Lost;
                    }
                }
            }

            // In progress if any safe cell unvisited OR any bomb unflagged
            for (int row = 0; row < size; row++)
            {
                for (int col = 0; col < size; col++)
                {
                    var cell = board.Cells[row, col];

                    if (!cell.IsBomb && !cell.IsVisited)
                    {
                        board.GameState = GameState.InProgress;
                        return GameState.InProgress;
                    }

                    if (cell.IsBomb && !cell.IsFlagged)
                    {
                        board.GameState = GameState.InProgress;
                        return GameState.InProgress;
                    }
                }
            }

            board.GameState = GameState.Won;
            return GameState.Won;
        }
        /// <summary>
        /// Recursive flood fill that shows the connected zero - neighbor cells
        /// </summary>
        /// <param name="board"></param>
        /// <param name="row"></param>
        /// <param name="col"></param>
        /// <exception cref="ArgumentNullException"></exception>
        public void FloodFill(BoardModel board, int row, int col)
        {
            if (board == null)
                throw new ArgumentNullException(nameof(board));

            if (!InBounds(board, row, col))
                return;

            var cell = board.Cells[row, col];

            // Stop if already visited or flagged
            if (cell.IsVisited || cell.IsFlagged)
                return;

            // If bomb, mark visited and stop
            if (cell.IsBomb)
            {
                cell.IsVisited = true;
                return;
            }

            // Mark visited
            cell.IsVisited = true;

            // Collect reward if present
            if (cell.HasSpecialReward)
            {
                board.RewardsRemaining++;
                cell.HasSpecialReward = false;
            }

            // Stop recursion if numbered cell
            if (cell.NumberOfBombNeighbors > 0)
                return;

            // Recurse in 8 directions
            for (int r = row - 1; r <= row + 1; r++)
            {
                for (int c = col - 1; c <= col + 1; c++)
                {
                    if (r == row && c == col)
                        continue;

                    FloodFill(board, r, c);
                }
            }
        }

        // Helper: bounds check
        private bool InBounds(BoardModel board, int row, int col)
        {
            return row >= 0 && row < board.Size && col >= 0 && col < board.Size;
        }
    }
}
/// Test Comment/ 
