using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Cognex.VisionPro.ToolBlock;

namespace VisionproTool
{
    public partial class Form_CogToolBlock : Form
    {
        public Form_CogToolBlock()
        {
            InitializeComponent();
        }

        public CogToolBlock formtool = null;

        private void Form_CogToolBlock_Load(object sender, EventArgs e)
        {
            this.cogToolBlockEditV21.Subject = this.formtool;
            base.WindowState = FormWindowState.Maximized;
            this.cogToolBlockEditV21.Size = this.ClientSize;
            this.cogToolBlockEditV21.Location = new Point(0, 0);
        }

        public CogToolBlock Subject
        {
            get
            {
                return this.formtool;
            }
            set
            {
                this.formtool = value;
                this.cogToolBlockEditV21.Subject = this.formtool;
            }

        }

        private void Form_CogToolBlock_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.cogToolBlockEditV21.Subject = null;
        }





    }
}
