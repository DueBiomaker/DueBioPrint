using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace BioPrint.model.slic3r
{
    public enum GCodeFlavor
    {
        [Description("E_REPRAP")]//RepRap (Marlin/Sprinter/Repetier)
        reprap,
        [Description("E_TEACUP")]//Teacup
        teacup,
        [Description("E_MAKERWAVE")]//MakerWare (MakerBot)
        makerware,
        [Description("E_SAILFISH")]//Sailfish (MakerBot)
        sailfish,
        [Description("E_MACH3_LINUXCNC")]//Mach3/LinuxCNC
        mach3,
        [Description("E_MACHINEKIT")]//Machinekit
        machinekit,
        [Description("E_NO_EXTRUSION")]//No extrusion
        no_extrusion
    }
}
