using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace RepetierHost.model.slic3r
{
    public enum SeamPosition
    {
        [Description("Random")]
        random,
        [Description("Nearest")]
        nearest,
        [Description("Aligned")]
        aligned
    }
}
