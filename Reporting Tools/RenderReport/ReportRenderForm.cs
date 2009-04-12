using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using RenderReport.ReportService;

namespace RenderReport
{
    public partial class ReportRenderForm : Form
    {
        ReportingService rs = new ReportingService();

        public ReportRenderForm()
        {
            InitializeComponent();
        }

        private void ReportRenderForm_Load(object sender, EventArgs e)
        {
            rs.Credentials = System.Net.CredentialCache.DefaultCredentials;

            CatalogItem[] serverItems =  rs.ListChildren("/", true);

            foreach(CatalogItem curItem in serverItems) {
                textBox1.Text += String.Format("[{0}] {1} \r\n", curItem.Type, curItem.Path);
            }

        }
    }

    public class ReportTree : TreeView 
    {
        public ReportTree() : base() 
        {
        }

    }
}