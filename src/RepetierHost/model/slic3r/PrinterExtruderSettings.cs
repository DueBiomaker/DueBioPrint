using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RepetierHost.model.slic3r
{
    public class PrinterExtruderSettings
    {
        public string NozzleDiameter { get; set; }
        public string ExtruderOffset { get; set; }
        public string RetractLength { get; set; }
        public string RetractLift { get; set; }
        public string RetractSpeed { get; set; }
        public string RetractRestartExtra { get; set; }
        public string RetractBeforeTravel { get; set; }
        public bool RetractLayerChange { get; set; }
        public bool Wipe { get; set; }
        public string RetractLengthToolchange { get; set; }
        public string RetractRestartExtraToolchange { get; set; }
    }
}
