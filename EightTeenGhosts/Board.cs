using System;
using System.Collections.Generic;
using System.Text;

namespace EightTeenGhosts
{
    class Board
    {
        internal CellState[,] boardState;

        public Board()
        {
            //Initialize board states
            boardState = new CellState[5, 5];

            //build the initial state of the board
            for (int i = 0; i < boardState.GetLength(0); i++)
            {
                for (int j = 0; j < boardState.GetLength(1); j++)
                {
                    //Top row, 0
                    if (i == 0 && (j + 1) % 3 == 1)
                        boardState[i, j] = CellState.EmptyBlue;
                    else if (i == 0 && (j + 1) % 3 == 2)
                        boardState[i, j] = CellState.EmptyRed;

                    //Second row, 1
                    if (i == 1)
                        boardState[i, j] = CellState.EmptyYellow;

                    //Third row, 2
                    if (i == 2 && (j + 1) % 2 == 1)
                        boardState[i, j] = CellState.EmptyRed;
                    else if (i == 2 && (j + 1) % 2 == 0)
                        boardState[i, j] = CellState.EmptyBlue;

                    //Fourth row, 3
                    if (i == 3 && (j + 1) % 3 == 1)
                        boardState[i, j] = CellState.EmptyBlue;
                    else if (i == 3 && (j + 1) % 3 == 2)
                        boardState[i, j] = CellState.EmptyRed;
                    else if (i == 3 && (j + 1) % 3 == 0)
                        boardState[i, j] = CellState.EmptyYellow;

                    //Fifth row, 4
                    if (i == 4 && (j + 1) % 4 == 1)
                        boardState[i, j] = CellState.EmptyYellow;
                    else if (i == 4 && (j + 1) % 4 == 2)
                        boardState[i, j] = CellState.EmptyRed;
                    else if (i == 4 && (j + 1) % 4 == 0)
                        boardState[i, j] = CellState.EmptyBlue;
                }
            }

            //Place the mirrors
            boardState[1, 1] = CellState.Mirror;
            boardState[1, 3] = CellState.Mirror;
            boardState[3, 1] = CellState.Mirror;
            boardState[3, 3] = CellState.Mirror;

            //Place the portals

        }
    }
}
