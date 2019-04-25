using System;
using System.Collections.Generic;
using System.Text;

namespace EightTeenGhosts
{
    [Flags]
    enum Rotation
    {
        Up = 1 << 0,
        Right = 1 << 1,
        Down = 1 << 2,
        Left = 1 << 3
    }
}
