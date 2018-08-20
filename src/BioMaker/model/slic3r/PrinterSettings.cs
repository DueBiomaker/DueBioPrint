using BioMaker.extensions;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace BioMaker.model.slic3r
{
    public class PrinterSettings : ISlic3rSettings, INotifyPropertyChanged
    {
        private const string DEFAULT_VALUE = "0";
        private const string DEFAULT_ORIGIN = "0";
        private const string DEFAULT_SIZE = "200";
        private const string DEFAULT_BED_SHAPE = "0x0,200x0,200x200,0x200";
        private const string BED_SHAPE_FORMAT = "{0}x{1},{2}x{1},{2}x{3},{0}x{3}";

        public string ProfileName { get; set; }
        public string FilePath { get; set; }

        private int _ExtruderCount = 1;
        public int ExtruderCount
        {
            get
            {
                return _ExtruderCount;
            }
            set
            {
                _ExtruderCount = value;
                AdjustExtruderList();
                OnPropertyChanged("ExtruderCount");
            }
        }

        private string _BedXOrigin;
        public string BedXOrigin
        {
            get
            {
                return _BedXOrigin ?? DEFAULT_ORIGIN;   
            }
            set
            {
                _BedXOrigin = value;
                OnPropertyChanged("BedXOrigin");
                OnPropertyChanged("BedShape");
            }
        }
        private string _BedYOrigin;
        public string BedYOrigin
        {
            get
            {
                return _BedYOrigin ?? DEFAULT_ORIGIN;   
            }
            set
            {
                _BedYOrigin = value;
                OnPropertyChanged("BedYOrigin");
                OnPropertyChanged("BedShape");
            }
        }
        private string _BedXSize;
        public string BedXSize
        {
            get
            {
                return _BedXSize ?? DEFAULT_SIZE;   
            }
            set
            {
                _BedXSize = value;
                OnPropertyChanged("BedXSize");
                OnPropertyChanged("BedShape");
            }
        }
        private string _BedYSize;
        public string BedYSize
        {
            get
            {
                return _BedYSize ?? DEFAULT_SIZE;   
            }
            set
            {
                _BedYSize = value;
                OnPropertyChanged("BedYSize");
                OnPropertyChanged("BedShape");
            }
        }

        // General
        public string BedShape
        {
            get
            {
                return string.Format(BED_SHAPE_FORMAT, BedXOrigin, BedYOrigin, BedXSize, BedYSize);
            }
            set
            {
                FillBedValues(value ?? DEFAULT_BED_SHAPE);
                OnPropertyChanged("BedShape");
            }
        }

        private void FillBedValues(string bedShape)
        {
            string[] values = bedShape.Split(',');

            string[] origin = values[0].Split('x');
            string[] extremity = values[2].Split('x');

            BedXOrigin = origin[0];
            BedYOrigin = origin[1];
            BedXSize = extremity[0];
            BedYSize = extremity[1];
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

        private GCodeFlavor _GcodeFlavor;

        public GCodeFlavor GcodeFlavor
        {
            get
            {
                return _GcodeFlavor;
            }
            set
            {
                _GcodeFlavor = value;
                OnPropertyChanged("GcodeFlavor");
            }
        }

        public int GcodeFlavorInt
        {
            get
            {
                return (int)_GcodeFlavor;
            }
            set
            {
                _GcodeFlavor = (GCodeFlavor)value;
                OnPropertyChanged("GcodeFlavorInt");
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
        private List<ExtruderSettings> _ExtrudersSettings;

        public List<ExtruderSettings> ExtrudersSettings
        {
            get
            {
                if (_ExtrudersSettings == null)
                    _ExtrudersSettings = new List<ExtruderSettings>();
                return _ExtrudersSettings;
            }
            set
            {
                _ExtrudersSettings = value;
                OnPropertyChanged("ExtrudersSettings");
            }
        }

        public Slic3rSettingsCategory Category
        {
            get
            {
                return Slic3rSettingsCategory.Printer;
            }
        }

        private void FillExtrudersValue(string key, string input)
        {
            string[] values = input.Split(',');

            ExtruderCount = values.Length;

            for (int i = 0; i < values.Length; i++)
            {
                ExtrudersSettings[i].FillValue(key, values[i].Trim());
            }
        }

        private void AdjustExtruderList()
        {
            if (ExtrudersSettings.Count == ExtruderCount)
                return;

            if (ExtrudersSettings.Count > ExtruderCount)
            {
                List<ExtruderSettings> reducedList = new List<ExtruderSettings>();
                for (int i = 0; i < ExtruderCount; i++)
                {
                    reducedList.Add(ExtrudersSettings[i]);
                }
                ExtrudersSettings = reducedList;
            }
            else
            {
                while (ExtrudersSettings.Count < ExtruderCount)
                    ExtrudersSettings.Add(new ExtruderSettings());
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string name)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
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
                    input = input.Replace("-", "_");
                    GcodeFlavor = (GCodeFlavor)Enum.Parse(typeof(GCodeFlavor), input);
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
                    UseFirmwareRetraction = input.ToBool();
                    break;

                case "use_relative_e_distances":
                    UseRelativeEDistances = input.ToBool();
                    break;

                case "use_volumetric_e":
                    UseVolumetricE = input.ToBool();
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