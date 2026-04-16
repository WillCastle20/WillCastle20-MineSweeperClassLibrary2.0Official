/*Darius Drake William Castellanos
 * CST-250
 * Milestone 5
 * Updated by Will Castellanos
 * 2/17/26
 */

using System.Linq;
using MinesweeperClassLibrary.BusinessLogicLayer;
using MinesweeperClassLibrary.Models;
using Xunit;

namespace MinesweeperTests
{
    /// <summary>
    /// Contains xUnit tests for the BoardLogic class across multiple milestones.
    /// </summary>
    public class BoardLogicMilestoneTests
    {
        /// <summary>
        /// Verifies the game is lost when a bomb cell is visited.
        /// </summary>
        [Fact]
        public void DetermineGameStateReturnsLostWhenBombCellIsVisited()
        {
            BoardLogic logic = new BoardLogic();
            BoardModel board = new BoardModel(2);

            board.Cells[0, 0].IsBomb = true;
            board.Cells[0, 0].IsVisited = true;

            GameState state = logic.DetermineGameState(board);

            Assert.Equal(GameState.Lost, state);
        }

        /// <summary>
        /// Verifies the game remains in progress when a safe cell is not visited.
        /// </summary>
        [Fact]
        public void DetermineGameStateReturnsInProgressWhenSafeCellIsNotVisited()
        {
            BoardLogic logic = new BoardLogic();
            BoardModel board = new BoardModel(2);

            board.Cells[0, 0].IsBomb = true;
            board.Cells[0, 0].IsFlagged = true;
            board.Cells[0, 1].IsVisited = false;

            GameState state = logic.DetermineGameState(board);

            Assert.Equal(GameState.InProgress, state);
        }

        /// <summary>
        /// Verifies the game is won when all safe cells are visited.
        /// </summary>
        [Fact]
        public void DetermineGameStateReturnsWonWhenAllSafeCellsAreVisited()
        {
            BoardLogic logic = new BoardLogic();
            BoardModel board = new BoardModel(2);

            board.Cells[0, 0].IsBomb = true;
            board.Cells[0, 0].IsVisited = false;

            VisitAllSafeCells(board);

            GameState state = logic.DetermineGameState(board);

            Assert.Equal(GameState.Won, state);
        }

        /// <summary>
        /// Ensures a flagged cell cannot be visited.
        /// </summary>
        [Fact]
        public void VisitCellDoesNotVisitWhenCellIsFlagged()
        {
            BoardLogic logic = new BoardLogic();
            BoardModel board = new BoardModel(2);

            board.Cells[1, 1].IsFlagged = true;

            logic.VisitCell(board, 1, 1);

            Assert.False(board.Cells[1, 1].IsVisited);
        }

        /// <summary>
        /// Ensures a visited cell cannot be flagged.
        /// </summary>
        [Fact]
        public void FlagCellDoesNotFlagWhenCellIsVisited()
        {
            BoardLogic logic = new BoardLogic();
            BoardModel board = new BoardModel(2);

            board.Cells[1, 1].IsVisited = true;

            logic.FlagCell(board, 1, 1);

            Assert.False(board.Cells[1, 1].IsFlagged);
        }

        /// <summary>
        /// Verifies FloodFill expands when starting on a zero-neighbor cell.
        /// </summary>
        [Fact]
        public void FloodFillZeroCellExpandsToMultipleCells()
        {
            BoardLogic logic = new BoardLogic();
            BoardModel board = new BoardModel(3);

            logic.CountBombsNearby(board);
            logic.FloodFill(board, 1, 1);

            int visitedCount = board.Cells.Cast<CellModel>()
                                          .Count(cell => cell.IsVisited);

            Assert.True(visitedCount > 1);
        }

        /// <summary>
        /// Verifies FloodFill does not recurse when starting on a numbered cell.
        /// </summary>
        [Fact]
        public void FloodFillNumberedCellDoesNotRecurse()
        {
            BoardLogic logic = new BoardLogic();
            BoardModel board = new BoardModel(3);

            board.Cells[0, 1].IsBomb = true;
            logic.CountBombsNearby(board);
            logic.FloodFill(board, 0, 0);

            int visitedCount = board.Cells.Cast<CellModel>()
                                          .Count(cell => cell.IsVisited);

            Assert.Equal(1, visitedCount);
        }

        /// <summary>
        /// Verifies FloodFill visits a bomb cell and stops.
        /// </summary>
        [Fact]
        public void FloodFillBombCellVisitsOnlyThatCell()
        {
            BoardLogic logic = new BoardLogic();
            BoardModel board = new BoardModel(3);

            board.Cells[1, 1].IsBomb = true;

            logic.FloodFill(board, 1, 1);

            Assert.True(board.Cells[1, 1].IsVisited);
        }

        /// <summary>
        /// Verifies FloodFill does not revisit cells and cause repeated expansion.
        /// </summary>
        [Fact]
        public void FloodFillDoesNotRevisitCells()
        {
            BoardLogic logic = new BoardLogic();
            BoardModel board = new BoardModel(3);

            logic.CountBombsNearby(board);
            logic.FloodFill(board, 1, 1);

            int firstVisitCount = board.Cells.Cast<CellModel>()
                                             .Count(cell => cell.IsVisited);

            logic.FloodFill(board, 1, 1);

            int secondVisitCount = board.Cells.Cast<CellModel>()
                                              .Count(cell => cell.IsVisited);

            Assert.Equal(firstVisitCount, secondVisitCount);
        }

        /// <summary>
        /// Marks all non-bomb cells on the board as visited.
        /// </summary>
        /// <param name="board">The board whose safe cells will be visited.</param>
        private static void VisitAllSafeCells(BoardModel board)
        {
            for (int row = 0; row < board.Size; row++)
            {
                for (int col = 0; col < board.Size; col++)
                {
                    if (!board.Cells[row, col].IsBomb)
                    {
                        board.Cells[row, col].IsVisited = true;
                    }
                }
            }
        }
    }
}