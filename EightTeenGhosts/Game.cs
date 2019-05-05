using System;
using System.Collections.Generic;
using System.Text;

namespace EightTeenGhosts
{
    class Game
    {
        private int turns;
        private Player currentPlayer;
        private Player player1;
        private Player player2;

        private Board gameBoard;
        private WinChecker winCheck;

        public Game()
        {
            winCheck = new WinChecker();
            gameBoard = new Board();

        }

        private void InitializePlayers()
        {
            string playerName;

            Console.WriteLine("Player 1>>>");
            Console.Write("\tWhat's your player name?: ");
            playerName = Console.ReadLine();

            player1 = new Player(playerName);

            Console.WriteLine("Player 2>>>");
            Console.Write("\tWhat's your player name?: ");
            playerName = Console.ReadLine();

            player2 = new Player(playerName);
        }

        public void Run()
        {
            // Encoding for UTF8 Chars
            Console.OutputEncoding = Encoding.UTF8;
            InitializePlayers();
            StartGame();
            GameLoop();
            Console.Read();
        }

        private void GameLoop()
        {
            Console.Clear();
            while (!winCheck.IsWin(gameBoard.ghostsOutside))
            {
                if (turns % 2 == 0)
                {
                    currentPlayer = player1;
                }
                else
                {
                    currentPlayer = player2;
                }
                turns++;
                Renderer.DrawBoard(gameBoard);
                Console.WriteLine(currentPlayer.PlayerName);
                if (Console.ReadKey().Key == ConsoleKey.Escape)
                    gameBoard.ghostsOutside[0] = CellColor.Blue | CellColor.Yellow | CellColor.Red;
            }
        }

        private void StartGame()
        {
            turns = 0;
            if (turns % 2 == 0)
            {
                currentPlayer = player1;
            }
            else
            {
                currentPlayer = player2;
            }
            turns++;
            Renderer.DrawBoard(gameBoard);
            Console.ReadKey();
            Console.Clear();
            Renderer.DrawBoardColor(CellColor.Red, gameBoard);
            Console.ReadKey();
        }
    }
}
