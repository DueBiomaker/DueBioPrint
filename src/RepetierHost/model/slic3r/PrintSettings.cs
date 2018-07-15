using System.ComponentModel;
using System.Text;

namespace RepetierHost.model.slic3r
{
    public class PrintSettings : INotifyPropertyChanged
    {
        private const string DEFAULT_VALUE = "0";

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

        private string _SeamPosition;

        public string SeamPosition
        {
            get
            {
                return _SeamPosition ?? DEFAULT_VALUE;
            }
            set
            {
                _SeamPosition = value;
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

        private string _FillPattern;

        public string FillPattern
        {
            get
            {
                return _FillPattern ?? DEFAULT_VALUE;
            }
            set
            {
                _FillPattern = value;
                OnPropertyChanged("FillPattern");
            }
        }

        private string _ExternalFillPattern;

        public string ExternalFillPattern
        {
            get
            {
                return _ExternalFillPattern ?? DEFAULT_VALUE;
            }
            set
            {
                _ExternalFillPattern = value;
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
        private string _SupportMaterial;

        public string SupportMaterial
        {
            get
            {
                return _SupportMaterial ?? DEFAULT_VALUE;
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

        private string _SupportMaterialPattern;

        public string SupportMaterialPattern
        {
            get
            {
                return _SupportMaterialPattern ?? DEFAULT_VALUE;
            }
            set
            {
                _SupportMaterialPattern = value;
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

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string name)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

        public override string ToString()
        {
            StringBuilder builder = new StringBuilder();

            builder.AppendFormat("{0} = {1}\n", "avoid_crossing_perimeters", AvoidCrossingPerimeters);
            builder.AppendFormat("{0} = {1}\n", "bottom_solid_layers", BottomSolidLayers);
            builder.AppendFormat("{0} = {1}\n", "bridge_acceleration", BridgeAcceleration);
            builder.AppendFormat("{0} = {1}\n", "bridge_flow_ratio", BridgeFlowRatio);
            builder.AppendFormat("{0} = {1}\n", "bridge_speed", BridgeSpeed);
            builder.AppendFormat("{0} = {1}\n", "brim_width", BrimWidth);
            builder.AppendFormat("{0} = {1}\n", "complete_objects", CompleteObjects);
            builder.AppendFormat("{0} = {1}\n", "default_acceleration", DefaultAcceleration);
            builder.AppendFormat("{0} = {1}\n", "dont_support_bridges", DontSupportBridges);
            builder.AppendFormat("{0} = {1}\n", "external_fill_pattern", ExternalFillPattern);
            builder.AppendFormat("{0} = {1}\n", "external_perimeter_extrusion_width", ExternalPerimeterExtrusionWidth);
            builder.AppendFormat("{0} = {1}\n", "external_perimeter_speed", ExternalPerimeterSpeed);
            builder.AppendFormat("{0} = {1}\n", "external_perimeters_first", ExternalPerimetersFirst);
            builder.AppendFormat("{0} = {1}\n", "extra_perimeters", ExtraPerimeters);
            builder.AppendFormat("{0} = {1}\n", "extruder_clearance_height", ExtruderClearanceHeight);
            builder.AppendFormat("{0} = {1}\n", "extruder_clearance_radius", ExtruderClearanceRadius);
            builder.AppendFormat("{0} = {1}\n", "extrusion_width", ExtrusionWidth);
            builder.AppendFormat("{0} = {1}\n", "fill_angle", FillAngle);
            builder.AppendFormat("{0} = {1}\n", "fill_density", FillDensity);
            builder.AppendFormat("{0} = {1}\n", "fill_pattern", FillPattern);
            builder.AppendFormat("{0} = {1}\n", "first_layer_acceleration", FirstLayerAcceleration);
            builder.AppendFormat("{0} = {1}\n", "first_layer_extrusion_width", FirstLayerExtrusionWidth);
            builder.AppendFormat("{0} = {1}\n", "first_layer_height", FirstLayerHeight);
            builder.AppendFormat("{0} = {1}\n", "first_layer_speed", FirstLayerSpeed);
            builder.AppendFormat("{0} = {1}\n", "gap_fill_speed", GapFillSpeed);
            builder.AppendFormat("{0} = {1}\n", "gcode_comments", GcodeComments);
            builder.AppendFormat("{0} = {1}\n", "infill_acceleration", InfillAcceleration);
            builder.AppendFormat("{0} = {1}\n", "infill_every_layers", InfillEveryLayers);
            builder.AppendFormat("{0} = {1}\n", "infill_extruder", InfillExtruder);
            builder.AppendFormat("{0} = {1}\n", "infill_extrusion_width", InfillExtrusionWidth);
            builder.AppendFormat("{0} = {1}\n", "infill_first", InfillFirst);
            builder.AppendFormat("{0} = {1}\n", "infill_only_where_needed", InfillOnlyWhereNeeded);
            builder.AppendFormat("{0} = {1}\n", "infill_overlap", InfillOverlap);
            builder.AppendFormat("{0} = {1}\n", "infill_speed", InfillSpeed);
            builder.AppendFormat("{0} = {1}\n", "interface_shells", InterfaceShells);
            builder.AppendFormat("{0} = {1}\n", "layer_height", LayerHeight);
            builder.AppendFormat("{0} = {1}\n", "max_print_speed", MaxPrintSpeed);
            builder.AppendFormat("{0} = {1}\n", "max_volumetric_speed", MaxVolumetricSpeed);
            builder.AppendFormat("{0} = {1}\n", "min_skirt_length", MinSkirtLength);
            builder.AppendFormat("{0} = {1}\n", "notes", Notes);
            builder.AppendFormat("{0} = {1}\n", "only_retract_when_crossing_perimeters", OnlyRetractWhenCrossingPerimeters);
            builder.AppendFormat("{0} = {1}\n", "ooze_prevention", OozePrevention);
            builder.AppendFormat("{0} = {1}\n", "output_filename_format", OutputFilenameFormat);
            builder.AppendFormat("{0} = {1}\n", "overhangs", Overhangs);
            builder.AppendFormat("{0} = {1}\n", "perimeter_acceleration", PerimeterAcceleration);
            builder.AppendFormat("{0} = {1}\n", "perimeter_extruder", PerimeterExtruder);
            builder.AppendFormat("{0} = {1}\n", "perimeter_extrusion_width", PerimeterExtrusionWidth);
            builder.AppendFormat("{0} = {1}\n", "perimeter_speed", PerimeterSpeed);
            builder.AppendFormat("{0} = {1}\n", "perimeters", Perimeters);
            builder.AppendFormat("{0} = {1}\n", "post_process", PostProcess);
            builder.AppendFormat("{0} = {1}\n", "raft_layers", RaftLayers);
            builder.AppendFormat("{0} = {1}\n", "resolution", Resolution);
            builder.AppendFormat("{0} = {1}\n", "seam_position", SeamPosition);
            builder.AppendFormat("{0} = {1}\n", "skirt_distance", SkirtDistance);
            builder.AppendFormat("{0} = {1}\n", "skirt_height", SkirtHeight);
            builder.AppendFormat("{0} = {1}\n", "skirts", Skirts);
            builder.AppendFormat("{0} = {1}\n", "small_perimeter_speed", SmallPerimeterSpeed);
            builder.AppendFormat("{0} = {1}\n", "solid_infill_below_area", SolidInfillBelowArea);
            builder.AppendFormat("{0} = {1}\n", "solid_infill_every_layers", SolidInfillEveryLayers);
            builder.AppendFormat("{0} = {1}\n", "solid_infill_extruder", SolidInfillExtruder);
            builder.AppendFormat("{0} = {1}\n", "solid_infill_extrusion_width", SolidInfillExtrusionWidth);
            builder.AppendFormat("{0} = {1}\n", "solid_infill_speed", SolidInfillSpeed);
            builder.AppendFormat("{0} = {1}\n", "spiral_vase", SpiralVase);
            builder.AppendFormat("{0} = {1}\n", "standby_temperature_delta", StandbyTemperatureDelta);
            builder.AppendFormat("{0} = {1}\n", "support_material", SupportMaterial);
            builder.AppendFormat("{0} = {1}\n", "support_material_angle", SupportMaterialAngle);
            builder.AppendFormat("{0} = {1}\n", "support_material_contact_distance", SupportMaterialContactDistance);
            builder.AppendFormat("{0} = {1}\n", "support_material_enforce_layers", SupportMaterialEnforceLayers);
            builder.AppendFormat("{0} = {1}\n", "support_material_extruder", SupportMaterialExtruder);
            builder.AppendFormat("{0} = {1}\n", "support_material_extrusion_width", SupportMaterialExtrusionWidth);
            builder.AppendFormat("{0} = {1}\n", "support_material_interface_extruder", SupportMaterialInterfaceExtruder);
            builder.AppendFormat("{0} = {1}\n", "support_material_interface_layers", SupportMaterialInterfaceLayers);
            builder.AppendFormat("{0} = {1}\n", "support_material_interface_spacing", SupportMaterialInterfaceSpacing);
            builder.AppendFormat("{0} = {1}\n", "support_material_interface_speed", SupportMaterialInterfaceSpeed);
            builder.AppendFormat("{0} = {1}\n", "support_material_pattern", SupportMaterialPattern);
            builder.AppendFormat("{0} = {1}\n", "support_material_spacing", SupportMaterialSpacing);
            builder.AppendFormat("{0} = {1}\n", "support_material_speed", SupportMaterialSpeed);
            builder.AppendFormat("{0} = {1}\n", "support_material_threshold", SupportMaterialThreshold);
            builder.AppendFormat("{0} = {1}\n", "thin_walls", ThinWalls);
            builder.AppendFormat("{0} = {1}\n", "threads", Threads);
            builder.AppendFormat("{0} = {1}\n", "top_infill_extrusion_width", TopInfillExtrusionWidth);
            builder.AppendFormat("{0} = {1}\n", "top_solid_infill_speed", TopSolidInfillSpeed);
            builder.AppendFormat("{0} = {1}\n", "top_solid_layers", TopSolidLayers);
            builder.AppendFormat("{0} = {1}\n", "travel_speed", TravelSpeed);
            builder.AppendFormat("{0} = {1}\n", "xy_size_compensation", XySizeCompensation);

            return builder.ToString();
        }
    }
}