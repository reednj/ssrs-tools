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
        BackgroundWorker Download_Worker = new BackgroundWorker();

        public RDPRip()
        {
            InitializeComponent();

            Download_Worker.DoWork += new DoWorkEventHandler(Download_Worker_DoWork);
            Download_Worker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(Download_Worker_RunWorkerCompleted);
            Download_Worker.ProgressChanged += new ProgressChangedEventHandler(Download_Worker_ProgressChanged);
            Download_Worker.WorkerReportsProgress = true;
        }

        private void RDPRip_Load(object sender, EventArgs e)
        {
            rs.Credentials = System.Net.CredentialCache.DefaultCredentials;
            rs.Url = SSRSUri.ParseString("hydrogen/nate").ToUrl();

            CatalogItem[] serverItems = rs.ListChildren("/", true);

            foreach (CatalogItem curItem in serverItems)
            {
                ReportTreeList.AddReport(curItem);
            }

            ReportTreeList.Nodes[0].Expand();
        }

        private void StartButton_Click(object sender, EventArgs e)
        {
            StartButton.Enabled = false;
            StatusLabel.Text = "Starting Download...";
            Download_Worker.RunWorkerAsync();
        }

        void Download_Worker_DoWork(object sender, DoWorkEventArgs e)
        {
            string RootPath = @"C:\Dev\Temp\";
            CatalogItem[] serverItems = rs.ListChildren("/", true);

            int i = 0;
            foreach (CatalogItem item in serverItems)
            {
                i++;
                DownloadReportItem(item, RootPath);
                Download_Worker.ReportProgress(i * 100 / serverItems.Length, item.Name);
            }
        }

        void Download_Worker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            StatusLabel.Text = String.Format("Downloading Items - {0} % Complete - '{1}'", e.ProgressPercentage, e.UserState);
        }

        void Download_Worker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            StatusLabel.Text = "All Items Downloaded";
            StartButton.Enabled = true;
        }


        private void DownloadReportItem(CatalogItem ReportItem, string RootPath)
        {
            // we want to remove the initial '/' from the path, otherwise
            // the Path.Combine method does not work correctly.
            string ReletivePath = (ReportItem.Path[0] == '/') ? ReportItem.Path.Substring(1) : ReportItem.Path;

            if (ReportItem.Type == ItemTypeEnum.Report)
            {
                Byte[] data = rs.GetReportDefinition(ReportItem.Path);
                string dest_file = Path.Combine(RootPath, ReletivePath + ".rdl");
                File.WriteAllBytes(dest_file, data);
            }
            else if (ReportItem.Type == ItemTypeEnum.Resource)
            {
                string MimeType;
                Byte[] data = rs.GetResourceContents(ReportItem.Path, out MimeType);
                string dest_file = Path.Combine(RootPath, ReletivePath);
                File.WriteAllBytes(dest_file, data);
            }
            else if (ReportItem.Type == ItemTypeEnum.Folder)
            {
                Directory.CreateDirectory(Path.Combine(RootPath, ReletivePath));
            }
        }


    }
}