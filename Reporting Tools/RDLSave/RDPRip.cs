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
        CatalogItem[] serverItems = null;

        public RDPRip()
        {
            InitializeComponent();
        }

        private void RDPRip_Load(object sender, EventArgs e)
        {
            rs.Credentials = System.Net.CredentialCache.DefaultCredentials;
            serverItems = rs.ListChildren("/", true);

            foreach (CatalogItem curItem in serverItems)
            {
                ReportTreeList.AddReport(curItem);
            }

            ReportTreeList.Nodes[0].Expand();
        }

        private void StartButton_Click(object sender, EventArgs e)
        {
            foreach (CatalogItem item in serverItems)
            {
                if (item.Type == ItemTypeEnum.Report)
                {
                    Byte[] data = rs.GetReportDefinition(item.Path);
                    string dest_file = String.Format(@"C:\Dev\Temp\{0}.rdl", item.Name);
                    File.WriteAllBytes(dest_file, data);
                }
                else if (item.Type == ItemTypeEnum.Resource)
                {
                    string MimeType;
                    Byte[] data = rs.GetResourceContents(item.Path, out MimeType);
                    string dest_file = String.Format(@"C:\Dev\Temp\{0}", item.Name);
                    File.WriteAllBytes(dest_file, data);
                }
                else if (item.Type == ItemTypeEnum.Resource)
                {
                }

            }
        }
    }
}