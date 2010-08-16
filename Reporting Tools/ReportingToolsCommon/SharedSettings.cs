using System;
using System.Collections.Generic;
using System.Text;

using Microsoft.Win32;

namespace ReportingTools.Common
{
    class SharedSettings
    {
        const string DefaultPath = @"Software\servralert\reporting-tools";

        public static string LicenseKey
        {
            get { return (string)GetValue("LicenseKey"); }
            set { SetValue("LicenseKey", value); }
        }

        public static string LicenseValue
        {
            get { return (string)GetValue("LicenseValue"); }
            set { SetValue("LicenseValue", value); }
        }

        public static string ServerName
        {
            get { return (string)GetValue("ServerName"); }
            set { SetValue("ServerName", value); }
        }

        public static bool AutoConnect
        {
            get { return (string)GetValue("AutoConnect") == "True" ? true : false ; }
            set { SetValue("AutoConnect", value.ToString()); }
        }

        public static object GetValue(string KeyName)
        {
            try
            {
                return Registry.CurrentUser.OpenSubKey(DefaultPath).GetValue(KeyName, "");
            }
            catch
            {
                return "";
            }
        }

        public static void SetValue(string KeyName, object KeyValue)
        {
            try
            {
                Registry.CurrentUser.OpenSubKey(DefaultPath, true).SetValue(KeyName, KeyValue);
            } catch {
            }
        }
    }
}
