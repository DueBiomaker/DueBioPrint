using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace RepetierHost.model.slic3r
{
    public enum SupportMaterialPattern
    {
        [Description("Rectilinear")]
        rectilinear,
        [Description("Rectilinear Grid")]
        rectilinear_grid,
        [Description("Honeycomb")]
        honeycomb,
        [Description("Pillars")]
        pillars,
    }
}
