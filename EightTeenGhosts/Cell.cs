using System;
using System.Collections.Generic;
using System.Text;

namespace EightTeenGhosts
{
    class Cell
    {
        public CellType Type { get; set; }

        public CellColor Color { get; set; }

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
