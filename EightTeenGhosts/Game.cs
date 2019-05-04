using System;
using System.Collections.Generic;
using System.Text;

namespace EightTeenGhosts
{
    class Game
    {
        private Board gameBoard;
        private WinChecker winCheck;
        public Game()
        {
            winCheck = new WinChecker();
            gameBoard = new Board();
        }

        public void Run()
        {
            // Encoding for UTF8 Chars
            Console.OutputEncoding = Encoding.UTF8;
            // Draw the game board
            GameLoop();
            Console.Read();
        }

        private void GameLoop()
        {
            while (!winCheck.IsWin(gameBoard.ghostsOutside))
            {
                Renderer.DrawBoard(gameBoard);

                if (Console.ReadKey().Key == ConsoleKey.Escape)
                    gameBoard.ghostsOutside[0] = CellColor.Blue | CellColor.Yellow | CellColor.Red;
            }
        }
    }
}
