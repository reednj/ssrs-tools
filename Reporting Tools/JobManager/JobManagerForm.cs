using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using ReportingTools.Common;
using ReportingTools.Common.ReportService;

namespace ReportingTools.JobManager
{
    public partial class JobManagerForm : Form
    {

        bool hasStarted = false;

        int tickCount = 0;
        ReportingService2005 rs = new ReportingService2005();
        ServiceState CurrentState = ServiceState.Disconnected;
        SSRSUri ServerUrl = null;

        public JobManagerForm()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            rs.Credentials = System.Net.CredentialCache.DefaultCredentials;
            rs.ListJobsCompleted += LoadJobsComplete;
            rs.CancelJobCompleted += CancelJobAsyncComplete;
        }

        private void JobManagerForm_Activated(object sender, EventArgs e)
        {
            if (this.hasStarted == false)
            {
                this.hasStarted = true;
                this.RunConnectDialog(true);
            }
        }

        private void LoadJobsComplete(object sender, ListJobsCompletedEventArgs e)
        {
            Job[] jobList = e.Result;

            jobListView.Items.Clear();
            foreach (Job curJob in jobList)
            {
                AddJob(curJob);
            }
           
            changeState(ServiceState.Connected);
        }

        private void AddJob(Job reportJob)
        {
            List<string> columnData = new List<string>();
            TimeSpan jobDuation = (DateTime.Now - reportJob.StartDateTime);

            columnData.Add(reportJob.Type.ToString());
            columnData.Add(reportJob.Status.ToString());
            columnData.Add(reportJob.Path);
            columnData.Add(reportJob.User);
            columnData.Add(TimeSpanString(jobDuation));

            ListViewItem newRow = new ListViewItem(columnData.ToArray());
            newRow.Tag = reportJob;

            if (reportJob.Status == JobStatusEnum.CancelRequested)
            {
                newRow.BackColor = Color.Pink;
            }

            jobListView.Items.Add(newRow);
        }

        private void CancelJobAsyncComplete(object sender, CancelJobCompletedEventArgs e)
        {
            changeState(ServiceState.Connected);
        }

        private void changeState(ServiceState newState)
        {
            if(newState == ServiceState.Connected) {
                mainStatusLabel.Text = "Connected (Refreshes automatically every 5 seconds)";
                jobListView.Enabled = true;
                StopJobButton.Enabled = true;
            } else if(newState == ServiceState.LoadingList) {
                mainStatusLabel.Text = "Loading Jobs...";
                jobListView.Enabled = false;
                StopJobButton.Enabled = false;
            } else if(newState == ServiceState.Error) {
                mainStatusLabel.Text = "Error: Could not load Job List...";
            }

            this.CurrentState = newState;
        }

        private static string TimeSpanString(TimeSpan ts)
        {
            return String.Format("{0:D2}:{1:D2}:{2:D2}", ts.Hours, ts.Minutes, ts.Seconds);
        }

        private void RefreshTimer_Tick(object sender, EventArgs e)
        {
            if (this.CurrentState != ServiceState.Connected)
            {
                return;
            }

            if (this.tickCount % 5 == 0 && this.CurrentState == ServiceState.Connected)
            {
                // every one in 5 times actually refresh the page, the rest of the time
                // just refresh the timer.
                this.CurrentState = ServiceState.LoadingList;
                rs.ListJobsAsync();
            }

            this.UpdateRowDurations();
            this.tickCount++;
        }

        private void UpdateRowDurations()
        {
            foreach (ListViewItem lvi in jobListView.Items)
            {
                Job j = lvi.Tag as Job;
                if (j != null)
                {
                    lvi.SubItems[lvi.SubItems.Count - 1].Text = TimeSpanString(DateTime.Now - j.StartDateTime);
                }
            }
        }

        private void RunConnectDialog(bool AutoLogin)
        {
            LoginForm lf = new LoginForm(AutoLogin);
            if (lf.ShowDialog() == DialogResult.OK)
            {
                // disconnect. TODO: a general method to set the ui on a state change.
                this.CurrentState = ServiceState.Disconnected;

                // if the user click ok on the connection dialog box, set the rs url
                // and start getting the data. Otherwise to nothing...
                this.ServerUrl = lf.ServerUrl;
                rs.Url = this.ServerUrl.ToUrl();
                rs.Credentials = lf.RsCredentials;

                // start loading. I think this should really be done in the calling method?
                // have this function return a result instead of doing it all...
                changeState(ServiceState.LoadingList);
                RefreshTimer.Enabled = true;
                rs.ListJobsAsync();
            }
        }

        private void StopJobButton_Click(object sender, EventArgs e)
        {
            if (jobListView.SelectedItems.Count > 0)
            {
                Job selectedJob = jobListView.SelectedItems[0].Tag as Job;

                if (selectedJob != null)
                {
                    // kill the job
                    changeState(ServiceState.LoadingList);
                    rs.CancelJobAsync(selectedJob.JobID);
                }
            }
        }

        private void ConnectButton_Click(object sender, EventArgs e)
        {
            this.RunConnectDialog(false);
        }


    }

   
}