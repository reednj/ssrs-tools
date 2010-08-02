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
            this.ServerNameText = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.AuthTypeCombo = new System.Windows.Forms.ComboBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.ConnectButton = new System.Windows.Forms.Button();
            this.CloseButton = new System.Windows.Forms.Button();
            this.FormPanel = new System.Windows.Forms.Panel();
            this.SqlServerAuthPanel = new System.Windows.Forms.Panel();
            this.label5 = new System.Windows.Forms.Label();
            this.ErrorLabel = new System.Windows.Forms.Label();
            this.FormPanel.SuspendLayout();
            this.SqlServerAuthPanel.SuspendLayout();
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
            "SQL Server Authentication"});
            this.AuthTypeCombo.Location = new System.Drawing.Point(115, 29);
            this.AuthTypeCombo.Name = "AuthTypeCombo";
            this.AuthTypeCombo.Size = new System.Drawing.Size(245, 21);
            this.AuthTypeCombo.TabIndex = 2;
            this.AuthTypeCombo.SelectedIndexChanged += new System.EventHandler(this.AuthTypeCombo_SelectedIndexChanged);
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(127, 6);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(221, 20);
            this.textBox2.TabIndex = 3;
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
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(127, 28);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(221, 20);
            this.textBox3.TabIndex = 6;
            // 
            // ConnectButton
            // 
            this.ConnectButton.Location = new System.Drawing.Point(219, 241);
            this.ConnectButton.Name = "ConnectButton";
            this.ConnectButton.Size = new System.Drawing.Size(78, 23);
            this.ConnectButton.TabIndex = 8;
            this.ConnectButton.Text = "Connect";
            this.ConnectButton.UseVisualStyleBackColor = true;
            this.ConnectButton.Click += new System.EventHandler(this.ConnectButton_Click);
            // 
            // CloseButton
            // 
            this.CloseButton.Location = new System.Drawing.Point(303, 241);
            this.CloseButton.Name = "CloseButton";
            this.CloseButton.Size = new System.Drawing.Size(78, 23);
            this.CloseButton.TabIndex = 9;
            this.CloseButton.Text = "Cancel";
            this.CloseButton.UseVisualStyleBackColor = true;
            this.CloseButton.Click += new System.EventHandler(this.CancelButton_Click);
            // 
            // FormPanel
            // 
            this.FormPanel.Controls.Add(this.SqlServerAuthPanel);
            this.FormPanel.Controls.Add(this.label2);
            this.FormPanel.Controls.Add(this.AuthTypeCombo);
            this.FormPanel.Controls.Add(this.label1);
            this.FormPanel.Controls.Add(this.ServerNameText);
            this.FormPanel.Location = new System.Drawing.Point(12, 27);
            this.FormPanel.Name = "FormPanel";
            this.FormPanel.Size = new System.Drawing.Size(369, 152);
            this.FormPanel.TabIndex = 10;
            // 
            // SqlServerAuthPanel
            // 
            this.SqlServerAuthPanel.Controls.Add(this.label4);
            this.SqlServerAuthPanel.Controls.Add(this.textBox3);
            this.SqlServerAuthPanel.Controls.Add(this.label3);
            this.SqlServerAuthPanel.Controls.Add(this.textBox2);
            this.SqlServerAuthPanel.Enabled = false;
            this.SqlServerAuthPanel.Location = new System.Drawing.Point(0, 56);
            this.SqlServerAuthPanel.Name = "SqlServerAuthPanel";
            this.SqlServerAuthPanel.Size = new System.Drawing.Size(369, 61);
            this.SqlServerAuthPanel.TabIndex = 8;
            // 
            // label5
            // 
            this.label5.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label5.Location = new System.Drawing.Point(0, 228);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(394, 2);
            this.label5.TabIndex = 11;
            // 
            // ErrorLabel
            // 
            this.ErrorLabel.AutoSize = true;
            this.ErrorLabel.Location = new System.Drawing.Point(12, 205);
            this.ErrorLabel.Name = "ErrorLabel";
            this.ErrorLabel.Size = new System.Drawing.Size(169, 13);
            this.ErrorLabel.TabIndex = 12;
            this.ErrorLabel.Text = "Error! Could not connect to server!";
            this.ErrorLabel.Visible = false;
            // 
            // LoginForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(393, 276);
            this.Controls.Add(this.ErrorLabel);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.FormPanel);
            this.Controls.Add(this.CloseButton);
            this.Controls.Add(this.ConnectButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "LoginForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Connect to Server";
            this.Load += new System.EventHandler(this.Login_Load);
            this.FormPanel.ResumeLayout(false);
            this.FormPanel.PerformLayout();
            this.SqlServerAuthPanel.ResumeLayout(false);
            this.SqlServerAuthPanel.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox ServerNameText;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox AuthTypeCombo;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.Button ConnectButton;
        private System.Windows.Forms.Button CloseButton;
        private System.Windows.Forms.Panel FormPanel;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Panel SqlServerAuthPanel;
        private System.Windows.Forms.Label ErrorLabel;
    }
}