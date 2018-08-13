using RepetierHost.controller;
using RepetierHost.extensions;
using RepetierHost.model;
using RepetierHost.model.slic3r;
using RepetierHost.util;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Reflection;
using System.Windows.Forms;

namespace RepetierHost.view
{
    public partial class Slic3rSettings : Form
    {
        private const string EXTRUDE_TITLE_FORMAT = "Extruder {0}";

        private PrintSettings PrintSettings { get; set; }
        private FilamentSettings FilamentSettings { get; set; }
        private PrinterSettings PrinterSettings { get; set; }
        private Slic3rSettingsController SettingsController { get; set; }

        public Slic3rSettings()
        {
            InitializeComponent();
            SettingsController = new Slic3rSettingsController(SettingsUtils.GetSlic3rDirectory());
            PrintSettings = new PrintSettings();
            FilamentSettings = new FilamentSettings();
            PrinterSettings = new PrinterSettings();
            PreparePrintBindings();
            PrepareFilamentBindings();
            PreparePrinterBindings();
            Customization();

            if (Main.main != null)
            {
                Main.main.languageChanged += translate;
                translate();
            }
        }

        private void Slic3rSettings_Load(object sender, EventArgs e)
        {
            LoadAndFillProfileList();
            LoadProfiles();
        }

        private void LoadProfiles()
        {
            LoadProfile(Slic3rSettingsCategory.Print);
            LoadProfile(Slic3rSettingsCategory.Filament);
            LoadProfile(Slic3rSettingsCategory.Printer);
        }

        public void Customization()
        {
            cboxSeamPosition.DropDownStyle = ComboBoxStyle.DropDownList;
            cboxSeamPosition.SelectedIndex = 0;
            cboxFillPattern.DropDownStyle = ComboBoxStyle.DropDownList;
            cboxFillPattern.SelectedIndex = 0;
            cboxExternalFillPattern.DropDownStyle = ComboBoxStyle.DropDownList;
            cboxExternalFillPattern.SelectedIndex = 0;
            cboxSupportMaterialPattern.DropDownStyle = ComboBoxStyle.DropDownList;
            cboxExternalFillPattern.SelectedIndex = 0;
            cboxGcodeFlavor.DropDownStyle = ComboBoxStyle.DropDownList;
            cboxGcodeFlavor.SelectedIndex = 0;
        }

        public void LoadAndFillProfileList()
        {
            cboxPrintProfiles.Items.Clear();
            cboxPrintProfiles.Items.AddRange(SettingsController.FindAvailableProfiles(Slic3rSettingsCategory.Print).ToArray());
            cboxPrintProfiles.SelectedIndex = 0;

            cboxFilamentProfiles.Items.Clear();
            cboxFilamentProfiles.Items.AddRange(SettingsController.FindAvailableProfiles(Slic3rSettingsCategory.Filament).ToArray());
            cboxFilamentProfiles.SelectedIndex = 0;

            cboxPrinterProfiles.Items.Clear();
            cboxPrinterProfiles.Items.AddRange(SettingsController.FindAvailableProfiles(Slic3rSettingsCategory.Printer).ToArray());
            cboxPrinterProfiles.SelectedIndex = 0;

            btnDeletePrintSettings.Enabled = true;
            btnDeleteFilamentSettings.Enabled = true;
            btnDeletePrinterSettings.Enabled = true;
        }

        public void LoadProfile(Slic3rSettingsCategory category)
        {
            switch (category)
            {
                case Slic3rSettingsCategory.Print:
                    SettingsController.LoadSettingsProfile(Slic3rSettingsCategory.Print, cboxPrintProfiles.Text, PrintSettings);
                    break;

                case Slic3rSettingsCategory.Filament:
                    SettingsController.LoadSettingsProfile(Slic3rSettingsCategory.Filament, cboxFilamentProfiles.Text, FilamentSettings);
                    break;

                case Slic3rSettingsCategory.Printer:
                    SettingsController.LoadSettingsProfile(Slic3rSettingsCategory.Printer, cboxPrinterProfiles.Text, PrinterSettings);
                    LoadExtrudersPage();
                    break;

                default:
                    break;
            }
        }

        public void PreparePrintBindings()
        {
            lbPrintSettingsCategories.Items?.Clear();
            lbPrintSettingsCategories.Items.AddRange(EnumUtils.GetDescriptions<PrintSettingsCategory>());
            lbPrintSettingsCategories.SelectedIndex = 0;

            PrepareLayerAndPerimetersBinding();
            PrepareInfillBinding();
            PrepareSkirtAndBrimBinding();
            PrepareSupportMaterialBinding();
            PrepareSpeedBinding();
            PrepareMultipleExtrudersBinding();
            PrepareAdvancedBinding();
            PrepareOutputOptionsBinding();
            PrepareNotesBinding();
        }

        public void PrepareFilamentBindings()
        {
            lbFilamentSettingsCategories.Items?.Clear();
            lbFilamentSettingsCategories.Items.AddRange(EnumUtils.GetDescriptions<FilamentSettingsCategory>());
            lbFilamentSettingsCategories.SelectedIndex = 0;

            PrepareFilamentBinding();
            PrepareCoolingBinding();
        }

        public void PreparePrinterBindings()
        {
            lbPrinterSettingsCategories.Items?.Clear();
            lbPrinterSettingsCategories.Items.AddRange(EnumUtils.GetDescriptions<PrinterSettingsCategory>());
            lbPrinterSettingsCategories.SelectedIndex = 0;

            PrepareGeneralBinding();
            PrepareCustomGcodeBinding();
        }

        public void PrepareLayerAndPerimetersBinding()
        {
            cboxSeamPosition.Items.Clear();
            cboxSeamPosition.Items.AddRange(EnumUtils.GetDescriptions<SeamPosition>());

            tbLayerHeight.DataBindings.Add("Text", PrintSettings, "LayerHeight", false, DataSourceUpdateMode.OnPropertyChanged);
            tbFirstLayerHeight.DataBindings.Add("Text", PrintSettings, "FirstLayerHeight", false, DataSourceUpdateMode.OnPropertyChanged);
            nbPerimeters.DataBindings.Add("Value", PrintSettings, "Perimeters", false, DataSourceUpdateMode.OnPropertyChanged);
            cbSpiralVase.DataBindings.Add("Checked", PrintSettings, "SpiralVase", false, DataSourceUpdateMode.OnPropertyChanged);
            nbTopSolidLayers.DataBindings.Add("Value", PrintSettings, "TopSolidLayers", false, DataSourceUpdateMode.OnPropertyChanged);
            nbBottomSolidLayers.DataBindings.Add("Value", PrintSettings, "BottomSolidLayers", false, DataSourceUpdateMode.OnPropertyChanged);
            cbExtraPerimetersfNeeded.DataBindings.Add("Checked", PrintSettings, "ExtraPerimeters", false, DataSourceUpdateMode.OnPropertyChanged);
            cbAvoidCrossingPerimeters.DataBindings.Add("Checked", PrintSettings, "AvoidCrossingPerimeters", false, DataSourceUpdateMode.OnPropertyChanged);
            cbThinWalls.DataBindings.Add("Checked", PrintSettings, "ThinWalls", false, DataSourceUpdateMode.OnPropertyChanged);
            cbOverhangs.DataBindings.Add("Checked", PrintSettings, "Overhangs", false, DataSourceUpdateMode.OnPropertyChanged);
            cboxSeamPosition.DataBindings.Add("SelectedIndex", PrintSettings, "SeamPositionInt", false, DataSourceUpdateMode.OnPropertyChanged);
            cbExternalPerimetersFirst.DataBindings.Add("Checked", PrintSettings, "ExternalPerimetersFirst", false, DataSourceUpdateMode.OnPropertyChanged);
        }

        public void PrepareInfillBinding()
        {
            cboxFillPattern.Items.Clear();
            cboxFillPattern.Items.AddRange(EnumUtils.GetDescriptions<FillPattern>());
            cboxExternalFillPattern.Items.Clear();
            cboxExternalFillPattern.Items.AddRange(EnumUtils.GetDescriptions<ExternalFillPattern>());

            cboxFillDensity.DataBindings.Add("Text", PrintSettings, "FillDensity", false, DataSourceUpdateMode.OnPropertyChanged);
            cboxFillPattern.DataBindings.Add("SelectedIndex", PrintSettings, "FillPatternInt", false, DataSourceUpdateMode.OnPropertyChanged);
            cboxExternalFillPattern.DataBindings.Add("SelectedIndex", PrintSettings, "ExternalFillPatternInt", false, DataSourceUpdateMode.OnPropertyChanged);
            nbInfillEveryLayers.DataBindings.Add("Value", PrintSettings, "InfillEveryLayers", false, DataSourceUpdateMode.OnPropertyChanged);
            cbInfillOnlyWhereNeeded.DataBindings.Add("Checked", PrintSettings, "InfillOnlyWhereNeeded", false, DataSourceUpdateMode.OnPropertyChanged);
            nbSolidInfillEveryLayers.DataBindings.Add("Value", PrintSettings, "SolidInfillEveryLayers", false, DataSourceUpdateMode.OnPropertyChanged);
            nbFillAngle.DataBindings.Add("Value", PrintSettings, "FillAngle", false, DataSourceUpdateMode.OnPropertyChanged);
            tbSolidInfillBellowArea.DataBindings.Add("Text", PrintSettings, "SolidInfillBelowArea", false, DataSourceUpdateMode.OnPropertyChanged);
            cbOnlyRetractWhenCrossingPerimeters.DataBindings.Add("Checked", PrintSettings, "OnlyRetractWhenCrossingPerimeters", false, DataSourceUpdateMode.OnPropertyChanged);
            cbInfillFirst.DataBindings.Add("Checked", PrintSettings, "InfillFirst", false, DataSourceUpdateMode.OnPropertyChanged);
        }

        public void PrepareSkirtAndBrimBinding()
        {
            nbSkirts.DataBindings.Add("Value", PrintSettings, "Skirts", false, DataSourceUpdateMode.OnPropertyChanged);
            tbSkirtDistance.DataBindings.Add("Text", PrintSettings, "SkirtDistance", false, DataSourceUpdateMode.OnPropertyChanged);
            nbSkirtHeight.DataBindings.Add("Value", PrintSettings, "SkirtHeight", false, DataSourceUpdateMode.OnPropertyChanged);
            tbMinSkirtLength.DataBindings.Add("Text", PrintSettings, "MinSkirtLength", false, DataSourceUpdateMode.OnPropertyChanged);
            tbBrimWidth.DataBindings.Add("Text", PrintSettings, "BrimWidth", false, DataSourceUpdateMode.OnPropertyChanged);
        }

        public void PrepareSupportMaterialBinding()
        {
            gbSupportMaterial.DataBindings.Add("Enabled", PrintSettings, "SupportMaterial", false, DataSourceUpdateMode.OnPropertyChanged);
            gbRaft.DataBindings.Add("Enabled", PrintSettings, "SupportMaterial", false, DataSourceUpdateMode.OnPropertyChanged);
            gbSupportMaterialOptions.DataBindings.Add("Enabled", PrintSettings, "SupportMaterial", false, DataSourceUpdateMode.OnPropertyChanged);

            cboxSupportMaterialPattern.Items.Clear();
            cboxSupportMaterialPattern.Items.AddRange(EnumUtils.GetDescriptions<SupportMaterialPattern>());

            cbSupportMaterial.DataBindings.Add("Checked", PrintSettings, "SupportMaterial", false, DataSourceUpdateMode.OnPropertyChanged);
            nbSupportMaterialThreshold.DataBindings.Add("Text", PrintSettings, "SupportMaterialThreshold", false, DataSourceUpdateMode.OnPropertyChanged);
            nbSupportMaterialEnforceLayers.DataBindings.Add("Text", PrintSettings, "SupportMaterialEnforceLayers", false, DataSourceUpdateMode.OnPropertyChanged);
            nbRaftLayers.DataBindings.Add("Text", PrintSettings, "RaftLayers", false, DataSourceUpdateMode.OnPropertyChanged);
            nbSupportMaterialContactDistance.DataBindings.Add("Text", PrintSettings, "SupportMaterialContactDistance", false, DataSourceUpdateMode.OnPropertyChanged);
            cboxSupportMaterialPattern.DataBindings.Add("SelectedIndex", PrintSettings, "SupportMaterialPatternInt", false, DataSourceUpdateMode.OnPropertyChanged);
            tbSupportMaterialSpacing.DataBindings.Add("Text", PrintSettings, "SupportMaterialSpacing", false, DataSourceUpdateMode.OnPropertyChanged);
            nbSupportMaterialAngle.DataBindings.Add("Text", PrintSettings, "SupportMaterialAngle", false, DataSourceUpdateMode.OnPropertyChanged);
            nbSupportMaterialInterfaceLayers.DataBindings.Add("Text", PrintSettings, "SupportMaterialInterfaceLayers", false, DataSourceUpdateMode.OnPropertyChanged);
            tbSupportMaterialInterfaceSpacing.DataBindings.Add("Text", PrintSettings, "SupportMaterialInterfaceSpacing", false, DataSourceUpdateMode.OnPropertyChanged);
            cbDontSupportBridges.DataBindings.Add("Checked", PrintSettings, "DontSupportBridges", false, DataSourceUpdateMode.OnPropertyChanged);
        }

        public void PrepareSpeedBinding()
        {
            tbPerimeterSpeed.DataBindings.Add("Text", PrintSettings, "PerimeterSpeed", false, DataSourceUpdateMode.OnPropertyChanged);
            tbSmallPerimeterSpeed.DataBindings.Add("Text", PrintSettings, "SmallPerimeterSpeed", false, DataSourceUpdateMode.OnPropertyChanged);
            tbExternalPerimeterSpeed.DataBindings.Add("Text", PrintSettings, "ExternalPerimeterSpeed", false, DataSourceUpdateMode.OnPropertyChanged);
            tbInfillSpeed.DataBindings.Add("Text", PrintSettings, "InfillSpeed", false, DataSourceUpdateMode.OnPropertyChanged);
            tbSolidInfillSpeed.DataBindings.Add("Text", PrintSettings, "SolidInfillSpeed", false, DataSourceUpdateMode.OnPropertyChanged);
            tbTopSolidInfillSpeed.DataBindings.Add("Text", PrintSettings, "TopSolidInfillSpeed", false, DataSourceUpdateMode.OnPropertyChanged);
            tbSupportMaterialSpeed.DataBindings.Add("Text", PrintSettings, "SupportMaterialSpeed", false, DataSourceUpdateMode.OnPropertyChanged);
            tbSupportMaterialInterfaceSpeed.DataBindings.Add("Text", PrintSettings, "SupportMaterialInterfaceSpeed", false, DataSourceUpdateMode.OnPropertyChanged);
            tbBridgeSpeed.DataBindings.Add("Text", PrintSettings, "BridgeSpeed", false, DataSourceUpdateMode.OnPropertyChanged);
            tbGapFillSpeed.DataBindings.Add("Text", PrintSettings, "GapFillSpeed", false, DataSourceUpdateMode.OnPropertyChanged);
            tbTravelSpeed.DataBindings.Add("Text", PrintSettings, "TravelSpeed", false, DataSourceUpdateMode.OnPropertyChanged);
            tbFirstLayerSpeed.DataBindings.Add("Text", PrintSettings, "FirstLayerSpeed", false, DataSourceUpdateMode.OnPropertyChanged);
            tbPerimeterAcceleration.DataBindings.Add("Text", PrintSettings, "PerimeterAcceleration", false, DataSourceUpdateMode.OnPropertyChanged);
            tbInfillAcceleration.DataBindings.Add("Text", PrintSettings, "InfillAcceleration", false, DataSourceUpdateMode.OnPropertyChanged);
            tbBridgeAcceleration.DataBindings.Add("Text", PrintSettings, "BridgeAcceleration", false, DataSourceUpdateMode.OnPropertyChanged);
            tbFirstLayerAcceleration.DataBindings.Add("Text", PrintSettings, "FirstLayerAcceleration", false, DataSourceUpdateMode.OnPropertyChanged);
            tbDefaultAcceleration.DataBindings.Add("Text", PrintSettings, "DefaultAcceleration", false, DataSourceUpdateMode.OnPropertyChanged);
            tbMaxPrintSpeed.DataBindings.Add("Text", PrintSettings, "MaxPrintSpeed", false, DataSourceUpdateMode.OnPropertyChanged);
            tbMaxVolumetricSpeed.DataBindings.Add("Text", PrintSettings, "MaxVolumetricSpeed", false, DataSourceUpdateMode.OnPropertyChanged);
        }

        public void PrepareMultipleExtrudersBinding()
        {
            nbStandbyTemperatureDelta.DataBindings.Add("Enabled", PrintSettings, "OozePrevention", false, DataSourceUpdateMode.OnPropertyChanged);

            nbPerimeterExtruder.DataBindings.Add("Value", PrintSettings, "PerimeterExtruder", false, DataSourceUpdateMode.OnPropertyChanged);
            nbInfillExtruder.DataBindings.Add("Value", PrintSettings, "InfillExtruder", false, DataSourceUpdateMode.OnPropertyChanged);
            nbSolidInfillExtruder.DataBindings.Add("Value", PrintSettings, "SolidInfillExtruder", false, DataSourceUpdateMode.OnPropertyChanged);
            nbSupportMaterialExtruder.DataBindings.Add("Value", PrintSettings, "SupportMaterialExtruder", false, DataSourceUpdateMode.OnPropertyChanged);
            nbSupportMaterialInterfaceExtruder.DataBindings.Add("Value", PrintSettings, "SupportMaterialInterfaceExtruder", false, DataSourceUpdateMode.OnPropertyChanged);
            cbOozePrevention.DataBindings.Add("Checked", PrintSettings, "OozePrevention", false, DataSourceUpdateMode.OnPropertyChanged);
            nbStandbyTemperatureDelta.DataBindings.Add("Value", PrintSettings, "StandbyTemperatureDelta", false, DataSourceUpdateMode.OnPropertyChanged);
            cbInterfaceShells.DataBindings.Add("Checked", PrintSettings, "InterfaceShells", false, DataSourceUpdateMode.OnPropertyChanged);
        }

        public void PrepareAdvancedBinding()
        {
            tbExtrusionWidth.DataBindings.Add("Text", PrintSettings, "ExtrusionWidth", false, DataSourceUpdateMode.OnPropertyChanged);
            tbFirstLayerExtrusionWidth.DataBindings.Add("Text", PrintSettings, "FirstLayerExtrusionWidth", false, DataSourceUpdateMode.OnPropertyChanged);
            tbPerimeterExtrusionWidth.DataBindings.Add("Text", PrintSettings, "PerimeterExtrusionWidth", false, DataSourceUpdateMode.OnPropertyChanged);
            tbExternalPerimeterExtrusionWidth.DataBindings.Add("Text", PrintSettings, "ExternalPerimeterExtrusionWidth", false, DataSourceUpdateMode.OnPropertyChanged);
            tbInfillExtrusionWidth.DataBindings.Add("Text", PrintSettings, "InfillExtrusionWidth", false, DataSourceUpdateMode.OnPropertyChanged);
            tbSolidInfillExtrusionWidth.DataBindings.Add("Text", PrintSettings, "SolidInfillExtrusionWidth", false, DataSourceUpdateMode.OnPropertyChanged);
            tbTopInfillExtrusionWidth.DataBindings.Add("Text", PrintSettings, "TopInfillExtrusionWidth", false, DataSourceUpdateMode.OnPropertyChanged);
            tbSupportMaterialExtrusionWidth.DataBindings.Add("Text", PrintSettings, "SupportMaterialExtrusionWidth", false, DataSourceUpdateMode.OnPropertyChanged);
            tbInfillOverlap.DataBindings.Add("Text", PrintSettings, "InfillOverlap", false, DataSourceUpdateMode.OnPropertyChanged);
            tbBridgeFlowRatio.DataBindings.Add("Text", PrintSettings, "BridgeFlowRatio", false, DataSourceUpdateMode.OnPropertyChanged);
            tbXySizeCompensation.DataBindings.Add("Text", PrintSettings, "XySizeCompensation", false, DataSourceUpdateMode.OnPropertyChanged);
            nbThreads.DataBindings.Add("Value", PrintSettings, "Threads", false, DataSourceUpdateMode.OnPropertyChanged);
            tbResolution.DataBindings.Add("Text", PrintSettings, "Resolution", false, DataSourceUpdateMode.OnPropertyChanged);
        }

        public void PrepareOutputOptionsBinding()
        {
            gbExtruderClearance.DataBindings.Add("Enabled", PrintSettings, "CompleteObjects", false, DataSourceUpdateMode.OnPropertyChanged);

            cbCompleteObjects.DataBindings.Add("Checked", PrintSettings, "CompleteObjects", false, DataSourceUpdateMode.OnPropertyChanged);
            tbExtruderClearanceHeight.DataBindings.Add("Text", PrintSettings, "ExtruderClearanceHeight", false, DataSourceUpdateMode.OnPropertyChanged);
            tbExtruderClearanceRadius.DataBindings.Add("Text", PrintSettings, "ExtruderClearanceRadius", false, DataSourceUpdateMode.OnPropertyChanged);
            cbGcodeComments.DataBindings.Add("Checked", PrintSettings, "GcodeComments", false, DataSourceUpdateMode.OnPropertyChanged);
            tbOutputFilenameFormat.DataBindings.Add("Text", PrintSettings, "OutputFilenameFormat", false, DataSourceUpdateMode.OnPropertyChanged);
            tbPostProcess.DataBindings.Add("Text", PrintSettings, "PostProcess", false, DataSourceUpdateMode.OnPropertyChanged);
        }

        public void PrepareNotesBinding()
        {
            tbNotes.DataBindings.Add("Text", PrintSettings, "Notes", false, DataSourceUpdateMode.OnPropertyChanged);
        }

        public void PrepareFilamentBinding()
        {
            UpdateColorField();

            tbFilamentColour.DataBindings.Add("BackColor", colorDialog, "Color", false, DataSourceUpdateMode.OnPropertyChanged);

            tbFilamentColour.DataBindings.Add("Text", FilamentSettings, "FilamentColour", false, DataSourceUpdateMode.OnPropertyChanged);
            tbFilamentDiameter.DataBindings.Add("Text", FilamentSettings, "FilamentDiameter", false, DataSourceUpdateMode.OnPropertyChanged);
            tbExtrusionMultiplier.DataBindings.Add("Text", FilamentSettings, "ExtrusionMultiplier", false, DataSourceUpdateMode.OnPropertyChanged);

            tbFirstLayerTemperature.DataBindings.Add("Text", FilamentSettings, "FirstLayerTemperature", false, DataSourceUpdateMode.OnPropertyChanged);
            tbTemperature.DataBindings.Add("Text", FilamentSettings, "Temperature", false, DataSourceUpdateMode.OnPropertyChanged);
            tbFirstLayerBedTemperature.DataBindings.Add("Text", FilamentSettings, "FirstLayerBedTemperature", false, DataSourceUpdateMode.OnPropertyChanged);
            tbBedTemperature.DataBindings.Add("Text", FilamentSettings, "BedTemperature", false, DataSourceUpdateMode.OnPropertyChanged);
        }

        public void PrepareCoolingBinding()
        {
            lblCoolingText.DataBindings.Add("Text", FilamentSettings, "CoolingDescription", false, DataSourceUpdateMode.OnPropertyChanged);

            cbFanAlwaysOn.DataBindings.Add("Checked", FilamentSettings, "FanAlwaysOn", false, DataSourceUpdateMode.OnPropertyChanged);
            cbCooling.DataBindings.Add("Checked", FilamentSettings, "Cooling", false, DataSourceUpdateMode.OnPropertyChanged);

            nbMinFanSpeed.DataBindings.Add("Value", FilamentSettings, "MinFanSpeed", false, DataSourceUpdateMode.OnPropertyChanged);
            nbMaxFanSpeed.DataBindings.Add("Value", FilamentSettings, "MaxFanSpeed", false, DataSourceUpdateMode.OnPropertyChanged);
            nbBridgeFanSpeed.DataBindings.Add("Value", FilamentSettings, "BridgeFanSpeed", false, DataSourceUpdateMode.OnPropertyChanged);
            nbDisableFanFirstLayers.DataBindings.Add("Value", FilamentSettings, "DisableFanFirstLayers", false, DataSourceUpdateMode.OnPropertyChanged);

            nbFanBelowLayerTime.DataBindings.Add("Value", FilamentSettings, "FanBelowLayerTime", false, DataSourceUpdateMode.OnPropertyChanged);
            nbSlowdownBelowLayerTime.DataBindings.Add("Value", FilamentSettings, "SlowdownBelowLayerTime", false, DataSourceUpdateMode.OnPropertyChanged);
            nbMinPrintSpeed.DataBindings.Add("Value", FilamentSettings, "MinPrintSpeed", false, DataSourceUpdateMode.OnPropertyChanged);

            nbMinFanSpeed.DataBindings.Add("Enabled", FilamentSettings, "FanSettingsEnabled", false, DataSourceUpdateMode.OnPropertyChanged);
            nbMaxFanSpeed.DataBindings.Add("Enabled", FilamentSettings, "Cooling", false, DataSourceUpdateMode.OnPropertyChanged);
            nbDisableFanFirstLayers.DataBindings.Add("Enabled", FilamentSettings, "FanSettingsEnabled", false, DataSourceUpdateMode.OnPropertyChanged);

            nbFanBelowLayerTime.DataBindings.Add("Enabled", FilamentSettings, "Cooling", false, DataSourceUpdateMode.OnPropertyChanged);
            nbSlowdownBelowLayerTime.DataBindings.Add("Enabled", FilamentSettings, "Cooling", false, DataSourceUpdateMode.OnPropertyChanged);
            nbMinPrintSpeed.DataBindings.Add("Enabled", FilamentSettings, "Cooling", false, DataSourceUpdateMode.OnPropertyChanged);
        }

        public void PrepareGeneralBinding()
        {
            cboxGcodeFlavor.Items.Clear();
            cboxGcodeFlavor.Items.AddRange(EnumUtils.GetDescriptions<GCodeFlavor>());

            nbBedXOrigin.DataBindings.Add("Value", PrinterSettings, "BedXOrigin", false, DataSourceUpdateMode.OnPropertyChanged);
            nbBedYOrigin.DataBindings.Add("Value", PrinterSettings, "BedYOrigin", false, DataSourceUpdateMode.OnPropertyChanged);
            nbBedXSize.DataBindings.Add("Value", PrinterSettings, "BedXSize", false, DataSourceUpdateMode.OnPropertyChanged);
            nbBedYSize.DataBindings.Add("Value", PrinterSettings, "BedYSize", false, DataSourceUpdateMode.OnPropertyChanged);
            nbZOffset.DataBindings.Add("Value", PrinterSettings, "ZOffset", false, DataSourceUpdateMode.OnPropertyChanged);

            nbExtruderCount.DataBindings.Add("Value", PrinterSettings, "ExtruderCount", false, DataSourceUpdateMode.OnPropertyChanged);

            tbOctoprintApikey.DataBindings.Add("Text", PrinterSettings, "OctoprintApikey", false, DataSourceUpdateMode.OnPropertyChanged);
            tbOctoprintHost.DataBindings.Add("Text", PrinterSettings, "OctoprintHost", false, DataSourceUpdateMode.OnPropertyChanged);

            cboxGcodeFlavor.DataBindings.Add("SelectedIndex", PrinterSettings, "GcodeFlavorInt", false, DataSourceUpdateMode.OnPropertyChanged);

            cbUseRelativeEDistances.DataBindings.Add("Checked", PrinterSettings, "UseRelativeEDistances", false, DataSourceUpdateMode.OnPropertyChanged);
            cbUseFirmwareRetraction.DataBindings.Add("Checked", PrinterSettings, "UseFirmwareRetraction", false, DataSourceUpdateMode.OnPropertyChanged);
            cbUseVolumetricE.DataBindings.Add("Checked", PrinterSettings, "UseVolumetricE", false, DataSourceUpdateMode.OnPropertyChanged);
            nbPressureAdvance.DataBindings.Add("Value", PrinterSettings, "PressureAdvance", false, DataSourceUpdateMode.OnPropertyChanged);
            nbVibrationLimit.DataBindings.Add("Value", PrinterSettings, "VibrationLimit", false, DataSourceUpdateMode.OnPropertyChanged);
        }

        public void PrepareCustomGcodeBinding()
        {
            tbStartGcode.DataBindings.Add("Text", PrinterSettings, "StartGcode", false, DataSourceUpdateMode.OnPropertyChanged);
            tbEndGcode.DataBindings.Add("Text", PrinterSettings, "EndGcode", false, DataSourceUpdateMode.OnPropertyChanged);
            tbBeforeLayerGcode.DataBindings.Add("Text", PrinterSettings, "BeforeLayerGcode", false, DataSourceUpdateMode.OnPropertyChanged);
            tbLayerGcode.DataBindings.Add("Text", PrinterSettings, "LayerGcode", false, DataSourceUpdateMode.OnPropertyChanged);
            tbToolchangeGcode.DataBindings.Add("Text", PrinterSettings, "ToolchangeGcode", false, DataSourceUpdateMode.OnPropertyChanged);
        }

        private void SetTransStringsToTextFields(string key_translate, params object[] objects)
        {
            var translate_string = Trans.T(key_translate);

            if (objects != null)
                foreach (object obj in objects)
                {
                    Type type = obj.GetType();
                    PropertyInfo prop = type.GetProperty("Text");
                    prop.SetValue(obj, translate_string, null);
                }
        }

        public void translate()
        {
            SetTransStringsToTextFields("L_DELETE", btnDeletePrintSettings, btnDeleteFilamentSettings);//"Delete"
            SetTransStringsToTextFields("L_PRINT_SETTINGS", pagePrint);//"Print Settings"
            SetTransStringsToTextFields("L_SAVE", btnSavePrintSettings, btnSavePrinterSettings);//"Save"
            SetTransStringsToTextFields("L_OPTIONS_FOR_SUPPORT_MATERIAL_AND_RAFT", gbSupportMaterialOptions);// "Options for support material and raft"
            SetTransStringsToTextFields("L_DONT_SUPPORT_BRIDGES", cbDontSupportBridges);//"Don\'t support bridges"
            SetTransStringsToTextFields("L_INTERFACE_PATTERN_SPACING", lblSupportMaterialInterfaceSpacing);//"Interface pattern spacing"
            SetTransStringsToTextFields("L_PATTERN_ANGLE", lblSupportMaterialAngle);//"Pattern angle"
            SetTransStringsToTextFields("L_LAYERS", label15, label10, label16, label8, label9, label77);//layers
            SetTransStringsToTextFields("L_PATTERN", lblSupportMaterialPattern);//Pattern

            SetTransStringsToTextFields("L_INTERFACE_LAYERS", lblSupportMaterialInterfaceLayers);//"Interface layers"
            SetTransStringsToTextFields("L_PATTERN_SPACING", lblSupportMaterialSpacing);//"Pattern spacing"
            SetTransStringsToTextFields("L_CONTACT_Z_DISTANCE", lblSupportMaterialContactDistance);//"Contact Z distance"
            SetTransStringsToTextFields("L_RAFT", gbRaft, groupBox17);//"Raft"
            SetTransStringsToTextFields("L_RAFT_LAYERS", lblRaftLayers);//"Raft layers"
            SetTransStringsToTextFields("L_GENERATE_SUPPORT_MATERIAL", cbSupportMaterial);//"Generate support material"
            SetTransStringsToTextFields("L_SUPPORT_MATERIAL", gbSupportMaterial, label36, label84);//"Support Material"
            SetTransStringsToTextFields("L_SUPPORT_MATERIAL_ENFORCE_LAYERS", lblSupportMaterialEnforceLayers);//"Enforce support for the first"
            SetTransStringsToTextFields("L_OVERHANG_THRESHOLD", lblSupportMaterialThreshold);//"Overhang threshold"
            SetTransStringsToTextFields("L_ACCELERATION_CONTROL_ADVANCED", gbAcceleration);//"Acceleration control (advanced)";
            SetTransStringsToTextFields("L_DEFAULT", label53);//"Default"
            SetTransStringsToTextFields("L_FIRST_LAYER", label55, label96, label108, label116);//"First layer"
            SetTransStringsToTextFields("L_BRIDGE", label57);//"Bridge"
            SetTransStringsToTextFields("L_INFILL", label59, label24, label90, groupBox5);//"Infill"
            SetTransStringsToTextFields("L_PERIMETERS", label61, label27, label94, lblPerimeters);//"Perimeters"
            SetTransStringsToTextFields("L_MODIFIERS", gbModifiers);//"Modifiers"
            SetTransStringsToTextFields("L_MMS_OR_PERCENT", label31, label37, label17, label3 );//"mm/s or %"
            SetTransStringsToTextFields("L_FIRST_LAYER_SPEED", label32);//"First layer speed"
            SetTransStringsToTextFields("L_AUTOSPEED_ADVANCED", gbAutospeed);//"Autospeed (advanced)"
            SetTransStringsToTextFields("L_MAX_VOLUMETRIC_SPEED", label45);//"Max volumetric speed"
            SetTransStringsToTextFields("L_MAX_PRINT_SPEED", label30);//"Max print speed"
            SetTransStringsToTextFields("L_SPEED_FOR_PRINT_MOVES", gbPrint);//"Speed for print moves"
            SetTransStringsToTextFields("L_GAP_FILL", label42);//"Gap fill"
            SetTransStringsToTextFields("L_BRIDGES", label40);//"Bridges"
            SetTransStringsToTextFields("L_SUPPORT_MATERIAL_INTERFACE", label38);//"Support material interface"
            SetTransStringsToTextFields("L_TOP_SOLID_INFILL", label34, label86);//"Top solid infill"
            SetTransStringsToTextFields("L_SOLID_INFILL", label26, label88);//"Solid infill"
            SetTransStringsToTextFields("L_EXTERNAL_PERIMETERS", label18, label92);//"External perimeters"
            SetTransStringsToTextFields("L_SMALL_PERIMETERS", label13);//"Small perimeters"
            SetTransStringsToTextFields("L_SPEED_FOR_NON_PRINT_MOVES", gbNonPrint);//"Speed for non-print moves"
            SetTransStringsToTextFields("L_TRAVEL", label33);//"Travel"
            SetTransStringsToTextFields("L_OTHER", groupBox9);//"Other"
            SetTransStringsToTextFields("L_RESOLUTION", label65);//"Resolution"
            SetTransStringsToTextFields("L_THREADS", label68);//"Threads"
            SetTransStringsToTextFields("L_XY_SIZE_COMPENSATION", label72);//"XY size compensation"
            SetTransStringsToTextFields("L_FLOW", groupBox10);//"Flow"
            SetTransStringsToTextFields("L_BRIDGE_FLOW_RATIO", label74);//"Bridge flow ratio"
            SetTransStringsToTextFields("L_EXTRUSION_WIDTH", groupBox12);//"Extrusion width"
            SetTransStringsToTextFields("L_LEAVE_0_FOR_AUTO_DEFAULT", label79);//"* Leave 0 for auto / default"
            SetTransStringsToTextFields("L_MM_OR_PERCENT", lblFirstLayerHeightMmOrPercent,  label83, label85, label87, label89, label91, label93, label95, label97, label99);//"mm or %"
            SetTransStringsToTextFields("L_DEFAULT_EXTRUSION_WIDTH", label98);//"Default extrusion width"
            SetTransStringsToTextFields("L_OVERLAP", groupBox13);//"Overlap"
            SetTransStringsToTextFields("L_INFILL_PERIMETERS_OVERLAP", label100);//"Infill/perimeters overlap"
            SetTransStringsToTextFields("L_ADVANCED", gbAdvanced, groupBox7, groupBox26);//"Advanced"
            SetTransStringsToTextFields("L_EXTERNAL_PERMITERS_FIRST", cbExternalPerimetersFirst);//"External perimeters first"
            SetTransStringsToTextFields("L_SEAM_POSITION", lblSeamPosition);//"Seam position"
            SetTransStringsToTextFields("L_QUALITY_SLOWER_SLICING", gbQuality);//"Quality (slower slicing)"
            SetTransStringsToTextFields("L_DETECT_BRIDGIN_PERMITERS", cbOverhangs);//"Detect bridging perimeters"
            SetTransStringsToTextFields("L_DETECT_THIN_WALLS", cbThinWalls);//"Detect thin walls"
            SetTransStringsToTextFields("L_AVOID_CROSSING_PERIMETERS", cbAvoidCrossingPerimeters);//"Avoid crossing perimeters"
            SetTransStringsToTextFields("L_EXTRA_PERIMETERS_IF_NEED", cbExtraPerimetersfNeeded);//"Extra perimeters if needed"
            SetTransStringsToTextFields("L_HORIZONTAL_SHELLS", gbHorizontalShells);//"Horizontal shells"
            SetTransStringsToTextFields("L_BOTTOM", label5);//"Bottom"
            SetTransStringsToTextFields("L_TOP", label6);//"Top"
            SetTransStringsToTextFields("L_SOLID_LAYERS", lblSolidLayers);//"Solid layers"
            SetTransStringsToTextFields("L_VERTICAL_SHELLS", gbVerticalShells);//"Vertical shells"
            SetTransStringsToTextFields("L_SPIRAL_VASE", cbSpiralVase);//"Spiral vase"
            SetTransStringsToTextFields("L_PERIMETERS", lblPerimeters);//"Perimeters"
            SetTransStringsToTextFields("L_LAYER_HEIGHT", gbLayerHeight, lblLayerHeight);//"Layer height"
            SetTransStringsToTextFields("L_FIRST_LAYER_HEIGHT", lblFirstLayerHeight);//"First layer height";
            SetTransStringsToTextFields("L_NOTES", groupBox15);//"Notes"
            SetTransStringsToTextFields("L_COMPLETE_INDIVIDUAL_OBJECTS", cbCompleteObjects);//"Complete individual objects"
            SetTransStringsToTextFields("L_POST_PROCESSING_SCRIPTS", groupBox11);//"Post-processing scripts"
            SetTransStringsToTextFields("L_VERBOSE_G_CODE", cbGcodeComments);//"Verbose G-code"
            SetTransStringsToTextFields("L_OUTPUT_FILENAME_FORMAT", label73);//"Output filename format"
            SetTransStringsToTextFields("", null);//
            SetTransStringsToTextFields("", null);//
            SetTransStringsToTextFields("", null);//
            SetTransStringsToTextFields("", null);//
            SetTransStringsToTextFields("", null);//
            SetTransStringsToTextFields("", null);//



        }

        private void lbPrintSettingsCategories_SelectedIndexChanged(object sender, EventArgs e)
        {
            tlpLayers.Visible = false;
            tlpInfill.Visible = false;
            tlpSkirt.Visible = false;
            tlpSupportMaterial.Visible = false;
            tlpSpeed.Visible = false;
            tlpMultipleExtruders.Visible = false;
            tlpAdvanced.Visible = false;
            tlpOutputOptions.Visible = false;
            tlpNotes.Visible = false;

            switch (lbPrintSettingsCategories.SelectedIndex)
            {
                case (int)PrintSettingsCategory.LayersAndPerimeters:
                    tlpLayers.Visible = true;
                    break;

                case (int)PrintSettingsCategory.Infill:
                    tlpInfill.Visible = true;
                    break;

                case (int)PrintSettingsCategory.SkirtAndBrim:
                    tlpSkirt.Visible = true;
                    break;

                case (int)PrintSettingsCategory.SupportMaterial:
                    tlpSupportMaterial.Visible = true;
                    break;

                case (int)PrintSettingsCategory.Speed:
                    tlpSpeed.Visible = true;
                    break;

                case (int)PrintSettingsCategory.MultipleExtruders:
                    tlpMultipleExtruders.Visible = true;
                    break;

                case (int)PrintSettingsCategory.Advanced:
                    tlpAdvanced.Visible = true;
                    break;

                case (int)PrintSettingsCategory.OutputOptions:
                    tlpOutputOptions.Visible = true;
                    break;

                case (int)PrintSettingsCategory.Notes:
                    tlpNotes.Visible = true;
                    break;
            }
        }

        private void lbFilamentSettingsCategories_SelectedIndexChanged(object sender, EventArgs e)
        {
            tlpFilament.Visible = false;
            tlpCooling.Visible = false;

            switch (lbFilamentSettingsCategories.SelectedIndex)
            {
                case (int)FilamentSettingsCategory.Filament:
                    tlpFilament.Visible = true;
                    break;

                case (int)FilamentSettingsCategory.Cooling:
                    tlpCooling.Visible = true;
                    break;
            }
        }

        private void lbPrinterSettingsCategories_SelectedIndexChanged(object sender, EventArgs e)
        {
            tlpGeneral.Visible = false;
            tlpCustomGcode.Visible = false;
            tlpExtruders.Visible = false;

            switch (lbPrinterSettingsCategories.SelectedIndex)
            {
                case (int)PrinterSettingsCategory.General:
                    tlpGeneral.Visible = true;
                    break;

                case (int)PrinterSettingsCategory.CustomGcode:
                    tlpCustomGcode.Visible = true;
                    break;

                case (int)PrinterSettingsCategory.Extruders:
                    tlpExtruders.Visible = true;
                    break;
            }
        }

        private void cboxFillDensity_Leave(object sender, EventArgs e)
        {
            int value;
            string currentValue = cboxFillDensity.Text.Split('%')[0];

            if (!int.TryParse(currentValue, out value))
                value = 5;

            cboxFillDensity.Text = string.Format("{0}%", value);
        }

        private void cboxPrintProfiles_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadProfile(Slic3rSettingsCategory.Print);
        }

        private void cboxFilamentProfiles_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadProfile(Slic3rSettingsCategory.Filament);
        }

        private void cboxPrinterProfiles_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadProfile(Slic3rSettingsCategory.Printer);
        }

        private void btnSavePrintSettings_Click(object sender, EventArgs e)
        {
            string profileName = cboxPrintProfiles.Text;
            SettingsController.SaveProfile(PrintSettings, profileName);
            LoadAndFillProfileList();
            cboxPrintProfiles.SelectedItem = profileName;
        }

        private void btnSaveFilamentSettings_Click(object sender, EventArgs e)
        {
            string profileName = cboxFilamentProfiles.Text;
            SettingsController.SaveProfile(FilamentSettings, profileName);
            LoadAndFillProfileList();
            cboxFilamentProfiles.SelectedItem = profileName;
        }

        private void btnSavePrinterSettings_Click(object sender, EventArgs e)
        {
            string profileName = cboxPrinterProfiles.Text;
            SettingsController.SaveProfile(PrinterSettings, profileName);
            LoadAndFillProfileList();
            cboxPrinterProfiles.SelectedItem = profileName;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DialogResult result = colorDialog.ShowDialog();
            if (result == DialogResult.OK)
            {
                UpdateColorField();
            }
        }

        private void UpdateColorField()
        {
            tbFilamentColour.BackColor = colorDialog.Color;
            tbFilamentColour.ForeColor = colorDialog.Color.Invert();
            tbFilamentColour.Text = colorDialog.Color.ToHex();
        }

        private void tbFilamentColour_TextChanged(object sender, EventArgs e)
        {
            colorDialog.Color = ColorTranslator.FromHtml(tbFilamentColour.Text);
            UpdateColorField();
        }

        private void nbExtruderCount_ValueChanged(object sender, EventArgs e)
        {
            LoadExtrudersPage();
        }

        public void LoadExtrudersPage()
        {
            foreach (var tab in tabExtruders.TabPages)
            {
                try
                {
                    ((TabPage)tab).Dispose();
                }
                catch { }
            }

            tabExtruders.TabPages.Clear();

            int i = 1;
            foreach (var settings in PrinterSettings.ExtrudersSettings)
            {
                var extruderSettings = new PrinterExtruderSettings()
                {
                    Dock = DockStyle.Fill
                };

                extruderSettings.LoadSettings(settings);

                var tabPage = new TabPage();
                tabPage.Text = string.Format(EXTRUDE_TITLE_FORMAT, i++);
                tabPage.Controls.Add(extruderSettings);

                tabExtruders.TabPages.Add(tabPage);
            }
        }

        private void btnDeletePrinterSettings_Click(object sender, EventArgs e)
        {
            SettingsController.DeleteProfile(PrinterSettings);
            LoadAndFillProfileList();
        }

        private void btnDeleteFilamentSettings_Click(object sender, EventArgs e)
        {
            SettingsController.DeleteProfile(FilamentSettings);
            LoadAndFillProfileList();
        }

        private void btnDeletePrintSettings_Click(object sender, EventArgs e)
        {
            SettingsController.DeleteProfile(PrintSettings);
            LoadAndFillProfileList();
        }

        private void cboxPrintProfiles_TextUpdate(object sender, EventArgs e)
        {
            btnDeletePrintSettings.Enabled = cboxPrintProfiles.Text.Equals(PrintSettings.ProfileName);
        }

        private void cboxFilamentProfiles_TextUpdate(object sender, EventArgs e)
        {
            btnDeleteFilamentSettings.Enabled = cboxFilamentProfiles.Text.Equals(FilamentSettings.ProfileName);
        }

        private void cboxPrinterProfiles_TextUpdate(object sender, EventArgs e)
        {
            btnDeletePrinterSettings.Enabled = cboxPrinterProfiles.Text.Equals(PrinterSettings.ProfileName);
        }
    }
}