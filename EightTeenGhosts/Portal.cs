using System;
using System.Collections.Generic;
using System.Text;

namespace EightTeenGhosts
{
    class Portal
    {
        // color
        private CellColor color;
        // position
        private Position position;
        // open side
        private static string[] openSides;
        public string openSide { get; private set; }

        static Portal()
        {
            openSides = new string[4] { "Up", "Right", "Down", "Left" };
        }

        public Portal(Position position, CellColor color)
        {
            this.color = color;
            this.position = position;
        }

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
    }
}
