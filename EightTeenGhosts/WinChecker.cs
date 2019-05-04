using System;
using System.Collections.Generic;
using System.Text;

namespace EightTeenGhosts
{
    class WinChecker
    {
        private CellColor winColor;

        public WinChecker()
        {
            winColor = CellColor.Red | CellColor.Blue | CellColor.Yellow;
        }

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
