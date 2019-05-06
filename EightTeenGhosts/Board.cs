using System;
using System.Collections.Generic;
using System.Text;

namespace EightTeenGhosts
{
    class Board
    {
        internal Cell[,] boardState;

        // Property for the ghosts that have left the castle, player 1 and 2
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
            SetGhost();
            MoveGhost(0, 0, 1, 0);
            MoveGhost(1, 0, 2, 0);
        }

        private void SetMirrors()
        {
            // Place the mirrors
            boardState[1, 1].Type = CellType.Mirror;
            boardState[1, 3].Type = CellType.Mirror;
            boardState[3, 1].Type = CellType.Mirror;
            boardState[3, 3].Type = CellType.Mirror;
        }

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

        private void SetGhost()
        {
            boardState[0, 0].Type = CellType.Ghost;
            boardState[0, 0].Color = CellColor.Blue;
        }

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

        CellColor previousColor1;
        CellColor previousColor2;

        public void MoveGhost(int xI, int yI, int xF, int yF)
        {
            previousColor1 = boardState[xI, yI].Color;
            previousColor2 = boardState[xF, yF].Color;
            boardState[xI, yI].Type = CellType.Empty;
            boardState[xF, yF].Type = CellType.Ghost;
            boardState[xI, yI].Color = previousColor1;
            previousColor1 = boardState[xF, yF].Color;
            boardState[xF, yF].Color = previousColor2;
        }
    }
}
