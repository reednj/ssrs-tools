using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace ReportingTools.Common
{
    public partial class EnterKeyForm : Form
    {
        public string LicenseKeyString = "";

        public EnterKeyForm()
        {
            InitializeComponent();
        }

        private void EnterKeyForm_Load(object sender, EventArgs e)
        {
            this.ActiveControl = LicenseTextBox;
        }

        private void CloseButton_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void PurchaseButton_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start(ReportingToolsConsts.BUY_URL);
        }

        private void ValidateButton_Click(object sender, EventArgs e)
        {
            ErrorLabel.Visible = false;

            if (LicenseKey.ValidateKey(LicenseTextBox.Text) == true)
            {
                this.LicenseKeyString = LicenseTextBox.Text;
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                // not a valid license, show the error message
                ErrorLabel.LabelText = "Error: License Key Not Valid";
                ErrorLabel.Visible = true;
            }
        }

        private void LicenseTextBox_KeyUp(object sender, EventArgs e)
        {
            ErrorLabel.Visible = true;

            if (LicenseKey.ValidateKey(LicenseTextBox.Text) == true)
            {
                ErrorLabel.Image = Properties.Resources.ok_ico;
                ErrorLabel.LabelText = "Thanks! License Key Valid";
            }
            else
            {
                ErrorLabel.Image = Properties.Resources.exclamation;
                ErrorLabel.LabelText = "Invalid License Key";
            }
        }

    }
}
