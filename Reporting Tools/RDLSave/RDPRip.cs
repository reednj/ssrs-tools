using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;

using ReportingTools.Common;
using ReportingTools.Common.ReportService;

namespace RDLSave
{
    public partial class RDPRip : Form
    {
        ReportingService rs = new ReportingService();

        public RDPRip()
        {
            InitializeComponent();
        }

        private void RDPRip_Load(object sender, EventArgs e)
        {
            rs.Credentials = System.Net.CredentialCache.DefaultCredentials;
            CatalogItem[] serverItems = rs.ListChildren("/", true);

            foreach (CatalogItem curItem in serverItems)
            {
                ReportTreeList.AddReport(curItem);
            }

            ReportTreeList.Nodes[0].Expand();
        }

        private void StartButton_Click(object sender, EventArgs e)
        {
            string RootPath = @"C:\Dev\Temp\";
            CatalogItem[] serverItems = rs.ListChildren("/", true);

            foreach (CatalogItem item in serverItems)
            {
                // we want to remove the initial '/' from the path, otherwise
                // the PAth.Combine method does not work correctly.
                string ReletivePath = (item.Path[0] == '/')? item.Path.Substring(1) : item.Path;

                if (item.Type == ItemTypeEnum.Report)
                {
                    Byte[] data = rs.GetReportDefinition(item.Path);
                    string dest_file = Path.Combine(RootPath, ReletivePath + ".rdl");
                    File.WriteAllBytes(dest_file, data);
                }
                else if (item.Type == ItemTypeEnum.Resource)
                {
                    string MimeType;
                    Byte[] data = rs.GetResourceContents(item.Path, out MimeType);
                    string dest_file = Path.Combine(RootPath, ReletivePath);
                    File.WriteAllBytes(dest_file, data); 
                }
                else if (item.Type == ItemTypeEnum.Folder)
                {
                    Directory.CreateDirectory(Path.Combine(RootPath, ReletivePath));
                }



            }
        }
    }
}