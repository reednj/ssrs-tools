namespace ReportingTools.SubscriptionManager
{
    partial class SubscriptionManager
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SubscriptionManager));
            this.detailsBox = new System.Windows.Forms.GroupBox();
            this.subLastRanLabel = new System.Windows.Forms.Label();
            this.subLastResultLabel = new System.Windows.Forms.Label();
            this.subDescLabel = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.subTreeMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.triggerSubscriptionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.refreshToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mainStatusStrip = new System.Windows.Forms.StatusStrip();
            this.statusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.iconList = new System.Windows.Forms.ImageList(this.components);
            this.mainToolStrip = new System.Windows.Forms.ToolStrip();
            this.ConnectToolButton = new System.Windows.Forms.ToolStripButton();
            this.refreshToolButton = new System.Windows.Forms.ToolStripButton();
            this.triggerToolButton = new System.Windows.Forms.ToolStripButton();
            this.mainSubTree = new ReportingTools.SubscriptionManager.SubscriptionTree();
            this.detailsBox.SuspendLayout();
            this.subTreeMenu.SuspendLayout();
            this.mainStatusStrip.SuspendLayout();
            this.mainToolStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // detailsBox
            // 
            this.detailsBox.Controls.Add(this.subLastRanLabel);
            this.detailsBox.Controls.Add(this.subLastResultLabel);
            this.detailsBox.Controls.Add(this.subDescLabel);
            this.detailsBox.Controls.Add(this.label3);
            this.detailsBox.Controls.Add(this.label2);
            this.detailsBox.Controls.Add(this.label1);
            this.detailsBox.Location = new System.Drawing.Point(11, 339);
            this.detailsBox.Name = "detailsBox";
            this.detailsBox.Size = new System.Drawing.Size(564, 69);
            this.detailsBox.TabIndex = 3;
            this.detailsBox.TabStop = false;
            this.detailsBox.Text = "Subscription Details";
            // 
            // subLastRanLabel
            // 
            this.subLastRanLabel.Location = new System.Drawing.Point(99, 45);
            this.subLastRanLabel.Name = "subLastRanLabel";
            this.subLastRanLabel.Size = new System.Drawing.Size(459, 13);
            this.subLastRanLabel.TabIndex = 5;
            this.subLastRanLabel.Text = "-";
            // 
            // subLastResultLabel
            // 
            this.subLastResultLabel.AutoEllipsis = true;
            this.subLastResultLabel.Location = new System.Drawing.Point(99, 32);
            this.subLastResultLabel.Name = "subLastResultLabel";
            this.subLastResultLabel.Size = new System.Drawing.Size(459, 13);
            this.subLastResultLabel.TabIndex = 4;
            this.subLastResultLabel.Text = "-";
            // 
            // subDescLabel
            // 
            this.subDescLabel.AutoEllipsis = true;
            this.subDescLabel.Location = new System.Drawing.Point(99, 19);
            this.subDescLabel.Name = "subDescLabel";
            this.subDescLabel.Size = new System.Drawing.Size(459, 13);
            this.subDescLabel.TabIndex = 3;
            this.subDescLabel.Text = "-";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(13, 45);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Last Ran:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 32);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(63, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Last Result:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(63, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Description:";
            // 
            // subTreeMenu
            // 
            this.subTreeMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.triggerSubscriptionToolStripMenuItem,
            this.toolStripSeparator1,
            this.refreshToolStripMenuItem});
            this.subTreeMenu.Name = "subTreeMenu";
            this.subTreeMenu.Size = new System.Drawing.Size(181, 54);
            // 
            // triggerSubscriptionToolStripMenuItem
            // 
            this.triggerSubscriptionToolStripMenuItem.Name = "triggerSubscriptionToolStripMenuItem";
            this.triggerSubscriptionToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.triggerSubscriptionToolStripMenuItem.Text = "Trigger Subscription";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(177, 6);
            // 
            // refreshToolStripMenuItem
            // 
            this.refreshToolStripMenuItem.Name = "refreshToolStripMenuItem";
            this.refreshToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.refreshToolStripMenuItem.Text = "Refresh";
            this.refreshToolStripMenuItem.Click += new System.EventHandler(this.refreshToolStripMenuItem_Click);
            // 
            // mainStatusStrip
            // 
            this.mainStatusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.statusLabel});
            this.mainStatusStrip.Location = new System.Drawing.Point(0, 416);
            this.mainStatusStrip.Name = "mainStatusStrip";
            this.mainStatusStrip.Size = new System.Drawing.Size(587, 22);
            this.mainStatusStrip.SizingGrip = false;
            this.mainStatusStrip.TabIndex = 4;
            this.mainStatusStrip.Text = "statusStrip1";
            // 
            // statusLabel
            // 
            this.statusLabel.Name = "statusLabel";
            this.statusLabel.Size = new System.Drawing.Size(19, 17);
            this.statusLabel.Text = "...";
            // 
            // iconList
            // 
            this.iconList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("iconList.ImageStream")));
            this.iconList.TransparentColor = System.Drawing.Color.Transparent;
            this.iconList.Images.SetKeyName(0, "Folder.ico");
            this.iconList.Images.SetKeyName(1, "Report.png");
            this.iconList.Images.SetKeyName(2, "Subscription.png");
            // 
            // mainToolStrip
            // 
            this.mainToolStrip.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.mainToolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ConnectToolButton,
            this.refreshToolButton,
            this.triggerToolButton});
            this.mainToolStrip.Location = new System.Drawing.Point(0, 0);
            this.mainToolStrip.Name = "mainToolStrip";
            this.mainToolStrip.Size = new System.Drawing.Size(587, 25);
            this.mainToolStrip.Stretch = true;
            this.mainToolStrip.TabIndex = 5;
            this.mainToolStrip.Text = "toolStrip1";
            // 
            // ConnectToolButton
            // 
            this.ConnectToolButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.ConnectToolButton.Image = global::ReportingTools.SubscriptionManager.Properties.Resources.connect;
            this.ConnectToolButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ConnectToolButton.Name = "ConnectToolButton";
            this.ConnectToolButton.Size = new System.Drawing.Size(23, 22);
            this.ConnectToolButton.Text = "Connect";
            this.ConnectToolButton.Click += new System.EventHandler(this.ConnectToolButton_Click);
            // 
            // refreshToolButton
            // 
            this.refreshToolButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.refreshToolButton.Image = global::ReportingTools.SubscriptionManager.Properties.Resources.arrow_refresh;
            this.refreshToolButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.refreshToolButton.Name = "refreshToolButton";
            this.refreshToolButton.Size = new System.Drawing.Size(23, 22);
            this.refreshToolButton.Text = "Refresh";
            this.refreshToolButton.Click += new System.EventHandler(this.refreshToolButton_Click);
            // 
            // triggerToolButton
            // 
            this.triggerToolButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.triggerToolButton.Image = global::ReportingTools.SubscriptionManager.Properties.Resources.application_go;
            this.triggerToolButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.triggerToolButton.Name = "triggerToolButton";
            this.triggerToolButton.Size = new System.Drawing.Size(23, 22);
            this.triggerToolButton.Text = "Trigger Subscription";
            this.triggerToolButton.Click += new System.EventHandler(this.triggerToolButton_Click);
            // 
            // mainSubTree
            // 
            this.mainSubTree.ImageIndex = 0;
            this.mainSubTree.ImageList = this.iconList;
            this.mainSubTree.Location = new System.Drawing.Point(12, 28);
            this.mainSubTree.Name = "mainSubTree";
            this.mainSubTree.SelectedImageIndex = 0;
            this.mainSubTree.Size = new System.Drawing.Size(563, 305);
            this.mainSubTree.TabIndex = 2;
            this.mainSubTree.MouseUp += new System.Windows.Forms.MouseEventHandler(this.mainSubTree_MouseUp);
            this.mainSubTree.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.mainSubTree_AfterSelect);
            // 
            // SubscriptionManager
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(587, 438);
            this.Controls.Add(this.mainToolStrip);
            this.Controls.Add(this.detailsBox);
            this.Controls.Add(this.mainSubTree);
            this.Controls.Add(this.mainStatusStrip);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "SubscriptionManager";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Subscription Manager";
            this.Load += new System.EventHandler(this.SubscriptionManager_Load);
            this.Activated += new System.EventHandler(this.SubscriptionManager_Activated);
            this.detailsBox.ResumeLayout(false);
            this.detailsBox.PerformLayout();
            this.subTreeMenu.ResumeLayout(false);
            this.mainStatusStrip.ResumeLayout(false);
            this.mainStatusStrip.PerformLayout();
            this.mainToolStrip.ResumeLayout(false);
            this.mainToolStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox detailsBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label subLastRanLabel;
        private System.Windows.Forms.Label subLastResultLabel;
        private System.Windows.Forms.Label subDescLabel;
        private System.Windows.Forms.ContextMenuStrip subTreeMenu;
        private System.Windows.Forms.ToolStripMenuItem refreshToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem triggerSubscriptionToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.StatusStrip mainStatusStrip;
        private System.Windows.Forms.ToolStripStatusLabel statusLabel;
        private System.Windows.Forms.ImageList iconList;
        private System.Windows.Forms.ToolStrip mainToolStrip;
        private System.Windows.Forms.ToolStripButton refreshToolButton;
        private System.Windows.Forms.ToolStripButton triggerToolButton;
        private System.Windows.Forms.ToolStripButton ConnectToolButton;
        private SubscriptionTree mainSubTree;
    }
}

