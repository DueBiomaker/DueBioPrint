using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace RepetierHost.model.slic3r
{
    public enum  FilamentSettingsCategory
    {
        [Description("Filament")]
        Filament,
        [Description("Cooling")]
        Cooling
    }
}
