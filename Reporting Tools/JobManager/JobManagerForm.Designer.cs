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
            this.jobListView = new System.Windows.Forms.ListView();
            this.killJobButton = new System.Windows.Forms.Button();
            this.refreshButton = new System.Windows.Forms.Button();
            this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader2 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader3 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader4 = new System.Windows.Forms.ColumnHeader();
            this.SuspendLayout();
            // 
            // jobListView
            // 
            this.jobListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
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
            // killJobButton
            // 
            this.killJobButton.Location = new System.Drawing.Point(484, 260);
            this.killJobButton.Name = "killJobButton";
            this.killJobButton.Size = new System.Drawing.Size(97, 26);
            this.killJobButton.TabIndex = 1;
            this.killJobButton.Text = "Stop Job";
            this.killJobButton.UseVisualStyleBackColor = true;
            // 
            // refreshButton
            // 
            this.refreshButton.Location = new System.Drawing.Point(381, 260);
            this.refreshButton.Name = "refreshButton";
            this.refreshButton.Size = new System.Drawing.Size(97, 26);
            this.refreshButton.TabIndex = 2;
            this.refreshButton.Text = "Refresh";
            this.refreshButton.UseVisualStyleBackColor = true;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Type";
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Path";
            this.columnHeader2.Width = 330;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "User";
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "Time";
            // 
            // JobManagerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(593, 293);
            this.Controls.Add(this.refreshButton);
            this.Controls.Add(this.killJobButton);
            this.Controls.Add(this.jobListView);
            this.Name = "JobManagerForm";
            this.Text = "Job Manager";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView jobListView;
        private System.Windows.Forms.Button killJobButton;
        private System.Windows.Forms.Button refreshButton;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;

    }
}

