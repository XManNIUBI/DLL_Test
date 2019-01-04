using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Cognex.VisionPro.ImageFile;

namespace VisionproTool
{
    public partial class Form_CogImageFileTool : Form
    {
        public Form_CogImageFileTool()
        {
            InitializeComponent();
        }

        public CogImageFileTool formtool = null;

        private void Form_CogImageFileTool_Load(object sender, EventArgs e)
        {
            this.cogImageFileEditV21.Subject = this.formtool;
            base.WindowState = FormWindowState.Maximized;
            this.cogImageFileEditV21.Size = this.ClientSize;
            this.cogImageFileEditV21.Location = new Point(0, 0);
        }

        public CogImageFileTool Subject
        {
            get
            {
                return this.formtool;
            }
            set
            {
                this.formtool = value;
                this.cogImageFileEditV21.Subject = this.formtool;
            }

        }

        private void Form_CogImageFileTool_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.cogImageFileEditV21.Subject = null;
        }

    }
}
