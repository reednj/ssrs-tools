using System;
using System.Collections.Generic;
using System.Text;

using RenderReport.ReportService;
using System.Threading;
using System.IO;

namespace RenderReport
{
    // wrapper for the reporting services render method. Its a complicated method, so
    // better to make a wrapper.
    public class ReportRenderer
    {
        ReportingService rs;
        string renderFormat = "PDF";

        public delegate void RenderAsyncCompleteHandler(object sender, EventArgs e);
        public event RenderAsyncCompleteHandler RenderAsyncComplete;

        public ReportRenderer(ReportingService newRs) 
        {
            this.rs = newRs;
        }

        public void renderAsync(string reportPath, string filePath)
        {
            ThreadPool.QueueUserWorkItem(renderAsyncCallBack, new RendererThreadArgs(reportPath, filePath));
        }

        private void renderAsyncCallBack(object reportArgsObj)
        {
            RendererThreadArgs reportArgs = reportArgsObj as RendererThreadArgs;
            renderToFile(reportArgs.reportPath, reportArgs.filePath);

            // raise the render complete event...
            RenderAsyncComplete(this, null);
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

            Byte[] data = rs.Render(reportPath, renderFormat, null, null, null, null, null, out encoding, out mimeType, out reportHistoryParameters, out warnings, out streamIDs);

            return data;
        }

        public void renderToFile(string reportPath, string filePath)
        {
            Byte[] data = render(reportPath);
            saveBytes(filePath, data);
        }

        private static void saveBytes(string filePath, Byte[] data)
        {
            FileStream fp = new FileStream(filePath, FileMode.Create, FileAccess.Write);
            BinaryWriter bw = new BinaryWriter(fp);

            bw.Write(data);

            bw.Close();
            fp.Close();
        }
    }

    public class RendererThreadArgs {
        public string reportPath;
        public string filePath;

        public RendererThreadArgs(string newReportPath, string newFilePath)
        {
            reportPath = newReportPath;
            filePath = newFilePath;
        }
    }
}
