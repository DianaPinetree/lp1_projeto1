using System;
using System.Collections.Generic;
using System.Text;

namespace EightTeenGhosts
{
    /// <summary>
    /// Main unit of the whole game, game board is built with this class
    /// </summary>
    class Cell
    {
        // Property for the type of the cell
        public CellType Type { get; set; }

        // Property for the color of the cell
        public CellColor Color { get; set; }

        // Property for the position of the cell
        public Position Position { get; set; }
        
        public Cell(CellType type)
        {
            Type = type;
        }

        public Cell(CellType type, CellColor color, Position position)
        {
            Type = type;
            Color = color;
            Position = position;
        }
    }
}
