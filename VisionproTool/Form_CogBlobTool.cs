using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Cognex.VisionPro.Blob;

namespace VisionproTool
{
    public partial class Form_CogBlobTool : Form
    {
        public Form_CogBlobTool()
        {
            InitializeComponent();
        }

        public CogBlobTool formtool = null;

        private void Form_CogBlobTool_Load(object sender, EventArgs e)
        {
            this.cogBlobEditV21.Subject = this.formtool;
            base.WindowState = FormWindowState.Maximized;
            this.cogBlobEditV21.Size = this.ClientSize;
            this.cogBlobEditV21.Location = new Point(0, 0);
        }

        public CogBlobTool Subject
        {
            get
            {
                return this.formtool;
            }
            set
            {
                this.formtool = value;
                this.cogBlobEditV21.Subject = this.formtool;
            }

        }

        private void Form_CogBlobTool_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.cogBlobEditV21.Subject = null;
        }

    }
}
