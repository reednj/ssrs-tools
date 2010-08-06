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
            this.StartButton = new System.Windows.Forms.Button();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.StatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.LoadList_Worker = new System.ComponentModel.BackgroundWorker();
            this.ReportTreeList = new ReportingTools.Common.ReportTree();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // StartButton
            // 
            this.StartButton.Location = new System.Drawing.Point(490, 496);
            this.StartButton.Name = "StartButton";
            this.StartButton.Size = new System.Drawing.Size(153, 28);
            this.StartButton.TabIndex = 1;
            this.StartButton.Text = "Download All";
            this.StartButton.UseVisualStyleBackColor = true;
            this.StartButton.Click += new System.EventHandler(this.StartButton_Click);
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
            // ReportTreeList
            // 
            this.ReportTreeList.ImageIndex = 0;
            this.ReportTreeList.Location = new System.Drawing.Point(12, 28);
            this.ReportTreeList.Name = "ReportTreeList";
            this.ReportTreeList.SelectedImageIndex = 0;
            this.ReportTreeList.Size = new System.Drawing.Size(631, 462);
            this.ReportTreeList.TabIndex = 0;
            // 
            // toolStrip1
            // 
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(655, 25);
            this.toolStrip1.TabIndex = 3;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // RDPRip
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(655, 549);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.StartButton);
            this.Controls.Add(this.ReportTreeList);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "RDPRip";
            this.Text = "Save Rdls";
            this.Load += new System.EventHandler(this.RDPRip_Load);
            this.Activated += new System.EventHandler(this.RDPRip_Activated);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ReportingTools.Common.ReportTree ReportTreeList;
        private System.Windows.Forms.Button StartButton;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel StatusLabel;
        private System.ComponentModel.BackgroundWorker LoadList_Worker;
        private System.Windows.Forms.ToolStrip toolStrip1;
    }
}

