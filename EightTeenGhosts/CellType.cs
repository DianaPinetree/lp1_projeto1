using System;
using System.Collections.Generic;
using System.Text;

namespace EightTeenGhosts
{
    [Flags]
    enum CellType
    {
        Empty,
        Ghost,
        Mirror,
        Portal
    }
}
