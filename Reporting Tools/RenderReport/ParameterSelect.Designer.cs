namespace RenderReport
{
    partial class ParameterSelectForm
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
            this.paramGridView = new System.Windows.Forms.DataGridView();
            this.NameColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ValueColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.paramGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // paramGridView
            // 
            this.paramGridView.AllowUserToAddRows = false;
            this.paramGridView.AllowUserToDeleteRows = false;
            this.paramGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.paramGridView.BackgroundColor = System.Drawing.SystemColors.Window;
            this.paramGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.paramGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.NameColumn,
            this.ValueColumn});
            this.paramGridView.Location = new System.Drawing.Point(8, 4);
            this.paramGridView.Name = "paramGridView";
            this.paramGridView.Size = new System.Drawing.Size(411, 252);
            this.paramGridView.TabIndex = 0;
            // 
            // NameColumn
            // 
            this.NameColumn.HeaderText = "Parameter Name";
            this.NameColumn.Name = "NameColumn";
            this.NameColumn.ReadOnly = true;
            // 
            // ValueColumn
            // 
            this.ValueColumn.HeaderText = "Value";
            this.ValueColumn.Name = "ValueColumn";
            // 
            // ParameterSelectForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(426, 266);
            this.Controls.Add(this.paramGridView);
            this.Name = "ParameterSelectForm";
            this.Text = "ParameterSelect";
            this.Load += new System.EventHandler(this.ParameterSelectForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.paramGridView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView paramGridView;
        private System.Windows.Forms.DataGridViewTextBoxColumn NameColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn ValueColumn;
    }
}