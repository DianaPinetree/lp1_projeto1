﻿using System;
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
        private Text gameText;

        public Game()
        {
            winCheck = new WinChecker();
            gameBoard = new Board();
            gameText = new Text();

        }

        /// <summary>
        /// Initializes players
        /// Players are asked to input their names
        /// </summary>
        private void InitializePlayers()
        {
            // Player name
            string playerName;

            // Asks for the name and saves it in player1
            Console.WriteLine("Player 1>>> A");
            Console.Write("\tWhat's your player name?: ");
            playerName = Console.ReadLine();

            player1 = new Player(playerName);

            // Asks for the name and saves it in player2
            Console.WriteLine("Player 2>>> B");
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

            // Initialize players
            InitializePlayers();

            // Start game
            StartGame();

            // Start main game loop
            GameLoop();

            // Wait for player input to close
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
                // Char used to print the current player's turn
                char turnChar;

                // Pick turn
                if (turns % 2 == 0)
                {
                    currentPlayer = player1;
                    turnChar = 'A';
                }
                else
                {
                    currentPlayer = player2;
                    turnChar = 'B';
                }
                turns++;

                // Render board without any changes & Player's name
                Console.WriteLine(currentPlayer.PlayerName + ": " + turnChar);
                Renderer.DrawBoard(gameBoard, player1);

                // Pick the current player action
                gameText.ActionsText();
                if (currentPlayer.PickAction() == 1)
                {
                    // Move a ghost
                    Renderer.EnumeratePlayerGhosts(currentPlayer, gameBoard);
                    gameBoard.MoveGhost(currentPlayer.GetPosition(gameBoard));
                }
                else
                {
                    // Get a ghost from the dungeon
                }
                // DO current player's actions

                //

                // Exit key, force win condition
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

            Renderer.DrawBoard(gameBoard, player1);
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
            Position ghostPosition;
            // Color of the ghost, saves the input color from the player
            CellColor color;

            // Checks the player from the parameter passed to the method
            if (player == 0)
                currentPlayer = player1;
            else
                currentPlayer = player2;

            // Writes on top of the screen which player's turn it is
            Console.WriteLine($"Player {currentPlayer.PlayerName}");

            // Loops with a max number of ghosts to put 
            for (int i = 0; i < numberOfGhosts; i++)
            {

                // Asks for a color
                color = currentPlayer.PickColor();

                // Renders the available respective color cells 
                Renderer.EnumerateBoardColor(color, gameBoard);

                // Translates a player input to a board position, saves it in
                // ghostPosition variable
                ghostPosition = currentPlayer.GetPosition(gameBoard, color);

                // Add the created ghost to the respective player's ghost list
                currentPlayer.AppendGhost(ghostPosition, color);

                // Sets the created ghost into the board position in gameBoard
                gameBoard.SetPosition(ghostPosition, color, CellType.Ghost);
            }
        }
    }
}
