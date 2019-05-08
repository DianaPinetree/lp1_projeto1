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
        public bool IsWin(Cell[] playerGhosts)
        {
            if ((CumulativeColor(playerGhosts) & winColor) == winColor)
            {
                return true;
            }
            else
                return false;
        }

        private CellColor CumulativeColor(Cell[] playerGhosts)
        {
            CellColor color;
            color = CellColor.White;
            foreach (Cell ghost in playerGhosts)
                color |= ghost.Color;
            return color;
        }

        public CellColor CombatCheck(CellColor attacker, CellColor defender)
        {
            switch (determineWinner(attacker, defender))
            {
                case true: Console.WriteLine("Player1 won the fight!");
                    return attacker;
                default:
                    Console.WriteLine("Player2 won the fight!");
                    return defender;
            }
        }

        private bool determineWinner(CellColor color1, 
            CellColor color2)
        {
            if (color1 == CellColor.Red && color2 == CellColor.Blue)
                return true;
            else if (color1 == CellColor.Blue && color2 == CellColor.Yellow)
                return true;
            else if (color1 == CellColor.Yellow && color2 == CellColor.Red)
                return true;
            else
                return false;
        }

    }
}
