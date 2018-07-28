using RepetierHost.extensions;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace RepetierHost.model.slic3r
{
    public class FilamentSettings : INotifyPropertyChanged, ISlic3rSettings
    {
        private const string DEFAULT_VALUE = "0";
        private const string DEFAULT_COLOR = "#FFFFFF";
        private const string TRUE_INT = "1";

        private const string TEXT_FAN_TURNED_OFF = "Fan will be turned off.";
        private const string TEXT_FAN_ALWAYS_ON = "Fan will always run at {0}% except for the first {1} layers.";

        private const string TEXT_COOLING = "If estimated layer time is below ~{0}s, fan will run at {1}% and print speed will be reduced so that no less than {0}s are spent on that layer(however, speed will never be reduced below {2}mm/s).\n" +
                                            "If estimated layer time is greater, but still below ~{3}s, fan will run at a proportionally decreasing speed between {1}% and {4}%.\n";
        private const string TEXT_FOOTER_ALWAYS_ON = "During the other layers, fan will always run at {0}% except for the first {1} layers.";

        private const string TEXT_FOOTER = "During the other layers, fan will be turned off.";

        public string CoolingDescription
        {
            get
            {
                StringBuilder builder = new StringBuilder();

                if (!FanAlwaysOn && !Cooling)
                    builder.Append(TEXT_FAN_TURNED_OFF);
                else if (FanAlwaysOn && !Cooling)
                    builder.AppendFormat(TEXT_FAN_ALWAYS_ON, MinFanSpeed, DisableFanFirstLayers);
                else if (!FanAlwaysOn && Cooling)
                {
                    builder.AppendFormat(TEXT_COOLING, SlowdownBelowLayerTime, MaxFanSpeed, MinPrintSpeed, FanBelowLayerTime, MinFanSpeed);
                    builder.Append(TEXT_FOOTER);
                }
                else
                {
                    builder.AppendFormat(TEXT_COOLING, SlowdownBelowLayerTime, MaxFanSpeed, MinPrintSpeed, FanBelowLayerTime, MinFanSpeed);
                    builder.AppendFormat(TEXT_FOOTER_ALWAYS_ON, MinFanSpeed, DisableFanFirstLayers);
                }

                return builder.ToString();
            }
        }

        public string ProfileName { get; set; }
        public string FilePath { get; set; }

        public bool FanSettingsEnabled
        {
            get
            {
                return FanAlwaysOn || Cooling;
            }
        }

        // Filament
        private string _FilamentColour;

        public string FilamentColour 
        {
            get
            {
                return _FilamentColour ?? DEFAULT_COLOR;
            }
            set
            {
                _FilamentColour = value;
                OnPropertyChanged("FilamentColour");
            }
        }
        private string _FilamentDiameter;

        public string FilamentDiameter 
        {
            get
            {
                return _FilamentDiameter ?? DEFAULT_VALUE;
            }
            set
            {
                _FilamentDiameter = value;
                OnPropertyChanged("FilamentDiameter");
            }
        }
        private string _ExtrusionMultiplier;

        public string ExtrusionMultiplier 
        {
            get
            {
                return _ExtrusionMultiplier ?? DEFAULT_VALUE;
            }
            set
            {
                _ExtrusionMultiplier = value;
                OnPropertyChanged("ExtrusionMultiplier");
            }
        }
        private string _FirstLayerTemperature;

        public string FirstLayerTemperature 
        {
            get
            {
                return _FirstLayerTemperature ?? DEFAULT_VALUE;
            }
            set
            {
                _FirstLayerTemperature = value;
                OnPropertyChanged("FirstLayerTemperature");
            }
        }
        private string _Temperature;

        public string Temperature 
        {
            get
            {
                return _Temperature ?? DEFAULT_VALUE;
            }
            set
            {
                _Temperature = value;
                OnPropertyChanged("Temperature");
            }
        }
        private string _FirstLayerBedTemperature;

        public string FirstLayerBedTemperature 
        {
            get
            {
                return _FirstLayerBedTemperature ?? DEFAULT_VALUE;
            }
            set
            {
                _FirstLayerBedTemperature = value;
                OnPropertyChanged("FirstLayerBedTemperature");
            }
        }
        private string _BedTemperature;

        public string BedTemperature 
        {
            get
            {
                return _BedTemperature ?? DEFAULT_VALUE;
            }
            set
            {
                _BedTemperature = value;
                OnPropertyChanged("BedTemperature");
            }
        }

        // Cooling
        private bool _FanAlwaysOn;

        public bool FanAlwaysOn 
        {
            get
            {
                return _FanAlwaysOn;
            }
            set
            {
                _FanAlwaysOn = value;
                OnPropertyChanged("FanAlwaysOn");
                OnPropertyChanged("CoolingDescription");
            }
        }
        private bool _Cooling;

        public bool Cooling 
        {
            get
            {
                return _Cooling;
            }
            set
            {
                _Cooling = value;
                OnPropertyChanged("Cooling");
                OnPropertyChanged("CoolingDescription");
            }
        }
        private string _MaxFanSpeed;

        public string MaxFanSpeed 
        {
            get
            {
                return _MaxFanSpeed ?? DEFAULT_VALUE;
            }
            set
            {
                _MaxFanSpeed = value;
                OnPropertyChanged("MaxFanSpeed");
            }
        }
        private string _MinFanSpeed;

        public string MinFanSpeed 
        {
            get
            {
                return _MinFanSpeed ?? DEFAULT_VALUE;
            }
            set
            {
                _MinFanSpeed = value;
                OnPropertyChanged("MinFanSpeed");
            }
        }
        private string _BridgeFanSpeed;

        public string BridgeFanSpeed 
        {
            get
            {
                return _BridgeFanSpeed ?? DEFAULT_VALUE;
            }
            set
            {
                _BridgeFanSpeed = value;
                OnPropertyChanged("BridgeFanSpeed");
            }
        }
        private string _DisableFanFirstLayers;

        public string DisableFanFirstLayers 
        {
            get
            {
                return _DisableFanFirstLayers ?? DEFAULT_VALUE;
            }
            set
            {
                _DisableFanFirstLayers = value;
                OnPropertyChanged("DisableFanFirstLayers");
            }
        }
        private string _FanBelowLayerTime;

        public string FanBelowLayerTime 
        {
            get
            {
                return _FanBelowLayerTime ?? DEFAULT_VALUE;
            }
            set
            {
                _FanBelowLayerTime = value;
                OnPropertyChanged("FanBelowLayerTime");
            }
        }
        private string _SlowdownBelowLayerTime;

        public string SlowdownBelowLayerTime 
        {
            get
            {
                return _SlowdownBelowLayerTime ?? DEFAULT_VALUE;
            }
            set
            {
                _SlowdownBelowLayerTime = value;
                OnPropertyChanged("SlowdownBelowLayerTime");
            }
        }
        private string _MinPrintSpeed;

        public string MinPrintSpeed 
        {
            get
            {
                return _MinPrintSpeed ?? DEFAULT_VALUE;
            }
            set
            {
                _MinPrintSpeed = value;
                OnPropertyChanged("MinPrintSpeed");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string name)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

        public override string ToString()
        {
            StringBuilder builder = new StringBuilder();

            builder.AppendFormat("{0} = {1}\n", "bed_temperature", BedTemperature.ToSlic3rSettings());
            builder.AppendFormat("{0} = {1}\n", "bridge_fan_speed", BridgeFanSpeed.ToSlic3rSettings());
            builder.AppendFormat("{0} = {1}\n", "cooling", Cooling.ToSlic3rSettings());
            builder.AppendFormat("{0} = {1}\n", "disable_fan_first_layers", DisableFanFirstLayers.ToSlic3rSettings());
            builder.AppendFormat("{0} = {1}\n", "extrusion_multiplier", ExtrusionMultiplier.ToSlic3rSettings());
            builder.AppendFormat("{0} = {1}\n", "fan_always_on", FanAlwaysOn.ToSlic3rSettings());
            builder.AppendFormat("{0} = {1}\n", "fan_below_layer_time", FanBelowLayerTime.ToSlic3rSettings());
            builder.AppendFormat("{0} = {1}\n", "filament_colour", FilamentColour.ToSlic3rSettings());
            builder.AppendFormat("{0} = {1}\n", "filament_diameter", FilamentDiameter.ToSlic3rSettings());
            builder.AppendFormat("{0} = {1}\n", "first_layer_bed_temperature", FirstLayerBedTemperature.ToSlic3rSettings());
            builder.AppendFormat("{0} = {1}\n", "first_layer_temperature", FirstLayerTemperature.ToSlic3rSettings());
            builder.AppendFormat("{0} = {1}\n", "max_fan_speed", MaxFanSpeed.ToSlic3rSettings());
            builder.AppendFormat("{0} = {1}\n", "min_fan_speed", MinFanSpeed.ToSlic3rSettings());
            builder.AppendFormat("{0} = {1}\n", "min_print_speed", MinPrintSpeed.ToSlic3rSettings());
            builder.AppendFormat("{0} = {1}\n", "slowdown_below_layer_time", SlowdownBelowLayerTime.ToSlic3rSettings());
            builder.AppendFormat("{0} = {1}\n", "temperature", Temperature.ToSlic3rSettings());

            return builder.ToString();
        }

        public void FillValue(string key, string input)
        {
            switch (key)
            {
                case "bed_temperature":
                    BedTemperature = input;
                    break;
                case "bridge_fan_speed":
                    BridgeFanSpeed = input;
                    break;
                case "cooling":
                    Cooling = input.Equals(TRUE_INT);
                    break;
                case "disable_fan_first_layers":
                    DisableFanFirstLayers = input;
                    break;
                case "extrusion_multiplier":
                    ExtrusionMultiplier = input;
                    break;
                case "fan_always_on":
                    FanAlwaysOn = input.Equals(TRUE_INT);
                    break;
                case "fan_below_layer_time":
                    FanBelowLayerTime = input;
                    break;
                case "filament_colour":
                    FilamentColour = input;
                    break;
                case "filament_diameter":
                    FilamentDiameter = input;
                    break;
                case "first_layer_bed_temperature":
                    FirstLayerBedTemperature = input;
                    break;
                case "first_layer_temperature":
                    FirstLayerTemperature = input;
                    break;
                case "max_fan_speed":
                    MaxFanSpeed = input;
                    break;
                case "min_fan_speed":
                    MinFanSpeed = input;
                    break;
                case "min_print_speed":
                    MinPrintSpeed = input;
                    break;
                case "slowdown_below_layer_time":
                    SlowdownBelowLayerTime = input;
                    break;
                case "temperature":
                    Temperature = input;
                    break;
            }
        }
    }
}
