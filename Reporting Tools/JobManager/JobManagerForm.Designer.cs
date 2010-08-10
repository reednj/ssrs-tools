namespace ReportingTools.JobManager
{
    partial class JobManagerForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(JobManagerForm));
            this.jobListView = new System.Windows.Forms.ListView();
            this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader5 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader2 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader3 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader4 = new System.Windows.Forms.ColumnHeader();
            this.killJobButton = new System.Windows.Forms.Button();
            this.refreshButton = new System.Windows.Forms.Button();
            this.mainStatusStrip = new System.Windows.Forms.StatusStrip();
            this.mainStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.RefreshTimer = new System.Windows.Forms.Timer(this.components);
            this.mainStatusStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // jobListView
            // 
            this.jobListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader5,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4});
            this.jobListView.FullRowSelect = true;
            this.jobListView.Location = new System.Drawing.Point(12, 12);
            this.jobListView.Name = "jobListView";
            this.jobListView.Size = new System.Drawing.Size(569, 242);
            this.jobListView.TabIndex = 0;
            this.jobListView.UseCompatibleStateImageBehavior = false;
            this.jobListView.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Type";
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "Status";
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Path";
            this.columnHeader2.Width = 251;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "User";
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "Time";
            // 
            // killJobButton
            // 
            this.killJobButton.Location = new System.Drawing.Point(484, 260);
            this.killJobButton.Name = "killJobButton";
            this.killJobButton.Size = new System.Drawing.Size(97, 26);
            this.killJobButton.TabIndex = 1;
            this.killJobButton.Text = "Stop Job";
            this.killJobButton.UseVisualStyleBackColor = true;
            this.killJobButton.Click += new System.EventHandler(this.killJobButton_Click);
            // 
            // refreshButton
            // 
            this.refreshButton.Location = new System.Drawing.Point(381, 260);
            this.refreshButton.Name = "refreshButton";
            this.refreshButton.Size = new System.Drawing.Size(97, 26);
            this.refreshButton.TabIndex = 2;
            this.refreshButton.Text = "Refresh";
            this.refreshButton.UseVisualStyleBackColor = true;
            this.refreshButton.Click += new System.EventHandler(this.refreshButton_Click);
            // 
            // mainStatusStrip
            // 
            this.mainStatusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mainStatusLabel});
            this.mainStatusStrip.Location = new System.Drawing.Point(0, 293);
            this.mainStatusStrip.Name = "mainStatusStrip";
            this.mainStatusStrip.Size = new System.Drawing.Size(592, 22);
            this.mainStatusStrip.TabIndex = 3;
            this.mainStatusStrip.Text = "statusStrip1";
            // 
            // mainStatusLabel
            // 
            this.mainStatusLabel.Name = "mainStatusLabel";
            this.mainStatusLabel.Size = new System.Drawing.Size(19, 17);
            this.mainStatusLabel.Text = "...";
            // 
            // RefreshTimer
            // 
            this.RefreshTimer.Interval = 1000;
            this.RefreshTimer.Tick += new System.EventHandler(this.RefreshTimer_Tick);
            // 
            // JobManagerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(592, 315);
            this.Controls.Add(this.mainStatusStrip);
            this.Controls.Add(this.refreshButton);
            this.Controls.Add(this.killJobButton);
            this.Controls.Add(this.jobListView);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "JobManagerForm";
            this.Text = "Job Manager";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Activated += new System.EventHandler(this.JobManagerForm_Activated);
            this.mainStatusStrip.ResumeLayout(false);
            this.mainStatusStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView jobListView;
        private System.Windows.Forms.Button killJobButton;
        private System.Windows.Forms.Button refreshButton;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.StatusStrip mainStatusStrip;
        private System.Windows.Forms.ToolStripStatusLabel mainStatusLabel;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.Timer RefreshTimer;

    }
}

