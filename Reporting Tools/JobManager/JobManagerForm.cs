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

        }
    }
}