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

                if(curItem.Type == ItemTypeEnum.Report) {
                    mainReportTree.AddReport(curItem);
                }
            }
                        
            mainReportTree.ExpandAll();

            
        }

        private void StartRenderButton_Click(object sender, EventArgs e)
        {
            CatalogItem reportItem = mainReportTree.SelectedNode.Tag as CatalogItem;

            if(reportItem != null) {
                string baseFilePath = targetDirLink.Tag as string;
                string reportPath = reportItem.Path;
                string filePath = String.Format("{0}\\{1}.pdf", baseFilePath, reportItem.Name);

                renderProgressBar.Visible = true;

                ReportRenderer renderer = new ReportRenderer(rs);
                renderer.RenderAsyncComplete += renderer_RenderAsyncComplete;
                renderer.renderAsync(reportPath, filePath);
            }
        }

        private void renderer_RenderAsyncComplete(object sender, EventArgs e)
        {
            renderProgressBar.Visible = false;
        }

        private void GetParmsButton_Click(object sender, EventArgs e)
        {
            CatalogItem reportItem = mainReportTree.SelectedNode.Tag as CatalogItem;

            if(reportItem != null) {
                string reportPath = reportItem.Path;
                
                ReportParameter[] reportParams = rs.GetReportParameters(reportPath, null, true, null, null);

                ParameterSelectForm paramSelect = new ParameterSelectForm(reportParams);
                paramSelect.Show(this);
            
            }
        }

        private void targetDirLink_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            DialogResult selectResult = folderBrowser.ShowDialog();

            if(selectResult == DialogResult.OK) {
                // split the selected path into an array of folders...
                string[] folders = folderBrowser.SelectedPath.Split('\\');

                targetDirLink.Tag = folderBrowser.SelectedPath;
                targetDirLink.Text = folders[folders.Length-1];
            }
        }
    }


}