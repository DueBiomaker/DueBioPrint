using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace RepetierHost.model.slic3r
{
    public enum GCodeFlavor
    {
        [Description("RepRap (Marlin/Sprinter/Repetier)")]
        reprap,
        [Description("Teacup")]
        teacup,
        [Description("MakerWare (MakerBot)")]
        makerware,
        [Description("Sailfish (MakerBot)")]
        sailfish,
        [Description("Mach3/LinuxCNC")]
        mach3,
        [Description("Machinekit")]
        machinekit,
        [Description("No extrusion")]
        no_extrusion
    }
}
