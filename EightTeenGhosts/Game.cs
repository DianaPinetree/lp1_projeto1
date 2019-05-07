using System;
using System.Collections.Generic;
using System.Text;

namespace EightTeenGhosts
{
    /// <summary>
    /// Game logic and run methods
    /// </summary>
    class Game
    {
        // VARIABLES
        // Turn Counter
        private int turns;

        // Current playing player
        private Player currentPlayer;

        // Players
        private Player player1;
        private Player player2;

        // Board and win checker instances
        private Board gameBoard;
        private WinChecker winCheck;

        public Game()
        {
            winCheck = new WinChecker();
            gameBoard = new Board();

        }

        /// <summary>
        /// Initializes players
        /// Players are asked to input their names
        /// </summary>
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

        /// <summary>
        /// Contains the whole game logic
        /// </summary>
        public void Run()
        {
            // Encoding for UTF8 Chars
            Console.OutputEncoding = Encoding.UTF8;
            InitializePlayers();
            StartGame();
            GameLoop();
            Console.Read();
        }

        /// <summary>
        /// Main loop of the game
        /// </summary>
        private void GameLoop()
        {
            Console.Clear();
            // Game Loop
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

                // Exit key
                if (Console.ReadKey().Key == ConsoleKey.Escape)
                    gameBoard.ghostsOutside[0] = CellColor.Blue | CellColor.Yellow | CellColor.Red;
            }
        }

        // Called before starting a game
        /// <summary>
        /// Called before starting the game, method responsible for placing
        /// the ghosts and giving the initial messages
        /// </summary>
        private void StartGame()
        {
            turns = 0;

            Renderer.DrawBoard(gameBoard);
            Continue();

            // Place the first ghost, first player
            PlaceStartingGhosts(1);
            Console.Clear();

            // Place the 2nd and 3rd ghosts, second player
            PlaceStartingGhosts(2, 2);

            for (int i = 0; i < 15; i++)
            {
                Console.Clear();
                PlaceStartingGhosts(1, i % 2);
            }
            Continue();
        }

        /// <summary>
        /// Simple method to add a stop to a loop with elegance
        /// </summary>
        private void Continue()
        {
            Console.WriteLine("Press <Enter> to continue");
            Console.ReadKey();
        }

        /// <summary>
        /// Function that translates player input to the board and places
        /// the corresponding color and position of a ghost/s
        /// </summary>
        /// <param name="numberOfGhosts">
        /// Number of how many ghosts you want to place for a said player
        /// </param>
        /// <param name="player">
        /// Player that will place the ghosts
        /// </param>
        private void PlaceStartingGhosts(int numberOfGhosts, int player = 0)
        {
            CellColor color;

            if (player == 0)
                currentPlayer = player1;
            else
                currentPlayer = player2;

            Console.WriteLine($"Player {currentPlayer.PlayerName}");
            for (int i = 0; i < numberOfGhosts; i++)
            {
                color = Player.PickColor();
                Renderer.DrawBoardColor(color, gameBoard);
                Position ghostPosition;
                ghostPosition = currentPlayer.GetPosition(gameBoard, color);
                currentPlayer.AppendGhost(ghostPosition, color);

                gameBoard.SetPosition(ghostPosition, color);
            }
        }
    }
}
