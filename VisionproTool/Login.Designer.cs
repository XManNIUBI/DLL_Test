namespace VisionproTool
{
    partial class Login
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btn_ok = new System.Windows.Forms.Button();
            this.btn_cancle = new System.Windows.Forms.Button();
            this.lb_account = new System.Windows.Forms.Label();
            this.lb_password = new System.Windows.Forms.Label();
            this.tb_account = new System.Windows.Forms.TextBox();
            this.tb_password = new System.Windows.Forms.TextBox();
            this.btn_operator_authority = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btn_ok
            // 
            this.btn_ok.Location = new System.Drawing.Point(72, 180);
            this.btn_ok.Name = "btn_ok";
            this.btn_ok.Size = new System.Drawing.Size(85, 37);
            this.btn_ok.TabIndex = 0;
            this.btn_ok.Text = "确定";
            this.btn_ok.UseVisualStyleBackColor = true;
            this.btn_ok.Click += new System.EventHandler(this.btn_ok_Click);
            // 
            // btn_cancle
            // 
            this.btn_cancle.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btn_cancle.Location = new System.Drawing.Point(217, 180);
            this.btn_cancle.Name = "btn_cancle";
            this.btn_cancle.Size = new System.Drawing.Size(85, 37);
            this.btn_cancle.TabIndex = 1;
            this.btn_cancle.Text = "取消";
            this.btn_cancle.UseVisualStyleBackColor = true;
            this.btn_cancle.Click += new System.EventHandler(this.btn_cancle_Click);
            // 
            // lb_account
            // 
            this.lb_account.AutoSize = true;
            this.lb_account.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lb_account.Location = new System.Drawing.Point(46, 52);
            this.lb_account.Name = "lb_account";
            this.lb_account.Size = new System.Drawing.Size(85, 19);
            this.lb_account.TabIndex = 2;
            this.lb_account.Text = "用户名：";
            // 
            // lb_password
            // 
            this.lb_password.AutoSize = true;
            this.lb_password.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lb_password.Location = new System.Drawing.Point(65, 94);
            this.lb_password.Name = "lb_password";
            this.lb_password.Size = new System.Drawing.Size(66, 19);
            this.lb_password.TabIndex = 3;
            this.lb_password.Text = "密码：";
            // 
            // tb_account
            // 
            this.tb_account.Location = new System.Drawing.Point(137, 50);
            this.tb_account.Name = "tb_account";
            this.tb_account.Size = new System.Drawing.Size(157, 21);
            this.tb_account.TabIndex = 4;
            // 
            // tb_password
            // 
            this.tb_password.Location = new System.Drawing.Point(137, 94);
            this.tb_password.Name = "tb_password";
            this.tb_password.PasswordChar = '*';
            this.tb_password.Size = new System.Drawing.Size(157, 21);
            this.tb_password.TabIndex = 5;
            this.tb_password.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tb_password_KeyDown);
            // 
            // btn_operator_authority
            // 
            this.btn_operator_authority.Location = new System.Drawing.Point(287, 261);
            this.btn_operator_authority.Name = "btn_operator_authority";
            this.btn_operator_authority.Size = new System.Drawing.Size(85, 37);
            this.btn_operator_authority.TabIndex = 6;
            this.btn_operator_authority.Text = "操作员模式";
            this.btn_operator_authority.UseVisualStyleBackColor = true;
            this.btn_operator_authority.Click += new System.EventHandler(this.btn_operator_authority_Click);
            // 
            // Login
            // 
            this.AcceptButton = this.btn_ok;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btn_cancle;
            this.ClientSize = new System.Drawing.Size(374, 301);
            this.Controls.Add(this.btn_operator_authority);
            this.Controls.Add(this.tb_password);
            this.Controls.Add(this.tb_account);
            this.Controls.Add(this.lb_password);
            this.Controls.Add(this.lb_account);
            this.Controls.Add(this.btn_cancle);
            this.Controls.Add(this.btn_ok);
            this.Name = "Login";
            this.Text = "Login";
            this.Load += new System.EventHandler(this.Login_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_ok;
        private System.Windows.Forms.Button btn_cancle;
        private System.Windows.Forms.Label lb_account;
        private System.Windows.Forms.Label lb_password;
        private System.Windows.Forms.TextBox tb_account;
        private System.Windows.Forms.TextBox tb_password;
        private System.Windows.Forms.Button btn_operator_authority;
    }
}