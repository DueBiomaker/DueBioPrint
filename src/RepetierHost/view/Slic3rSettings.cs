﻿using RepetierHost.controller;
using RepetierHost.extensions;
using RepetierHost.model.slic3r;
using RepetierHost.util;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace RepetierHost.view
{
    public partial class Slic3rSettings : Form
    {
        private PrintSettings PrintSettings { get; set; }
        private FilamentSettings FilamentSettings { get; set; }
        private Slic3rSettingsController SettingsController { get; set; }

        public Slic3rSettings()
        {
            InitializeComponent();
            SettingsController = new Slic3rSettingsController(SettingsUtils.GetSlic3rDirectory());
            PrintSettings = new PrintSettings();
            FilamentSettings = new FilamentSettings();
            PreparePrintBindings();
            PrepareFilamentBindings();
            Customization();
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
        }

        public void LoadAndFillProfileList()
        {
            cboxPrintProfiles.Items.Clear();
            cboxPrintProfiles.Items.AddRange(SettingsController.FindAvailableProfiles(Slic3rSettingsCategory.Print).ToArray());
            cboxPrintProfiles.DropDownStyle = ComboBoxStyle.DropDownList;
            cboxPrintProfiles.SelectedIndex = 0;

            cboxFilamentProfiles.Items.Clear();
            cboxFilamentProfiles.Items.AddRange(SettingsController.FindAvailableProfiles(Slic3rSettingsCategory.Filament).ToArray());
            cboxFilamentProfiles.DropDownStyle = ComboBoxStyle.DropDownList;
            cboxFilamentProfiles.SelectedIndex = 0;
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
            PrepareAdvanced();
            PrepareOutputOptions();
            PrepareNotes();
        }

        public void PrepareFilamentBindings()
        {
            lbFilamentSettingsCategories.Items?.Clear();
            lbFilamentSettingsCategories.Items.AddRange(EnumUtils.GetDescriptions<FilamentSettingsCategory>());
            lbFilamentSettingsCategories.SelectedIndex = 0;

            PrepareFilament();
            PrepareCooling();
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

        public void PrepareAdvanced()
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

        public void PrepareOutputOptions()
        {
            gbExtruderClearance.DataBindings.Add("Enabled", PrintSettings, "CompleteObjects", false, DataSourceUpdateMode.OnPropertyChanged);

            cbCompleteObjects.DataBindings.Add("Checked", PrintSettings, "CompleteObjects", false, DataSourceUpdateMode.OnPropertyChanged);
            tbExtruderClearanceHeight.DataBindings.Add("Text", PrintSettings, "ExtruderClearanceHeight", false, DataSourceUpdateMode.OnPropertyChanged);
            tbExtruderClearanceRadius.DataBindings.Add("Text", PrintSettings, "ExtruderClearanceRadius", false, DataSourceUpdateMode.OnPropertyChanged);
            cbGcodeComments.DataBindings.Add("Checked", PrintSettings, "GcodeComments", false, DataSourceUpdateMode.OnPropertyChanged);
            tbOutputFilenameFormat.DataBindings.Add("Text", PrintSettings, "OutputFilenameFormat", false, DataSourceUpdateMode.OnPropertyChanged);
            tbPostProcess.DataBindings.Add("Text", PrintSettings, "PostProcess", false, DataSourceUpdateMode.OnPropertyChanged);
        }

        public void PrepareNotes()
        {
            tbNotes.DataBindings.Add("Text", PrintSettings, "Notes", false, DataSourceUpdateMode.OnPropertyChanged);
        }

        public void PrepareFilament()
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

        public void PrepareCooling()
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

        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show(PrintSettings.ToString());
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

        private void btnSavePrintSettings_Click(object sender, EventArgs e)
        {
            SettingsController.SaveProfile(PrintSettings);
        }

        private void btnSaveFilamentSettings_Click(object sender, EventArgs e)
        {
            SettingsController.SaveProfile(FilamentSettings);
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
    }
}