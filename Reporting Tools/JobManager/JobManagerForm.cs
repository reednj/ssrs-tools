using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

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

            Job[] jobList = rs.ListJobs();

            foreach(Job curJob in jobList) {
                AddJob(curJob);
            }

        }

        private void AddJob(Job reportJob)
        {
            List<string> columns = new List<string>();

            columns.Add(reportJob.Type.ToString());
            columns.Add(reportJob.Path);
            columns.Add(reportJob.User);
            columns.Add(reportJob.StartDateTime.ToString());

            jobListView.Items.Add(new ListViewItem(columns.ToArray()));
        }
    }
}