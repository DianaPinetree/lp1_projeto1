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
        private string openSide;
        // Color
        public CellColor Color { get; set; }
        // Position of the portal in the board
        public Position Position { get; private set; }
        // Portal print char
        private char portalChar;
        // Possible open sides for the portal
        private static string[] openSides;

        /// <value>
        /// Contains the current open side of the portal
        /// </value>>
        public string OpenSide
        {
            get
            {
                return openSide;
            }
            set
            {
                openSide = value;
                SetSideChar(openSide);
            }
        }

        static Portal()
        {
            openSides = new string[4] { "Up", "Right", "Down", "Left" };
        }

        public Portal(Position position, CellColor color, string startingSide)
        {
            Color = color;
            Position = position;
            OpenSide = startingSide;
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
                if (openSides[i] == OpenSide) index = i;
            }
            OpenSide = GetNextSide(openSides, index);
        }

        public char GetSideChar()
        {
            return portalChar;
        }

        private void SetSideChar(string side)
        {
            switch (side)
            {
                case "Up": portalChar = '\u02C4';
                        break;
                case "Right": portalChar = '\u02C3';
                        break;
                case "Down": portalChar = '\u02C5';
                        break;
                case "Left": portalChar = '\u02C2';
                        break;
            }
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
        /// Creates a neighbor position of a portal instance from the
        /// current open side
        /// </summary>
        /// <returns>
        /// Returns the x,y coordinate of the created neighbor
        /// </returns>
        private Position Neighbours()
        {
            Position checkPos;
            checkPos = new Position(Position.x, Position.y);
            switch (OpenSide)
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
        /// Checks for any ghosts in the neighbor cell
        /// </summary>
        /// <param name="p1Ghosts"> Ghost array for player 1</param>
        /// <param name="p2Ghosts"> Ghost array for player 2</param>
        /// <returns>
        /// Returns the position of the neighbor ghost facing the portal
        /// </returns>
        public Cell GhostEnter(List<Cell> playerGhosts)
        {
            Cell ghostToExit;
            ghostToExit = new Cell(CellType.Ghost);
            // Check for player's 1 ghosts
            foreach (Cell ghost in playerGhosts)
            {
                if (ghost.Position == Neighbours())
                {
                    ghostToExit = ghost;
                    return ghost;
                }
            }
            return null;
        }
    }
}
