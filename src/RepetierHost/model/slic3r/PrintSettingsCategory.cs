using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace RepetierHost.model.slic3r
{
    public enum  PrintSettingsCategory
    {
        [Description("E_LAYERS_AND_PERIMETERS")]//Layers and Perimeters
        LayersAndPerimeters,
        [Description("E_INFILL")]//Infill
        Infill,
        [Description("E_SKIRT_AND_BRIM")]//Skirt and Brim
        SkirtAndBrim,
        [Description("E_SUPPORT_MATERIAL")]//Support Material
        SupportMaterial,
        [Description("E_SPEED")]//Speed
        Speed,
        [Description("E_MULTIPLE_EXTRUDERS")]//Multiple Extruders
        MultipleExtruders,
        [Description("E_ADVANCED")]//Advanced
        Advanced,
        [Description("E_OUTPUT_OPTIONS")]//Output Options
        OutputOptions,
        [Description("E_NOTES")]//Notes
        Notes
    }
}
