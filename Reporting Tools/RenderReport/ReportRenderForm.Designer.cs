namespace RenderReport
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
            this.mainReportTree = new RenderReport.ReportTree();
            this.label1 = new System.Windows.Forms.Label();
            this.ToolGroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // ToolGroupBox
            // 
            this.ToolGroupBox.Controls.Add(this.label1);
            this.ToolGroupBox.Location = new System.Drawing.Point(13, 334);
            this.ToolGroupBox.Name = "ToolGroupBox";
            this.ToolGroupBox.Size = new System.Drawing.Size(493, 82);
            this.ToolGroupBox.TabIndex = 2;
            this.ToolGroupBox.TabStop = false;
            // 
            // mainReportTree
            // 
            this.mainReportTree.Location = new System.Drawing.Point(12, 12);
            this.mainReportTree.Name = "mainReportTree";
            this.mainReportTree.Size = new System.Drawing.Size(495, 313);
            this.mainReportTree.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(25, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "label1";
            // 
            // ReportRenderForm
            // 
            this.ClientSize = new System.Drawing.Size(519, 428);
            this.Controls.Add(this.ToolGroupBox);
            this.Controls.Add(this.mainReportTree);
            this.Name = "ReportRenderForm";
            this.Text = "Render Report";
            this.Load += new System.EventHandler(this.ReportRenderForm_Load);
            this.ToolGroupBox.ResumeLayout(false);
            this.ToolGroupBox.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private ReportTree mainReportTree;
        private System.Windows.Forms.GroupBox ToolGroupBox;
        private System.Windows.Forms.Label label1;
    }
}

