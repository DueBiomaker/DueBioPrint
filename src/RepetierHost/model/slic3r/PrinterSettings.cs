using RepetierHost.extensions;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace RepetierHost.model.slic3r
{
    public class PrinterSettings : ISlic3rSettings, INotifyPropertyChanged
    {
        private const string DEFAULT_VALUE = "0";

        public string ProfileName { get; set; }
        public string FilePath { get; set; }

        // General
        private string _BedShape;

        public string BedShape
        {
            get
            {
                return _BedShape;
            }
            set
            {
                _BedShape = value ?? DEFAULT_VALUE;
                OnPropertyChanged("BedShape");
            }
        }

        private string _ZOffset;

        public string ZOffset
        {
            get
            {
                return _ZOffset;
            }
            set
            {
                _ZOffset = value ?? DEFAULT_VALUE;
                OnPropertyChanged("ZOffset");
            }
        }

        private string _OctoprintHost;

        public string OctoprintHost
        {
            get
            {
                return _OctoprintHost;
            }
            set
            {
                _OctoprintHost = value ?? DEFAULT_VALUE;
                OnPropertyChanged("OctoprintHost");
            }
        }

        private string _OctoprintApikey;

        public string OctoprintApikey
        {
            get
            {
                return _OctoprintApikey;
            }
            set
            {
                _OctoprintApikey = value ?? DEFAULT_VALUE;
                OnPropertyChanged("OctoprintApikey");
            }
        }

        private string _GcodeFlavor;

        public string GcodeFlavor
        {
            get
            {
                return _GcodeFlavor;
            }
            set
            {
                _GcodeFlavor = value ?? DEFAULT_VALUE;
                OnPropertyChanged("GcodeFlavor");
            }
        }

        private bool _UseRelativeEDistances;

        public bool UseRelativeEDistances
        {
            get
            {
                return _UseRelativeEDistances;
            }
            set
            {
                _UseRelativeEDistances = value;
                OnPropertyChanged("UseRelativeEDistances");
            }
        }

        private bool _UseFirmwareRetraction;

        public bool UseFirmwareRetraction
        {
            get
            {
                return _UseFirmwareRetraction;
            }
            set
            {
                _UseFirmwareRetraction = value;
                OnPropertyChanged("UseFirmwareRetraction");
            }
        }

        private bool _UseVolumetricE;

        public bool UseVolumetricE
        {
            get
            {
                return _UseVolumetricE;
            }
            set
            {
                _UseVolumetricE = value;
                OnPropertyChanged("UseVolumetricE");
            }
        }

        private string _PressureAdvance;

        public string PressureAdvance
        {
            get
            {
                return _PressureAdvance;
            }
            set
            {
                _PressureAdvance = value ?? DEFAULT_VALUE;
                OnPropertyChanged("PressureAdvance");
            }
        }

        private string _VibrationLimit;

        public string VibrationLimit
        {
            get
            {
                return _VibrationLimit;
            }
            set
            {
                _VibrationLimit = value ?? DEFAULT_VALUE;
                OnPropertyChanged("VibrationLimit");
            }
        }

        // Custom G-code
        private string _StartGcode;

        public string StartGcode
        {
            get
            {
                return _StartGcode;
            }
            set
            {
                _StartGcode = value ?? DEFAULT_VALUE;
                OnPropertyChanged("StartGcode");
            }
        }

        private string _EndGcode;

        public string EndGcode
        {
            get
            {
                return _EndGcode;
            }
            set
            {
                _EndGcode = value ?? DEFAULT_VALUE;
                OnPropertyChanged("EndGcode");
            }
        }

        private string _BeforeLayerGcode;

        public string BeforeLayerGcode
        {
            get
            {
                return _BeforeLayerGcode;
            }
            set
            {
                _BeforeLayerGcode = value ?? DEFAULT_VALUE;
                OnPropertyChanged("BeforeLayerGcode");
            }
        }

        private string _LayerGcode;

        public string LayerGcode
        {
            get
            {
                return _LayerGcode;
            }
            set
            {
                _LayerGcode = value ?? DEFAULT_VALUE;
                OnPropertyChanged("LayerGcode");
            }
        }

        private string _ToolchangeGcode;

        public string ToolchangeGcode
        {
            get
            {
                return _ToolchangeGcode;
            }
            set
            {
                _ToolchangeGcode = value ?? DEFAULT_VALUE;
                OnPropertyChanged("ToolchangeGcode");
            }
        }

        // Extruder
        private List<PrinterExtruderSettings> _ExtrudersSettings;

        public List<PrinterExtruderSettings> ExtrudersSettings
        {
            get
            {
                if (_ExtrudersSettings == null)
                    _ExtrudersSettings = new List<PrinterExtruderSettings>();
                return _ExtrudersSettings;
            }
            set
            {
                _ExtrudersSettings = value;
                OnPropertyChanged("ExtrudersSettings");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string name)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

        private void FillExtrudersValue(string key, string input)
        {
            string[] values = input.Split(',');
            AdjustExtruderList(values.Length);

            for (int i = 0; i < values.Length; i++)
            {
                ExtrudersSettings[i].FillValue(key, input);
            }
        }

        private void AdjustExtruderList(int size)
        {
            if (ExtrudersSettings.Count == size)
                return;

            if (ExtrudersSettings.Count > size)
            {
                List<PrinterExtruderSettings> newList = new List<PrinterExtruderSettings>();
                for (int i = 0; i < size; i++)
                {
                    newList.Add(ExtrudersSettings[i]);
                }
            }
            else
            {
                while (ExtrudersSettings.Count < size)
                    ExtrudersSettings.Add(new PrinterExtruderSettings());
            }
        }

        public void FillValue(string key, string input)
        {
            switch (key)
            {
                case "bed_shape":
                    BedShape = input;
                    break;

                case "before_layer_gcode":
                    BeforeLayerGcode = input;
                    break;

                case "end_gcode":
                    EndGcode = input;
                    break;

                case "extruder_offset":
                    FillExtrudersValue(key, input);
                    break;

                case "gcode_flavor":
                    GcodeFlavor = input;
                    break;

                case "layer_gcode":
                    LayerGcode = input;
                    break;

                case "nozzle_diameter":
                    FillExtrudersValue(key, input);
                    break;

                case "octoprint_apikey":
                    OctoprintApikey = input;
                    break;

                case "octoprint_host":
                    OctoprintHost = input;
                    break;

                case "pressure_advance":
                    PressureAdvance = input;
                    break;

                case "retract_before_travel":
                    FillExtrudersValue(key, input);
                    break;

                case "retract_layer_change":
                    FillExtrudersValue(key, input);
                    break;

                case "retract_length":
                    FillExtrudersValue(key, input);
                    break;

                case "retract_length_toolchange":
                    FillExtrudersValue(key, input);
                    break;

                case "retract_lift":
                    FillExtrudersValue(key, input);
                    break;

                case "retract_restart_extra":
                    FillExtrudersValue(key, input);
                    break;

                case "retract_restart_extra_toolchange":
                    FillExtrudersValue(key, input);
                    break;

                case "retract_speed":
                    FillExtrudersValue(key, input);
                    break;

                case "start_gcode":
                    StartGcode = input;
                    break;

                case "toolchange_gcode":
                    ToolchangeGcode = input;
                    break;

                case "use_firmware_retraction":
                    FillExtrudersValue(key, input);
                    break;

                case "use_relative_e_distances":
                    FillExtrudersValue(key, input);
                    break;

                case "use_volumetric_e":
                    FillExtrudersValue(key, input);
                    break;

                case "vibration_limit":
                    VibrationLimit = input;
                    break;

                case "wipe":
                    FillExtrudersValue(key, input);
                    break;

                case "z_offset":
                    ZOffset = input;
                    break;
            }
        }

        public override string ToString()
        {
            StringBuilder builder = new StringBuilder();

            builder.AppendFormat("{0} = {1}\n", "bed_shape", BedShape.ToSlic3rSettings());
            builder.AppendFormat("{0} = {1}\n", "before_layer_gcode", BeforeLayerGcode.ToSlic3rSettings());
            builder.AppendFormat("{0} = {1}\n", "end_gcode", EndGcode.ToSlic3rSettings());
            builder.AppendFormat("{0} = {1}\n", "extruder_offset", string.Join(", ", ExtrudersSettings.Select(es => es.ExtruderOffset.ToSlic3rSettings())));
            builder.AppendFormat("{0} = {1}\n", "gcode_flavor", GcodeFlavor.ToSlic3rSettings());
            builder.AppendFormat("{0} = {1}\n", "layer_gcode", LayerGcode.ToSlic3rSettings());
            builder.AppendFormat("{0} = {1}\n", "nozzle_diameter", string.Join(", ", ExtrudersSettings.Select(es => es.NozzleDiameter.ToSlic3rSettings())));
            builder.AppendFormat("{0} = {1}\n", "octoprint_apikey", OctoprintApikey.ToSlic3rSettings());
            builder.AppendFormat("{0} = {1}\n", "octoprint_host", OctoprintHost.ToSlic3rSettings());
            builder.AppendFormat("{0} = {1}\n", "pressure_advance", PressureAdvance.ToSlic3rSettings());
            builder.AppendFormat("{0} = {1}\n", "retract_before_travel", string.Join(", ", ExtrudersSettings.Select(es => es.RetractBeforeTravel.ToSlic3rSettings())));
            builder.AppendFormat("{0} = {1}\n", "retract_layer_change", string.Join(", ", ExtrudersSettings.Select(es => es.RetractLayerChange.ToSlic3rSettings())));
            builder.AppendFormat("{0} = {1}\n", "retract_length", string.Join(", ", ExtrudersSettings.Select(es => es.RetractLength.ToSlic3rSettings())));
            builder.AppendFormat("{0} = {1}\n", "retract_length_toolchange", string.Join(", ", ExtrudersSettings.Select(es => es.RetractLengthToolchange.ToSlic3rSettings())));
            builder.AppendFormat("{0} = {1}\n", "retract_lift", string.Join(", ", ExtrudersSettings.Select(es => es.RetractLift.ToSlic3rSettings())));
            builder.AppendFormat("{0} = {1}\n", "retract_restart_extra", string.Join(", ", ExtrudersSettings.Select(es => es.RetractRestartExtra.ToSlic3rSettings())));
            builder.AppendFormat("{0} = {1}\n", "retract_restart_extra_toolchange", string.Join(", ", ExtrudersSettings.Select(es => es.RetractRestartExtraToolchange.ToSlic3rSettings())));
            builder.AppendFormat("{0} = {1}\n", "retract_speed", string.Join(", ", ExtrudersSettings.Select(es => es.RetractSpeed.ToSlic3rSettings())));
            builder.AppendFormat("{0} = {1}\n", "start_gcode", StartGcode.ToSlic3rSettings());
            builder.AppendFormat("{0} = {1}\n", "toolchange_gcode", ToolchangeGcode.ToSlic3rSettings());
            builder.AppendFormat("{0} = {1}\n", "use_firmware_retraction", UseFirmwareRetraction.ToSlic3rSettings());
            builder.AppendFormat("{0} = {1}\n", "use_relative_e_distances", UseRelativeEDistances.ToSlic3rSettings());
            builder.AppendFormat("{0} = {1}\n", "use_volumetric_e", UseVolumetricE.ToSlic3rSettings());
            builder.AppendFormat("{0} = {1}\n", "vibration_limit", VibrationLimit.ToSlic3rSettings());
            builder.AppendFormat("{0} = {1}\n", "wipe", string.Join(", ", ExtrudersSettings.Select(es => es.Wipe.ToSlic3rSettings())));
            builder.AppendFormat("{0} = {1}\n", "z_offset", ZOffset.ToSlic3rSettings());

            return builder.ToString();
        }
    }
}