using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace RepetierHost.model.slic3r
{
    public enum  PrintSettingsCategory
    {
        [Description("Layers and Perimeters")]
        LayersAndPerimeters,
        [Description("Infill")]
        Infill,
        [Description("Skirt and Brim")]
        SkirtAndBrim,
        [Description("Support Material")]
        SupportMaterial,
        [Description("Speed")]
        Speed,
        [Description("Multiple Extruders")]
        MultipleExtruders,
        [Description("Advanced")]
        Advanced,
        [Description("Output Options")]
        OutputOptions,
        [Description("Notes")]
        Notes
    }
}
