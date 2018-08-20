using BioMaker.extensions;
using System.ComponentModel;

namespace BioMaker.model.slic3r
{
    public class ExtruderSettings : INotifyPropertyChanged
    {
        private const string DEFAULT_VALUE = "0";
        private const string EXTRUDER_OFFSET_FORMAT = "{0}x{1}";

        private string _NozzleDiameter = "0.5";

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

        private string _ExtruderXOffset = "0";

        public string ExtruderXOffset 
        {
            get
            {
                return _ExtruderXOffset;
            }
            set
            {
                _ExtruderXOffset = value;
                OnPropertyChanged("ExtruderXOffset");
                OnPropertyChanged("ExtruderOffset");
            }
        }

        private string _ExtruderYOffset = "0";

        public string ExtruderYOffset 
        {
            get
            {
                return _ExtruderYOffset;
            }
            set
            {
                _ExtruderYOffset = value;
                OnPropertyChanged("ExtruderYOffset");
                OnPropertyChanged("ExtruderOffset");
            }
        }

        public string ExtruderOffset
        {
            get
            {
                return string.Format(EXTRUDER_OFFSET_FORMAT, ExtruderXOffset, ExtruderYOffset);
            }
            set
            {
                FillOffsetValues(value);
                OnPropertyChanged("ExtruderOffset");
            }
        }

        private void FillOffsetValues(string offset)
        {
            string[] values = offset.Split('x');

            ExtruderXOffset = values[0];
            ExtruderYOffset = values[1];
        }

        private string _RetractLength = "2";

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

        private string _RetractLift = "0";

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

        private string _RetractSpeed = "40";

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

        private string _RetractRestartExtra = "0";

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

        private string _RetractBeforeTravel = "2";

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

        private string _RetractLengthToolchange = "10";

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

        private string _RetractRestartExtraToolchange = "0";

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