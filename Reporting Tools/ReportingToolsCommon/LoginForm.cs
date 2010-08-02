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
        public SSRSUri ServerUrl = null;
        ReportingService rs = new ReportingService();

        public LoginForm()
        {
            InitializeComponent();
            AuthTypeCombo.SelectedIndex = 0;
        }

        private void Login_Load(object sender, EventArgs e)
        {
            this.Activate();
            this.ActiveControl = this.ServerNameText;
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
            rs.Url = this.ServerUrl.ToString();
        
            BackgroundWorker ListJobs_Worker = new BackgroundWorker();
            ListJobs_Worker.DoWork += new DoWorkEventHandler(ListJobs_Worker_DoWork);
            ListJobs_Worker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(ListJobs_Worker_RunWorkerCompleted);

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
                ConnectButton.Enabled = true;
                FormPanel.Enabled = true;
                ErrorLabel.Visible = true;
                ErrorLabel.Text = "Error: " + e.Error.Message;
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

    // sets a url specifically for reporting services
    public class SSRSUri
    {
        private string _serverName = null;
        private string _instanceName = null;

        public string ServerName{get { return _serverName; } set { _serverName = value; }}
        public string InstanceName {get { return _instanceName; } set { _instanceName = value; }}
        public string WebServiceUrl { get { return this.ToString(); }  }

        public SSRSUri()
        {
        }

        public SSRSUri(string ServerName)
        {
            this.ServerName = ServerName;
        }

        public SSRSUri(string ServerName, string InstanceName)
        {
            this.ServerName = ServerName;
            this.InstanceName = InstanceName;
        }
        
        // takes a string containing the servername and the instance name
        public static SSRSUri ParseString(string ServerString)
        {
            // we need to split this along the '\' character to get the instance
            string[] ServerDetails = ServerString.Split(new char[] { '/', '\\' }, 2);
            if (ServerDetails.Length > 1)
            {
                return new SSRSUri(ServerDetails[0], ServerDetails[1]);
            }
            else
            {
                return new SSRSUri(ServerDetails[0]);
            }
        }

        public override string ToString()
        {
            if (this.ServerName == null)
            {
                throw new InvalidOperationException("You must set a ServerName to generate a url");
            }

            if (this.InstanceName == null)
            {
                return String.Format("http://{0}/reportserver/reportservice.asmx", this.ServerName);
            }
            else
            {
                return String.Format("http://{0}/reportserver${1}/reportservice.asmx", this.ServerName, this.InstanceName);
            }
        } 
    }
}