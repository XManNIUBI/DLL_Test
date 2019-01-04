using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Cognex.VisionPro;

namespace VisionproTool
{
    public partial class Form_CogAcqFifoTool1 : Form
    {
        public Form_CogAcqFifoTool1()
        {
            InitializeComponent();
        }

        public  CogAcqFifoTool formtool = null;

        private void Form_CogAcqFifoTool1_Load(object sender, EventArgs e)
        {
            this.cogAcqFifoEditV21.Subject = this.formtool;
            base.WindowState = FormWindowState.Maximized;
            this.cogAcqFifoEditV21.Size = this.ClientSize;
            this.cogAcqFifoEditV21.Location = new Point(0, 0);
        }

        public CogAcqFifoTool Subject
        {
            get
            {
                return this.formtool;
            }
            set
            {
                this.formtool = value;
                this.cogAcqFifoEditV21.Subject = this.formtool;
            }

        }

        private void Form_CogAcqFifoTool1_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.cogAcqFifoEditV21.Subject = null;
        }
        

    }
}
