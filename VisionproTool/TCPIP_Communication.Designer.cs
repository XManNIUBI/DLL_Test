namespace VisionproTool
{
    partial class TCPIP_Communication
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
            this.debugtcp = new System.Windows.Forms.Button();
            this.Save_ClientServer_Par = new System.Windows.Forms.Button();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.ServerMode = new System.Windows.Forms.RadioButton();
            this.ClientMode = new System.Windows.Forms.RadioButton();
            this.bt_sendserver = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.txt_msgserver = new System.Windows.Forms.TextBox();
            this.btn_StopListen = new System.Windows.Forms.Button();
            this.bt_connnect = new System.Windows.Forms.Button();
            this.tb_port = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.tb_ip = new System.Windows.Forms.TextBox();
            this.bt_send = new System.Windows.Forms.Button();
            this.bt_clear = new System.Windows.Forms.Button();
            this.txt_msg = new System.Windows.Forms.TextBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.bt_disconnect = new System.Windows.Forms.Button();
            this.bt_connect = new System.Windows.Forms.Button();
            this.txt_port = new System.Windows.Forms.TextBox();
            this.lb_port = new System.Windows.Forms.Label();
            this.lb_ip = new System.Windows.Forms.Label();
            this.txt_ip = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // debugtcp
            // 
            this.debugtcp.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.debugtcp.Location = new System.Drawing.Point(256, 373);
            this.debugtcp.Name = "debugtcp";
            this.debugtcp.Size = new System.Drawing.Size(136, 28);
            this.debugtcp.TabIndex = 52;
            this.debugtcp.Text = "调试网络";
            this.debugtcp.UseVisualStyleBackColor = true;
            // 
            // Save_ClientServer_Par
            // 
            this.Save_ClientServer_Par.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.Save_ClientServer_Par.Location = new System.Drawing.Point(454, 373);
            this.Save_ClientServer_Par.Name = "Save_ClientServer_Par";
            this.Save_ClientServer_Par.Size = new System.Drawing.Size(98, 28);
            this.Save_ClientServer_Par.TabIndex = 51;
            this.Save_ClientServer_Par.Text = "保存";
            this.Save_ClientServer_Par.UseVisualStyleBackColor = true;
            // 
            // textBox2
            // 
            this.textBox2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.textBox2.Enabled = false;
            this.textBox2.Location = new System.Drawing.Point(330, 161);
            this.textBox2.Multiline = true;
            this.textBox2.Name = "textBox2";
            this.textBox2.ReadOnly = true;
            this.textBox2.Size = new System.Drawing.Size(165, 114);
            this.textBox2.TabIndex = 50;
            // 
            // ServerMode
            // 
            this.ServerMode.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.ServerMode.AutoSize = true;
            this.ServerMode.Checked = true;
            this.ServerMode.Location = new System.Drawing.Point(342, 47);
            this.ServerMode.Name = "ServerMode";
            this.ServerMode.Size = new System.Drawing.Size(83, 16);
            this.ServerMode.TabIndex = 49;
            this.ServerMode.TabStop = true;
            this.ServerMode.Text = "作为服务器";
            this.ServerMode.UseVisualStyleBackColor = true;
            // 
            // ClientMode
            // 
            this.ClientMode.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.ClientMode.AutoSize = true;
            this.ClientMode.Location = new System.Drawing.Point(110, 46);
            this.ClientMode.Name = "ClientMode";
            this.ClientMode.Size = new System.Drawing.Size(83, 16);
            this.ClientMode.TabIndex = 48;
            this.ClientMode.TabStop = true;
            this.ClientMode.Text = "作为客户端";
            this.ClientMode.UseVisualStyleBackColor = true;
            // 
            // bt_sendserver
            // 
            this.bt_sendserver.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.bt_sendserver.Location = new System.Drawing.Point(504, 303);
            this.bt_sendserver.Name = "bt_sendserver";
            this.bt_sendserver.Size = new System.Drawing.Size(82, 28);
            this.bt_sendserver.TabIndex = 47;
            this.bt_sendserver.Text = "发送";
            this.bt_sendserver.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.button1.Location = new System.Drawing.Point(516, 241);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(70, 30);
            this.button1.TabIndex = 46;
            this.button1.Text = "清除消息";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // txt_msgserver
            // 
            this.txt_msgserver.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txt_msgserver.Location = new System.Drawing.Point(322, 287);
            this.txt_msgserver.Multiline = true;
            this.txt_msgserver.Name = "txt_msgserver";
            this.txt_msgserver.Size = new System.Drawing.Size(176, 54);
            this.txt_msgserver.TabIndex = 45;
            // 
            // btn_StopListen
            // 
            this.btn_StopListen.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btn_StopListen.Location = new System.Drawing.Point(485, 131);
            this.btn_StopListen.Name = "btn_StopListen";
            this.btn_StopListen.Size = new System.Drawing.Size(85, 24);
            this.btn_StopListen.TabIndex = 44;
            this.btn_StopListen.Text = "停止监听";
            this.btn_StopListen.UseVisualStyleBackColor = true;
            // 
            // bt_connnect
            // 
            this.bt_connnect.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.bt_connnect.Location = new System.Drawing.Point(485, 85);
            this.bt_connnect.Name = "bt_connnect";
            this.bt_connnect.Size = new System.Drawing.Size(85, 25);
            this.bt_connnect.TabIndex = 43;
            this.bt_connnect.Text = "开始监听";
            this.bt_connnect.UseVisualStyleBackColor = true;
            // 
            // tb_port
            // 
            this.tb_port.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.tb_port.Location = new System.Drawing.Point(369, 129);
            this.tb_port.Name = "tb_port";
            this.tb_port.Size = new System.Drawing.Size(100, 21);
            this.tb_port.TabIndex = 42;
            this.tb_port.Text = "2001";
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(328, 129);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 12);
            this.label2.TabIndex = 41;
            this.label2.Text = "Port:";
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(340, 92);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(23, 12);
            this.label1.TabIndex = 40;
            this.label1.Text = "IP:";
            // 
            // tb_ip
            // 
            this.tb_ip.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.tb_ip.Location = new System.Drawing.Point(369, 89);
            this.tb_ip.Name = "tb_ip";
            this.tb_ip.Size = new System.Drawing.Size(100, 21);
            this.tb_ip.TabIndex = 39;
            this.tb_ip.Text = "127.0.0.1";
            // 
            // bt_send
            // 
            this.bt_send.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.bt_send.Enabled = false;
            this.bt_send.Location = new System.Drawing.Point(234, 312);
            this.bt_send.Name = "bt_send";
            this.bt_send.Size = new System.Drawing.Size(62, 29);
            this.bt_send.TabIndex = 38;
            this.bt_send.Text = "发送";
            this.bt_send.UseVisualStyleBackColor = true;
            // 
            // bt_clear
            // 
            this.bt_clear.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.bt_clear.Enabled = false;
            this.bt_clear.Location = new System.Drawing.Point(234, 241);
            this.bt_clear.Name = "bt_clear";
            this.bt_clear.Size = new System.Drawing.Size(62, 30);
            this.bt_clear.TabIndex = 37;
            this.bt_clear.Text = "清除";
            this.bt_clear.UseVisualStyleBackColor = true;
            // 
            // txt_msg
            // 
            this.txt_msg.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txt_msg.Enabled = false;
            this.txt_msg.Location = new System.Drawing.Point(63, 287);
            this.txt_msg.Multiline = true;
            this.txt_msg.Name = "txt_msg";
            this.txt_msg.Size = new System.Drawing.Size(165, 54);
            this.txt_msg.TabIndex = 36;
            // 
            // textBox1
            // 
            this.textBox1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.textBox1.Enabled = false;
            this.textBox1.Location = new System.Drawing.Point(63, 167);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(165, 114);
            this.textBox1.TabIndex = 35;
            // 
            // bt_disconnect
            // 
            this.bt_disconnect.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.bt_disconnect.Enabled = false;
            this.bt_disconnect.Location = new System.Drawing.Point(231, 126);
            this.bt_disconnect.Name = "bt_disconnect";
            this.bt_disconnect.Size = new System.Drawing.Size(65, 35);
            this.bt_disconnect.TabIndex = 34;
            this.bt_disconnect.Text = "断开";
            this.bt_disconnect.UseVisualStyleBackColor = true;
            // 
            // bt_connect
            // 
            this.bt_connect.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.bt_connect.Enabled = false;
            this.bt_connect.Location = new System.Drawing.Point(231, 84);
            this.bt_connect.Name = "bt_connect";
            this.bt_connect.Size = new System.Drawing.Size(65, 29);
            this.bt_connect.TabIndex = 33;
            this.bt_connect.Text = "连接";
            this.bt_connect.UseVisualStyleBackColor = true;
            // 
            // txt_port
            // 
            this.txt_port.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txt_port.Enabled = false;
            this.txt_port.Location = new System.Drawing.Point(105, 126);
            this.txt_port.Name = "txt_port";
            this.txt_port.Size = new System.Drawing.Size(100, 21);
            this.txt_port.TabIndex = 32;
            this.txt_port.Text = "2001";
            // 
            // lb_port
            // 
            this.lb_port.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lb_port.AutoSize = true;
            this.lb_port.Location = new System.Drawing.Point(63, 126);
            this.lb_port.Name = "lb_port";
            this.lb_port.Size = new System.Drawing.Size(35, 12);
            this.lb_port.TabIndex = 31;
            this.lb_port.Text = "port:";
            // 
            // lb_ip
            // 
            this.lb_ip.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lb_ip.AutoSize = true;
            this.lb_ip.Location = new System.Drawing.Point(76, 95);
            this.lb_ip.Name = "lb_ip";
            this.lb_ip.Size = new System.Drawing.Size(23, 12);
            this.lb_ip.TabIndex = 30;
            this.lb_ip.Text = "IP:";
            // 
            // txt_ip
            // 
            this.txt_ip.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txt_ip.Enabled = false;
            this.txt_ip.Location = new System.Drawing.Point(105, 92);
            this.txt_ip.Name = "txt_ip";
            this.txt_ip.Size = new System.Drawing.Size(100, 21);
            this.txt_ip.TabIndex = 29;
            this.txt_ip.Text = "127.0.0.1";
            // 
            // TCPIP_Communication
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(649, 446);
            this.Controls.Add(this.debugtcp);
            this.Controls.Add(this.Save_ClientServer_Par);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.ServerMode);
            this.Controls.Add(this.ClientMode);
            this.Controls.Add(this.bt_sendserver);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.txt_msgserver);
            this.Controls.Add(this.btn_StopListen);
            this.Controls.Add(this.bt_connnect);
            this.Controls.Add(this.tb_port);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tb_ip);
            this.Controls.Add(this.bt_send);
            this.Controls.Add(this.bt_clear);
            this.Controls.Add(this.txt_msg);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.bt_disconnect);
            this.Controls.Add(this.bt_connect);
            this.Controls.Add(this.txt_port);
            this.Controls.Add(this.lb_port);
            this.Controls.Add(this.lb_ip);
            this.Controls.Add(this.txt_ip);
            this.Name = "TCPIP_Communication";
            this.Text = "TCPIP_Communication";
            this.Load += new System.EventHandler(this.TCPIP_Communication_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button debugtcp;
        private System.Windows.Forms.Button Save_ClientServer_Par;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.RadioButton ServerMode;
        private System.Windows.Forms.RadioButton ClientMode;
        private System.Windows.Forms.Button bt_sendserver;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox txt_msgserver;
        private System.Windows.Forms.Button btn_StopListen;
        private System.Windows.Forms.Button bt_connnect;
        private System.Windows.Forms.TextBox tb_port;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tb_ip;
        private System.Windows.Forms.Button bt_send;
        private System.Windows.Forms.Button bt_clear;
        private System.Windows.Forms.TextBox txt_msg;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button bt_disconnect;
        private System.Windows.Forms.Button bt_connect;
        private System.Windows.Forms.TextBox txt_port;
        private System.Windows.Forms.Label lb_port;
        private System.Windows.Forms.Label lb_ip;
        private System.Windows.Forms.TextBox txt_ip;
    }
}