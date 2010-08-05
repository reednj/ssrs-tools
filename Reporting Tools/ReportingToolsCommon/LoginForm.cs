using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using ReportingTools.Common.ReportService;


namespace ReportingTools.Common
{
    public partial class LoginForm : Form
    {
        bool WillAutoConnect = false;
        public SSRSUri ServerUrl = null;
        ReportingService rs = new ReportingService();

        public LoginForm()
        {
            InitializeComponent();
            AuthTypeCombo.SelectedIndex = 0;
        }

        public LoginForm(bool WillAutoConnect)
        {
            InitializeComponent();

            AuthTypeCombo.SelectedIndex = 0;
            this.WillAutoConnect = WillAutoConnect;
        }

        private void Login_Load(object sender, EventArgs e)
        {
            this.AcceptButton = this.ConnectButton;
            this.CancelButton = this.CloseButton;

            this.Activate();
            this.ActiveControl = this.ServerNameText;

            if (Properties.Settings.Default.ServerName.Length > 0)
            {
                ServerNameText.Text = Properties.Settings.Default.ServerName;
                ServerNameText.SelectionStart = ServerNameText.Text.Length;

            }

            AutoLoginCheck.Checked = Properties.Settings.Default.AutoConnect;
            UsernameText.Text = System.Security.Principal.WindowsIdentity.GetCurrent().Name;
            // should we connect automatically. Was this loaded at start up, or triggered by the user?
            if (this.WillAutoConnect == true && this.AutoLoginCheck.Checked == true)
            {
                // TODO: no magic push buttons please. 
                // this connection stuff should be moved out into its own method.
                ConnectButton.PerformClick();
            }
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            this.ServerUrl = null;
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void ConnectButton_Click(object sender, EventArgs e)
        {
            this.ServerUrl = SSRSUri.ParseString(ServerNameText.Text);

            rs.Credentials = System.Net.CredentialCache.DefaultCredentials;
            rs.Url = this.ServerUrl.ToUrl();

            Properties.Settings.Default.ServerName = this.ServerUrl.FullName;
            Properties.Settings.Default.AutoConnect = AutoLoginCheck.Checked;
            Properties.Settings.Default.Save();

            BackgroundWorker ListJobs_Worker = new BackgroundWorker();
            ListJobs_Worker.DoWork += new DoWorkEventHandler(ListJobs_Worker_DoWork);
            ListJobs_Worker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(ListJobs_Worker_RunWorkerCompleted);

            LoadingImg.Visible = true;
            ConnectButton.Enabled = false;
            FormPanel.Enabled = false;
            ListJobs_Worker.RunWorkerAsync();
        }
        
        void ListJobs_Worker_DoWork(object sender, DoWorkEventArgs e)
        {
            e.Result = rs.ListJobs();
        }

        void ListJobs_Worker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Error != null)
            {
                LoadingImg.Visible = false;
                ConnectButton.Enabled = true;
                FormPanel.Enabled = true;
                ErrorLabel.Visible = true;
                ErrorLabel.LabelText = "Error: " + e.Error.Message;
                return;
            }

            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void AuthTypeCombo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (AuthTypeCombo.SelectedIndex == 0)
            {
                SqlServerAuthPanel.Enabled = false;
            }
            else
            {
                SqlServerAuthPanel.Enabled = true;
            }
        }


    }


}