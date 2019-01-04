namespace VisionproTool
{
    partial class SerialPort_Communication
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
            this.save_serial_par = new System.Windows.Forms.Button();
            this.button_Send = new System.Windows.Forms.Button();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.textBox_Send = new System.Windows.Forms.TextBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.textBox_Receive = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.radioButton_Unicode = new System.Windows.Forms.RadioButton();
            this.radioButton_UTF8 = new System.Windows.Forms.RadioButton();
            this.radioButton_ASCII = new System.Windows.Forms.RadioButton();
            this.radioButton_Hex = new System.Windows.Forms.RadioButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.button_Switch = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.comboBox_DataBits = new System.Windows.Forms.ComboBox();
            this.comboBox_CheckBits = new System.Windows.Forms.ComboBox();
            this.comboBox_BaudRate = new System.Windows.Forms.ComboBox();
            this.comboBox_StopBits = new System.Windows.Forms.ComboBox();
            this.comboBox_Port = new System.Windows.Forms.ComboBox();
            this.groupBox4.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // save_serial_par
            // 
            this.save_serial_par.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.save_serial_par.Location = new System.Drawing.Point(504, 399);
            this.save_serial_par.Name = "save_serial_par";
            this.save_serial_par.Size = new System.Drawing.Size(75, 23);
            this.save_serial_par.TabIndex = 24;
            this.save_serial_par.Text = "保存";
            this.save_serial_par.UseVisualStyleBackColor = true;
            this.save_serial_par.Click += new System.EventHandler(this.save_serial_par_Click_1);
            // 
            // button_Send
            // 
            this.button_Send.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.button_Send.Location = new System.Drawing.Point(681, 399);
            this.button_Send.Name = "button_Send";
            this.button_Send.Size = new System.Drawing.Size(75, 23);
            this.button_Send.TabIndex = 23;
            this.button_Send.Text = "send";
            this.button_Send.UseVisualStyleBackColor = true;
            this.button_Send.Click += new System.EventHandler(this.button_Send_Click_1);
            // 
            // groupBox4
            // 
            this.groupBox4.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.groupBox4.Controls.Add(this.textBox_Send);
            this.groupBox4.Location = new System.Drawing.Point(12, 295);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(702, 77);
            this.groupBox4.TabIndex = 22;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "send";
            // 
            // textBox_Send
            // 
            this.textBox_Send.Location = new System.Drawing.Point(15, 20);
            this.textBox_Send.Multiline = true;
            this.textBox_Send.Name = "textBox_Send";
            this.textBox_Send.Size = new System.Drawing.Size(668, 50);
            this.textBox_Send.TabIndex = 1;
            // 
            // groupBox3
            // 
            this.groupBox3.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.groupBox3.Controls.Add(this.textBox_Receive);
            this.groupBox3.Location = new System.Drawing.Point(12, 212);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(702, 77);
            this.groupBox3.TabIndex = 21;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "received";
            // 
            // textBox_Receive
            // 
            this.textBox_Receive.Location = new System.Drawing.Point(15, 21);
            this.textBox_Receive.Multiline = true;
            this.textBox_Receive.Name = "textBox_Receive";
            this.textBox_Receive.Size = new System.Drawing.Size(668, 50);
            this.textBox_Receive.TabIndex = 0;
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.groupBox2.Controls.Add(this.radioButton_Unicode);
            this.groupBox2.Controls.Add(this.radioButton_UTF8);
            this.groupBox2.Controls.Add(this.radioButton_ASCII);
            this.groupBox2.Controls.Add(this.radioButton_Hex);
            this.groupBox2.Location = new System.Drawing.Point(12, 117);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(702, 77);
            this.groupBox2.TabIndex = 20;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "编码方式";
            // 
            // radioButton_Unicode
            // 
            this.radioButton_Unicode.AutoSize = true;
            this.radioButton_Unicode.Location = new System.Drawing.Point(540, 36);
            this.radioButton_Unicode.Name = "radioButton_Unicode";
            this.radioButton_Unicode.Size = new System.Drawing.Size(65, 16);
            this.radioButton_Unicode.TabIndex = 3;
            this.radioButton_Unicode.TabStop = true;
            this.radioButton_Unicode.Text = "unicode";
            this.radioButton_Unicode.UseVisualStyleBackColor = true;
            // 
            // radioButton_UTF8
            // 
            this.radioButton_UTF8.AutoSize = true;
            this.radioButton_UTF8.Location = new System.Drawing.Point(366, 36);
            this.radioButton_UTF8.Name = "radioButton_UTF8";
            this.radioButton_UTF8.Size = new System.Drawing.Size(47, 16);
            this.radioButton_UTF8.TabIndex = 2;
            this.radioButton_UTF8.TabStop = true;
            this.radioButton_UTF8.Text = "utf8";
            this.radioButton_UTF8.UseVisualStyleBackColor = true;
            // 
            // radioButton_ASCII
            // 
            this.radioButton_ASCII.AutoSize = true;
            this.radioButton_ASCII.Location = new System.Drawing.Point(200, 36);
            this.radioButton_ASCII.Name = "radioButton_ASCII";
            this.radioButton_ASCII.Size = new System.Drawing.Size(53, 16);
            this.radioButton_ASCII.TabIndex = 1;
            this.radioButton_ASCII.TabStop = true;
            this.radioButton_ASCII.Text = "ascii";
            this.radioButton_ASCII.UseVisualStyleBackColor = true;
            // 
            // radioButton_Hex
            // 
            this.radioButton_Hex.Location = new System.Drawing.Point(31, 36);
            this.radioButton_Hex.Name = "radioButton_Hex";
            this.radioButton_Hex.Size = new System.Drawing.Size(35, 16);
            this.radioButton_Hex.TabIndex = 0;
            this.radioButton_Hex.TabStop = true;
            this.radioButton_Hex.Text = "16";
            this.radioButton_Hex.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.groupBox1.Controls.Add(this.button_Switch);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.comboBox_DataBits);
            this.groupBox1.Controls.Add(this.comboBox_CheckBits);
            this.groupBox1.Controls.Add(this.comboBox_BaudRate);
            this.groupBox1.Controls.Add(this.comboBox_StopBits);
            this.groupBox1.Controls.Add(this.comboBox_Port);
            this.groupBox1.Location = new System.Drawing.Point(12, 13);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(768, 98);
            this.groupBox1.TabIndex = 19;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "参数设定";
            // 
            // button_Switch
            // 
            this.button_Switch.Location = new System.Drawing.Point(492, 62);
            this.button_Switch.Name = "button_Switch";
            this.button_Switch.Size = new System.Drawing.Size(75, 23);
            this.button_Switch.TabIndex = 0;
            this.button_Switch.Text = "开启";
            this.button_Switch.UseVisualStyleBackColor = true;
            this.button_Switch.Click += new System.EventHandler(this.button_Switch_Click_1);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(618, 26);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(41, 12);
            this.label7.TabIndex = 13;
            this.label7.Text = "数据位";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(364, 62);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(29, 12);
            this.label4.TabIndex = 10;
            this.label4.Text = "奇偶";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(364, 28);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 12);
            this.label3.TabIndex = 9;
            this.label3.Text = "波特率";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(142, 62);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 12);
            this.label2.TabIndex = 8;
            this.label2.Text = "停止位";
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(142, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "端口";
            // 
            // comboBox_DataBits
            // 
            this.comboBox_DataBits.FormattingEnabled = true;
            this.comboBox_DataBits.Items.AddRange(new object[] {
            6,
            7,
            8});
            this.comboBox_DataBits.Location = new System.Drawing.Point(492, 23);
            this.comboBox_DataBits.Name = "comboBox_DataBits";
            this.comboBox_DataBits.Size = new System.Drawing.Size(98, 20);
            this.comboBox_DataBits.TabIndex = 6;
            // 
            // comboBox_CheckBits
            // 
            this.comboBox_CheckBits.FormattingEnabled = true;
            this.comboBox_CheckBits.Items.AddRange(new object[] {
            "None","Odd","Even"});
            this.comboBox_CheckBits.Location = new System.Drawing.Point(226, 59);
            this.comboBox_CheckBits.Name = "comboBox_CheckBits";
            this.comboBox_CheckBits.Size = new System.Drawing.Size(121, 20);
            this.comboBox_CheckBits.TabIndex = 3;
            // 
            // comboBox_BaudRate
            // 
            this.comboBox_BaudRate.FormattingEnabled = true;
            this.comboBox_BaudRate.Items.AddRange(new object[] {
            110,
            300,
            1200,
            2400,
            4800,
            9600,19200,38400,43000,56000,576000,
            115200});
            this.comboBox_BaudRate.Location = new System.Drawing.Point(226, 20);
            this.comboBox_BaudRate.Name = "comboBox_BaudRate";
            this.comboBox_BaudRate.Size = new System.Drawing.Size(121, 20);
            this.comboBox_BaudRate.TabIndex = 2;
            // 
            // comboBox_StopBits
            // 
            this.comboBox_StopBits.FormattingEnabled = true;
            this.comboBox_StopBits.Items.AddRange(new object[] {
            1,1.5,
            2,
            3});
            this.comboBox_StopBits.Location = new System.Drawing.Point(6, 59);
            this.comboBox_StopBits.Name = "comboBox_StopBits";
            this.comboBox_StopBits.Size = new System.Drawing.Size(121, 20);
            this.comboBox_StopBits.TabIndex = 1;
            // 
            // comboBox_Port
            // 
            this.comboBox_Port.Location = new System.Drawing.Point(6, 20);
            this.comboBox_Port.Name = "comboBox_Port";
            this.comboBox_Port.Size = new System.Drawing.Size(121, 20);
            this.comboBox_Port.TabIndex = 0;
            // 
            // SerialPort_Communication
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(821, 434);
            this.Controls.Add(this.save_serial_par);
            this.Controls.Add(this.button_Send);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "SerialPort_Communication";
            this.Text = "SerialPort_Communication";
            this.Load += new System.EventHandler(this.SerialPort_Communication_Load);
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button save_serial_par;
        private System.Windows.Forms.Button button_Send;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.TextBox textBox_Send;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.TextBox textBox_Receive;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.RadioButton radioButton_Unicode;
        private System.Windows.Forms.RadioButton radioButton_UTF8;
        private System.Windows.Forms.RadioButton radioButton_ASCII;
        private System.Windows.Forms.RadioButton radioButton_Hex;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button button_Switch;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboBox_DataBits;
        private System.Windows.Forms.ComboBox comboBox_CheckBits;
        private System.Windows.Forms.ComboBox comboBox_BaudRate;
        private System.Windows.Forms.ComboBox comboBox_StopBits;
        private System.Windows.Forms.ComboBox comboBox_Port;
    }
}