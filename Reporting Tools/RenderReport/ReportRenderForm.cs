using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using System.Web.Services.Protocols;
using ReportingTools.Common.ReportService;
using System.Xml;

namespace ReportingTools.RenderReport
{
    public partial class ReportRenderForm : Form
    {
        ReportingService2005 rs = new ReportingService2005();
        string DefaultRenderSavePath = Properties.Settings.Default.DefaultSavePath;

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

            // set the save directory. if we have %USERPROFILE% or something in the path, then expand it
            setSavePath(Environment.ExpandEnvironmentVariables(DefaultRenderSavePath));

            rs.RenderCompleted += renderer_RenderAsyncComplete;
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
                renderer.renderAsync(reportPath, filePath);
            }
        }

        private void renderer_RenderAsyncComplete(object sender, EventArgs e)
        {
            const string BAD_PARMS_ERROR = "rsReportParameterValueNotSet";

            // TODO: refactor all this code, move the xml parsing out into some other class..
            if(e.Error != null) {
                // could not render the report for some reason
                // probably there was a webservice exception
                SoapException ex = e.Error as SoapException;
                XmlNode xn = ex.Detail.SelectSingleNode("/*[local-name()='ErrorCode']");
                
                if(xn.InnerText == BAD_PARMS_ERROR) {
                    MessageBox.Show("This report cannot be executed! Not all the parameters are set!");
                }
            }

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
                setSavePath(folderBrowser.SelectedPath);
            }
        }

        private void setSavePath(string Path)
        {
            // split the selected path into an array of folders...
            string[] folders = Path.Split('\\');

            targetDirLink.Tag = Path;
            targetDirLink.Text = folders[folders.Length-1];

            // save the settings to disk
            Properties.Settings.Default.DefaultSavePath = Path;
            Properties.Settings.Default.Save();
        }
    }


}