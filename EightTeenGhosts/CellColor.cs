using System;
using System.Collections.Generic;
using System.Text;

namespace EightTeenGhosts
{
    [Flags]
    enum CellColor
    {
        Red = 1 << 0,
        Blue = 1 << 1,
        Yellow = 1 << 2,
    }
}
