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
    public partial class Form_CogCalibCheckerboardTool : Form
    {
        public Form_CogCalibCheckerboardTool()
        {
            InitializeComponent();
        }

        public  CogCalibCheckerboardTool formtool = null;

        private void Form_CogCalibCheckerboardTool_Load(object sender, EventArgs e)
        {
            this.cogCalibCheckerboardEditV21.Subject = this.formtool;
            base.WindowState = FormWindowState.Maximized;
            this.cogCalibCheckerboardEditV21.Size = this.ClientSize;
            this.cogCalibCheckerboardEditV21.Location = new Point(0, 0);
        }

        public CogCalibCheckerboardTool Subject
        {
            get
            {
                return this.formtool;
            }
            set
            {
                this.formtool = value;
                this.cogCalibCheckerboardEditV21.Subject = this.formtool;
            }

        }

        private void Form_CogCalibCheckerboardTool_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.cogCalibCheckerboardEditV21.Subject = null;
        }

    }
}
