using System;
using System.Collections.Generic;
using System.Text;

namespace EightTeenGhosts
{
    [Flags]
    enum CellState
    {
        EmptyRed = 1 << 0,
        EmptyYellow = 1 << 1,
        EmptyBlue = 1 << 2,
        GhostRed = 1 << 3,
        GhostYellow = 1 << 4,
        GhostBlue = 1 << 5,
        Mirror = 1 << 6,
        Portal = 1 << 7
    }
}
