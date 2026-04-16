/*William Castellanos
 * CST-250
 * Milestone 3
 * 3/2/26
 */

using System.Linq;
using MinesweeperClassLibrary.BusinessLogicLayer;
using MinesweeperClassLibrary.Models;
using Xunit;

namespace MinesweeperTests
{
    public class BoardLogicMilestoneTests
    {
        // ============================
        // Milestone 2 Tests
        // ============================

        // Verifies the game is lost when a bomb cell is visited
        [Fact]
        public void DetermineGameState_ReturnsLost_WhenBombCellIsVisited()
        {
            var logic = new BoardLogic();
            var board = new BoardModel(2);

            board.Cells[0, 0].IsBomb = true;
            board.Cells[0, 0].IsVisited = true;

            GameState state = logic.DetermineGameState(board);

            Assert.Equal(GameState.Lost, state);
        }

        // Verifies the game remains in progress when a safe cell is not visited
        [Fact]
        public void DetermineGameState_ReturnsInProgress_WhenSafeCellNotVisited()
        {
            var logic = new BoardLogic();
            var board = new BoardModel(2);

            board.Cells[0, 0].IsBomb = true;
            board.Cells[0, 0].IsFlagged = true;

            board.Cells[0, 1].IsVisited = false;

            GameState state = logic.DetermineGameState(board);

            Assert.Equal(GameState.InProgress, state);
        }

        // Verifies the game is still in progress if a bomb exists but is not flagged
        [Fact]
        public void DetermineGameState_ReturnsInProgress_WhenBombNotFlagged()
        {
            var logic = new BoardLogic();
            var board = new BoardModel(2);

            VisitAllSafeCells(board);

            board.Cells[0, 0].IsBomb = true;
            board.Cells[0, 0].IsFlagged = false;
            board.Cells[0, 0].IsVisited = false;

            GameState state = logic.DetermineGameState(board);

            Assert.Equal(GameState.InProgress, state);
        }

        // Verifies the game is won when all safe cells are visited and bombs are flagged
        [Fact]
        public void DetermineGameState_ReturnsWon_WhenAllSafeVisited_AndAllBombsFlagged()
        {
            var logic = new BoardLogic();
            var board = new BoardModel(2);

            board.Cells[0, 0].IsBomb = true;
            board.Cells[0, 0].IsFlagged = true;

            VisitAllSafeCells(board);

            GameState state = logic.DetermineGameState(board);

            Assert.Equal(GameState.Won, state);
        }

        // Ensures a flagged cell cannot be visited
        [Fact]
        public void VisitCell_DoesNotVisit_WhenCellIsFlagged()
        {
            var logic = new BoardLogic();
            var board = new BoardModel(2);

            board.Cells[1, 1].IsFlagged = true;

            logic.VisitCell(board, 1, 1);

            Assert.False(board.Cells[1, 1].IsVisited);
        }

        // Ensures a visited cell cannot be flagged
        [Fact]
        public void FlagCell_DoesNotFlag_WhenCellIsVisited()
        {
            var logic = new BoardLogic();
            var board = new BoardModel(2);

            board.Cells[1, 1].IsVisited = true;

            logic.FlagCell(board, 1, 1);

            Assert.False(board.Cells[1, 1].IsFlagged);
        }

        // ============================
        // Milestone 3 Tests - FloodFill
        // ============================

        // Verifies FloodFill expands when starting on a zero neighbor cell
        [Fact]
        public void FloodFill_ZeroCell_ExpandsToMultipleCells()
        {
            var logic = new BoardLogic();
            var board = new BoardModel(3);

            logic.CountBombsNearby(board);

            logic.FloodFill(board, 1, 1);

            int visited = board.Cells.Cast<CellModel>()
                                     .Count(c => c.IsVisited);

            Assert.True(visited > 1);
        }

        // Verifies FloodFill does not recurse on a numbered cell
        [Fact]
        public void FloodFill_NumberedCell_DoesNotRecurse()
        {
            var logic = new BoardLogic();
            var board = new BoardModel(3);

            board.Cells[0, 1].IsBomb = true;
            logic.CountBombsNearby(board);

            logic.FloodFill(board, 0, 0);

            int visited = board.Cells.Cast<CellModel>()
                                     .Count(c => c.IsVisited);

            Assert.Equal(1, visited);
        }

        // Verifies FloodFill does nothing when starting on a bomb
        [Fact]
        public void FloodFill_BombCell_DoesNothing()
        {
            var logic = new BoardLogic();
            var board = new BoardModel(3);

            board.Cells[1, 1].IsBomb = true;

            logic.FloodFill(board, 1, 1);

            Assert.False(board.Cells[1, 1].IsVisited);
        }

        // Verifies FloodFill does not revisit cells and cause infinite recursion
        [Fact]
        public void FloodFill_DoesNotRevisitCells()
        {
            var logic = new BoardLogic();
            var board = new BoardModel(3);

            logic.CountBombsNearby(board);

            logic.FloodFill(board, 1, 1);

            int firstVisit = board.Cells.Cast<CellModel>()
                                        .Count(c => c.IsVisited);

            logic.FloodFill(board, 1, 1);

            int secondVisit = board.Cells.Cast<CellModel>()
                                         .Count(c => c.IsVisited);

            Assert.Equal(firstVisit, secondVisit);
        }

        // Helper method to mark all non bomb cells as visited
        private static void VisitAllSafeCells(BoardModel board)
        {
            for (int r = 0; r < board.Size; r++)
            {
                for (int c = 0; c < board.Size; c++)
                {
                    if (!board.Cells[r, c].IsBomb)
                    {
                        board.Cells[r, c].IsVisited = true;
                    }
                }
            }
        }
    }
}