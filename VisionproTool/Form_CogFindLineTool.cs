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
    public partial class Form_CogFindLineTool : Form
    {
        public Form_CogFindLineTool()
        {
            InitializeComponent();
        }

        public CogFindLineTool formtool = null;

        private void Form_CogFindLineTool_Load(object sender, EventArgs e)
        {
            this.cogFindLineEditV21.Subject = this.formtool;
            base.WindowState = FormWindowState.Maximized;
            this.cogFindLineEditV21.Size = this.ClientSize;
            this.cogFindLineEditV21.Location = new Point(0, 0);
        }

        public CogFindLineTool Subject
        {
            get
            {
                return this.formtool;
            }
            set
            {
                this.formtool = value;
                this.cogFindLineEditV21.Subject = this.formtool;
            }

        }

        private void Form_CogFindLineTool_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.cogFindLineEditV21.Subject = null;
        }


    }
}
