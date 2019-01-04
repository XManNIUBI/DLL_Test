using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Cognex.VisionPro.CalibFix;

namespace VisionproTool
{
    public partial class Form_CogCalibNPointToNPointTool : Form
    {
        public Form_CogCalibNPointToNPointTool()
        {
            InitializeComponent();
        }

        public  CogCalibNPointToNPointTool formtool = null;

        private void Form_CogCalibNPointToNPointTool_Load(object sender, EventArgs e)
        {
            this.cogCalibNPointToNPointEditV21.Subject = this.formtool;
            base.WindowState = FormWindowState.Maximized;
            this.cogCalibNPointToNPointEditV21.Size = this.ClientSize;
            this.cogCalibNPointToNPointEditV21.Location = new Point(0, 0);
        }

        public CogCalibNPointToNPointTool Subject
        {
            get
            {
                return this.formtool;
            }
            set
            {
                this.formtool = value;
                this.cogCalibNPointToNPointEditV21.Subject = this.formtool;
            }

        }

        private void cogCalibNPointToNPointEditV21_Load(object sender, EventArgs e)
        {
            this.cogCalibNPointToNPointEditV21.Subject = null;
        }

    }
}
