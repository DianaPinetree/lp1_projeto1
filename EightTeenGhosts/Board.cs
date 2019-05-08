using System;
using System.Collections.Generic;
using System.Text;

namespace EightTeenGhosts
{
    /// <summary>
    /// Gameboard class.
    /// Has the base structure of a Cell bi-dimensional array
    /// Contains all methods that change the board directly
    /// </summary>
    class Board
    {
        // Main board state, bi-dimensional array made of Cell's
        internal Cell[,] boardState;

        // Property for the ghosts that have left the castle, player 1 and 2
        /// <value> 
        /// Property array with 2 positions for the ghosts that are outside
        /// the git repository, ghosts that count for the win state.<br>
        /// Can only be changed from inside the Board class.
        /// </value>
        public CellColor[] ghostsOutside { get; private set; }

        // Constructor method of the board class
        public Board()
        {
            // Property array size of 2, 1 for each player
            ghostsOutside = new CellColor[2];

            // Initialize board states
            boardState = new Cell[5, 5];

            // Set Blank colored spaces of the board
            SetBlanks();
            SetEmptyColors();

            // Place the rest of the pieces
            SetMirrors();
            SetPortals();
        }

        /// <summary>
        /// Builds the mirrors in the board
        /// </summary>
        private void SetMirrors()
        {
            // Place the mirrors
            boardState[1, 1].Type = CellType.Mirror;
            boardState[1, 3].Type = CellType.Mirror;
            boardState[3, 1].Type = CellType.Mirror;
            boardState[3, 3].Type = CellType.Mirror;
        }

        /// <summary>
        /// Builds the portals in the board
        /// </summary>
        private void SetPortals()
        {
            // Place the portals
            boardState[0, 2].Type = CellType.Portal;
            boardState[0, 2].Color = CellColor.Red;
            boardState[2, 4].Type = CellType.Portal;
            boardState[2, 4].Color = CellColor.Yellow;
            boardState[4, 2].Type = CellType.Portal;
            boardState[4, 2].Color = CellColor.Blue;
        }

        /// <summary>
        /// Initializes the board with empty cells
        /// </summary>
        private void SetBlanks()
        {
            // build the initial state of the board
            for (int i = 0; i < boardState.GetLength(0); i++)
            {
                for (int j = 0; j < boardState.GetLength(1); j++)
                {
                    boardState[i, j] = new Cell(CellType.Empty);
                }
            }
        }

        /// <summary>
        /// Sets all the empty cells in the board
        /// </summary>
        private void SetEmptyColors()
        {
            // build the initial state of the board
            for (int i = 0; i < boardState.GetLength(0); i++)
            {
                for (int j = 0; j < boardState.GetLength(1); j++)
                {
                    // Top row, 0
                    if (i == 0 && (j + 1) % 3 == 1)
                        boardState[i, j].Color = CellColor.Blue;
                    else if (i == 0 && (j + 1) % 3 == 2)
                        boardState[i, j].Color = CellColor.Red;

                    // Second row, 1
                    if (i == 1)
                        boardState[i, j].Color = CellColor.Yellow;

                    // Third row, 2
                    if (i == 2 && (j + 1) % 2 == 1)
                        boardState[i, j].Color = CellColor.Red;
                    else if (i == 2 && (j + 1) % 2 == 0)
                        boardState[i, j].Color = CellColor.Blue;

                    // Fourth row, 3
                    if (i == 3 && (j + 1) % 3 == 1)
                        boardState[i, j].Color = CellColor.Blue;
                    else if (i == 3 && (j + 1) % 3 == 2)
                        boardState[i, j].Color = CellColor.Red;
                    else if (i == 3 && (j + 1) % 3 == 0)
                        boardState[i, j].Color = CellColor.Yellow;

                    // Fifth row, 4
                    if (i == 4 && (j + 1) % 4 == 1)
                        boardState[i, j].Color = CellColor.Yellow;
                    else if (i == 4 && (j + 1) % 4 == 2)
                        boardState[i, j].Color = CellColor.Red;
                    else if (i == 4 && (j + 1) % 4 == 0)
                        boardState[i, j].Color = CellColor.Blue;
                }
            }
        }

        /// <summary>
        /// Sets a position of the board with a ghost cell and a given color
        /// </summary>
        /// <param name="position">
        /// Position of the ghost
        /// </param>
        /// <param name="color">
        /// Color of the ghost
        /// </param>
        /// <param name="type">
        /// CellType is being replaced in the board position
        /// </param>
        public void SetPosition(Position position, 
            CellColor color, CellType type)
        {
            boardState[position.x, position.y].Type = type;
            boardState[position.x, position.y].Color = color;
        }

        
        /// <summary>
        /// Moves a ghost to a position given by the player.<br> 
        /// The input is given through the arrow keys.
        /// </summary>
        /// <param name="ghostPos"> 
        /// Initial Position of the ghost you want to move
        /// </param>
        public void MoveGhost(Position ghostPos)
        {
            CellColor ghostColour;
            Console.WriteLine("What direction will you move to?\n" +
                "Select your direction with the arrow keys.");
            switch (Console.ReadKey().Key)
            {
                case (ConsoleKey.DownArrow):
                    ghostColour = boardState[ghostPos.x, ghostPos.y].Color;
                    boardState[ghostPos.x, ghostPos.y].Type = CellType.Empty;
                    boardState[ghostPos.x + 1, ghostPos.y]
                        .Type = CellType.Ghost;
                    SetEmptyColors();
                    boardState[ghostPos.x + 1, ghostPos.y].Color = ghostColour;
                    ghostPos.x = ghostPos.x + 1;
                    break;
                case (ConsoleKey.UpArrow):
                    ghostColour = boardState[ghostPos.x, ghostPos.y].Color;
                    boardState[ghostPos.x, ghostPos.y].Type = CellType.Empty;
                    boardState[ghostPos.x - 1, ghostPos.y]
                        .Type = CellType.Ghost;
                    SetEmptyColors();
                    boardState[ghostPos.x - 1, ghostPos.y].Color = ghostColour;
                    ghostPos.x = ghostPos.x - 1;
                    break;
                case (ConsoleKey.LeftArrow):
                    ghostColour = boardState[ghostPos.x, ghostPos.y].Color;
                    boardState[ghostPos.x, ghostPos.y].Type = CellType.Empty;
                    boardState[ghostPos.x, ghostPos.y - 1]
                        .Type = CellType.Ghost;
                    SetEmptyColors();
                    boardState[ghostPos.x, ghostPos.y - 1]
                        .Color = ghostColour;
                    ghostPos.y = ghostPos.y - 1;
                    break;
                case (ConsoleKey.RightArrow):
                    ghostColour = boardState[ghostPos.x, ghostPos.y].Color;
                    boardState[ghostPos.x, ghostPos.y].Type = CellType.Empty;
                    boardState[ghostPos.x, ghostPos.y + 1]
                        .Type = CellType.Ghost;
                    SetEmptyColors();
                    boardState[ghostPos.x, ghostPos.y + 1].Color = ghostColour;
                    ghostPos.y = ghostPos.y + 1;
                    break;
            }
            
        }
    }
}
