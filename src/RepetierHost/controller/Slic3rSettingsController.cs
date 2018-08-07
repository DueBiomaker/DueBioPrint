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
        private const string DEFAULT_PROFILE = "Default";

        public string SettingsPath { get; private set; }

        public Slic3rSettingsController(string path)
        {
            SettingsPath = path;

            foreach (Slic3rSettingsCategory category in Enum.GetValues(typeof(Slic3rSettingsCategory)))
            {
                string folder = FileUtils.CreatePath(SettingsPath, GetCategoryFolder(category));
                DirectoryInfo di = new DirectoryInfo(folder);

                if (di.Exists && !di.GetFiles().Any())
                    CreateDefaultSettings(category);
            }
        }
        
        public void LoadSettingsProfile(Slic3rSettingsCategory category, string profile, ISlic3rSettings slic3rSettings)
        {
            LoadSettingsProfile(category, profile, slic3rSettings, SettingsPath);
        }

        private void LoadSettingsProfile(Slic3rSettingsCategory category, string profile, ISlic3rSettings slic3rSettings, string path = null)
        {
            string filePath = FileUtils.CreatePath(path, GetCategoryFolder(category), profile + CONFIG_EXTENSION);

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

        public void SaveProfile(ISlic3rSettings slic3rSettings, string newProfileName = null)
        {
            if (newProfileName != null)
                slic3rSettings.FilePath =  FileUtils.CreatePath(SettingsPath, GetCategoryFolder(slic3rSettings.Category), newProfileName + CONFIG_EXTENSION);

            using (var fileStream = File.Open(slic3rSettings.FilePath, FileMode.Create))
            using (var streamReader = new StreamWriter(fileStream))
            {
                streamReader.Write(slic3rSettings.ToString());
            }
        }

        public void DeleteProfile(ISlic3rSettings slic3rSettings)
        {
            File.Delete(slic3rSettings.FilePath);
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

        private void CreateDefaultSettings(Slic3rSettingsCategory category)
        {
            ISlic3rSettings defaultSettings = null;
            switch (category)
            {
                case Slic3rSettingsCategory.Print:
                    defaultSettings = new PrintSettings();
                    break;
                case Slic3rSettingsCategory.Filament:
                    defaultSettings = new FilamentSettings();
                    break;
                case Slic3rSettingsCategory.Printer:
                    defaultSettings = new PrinterSettings();
                    break;
                default:
                    throw new ArgumentOutOfRangeException("category");
            }

            LoadSettingsProfile(category, DEFAULT_PROFILE, defaultSettings, SettingsUtils.GetDefaultDataDirectory());
            defaultSettings.FilePath = FileUtils.CreatePath(SettingsPath, GetCategoryFolder(category), DEFAULT_PROFILE + CONFIG_EXTENSION);
            SaveProfile(defaultSettings);
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
