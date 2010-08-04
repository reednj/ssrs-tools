namespace ReportingTools.Common
{
    partial class ImageLabel
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.MainPicture = new System.Windows.Forms.PictureBox();
            this.MainLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.MainPicture)).BeginInit();
            this.SuspendLayout();
            // 
            // MainPicture
            // 
            this.MainPicture.Location = new System.Drawing.Point(0, 0);
            this.MainPicture.Name = "MainPicture";
            this.MainPicture.Size = new System.Drawing.Size(16, 16);
            this.MainPicture.TabIndex = 0;
            this.MainPicture.TabStop = false;
            // 
            // MainLabel
            // 
            this.MainLabel.AutoEllipsis = true;
            this.MainLabel.AutoSize = true;
            this.MainLabel.Location = new System.Drawing.Point(22, 0);
            this.MainLabel.Name = "MainLabel";
            this.MainLabel.Size = new System.Drawing.Size(35, 13);
            this.MainLabel.TabIndex = 1;
            this.MainLabel.Text = "label1";
            this.MainLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ImageLabel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.Controls.Add(this.MainLabel);
            this.Controls.Add(this.MainPicture);
            this.Name = "ImageLabel";
            this.Size = new System.Drawing.Size(94, 33);
            this.Load += new System.EventHandler(this.ImageLabel_Load);
            this.SizeChanged += new System.EventHandler(this.ImageLabel_SizeChanged);
            ((System.ComponentModel.ISupportInitialize)(this.MainPicture)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox MainPicture;
        private System.Windows.Forms.Label MainLabel;
    }
}
