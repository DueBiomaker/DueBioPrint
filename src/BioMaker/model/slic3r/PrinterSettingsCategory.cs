using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace BioMaker.model.slic3r
{
    public enum  PrinterSettingsCategory
    {
        [Description("E_GENERAL")]//General
        General,
        [Description("E_CUSTOM_G_CODE")]//Custom G-code
        CustomGcode,
        [Description("E_EXTRUDERS")]//Extruders
        Extruders,
    }
}
