namespace RDLSave
{
    partial class RDPRip
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.TreeNode treeNode1 = new System.Windows.Forms.TreeNode("Home");
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RDPRip));
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.StatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.LoadList_Worker = new System.ComponentModel.BackgroundWorker();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.ConnectButton = new System.Windows.Forms.ToolStripButton();
            this.SetFolderButton = new System.Windows.Forms.ToolStripButton();
            this.RefreshButton = new System.Windows.Forms.ToolStripButton();
            this.DownloadButton = new System.Windows.Forms.ToolStripButton();
            this.Download_Worker = new System.ComponentModel.BackgroundWorker();
            this.TreeContextMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.viewReportToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.downloadAllToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.refreshToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.FolderSelectDialog = new System.Windows.Forms.FolderBrowserDialog();
            this.ReportTreeList = new ReportingTools.Common.ReportTree();
            this.statusStrip1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.TreeContextMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.StatusLabel});
            this.statusStrip1.Location = new System.Drawing.Point(0, 527);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(655, 22);
            this.statusStrip1.TabIndex = 2;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // StatusLabel
            // 
            this.StatusLabel.Name = "StatusLabel";
            this.StatusLabel.Size = new System.Drawing.Size(19, 17);
            this.StatusLabel.Text = "...";
            // 
            // LoadList_Worker
            // 
            this.LoadList_Worker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.LoadList_Worker_DoWork);
            this.LoadList_Worker.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.LoadList_Worker_RunWorkerCompleted);
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ConnectButton,
            this.SetFolderButton,
            this.RefreshButton,
            this.DownloadButton});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(655, 25);
            this.toolStrip1.TabIndex = 3;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // ConnectButton
            // 
            this.ConnectButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.ConnectButton.Image = global::RDLSave.Properties.Resources.connect;
            this.ConnectButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ConnectButton.Name = "ConnectButton";
            this.ConnectButton.Size = new System.Drawing.Size(23, 22);
            this.ConnectButton.Text = "Connect";
            this.ConnectButton.Click += new System.EventHandler(this.ConnectButton_Click);
            // 
            // SetFolderButton
            // 
            this.SetFolderButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.SetFolderButton.Image = global::RDLSave.Properties.Resources.folder_icon;
            this.SetFolderButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.SetFolderButton.Name = "SetFolderButton";
            this.SetFolderButton.Size = new System.Drawing.Size(23, 22);
            this.SetFolderButton.Text = "Set Download Folder";
            this.SetFolderButton.Click += new System.EventHandler(this.SetFolderButton_Click);
            // 
            // RefreshButton
            // 
            this.RefreshButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.RefreshButton.Image = global::RDLSave.Properties.Resources.arrow_refresh;
            this.RefreshButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.RefreshButton.Name = "RefreshButton";
            this.RefreshButton.Size = new System.Drawing.Size(23, 22);
            this.RefreshButton.Text = "Refresh";
            this.RefreshButton.Click += new System.EventHandler(this.RefreshButton_Click);
            // 
            // DownloadButton
            // 
            this.DownloadButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.DownloadButton.Image = global::RDLSave.Properties.Resources.application_go;
            this.DownloadButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.DownloadButton.Name = "DownloadButton";
            this.DownloadButton.Size = new System.Drawing.Size(23, 22);
            this.DownloadButton.Text = "Download Selection";
            this.DownloadButton.Click += new System.EventHandler(this.DownloadButton_Click);
            // 
            // Download_Worker
            // 
            this.Download_Worker.WorkerReportsProgress = true;
            this.Download_Worker.WorkerSupportsCancellation = true;
            this.Download_Worker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.Download_Worker_DoWork);
            this.Download_Worker.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.Download_Worker_RunWorkerCompleted);
            this.Download_Worker.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.Download_Worker_ProgressChanged);
            // 
            // TreeContextMenu
            // 
            this.TreeContextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.viewReportToolStripMenuItem,
            this.downloadAllToolStripMenuItem,
            this.toolStripMenuItem1,
            this.refreshToolStripMenuItem});
            this.TreeContextMenu.Name = "TreeContextMenu";
            this.TreeContextMenu.ShowImageMargin = false;
            this.TreeContextMenu.Size = new System.Drawing.Size(134, 76);
            // 
            // viewReportToolStripMenuItem
            // 
            this.viewReportToolStripMenuItem.Name = "viewReportToolStripMenuItem";
            this.viewReportToolStripMenuItem.Size = new System.Drawing.Size(133, 22);
            this.viewReportToolStripMenuItem.Text = "View Report...";
            this.viewReportToolStripMenuItem.Click += new System.EventHandler(this.viewReportToolStripMenuItem_Click);
            // 
            // downloadAllToolStripMenuItem
            // 
            this.downloadAllToolStripMenuItem.Name = "downloadAllToolStripMenuItem";
            this.downloadAllToolStripMenuItem.Size = new System.Drawing.Size(133, 22);
            this.downloadAllToolStripMenuItem.Text = "Download All...";
            this.downloadAllToolStripMenuItem.Click += new System.EventHandler(this.downloadAllToolStripMenuItem_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(130, 6);
            // 
            // refreshToolStripMenuItem
            // 
            this.refreshToolStripMenuItem.Name = "refreshToolStripMenuItem";
            this.refreshToolStripMenuItem.Size = new System.Drawing.Size(133, 22);
            this.refreshToolStripMenuItem.Text = "Refresh";
            this.refreshToolStripMenuItem.Click += new System.EventHandler(this.refreshToolStripMenuItem_Click);
            // 
            // FolderSelectDialog
            // 
            this.FolderSelectDialog.Description = "Select Download Folder";
            // 
            // ReportTreeList
            // 
            this.ReportTreeList.ImageIndex = 0;
            this.ReportTreeList.Location = new System.Drawing.Point(12, 28);
            this.ReportTreeList.Name = "ReportTreeList";
            treeNode1.ImageKey = "Folder";
            treeNode1.Name = "Root";
            treeNode1.SelectedImageKey = "Folder";
            treeNode1.Text = "Home";
            this.ReportTreeList.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode1});
            this.ReportTreeList.SelectedImageIndex = 0;
            this.ReportTreeList.Size = new System.Drawing.Size(631, 496);
            this.ReportTreeList.TabIndex = 0;
            this.ReportTreeList.MouseUp += new System.Windows.Forms.MouseEventHandler(this.ReportTreeList_MouseUp);
            this.ReportTreeList.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.ReportTreeList_AfterSelect);
            // 
            // RDPRip
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(655, 549);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.ReportTreeList);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "RDPRip";
            this.Text = "Download Server Objects";
            this.Load += new System.EventHandler(this.RDPRip_Load);
            this.SizeChanged += new System.EventHandler(this.RDPRip_SizeChanged);
            this.Activated += new System.EventHandler(this.RDPRip_Activated);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.TreeContextMenu.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ReportingTools.Common.ReportTree ReportTreeList;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel StatusLabel;
        private System.ComponentModel.BackgroundWorker LoadList_Worker;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton RefreshButton;
        private System.Windows.Forms.ToolStripButton DownloadButton;
        private System.Windows.Forms.ToolStripButton ConnectButton;
        private System.ComponentModel.BackgroundWorker Download_Worker;
        private System.Windows.Forms.ToolStripButton SetFolderButton;
        private System.Windows.Forms.ContextMenuStrip TreeContextMenu;
        private System.Windows.Forms.ToolStripMenuItem downloadAllToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem refreshToolStripMenuItem;
        private System.Windows.Forms.FolderBrowserDialog FolderSelectDialog;
        private System.Windows.Forms.ToolStripMenuItem viewReportToolStripMenuItem;
    }
}

