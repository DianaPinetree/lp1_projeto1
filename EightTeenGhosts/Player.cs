using System;
using System.Collections.Generic;
using System.Text;

namespace EightTeenGhosts
{
    class Player
    {
        public string PlayerName { get; set;}

        public Player(string playerName)
        {
            PlayerName = playerName;
        }


        public static CellColor PickColor()
        {
            CellColor color;
            int playerColor;

            Console.WriteLine("What color of ghost do you want to place? " +
                "red: 1, blue: 2, yellow: 3");
            playerColor = Convert.ToInt32(Console.ReadLine());

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

        // Gets a position with a user input from a number from 1 to 6
        // 6 being the max number of empty cells in any given moment of 1 color
        public Position GetPosition(Board board, CellColor color)
        {
            Position ghostPosition;
            int inputIndex;
            int cellIndex;

            // Get a number between 1 and 6 from the player
            inputIndex = Convert.ToInt32(Console.ReadLine());
            inputIndex = Math.Clamp(inputIndex, 1, 6);
            cellIndex = 1;

            // get the corresponding position
            for (int i = 0; i < board.boardState.GetLength(0); i++)
            {
                for (int j = 0; j < board.boardState.GetLength(1); j++)
                {
                    if (board.boardState[i, j].Color == color &&
                        board.boardState[i, j].Type == CellType.Empty)
                    {
                        if (inputIndex == cellIndex)
                        {
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
