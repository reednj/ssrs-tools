using System;
using System.Collections.Generic;
using System.Text;

using Newtonsoft.Json;
using System.IO;

namespace ReportingTools.Common
{
    class SharedSettings
    {
        public static DefaultSettings Default = DefaultSettings.Initialize();
    }

    class DefaultSettings
    {
        const string DefaultFolder = "ReportingTools";
        const string DefaultFileName = @"\ReportingTools\ReportingToolsSettings.json";


        public string LicenseKey { get; set; }
        public string LicenseValue { get; set; }
        public string ServerName { get; set; }
        public bool AutoConnect { get; set; }

        public static DefaultSettings Initialize()
        {
            string FileName = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) + DefaultFileName;

            if (!File.Exists(FileName))
            {
                Directory.CreateDirectory(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), DefaultFolder));
                
                // if the file doesn't exist, then just create one with all the default
                // settings.
                DefaultSettings d = new DefaultSettings();
                d.LicenseKey = "";
                d.LicenseValue = "mr.tickle";
                d.ServerName = "";
                d.AutoConnect = false;
                d.Save();

                return d;
            }

            return (DefaultSettings)JavaScriptConvert.DeserializeObject(File.ReadAllText(FileName), typeof(DefaultSettings));
        }

        public void Save()
        {
            string FileName = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) + DefaultFileName;
            File.WriteAllText(FileName, JavaScriptConvert.SerializeObject(this));
        }
    }
}
