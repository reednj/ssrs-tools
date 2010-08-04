using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace ReportingTools.Common
{
    public partial class ImageLabel : UserControl
    {
        public Image Image 
        {
            get { return MainPicture.Image; }
            set { MainPicture.Image = value; } 
        }

        public string LabelText
        {
            get { return MainLabel.Text; }
            set { MainLabel.Text = value; } 
        }

        public ImageLabel()
        {
            InitializeComponent();
        }

        private void ImageLabel_Load(object sender, EventArgs e)
        {
            this.Height = MainPicture.Height;
            this.Width = MainLabel.Right;
            MainLabel.Left = MainPicture.Width + 1;

            MainLabel.Top = this.Height / 2 - MainLabel.Height / 2;
        }

        private void ImageLabel_SizeChanged(object sender, EventArgs e)
        {
            this.Height = MainPicture.Height;
            this.Width = MainLabel.Right;

            MainLabel.Top = this.Height / 2 - MainLabel.Height / 2;
        }
    }
}
