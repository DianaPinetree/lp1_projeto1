using System;
using System.Collections.Generic;
using System.Text;

namespace EightTeenGhosts
{
    /// <summary>
    /// CellColor enumeration.
    /// Contains the 3 different colors a Cell can have
    /// </summary>
    [Flags]
    enum CellColor
    {
        Red = 1 << 0,
        Blue = 1 << 1,
        Yellow = 1 << 2,
        White = 1 << 3
    }
}
