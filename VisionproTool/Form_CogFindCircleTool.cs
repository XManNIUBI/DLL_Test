using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Cognex.VisionPro.Caliper;

namespace VisionproTool
{
    public partial class Form_CogFindCircleTool : Form
    {
        public Form_CogFindCircleTool()
        {
            InitializeComponent();
        }

        public  CogFindCircleTool formtool = null;

        private void Form_CogFindCircleTool_Load(object sender, EventArgs e)
        {
            this.cogFindCircleEditV21.Subject = this.formtool;
            base.WindowState = FormWindowState.Maximized;
            this.cogFindCircleEditV21.Size = this.ClientSize;
            this.cogFindCircleEditV21.Location = new Point(0, 0);
        }

        public CogFindCircleTool Subject
        {
            get
            {
                return this.formtool;
            }
            set
            {
                this.formtool = value;
                this.cogFindCircleEditV21.Subject = this.formtool;
            }

        }

        private void Form_CogFindCircleTool_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.cogFindCircleEditV21.Subject = null;
        }

    }
}
