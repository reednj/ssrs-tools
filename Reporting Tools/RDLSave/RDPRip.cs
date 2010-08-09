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
        bool hasStarted = false;
        ServiceState CurrentState = ServiceState.Disconnected;
        SSRSUri ServerUrl = null;

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
            

        }

        private void RDPRip_Activated(object sender, EventArgs e)
        {
            if (hasStarted == false)
            {
                hasStarted = true;
                RunConnectDialog(true);
            }
        }

        private void LoadList_Worker_DoWork(object sender, DoWorkEventArgs e)
        {
            this.CurrentState = ServiceState.LoadingList;
            StatusLabel.Text = "Loading Reports...";
            e.Result = rs.ListChildren("/", true);
        }

        private void LoadList_Worker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Error != null)
            {
                throw e.Error;
            }

            CatalogItem[] serverItems = e.Result as CatalogItem[];
            
            foreach (CatalogItem curItem in serverItems)
            {
                ReportTreeList.AddReport(curItem);
            }

            ReportTreeList.Nodes[0].Expand();
            StatusLabel.Text = String.Format("Connected to '{0}'", this.ServerUrl.FullName);
            this.CurrentState = ServiceState.Connected;
        }

        void Download_Worker_DoWork(object sender, DoWorkEventArgs e)
        {
            DownloadArgs args = e.Argument as DownloadArgs;
            string FromFolder = args.SourcePath.RemoveEndSlash();
            string DestRootPath = args.DestPath + Path.GetFileName(FromFolder);

            CatalogItem[] serverItems = rs.ListChildren(FromFolder, true);
            Directory.CreateDirectory(DestRootPath);

            int i = 0;
            foreach (CatalogItem item in serverItems)
            {
                i++;

                if (item.Type != ItemTypeEnum.Folder)
                {
                    Byte[] data = RsHelper.DownloadReportItem(rs, item);

                    if (data != null)
                    {
                        string TempFromFolder = FromFolder.AddEndSlash();
                        string FilePath = item.Path.Remove(item.Path.IndexOf(TempFromFolder), TempFromFolder.Length);
                        FilePath = Path.Combine(DestRootPath, FilePath);
                        FilePath = (item.Type == ItemTypeEnum.Report) ? FilePath + ".rdl" : FilePath;
                        File.WriteAllBytes(FilePath, data);
                    }
                }
                else
                {
                    // the item is a folder. There is no need for downloading here, we just need to create
                    // one with the same name
                    string TempFromFolder = FromFolder.AddEndSlash();
                    string RelativePath = item.Path.Remove(item.Path.IndexOf(TempFromFolder), TempFromFolder.Length);
                    Directory.CreateDirectory(Path.Combine(DestRootPath, RelativePath));
                }

                
                Download_Worker.ReportProgress(i * 100 / serverItems.Length, item.Name);
            }

            e.Result = serverItems.Length;
        }

        void Download_Worker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            StatusLabel.Text = String.Format("Downloading Items - {0} % Complete - '{1}'", e.ProgressPercentage, e.UserState);
        }

        void Download_Worker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Error != null)
            {
                throw e.Error;
            }
            
            StatusLabel.Text = String.Format("{0} Items Downloaded", e.Result);
            DownloadButton.Enabled = true;
        }



        private void RunConnectDialog(bool AutoLogin)
        {
            LoginForm lf = new LoginForm(AutoLogin);
            if (lf.ShowDialog() == DialogResult.OK)
            {
                // disconnect. TODO: a general method to set the ui on a state change.
                this.CurrentState = ServiceState.Disconnected;

                // if the user click ok on the connection dialog box, set the rs url
                // and start getting the data. Otherwise to nothing...
                this.ServerUrl = lf.ServerUrl;
                rs.Url = this.ServerUrl.ToUrl();
                rs.Credentials = lf.RsCredentials;
                LoadList_Worker.RunWorkerAsync();

            }
        }

        private void RefreshButton_Click(object sender, EventArgs e)
        {
            if (this.CurrentState == ServiceState.Connected)
            {
                ReportTreeList.Nodes["Root"].Nodes.Clear();
                LoadList_Worker.RunWorkerAsync();
            }
        }

        private void DownloadButton_Click(object sender, EventArgs e)
        {
            DownloadButton.Enabled = false;
            StatusLabel.Text = "Starting Download...";
            Download_Worker.RunWorkerAsync(new DownloadArgs("/", @"C:\Dev\Temp\"));
        }
    }

    public class DownloadArgs
    {
        public string SourcePath;
        public string DestPath;

        public DownloadArgs(string SourcePath, string DestPath)
        {
            this.SourcePath = SourcePath.Trim();
            this.DestPath = DestPath.Trim();
        }
    }

    public static class Extensions
    {
        public static string RemoveEndSlash(this string FilePath)
        {
            // we want to remove the initial '/' from the path, otherwise
            // the Path.Combine method does not work correctly.
            FilePath = FilePath.Trim();
            return (FilePath[FilePath.Length - 1] == '/' && FilePath.Length > 1) ? FilePath.Substring(0, FilePath.Length - 1) : FilePath;
        }

        public static string AddEndSlash(this string FilePath)
        {
            FilePath = FilePath.Trim();
            return (FilePath[FilePath.Length - 1] != '/') ? FilePath + "/" : FilePath;
        }
    }

    public class RsHelper
    {
        public static Byte[] DownloadReportItem(ReportingService rs, CatalogItem ReportItem)
        {

            if (ReportItem.Type == ItemTypeEnum.Report)
            {
                return rs.GetReportDefinition(ReportItem.Path);

            }
            else if (ReportItem.Type == ItemTypeEnum.Resource)
            {
                string MimeType;
                return rs.GetResourceContents(ReportItem.Path, out MimeType);
            }

            return null;
        }
    }

}