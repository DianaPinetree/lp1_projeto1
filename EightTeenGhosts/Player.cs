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
        public string PlayerName { get; set;}
        private Cell[] playerGhosts;

        // Constructor that receives a player name
        public Player(string playerName)
        {
            PlayerName = playerName;
            playerGhosts = new Cell[9];
        }

        public void AppendGhost(Position position, CellColor color)
        {
            // Type that will be added to the array of ghosts
            CellType type = CellType.Ghost;

            for (int i = 0; i < playerGhosts.Length; i++)
            {
                if (playerGhosts[i] != null)
                {
                    playerGhosts[i] = new Cell(type, color, position);
                    break;
                }
            }
        }

        /// <summary>
        /// Static class to get a color from player input
        /// </summary>
        /// <returns> Returns a Color of type CellColor</returns>
        public static CellColor PickColor()
        {
            // Color and player input
            CellColor color;
            int playerColor;

            // Ask the color and get the input
            Console.WriteLine("What color of ghost do you want to place? " +
                "red: 1, blue: 2, yellow: 3");
            playerColor = Convert.ToInt32(Console.ReadLine());

            // Compare and return the corresponding color
            if (playerColor == 1)
            {
                color = CellColor.Red;
                return color;
            }
            else if (playerColor == 2)
            {
                color = CellColor.Blue;
                return color;
            }
            else
            {
                color = CellColor.Yellow;
                return color;
            }
        }

        /// <summary>
        /// Gets a a position with a user input from a number from 1 to 6
        /// 6 being the max number of empty cells in 
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
            Position ghostPosition;
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
                            ghostPosition = new Position(i,j);
                            return ghostPosition;
                        }
                        cellIndex++;
                    }
                }
            }
            return null;
        }
    }
}
