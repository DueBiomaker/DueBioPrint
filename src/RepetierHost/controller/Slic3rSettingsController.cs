using RepetierHost.model;
using RepetierHost.model.slic3r;
using RepetierHost.util;
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
        private const string CONFIG_FILE = "slic3r.ini";
        private const string CONFIG_EXTENSION_WILDCARD = "*.ini";
        private const string CONFIG_EXTENSION = ".ini";

        private const string PRINT_SETTINGS_SUBFOLDER = "print";
        private const string FILAMENT_SETTINGS_SUBFOLDER = "filament";
        private const string PRINTER_SETTINGS_SUBFOLDER = "printer";

        public string SettingsPath { get; private set; }

        public Slic3rSettingsController(string path)
        {
            SettingsPath = path;
        }
        
        public void LoadSettingsProfile(Slic3rSettingsCategory category, string profile, ISlic3rSettings slic3rSettings)
        {
            string filePath = FileUtils.CreatePath(SettingsPath, GetCategoryFolder(category), profile+CONFIG_EXTENSION);

            FileInfo info = new FileInfo(filePath);
            if (info.Exists)
            {
                using (var fileStream = File.OpenRead(filePath))
                using (var streamReader = new StreamReader(fileStream))
                {
                    String line;
                    while ((line = streamReader.ReadLine()) != null)
                    {
                        var values = line.Split('=');
                        if (values.Count() == 2)
                            slic3rSettings.FillValue(values[0].Trim(), values[1].Trim().Replace("\\n", Environment.NewLine));
                    }
                }
            }
            else
            {
                throw new FileNotFoundException();
            }

            slic3rSettings.ProfileName = profile;
            slic3rSettings.FilePath = filePath;
        }

        public void SaveProfile(ISlic3rSettings iSlic3rSettings)
        {
            using (var fileStream = File.Open(iSlic3rSettings.FilePath, FileMode.Create))
            using (var streamReader = new StreamWriter(fileStream))
            {
                streamReader.Write(iSlic3rSettings.ToString());
            }
        }

        public List<string> FindAvailableProfiles(Slic3rSettingsCategory category)
        {
            string folder = FileUtils.CreatePath(SettingsPath, GetCategoryFolder(category));
            DirectoryInfo di = new DirectoryInfo(folder);

            if (di.Exists)
                return di.GetFiles(CONFIG_EXTENSION_WILDCARD).Select(fi => fi.Name.Replace(CONFIG_EXTENSION, string.Empty)).ToList();
            else
                return new List<string>();
        }

        private string GetCategoryFolder(Slic3rSettingsCategory category)
        {
            switch (category)
            {
                case Slic3rSettingsCategory.Print:
                    return PRINT_SETTINGS_SUBFOLDER;
                case Slic3rSettingsCategory.Filament:
                    return FILAMENT_SETTINGS_SUBFOLDER;
                case Slic3rSettingsCategory.Printer:
                    return PRINTER_SETTINGS_SUBFOLDER;
                default:
                    throw new ArgumentOutOfRangeException("category");
            }
        }
    }
}
