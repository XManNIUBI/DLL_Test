using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Cognex.VisionPro.ToolGroup;

namespace VisionproTool
{
    public partial class Form_CogToolGroup : Form
    {
        public Form_CogToolGroup()
        {
            InitializeComponent();
        }
        public  CogToolGroup formtool = null;

        private void Form_CogToolGroup_Load(object sender, EventArgs e)
        {
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form_CogToolGroup_FormClosing);
            this.cogToolGroupEditV21.Subject = this.formtool;
            base.WindowState = FormWindowState.Maximized;
            this.cogToolGroupEditV21.Size = this.ClientSize;
            this.cogToolGroupEditV21.Location = new Point(0, 0);
        }

        private void Form_CogToolGroup_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.cogToolGroupEditV21.Subject = null;
        }

        public CogToolGroup Subject
        {
            get
            {
                return this.formtool;
            }
            set
            {
                this.formtool = value;
                this.cogToolGroupEditV21.Subject = this.formtool;
            }

        }


    }
}
