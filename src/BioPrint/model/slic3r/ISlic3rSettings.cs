using BioPrint.controller;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BioPrint.model.slic3r
{
    public interface ISlic3rSettings
    {
        string ProfileName { get; set; }
        Slic3rSettingsCategory Category { get; }
        string FilePath { get; set; }
        void FillValue(string key, string input);
    }
}
