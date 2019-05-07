using System;
using System.Collections.Generic;
using System.Text;

namespace EightTeenGhosts
{
    /// <summary>
    /// Position class to save an x and y position of the board
    /// </summary>
    class Position
    {
        // Variables of an x, y position
        /// <value>
        /// Gets and Sets the value of X coordinate of a position
        /// </value>
        public int x { set; get; }
        /// <value>
        /// Gets and Sets the value of Y coordinate of a position
        /// </value>
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
