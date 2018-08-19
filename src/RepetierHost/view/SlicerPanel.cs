/*
   Copyright 2011 repetier repetierdev@gmail.com

   Licensed under the Apache License, Version 2.0 (the "License");
   you may not use this file except in compliance with the License.
   You may obtain a copy of the License at

       http://www.apache.org/licenses/LICENSE-2.0

   Unless required by applicable law or agreed to in writing, software
   distributed under the License is distributed on an "AS IS" BASIS,
   WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
   See the License for the specific language governing permissions and
   limitations under the License.
*/

using BioMaker.model;
using BioMaker.view.utils;
using System;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace BioMaker.view
{
    public partial class SlicerPanel : UserControl
    {
        private bool updating = false;

        public SlicerPanel()
        {
            InitializeComponent();
            //UpdateSelection();
            if (Main.main != null)
            {
                Main.main.languageChanged += translate;
                translate();
                mainBindingSource.DataSource = Main.printerModel;
            }
        }

        private void translate()
        {
            buttonSetupSlic3r.Text = Trans.T("B_SETUP_SLIC3R");
            buttonSlic3rConfigure.Text = Trans.T("B_CONFIGURE_SLIC3R");
            switchSlic3rActive.TextOn = switchSlic3rActive.TextOff = Trans.T("B_ACTIVE");
            labelFilamentSettings.Text = Trans.T("L_FILAMENT_SETTINGS");
            labelPrinterSettings.Text = Trans.T("L_PRINTER_SETTINGS");
            labelPrintSettings.Text = Trans.T("L_PRINT_SETTINGS");
            labelSlic3rExtruder1.Text = Trans.T1("L_EXTRUDER_X:", "1");
            labelSlic3rExtruder2.Text = Trans.T1("L_EXTRUDER_X:", "2");
            if (Main.slicer != null)
                buttonStartSlicing.Text = Trans.T1("L_SLICE_WITH", Main.slicer.SlicerName);
        }

        private string noINI(string ini)
        {
            if (ini.EndsWith(".ini"))
                return ini.Substring(0, ini.Length - 4);
            return ini;
        }

        public string slic3rDirectory
        {
            get
            {
                BasicConfiguration b = BasicConfiguration.basicConf;
                string cdir = b.Slic3rConfigDir;
                if (cdir.Trim().Length == 0)
                {
                    if (Main.IsMono)
                    {
                        cdir = System.Environment.GetEnvironmentVariable("HOME") + "/.Slic3r";
                        //Console.WriteLine("Slic3r home:" + cdir);
                        return cdir;
                        //return "~/.Slic3r";
                        //cdir = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
                    }
                    else
                    {
                        cdir = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + Path.DirectorySeparatorChar + "Slic3r";
                    }
                }
                //Console.WriteLine("App dir:" + cdir);
                return cdir; // +Path.DirectorySeparatorChar + "Slic3r";
            }
        }

        public MethodInvoker UpdateSelectionInvoker = delegate
        {
            Main.main.slicerPanel.UpdateSelection();
        };

        public void UpdateSelection()
        {
            BasicConfiguration b = BasicConfiguration.basicConf;
            string slic3rConf = slic3rDirectory;
            updating = true;
            // Printer folder
            string printerFolder = slic3rConf + Path.DirectorySeparatorChar + "printer";
            DirectoryInfo di = new DirectoryInfo(printerFolder);
            string old;
            if (di.Exists)
            {
                old = Main.printerModel.Slic3rPrinter;
                FileInfo[] rgFiles = di.GetFiles("*.ini");
                comboSlic3rPrinterSettings.Items.Clear();
                foreach (FileInfo fi in rgFiles)
                {
                    comboSlic3rPrinterSettings.Items.Add(noINI(fi.Name));
                }
                comboSlic3rPrinterSettings.Enabled = true;
                if (b.Slic3rPrinterSettings.Length > 0)
                    comboSlic3rPrinterSettings.SelectedItem = old;
                if (comboSlic3rPrinterSettings.SelectedIndex < 0 && rgFiles.Count() > 0)
                {
                    b.Slic3rPrinterSettings = noINI(rgFiles[0].Name);
                    comboSlic3rPrinterSettings.SelectedIndex = 0;
                }
            }
            else
            {
                comboSlic3rPrinterSettings.Enabled = false;
            }
            string printFolder = slic3rConf + Path.DirectorySeparatorChar + "print";
            di = new DirectoryInfo(printFolder);
            if (di.Exists)
            {
                old = Main.printerModel.Slic3rPrint;
                FileInfo[] rgFiles = di.GetFiles("*.ini");
                comboSlic3rPrintSettings.Items.Clear();
                foreach (FileInfo fi in rgFiles)
                {
                    comboSlic3rPrintSettings.Items.Add(noINI(fi.Name));
                }
                comboSlic3rPrintSettings.Enabled = true;
                if (b.Slic3rPrintSettings.Length > 0)
                    comboSlic3rPrintSettings.SelectedItem = old;
                if (comboSlic3rPrintSettings.SelectedIndex < 0 && rgFiles.Count() > 0)
                {
                    b.Slic3rPrintSettings = noINI(rgFiles[0].Name);
                    comboSlic3rPrintSettings.SelectedIndex = 0;
                }
            }
            else
            {
                comboSlic3rPrintSettings.Enabled = false;
            }
            string filamentFolder = slic3rConf + Path.DirectorySeparatorChar + "filament";
            di = new DirectoryInfo(filamentFolder);
            if (di.Exists)
            {
                string old1 = Main.printerModel.Slic3rFilament1;
                string old2 = Main.printerModel.Slic3rFilament2;
                FileInfo[] rgFiles = di.GetFiles("*.ini");
                comboSlic3rFilamentSettings.Items.Clear();
                comboSlic3rFilamentSettings2.Items.Clear();
                // L_FILAMENT_NONE
                //comboSlic3rFilamentSettings2.Items.Add(Trans.T("L_FILAMENT_NONE"));
                //comboSlic3rFilamentSettings3.Items.Add(Trans.T("L_FILAMENT_NONE"));
                foreach (FileInfo fi in rgFiles)
                {
                    comboSlic3rFilamentSettings.Items.Add(noINI(fi.Name));
                    comboSlic3rFilamentSettings2.Items.Add(noINI(fi.Name));
                }
                comboSlic3rFilamentSettings.Enabled = Main.conn.numberExtruder > 0;
                comboSlic3rFilamentSettings2.Enabled = Main.conn.numberExtruder > 1;
                if (b.Slic3rFilamentSettings.Length > 0)
                    comboSlic3rFilamentSettings.SelectedItem = old1;
                if (comboSlic3rFilamentSettings.SelectedIndex < 0 && rgFiles.Count() > 0)
                {
                    b.Slic3rFilamentSettings = noINI(rgFiles[0].Name);
                    comboSlic3rFilamentSettings.SelectedIndex = 0;
                }

                if (b.Slic3rFilament2Settings.Length > 0)
                    comboSlic3rFilamentSettings2.SelectedItem = old2;
                if (comboSlic3rFilamentSettings2.SelectedIndex < 0 && rgFiles.Count() > 0)
                {
                    b.Slic3rFilament2Settings = noINI(rgFiles[0].Name);
                    comboSlic3rFilamentSettings2.SelectedIndex = 0;
                }
            }
            else
            {
                comboSlic3rFilamentSettings.Enabled = false;
            }

            buttonStartSlicing.Text = Trans.T1("L_SLICE_WITH", Main.slicer.SlicerName);
            updating = false;
        }

        public void SetFilamentSettings(string filamentSettingsName)
        {
            UpdateSelection();

            if (comboSlic3rFilamentSettings.Enabled)
                comboSlic3rFilamentSettings.SelectedItem = filamentSettingsName;

            if (comboSlic3rFilamentSettings2.Enabled)
                comboSlic3rFilamentSettings2.SelectedItem = filamentSettingsName;
        }

        public void SetPrinterSettings(string printerSettingName)
        {
            UpdateSelection();

            comboSlic3rPrinterSettings.SelectedItem = printerSettingName;
        }

        public void SetPrintSettings(string printSettingNameName)
        {
            UpdateSelection();

            comboSlic3rPrintSettings.SelectedItem = printSettingNameName;
        }

        private void comboSlic3rPrintSettings_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!updating)
            {
                if (Main.IsMono && comboSlic3rPrintSettings.SelectedItem != null)
                    Main.printerModel.Slic3rPrint = (string)comboSlic3rPrintSettings.SelectedItem;
            }
        }

        private void comboSlic3rFilamentSettings_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!updating)
            {
                if (Main.IsMono && comboSlic3rFilamentSettings.SelectedItem != null)
                    Main.printerModel.Slic3rFilament1 = (string)comboSlic3rFilamentSettings.SelectedItem;
            }
        }

        private void comboSlic3rPrinterSettings_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!updating)
            {
                if (Main.IsMono && comboSlic3rPrinterSettings.SelectedItem != null)
                    Main.printerModel.Slic3rPrinter = (string)comboSlic3rPrinterSettings.SelectedItem;
            }
        }

        private void buttonSlic3rConfigure_Click(object sender, EventArgs e)
        {
            Main.slic3rSettings.ShowDialog();
        }

        private void switchSlic3rActive_OnChange(SwitchButton button)
        {
            if (updating || Main.slicer == null) return;
            Main.slicer.ActiveSlicer = Slicer.SlicerID.Slic3r;
        }

        private void buttonStartSlicing_Click(object sender, EventArgs e)
        {
            Main.main.objectPlacement.buttonSlice_Click(null, null);
        }

        private void buttonSetupSlic3r_Click(object sender, EventArgs e)
        {
            Slic3rSetup.Execute();
        }

        private void buttonKillSlicing_Click(object sender, EventArgs e)
        {
            Main.slic3r.KillSlice();
            SlicingInfo.Stop();
        }

        private void comboSlic3rFilamentSettings2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!updating)
            {
                if (Main.IsMono && comboSlic3rFilamentSettings2.SelectedItem != null)
                    Main.printerModel.Slic3rFilament2 = (string)comboSlic3rFilamentSettings2.SelectedItem;
            }
        }

    }
}