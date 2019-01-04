using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace VisionproTool
{
    /// <summary>
    /// 用于改变操作者权限的委托
    /// </summary>
    /// <param name="i">权限等级，0最低</param>
    public delegate void Change_access_class(int i);

    /// <summary>
    /// 登录窗口
    /// </summary>
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void Login_Load(object sender, EventArgs e)
        {
            tb_account.Text = "eng";
        }

        /// <summary>
        /// 工程师用户名，权限等级为1
        /// </summary>
        public static string engieer = "eng";
        /// <summary>
        /// 管理员用户名，权限等级为2
        /// </summary>
        public static string admin = "admin";
        /// <summary>
        /// 工程师密码
        /// </summary>
        public static string engieer_password = "456";
        /// <summary>
        /// 管理员密码
        /// </summary>
        public static string admin_password = "123";
        /// <summary>
        /// 权限等级变量
        /// </summary>
        public static int access_class = 0;
        /// <summary>
        /// 权限更改事件
        /// </summary>
        public event  Change_access_class change_authority_event;

        /// <summary>
        /// 输入密码时，按enter键相当于按确定键，esc相当于取消
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tb_password_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode==Keys.Enter)
            {
                this.btn_ok_Click(sender, e);
            }
            if (e.KeyCode == Keys.Escape)
            {
                this.btn_cancle_Click(sender, e);
            }
        }

        /// <summary>
        /// 确定按钮事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_ok_Click(object sender, EventArgs e)
        {
            if ((tb_account.Text == engieer) & (tb_password.Text == engieer_password))
            {
                access_class = 1;
                change_authority_event(access_class);
                this.Close();
            }
            else if ((tb_account.Text == admin) & (tb_password.Text == admin_password))
            {
                access_class = 2;
                change_authority_event(access_class);
                this.Close();
            }
            else
            {
                MessageBox.Show("帐号或密码错误","提示");
            }
            

        }

        /// <summary>
        /// 取消按钮事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_cancle_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// 操作员模式
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_operator_authority_Click(object sender, EventArgs e)
        {
            access_class = 0;
            change_authority_event(access_class);
            this.Close();
        }

        


    }
}
