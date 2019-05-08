using System;
using System.Collections.Generic;
using System.Text;

namespace EightTeenGhosts
{
    /// <summary>
    /// This class soul purpose is to check at any time in the game if there's 
    /// any player in a winning position.<br> Check the rules of '18 ghosts' for
    /// the winning condition of the game
    /// </summary>
    class WinChecker
    {
        private CellColor winColor;

        public WinChecker()
        {
            winColor = CellColor.Red | CellColor.Blue | CellColor.Yellow;
        }

        /// <summary>
        /// Compares the ghosts outside the castle for the winning "color"<br>
        /// _color_ = Combination of all the colors using 
        /// CellColor Flags enumeration
        /// </summary>
        /// <param name="ghostsOutside"></param>
        /// <returns>
        /// Returns true if there's a winning player, 
        /// false if no one is winning
        /// </returns>
        public bool IsWin(CellColor[] ghostsOutside)
        {
            if ((winColor == ghostsOutside[0])
                || (winColor == ghostsOutside[1]))
            {
                return true;
            }
            else
                return false;
        }

        public CellColor CombatCheck(CellColor p1Color, CellColor p2Color)
        {
            switch (determineWinner((int)p1Color, (int)p2Color))
            {
                case null: Console.WriteLine("Invalid move");
                    return CellColor.White;
                case true: Console.WriteLine("Player1 won");
                    return p1Color;
                default:
                    Console.WriteLine("Player2 won");
                    return p2Color;
            }
        }

        bool? determineWinner(int player1Selection, int player2Selection)
        {

            bool?[,] winMatrix = {
            {null, false, true },
            {true, null, false },
            {false, true, null}
            };

            if (winMatrix[player1Selection, player2Selection] == null)
                return null;
            return (winMatrix[player1Selection, player2Selection] == true) ? true : false;
        }

    }
}
