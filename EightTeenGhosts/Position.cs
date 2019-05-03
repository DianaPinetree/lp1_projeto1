using System;
using System.Collections.Generic;
using System.Text;

namespace EightTeenGhosts
{
    class Position
    {
        // Variables of an x, y position
        public int x { set; get; }
        public int y { set; get; }

        /// <summary>
        /// Constructor method for position object.
        /// </summary>
        /// <param name="_row">x position in the board</param>
        /// <param name="_col">y position in the board</param>
        public Position(int _row, int _col)
        {
            x = _row;
            y = _col;
        }
    }
}
