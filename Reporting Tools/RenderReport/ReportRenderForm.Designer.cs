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
            this.StartRenderButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.mainReportTree = new RenderReport.ReportTree();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.GetParmsButton = new System.Windows.Forms.Button();
            this.ToolGroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // ToolGroupBox
            // 
            this.ToolGroupBox.Controls.Add(this.GetParmsButton);
            this.ToolGroupBox.Controls.Add(this.textBox1);
            this.ToolGroupBox.Controls.Add(this.StartRenderButton);
            this.ToolGroupBox.Controls.Add(this.label1);
            this.ToolGroupBox.Location = new System.Drawing.Point(13, 334);
            this.ToolGroupBox.Name = "ToolGroupBox";
            this.ToolGroupBox.Size = new System.Drawing.Size(493, 193);
            this.ToolGroupBox.TabIndex = 2;
            this.ToolGroupBox.TabStop = false;
            // 
            // StartRenderButton
            // 
            this.StartRenderButton.Location = new System.Drawing.Point(357, 24);
            this.StartRenderButton.Name = "StartRenderButton";
            this.StartRenderButton.Size = new System.Drawing.Size(57, 29);
            this.StartRenderButton.TabIndex = 1;
            this.StartRenderButton.Text = "go";
            this.StartRenderButton.UseVisualStyleBackColor = true;
            this.StartRenderButton.Click += new System.EventHandler(this.StartRenderButton_Click);
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
            // mainReportTree
            // 
            this.mainReportTree.Location = new System.Drawing.Point(12, 12);
            this.mainReportTree.Name = "mainReportTree";
            this.mainReportTree.Size = new System.Drawing.Size(495, 313);
            this.mainReportTree.TabIndex = 1;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(66, 24);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(241, 150);
            this.textBox1.TabIndex = 2;
            // 
            // GetParmsButton
            // 
            this.GetParmsButton.Location = new System.Drawing.Point(365, 63);
            this.GetParmsButton.Name = "GetParmsButton";
            this.GetParmsButton.Size = new System.Drawing.Size(48, 20);
            this.GetParmsButton.TabIndex = 3;
            this.GetParmsButton.Text = "button1";
            this.GetParmsButton.UseVisualStyleBackColor = true;
            this.GetParmsButton.Click += new System.EventHandler(this.GetParmsButton_Click);
            // 
            // ReportRenderForm
            // 
            this.ClientSize = new System.Drawing.Size(519, 553);
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
        private System.Windows.Forms.Button StartRenderButton;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button GetParmsButton;
    }
}

