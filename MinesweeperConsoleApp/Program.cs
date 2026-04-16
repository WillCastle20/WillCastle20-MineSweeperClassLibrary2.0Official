/*Will Castellanos
 * CST-250
 * Milestone 2
 * 2/17/26
 */
using System;
using MinesweeperClassLibrary.BusinessLogicLayer;
using MinesweeperClassLibrary.Models;


            var logic = new BoardLogic();

            // Main gameplay board
            var board = new BoardModel(10);
            int difficultyLevel = 1;

logic.SetUpBombs(board, difficultyLevel);
            logic.CountBombsNearby(board);
            

            // REQUIRED for rewards to actually exist
            logic.SetUpRewards(board, 3);

            // Optional debug ("technically cheating") - turn OFF before final screenshots if you want
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
                Console.WriteLine("Minesweeper (Milestone 2)");
                Console.WriteLine($"Rewards Available: {board.RewardsRemaining}");
                Console.WriteLine("Actions: 1 = Visit, 2 = Flag, 3 = Use Reward (peek)");
                Console.WriteLine();

                PrintBoard(board, revealBombs: false);

                int row = ReadInt($"Enter row (0-{board.Size - 1}): ", 0, board.Size - 1);
                int col = ReadInt($"Enter col (0-{board.Size - 1}): ", 0, board.Size - 1);
                int action = ReadInt("Enter action (1=Visit, 2=Flag, 3=Use Reward): ", 1, 3);

                switch (action)
                {
                    case 1: // Visit
                        logic.VisitCell(board, row, col);
                        break;

                    case 2: // Flag toggle
                        logic.FlagCell(board, row, col);
                        break;

                    case 3: // Use Reward (peek)
                        bool? peek = logic.UseRewardPeek(board, row, col);

                        if (peek == null)
                        {
                            Console.WriteLine("No rewards available (or invalid cell).");
                        }
                        else if (peek == true)
                        {
                            Console.WriteLine(" Reward Peek: That cell IS a bomb!");
                            Console.WriteLine("Reward Peek: That cell IS a bomb!");
                        }
                        else
                        {
                            Console.WriteLine("Reward Peek: That cell is NOT a bomb!");
                        }

                        Pause();
                        break;
                }

                // Determine new state after the move
                state = logic.DetermineGameState(board);
            }

            // Game over screen
            Console.Clear();
            PrintBoard(board, revealBombs: true);

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
        

        // Player view: show ? if not visited
          void PrintBoard(BoardModel board, bool revealBombs)
        {
            int size = board.Size;

            // Column header
            Console.Write("   ");
            for (int col = 0; col < size; col++)
            {
                Console.Write($"{col,2} ");
            }
            Console.WriteLine();

            // Top border
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
                    var cell = board.Cells[row, col];

                    // Flagged cell (if not visited)
                    if (cell.IsFlagged && !cell.IsVisited)
                    {
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.Write(" F ");
                        Console.ResetColor();
                        continue;
                    }

                    // Not visited => ?
                    if (!cell.IsVisited)
                    {
                        Console.ForegroundColor = ConsoleColor.DarkGray;
                        Console.Write(" ? ");
                        Console.ResetColor();
                        continue;
                    }

                    // Visited bomb (only reveal if game over)
                    if (cell.IsBomb && revealBombs)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write(" B ");
                        Console.ResetColor();
                        continue;
                    }

                    // Visited safe cell => number or .
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

            // Bottom border
            Console.Write("   ");
            for (int col = 0; col < size; col++)
            {
                Console.Write("---");
            }
            Console.WriteLine("-");
        }

        // Debug answer key (optional)
         void PrintAnswers(BoardModel board)
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
                    var cell = board.Cells[row, col];

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

       int ReadInt(string prompt, int min, int max)
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

        void Pause()
{
    Console.WriteLine("Press Enter to continue...");
    Console.ReadLine();
}

 
