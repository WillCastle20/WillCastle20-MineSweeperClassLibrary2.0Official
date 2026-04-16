/*Darius Drake William Castellanos
 * CST-250
 * Milestone 5
 * Updated by Will Castellanos
 * 2/17/26
 */

namespace MinesweeperGUI
{
    /// <summary>
    /// Provides the main entry point for the Minesweeper GUI application.
    /// </summary>
    internal static class Program
    {
        /// <summary>
        /// Starts the Minesweeper GUI application.
        /// </summary>
        [STAThread]
        private static void Main()
        {
            ApplicationConfiguration.Initialize();
            Application.Run(new FrmStart());
        }
    }
}