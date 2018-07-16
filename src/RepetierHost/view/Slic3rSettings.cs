using RepetierHost.controller;
using RepetierHost.model.slic3r;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using RepetierHost.extensions;
using RepetierHost.util;

namespace RepetierHost.view
{
    public partial class Slic3rSettings : Form
    {
        private PrintSettings PrintSettings { get; set; }

        public Slic3rSettings()
        {
            InitializeComponent();
            PrintSettings = Slic3rSettingsController.LoadPrintSettings();
            PrepareBindings();
            Customization();
        }

        public void Customization()
        {
            cboxSeamPosition.DropDownStyle = ComboBoxStyle.DropDownList;
            cboxSeamPosition.SelectedIndex = 0;
            cboxFillPattern.DropDownStyle = ComboBoxStyle.DropDownList;
            cboxFillPattern.SelectedIndex = 0;
            cboxExternalFillPattern.DropDownStyle = ComboBoxStyle.DropDownList;
            cboxExternalFillPattern.SelectedIndex = 0;
        }

        public void PrepareBindings()
        {
            lbPrintSettingsCategories.Items?.Clear();
            lbPrintSettingsCategories.Items.AddRange(EnumUtils.GetDescriptions<PrintSettingsCategory>());
            lbPrintSettingsCategories.SelectedIndex = 0;

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
            cboxSeamPosition.DataBindings.Add("SelectedIndex", PrintSettings, "SeamPosition", false, DataSourceUpdateMode.OnPropertyChanged);
            cbExternalPerimetersFirst.DataBindings.Add("Checked", PrintSettings, "ExternalPerimetersFirst", false, DataSourceUpdateMode.OnPropertyChanged);

            cboxFillPattern.Items.Clear();
            cboxFillPattern.Items.AddRange(EnumUtils.GetDescriptions<FillPattern>());
            cboxExternalFillPattern.Items.Clear();
            cboxExternalFillPattern.Items.AddRange(EnumUtils.GetDescriptions<ExternalFillPattern>());

            cboxFillDensity.DataBindings.Add("Text", PrintSettings, "FillDensity", false, DataSourceUpdateMode.OnPropertyChanged);
            cboxFillPattern.DataBindings.Add("SelectedIndex", PrintSettings, "FillPattern", false, DataSourceUpdateMode.OnPropertyChanged);
            cboxExternalFillPattern.DataBindings.Add("SelectedIndex", PrintSettings, "ExternalFillPattern", false, DataSourceUpdateMode.OnPropertyChanged);
            nbInfillEveryLayers.DataBindings.Add("Value", PrintSettings, "InfillEveryLayers", false, DataSourceUpdateMode.OnPropertyChanged);
            cbInfillOnlyWhereNeeded.DataBindings.Add("Checked", PrintSettings, "InfillOnlyWhereNeeded", false, DataSourceUpdateMode.OnPropertyChanged);
            nbSolidInfillEveryLayers.DataBindings.Add("Value", PrintSettings, "SolidInfillEveryLayers", false, DataSourceUpdateMode.OnPropertyChanged);
            nbFillAngle.DataBindings.Add("Value", PrintSettings, "FillAngle", false, DataSourceUpdateMode.OnPropertyChanged);
            tbSolidInfillBellowArea.DataBindings.Add("Text", PrintSettings, "SolidInfillBelowArea", false, DataSourceUpdateMode.OnPropertyChanged);
            cbOnlyRetractWhenCrossingPerimeters.DataBindings.Add("Checked", PrintSettings, "OnlyRetractWhenCrossingPerimeters", false, DataSourceUpdateMode.OnPropertyChanged);
            cbInfillFirst.DataBindings.Add("Checked", PrintSettings, "InfillFirst", false, DataSourceUpdateMode.OnPropertyChanged);

        }

        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show(PrintSettings.ToString());
        }

        private void lbPrintSettingsCategories_SelectedIndexChanged(object sender, EventArgs e)
        {
            tlpLayers.Visible = tlpInfill.Visible = false;

            switch (lbPrintSettingsCategories.SelectedIndex)
            {
                case (int) PrintSettingsCategory.LayersAndPerimeters:
                    tlpLayers.Visible = true;
                    break;

                case (int)PrintSettingsCategory.Infill:
                    tlpInfill.Visible = true;
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
    }
}
