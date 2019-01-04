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
    public partial class Form_CogCaliperTool : Form
    {
        public Form_CogCaliperTool()
        {
            InitializeComponent();
        }

        public CogCaliperTool formtool = null;

        private void Form_CogCaliperTool_Load(object sender, EventArgs e)
        {
            this.cogCaliperEditV21.Subject = this.formtool;
            base.WindowState = FormWindowState.Maximized;
            this.cogCaliperEditV21.Size = this.ClientSize;
            this.cogCaliperEditV21.Location = new Point(0, 0);
        }

        public CogCaliperTool Subject
        {
            get
            {
                return this.formtool;
            }
            set
            {
                this.formtool = value;
                this.cogCaliperEditV21.Subject = this.formtool;
            }

        }

        private void Form_CogCaliperTool_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.cogCaliperEditV21.Subject = null;
        }


    }
}
