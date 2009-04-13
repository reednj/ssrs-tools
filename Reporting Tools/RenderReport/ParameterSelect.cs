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
    public partial class ParameterSelectForm : Form
    {
        ReportParameter[] reportParams = null;

        public ParameterSelectForm()
        {
            InitializeComponent();
        }

        public ParameterSelectForm(ReportParameter[] newReportParams)
        {
            this.reportParams = newReportParams;

            InitializeComponent();
        }

        private void ParameterSelectForm_Load(object sender, EventArgs e)
        {

            // fill the data grid with the sent parameters
            if(reportParams != null) {
                foreach(ReportParameter curParam in reportParams) {
                    
                    // if the promp varible is null then parameter is probably hidden
                    if(curParam.Prompt.Length > 0) {
                        string currentValue = (curParam.DefaultValues != null)? curParam.DefaultValues[0]:"";
                        paramGridView.Rows.Add(curParam.Prompt, currentValue);
                    }
                }
            }
        }
    }
}