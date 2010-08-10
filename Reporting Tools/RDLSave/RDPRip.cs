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
        SSRSUri ServerUrl = null;
        string downloadFolder = Properties.Settings.Default.DownloadFolder.AddFileEndSlash();

        ServiceState _currentState = ServiceState.Disconnected;
        ServiceState CurrentState { 
            set {
                this._currentState = value;
                this.SetControlsState();
            } 
            get { return this._currentState;  } 
        }

        ReportingService rs = new ReportingService();

        public RDPRip()
        {
            InitializeComponent();

            CatalogItem c = new CatalogItem();
            c.Type = ItemTypeEnum.Folder;
            c.Path = "/";

            ReportTreeList.Nodes["Root"].Tag = c;
        }

        private void RDPRip_Load(object sender, EventArgs e)
        {
            
        }

        private void RDPRip_Activated(object sender, EventArgs e)
        {
            if (hasStarted == false)
            {
                hasStarted = true;
                this.CurrentState = ServiceState.Disconnected;
                RunConnectDialog(true);
            }
        }

        private void LoadList_Worker_DoWork(object sender, DoWorkEventArgs e)
        {
           
            StatusLabel.Text = "Loading Reports...";
            e.Result = rs.ListChildren("/", true);
        }

        private void LoadList_Worker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Error != null)
            {
                this.CurrentState = ServiceState.Connected;
                StatusLabel.Image = Properties.Resources.exclamation;
                StatusLabel.Text = "Error: " + e.Error.ShortMessage();
                return;
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

            int downloadCount = 0;
            int errorCount = 0;

            foreach (CatalogItem item in serverItems)
            {
                downloadCount++;

                // has the download been cancelled?
                if (Download_Worker.CancellationPending == true)
                {
                    e.Cancel = true;
                    break;
                }

                if (item.Type == ItemTypeEnum.Report || item.Type == ItemTypeEnum.Resource)
                {
                    Byte[] data = RsHelper.DownloadReportItem(rs, item);

                    if (data != null)
                    {
                        // finding the correct name and location for the file can be a bit tricky...
                        string TempFromFolder = FromFolder.AddEndSlash();
                        string FilePath = item.Path.Remove(item.Path.ToLower().IndexOf(TempFromFolder.ToLower()), TempFromFolder.Length);
                        FilePath = Path.Combine(DestRootPath, FilePath);
                        FilePath = (item.Type == ItemTypeEnum.Report) ? FilePath + ".rdl" : FilePath;
                        File.WriteAllBytes(FilePath, data);
                    }
                    else
                    {
                        errorCount++;
                    }
                }
                else if(item.Type == ItemTypeEnum.Folder) 
                {
                    // the item is a folder. There is no need for downloading here, we just need to create
                    // one with the same name
                    string TempFromFolder = FromFolder.AddEndSlash();
                    string RelativePath = item.Path.Remove(item.Path.ToLower().IndexOf(TempFromFolder.ToLower()), TempFromFolder.Length);
                    Directory.CreateDirectory(Path.Combine(DestRootPath, RelativePath));
                }
                
                Download_Worker.ReportProgress(downloadCount * 100 / serverItems.Length, item.Name);

            }

            e.Result = new DownloadResult(serverItems.Length - errorCount, errorCount);
        }

        void Download_Worker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            StatusLabel.Text = String.Format("Downloading Items - {0} % Complete - '{1}'", e.ProgressPercentage, e.UserState);
        }

        void Download_Worker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Error != null)
            {
                this.CurrentState = ServiceState.Connected;
                StatusLabel.Image = Properties.Resources.exclamation;
                StatusLabel.Text = "Error: " + e.Error.ShortMessage();
                return;
            }

            if (e.Cancelled == true)
            {
                StatusLabel.Text = "Download Cancelled";
            }
            else
            {
                DownloadResult dr = e.Result as DownloadResult;
                StatusLabel.Text = String.Format("{0} Items Downloaded, {1} Errors", dr.DownloadCount, dr.ErrorCount);
            } 

            this.CurrentState = ServiceState.Connected;
        }

        private void RunConnectDialog(bool AutoLogin)
        {
            LoginForm lf = new LoginForm(AutoLogin);
            if (lf.ShowDialog() == DialogResult.OK)
            {
                // clear the treeview
                ReportTreeList.Nodes["Root"].Nodes.Clear();

                // disconnect. TODO: a general method to set the ui on a state change.
                this.CurrentState = ServiceState.Disconnected;

                // if the user click ok on the connection dialog box, set the rs url
                // and start getting the data. Otherwise to nothing...
                this.ServerUrl = lf.ServerUrl;
                rs.Url = this.ServerUrl.ToUrl();
                rs.Credentials = lf.RsCredentials;

                this.CurrentState = ServiceState.LoadingList;
                LoadList_Worker.RunWorkerAsync();
            }
        }

        private void RefreshButton_Click(object sender, EventArgs e)
        {
            if (this.CurrentState == ServiceState.Connected)
            {
                this.CurrentState = ServiceState.LoadingList;
                ReportTreeList.Nodes["Root"].Nodes.Clear();
                LoadList_Worker.RunWorkerAsync();
            }
        }

        private void DownloadButton_Click(object sender, EventArgs e)
        {
            if (this.CurrentState == ServiceState.Connected)
            {
                string RemoteFolder = "/";

                // if the user has selected a particular node, then download only that folder.
                // if nothing selected, then stick with the default choice and download everything
                if (ReportTreeList.SelectedNode != null && ReportTreeList.SelectedNode.Tag != null)
                {
                    CatalogItem ReportItem = ReportTreeList.SelectedNode.Tag as CatalogItem;

                    // only download entire folders, for now.
                    if (ReportItem.Type == ItemTypeEnum.Folder)
                    {
                        RemoteFolder = ReportItem.Path;
                    }
                    else
                    {
                        return;
                    }
                }

                // do we have a valid download folder? if not, then show the dialog to set it
                if (this.downloadFolder == "" || !Directory.Exists(this.downloadFolder))
                {
                    bool FolderResult = this.RunFolderDialog();

                    if (!FolderResult)
                    {
                        return;
                    }
                }
                
                StatusLabel.Text = "Starting Download...";
                this.CurrentState = ServiceState.Downloading;
                Download_Worker.RunWorkerAsync(new DownloadArgs(RemoteFolder, downloadFolder));
            }
            else if (this.CurrentState == ServiceState.Downloading && !Download_Worker.CancellationPending)
            {
                // cancel the download
                Download_Worker.CancelAsync();
            }

        }

        private void ConnectButton_Click(object sender, EventArgs e)
        {
            RunConnectDialog(false);
        }

        private void SetControlsState()
        {
            StatusLabel.Image = null;

            if (this._currentState == ServiceState.Downloading)
            {
                ConnectButton.Enabled = false;
                RefreshButton.Enabled = false;
                ReportTreeList.Enabled = false;
                SetFolderButton.Enabled = false;
                DownloadButton.Enabled = true;

                DownloadButton.Image = Properties.Resources.cancel;
                
            }
            else if (this._currentState == ServiceState.Connected)
            {
                ConnectButton.Enabled = true;
                RefreshButton.Enabled = true;
                DownloadButton.Enabled = true;
                SetFolderButton.Enabled = true;
                ReportTreeList.Enabled = true;

                DownloadButton.Image = Properties.Resources.application_go;
            }
            else if (this._currentState == ServiceState.Disconnected)
            {
                ConnectButton.Enabled = true;
                RefreshButton.Enabled = false;
                ReportTreeList.Enabled = false;
                SetFolderButton.Enabled = true;
                DownloadButton.Enabled = false;
            }
            else if (this._currentState == ServiceState.LoadingList)
            {
                ConnectButton.Enabled = false;
                RefreshButton.Enabled = false;
                ReportTreeList.Enabled = false;
                DownloadButton.Enabled = false;
                SetFolderButton.Enabled = false;
            }
        }

        private void downloadAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DownloadButton.PerformClick();
        }

        private void refreshToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RefreshButton.PerformClick();
        }

        private void ReportTreeList_MouseUp(object sender, MouseEventArgs e)
        {
            // show the right click menu..
            if (e.Button == MouseButtons.Right)
            {
                // select the node they just clicked on. Don't know why this doesn't happen
                // by default
                ReportTreeList.SelectedNode = ReportTreeList.GetNodeAt(e.X, e.Y);

                // check the selecteditem to see whether they should be able to trigger a subscription
                // or not.
                downloadAllToolStripMenuItem.Enabled = (ReportTreeList.SelectedNode != null && ReportTreeList.SelectedNode.Tag != null && ((CatalogItem)ReportTreeList.SelectedNode.Tag).Type == ItemTypeEnum.Folder);
                TreeContextMenu.Show(ReportTreeList, new Point(e.X, e.Y));
            }
        }

        private void SetFolderButton_Click(object sender, EventArgs e)
        {
            this.RunFolderDialog();
        }

        private bool RunFolderDialog()
        {
            bool result = false;
            
            if (this.downloadFolder != "" && Directory.Exists(this.downloadFolder))
            {
                FolderSelectDialog.SelectedPath = this.downloadFolder;
            }

            if (FolderSelectDialog.ShowDialog(this) == DialogResult.OK)
            {
                // save the selected directory to the settings file
                this.downloadFolder = FolderSelectDialog.SelectedPath.AddFileEndSlash();
                Properties.Settings.Default.DownloadFolder = downloadFolder;
                Properties.Settings.Default.Save();

                result = true;
            }

            return result;
        }

        private void ReportTreeList_AfterSelect(object sender, TreeViewEventArgs e)
        {

            bool ButtonState = false;
            if (ReportTreeList.SelectedNode != null && ReportTreeList.SelectedNode.Tag != null)
            {
                CatalogItem c = ReportTreeList.SelectedNode.Tag as CatalogItem;

                if (c != null && c.Type == ItemTypeEnum.Folder)
                {
                    ButtonState = true;
                }
            }

            DownloadButton.Enabled = ButtonState;
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

    public class DownloadResult
    {
        public int DownloadCount;
        public int ErrorCount;

        public DownloadResult(int DownloadCount, int ErrorCount)
        {
            this.DownloadCount = DownloadCount;
            this.ErrorCount = ErrorCount;
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
            return (FilePath != "" && FilePath[FilePath.Length - 1] != '/') ? FilePath + "/" : FilePath;
        }

        public static string AddFileEndSlash(this string FilePath)
        {
            FilePath = FilePath.Trim();
            return (FilePath != "" && FilePath[FilePath.Length - 1] != Path.DirectorySeparatorChar) ? FilePath + Path.DirectorySeparatorChar : FilePath;
        }
    }

    public class RsHelper
    {
        public static Byte[] DownloadReportItem(ReportingService rs, CatalogItem ReportItem)
        {
            try
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
            }
            catch (System.Web.Services.Protocols.SoapException ex)
            {
                // the most likely error here it that the item cannot be found, maybe it was
                // deleted since the item list was retrieved. Ignore those errors, but throw the rest.
                if (ex.Detail.FirstChild.InnerText != "rsItemNotFound" && ex.Detail.FirstChild.InnerText != "rsAccessDenied")
                {
                    throw ex;
                }
            }

            return null;
        }
    }

}