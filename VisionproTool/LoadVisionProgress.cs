using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;

namespace VisionproTool
{
    /// <summary>
    /// 控制进度条委托
    /// </summary>
    public delegate void ChangeProcessStatus();

    /// <summary>
    /// 进度条窗口类
    /// </summary>
    public partial class LoadVisionProgress : Form
    {
        public LoadVisionProgress()
        {
            InitializeComponent();
            
        }

        private  int progressbarvalue = 0;

        private void LoadVisionProgress_Load(object sender, EventArgs e)
        {

            Thread progressadd = new Thread(loadvppprocess);
            progressadd.IsBackground = true;
            progressadd.Start();

            //Thread threadupgradelabel = new Thread(upgradelabel);
            //threadupgradelabel.IsBackground = true;
            //threadupgradelabel.Start();

            Thread loadvppThread = new Thread(loadvpp);
            loadvppThread.IsBackground = true;
            loadvppThread.Start();

            this.progressBar1.Size = this.ClientSize;
        }

        void loadvppprocess()
        {
            if (this.progressBar1.InvokeRequired)
            {
                ChangeProcessStatus changestatus = new ChangeProcessStatus(loadvppprocess);
                this.BeginInvoke(changestatus);
            }
            else
            {
                for (progressbarvalue = 0; progressbarvalue < 100; progressbarvalue++)
                {

                    progressBar1.Value = progressbarvalue;
                    Thread.Sleep(10);
                }
            }
        }

        //无法显示进度条以外的控件，以后再研究
        //void upgradelabel()
        //{
        //    if (this.label1.InvokeRequired)
        //    {
        //        ChangeProcessStatus changestatus = new ChangeProcessStatus(upgradelabel);
        //        this.BeginInvoke(changestatus);
        //    }
        //    else
        //    {
        //        this.label1.Text = "正在载入视觉工具，当前进度：" + progressbarvalue + "%";
        //    }
        //}

        public void loadvpp()
        {
                VisionFunc vf = new VisionFunc();
                vf.LoadVisionFile();
                upgradeprogress();
                
        }

        void upgradeprogress()
        {
            if (this.progressBar1.InvokeRequired)
            {
                ChangeProcessStatus changestatus = new ChangeProcessStatus(upgradeprogress);
                this.BeginInvoke(changestatus);
            }
            else
            {
                progressBar1.Value = 100;
                this.Close();
            }
        }

    }
}
