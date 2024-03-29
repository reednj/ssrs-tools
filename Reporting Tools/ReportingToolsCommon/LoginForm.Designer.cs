namespace ReportingTools.Common
{
    partial class LoginForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LoginForm));
            this.ServerNameText = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.AuthTypeCombo = new System.Windows.Forms.ComboBox();
            this.UsernameText = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.PasswordText = new System.Windows.Forms.TextBox();
            this.ConnectButton = new System.Windows.Forms.Button();
            this.CloseButton = new System.Windows.Forms.Button();
            this.FormPanel = new System.Windows.Forms.Panel();
            this.LicensePanel = new System.Windows.Forms.Panel();
            this.DayLeftTextLabel = new System.Windows.Forms.Label();
            this.BuyNowButton = new System.Windows.Forms.Button();
            this.EnterKeyButton = new System.Windows.Forms.Button();
            this.DaysLeftLabel = new System.Windows.Forms.Label();
            this.AutoLoginCheck = new System.Windows.Forms.CheckBox();
            this.SqlServerAuthPanel = new System.Windows.Forms.Panel();
            this.label5 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.LoadingImg = new System.Windows.Forms.PictureBox();
            this.ErrorLabel = new ReportingTools.Common.ImageLabel();
            this.FormPanel.SuspendLayout();
            this.LicensePanel.SuspendLayout();
            this.SqlServerAuthPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.LoadingImg)).BeginInit();
            this.SuspendLayout();
            // 
            // ServerNameText
            // 
            this.ServerNameText.Location = new System.Drawing.Point(115, 3);
            this.ServerNameText.Name = "ServerNameText";
            this.ServerNameText.Size = new System.Drawing.Size(245, 20);
            this.ServerNameText.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 6);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(70, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Server name:";
            // 
            // AuthTypeCombo
            // 
            this.AuthTypeCombo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.AuthTypeCombo.FormattingEnabled = true;
            this.AuthTypeCombo.Items.AddRange(new object[] {
            "Windows Authentication",
            "Basic Authentication"});
            this.AuthTypeCombo.Location = new System.Drawing.Point(115, 29);
            this.AuthTypeCombo.Name = "AuthTypeCombo";
            this.AuthTypeCombo.Size = new System.Drawing.Size(245, 21);
            this.AuthTypeCombo.TabIndex = 2;
            this.AuthTypeCombo.SelectedIndexChanged += new System.EventHandler(this.AuthTypeCombo_SelectedIndexChanged);
            // 
            // UsernameText
            // 
            this.UsernameText.Location = new System.Drawing.Point(127, 6);
            this.UsernameText.Name = "UsernameText";
            this.UsernameText.Size = new System.Drawing.Size(221, 20);
            this.UsernameText.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(7, 32);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(78, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Authentication:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(15, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(61, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "User name:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(15, 35);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(56, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "Password:";
            // 
            // PasswordText
            // 
            this.PasswordText.Location = new System.Drawing.Point(127, 28);
            this.PasswordText.Name = "PasswordText";
            this.PasswordText.Size = new System.Drawing.Size(221, 20);
            this.PasswordText.TabIndex = 6;
            this.PasswordText.UseSystemPasswordChar = true;
            // 
            // ConnectButton
            // 
            this.ConnectButton.Location = new System.Drawing.Point(219, 277);
            this.ConnectButton.Name = "ConnectButton";
            this.ConnectButton.Size = new System.Drawing.Size(78, 23);
            this.ConnectButton.TabIndex = 8;
            this.ConnectButton.Text = "Connect";
            this.ConnectButton.UseVisualStyleBackColor = true;
            this.ConnectButton.Click += new System.EventHandler(this.ConnectButton_Click);
            // 
            // CloseButton
            // 
            this.CloseButton.Location = new System.Drawing.Point(303, 277);
            this.CloseButton.Name = "CloseButton";
            this.CloseButton.Size = new System.Drawing.Size(78, 23);
            this.CloseButton.TabIndex = 9;
            this.CloseButton.Text = "Cancel";
            this.CloseButton.UseVisualStyleBackColor = true;
            this.CloseButton.Click += new System.EventHandler(this.CancelButton_Click);
            // 
            // FormPanel
            // 
            this.FormPanel.Controls.Add(this.LicensePanel);
            this.FormPanel.Controls.Add(this.AutoLoginCheck);
            this.FormPanel.Controls.Add(this.SqlServerAuthPanel);
            this.FormPanel.Controls.Add(this.label2);
            this.FormPanel.Controls.Add(this.AuthTypeCombo);
            this.FormPanel.Controls.Add(this.label1);
            this.FormPanel.Controls.Add(this.ServerNameText);
            this.FormPanel.Location = new System.Drawing.Point(12, 92);
            this.FormPanel.Name = "FormPanel";
            this.FormPanel.Size = new System.Drawing.Size(375, 169);
            this.FormPanel.TabIndex = 10;
            // 
            // LicensePanel
            // 
            this.LicensePanel.Controls.Add(this.DayLeftTextLabel);
            this.LicensePanel.Controls.Add(this.BuyNowButton);
            this.LicensePanel.Controls.Add(this.EnterKeyButton);
            this.LicensePanel.Controls.Add(this.DaysLeftLabel);
            this.LicensePanel.Location = new System.Drawing.Point(207, 110);
            this.LicensePanel.Name = "LicensePanel";
            this.LicensePanel.Size = new System.Drawing.Size(168, 59);
            this.LicensePanel.TabIndex = 20;
            // 
            // DayLeftTextLabel
            // 
            this.DayLeftTextLabel.AutoSize = true;
            this.DayLeftTextLabel.ForeColor = System.Drawing.Color.DimGray;
            this.DayLeftTextLabel.Location = new System.Drawing.Point(32, 36);
            this.DayLeftTextLabel.Name = "DayLeftTextLabel";
            this.DayLeftTextLabel.Size = new System.Drawing.Size(46, 13);
            this.DayLeftTextLabel.TabIndex = 19;
            this.DayLeftTextLabel.Text = "days left";
            // 
            // BuyNowButton
            // 
            this.BuyNowButton.Location = new System.Drawing.Point(84, 6);
            this.BuyNowButton.Name = "BuyNowButton";
            this.BuyNowButton.Size = new System.Drawing.Size(78, 23);
            this.BuyNowButton.TabIndex = 16;
            this.BuyNowButton.Text = "Buy Now...";
            this.BuyNowButton.UseVisualStyleBackColor = true;
            this.BuyNowButton.Click += new System.EventHandler(this.BuyNowButton_Click_1);
            // 
            // EnterKeyButton
            // 
            this.EnterKeyButton.Location = new System.Drawing.Point(84, 31);
            this.EnterKeyButton.Name = "EnterKeyButton";
            this.EnterKeyButton.Size = new System.Drawing.Size(78, 23);
            this.EnterKeyButton.TabIndex = 17;
            this.EnterKeyButton.Text = "Enter Key...";
            this.EnterKeyButton.UseVisualStyleBackColor = true;
            this.EnterKeyButton.Click += new System.EventHandler(this.EnterKeyButton_Click);
            // 
            // DaysLeftLabel
            // 
            this.DaysLeftLabel.AutoSize = true;
            this.DaysLeftLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DaysLeftLabel.Location = new System.Drawing.Point(3, 27);
            this.DaysLeftLabel.Name = "DaysLeftLabel";
            this.DaysLeftLabel.Size = new System.Drawing.Size(36, 26);
            this.DaysLeftLabel.TabIndex = 18;
            this.DaysLeftLabel.Text = "30";
            // 
            // AutoLoginCheck
            // 
            this.AutoLoginCheck.AutoSize = true;
            this.AutoLoginCheck.Location = new System.Drawing.Point(10, 145);
            this.AutoLoginCheck.Name = "AutoLoginCheck";
            this.AutoLoginCheck.Size = new System.Drawing.Size(175, 17);
            this.AutoLoginCheck.TabIndex = 9;
            this.AutoLoginCheck.Text = "Connect automatically next time";
            this.AutoLoginCheck.UseVisualStyleBackColor = true;
            // 
            // SqlServerAuthPanel
            // 
            this.SqlServerAuthPanel.Controls.Add(this.label4);
            this.SqlServerAuthPanel.Controls.Add(this.PasswordText);
            this.SqlServerAuthPanel.Controls.Add(this.label3);
            this.SqlServerAuthPanel.Controls.Add(this.UsernameText);
            this.SqlServerAuthPanel.Enabled = false;
            this.SqlServerAuthPanel.Location = new System.Drawing.Point(0, 56);
            this.SqlServerAuthPanel.Name = "SqlServerAuthPanel";
            this.SqlServerAuthPanel.Size = new System.Drawing.Size(369, 54);
            this.SqlServerAuthPanel.TabIndex = 8;
            // 
            // label5
            // 
            this.label5.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label5.Location = new System.Drawing.Point(0, 267);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(401, 2);
            this.label5.TabIndex = 11;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::ReportingTools.Common.Properties.Resources.login_banner;
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(400, 64);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox1.TabIndex = 15;
            this.pictureBox1.TabStop = false;
            // 
            // LoadingImg
            // 
            this.LoadingImg.Image = global::ReportingTools.Common.Properties.Resources.loader;
            this.LoadingImg.Location = new System.Drawing.Point(192, 277);
            this.LoadingImg.Name = "LoadingImg";
            this.LoadingImg.Size = new System.Drawing.Size(21, 23);
            this.LoadingImg.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.LoadingImg.TabIndex = 14;
            this.LoadingImg.TabStop = false;
            this.LoadingImg.Visible = false;
            // 
            // ErrorLabel
            // 
            this.ErrorLabel.AutoSize = true;
            this.ErrorLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ErrorLabel.Image = global::ReportingTools.Common.Properties.Resources.exclamation;
            this.ErrorLabel.LabelText = "Error Message";
            this.ErrorLabel.Location = new System.Drawing.Point(22, 70);
            this.ErrorLabel.Name = "ErrorLabel";
            this.ErrorLabel.Size = new System.Drawing.Size(108, 16);
            this.ErrorLabel.TabIndex = 13;
            this.ErrorLabel.Visible = false;
            // 
            // LoginForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(399, 312);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.LoadingImg);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.ErrorLabel);
            this.Controls.Add(this.FormPanel);
            this.Controls.Add(this.CloseButton);
            this.Controls.Add(this.ConnectButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "LoginForm";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Connect to Server";
            this.Load += new System.EventHandler(this.Login_Load);
            this.FormPanel.ResumeLayout(false);
            this.FormPanel.PerformLayout();
            this.LicensePanel.ResumeLayout(false);
            this.LicensePanel.PerformLayout();
            this.SqlServerAuthPanel.ResumeLayout(false);
            this.SqlServerAuthPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.LoadingImg)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox ServerNameText;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox AuthTypeCombo;
        private System.Windows.Forms.TextBox UsernameText;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox PasswordText;
        private System.Windows.Forms.Button ConnectButton;
        private System.Windows.Forms.Button CloseButton;
        private System.Windows.Forms.Panel FormPanel;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Panel SqlServerAuthPanel;
        private ImageLabel ErrorLabel;
        private System.Windows.Forms.PictureBox LoadingImg;
        private System.Windows.Forms.CheckBox AutoLoginCheck;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button BuyNowButton;
        private System.Windows.Forms.Button EnterKeyButton;
        private System.Windows.Forms.Label DaysLeftLabel;
        private System.Windows.Forms.Label DayLeftTextLabel;
        private System.Windows.Forms.Panel LicensePanel;
    }
}