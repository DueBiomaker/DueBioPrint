using RepetierHost.extensions;
using System.ComponentModel;

namespace RepetierHost.model.slic3r
{
    public class PrinterExtruderSettings : INotifyPropertyChanged
    {
        private const string DEFAULT_VALUE = "0";

        private string _NozzleDiameter;

        public string NozzleDiameter
        {
            get
            {
                return _NozzleDiameter;
            }
            set
            {
                _NozzleDiameter = value ?? DEFAULT_VALUE;
                OnPropertyChanged("NozzleDiameter");
            }
        }

        private string _ExtruderOffset;

        public string ExtruderOffset
        {
            get
            {
                return _ExtruderOffset;
            }
            set
            {
                _ExtruderOffset = value ?? DEFAULT_VALUE;
                OnPropertyChanged("ExtruderOffset");
            }
        }

        private string _RetractLength;

        public string RetractLength
        {
            get
            {
                return _RetractLength;
            }
            set
            {
                _RetractLength = value ?? DEFAULT_VALUE;
                OnPropertyChanged("RetractLength");
            }
        }

        private string _RetractLift;

        public string RetractLift
        {
            get
            {
                return _RetractLift;
            }
            set
            {
                _RetractLift = value ?? DEFAULT_VALUE;
                OnPropertyChanged("RetractLift");
            }
        }

        private string _RetractSpeed;

        public string RetractSpeed
        {
            get
            {
                return _RetractSpeed;
            }
            set
            {
                _RetractSpeed = value ?? DEFAULT_VALUE;
                OnPropertyChanged("RetractSpeed");
            }
        }

        private string _RetractRestartExtra;

        public string RetractRestartExtra
        {
            get
            {
                return _RetractRestartExtra;
            }
            set
            {
                _RetractRestartExtra = value ?? DEFAULT_VALUE;
                OnPropertyChanged("RetractRestartExtra");
            }
        }

        private string _RetractBeforeTravel;

        public string RetractBeforeTravel
        {
            get
            {
                return _RetractBeforeTravel;
            }
            set
            {
                _RetractBeforeTravel = value ?? DEFAULT_VALUE;
                OnPropertyChanged("RetractBeforeTravel");
            }
        }

        private bool _RetractLayerChange;

        public bool RetractLayerChange
        {
            get
            {
                return _RetractLayerChange;
            }
            set
            {
                _RetractLayerChange = value;
                OnPropertyChanged("RetractLayerChange");
            }
        }

        private bool _Wipe;

        public bool Wipe
        {
            get
            {
                return _Wipe;
            }
            set
            {
                _Wipe = value;
                OnPropertyChanged("Wipe");
            }
        }

        private string _RetractLengthToolchange;

        public string RetractLengthToolchange
        {
            get
            {
                return _RetractLengthToolchange;
            }
            set
            {
                _RetractLengthToolchange = value ?? DEFAULT_VALUE;
                OnPropertyChanged("RetractLengthToolchange");
            }
        }

        private string _RetractRestartExtraToolchange;

        public string RetractRestartExtraToolchange
        {
            get
            {
                return _RetractRestartExtraToolchange;
            }
            set
            {
                _RetractRestartExtraToolchange = value ?? DEFAULT_VALUE;
                OnPropertyChanged("RetractRestartExtraToolchange");
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
                case "extruder_offset":
                    ExtruderOffset = input;
                    break;

                case "nozzle_diameter":
                    NozzleDiameter = input;
                    break;

                case "retract_before_travel":
                    RetractBeforeTravel = input;
                    break;

                case "retract_layer_change":
                    RetractLayerChange = input.ToBool();
                    break;

                case "retract_length":
                    RetractLength = input;
                    break;

                case "retract_length_toolchange":
                    RetractLengthToolchange = input;
                    break;

                case "retract_lift":
                    RetractLift = input;
                    break;

                case "retract_restart_extra":
                    RetractRestartExtra = input;
                    break;

                case "retract_restart_extra_toolchange":
                    RetractRestartExtraToolchange = input;
                    break;

                case "retract_speed":
                    RetractSpeed = input;
                    break;

                case "wipe":
                    Wipe = input.ToBool();
                    break;
            }
        }
    }
}