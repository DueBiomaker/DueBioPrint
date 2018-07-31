using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace RepetierHost.model.slic3r
{
    public enum  PrinterSettingsCategory
    {
        [Description("General")]
        General,
        [Description("Custom G-code")]
        CustomGcode,
        [Description("Extruders")]
        Extruders
    }
}
