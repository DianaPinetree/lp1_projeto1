using System;
using System.Collections.Generic;
using System.Text;

namespace EightTeenGhosts
{
    /// <summary>
    /// Represents a player from the game
    /// </summary>
    class Player
    {
        // The number of ghosts a player has of a certain color
        private int rNum = 0;
        private int bNum = 0;
        private int yNum = 0;

        /// <value>
        /// Gets and Sets the name of the player of a Player instance.
        /// </value>
        public string PlayerName { get; set; }

        // Array for the Player's owned ghosts
        /// <value>
        /// Cell array property for the player's owned ghosts with a get and a
        /// private set
        /// </value>
        public Cell[] PlayerGhosts { get; private set; }

        public Cell[] Dungeon { get; private set; }

        // Property for the ghosts that have left the castle, player 1 and 2
        /// <value> 
        /// Property array with 2 positions for the ghosts that are outside
        /// the git repository, ghosts that count for the win state.<br>
        /// Can only be changed from inside the Board class.
        /// </value>
        public Cell[] ghostsOutside { get; private set; }

        // Constructor that receives a player name
        /// <summary>
        /// Constructor that initializes the player's ghost array 
        /// as well as the custom player name
        /// </summary>
        /// <param name="playerName"></param>
        public Player(string playerName)
        {
            PlayerName = playerName;
            ghostsOutside = new Cell[9];
            Dungeon = new Cell[9];
            PlayerGhosts = new Cell[9];
            InitializePools();
        }

        private void InitializePools()
        {
            for (int i = 0; i < 9; i++)
            {
                ghostsOutside[i] = new Cell(CellType.Ghost);
                Dungeon[i] = new Cell(CellType.Ghost);
            }
        }

        /// <summary>
        /// Inserts a new ghost to the player's ghost array
        /// </summary>
        /// <param name="position"> 
        /// Position in the gameBoard of the ghost
        /// </param>
        /// <param name="color">
        /// Color of the ghost
        /// </param>
        public void AppendGhost(Position position, CellColor color)
        {
            // Type that will be added to the array of ghosts
            CellType type = CellType.Ghost;

            for (int i = 0; i < PlayerGhosts.Length; i++)
            {
                if (PlayerGhosts[i] == null)
                {
                    PlayerGhosts[i] = new Cell(type, color, position);
                    break;
                }
            }
        }

        public void RemoveGhost(Position position, string placeArrayName)
        {
            int index;
            index = 0;
            for (int i = 0; i < PlayerGhosts.Length; i++)
            {
                if (PlayerGhosts[i].Position == position)
                    index = i;
            }
            if (placeArrayName == "Dungeon")
            {
                Dungeon[index] = PlayerGhosts[index];
                PlayerGhosts[index].Position.x = 6;
            }
            else if (placeArrayName == "Outside")
            {
                ghostsOutside[index] = PlayerGhosts[index];
                PlayerGhosts[index].Position.x = 6;
            }
        }

        /// <summary>
        /// Class to get a color from player input
        /// </summary>
        /// <returns> Returns a Color of type CellColor</returns>
        public CellColor PickColor()
        {
            // Color and player input
            CellColor color;
            int playerColor;

            // Ask the color and get the input
            Console.WriteLine("What color of ghost do you want to place? " +
                "red: 1, blue: 2, yellow: 3" +
                "\n\nPress 4 for help.");
            playerColor = Convert.ToInt32(Console.ReadLine());

            // Compare and return the corresponding color
            if (playerColor == 1 && rNum < 3)
            {
                color = CellColor.Red;
                rNum++;
                // Debug of above
                Console.WriteLine(rNum);
                return color;
            }
            else if (playerColor == 2 && bNum < 3)
            {
                color = CellColor.Blue;
                bNum++;
                // Debug of above
                Console.WriteLine(bNum);
                return color;
            }
            else if (playerColor == 3 && yNum < 3)
            {
                color = CellColor.Yellow;
                yNum++;
                // Debug of above
                Console.WriteLine(yNum);
                return color;
            }
            else
            {
                Console.WriteLine("Pick a valid colour or " +
                    "one that still has ghosts for you to place.");
                return PickColor();
            }
        }

        public int PickAction()
        {
            int action;

            action = Convert.ToInt32(Console.ReadLine());
            return action;
        }

        public int PositionToGhost(Position position)
        {
            int counter;
            counter = 0;
            foreach (Cell ghost in PlayerGhosts)
            {
                if (ghost.Position == position)
                    return counter;
                else
                    counter++;
            }

            return 0;
        }

        public Position GetPosition(Board board)
        {
            // Return position, player input number and cell number vars
            Position ghostPosition;
            int inputIndex;
            int cellIndex;

            // Get a number between 1 and 9 from the player
            inputIndex = Convert.ToInt32(Console.ReadLine());

            // Force it to be between 1 and 9
            inputIndex = Math.Clamp(inputIndex, 1, 9);
            cellIndex = 1;

            ghostPosition = new Position();
            // get the corresponding position
            for (int i = 0; i < board.boardState.GetLength(0); i++)
            {
                for (int j = 0; j < board.boardState.GetLength(1); j++)
                {
                    foreach (Cell ghost in PlayerGhosts)
                    {
                        if (ghost.Position.x == i 
                            && ghost.Position.y == j)
                        {
                            ghostPosition = ghost.Position;
                            break;
                        }
                        else
                        {
                            continue;
                        }
                    }
                    if (ghostPosition != null)
                    {
                        cellIndex++;
                        if (cellIndex == inputIndex)
                        {
                            // Create a new position with the x,y coordinates
                            ghostPosition = new Position(i, j);
                            return ghostPosition;
                        }
                    }
                }
            }
            return null;
        }

        /// <summary>
        /// Gets a a position with a user input from a number from 1 to 6
        /// <br>6 being the max number of empty cells in 
        /// any given moment of 1 color
        /// </summary>
        /// <param name="board">
        /// Board on where to get the position from
        /// </param>
        /// <param name="color">
        /// What color you want to search for in the board
        /// </param>
        /// <returns>
        /// Returns the position x,y of the cell chosen by the player
        /// </returns>
        public Position GetPosition(Board board, CellColor color)
        {
            // Return position, player input number and cell number vars
            Position cellPosition;
            int inputIndex;
            int cellIndex;

            // Get a number between 1 and 6 from the player
            inputIndex = Convert.ToInt32(Console.ReadLine());

            // Force it to be between 1 and 6
            inputIndex = Math.Clamp(inputIndex, 1, 6);
            cellIndex = 1;

            // get the corresponding position
            for (int i = 0; i < board.boardState.GetLength(0); i++)
            {
                for (int j = 0; j < board.boardState.GetLength(1); j++)
                {
                    // If the color is the same as the parameter and the cell
                    // is empty, add 1 to cellIndex
                    if (board.boardState[i, j].Color == color &&
                        board.boardState[i, j].Type == CellType.Empty)
                    {
                        // Check if the index is the same as the player input
                        if (inputIndex == cellIndex)
                        {
                            // Create a new position with the x,y coordinates
                            cellPosition = new Position(i, j);
                            return cellPosition;
                        }
                        cellIndex++;
                    }
                }
            }
            return null;
        }


        public void GetHelp()
        {
            // Chars
            char help;
            char helpOption;

            // Asks the player if he needs help
            Console.WriteLine("If you want help regarding" +
                " anything in the game type H.\n" +
                "If you don´t just type X.");

            //Registers the player input in the help char 
            //after converting the input
            help = Convert.ToChar(Console.ReadLine());

            if (help == 'h' || help == 'H')
            {
                // Gives the player the help options
                Console.WriteLine("Please select one of " +
                    "the following options:\n" +
                    "\tWhat is the board setup? - B\n" +
                    "\tHow do I win? - W\n" +
                    "\tWhat am I looking at? - L\n" +
                    "\tHow does movement and mirrors work? - M\n" +
                    "\tHow does combat work? - C\n" +
                    "\tWhat are portals? - P\n" +
                    "\tWhat is the dungeon? - D\n" +
                    "If you want to go back to the game press X");

                //Registers the player input in the helpOption string
                helpOption = Convert.ToChar(Console.ReadLine());

                // Calls the methods in text class
                if (helpOption == 'b' || helpOption == 'B')
                {
                    Text.BoardComponentsText();
                    GetHelp();
                }
                else if (helpOption == 'w' || helpOption == 'W')
                {
                    Text.GoalsText();
                    GetHelp();
                }
                else if (helpOption == 'l' || helpOption == 'L')
                {
                    Text.BoardLayoutText();
                    GetHelp();
                }
                else if (helpOption == 'm' || helpOption == 'M')
                {
                    Text.MovementsText();
                    GetHelp();
                }
                else if (helpOption == 'c' || helpOption == 'C')
                {
                    Text.CombatText();
                    GetHelp();
                }
                else if (helpOption == 'p' || helpOption == 'P')
                {
                    Text.PortalText();
                    GetHelp();
                }
                else if (helpOption == 'd' || helpOption == 'D')
                {
                    Text.DungeonText();
                    GetHelp();
                }
                else if (helpOption == 'x' || helpOption == 'X')
                {
                    PickColor();
                }
                else
                {
                    Console.WriteLine("For someone who needs help, you aren't being very helpful.");
                    GetHelp();
                    return;
                }
            }
            else if (help == 'x' || help == 'X')
            {
                PickColor();
            }
            else
            {
                Console.WriteLine("For someone who needs help, you aren't being very helpful.");
                GetHelp();
                return;
            }
        }
    }
}
