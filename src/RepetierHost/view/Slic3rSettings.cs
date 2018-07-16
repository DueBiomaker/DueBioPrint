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
        }

        public void PrepareBindings()
        {
            lbPrintSettingsCategories.Items?.Clear();
            lbPrintSettingsCategories.Items.AddRange(EnumUtils.GetDescriptions<PrintSettingsCategory>());

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
            cboxSeamPosition.DataBindings.Add("SelectedItem", PrintSettings, "SeamPosition", false, DataSourceUpdateMode.OnPropertyChanged);
            cbExternalPerimetersFirst.DataBindings.Add("Checked", PrintSettings, "ExternalPerimetersFirst", false, DataSourceUpdateMode.OnPropertyChanged);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show(PrintSettings.ToString());
        }
    }
}
