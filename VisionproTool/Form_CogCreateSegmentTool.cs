using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Cognex.VisionPro.Caliper;
using Cognex.VisionPro.Dimensioning;

namespace VisionproTool
{
    public partial class Form_CogCreateSegmentTool : Form
    {
        public Form_CogCreateSegmentTool()
        {
            InitializeComponent();
        }


        public  CogCreateSegmentTool formtool = null;

        private void Form_CogCreateSegmentTool_Load(object sender, EventArgs e)
        {
            this.cogCreateSegmentEditV21.Subject = this.formtool;
            base.WindowState = FormWindowState.Maximized;
            this.cogCreateSegmentEditV21.Size = this.ClientSize;
            this.cogCreateSegmentEditV21.Location = new Point(0, 0);
        }

        public CogCreateSegmentTool Subject
        {
            get
            {
                return this.formtool;
            }
            set
            {
                this.formtool = value;
                this.cogCreateSegmentEditV21.Subject = this.formtool;
            }

        }

        private void Form_CogCreateSegmentTool_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.cogCreateSegmentEditV21.Subject = null;
        }

    }
}
