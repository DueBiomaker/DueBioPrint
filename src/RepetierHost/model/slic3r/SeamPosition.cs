using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace RepetierHost.model.slic3r
{
    public enum SeamPosition
    {
        [Description("E_RANDOM")]//Random
        random,
        [Description("E_NEAREST")]//Nearest
        nearest,
        [Description("E_ALIGNED")]//Aligned
        aligned
    }
}
