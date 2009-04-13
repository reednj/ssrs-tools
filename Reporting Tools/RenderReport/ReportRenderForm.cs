using System;
using System.IO;

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
                string reportPath = reportItem.Path;
                string filePath = String.Format("C:\\{0}.pdf", reportItem.Name);

                ReportRenderer renderer = new ReportRenderer(rs);
                Byte[] data = renderer.render(reportPath);
                renderer.saveBytes(filePath, data);
            }

        }
    }

    // wrapper for the reporting services render method. Its a complicated method, so
    // better to make a wrapper.
    public class ReportRenderer
    {
        ReportingService rs;

        public ReportRenderer(ReportingService newRs) 
        {
            this.rs = newRs;
        }

        // renders the report, and returns a byte array of whatever was created
        public Byte[] render(string reportPath)
        {
            // we don't really care about these, but the render method needs them as 'out' params
            string encoding;
            string mimeType;
            ParameterValue[] reportHistoryParameters = null;
            Warning[] warnings = null;
            string[] streamIDs = null;

            Byte[] data = rs.Render(reportPath, "PDF", null, null, null, null, null, out encoding, out mimeType, out reportHistoryParameters, out warnings, out streamIDs);

            return data;
        }

        public void saveBytes(string filePath, Byte[] data)
        {
            FileStream fp = new FileStream(filePath, FileMode.Create, FileAccess.Write);
            BinaryWriter bw = new BinaryWriter(fp);

            bw.Write(data);

            bw.Close();
            fp.Close();
        }
    }
}