/*Darius Drake William Castellanos
 * CST-250
 * Milestone 5
 * Updated by Will Castellanos
 * 2/17/26
 */

using MinesweeperClassLibrary.Models;
using System;

namespace MinesweeperClassLibrary.BusinessLogicLayer
{
    /// <summary>
    /// Contains the business logic for the Minesweeper game board,
    /// including bomb placement, reward placement, visiting cells,
    /// flagging cells, checking game state, and flood fill behavior.
    /// </summary>
    public class BoardLogic
    {
        /// <summary>
        /// Random number generator used for bomb and reward placement.
        /// </summary>
        private static readonly Random _random = new Random();

        /// <summary>
        /// Places bombs on the board based on the selected difficulty level.
        /// </summary>
        /// <param name="board">The game board being initialized.</param>
        /// <param name="difficultyLevel">The selected difficulty level.</param>
        public void SetUpBombs(BoardModel board, int difficultyLevel)
        {
            if (board == null)
            {
                throw new ArgumentNullException(nameof(board));
            }

            int numberOfBombs;

            if (difficultyLevel == 1)
            {
                numberOfBombs = board.Size;
            }
            else if (difficultyLevel == 2)
            {
                numberOfBombs = board.Size * 2;
            }
            else
            {
                numberOfBombs = board.Size * 3;
            }

            int totalCells = board.Size * board.Size;
            int maxBombs = totalCells - 1;

            if (numberOfBombs > maxBombs)
            {
                numberOfBombs = maxBombs;
            }

            int bombsPlaced = 0;

            while (bombsPlaced < numberOfBombs)
            {
                int row = _random.Next(0, board.Size);
                int col = _random.Next(0, board.Size);

                if (!board.Cells[row, col].IsBomb)
                {
                    board.Cells[row, col].IsBomb = true;
                    bombsPlaced++;
                }
            }
        }

        /// <summary>
        /// Randomly places special rewards on non-bomb cells.
        /// </summary>
        /// <param name="board">The game board receiving rewards.</param>
        /// <param name="rewardsToPlace">The number of rewards to place.</param>
        public void SetUpRewards(BoardModel board, int rewardsToPlace = 3)
        {
            if (board == null)
            {
                throw new ArgumentNullException(nameof(board));
            }

            int size = board.Size;

            rewardsToPlace = Math.Max(0, Math.Min(rewardsToPlace, (size * size) - board.Difficulty));

            while (rewardsToPlace > 0)
            {
                int row = _random.Next(size);
                int col = _random.Next(size);

                CellModel cell = board.Cells[row, col];

                if (!cell.IsBomb && !cell.HasSpecialReward)
                {
                    cell.HasSpecialReward = true;
                    rewardsToPlace--;
                }
            }
        }

        /// <summary>
        /// Counts the number of neighboring bombs for each cell on the board.
        /// Bomb cells are assigned a value of 9.
        /// </summary>
        /// <param name="board">The game board to evaluate.</param>
        public void CountBombsNearby(BoardModel board)
        {
            if (board == null)
            {
                throw new ArgumentNullException(nameof(board));
            }

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
                            {
                                continue;
                            }

                            if (r == row && c == col)
                            {
                                continue;
                            }

                            if (board.Cells[r, c].IsBomb)
                            {
                                bombCount++;
                            }
                        }
                    }

                    board.Cells[row, col].NumberOfBombNeighbors = bombCount;
                }
            }
        }

        /// <summary>
        /// Visits a cell if it is within bounds and not flagged.
        /// </summary>
        /// <param name="board">The game board containing the cell.</param>
        /// <param name="row">The row of the selected cell.</param>
        /// <param name="col">The column of the selected cell.</param>
        public void VisitCell(BoardModel board, int row, int col)
        {
            if (board == null)
            {
                throw new ArgumentNullException(nameof(board));
            }

            if (!IsInBounds(board, row, col))
            {
                return;
            }

            if (board.Cells[row, col].IsFlagged)
            {
                return;
            }

            FloodFill(board, row, col);
        }

        /// <summary>
        /// Toggles the flagged state of a cell if it is within bounds and not already visited.
        /// </summary>
        /// <param name="board">The game board containing the cell.</param>
        /// <param name="row">The row of the selected cell.</param>
        /// <param name="col">The column of the selected cell.</param>
        public void FlagCell(BoardModel board, int row, int col)
        {
            if (board == null)
            {
                throw new ArgumentNullException(nameof(board));
            }

            if (!IsInBounds(board, row, col))
            {
                return;
            }

            if (board.Cells[row, col].IsVisited)
            {
                return;
            }

            board.Cells[row, col].IsFlagged = !board.Cells[row, col].IsFlagged;
        }

        /// <summary>
        /// Uses one reward to peek at whether a selected cell contains a bomb.
        /// </summary>
        /// <param name="board">The game board containing the cell.</param>
        /// <param name="row">The row of the selected cell.</param>
        /// <param name="col">The column of the selected cell.</param>
        /// <returns>
        /// True if the cell is a bomb, false if it is not a bomb,
        /// or null if the action cannot be completed.
        /// </returns>
        public bool? UseRewardPeek(BoardModel board, int row, int col)
        {
            if (board == null)
            {
                throw new ArgumentNullException(nameof(board));
            }

            if (!IsInBounds(board, row, col))
            {
                return null;
            }

            if (board.RewardsRemaining <= 0)
            {
                return null;
            }

            board.RewardsRemaining--;

            return board.Cells[row, col].IsBomb;
        }

        /// <summary>
        /// Determines whether the current game state is won, lost, or still in progress.
        /// </summary>
        /// <param name="board">The game board to evaluate.</param>
        /// <returns>The current game state.</returns>
        public GameState DetermineGameState(BoardModel board)
        {
            if (board == null)
            {
                throw new ArgumentNullException(nameof(board));
            }

            int size = board.Size;

            for (int row = 0; row < size; row++)
            {
                for (int col = 0; col < size; col++)
                {
                    CellModel cell = board.Cells[row, col];

                    if (cell.IsBomb && cell.IsVisited)
                    {
                        board.GameState = GameState.Lost;
                        return GameState.Lost;
                    }
                }
            }

            for (int row = 0; row < size; row++)
            {
                for (int col = 0; col < size; col++)
                {
                    CellModel cell = board.Cells[row, col];

                    if (!cell.IsBomb && !cell.IsVisited)
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
        /// Recursively reveals connected cells with zero neighboring bombs.
        /// </summary>
        /// <param name="board">The game board containing the cell.</param>
        /// <param name="row">The row of the selected cell.</param>
        /// <param name="col">The column of the selected cell.</param>
        public void FloodFill(BoardModel board, int row, int col)
        {
            if (board == null)
            {
                throw new ArgumentNullException(nameof(board));
            }

            if (!IsInBounds(board, row, col))
            {
                return;
            }

            CellModel cell = board.Cells[row, col];

            if (cell.IsVisited || cell.IsFlagged)
            {
                return;
            }

            if (cell.IsBomb)
            {
                cell.IsVisited = true;
                return;
            }

            cell.IsVisited = true;

            if (cell.HasSpecialReward)
            {
                board.RewardsRemaining++;
                cell.HasSpecialReward = false;
            }

            if (cell.NumberOfBombNeighbors > 0)
            {
                return;
            }

            for (int r = row - 1; r <= row + 1; r++)
            {
                for (int c = col - 1; c <= col + 1; c++)
                {
                    if (r == row && c == col)
                    {
                        continue;
                    }

                    FloodFill(board, r, c);
                }
            }
        }

        /// <summary>
        /// Calculates the player's final score based on difficulty and elapsed game time.
        /// </summary>
        /// <param name="difficultyLevel">The selected difficulty level.</param>
        /// <param name="gameTime">The amount of time the player spent in the game.</param>
        /// <returns>The calculated final score.</returns>
        public int CalculateScore(int difficultyLevel, TimeSpan gameTime)
        {
            int baseScore = 1000;
            int difficultyBonus = difficultyLevel * 100;
            int timePenalty = (int)gameTime.TotalSeconds;

            int finalScore = baseScore + difficultyBonus - timePenalty;

            if (finalScore < 0)
            {
                finalScore = 0;
            }

            return finalScore;
        }

        /// <summary>
        /// Determines whether the specified row and column are within the board boundaries.
        /// </summary>
        /// <param name="board">The game board being checked.</param>
        /// <param name="row">The row to validate.</param>
        /// <param name="col">The column to validate.</param>
        /// <returns>True if the row and column are inside the board; otherwise, false.</returns>
        private bool IsInBounds(BoardModel board, int row, int col)
        {
            return row >= 0 && row < board.Size && col >= 0 && col < board.Size;
        }
    }
}