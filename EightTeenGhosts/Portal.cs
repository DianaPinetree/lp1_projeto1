using System;
using System.Collections.Generic;
using System.Text;

namespace EightTeenGhosts
{
    /// <summary>
    /// Defines the Portal object of the game board<br> Has the rotate functions
    /// of a Portal cell.
    /// </summary>
    class Portal
    {
        // Color
        private CellColor color;
        // Position of the portal in the board
        private Position position;
        // Possible open sides for the portal
        private static string[] openSides;

        /// <value>
        /// Contains the current open side of the portal
        /// </value>>
        public string openSide { get; private set; }

        static Portal()
        {
            openSides = new string[4] { "Up", "Right", "Down", "Left" };
        }

        public Portal(Position position, CellColor color, string startingSide)
        {
            this.color = color;
            this.position = position;
            openSide = startingSide;
        }

        /// <summary>
        /// Switches the open side to the next in the openSides static array
        /// </summary>
        public void SwitchSide()
        {
            int index;
            index = 0;

            for (int i = 0; i < openSides.Length - 1; i++)
            {
                if (openSides[i] == openSide) index = i;
            }
            openSide = GetNextSide(openSides, index);
        }

        /// <summary>
        /// Get function for the next value of the openSides static array
        /// </summary>
        /// <param name="sideArray"> Array of the possible sides</param>
        /// <param name="index"> Current side index in the array</param>
        /// <returns>
        /// Returns the index + 1 element of the given array
        /// </returns>
        private string GetNextSide(string[] sideArray, int index)
        {
            if ((index > sideArray.Length - 1) || index < 0)
                throw new Exception("Invalid Index");
            else if (index == sideArray.Length - 1)
                index = 0;
            else
                index++;

            return sideArray[index];
        }

        /// <summary>
        /// Creates a neighbour position of a portal instance from the
        /// current open side
        /// </summary>
        /// <returns>
        /// Returns the x,y coordinate of the created neighbour
        /// </returns>
        private Position Neighbours()
        {
            Position checkPos;
            checkPos = new Position(position.x, position.y);
            switch (openSide)
            {
                case "Up": checkPos.y--;
                    break;
                case "Right": checkPos.x++;
                    break;
                case "Down": checkPos.y++;
                    break;
                case "Left": checkPos.x--;
                    break;
            }

            return checkPos;
        }

        /// <summary>
        /// Checks for any ghosts in the neighbour cell
        /// </summary>
        /// <param name="p1Ghosts"> Ghost array for player 1</param>
        /// <param name="p2Ghosts"> Ghost array for player 2</param>
        /// <returns>
        /// Returns the position of the neighbour ghost facing the portal
        /// </returns>
        public Position GhostEnter(Cell[] p1Ghosts, Cell[] p2Ghosts)
        {
            Position ghostPos;
            ghostPos = new Position();

            // Check for player's 1 ghosts
            foreach (Cell ghost in p1Ghosts)
            {
                if (ghost.Position == Neighbours())
                    ghostPos = ghost.Position;
            }

            // Check for player's 2 ghosts
            foreach (Cell ghost in p2Ghosts)
            {
                if (ghost.Position == Neighbours())
                    ghostPos = ghost.Position;
            }

            return ghostPos;
        }
    }
}
