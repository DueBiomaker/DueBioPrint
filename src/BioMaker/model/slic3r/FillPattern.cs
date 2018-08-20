using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace BioMaker.model.slic3r
{
    public enum FillPattern
    {
        [Description("Rectilinear")]
        rectilinear,
        [Description("Line")]
        line,
        [Description("Concentric")]
        concentric,
        [Description("Honeycomb")]
        honeycomb,
        [Description("3D Honeycomb")]
        threedhoneycomb,
        [Description("Hilbert Curve")]
        hilbertcurve,
        [Description("Archimedean Chords")]
        archimedeanchords,
        [Description("Octagram Spiral")]
        octagramspiral
    }
}
