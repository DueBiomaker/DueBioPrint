using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RepetierHost.model.slic3r
{
    public interface ISlic3rSettings
    {
        string ProfileName { get; set; }
        string FilePath { get; set; }
        void FillValue(string key, string input);
    }
}
