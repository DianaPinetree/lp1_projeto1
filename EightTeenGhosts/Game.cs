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
        private Text gameText;
        private Portal[] portals;

        private bool forceEnd;

        public Game()
        {
            winCheck = new WinChecker();
            gameBoard = new Board();
            gameText = new Text();
            forceEnd = false;

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

        private void InitializePortals()
        {
            portals = new Portal[3];
            portals[0] = new Portal(new Position(0,2), CellColor.Red,
                "Up");
            portals[1] = new Portal(new Position(2, 4), CellColor.Yellow,
                "Right");
            portals[2] = new Portal(new Position(4, 2), CellColor.Blue,
                "Down");
        }

        /// <summary>
        /// Contains the whole game logic
        /// </summary>
        public void Run()
        {
            // Encoding for UTF8 Chars
            Console.OutputEncoding = Encoding.UTF8;

            InitializePortals();
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
            while (!winCheck.IsWin(player1.GhostsOutside) ||
                !winCheck.IsWin(player2.GhostsOutside) || (forceEnd == true))
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
                Renderer.DrawBoard(gameBoard, 
                    player1.PlayerGhosts, player2.PlayerGhosts, portals);
                Renderer.DrawDungeon(currentPlayer);
                // Pick the current player action
                gameText.ActionsText();

                switch (currentPlayer.PickAction())
                {
                    case 1:
                        {
                            // Move a ghost
                            Renderer.EnumeratePlayerGhosts(currentPlayer,
                                gameBoard);

                            Position pos = currentPlayer.
                                GetPosition(gameBoard);
                          
                            currentPlayer.MoveGhost(pos, gameBoard);
                            break;
                        }
                    case 2:
                        {
                            // Get Ghost from dungeon
                            currentPlayer.PlaceGhost
                                (currentPlayer.RessurectGhost(), gameBoard);
                            break;
                        }
                }
                GhostCombat(player1, player2);
                // Check for any ghosts that can leave
                CheckForPortalsExit(player1);
                CheckForPortalsExit(player2);

                // Exit key, force win condition
                if (Console.ReadKey().Key == ConsoleKey.Escape)
                    forceEnd = true;
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
            Text.StartupText();
            Text.GetHelp();
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
            gameBoard.RestartBoard();
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
                Renderer.EnumerateBoardColor(color, gameBoard, CellType.Empty);

                // Translates a player input to a board position, saves it in
                // ghostPosition variable
                ghostPosition = currentPlayer.GetPosition(gameBoard, color);

                // Add the created ghost to the respective player's ghost list
                currentPlayer.PlayerGhosts.Add(new Cell(CellType.Ghost, color, ghostPosition));

                // Sets the created ghost into the board position in gameBoard
                gameBoard.SetPosition(ghostPosition, color, CellType.Ghost);
            }
        }

        private void CheckForPortalsExit(Player player)
        {
            foreach (Portal exit in portals)
            {
                if (exit.GhostEnter
                    (player.PlayerGhosts) == null)
                {
                    continue;
                }
                else
                {
                    player.GhostPushOut
                        (exit.GhostEnter(player.PlayerGhosts));
                }

            }
        }

        private void GhostCombat(Player player1, Player player2)
        {
            Cell ghostp1, ghostp2, ghostWin;
            ghostp1 = new Cell(CellType.Ghost);
            ghostp2 = new Cell(CellType.Ghost);
            foreach (Cell ghost1 in player1.PlayerGhosts)
            {
                // get the position from current ghost
                ghostp1 = ghost1;
                foreach (Cell ghost2 in player2.PlayerGhosts)
                {
                    // compare to all ghosts in player2 ghosts position
                    if (ghost1.Position == ghost2.Position)
                    {
                        // if 1 == 2 then break for loop
                        ghostp2 = ghost2;
                        break;
                    }
                    else continue;
                }
            }

            ghostWin = Fight(ghostp1, ghostp2);
            // whichever looses gets thrown into the respective player dungeon
            if (player1.PlayerGhosts.Find(x => x == ghostWin) == ghostp1)
            {
                player2.PlayerGhosts.Remove(ghostp2);
            }
            else
            {
                player1.PlayerGhosts.Remove(ghostp1);
            }
        }

        private Cell Fight(Cell ghost1, Cell ghost2)
        {
            CellColor ghostWinColor;
            ghostWinColor = winCheck.CombatCheck(ghost1.Color, ghost2.Color);

            if (ghostWinColor == ghost1.Color)
                return ghost1;
            else
                return ghost2;
        }
    }
}
