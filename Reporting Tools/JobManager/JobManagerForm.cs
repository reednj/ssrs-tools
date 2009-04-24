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

        ReportingService rs = new ReportingService();

        public JobManagerForm()
        {
            InitializeComponent();

        }

        private void Form1_Load(object sender, EventArgs e)
        {

            rs.Credentials = System.Net.CredentialCache.DefaultCredentials;
            rs.ListJobsCompleted += LoadJobsComplete;
            rs.CancelJobCompleted += CancelJobAsyncComplete;

            changeState(ServiceState.LoadingList);
            rs.ListJobsAsync();
        }
        
        private void LoadJobsComplete(object sender, ListJobsCompletedEventArgs e)
        {
            Job[] jobList = e.Result;

            jobListView.Items.Clear();

            foreach(Job curJob in jobList) {
                AddJob(curJob);
            }

            changeState(ServiceState.Connected);
        }

        private void AddJob(Job reportJob)
        {
            List<string> columns = new List<string>();
            TimeSpan jobDuation = (DateTime.Now - reportJob.StartDateTime);

            columns.Add(reportJob.Type.ToString());
            columns.Add(reportJob.Path);
            columns.Add(reportJob.User);
            columns.Add(jobDuation.ToString());

            ListViewItem newRow = new ListViewItem(columns.ToArray());
            newRow.Tag = reportJob;

            jobListView.Items.Add(newRow);
        }

        private void refreshButton_Click(object sender, EventArgs e)
        {
            changeState(ServiceState.LoadingList);
            rs.ListJobsAsync();
        }

        private void CancelJobAsyncComplete(object sender, CancelJobCompletedEventArgs e)
        {
            changeState(ServiceState.Connected);
        }

        private void killJobButton_Click(object sender, EventArgs e)
        {
            if(jobListView.SelectedItems.Count > 0) {
                Job selectedJob = jobListView.SelectedItems[0].Tag as Job;
                
                if(selectedJob != null) {
                    // kill the job
                    changeState(ServiceState.LoadingList);
                    rs.CancelJobAsync(selectedJob.JobID);
                }
            }
        }

        private void changeState(ServiceState newState)
        {
            if(newState == ServiceState.Connected) {
                mainStatusLabel.Text = "Connected";
                lockControls(true);
            } else if(newState == ServiceState.LoadingList) {
                mainStatusLabel.Text = "Loading Jobs...";
                lockControls(false);
            } else if(newState == ServiceState.Error) {
                mainStatusLabel.Text = "Error: Could not load Job List...";
            }
        }

        private void lockControls(bool unlock)
        {
            killJobButton.Enabled = unlock;
            refreshButton.Enabled = unlock;
        }


    }
   
}