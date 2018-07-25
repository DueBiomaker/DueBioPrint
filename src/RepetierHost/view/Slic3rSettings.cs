using RepetierHost.controller;
using RepetierHost.model.slic3r;
using RepetierHost.util;
using System;
using System.Windows.Forms;

namespace RepetierHost.view
{
    public partial class Slic3rSettings : Form
    {
        private PrintSettings PrintSettings { get; set; }
        private Slic3rSettingsController SettingsController { get; set; }

        public Slic3rSettings()
        {
            InitializeComponent();
            SettingsController = new Slic3rSettingsController(SettingsUtils.GetSlic3rDirectory());
            PrintSettings = new PrintSettings();
            PreparePrintBindings();
            Customization();
        }

        private void Slic3rSettings_Load(object sender, EventArgs e)
        {
            LoadAndFillProfileList();
            LoadProfiles();
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
        }

        public void LoadProfiles()
        {
            PrintSettings = SettingsController.LoadPrintProfile(cboxPrintProfiles.Text, PrintSettings);
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
            cboxOozePrevention.DataBindings.Add("Checked", PrintSettings, "OozePrevention", false, DataSourceUpdateMode.OnPropertyChanged);
            nbStandbyTemperatureDelta.DataBindings.Add("Value", PrintSettings, "StandbyTemperatureDelta", false, DataSourceUpdateMode.OnPropertyChanged);
            cboxInterfaceShells.DataBindings.Add("Checked", PrintSettings, "InterfaceShells", false, DataSourceUpdateMode.OnPropertyChanged);
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
            LoadProfiles();
        }

        private void btnSavePrintSettings_Click(object sender, EventArgs e)
        {
            SettingsController.SaveProfile(PrintSettings);
        }
    }
}