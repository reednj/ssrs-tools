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
        const int CMB_WINDOWS_AUTH = 0;
        const int CMB_BASIC_AUTH = 1;
        
        bool WillAutoConnect = false;
        ReportingService rs = new ReportingService();

        public SSRSUri ServerUrl = null;
        public System.Net.ICredentials RsCredentials { get { return rs.Credentials; } }

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
            try
            {
                this.ServerUrl = SSRSUri.ParseString(ServerNameText.Text);
                rs.Url = this.ServerUrl.ToUrl();
            }
            catch(Exception ex)
            {
                ErrorLabel.Visible = true;
                ErrorLabel.LabelText = "Error: " + ex.Message;
                return;
            }

            // what credentials to use?
            if (AuthTypeCombo.SelectedIndex == CMB_BASIC_AUTH)
            {
                string username = UsernameText.Text.Trim();
                string password = PasswordText.Text.Trim();
                rs.Credentials = new System.Net.NetworkCredential(username, password);
            }
            else
            {
                rs.Credentials = System.Net.CredentialCache.DefaultCredentials;
            }
            
            
            // save the settings for next time.
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
            UsernameText.Clear();
            PasswordText.Clear();
            SqlServerAuthPanel.Enabled = !(AuthTypeCombo.SelectedIndex == CMB_WINDOWS_AUTH);
        }


    }


}