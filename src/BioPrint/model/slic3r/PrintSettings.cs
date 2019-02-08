using BioPrint.extensions;
using System;
using System.ComponentModel;
using System.Text;

namespace BioPrint.model.slic3r
{
    public class PrintSettings : INotifyPropertyChanged, ISlic3rSettings
    {
        private const string DEFAULT_VALUE = "0";

        public string ProfileName { get; set; }
        public string FilePath { get; set; }

        // Layers and perimeters
        private string _LayerHeight;

        public string LayerHeight
        {
            get
            {
                return _LayerHeight ?? DEFAULT_VALUE;
            }
            set
            {
                _LayerHeight = value;
                OnPropertyChanged("LayerHeight");
            }
        }

        private string _FirstLayerHeight;

        public string FirstLayerHeight
        {
            get
            {
                return _FirstLayerHeight ?? DEFAULT_VALUE;
            }
            set
            {
                _FirstLayerHeight = value;
                OnPropertyChanged("FirstLayerHeight");
            }
        }

        private string _Perimeters;

        public string Perimeters
        {
            get
            {
                return _Perimeters ?? DEFAULT_VALUE;
            }
            set
            {
                _Perimeters = value;
                OnPropertyChanged("Perimeters");
            }
        }

        private bool _SpiralVase;

        public bool SpiralVase
        {
            get
            {
                return _SpiralVase;
            }
            set
            {
                _SpiralVase = value;
                OnPropertyChanged("SpiralVase");
            }
        }

        private string _TopSolidLayers;

        public string TopSolidLayers
        {
            get
            {
                return _TopSolidLayers ?? DEFAULT_VALUE;
            }
            set
            {
                _TopSolidLayers = value;
                OnPropertyChanged("TopSolidLayers");
            }
        }

        private string _BottomSolidLayers;

        public string BottomSolidLayers
        {
            get
            {
                return _BottomSolidLayers ?? DEFAULT_VALUE;
            }
            set
            {
                _BottomSolidLayers = value;
                OnPropertyChanged("BottomSolidLayers");
            }
        }

        private bool _ExtraPerimeters;

        public bool ExtraPerimeters
        {
            get
            {
                return _ExtraPerimeters;
            }
            set
            {
                _ExtraPerimeters = value;
                OnPropertyChanged("ExtraPerimeters");
            }
        }

        private bool _AvoidCrossingPerimeters;

        public bool AvoidCrossingPerimeters
        {
            get
            {
                return _AvoidCrossingPerimeters;
            }
            set
            {
                _AvoidCrossingPerimeters = value;
                OnPropertyChanged("AvoidCrossingPerimeters");
            }
        }

        private bool _ThinWalls;

        public bool ThinWalls
        {
            get
            {
                return _ThinWalls;
            }
            set
            {
                _ThinWalls = value;
                OnPropertyChanged("ThinWalls");
            }
        }

        private bool _Overhangs;

        public bool Overhangs
        {
            get
            {
                return _Overhangs;
            }
            set
            {
                _Overhangs = value;
                OnPropertyChanged("Overhangs");
            }
        }

        private SeamPosition _SeamPosition;

        public SeamPosition SeamPosition
        {
            get
            {
                return _SeamPosition;
            }
            set
            {
                _SeamPosition = value;
                OnPropertyChanged("SeamPosition");
            }
        }

        public int SeamPositionInt
        {
            get
            {
                return (int)_SeamPosition;
            }
            set
            {
                _SeamPosition = (SeamPosition)value;
                OnPropertyChanged("SeamPositionInt");
                OnPropertyChanged("SeamPosition");
            }
        }

        private bool _ExternalPerimetersFirst;

        public bool ExternalPerimetersFirst
        {
            get
            {
                return _ExternalPerimetersFirst;
            }
            set
            {
                _ExternalPerimetersFirst = value;
                OnPropertyChanged("ExternalPerimetersFirst");
            }
        }

        // Infill
        private string _FillDensity;

        public string FillDensity
        {
            get
            {
                return _FillDensity ?? DEFAULT_VALUE;
            }
            set
            {
                _FillDensity = value;
                OnPropertyChanged("FillDensity");
            }
        }

        private FillPattern _FillPattern;

        public FillPattern FillPattern
        {
            get
            {
                return _FillPattern;
            }
            set
            {
                _FillPattern = value;
                OnPropertyChanged("FillPattern");
            }
        }

        public int FillPatternInt
        {
            get
            {
                return (int)_FillPattern;
            }
            set
            {
                _FillPattern = (FillPattern)value;
                OnPropertyChanged("FillPatternInt");
                OnPropertyChanged("FillPattern");
            }
        }

        private ExternalFillPattern _ExternalFillPattern;

        public ExternalFillPattern ExternalFillPattern
        {
            get
            {
                return _ExternalFillPattern;
            }
            set
            {
                _ExternalFillPattern = value;
                OnPropertyChanged("ExternalFillPattern");
            }
        }

        public int ExternalFillPatternInt
        {
            get
            {
                return (int)_ExternalFillPattern;
            }
            set
            {
                _ExternalFillPattern = (ExternalFillPattern)value;
                OnPropertyChanged("ExternalFillPatternInt");
                OnPropertyChanged("ExternalFillPattern");
            }
        }

        private string _InfillEveryLayers;

        public string InfillEveryLayers
        {
            get
            {
                return _InfillEveryLayers ?? DEFAULT_VALUE;
            }
            set
            {
                _InfillEveryLayers = value;
                OnPropertyChanged("InfillEveryLayers");
            }
        }

        private bool _InfillOnlyWhereNeeded;

        public bool InfillOnlyWhereNeeded
        {
            get
            {
                return _InfillOnlyWhereNeeded;
            }
            set
            {
                _InfillOnlyWhereNeeded = value;
                OnPropertyChanged("InfillOnlyWhereNeeded");
            }
        }

        private string _SolidInfillEveryLayers;

        public string SolidInfillEveryLayers
        {
            get
            {
                return _SolidInfillEveryLayers ?? DEFAULT_VALUE;
            }
            set
            {
                _SolidInfillEveryLayers = value;
                OnPropertyChanged("SolidInfillEveryLayers");
            }
        }

        private string _FillAngle;

        public string FillAngle
        {
            get
            {
                return _FillAngle ?? DEFAULT_VALUE;
            }
            set
            {
                _FillAngle = value;
                OnPropertyChanged("FillAngle");
            }
        }

        private string _SolidInfillBelowArea;

        public string SolidInfillBelowArea
        {
            get
            {
                return _SolidInfillBelowArea ?? DEFAULT_VALUE;
            }
            set
            {
                _SolidInfillBelowArea = value;
                OnPropertyChanged("SolidInfillBelowArea");
            }
        }

        private bool _OnlyRetractWhenCrossingPerimeters;

        public bool OnlyRetractWhenCrossingPerimeters
        {
            get
            {
                return _OnlyRetractWhenCrossingPerimeters;
            }
            set
            {
                _OnlyRetractWhenCrossingPerimeters = value;
                OnPropertyChanged("OnlyRetractWhenCrossingPerimeters");
            }
        }

        private bool _InfillFirst;

        public bool InfillFirst
        {
            get
            {
                return _InfillFirst;
            }
            set
            {
                _InfillFirst = value;
                OnPropertyChanged("InfillFirst");
            }
        }

        // Skirt and Brim
        private string _Skirts;

        public string Skirts
        {
            get
            {
                return _Skirts ?? DEFAULT_VALUE;
            }
            set
            {
                _Skirts = value;
                OnPropertyChanged("Skirts");
            }
        }

        private string _SkirtDistance;

        public string SkirtDistance
        {
            get
            {
                return _SkirtDistance ?? DEFAULT_VALUE;
            }
            set
            {
                _SkirtDistance = value;
                OnPropertyChanged("SkirtDistance");
            }
        }

        private string _SkirtHeight;

        public string SkirtHeight
        {
            get
            {
                return _SkirtHeight ?? DEFAULT_VALUE;
            }
            set
            {
                _SkirtHeight = value;
                OnPropertyChanged("SkirtHeight");
            }
        }

        private string _MinSkirtLength;

        public string MinSkirtLength
        {
            get
            {
                return _MinSkirtLength ?? DEFAULT_VALUE;
            }
            set
            {
                _MinSkirtLength = value;
                OnPropertyChanged("MinSkirtLength");
            }
        }

        private string _BrimWidth;

        public string BrimWidth
        {
            get
            {
                return _BrimWidth ?? DEFAULT_VALUE;
            }
            set
            {
                _BrimWidth = value;
                OnPropertyChanged("BrimWidth");
            }
        }

        // Support Material
        private bool _SupportMaterial;

        public bool SupportMaterial
        {
            get
            {
                return _SupportMaterial;
            }
            set
            {
                _SupportMaterial = value;
                OnPropertyChanged("SupportMaterial");
            }
        }

        private string _SupportMaterialThreshold;

        public string SupportMaterialThreshold
        {
            get
            {
                return _SupportMaterialThreshold ?? DEFAULT_VALUE;
            }
            set
            {
                _SupportMaterialThreshold = value;
                OnPropertyChanged("SupportMaterialThreshold");
            }
        }

        private string _SupportMaterialEnforceLayers;

        public string SupportMaterialEnforceLayers
        {
            get
            {
                return _SupportMaterialEnforceLayers ?? DEFAULT_VALUE;
            }
            set
            {
                _SupportMaterialEnforceLayers = value;
                OnPropertyChanged("SupportMaterialEnforceLayers");
            }
        }

        private string _RaftLayers;

        public string RaftLayers
        {
            get
            {
                return _RaftLayers ?? DEFAULT_VALUE;
            }
            set
            {
                _RaftLayers = value;
                OnPropertyChanged("RaftLayers");
            }
        }

        private string _SupportMaterialContactDistance;

        public string SupportMaterialContactDistance
        {
            get
            {
                return _SupportMaterialContactDistance ?? DEFAULT_VALUE;
            }
            set
            {
                _SupportMaterialContactDistance = value;
                OnPropertyChanged("SupportMaterialContactDistance");
            }
        }

        private SupportMaterialPattern _SupportMaterialPattern;

        public SupportMaterialPattern SupportMaterialPattern
        {
            get
            {
                return _SupportMaterialPattern;
            }
            set
            {
                _SupportMaterialPattern = value;
                OnPropertyChanged("SupportMaterialPattern");
            }
        }

        public int SupportMaterialPatternInt
        {
            get
            {
                return (int)_SupportMaterialPattern;
            }
            set
            {
                _SupportMaterialPattern = (SupportMaterialPattern) value;
                OnPropertyChanged("SupportMaterialPatternInt");
                OnPropertyChanged("SupportMaterialPattern");
            }
        }

        private string _SupportMaterialSpacing;

        public string SupportMaterialSpacing
        {
            get
            {
                return _SupportMaterialSpacing ?? DEFAULT_VALUE;
            }
            set
            {
                _SupportMaterialSpacing = value;
                OnPropertyChanged("SupportMaterialSpacing");
            }
        }

        private string _SupportMaterialAngle;

        public string SupportMaterialAngle
        {
            get
            {
                return _SupportMaterialAngle ?? DEFAULT_VALUE;
            }
            set
            {
                _SupportMaterialAngle = value;
                OnPropertyChanged("SupportMaterialAngle");
            }
        }

        private string _SupportMaterialInterfaceLayers;

        public string SupportMaterialInterfaceLayers
        {
            get
            {
                return _SupportMaterialInterfaceLayers ?? DEFAULT_VALUE;
            }
            set
            {
                _SupportMaterialInterfaceLayers = value;
                OnPropertyChanged("SupportMaterialInterfaceLayers");
            }
        }

        private string _SupportMaterialInterfaceSpacing;

        public string SupportMaterialInterfaceSpacing
        {
            get
            {
                return _SupportMaterialInterfaceSpacing ?? DEFAULT_VALUE;
            }
            set
            {
                _SupportMaterialInterfaceSpacing = value;
                OnPropertyChanged("SupportMaterialInterfaceSpacing");
            }
        }

        private bool _DontSupportBridges;

        public bool DontSupportBridges
        {
            get
            {
                return _DontSupportBridges;
            }
            set
            {
                _DontSupportBridges = value;
                OnPropertyChanged("DontSupportBridges");
            }
        }

        // Speed
        private string _PerimeterSpeed;

        public string PerimeterSpeed
        {
            get
            {
                return _PerimeterSpeed ?? DEFAULT_VALUE;
            }
            set
            {
                _PerimeterSpeed = value;
                OnPropertyChanged("PerimeterSpeed");
            }
        }

        private string _SmallPerimeterSpeed;

        public string SmallPerimeterSpeed
        {
            get
            {
                return _SmallPerimeterSpeed ?? DEFAULT_VALUE;
            }
            set
            {
                _SmallPerimeterSpeed = value;
                OnPropertyChanged("SmallPerimeterSpeed");
            }
        }

        private string _ExternalPerimeterSpeed;

        public string ExternalPerimeterSpeed
        {
            get
            {
                return _ExternalPerimeterSpeed ?? DEFAULT_VALUE;
            }
            set
            {
                _ExternalPerimeterSpeed = value;
                OnPropertyChanged("ExternalPerimeterSpeed");
            }
        }

        private string _InfillSpeed;

        public string InfillSpeed
        {
            get
            {
                return _InfillSpeed ?? DEFAULT_VALUE;
            }
            set
            {
                _InfillSpeed = value;
                OnPropertyChanged("InfillSpeed");
            }
        }

        private string _SolidInfillSpeed;

        public string SolidInfillSpeed
        {
            get
            {
                return _SolidInfillSpeed ?? DEFAULT_VALUE;
            }
            set
            {
                _SolidInfillSpeed = value;
                OnPropertyChanged("SolidInfillSpeed");
            }
        }

        private string _TopSolidInfillSpeed;

        public string TopSolidInfillSpeed
        {
            get
            {
                return _TopSolidInfillSpeed ?? DEFAULT_VALUE;
            }
            set
            {
                _TopSolidInfillSpeed = value;
                OnPropertyChanged("TopSolidInfillSpeed");
            }
        }

        private string _SupportMaterialSpeed;

        public string SupportMaterialSpeed
        {
            get
            {
                return _SupportMaterialSpeed ?? DEFAULT_VALUE;
            }
            set
            {
                _SupportMaterialSpeed = value;
                OnPropertyChanged("SupportMaterialSpeed");
            }
        }

        private string _SupportMaterialInterfaceSpeed;

        public string SupportMaterialInterfaceSpeed
        {
            get
            {
                return _SupportMaterialInterfaceSpeed ?? DEFAULT_VALUE;
            }
            set
            {
                _SupportMaterialInterfaceSpeed = value;
                OnPropertyChanged("SupportMaterialInterfaceSpeed");
            }
        }

        private string _BridgeSpeed;

        public string BridgeSpeed
        {
            get
            {
                return _BridgeSpeed ?? DEFAULT_VALUE;
            }
            set
            {
                _BridgeSpeed = value;
                OnPropertyChanged("BridgeSpeed");
            }
        }

        private string _GapFillSpeed;

        public string GapFillSpeed
        {
            get
            {
                return _GapFillSpeed ?? DEFAULT_VALUE;
            }
            set
            {
                _GapFillSpeed = value;
                OnPropertyChanged("GapFillSpeed");
            }
        }

        private string _TravelSpeed;

        public string TravelSpeed
        {
            get
            {
                return _TravelSpeed ?? DEFAULT_VALUE;
            }
            set
            {
                _TravelSpeed = value;
                OnPropertyChanged("TravelSpeed");
            }
        }

        private string _FirstLayerSpeed;

        public string FirstLayerSpeed
        {
            get
            {
                return _FirstLayerSpeed ?? DEFAULT_VALUE;
            }
            set
            {
                _FirstLayerSpeed = value;
                OnPropertyChanged("FirstLayerSpeed");
            }
        }

        private string _PerimeterAcceleration;

        public string PerimeterAcceleration
        {
            get
            {
                return _PerimeterAcceleration ?? DEFAULT_VALUE;
            }
            set
            {
                _PerimeterAcceleration = value;
                OnPropertyChanged("PerimeterAcceleration");
            }
        }

        private string _InfillAcceleration;

        public string InfillAcceleration
        {
            get
            {
                return _InfillAcceleration ?? DEFAULT_VALUE;
            }
            set
            {
                _InfillAcceleration = value;
                OnPropertyChanged("InfillAcceleration");
            }
        }

        private string _BridgeAcceleration;

        public string BridgeAcceleration
        {
            get
            {
                return _BridgeAcceleration ?? DEFAULT_VALUE;
            }
            set
            {
                _BridgeAcceleration = value;
                OnPropertyChanged("BridgeAcceleration");
            }
        }

        private string _FirstLayerAcceleration;

        public string FirstLayerAcceleration
        {
            get
            {
                return _FirstLayerAcceleration ?? DEFAULT_VALUE;
            }
            set
            {
                _FirstLayerAcceleration = value;
                OnPropertyChanged("FirstLayerAcceleration");
            }
        }

        private string _DefaultAcceleration;

        public string DefaultAcceleration
        {
            get
            {
                return _DefaultAcceleration ?? DEFAULT_VALUE;
            }
            set
            {
                _DefaultAcceleration = value;
                OnPropertyChanged("DefaultAcceleration");
            }
        }

        private string _MaxPrintSpeed;

        public string MaxPrintSpeed
        {
            get
            {
                return _MaxPrintSpeed ?? DEFAULT_VALUE;
            }
            set
            {
                _MaxPrintSpeed = value;
                OnPropertyChanged("MaxPrintSpeed");
            }
        }

        private string _MaxVolumetricSpeed;

        public string MaxVolumetricSpeed
        {
            get
            {
                return _MaxVolumetricSpeed ?? DEFAULT_VALUE;
            }
            set
            {
                _MaxVolumetricSpeed = value;
                OnPropertyChanged("MaxVolumetricSpeed");
            }
        }

        // Multiple Extruders
        private string _PerimeterExtruder;

        public string PerimeterExtruder
        {
            get
            {
                return _PerimeterExtruder ?? DEFAULT_VALUE;
            }
            set
            {
                _PerimeterExtruder = value;
                OnPropertyChanged("PerimeterExtruder");
            }
        }

        private string _InfillExtruder;

        public string InfillExtruder
        {
            get
            {
                return _InfillExtruder ?? DEFAULT_VALUE;
            }
            set
            {
                _InfillExtruder = value;
                OnPropertyChanged("InfillExtruder");
            }
        }

        private string _SolidInfillExtruder;

        public string SolidInfillExtruder
        {
            get
            {
                return _SolidInfillExtruder ?? DEFAULT_VALUE;
            }
            set
            {
                _SolidInfillExtruder = value;
                OnPropertyChanged("SolidInfillExtruder");
            }
        }

        private string _SupportMaterialExtruder;

        public string SupportMaterialExtruder
        {
            get
            {
                return _SupportMaterialExtruder ?? DEFAULT_VALUE;
            }
            set
            {
                _SupportMaterialExtruder = value;
                OnPropertyChanged("SupportMaterialExtruder");
            }
        }

        private string _SupportMaterialInterfaceExtruder;

        public string SupportMaterialInterfaceExtruder
        {
            get
            {
                return _SupportMaterialInterfaceExtruder ?? DEFAULT_VALUE;
            }
            set
            {
                _SupportMaterialInterfaceExtruder = value;
                OnPropertyChanged("SupportMaterialInterfaceExtruder");
            }
        }

        private bool _OozePrevention;

        public bool OozePrevention
        {
            get
            {
                return _OozePrevention;
            }
            set
            {
                _OozePrevention = value;
                OnPropertyChanged("OozePrevention");
            }
        }

        private string _StandbyTemperatureDelta;

        public string StandbyTemperatureDelta
        {
            get
            {
                return _StandbyTemperatureDelta;
            }
            set
            {
                _StandbyTemperatureDelta = value;
                OnPropertyChanged("StandbyTemperatureDelta");
            }
        }

        private bool _InterfaceShells;

        public bool InterfaceShells
        {
            get
            {
                return _InterfaceShells;
            }
            set
            {
                _InterfaceShells = value;
                OnPropertyChanged("InterfaceShells");
            }
        }

        // Advanced
        private string _ExtrusionWidth;

        public string ExtrusionWidth
        {
            get
            {
                return _ExtrusionWidth ?? DEFAULT_VALUE;
            }
            set
            {
                _ExtrusionWidth = value;
                OnPropertyChanged("ExtrusionWidth");
            }
        }

        private string _FirstLayerExtrusionWidth;

        public string FirstLayerExtrusionWidth
        {
            get
            {
                return _FirstLayerExtrusionWidth ?? DEFAULT_VALUE;
            }
            set
            {
                _FirstLayerExtrusionWidth = value;
                OnPropertyChanged("FirstLayerExtrusionWidth");
            }
        }

        private string _PerimeterExtrusionWidth;

        public string PerimeterExtrusionWidth
        {
            get
            {
                return _PerimeterExtrusionWidth ?? DEFAULT_VALUE;
            }
            set
            {
                _PerimeterExtrusionWidth = value;
                OnPropertyChanged("PerimeterExtrusionWidth");
            }
        }

        private string _ExternalPerimeterExtrusionWidth;

        public string ExternalPerimeterExtrusionWidth
        {
            get
            {
                return _ExternalPerimeterExtrusionWidth ?? DEFAULT_VALUE;
            }
            set
            {
                _ExternalPerimeterExtrusionWidth = value;
                OnPropertyChanged("ExternalPerimeterExtrusionWidth");
            }
        }

        private string _InfillExtrusionWidth;

        public string InfillExtrusionWidth
        {
            get
            {
                return _InfillExtrusionWidth ?? DEFAULT_VALUE;
            }
            set
            {
                _InfillExtrusionWidth = value;
                OnPropertyChanged("InfillExtrusionWidth");
            }
        }

        private string _SolidInfillExtrusionWidth;

        public string SolidInfillExtrusionWidth
        {
            get
            {
                return _SolidInfillExtrusionWidth ?? DEFAULT_VALUE;
            }
            set
            {
                _SolidInfillExtrusionWidth = value;
                OnPropertyChanged("SolidInfillExtrusionWidth");
            }
        }

        private string _TopInfillExtrusionWidth;

        public string TopInfillExtrusionWidth
        {
            get
            {
                return _TopInfillExtrusionWidth ?? DEFAULT_VALUE;
            }
            set
            {
                _TopInfillExtrusionWidth = value;
                OnPropertyChanged("TopInfillExtrusionWidth");
            }
        }

        private string _SupportMaterialExtrusionWidth;

        public string SupportMaterialExtrusionWidth
        {
            get
            {
                return _SupportMaterialExtrusionWidth ?? DEFAULT_VALUE;
            }
            set
            {
                _SupportMaterialExtrusionWidth = value;
                OnPropertyChanged("SupportMaterialExtrusionWidth");
            }
        }

        private string _InfillOverlap;

        public string InfillOverlap
        {
            get
            {
                return _InfillOverlap ?? DEFAULT_VALUE;
            }
            set
            {
                _InfillOverlap = value;
                OnPropertyChanged("InfillOverlap");
            }
        }

        private string _BridgeFlowRatio;

        public string BridgeFlowRatio
        {
            get
            {
                return _BridgeFlowRatio ?? DEFAULT_VALUE;
            }
            set
            {
                _BridgeFlowRatio = value;
                OnPropertyChanged("BridgeFlowRatio");
            }
        }

        private string _XySizeCompensation;

        public string XySizeCompensation
        {
            get
            {
                return _XySizeCompensation ?? DEFAULT_VALUE;
            }
            set
            {
                _XySizeCompensation = value;
                OnPropertyChanged("XySizeCompensation");
            }
        }

        private string _Threads;

        public string Threads
        {
            get
            {
                return _Threads ?? DEFAULT_VALUE;
            }
            set
            {
                _Threads = value;
                OnPropertyChanged("Threads");
            }
        }

        private string _Resolution;

        public string Resolution
        {
            get
            {
                return _Resolution ?? DEFAULT_VALUE;
            }
            set
            {
                _Resolution = value;
                OnPropertyChanged("Resolution");
            }
        }

        // Output Options
        private bool _CompleteObjects;

        public bool CompleteObjects
        {
            get
            {
                return _CompleteObjects;
            }
            set
            {
                _CompleteObjects = value;
                OnPropertyChanged("CompleteObjects");
            }
        }

        private string _ExtruderClearanceHeight;

        public string ExtruderClearanceHeight
        {
            get
            {
                return _ExtruderClearanceHeight ?? DEFAULT_VALUE;
            }
            set
            {
                _ExtruderClearanceHeight = value;
                OnPropertyChanged("ExtruderClearanceHeight");
            }
        }

        private string _ExtruderClearanceRadius;

        public string ExtruderClearanceRadius
        {
            get
            {
                return _ExtruderClearanceRadius ?? DEFAULT_VALUE;
            }
            set
            {
                _ExtruderClearanceRadius = value;
                OnPropertyChanged("ExtruderClearanceRadius");
            }
        }

        private bool _GcodeComments;

        public bool GcodeComments
        {
            get
            {
                return _GcodeComments;
            }
            set
            {
                _GcodeComments = value;
                OnPropertyChanged("GcodeComments");
            }
        }

        private string _OutputFilenameFormat;

        public string OutputFilenameFormat
        {
            get
            {
                return _OutputFilenameFormat ?? DEFAULT_VALUE;
            }
            set
            {
                _OutputFilenameFormat = value;
                OnPropertyChanged("OutputFilenameFormat");
            }
        }

        private string _PostProcess;

        public string PostProcess
        {
            get
            {
                return _PostProcess ?? DEFAULT_VALUE;
            }
            set
            {
                _PostProcess = value;
                OnPropertyChanged("PostProcess");
            }
        }

        // Notes
        private string _Notes;

        public string Notes
        {
            get
            {
                return _Notes ?? DEFAULT_VALUE;
            }
            set
            {
                _Notes = value;
                OnPropertyChanged("Notes");
            }
        }

        public Slic3rSettingsCategory Category
        {
            get
            {
                return Slic3rSettingsCategory.Print;
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
                case "avoid_crossing_perimeters":
                    AvoidCrossingPerimeters = input.ToBool();
                    break;
                case "bottom_solid_layers":
                    BottomSolidLayers = input;
                    break;
                case "bridge_acceleration":
                    BridgeAcceleration = input;
                    break;
                case "bridge_flow_ratio":
                    BridgeFlowRatio = input;
                    break;
                case "bridge_speed":
                    BridgeSpeed = input;
                    break;
                case "brim_width":
                    BrimWidth = input;
                    break;
                case "complete_objects":
                    CompleteObjects = input.ToBool();
                    break;
                case "default_acceleration":
                    DefaultAcceleration = input;
                    break;
                case "dont_support_bridges":
                    DontSupportBridges = input.ToBool();
                    break;
                case "external_fill_pattern":
                    ExternalFillPattern = (ExternalFillPattern)Enum.Parse(typeof(ExternalFillPattern), input);
                    break;
                case "external_perimeter_extrusion_width":
                    ExternalPerimeterExtrusionWidth = input;
                    break;
                case "external_perimeter_speed":
                    ExternalPerimeterSpeed = input;
                    break;
                case "external_perimeters_first":
                    ExternalPerimetersFirst = input.ToBool();
                    break;
                case "extra_perimeters":
                    ExtraPerimeters = input.ToBool();
                    break;
                case "extruder_clearance_height":
                    ExtruderClearanceHeight = input;
                    break;
                case "extruder_clearance_radius":
                    ExtruderClearanceRadius = input;
                    break;
                case "extrusion_width":
                    ExtrusionWidth = input;
                    break;
                case "fill_angle":
                    FillAngle = input;
                    break;
                case "fill_density":
                    FillDensity = input;
                    break;
                case "fill_pattern":
                    input = input.Replace("3", "three");
                    FillPattern = (FillPattern)Enum.Parse(typeof(FillPattern), input);
                    break;
                case "first_layer_acceleration":
                    FirstLayerAcceleration = input;
                    break;
                case "first_layer_extrusion_width":
                    FirstLayerExtrusionWidth = input;
                    break;
                case "first_layer_height":
                    FirstLayerHeight = input;
                    break;
                case "first_layer_speed":
                    FirstLayerSpeed = input;
                    break;
                case "gap_fill_speed":
                    GapFillSpeed = input;
                    break;
                case "gcode_comments":
                    GcodeComments = input.ToBool();
                    break;
                case "infill_acceleration":
                    InfillAcceleration = input;
                    break;
                case "infill_every_layers":
                    InfillEveryLayers = input;
                    break;
                case "infill_extruder":
                    InfillExtruder = input;
                    break;
                case "infill_extrusion_width":
                    InfillExtrusionWidth = input;
                    break;
                case "infill_first":
                    InfillFirst = input.ToBool();
                    break;
                case "infill_only_where_needed":
                    InfillOnlyWhereNeeded = input.ToBool();
                    break;
                case "infill_overlap":
                    InfillOverlap = input;
                    break;
                case "infill_speed":
                    InfillSpeed = input;
                    break;
                case "interface_shells":
                    InterfaceShells = input.ToBool();
                    break;
                case "layer_height":
                    LayerHeight = input;
                    break;
                case "max_print_speed":
                    MaxPrintSpeed = input;
                    break;
                case "max_volumetric_speed":
                    MaxVolumetricSpeed = input;
                    break;
                case "min_skirt_length":
                    MinSkirtLength = input;
                    break;
                case "notes":
                    Notes = input;
                    break;
                case "only_retract_when_crossing_perimeters":
                    OnlyRetractWhenCrossingPerimeters = input.ToBool();
                    break;
                case "ooze_prevention":
                    OozePrevention = input.ToBool();
                    break;
                case "output_filename_format":
                    OutputFilenameFormat = input;
                    break;
                case "overhangs":
                    Overhangs = input.ToBool();
                    break;
                case "perimeter_acceleration":
                    PerimeterAcceleration = input;
                    break;
                case "perimeter_extruder":
                    PerimeterExtruder = input;
                    break;
                case "perimeter_extrusion_width":
                    PerimeterExtrusionWidth = input;
                    break;
                case "perimeter_speed":
                    PerimeterSpeed = input;
                    break;
                case "perimeters":
                    Perimeters = input;
                    break;
                case "post_process":
                    PostProcess = input;
                    break;
                case "raft_layers":
                    RaftLayers = input;
                    break;
                case "resolution":
                    Resolution = input;
                    break;
                case "seam_position":
                    SeamPosition = (SeamPosition)Enum.Parse(typeof(SeamPosition), input);
                    break;
                case "skirt_distance":
                    SkirtDistance = input;
                    break;
                case "skirt_height":
                    SkirtHeight = input;
                    break;
                case "skirts":
                    Skirts = input;
                    break;
                case "small_perimeter_speed":
                    SmallPerimeterSpeed = input;
                    break;
                case "solid_infill_below_area":
                    SolidInfillBelowArea = input;
                    break;
                case "solid_infill_every_layers":
                    SolidInfillEveryLayers = input;
                    break;
                case "solid_infill_extruder":
                    SolidInfillExtruder = input;
                    break;
                case "solid_infill_extrusion_width":
                    SolidInfillExtrusionWidth = input;
                    break;
                case "solid_infill_speed":
                    SolidInfillSpeed = input;
                    break;
                case "spiral_vase":
                    SpiralVase = input.ToBool();
                    break;
                case "standby_temperature_delta":
                    StandbyTemperatureDelta = input;
                    break;
                case "support_material":
                    SupportMaterial = input.ToBool();
                    break;
                case "support_material_angle":
                    SupportMaterialAngle = input;
                    break;
                case "support_material_contact_distance":
                    SupportMaterialContactDistance = input;
                    break;
                case "support_material_enforce_layers":
                    SupportMaterialEnforceLayers = input;
                    break;
                case "support_material_extruder":
                    SupportMaterialExtruder = input;
                    break;
                case "support_material_extrusion_width":
                    SupportMaterialExtrusionWidth = input;
                    break;
                case "support_material_interface_extruder":
                    SupportMaterialInterfaceExtruder = input;
                    break;
                case "support_material_interface_layers":
                    SupportMaterialInterfaceLayers = input;
                    break;
                case "support_material_interface_spacing":
                    SupportMaterialInterfaceSpacing = input;
                    break;
                case "support_material_interface_speed":
                    SupportMaterialInterfaceSpeed = input;
                    break;
                case "support_material_pattern":
                    input = input.Replace("-", "_");
                    SupportMaterialPattern = (SupportMaterialPattern)Enum.Parse(typeof(SupportMaterialPattern), input);
                    break;
                case "support_material_spacing":
                    SupportMaterialSpacing = input;
                    break;
                case "support_material_speed":
                    SupportMaterialSpeed = input;
                    break;
                case "support_material_threshold":
                    SupportMaterialThreshold = input;
                    break;
                case "thin_walls":
                    ThinWalls = input.ToBool();
                    break;
                case "threads":
                    Threads = input;
                    break;
                case "top_infill_extrusion_width":
                    TopInfillExtrusionWidth = input;
                    break;
                case "top_solid_infill_speed":
                    TopSolidInfillSpeed = input;
                    break;
                case "top_solid_layers":
                    TopSolidLayers = input;
                    break;
                case "travel_speed":
                    TravelSpeed = input;
                    break;
                case "xy_size_compensation":
                    XySizeCompensation = input;
                    break;
            }
        }

        public override string ToString()
        {
            StringBuilder builder = new StringBuilder();

            builder.AppendFormat("{0} = {1}\n", "avoid_crossing_perimeters", AvoidCrossingPerimeters.ToSlic3rSettings());
            builder.AppendFormat("{0} = {1}\n", "bottom_solid_layers", BottomSolidLayers.ToSlic3rSettings());
            builder.AppendFormat("{0} = {1}\n", "bridge_acceleration", BridgeAcceleration.ToSlic3rSettings());
            builder.AppendFormat("{0} = {1}\n", "bridge_flow_ratio", BridgeFlowRatio.ToSlic3rSettings());
            builder.AppendFormat("{0} = {1}\n", "bridge_speed", BridgeSpeed.ToSlic3rSettings());
            builder.AppendFormat("{0} = {1}\n", "brim_width", BrimWidth.ToSlic3rSettings());
            builder.AppendFormat("{0} = {1}\n", "complete_objects", CompleteObjects.ToSlic3rSettings());
            builder.AppendFormat("{0} = {1}\n", "default_acceleration", DefaultAcceleration.ToSlic3rSettings());
            builder.AppendFormat("{0} = {1}\n", "dont_support_bridges", DontSupportBridges.ToSlic3rSettings());
            builder.AppendFormat("{0} = {1}\n", "external_fill_pattern", ExternalFillPattern.ToSlic3rSettings());
            builder.AppendFormat("{0} = {1}\n", "external_perimeter_extrusion_width", ExternalPerimeterExtrusionWidth.ToSlic3rSettings());
            builder.AppendFormat("{0} = {1}\n", "external_perimeter_speed", ExternalPerimeterSpeed.ToSlic3rSettings());
            builder.AppendFormat("{0} = {1}\n", "external_perimeters_first", ExternalPerimetersFirst.ToSlic3rSettings());
            builder.AppendFormat("{0} = {1}\n", "extra_perimeters", ExtraPerimeters.ToSlic3rSettings());
            builder.AppendFormat("{0} = {1}\n", "extruder_clearance_height", ExtruderClearanceHeight.ToSlic3rSettings());
            builder.AppendFormat("{0} = {1}\n", "extruder_clearance_radius", ExtruderClearanceRadius.ToSlic3rSettings());
            builder.AppendFormat("{0} = {1}\n", "extrusion_width", ExtrusionWidth.ToSlic3rSettings());
            builder.AppendFormat("{0} = {1}\n", "fill_angle", FillAngle.ToSlic3rSettings());
            builder.AppendFormat("{0} = {1}\n", "fill_density", FillDensity.ToSlic3rSettings());
            builder.AppendFormat("{0} = {1}\n", "fill_pattern", FillPattern.ToSlic3rSettings());
            builder.AppendFormat("{0} = {1}\n", "first_layer_acceleration", FirstLayerAcceleration.ToSlic3rSettings());
            builder.AppendFormat("{0} = {1}\n", "first_layer_extrusion_width", FirstLayerExtrusionWidth.ToSlic3rSettings());
            builder.AppendFormat("{0} = {1}\n", "first_layer_height", FirstLayerHeight.ToSlic3rSettings());
            builder.AppendFormat("{0} = {1}\n", "first_layer_speed", FirstLayerSpeed.ToSlic3rSettings());
            builder.AppendFormat("{0} = {1}\n", "gap_fill_speed", GapFillSpeed.ToSlic3rSettings());
            builder.AppendFormat("{0} = {1}\n", "gcode_comments", GcodeComments.ToSlic3rSettings());
            builder.AppendFormat("{0} = {1}\n", "infill_acceleration", InfillAcceleration.ToSlic3rSettings());
            builder.AppendFormat("{0} = {1}\n", "infill_every_layers", InfillEveryLayers.ToSlic3rSettings());
            builder.AppendFormat("{0} = {1}\n", "infill_extruder", InfillExtruder.ToSlic3rSettings());
            builder.AppendFormat("{0} = {1}\n", "infill_extrusion_width", InfillExtrusionWidth.ToSlic3rSettings());
            builder.AppendFormat("{0} = {1}\n", "infill_first", InfillFirst.ToSlic3rSettings());
            builder.AppendFormat("{0} = {1}\n", "infill_only_where_needed", InfillOnlyWhereNeeded.ToSlic3rSettings());
            builder.AppendFormat("{0} = {1}\n", "infill_overlap", InfillOverlap.ToSlic3rSettings());
            builder.AppendFormat("{0} = {1}\n", "infill_speed", InfillSpeed.ToSlic3rSettings());
            builder.AppendFormat("{0} = {1}\n", "interface_shells", InterfaceShells.ToSlic3rSettings());
            builder.AppendFormat("{0} = {1}\n", "layer_height", LayerHeight.ToSlic3rSettings());
            builder.AppendFormat("{0} = {1}\n", "max_print_speed", MaxPrintSpeed.ToSlic3rSettings());
            builder.AppendFormat("{0} = {1}\n", "max_volumetric_speed", MaxVolumetricSpeed.ToSlic3rSettings());
            builder.AppendFormat("{0} = {1}\n", "min_skirt_length", MinSkirtLength.ToSlic3rSettings());
            builder.AppendFormat("{0} = {1}\n", "notes", Notes.ToSlic3rSettings());
            builder.AppendFormat("{0} = {1}\n", "only_retract_when_crossing_perimeters", OnlyRetractWhenCrossingPerimeters.ToSlic3rSettings());
            builder.AppendFormat("{0} = {1}\n", "ooze_prevention", OozePrevention.ToSlic3rSettings());
            builder.AppendFormat("{0} = {1}\n", "output_filename_format", OutputFilenameFormat.ToSlic3rSettings());
            builder.AppendFormat("{0} = {1}\n", "overhangs", Overhangs.ToSlic3rSettings());
            builder.AppendFormat("{0} = {1}\n", "perimeter_acceleration", PerimeterAcceleration.ToSlic3rSettings());
            builder.AppendFormat("{0} = {1}\n", "perimeter_extruder", PerimeterExtruder.ToSlic3rSettings());
            builder.AppendFormat("{0} = {1}\n", "perimeter_extrusion_width", PerimeterExtrusionWidth.ToSlic3rSettings());
            builder.AppendFormat("{0} = {1}\n", "perimeter_speed", PerimeterSpeed.ToSlic3rSettings());
            builder.AppendFormat("{0} = {1}\n", "perimeters", Perimeters.ToSlic3rSettings());
            builder.AppendFormat("{0} = {1}\n", "post_process", PostProcess.ToSlic3rSettings());
            builder.AppendFormat("{0} = {1}\n", "raft_layers", RaftLayers.ToSlic3rSettings());
            builder.AppendFormat("{0} = {1}\n", "resolution", Resolution.ToSlic3rSettings());
            builder.AppendFormat("{0} = {1}\n", "seam_position", SeamPosition.ToSlic3rSettings());
            builder.AppendFormat("{0} = {1}\n", "skirt_distance", SkirtDistance.ToSlic3rSettings());
            builder.AppendFormat("{0} = {1}\n", "skirt_height", SkirtHeight.ToSlic3rSettings());
            builder.AppendFormat("{0} = {1}\n", "skirts", Skirts.ToSlic3rSettings());
            builder.AppendFormat("{0} = {1}\n", "small_perimeter_speed", SmallPerimeterSpeed.ToSlic3rSettings());
            builder.AppendFormat("{0} = {1}\n", "solid_infill_below_area", SolidInfillBelowArea.ToSlic3rSettings());
            builder.AppendFormat("{0} = {1}\n", "solid_infill_every_layers", SolidInfillEveryLayers.ToSlic3rSettings());
            builder.AppendFormat("{0} = {1}\n", "solid_infill_extruder", SolidInfillExtruder.ToSlic3rSettings());
            builder.AppendFormat("{0} = {1}\n", "solid_infill_extrusion_width", SolidInfillExtrusionWidth.ToSlic3rSettings());
            builder.AppendFormat("{0} = {1}\n", "solid_infill_speed", SolidInfillSpeed.ToSlic3rSettings());
            builder.AppendFormat("{0} = {1}\n", "spiral_vase", SpiralVase.ToSlic3rSettings());
            builder.AppendFormat("{0} = {1}\n", "standby_temperature_delta", StandbyTemperatureDelta.ToSlic3rSettings());
            builder.AppendFormat("{0} = {1}\n", "support_material", SupportMaterial.ToSlic3rSettings());
            builder.AppendFormat("{0} = {1}\n", "support_material_angle", SupportMaterialAngle.ToSlic3rSettings());
            builder.AppendFormat("{0} = {1}\n", "support_material_contact_distance", SupportMaterialContactDistance.ToSlic3rSettings());
            builder.AppendFormat("{0} = {1}\n", "support_material_enforce_layers", SupportMaterialEnforceLayers.ToSlic3rSettings());
            builder.AppendFormat("{0} = {1}\n", "support_material_extruder", SupportMaterialExtruder.ToSlic3rSettings());
            builder.AppendFormat("{0} = {1}\n", "support_material_extrusion_width", SupportMaterialExtrusionWidth.ToSlic3rSettings());
            builder.AppendFormat("{0} = {1}\n", "support_material_interface_extruder", SupportMaterialInterfaceExtruder.ToSlic3rSettings());
            builder.AppendFormat("{0} = {1}\n", "support_material_interface_layers", SupportMaterialInterfaceLayers.ToSlic3rSettings());
            builder.AppendFormat("{0} = {1}\n", "support_material_interface_spacing", SupportMaterialInterfaceSpacing.ToSlic3rSettings());
            builder.AppendFormat("{0} = {1}\n", "support_material_interface_speed", SupportMaterialInterfaceSpeed.ToSlic3rSettings());
            builder.AppendFormat("{0} = {1}\n", "support_material_pattern", SupportMaterialPattern.ToSlic3rSettings());
            builder.AppendFormat("{0} = {1}\n", "support_material_spacing", SupportMaterialSpacing.ToSlic3rSettings());
            builder.AppendFormat("{0} = {1}\n", "support_material_speed", SupportMaterialSpeed.ToSlic3rSettings());
            builder.AppendFormat("{0} = {1}\n", "support_material_threshold", SupportMaterialThreshold.ToSlic3rSettings());
            builder.AppendFormat("{0} = {1}\n", "thin_walls", ThinWalls.ToSlic3rSettings());
            builder.AppendFormat("{0} = {1}\n", "threads", Threads.ToSlic3rSettings());
            builder.AppendFormat("{0} = {1}\n", "top_infill_extrusion_width", TopInfillExtrusionWidth.ToSlic3rSettings());
            builder.AppendFormat("{0} = {1}\n", "top_solid_infill_speed", TopSolidInfillSpeed.ToSlic3rSettings());
            builder.AppendFormat("{0} = {1}\n", "top_solid_layers", TopSolidLayers.ToSlic3rSettings());
            builder.AppendFormat("{0} = {1}\n", "travel_speed", TravelSpeed.ToSlic3rSettings());
            builder.AppendFormat("{0} = {1}\n", "xy_size_compensation", XySizeCompensation.ToSlic3rSettings());

            return builder.ToString();
        }
    }
}