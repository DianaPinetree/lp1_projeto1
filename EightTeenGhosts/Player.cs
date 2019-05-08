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
        int rNum = 0;
        int bNum = 0;
        int yNum = 0;

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

        // Constructor that receives a player name
        /// <summary>
        /// Constructor that initializes the player's ghost array 
        /// as well as the custom player name
        /// </summary>
        /// <param name="playerName"></param>
        public Player(string playerName)
        {
            PlayerName = playerName;
            PlayerGhosts = new Cell[9];
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
                "red: 1, blue: 2, yellow: 3");
            playerColor = Convert.ToInt32(Console.ReadLine());

            //Checks if the player can put more ghosts of a certain color
            //ColorCheck();

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
                        if (ghost.Position.x == i && ghost.Position.y == j 
                            && cellIndex == inputIndex)
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
                        // Create a new position with the x,y coordinates

                        ghostPosition = new Position(i, j);
                        return ghostPosition;

                    }
                    else
                        cellIndex++;
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
    }
}
