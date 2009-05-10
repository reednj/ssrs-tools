using System;
using System.Collections.Generic;
using System.Text;

using ReportingTools.Common.ReportService;
using System.Threading;
using System.IO;

namespace ReportingTools.RenderReport
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
            rs.RenderCompleted += renderComplete;
        }

        public void renderAsync(string reportPath, string filePath)
        {
            //ThreadPool.QueueUserWorkItem(renderAsyncCallBack, new RendererThreadArgs(reportPath, filePath));
            render(reportPath);            
        }

        //private void renderAsyncCallBack(object reportArgsObj)
        //{
        //    RendererThreadArgs reportArgs = reportArgsObj as RendererThreadArgs;
        //    renderToFile(reportArgs.reportPath, reportArgs.filePath);

        //    // raise the render complete event...
        //    RenderAsyncComplete(this, null);
        //}

        // renders the report, and returns a byte array of whatever was created

        //public void renderToFile(string reportPath, string filePath)
        //{
        //    Byte[] data = render(reportPath);
        //    saveBytes(filePath, data);
        //}

        public void render(string reportPath)
        {
            rs.RenderAsync(reportPath, renderFormat, null, null, null, null, null);
        }

        public void renderComplete(object sender, RenderCompletedEventArgs e)
        {
            Byte[] data = e.Result;

            saveBytes("C:\\test.pdf", data);

            RenderAsyncComplete(this, null);
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
