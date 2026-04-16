/*Darius Drake William Castellanos
 * CST-250
 * Milestone 5
 * Updated by Will Castellanos
 * 2/17/26
 */

using System;
using MinesweeperClassLibrary.BusinessLogicLayer;
using MinesweeperClassLibrary.Models;

namespace MinesweeperConsole
{
    /// <summary>
    /// Contains the entry point and helper methods for the console version of Minesweeper.
    /// </summary>
    internal class Program
    {
        /// <summary>
        /// Starts the console Minesweeper game.
        /// </summary>
        /// <param name="args">Command-line arguments.</param>
        private static void Main(string[] args)
        {
            BoardLogic logic = new BoardLogic();

            BoardModel board = new BoardModel(10);
            int difficultyLevel = 1;

            logic.SetUpBombs(board, difficultyLevel);
            logic.CountBombsNearby(board);
            logic.SetUpRewards(board, 3);

            bool showAnswerKey = false;

            if (showAnswerKey)
            {
                Console.WriteLine("===== ANSWER KEY (DEBUG) =====");
                PrintAnswers(board);
                Console.WriteLine("\nPress Enter to start the real game...");
                Console.ReadLine();
            }

            GameState state = GameState.InProgress;

            while (state == GameState.InProgress)
            {
                Console.Clear();
                Console.WriteLine("Minesweeper (Milestone 5)");
                Console.WriteLine($"Rewards Available: {board.RewardsRemaining}");
                Console.WriteLine("Actions: 1 = Visit, 2 = Flag, 3 = Use Reward (Peek)");
                Console.WriteLine();

                PrintBoard(board, false);

                int row = ReadInt($"Enter row (0-{board.Size - 1}): ", 0, board.Size - 1);
                int col = ReadInt($"Enter column (0-{board.Size - 1}): ", 0, board.Size - 1);
                int action = ReadInt("Enter action (1 = Visit, 2 = Flag, 3 = Use Reward): ", 1, 3);

                switch (action)
                {
                    case 1:
                        logic.VisitCell(board, row, col);
                        break;

                    case 2:
                        logic.FlagCell(board, row, col);
                        break;

                    case 3:
                        bool? peekResult = logic.UseRewardPeek(board, row, col);

                        if (peekResult == null)
                        {
                            Console.WriteLine("No rewards are available or the selected cell is invalid.");
                        }
                        else if (peekResult == true)
                        {
                            Console.WriteLine("Reward Peek: That cell is a bomb.");
                        }
                        else
                        {
                            Console.WriteLine("Reward Peek: That cell is not a bomb.");
                        }

                        Pause();
                        break;
                }

                state = logic.DetermineGameState(board);
            }

            Console.Clear();
            PrintBoard(board, true);

            if (state == GameState.Won)
            {
                Console.WriteLine("\nCongratulations! You won!");
            }
            else
            {
                Console.WriteLine("\nGame Over! You hit a bomb.");
            }

            Console.WriteLine("\nPress Enter to exit...");
            Console.ReadLine();
        }

        /// <summary>
        /// Prints the current board view for the player.
        /// </summary>
        /// <param name="board">The game board to display.</param>
        /// <param name="revealBombs">Indicates whether bombs should be revealed.</param>
        private static void PrintBoard(BoardModel board, bool revealBombs)
        {
            int size = board.Size;

            Console.Write("   ");
            for (int col = 0; col < size; col++)
            {
                Console.Write($"{col,2} ");
            }
            Console.WriteLine();

            Console.Write("   ");
            for (int col = 0; col < size; col++)
            {
                Console.Write("---");
            }
            Console.WriteLine("-");

            for (int row = 0; row < size; row++)
            {
                Console.Write($"{row,2} |");

                for (int col = 0; col < size; col++)
                {
                    CellModel cell = board.Cells[row, col];

                    if (cell.IsFlagged && !cell.IsVisited)
                    {
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.Write(" F ");
                        Console.ResetColor();
                        continue;
                    }

                    if (!cell.IsVisited)
                    {
                        Console.ForegroundColor = ConsoleColor.DarkGray;
                        Console.Write(" ? ");
                        Console.ResetColor();
                        continue;
                    }

                    if (cell.IsBomb && revealBombs)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write(" B ");
                        Console.ResetColor();
                        continue;
                    }

                    if (cell.NumberOfBombNeighbors == 0)
                    {
                        Console.ForegroundColor = ConsoleColor.DarkGray;
                        Console.Write(" . ");
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Cyan;
                        Console.Write($" {cell.NumberOfBombNeighbors} ");
                    }

                    Console.ResetColor();
                }

                Console.WriteLine("|");
            }

            Console.Write("   ");
            for (int col = 0; col < size; col++)
            {
                Console.Write("---");
            }
            Console.WriteLine("-");
        }

        /// <summary>
        /// Prints the answer key for debugging purposes.
        /// </summary>
        /// <param name="board">The game board to display.</param>
        private static void PrintAnswers(BoardModel board)
        {
            int size = board.Size;

            Console.Write("   ");
            for (int col = 0; col < size; col++)
            {
                Console.Write($"{col,2} ");
            }
            Console.WriteLine();

            Console.Write("   ");
            for (int col = 0; col < size; col++)
            {
                Console.Write("---");
            }
            Console.WriteLine("-");

            for (int row = 0; row < size; row++)
            {
                Console.Write($"{row,2} |");

                for (int col = 0; col < size; col++)
                {
                    CellModel cell = board.Cells[row, col];

                    if (cell.IsBomb)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write(" B ");
                    }
                    else if (cell.NumberOfBombNeighbors == 0)
                    {
                        Console.ForegroundColor = ConsoleColor.DarkGray;
                        Console.Write(" . ");
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Cyan;
                        Console.Write($" {cell.NumberOfBombNeighbors} ");
                    }

                    Console.ResetColor();
                }

                Console.WriteLine("|");
            }

            Console.Write("   ");
            for (int col = 0; col < size; col++)
            {
                Console.Write("---");
            }
            Console.WriteLine("-");
        }

        /// <summary>
        /// Reads an integer from the user within the allowed range.
        /// </summary>
        /// <param name="prompt">The message shown to the user.</param>
        /// <param name="min">The minimum allowed value.</param>
        /// <param name="max">The maximum allowed value.</param>
        /// <returns>A valid integer entered by the user.</returns>
        private static int ReadInt(string prompt, int min, int max)
        {
            while (true)
            {
                Console.Write(prompt);
                string? input = Console.ReadLine();

                if (int.TryParse(input, out int value) && value >= min && value <= max)
                {
                    return value;
                }

                Console.WriteLine($"Please enter a number between {min} and {max}.");
            }
        }

        /// <summary>
        /// Pauses the game until the user presses Enter.
        /// </summary>
        private static void Pause()
        {
            Console.WriteLine("Press Enter to continue...");
            Console.ReadLine();
        }
    }
}