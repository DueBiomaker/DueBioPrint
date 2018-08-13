using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace RepetierHost.model.slic3r
{
    public enum  FilamentSettingsCategory
    {
        [Description("E_FILAMENT")]//Filament
        Filament,
        [Description("E_COOLING")]//Cooling
        Cooling
    }
}
