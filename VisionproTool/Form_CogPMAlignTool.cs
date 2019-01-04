using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Cognex.VisionPro;
using Cognex.VisionPro.PMAlign;

namespace VisionproTool
{
    public partial class Form_CogPMAlignTool : Form
    {
        public Form_CogPMAlignTool()
        {
            InitializeComponent();
        }

        public  CogPMAlignTool formtool=null;

        private void Form_CogPMAlignTool_Load(object sender, EventArgs e)
        {
            this.cogPMAlignEditV21.Subject = this.formtool;
            base.WindowState = FormWindowState.Maximized;
            this.cogPMAlignEditV21.Size = this.ClientSize;
            this.cogPMAlignEditV21.Location = new Point(0, 0);
        }

        public CogPMAlignTool Subject
        {
            get
            {
                return this.formtool;
            }
            set
            {
                this.formtool = value;
                this.cogPMAlignEditV21.Subject = this.formtool;
            }

        }

        private void Form_CogPMAlignTool_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.cogPMAlignEditV21.Subject = null;
        }


    }
}
