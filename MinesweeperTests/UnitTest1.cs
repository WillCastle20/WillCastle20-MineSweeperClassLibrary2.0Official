/*Darius Drake William Castellanos
 * CST-250
 * Milestone 5
 * Updated by Will Castellanos
 * 2/17/26
 */

using System.Linq;
using MinesweeperClassLibrary.BusinessLogicLayer;
using MinesweeperClassLibrary.Models;
using System.Collections.Generic;
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
        /// Verifies SetUpBombs places bombs without filling the entire board.
        /// </summary>
        [Fact]
        public void SetUpBombsDoesNotMakeEveryCellABomb()
        {
            BoardLogic logic = new BoardLogic();
            BoardModel board = new BoardModel(2);

            logic.SetUpBombs(board, 1);

            int bombCount = 0;

            foreach (CellModel cell in board.Cells)
            {
                if (cell.IsBomb)
                {
                    bombCount++;
                }
            }

            Assert.True(bombCount < 4);
            Assert.True(bombCount > 0);
        }

        /// <summary>
        /// Verifies SetUpRewards places rewards only on non-bomb cells.
        /// </summary>
        [Fact]
        public void SetUpRewardsPlacesRewardsOnNonBombCells()
        {
            BoardLogic logic = new BoardLogic();
            BoardModel board = new BoardModel(3);

            board.Cells[0, 0].IsBomb = true;

            logic.SetUpRewards(board, 2);

            foreach (CellModel cell in board.Cells)
            {
                if (cell.HasSpecialReward)
                {
                    Assert.False(cell.IsBomb);
                }
            }
        }

        /// <summary>
        /// Verifies CountBombsNearby correctly counts neighboring bombs.
        /// </summary>
        [Fact]
        public void CountBombsNearbyCountsNeighboringBombs()
        {
            BoardLogic logic = new BoardLogic();
            BoardModel board = new BoardModel(3);

            board.Cells[0, 0].IsBomb = true;

            logic.CountBombsNearby(board);

            Assert.Equal(1, board.Cells[0, 1].NumberOfBombNeighbors);
            Assert.Equal(1, board.Cells[1, 0].NumberOfBombNeighbors);
            Assert.Equal(1, board.Cells[1, 1].NumberOfBombNeighbors);
            Assert.Equal(9, board.Cells[0, 0].NumberOfBombNeighbors);
        }

        /// <summary>
        /// Verifies UseRewardPeek uses one reward and returns whether the selected cell is a bomb.
        /// </summary>
        [Fact]
        public void UseRewardPeekReturnsBombStatusAndUsesReward()
        {
            BoardLogic logic = new BoardLogic();
            BoardModel board = new BoardModel(2);

            board.RewardsRemaining = 1;
            board.Cells[0, 0].IsBomb = true;

            bool? result = logic.UseRewardPeek(board, 0, 0);

            Assert.True(result);
            Assert.Equal(0, board.RewardsRemaining);

        }

        /// <summary>
        /// Verifies CalculateScore returns a positive score using difficulty and game time.
        /// </summary>
        [Fact]
        public void CalculateScoreReturnsExpectedScore()
        {
            BoardLogic logic = new BoardLogic();
            TimeSpan gameTime = TimeSpan.FromSeconds(30);

            int score = logic.CalculateScore(2, gameTime);

            Assert.Equal(1170, score);
        }

        /// <summary>
        /// Verifies CalculateAverageScore returns the correct average score.
        /// </summary>
        [Fact]
        public void CalculateAverageScoreReturnsCorrectAverage()
        {
            GameStatLogic logic = new GameStatLogic();

            List<GameStat> stats = new List<GameStat>
    {
        new GameStat(1, "Will", 1000, TimeSpan.FromSeconds(60)),
        new GameStat(2, "Darius", 2000, TimeSpan.FromSeconds(120))
    };

            double averageScore = logic.CalculateAverageScore(stats);

            Assert.Equal(1500, averageScore);
        }

        /// <summary>
        /// Verifies CalculateAverageGameTime returns the correct average game time.
        /// </summary>
        [Fact]
        public void CalculateAverageGameTimeReturnsCorrectAverage()
        {
            GameStatLogic logic = new GameStatLogic();

            List<GameStat> stats = new List<GameStat>
    {
        new GameStat(1, "Will", 1000, TimeSpan.FromSeconds(60)),
        new GameStat(2, "Darius", 2000, TimeSpan.FromSeconds(120))
    };

            TimeSpan averageTime = logic.CalculateAverageGameTime(stats);

            Assert.Equal(TimeSpan.FromSeconds(90), averageTime);
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