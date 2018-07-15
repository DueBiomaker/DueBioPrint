using RepetierHost.model.slic3r;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace RepetierHost.controller
{
    public class Slic3rSettingsController
    {
        private const string CONFIG_DIRECTORY = "config";
        private const string CONFIG_FILE = "slic3r.ini";

        public static PrintSettings LoadPrintSettings()
        {
            PrintSettings printSettings = new PrintSettings();
            string filename = Application.StartupPath + Path.DirectorySeparatorChar + CONFIG_DIRECTORY + Path.DirectorySeparatorChar + CONFIG_FILE;

            using (var fileStream = File.OpenRead(filename))
            using (var streamReader = new StreamReader(fileStream))
            {
                String line;
                while ((line = streamReader.ReadLine()) != null)
                {
                    var values = line.Split('=');
                    if (values.Count() == 2)
                        printSettings.FillValue(values[0].Trim(), values[1].Trim());
                }
            }

            return printSettings;
        }
    }
}
