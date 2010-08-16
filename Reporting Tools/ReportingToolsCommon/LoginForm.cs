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

            InitializeLicense();
        }

        public LoginForm(bool WillAutoConnect)
        {
            InitializeComponent();

            AuthTypeCombo.SelectedIndex = 0;
            this.WillAutoConnect = WillAutoConnect;

            InitializeLicense();
        }

        private void InitializeLicense()
        {
            // check for a license
            if (LicenseKey.ValidateKey())
            {
                // the user has a valid license, so make sure we hide the license panel
                // then let them go about their business
                LicensePanel.Visible = false;
            }

            // no valid license? How many days remaining in the trial?
            int DaysLeft = LicenseTest.DaysLeft();
            DaysLeft = (DaysLeft < 0) ? 0 : DaysLeft;
            DaysLeftLabel.Text = DaysLeft.ToString();

            // less then zero days left?
            if (DaysLeft <= 0)
            {
                DaysLeftLabel.ForeColor = Color.Red;
                ConnectButton.Enabled = false;
                BuyNowButton.Font = new Font(BuyNowButton.Font, FontStyle.Bold);
            }
        }

        private void Login_Load(object sender, EventArgs e)
        {
            this.AcceptButton = this.ConnectButton;
            this.CancelButton = this.CloseButton;

            this.Activate();
            this.ActiveControl = this.ServerNameText;

            if (SharedSettings.Default.ServerName.Length > 0)
            {
                ServerNameText.Text = SharedSettings.Default.ServerName;
                ServerNameText.SelectionStart = ServerNameText.Text.Length;

            }

            AutoLoginCheck.Checked = SharedSettings.Default.AutoConnect;
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
            ErrorLabel.BringToFront();

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
            SharedSettings.Default.ServerName = this.ServerUrl.FullName;
            SharedSettings.Default.AutoConnect = AutoLoginCheck.Checked;
            SharedSettings.Default.Save();

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

            // lets check the ssrs version - at this stage we only support ssrs2005, so anything
            // else and we show an error message
            if (!rs.ServerInfoHeaderValue.ReportServerVersionNumber.Contains(" 9."))
            {
                throw new Exception("Reporting Services 2008 is not currently supported.");
            }
        }

        void ListJobs_Worker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Error != null)
            {
                LoadingImg.Visible = false;
                ConnectButton.Enabled = true;
                FormPanel.Enabled = true;
                ErrorLabel.Visible = true;
                ErrorLabel.LabelText = "Error: " + e.Error.ShortMessage();

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


        private void BuyNowButton_Click_1(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start(ReportingToolsConsts.BUY_URL);
        }

        private void EnterKeyButton_Click(object sender, EventArgs e)
        {
            EnterKeyForm ekf = new EnterKeyForm();

            if (ekf.ShowDialog(this) == DialogResult.OK)
            {
                // the license key is valid, so save it to the config file
                SharedSettings.Default.LicenseKey = ekf.LicenseKeyString;
                SharedSettings.Default.Save();

                LicensePanel.Visible = false;
                ConnectButton.Enabled = true;

            }
        }
    }
}