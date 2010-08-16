namespace ReportingTools.Common
{
    partial class EnterKeyForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EnterKeyForm));
            this.CloseButton = new System.Windows.Forms.Button();
            this.ValidateButton = new System.Windows.Forms.Button();
            this.LicenseTextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.PurchaseButton = new System.Windows.Forms.Button();
            this.ErrorLabel = new ReportingTools.Common.ImageLabel();
            this.SuspendLayout();
            // 
            // CloseButton
            // 
            this.CloseButton.Location = new System.Drawing.Point(405, 60);
            this.CloseButton.Name = "CloseButton";
            this.CloseButton.Size = new System.Drawing.Size(93, 25);
            this.CloseButton.TabIndex = 0;
            this.CloseButton.Text = "Cancel";
            this.CloseButton.UseVisualStyleBackColor = true;
            this.CloseButton.Click += new System.EventHandler(this.CloseButton_Click);
            // 
            // ValidateButton
            // 
            this.ValidateButton.Location = new System.Drawing.Point(306, 60);
            this.ValidateButton.Name = "ValidateButton";
            this.ValidateButton.Size = new System.Drawing.Size(93, 25);
            this.ValidateButton.TabIndex = 1;
            this.ValidateButton.Text = "OK";
            this.ValidateButton.UseVisualStyleBackColor = true;
            this.ValidateButton.Click += new System.EventHandler(this.ValidateButton_Click);
            // 
            // LicenseTextBox
            // 
            this.LicenseTextBox.Location = new System.Drawing.Point(83, 12);
            this.LicenseTextBox.Name = "LicenseTextBox";
            this.LicenseTextBox.Size = new System.Drawing.Size(415, 20);
            this.LicenseTextBox.TabIndex = 2;
            this.LicenseTextBox.TextChanged += new System.EventHandler(this.LicenseTextBox_KeyUp);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "License Key";
            // 
            // PurchaseButton
            // 
            this.PurchaseButton.Location = new System.Drawing.Point(15, 60);
            this.PurchaseButton.Name = "PurchaseButton";
            this.PurchaseButton.Size = new System.Drawing.Size(93, 25);
            this.PurchaseButton.TabIndex = 4;
            this.PurchaseButton.Text = "Buy Now...";
            this.PurchaseButton.UseVisualStyleBackColor = true;
            this.PurchaseButton.Click += new System.EventHandler(this.PurchaseButton_Click);
            // 
            // ErrorLabel
            // 
            this.ErrorLabel.AutoSize = true;
            this.ErrorLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ErrorLabel.Image = global::ReportingTools.Common.Properties.Resources.exclamation;
            this.ErrorLabel.LabelText = "Error";
            this.ErrorLabel.Location = new System.Drawing.Point(83, 38);
            this.ErrorLabel.Name = "ErrorLabel";
            this.ErrorLabel.Size = new System.Drawing.Size(54, 16);
            this.ErrorLabel.TabIndex = 5;
            this.ErrorLabel.Visible = false;
            // 
            // EnterKeyForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(510, 97);
            this.Controls.Add(this.ErrorLabel);
            this.Controls.Add(this.PurchaseButton);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.LicenseTextBox);
            this.Controls.Add(this.ValidateButton);
            this.Controls.Add(this.CloseButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "EnterKeyForm";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Enter License Key";
            this.Load += new System.EventHandler(this.EnterKeyForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button CloseButton;
        private System.Windows.Forms.Button ValidateButton;
        private System.Windows.Forms.TextBox LicenseTextBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button PurchaseButton;
        private ImageLabel ErrorLabel;
    }
}