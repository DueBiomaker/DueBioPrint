using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace RepetierHost.model.slic3r
{
    public enum ExternalFillPattern
    {
        [Description("Rectilinear")]
        rectilinear,
        [Description("Concentric")]
        concentric,
        [Description("Hilbert Curve")]
        hilbertcurve,
        [Description("Archimedean Chords")]
        archimedeanchords,
        [Description("Octagram Spiral")]
        octagramspiral
    }
}
