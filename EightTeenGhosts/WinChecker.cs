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

    }
}
