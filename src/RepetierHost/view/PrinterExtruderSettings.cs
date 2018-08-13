using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using RepetierHost.model.slic3r;

namespace RepetierHost.view
{
    public partial class PrinterExtruderSettings : UserControl
    {
        public ExtruderSettings ExtruderSettings { get; set; }

        public PrinterExtruderSettings()
        {
            InitializeComponent();
        }

        public void LoadSettings(ExtruderSettings settings)
        {
            ExtruderSettings = settings;
            PrepareBindings();
        }

        public void PrepareBindings()
        {
            tbNozzleDiameter.DataBindings.Add("Text", ExtruderSettings, "NozzleDiameter", false, DataSourceUpdateMode.OnPropertyChanged);
            tbExtruderXOffset.DataBindings.Add("Text", ExtruderSettings, "ExtruderXOffset", false, DataSourceUpdateMode.OnPropertyChanged);
            tbExtruderYOffset.DataBindings.Add("Text", ExtruderSettings, "ExtruderYOffset", false, DataSourceUpdateMode.OnPropertyChanged);

            tbRetractLength.DataBindings.Add("Text", ExtruderSettings, "RetractLength", false, DataSourceUpdateMode.OnPropertyChanged);
            tbRetractLift.DataBindings.Add("Text", ExtruderSettings, "RetractLift", false, DataSourceUpdateMode.OnPropertyChanged);
            nbRetractSpeed.DataBindings.Add("Value", ExtruderSettings, "RetractSpeed", false, DataSourceUpdateMode.OnPropertyChanged);
            tbRetractRestartExtra.DataBindings.Add("Text", ExtruderSettings, "RetractRestartExtra", false, DataSourceUpdateMode.OnPropertyChanged);
            tbRetractBeforeTravel.DataBindings.Add("Text", ExtruderSettings, "RetractBeforeTravel", false, DataSourceUpdateMode.OnPropertyChanged);
            cbRetractLayerChange.DataBindings.Add("Checked", ExtruderSettings, "RetractLayerChange", false, DataSourceUpdateMode.OnPropertyChanged);
            cbWipe.DataBindings.Add("Checked", ExtruderSettings, "Wipe", false, DataSourceUpdateMode.OnPropertyChanged);

            tbRetractLengthToolchange.DataBindings.Add("Text", ExtruderSettings, "RetractLengthToolchange", false, DataSourceUpdateMode.OnPropertyChanged);
            tbRetractRestartExtraToolchange.DataBindings.Add("Text", ExtruderSettings, "RetractRestartExtraToolchange", false, DataSourceUpdateMode.OnPropertyChanged);
        }

    }
}
