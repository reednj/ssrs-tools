using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using ReportingTools.Common.ReportService;

namespace ReportingTools.RenderReport
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
                        //string currentValue = (curParam.ValidValues != null)? curParam.ValidValues[0].Label:"";
                        
                        DataGridViewRow newRow = new DataGridViewRow();
  
                        DataGridViewTextBoxCell nameCell = new DataGridViewTextBoxCell();
                        nameCell.Value = curParam.Name;
                        newRow.Cells.Add(nameCell);
                        
  
                        
                        if(curParam.Name != "AreaId") {
                            DataGridViewTextBoxCell valueCell = new DataGridViewTextBoxCell();
                            valueCell.Value = currentValue;

                            newRow.Cells.Add(valueCell);
                        } else {
                            DataGridViewComboBoxCell valueCell = new DataGridViewComboBoxCell();
                            foreach(ValidValue curValue in curParam.ValidValues) {
                                valueCell.Items.Add(curValue.Label);
                            }

                            newRow.Cells.Add(valueCell);                            
                        }
                        
                        paramGridView.Rows.Add(newRow);
                        
                    }
                }
            }
        }
    }
}