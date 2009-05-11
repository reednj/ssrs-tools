namespace ReportingTools.RenderReport
{
    partial class ReportRenderForm
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
            this.ToolGroupBox = new System.Windows.Forms.GroupBox();
            this.targetDirLink = new System.Windows.Forms.LinkLabel();
            this.label1 = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.GetParmsButton = new System.Windows.Forms.Button();
            this.StartRenderButton = new System.Windows.Forms.Button();
            this.folderBrowser = new System.Windows.Forms.FolderBrowserDialog();
            this.mainStatusStrip = new System.Windows.Forms.StatusStrip();
            this.renderStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.renderProgressBar = new System.Windows.Forms.ToolStripProgressBar();
            this.mainReportTree = new ReportingTools.RenderReport.ReportTree();
            this.ToolGroupBox.SuspendLayout();
            this.mainStatusStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // ToolGroupBox
            // 
            this.ToolGroupBox.Controls.Add(this.targetDirLink);
            this.ToolGroupBox.Controls.Add(this.label1);
            this.ToolGroupBox.Controls.Add(this.comboBox1);
            this.ToolGroupBox.Controls.Add(this.GetParmsButton);
            this.ToolGroupBox.Controls.Add(this.StartRenderButton);
            this.ToolGroupBox.Location = new System.Drawing.Point(13, 334);
            this.ToolGroupBox.Name = "ToolGroupBox";
            this.ToolGroupBox.Size = new System.Drawing.Size(493, 70);
            this.ToolGroupBox.TabIndex = 2;
            this.ToolGroupBox.TabStop = false;
            // 
            // targetDirLink
            // 
            this.targetDirLink.AutoSize = true;
            this.targetDirLink.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.targetDirLink.Image = global::ReportingTools.RenderReport.Properties.Resources.folder_icon;
            this.targetDirLink.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.targetDirLink.LinkColor = System.Drawing.Color.DodgerBlue;
            this.targetDirLink.Location = new System.Drawing.Point(197, 38);
            this.targetDirLink.Name = "targetDirLink";
            this.targetDirLink.Padding = new System.Windows.Forms.Padding(20, 0, 0, 0);
            this.targetDirLink.Size = new System.Drawing.Size(80, 17);
            this.targetDirLink.TabIndex = 8;
            this.targetDirLink.TabStop = true;
            this.targetDirLink.Text = "Desktop";
            this.targetDirLink.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.targetDirLink.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.targetDirLink_LinkClicked);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(15, 40);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(42, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Format:";
            // 
            // comboBox1
            // 
            this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "PNG",
            "PDF",
            "Web Archive"});
            this.comboBox1.Location = new System.Drawing.Point(63, 37);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(119, 21);
            this.comboBox1.TabIndex = 4;
            // 
            // GetParmsButton
            // 
            this.GetParmsButton.Location = new System.Drawing.Point(430, 40);
            this.GetParmsButton.Name = "GetParmsButton";
            this.GetParmsButton.Size = new System.Drawing.Size(57, 20);
            this.GetParmsButton.TabIndex = 3;
            this.GetParmsButton.Text = "Params";
            this.GetParmsButton.UseVisualStyleBackColor = true;
            this.GetParmsButton.Click += new System.EventHandler(this.GetParmsButton_Click);
            // 
            // StartRenderButton
            // 
            this.StartRenderButton.Location = new System.Drawing.Point(430, 14);
            this.StartRenderButton.Name = "StartRenderButton";
            this.StartRenderButton.Size = new System.Drawing.Size(57, 20);
            this.StartRenderButton.TabIndex = 1;
            this.StartRenderButton.Text = "Render";
            this.StartRenderButton.UseVisualStyleBackColor = true;
            this.StartRenderButton.Click += new System.EventHandler(this.StartRenderButton_Click);
            // 
            // mainStatusStrip
            // 
            this.mainStatusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.renderStatusLabel,
            this.renderProgressBar});
            this.mainStatusStrip.Location = new System.Drawing.Point(0, 409);
            this.mainStatusStrip.Name = "mainStatusStrip";
            this.mainStatusStrip.Size = new System.Drawing.Size(519, 22);
            this.mainStatusStrip.TabIndex = 3;
            this.mainStatusStrip.Text = "statusStrip1";
            // 
            // renderStatusLabel
            // 
            this.renderStatusLabel.Name = "renderStatusLabel";
            this.renderStatusLabel.Size = new System.Drawing.Size(19, 17);
            this.renderStatusLabel.Text = "...";
            // 
            // renderProgressBar
            // 
            this.renderProgressBar.Name = "renderProgressBar";
            this.renderProgressBar.Size = new System.Drawing.Size(100, 16);
            this.renderProgressBar.Style = System.Windows.Forms.ProgressBarStyle.Marquee;
            this.renderProgressBar.Visible = false;
            // 
            // mainReportTree
            // 
            this.mainReportTree.Location = new System.Drawing.Point(12, 12);
            this.mainReportTree.Name = "mainReportTree";
            this.mainReportTree.Size = new System.Drawing.Size(495, 313);
            this.mainReportTree.TabIndex = 1;
            // 
            // ReportRenderForm
            // 
            this.ClientSize = new System.Drawing.Size(519, 431);
            this.Controls.Add(this.mainStatusStrip);
            this.Controls.Add(this.ToolGroupBox);
            this.Controls.Add(this.mainReportTree);
            this.Name = "ReportRenderForm";
            this.Text = "Render Report";
            this.Load += new System.EventHandler(this.ReportRenderForm_Load);
            this.ToolGroupBox.ResumeLayout(false);
            this.ToolGroupBox.PerformLayout();
            this.mainStatusStrip.ResumeLayout(false);
            this.mainStatusStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ReportTree mainReportTree;
        private System.Windows.Forms.GroupBox ToolGroupBox;
        private System.Windows.Forms.Button StartRenderButton;
        private System.Windows.Forms.Button GetParmsButton;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.LinkLabel targetDirLink;
        private System.Windows.Forms.FolderBrowserDialog folderBrowser;
        private System.Windows.Forms.StatusStrip mainStatusStrip;
        private System.Windows.Forms.ToolStripProgressBar renderProgressBar;
        private System.Windows.Forms.ToolStripStatusLabel renderStatusLabel;
    }
}

