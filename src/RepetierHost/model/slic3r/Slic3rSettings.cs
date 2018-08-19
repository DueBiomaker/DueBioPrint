using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BioMaker.model.slic3r
{
    public class Slic3rSettings
    {
        public PrintSettings PrintSettings { get; set; }
        public FilamentSettings FilamentSettings { get; set; }
        public PrinterSettings PrinterSettings { get; set; }

        public override string ToString()
        {
            StringBuilder builder = new StringBuilder();



            return builder.ToString();
        }
    }
}
