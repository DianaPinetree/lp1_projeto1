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
        /// <value>
        /// Getter and Setter property for the CellType of the cell
        /// </value>
        public CellType Type { get; set; }

        // Property for the color of the cell
        /// <value>
        /// Getter and Setter property for the CellColor of the cell
        /// </value>
        public CellColor Color { get; set; }

        // Property for the position of the cell
        /// <value>
        /// Getter and Setter property for the Position of the cell
        /// </value>
        public Position Position { get; set; }
        
        /// <summary>
        /// Constructor that only inserts the type on the cell
        /// </summary>
        /// <param name="type">
        /// CellType that you want to place on the cell
        /// </param>
        public Cell(CellType type)
        {
            Type = type;
        }

        /// <summary>
        /// Constructor overload that receives a color and a position
        /// in addition to the type variable 
        /// </summary>
        /// <param name="type">CellType of the cell</param>
        /// <param name="color">CellColor of the cell</param>
        /// <param name="position">
        /// Position of the cell
        /// </param>
        /// <remarks>
        /// This overload is used when creating instances of the cell for the
        /// player ghost array
        /// </remarks>
        public Cell(CellType type, CellColor color, Position position)
        {
            Type = type;
            Color = color;
            Position = position;
        }
    }
}
