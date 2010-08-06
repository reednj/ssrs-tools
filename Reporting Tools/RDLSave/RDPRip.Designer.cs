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
            this.ReportTreeList = new ReportingTools.Common.ReportTree();
            this.SuspendLayout();
            // 
            // StartButton
            // 
            this.StartButton.Location = new System.Drawing.Point(490, 509);
            this.StartButton.Name = "StartButton";
            this.StartButton.Size = new System.Drawing.Size(153, 28);
            this.StartButton.TabIndex = 1;
            this.StartButton.Text = "Download All";
            this.StartButton.UseVisualStyleBackColor = true;
            this.StartButton.Click += new System.EventHandler(this.StartButton_Click);
            // 
            // ReportTreeList
            // 
            this.ReportTreeList.ImageIndex = 0;
            this.ReportTreeList.Location = new System.Drawing.Point(12, 12);
            this.ReportTreeList.Name = "ReportTreeList";
            this.ReportTreeList.SelectedImageIndex = 0;
            this.ReportTreeList.Size = new System.Drawing.Size(631, 491);
            this.ReportTreeList.TabIndex = 0;
            // 
            // RDPRip
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(655, 549);
            this.Controls.Add(this.StartButton);
            this.Controls.Add(this.ReportTreeList);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "RDPRip";
            this.Text = "Save Rdls";
            this.Load += new System.EventHandler(this.RDPRip_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private ReportingTools.Common.ReportTree ReportTreeList;
        private System.Windows.Forms.Button StartButton;
    }
}

