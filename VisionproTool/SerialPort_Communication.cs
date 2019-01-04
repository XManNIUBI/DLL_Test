using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO.Ports;

namespace VisionproTool
{
    /// <summary>
    /// 串口通讯（发送和接收的格式都通过编码格式的编码解码）
    /// </summary>
    public partial class SerialPort_Communication : Form
    {
        //定义端口类
        private SerialPort ComDevice = new SerialPort();

        /// <summary>
        /// 构造函数
        /// </summary>
        public SerialPort_Communication()
        {
            InitializeComponent();
            InitialConfig();
            ReadIniPar();
        }

        private void SerialPort_Communication_Load(object sender, EventArgs e)
        {


            this.MaximizeBox = false;
            
        }

        public void ReadIniPar()
        {
            FilesIni mIni = new FilesIni(SerialPortFileName);
            string COM = mIni.ReadString("SerialPort Communication", "COM", "");
            string BaudRate = mIni.ReadString("SerialPort Communication", "BaudRate", "");
            string DateBits = mIni.ReadString("SerialPort Communication", "DateBits", "");
            string StopBits = mIni.ReadString("SerialPort Communication", "StopBits", "");
            string CheckBits = mIni.ReadString("SerialPort Communication", "CheckBits", "");
            string CodedFormat = mIni.ReadString("SerialPort Communication", "CodedFormat", "");


            if (CodedFormat != "")
            {
                this.radioButton_Hex.Checked = (CodedFormat == "Hex");
                this.radioButton_ASCII.Checked = (CodedFormat == "ASCII");
                this.radioButton_UTF8.Checked = (CodedFormat == "UTF8");
                this.radioButton_Unicode.Checked = (CodedFormat == "Unicode");
            }
            else
            {
                this.radioButton_ASCII.Checked = true;
            }

            if (COM != "") { comboBox_Port.Text = COM; }
            if (StopBits != "") { comboBox_StopBits.Text = StopBits; }
            if (BaudRate != "") { comboBox_BaudRate.Text = BaudRate; }
            if (CheckBits != "") { comboBox_CheckBits.Text = CheckBits; }
            if (DateBits != "") { comboBox_DataBits.Text = DateBits; }
        }

        /// <summary>
        /// 配置初始化
        /// </summary>
        private void InitialConfig()
        {
            //查询主机上存在的串口
            comboBox_Port.Items.AddRange(SerialPort.GetPortNames());

            if (comboBox_Port.Items.Count > 0)
            {
                //comboBox_Port.SelectedIndex = 1;
            }
            else
            {
                comboBox_Port.Text = "未检测到串口";
            }
            comboBox_BaudRate.SelectedIndex = 5;
            comboBox_DataBits.SelectedIndex = 2;
            comboBox_StopBits.SelectedIndex = 0;
            comboBox_CheckBits.SelectedIndex = 0;
            //pictureBox_Status.BackgroundImage = Properties.Resources.ResourceManager.

            //向ComDevice.DataReceived（是一个事件）注册一个方法Com_DataReceived，当端口类接收到信息时时会自动调用Com_DataReceived方法
            ComDevice.DataReceived += new SerialDataReceivedEventHandler(Com_DataReceived);
        }

        /// <summary>
        /// 一旦ComDevice.DataReceived事件发生，就将从串口接收到的数据显示到接收端对话框
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Com_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            //开辟接收缓冲区
            byte[] ReDatas = new byte[ComDevice.BytesToRead];
            //从串口读取数据
            ComDevice.Read(ReDatas, 0, ReDatas.Length);//把接收到的数据从0开始读，读的个数为ReDatas.Length，存入ReDatas字节数组
            //实现数据的解码与显示
            AddData(ReDatas);
        }

        /// <summary>
        /// 解码过程
        /// </summary>
        /// <param name="data">串口通信的数据编码方式因串口而异，需要查询串口相关信息以获取</param>
        public void AddData(byte[] data)
        {
            if (radioButton_Hex.Checked)
            {
                StringBuilder sb = new StringBuilder();
                for (int i = 0; i < data.Length; i++)
                {
                    sb.AppendFormat("{0:x2}" + " ", data[i]);//x表示16进制，2表示域宽
                }
                AddContent(sb.ToString().ToUpper());
            }
            else if (radioButton_ASCII.Checked)
            {
                AddContent(new ASCIIEncoding().GetString(data));
            }
            else if (radioButton_UTF8.Checked)
            {
                AddContent(new UTF8Encoding().GetString(data));
            }
            else if (radioButton_Unicode.Checked)
            {
                AddContent(new UnicodeEncoding().GetString(data));
            }
            else
            {
                StringBuilder sb = new StringBuilder();
                for (int i = 0; i < data.Length; i++)
                {
                    sb.AppendFormat("{0:x2}" + " ", data[i]);
                }
                AddContent(sb.ToString().ToUpper());
            }
        }

        /// <summary>
        /// 接收端对话框显示消息
        /// </summary>
        /// <param name="content"></param>
        private void AddContent(string content)
        {
            if (this.IsHandleCreated)
            {
                BeginInvoke(new MethodInvoker(delegate
                {
                    textBox_Receive.AppendText(content);
                }));
            }
            SerialPort_ReceiveData = content;
            lock (receive_Obj)
            {
                List_ReceiveData.Add(SerialPort_ReceiveData);
            }

        }

        /// <summary>
        /// 每次接受到数据，放入此列表
        /// </summary>
        public static List<string> List_ReceiveData = new List<string>();
        /// <summary>
        /// 列表不可同时操作锁定对象
        /// </summary>
        public static object receive_Obj = new object();

        #region 把串口开关拆分为打开和关闭两个功能

        /// <summary>
        /// 串口开关
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button_Switch_Click(object sender, EventArgs e)
        {
            SerialPort_Switch();
        }


        void SerialPort_Switch()
        {
            if (comboBox_Port.Items.Count <= 0)
            {
                MessageBox.Show("未发现可用串口，请检查硬件设备");
                return;
            }

            if (ComDevice.IsOpen == false)
            {
                //设置串口相关属性

                ComDevice.PortName = comboBox_Port.SelectedItem.ToString();
                ComDevice.BaudRate = Convert.ToInt32(comboBox_BaudRate.SelectedItem.ToString());
                ComDevice.Parity = (Parity)Convert.ToInt32(comboBox_CheckBits.SelectedIndex.ToString());
                ComDevice.DataBits = Convert.ToInt32(comboBox_DataBits.SelectedItem.ToString());
                ComDevice.StopBits = (StopBits)Convert.ToInt32(comboBox_StopBits.SelectedItem.ToString());
                try
                {
                    //开启串口
                    ComDevice.Open();
                    button_Send.Enabled = true;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "未能成功开启串口", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                button_Switch.Text = "关闭";
                //pictureBox_Status.BackgroundImage = Properties.Resources.green;
            }
            else
            {
                try
                {
                    //关闭串口
                    ComDevice.Close();
                    button_Send.Enabled = false;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "串口关闭错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                button_Switch.Text = "开启";
                //pictureBox_Status.BackgroundImage = Properties.Resources.red;
            }

            comboBox_Port.Enabled = !ComDevice.IsOpen;
            comboBox_BaudRate.Enabled = !ComDevice.IsOpen;
            comboBox_DataBits.Enabled = !ComDevice.IsOpen;
            comboBox_StopBits.Enabled = !ComDevice.IsOpen;
            comboBox_CheckBits.Enabled = !ComDevice.IsOpen;
        }

        /// <summary>
        /// 开启串口
        /// </summary>
        public void SerialPort_Open()
        {
            if (comboBox_Port.Items.Count <= 0)
            {
                MessageBox.Show("未发现可用串口，请检查硬件设备");
                return;
            }

            if (ComDevice.IsOpen == false)
            {
                //设置串口相关属性
                //FilesIni mIni = new FilesIni(SerialPortFileName);
                //ComDevice.PortName = mIni.ReadString("SerialPort Communication", "COM", "");

                //int _BaudRate = 0;
                //int.TryParse(mIni.ReadString("SerialPort Communication", "BaudRate", ""), out _BaudRate);
                //ComDevice.BaudRate = _BaudRate;

                //int _Parity = 0;
                //int.TryParse(mIni.ReadString("SerialPort Communication", "CheckBits", ""), out _Parity);
                //ComDevice.Parity = (Parity)_Parity;

                //int _DataBits = 0;
                //int.TryParse(mIni.ReadString("SerialPort Communication", "DateBits", ""), out _DataBits);
                //ComDevice.DataBits = _DataBits;

                //int _StopBits = 0;
                //int.TryParse(mIni.ReadString("SerialPort Communication", "StopBits", ""), out _StopBits);
                //ComDevice.StopBits = (StopBits)_StopBits;

                ComDevice.PortName = comboBox_Port.SelectedItem.ToString();
                ComDevice.BaudRate = Convert.ToInt32(comboBox_BaudRate.SelectedItem.ToString());
                ComDevice.Parity = (Parity)Convert.ToInt32(comboBox_CheckBits.SelectedIndex.ToString());
                ComDevice.DataBits = Convert.ToInt32(comboBox_DataBits.SelectedItem.ToString());
                ComDevice.StopBits = (StopBits)Convert.ToInt32(comboBox_StopBits.SelectedItem.ToString());
                try
                {
                    //开启串口
                    ComDevice.Open();
                    button_Send.Enabled = true;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "未能成功开启串口", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                button_Switch.Text = "关闭";
                //pictureBox_Status.BackgroundImage = Properties.Resources.green;
            }
        }

        /// <summary>
        /// 关闭串口
        /// </summary>
        public void SerialPort_Close()
        {
            if (comboBox_Port.Items.Count <= 0)
            {
                MessageBox.Show("未发现可用串口，请检查硬件设备");
                return;
            }

            if (ComDevice.IsOpen == true)
            {
                try
                {
                    //关闭串口
                    ComDevice.Close();
                    button_Send.Enabled = false;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "串口关闭错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                button_Switch.Text = "开启";
                //pictureBox_Status.BackgroundImage = Properties.Resources.red;
            }
        }
        #endregion


        /// <summary>
        /// 将消息编码并发送
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button_Send_Click(object sender, EventArgs e)
        {
            SerialPort_SendMsg();
        }

        /// <summary>
        /// 串口要发送的数据
        /// </summary>
        public string SerialPort_SendData;

        /// <summary>
        /// 串口发送数据
        /// </summary>
        public void SerialPort_SendMsg()
        {
            if (textBox_Receive.Text.Length > 0)
            {
                textBox_Receive.AppendText("\n");
            }

            byte[] sendData = null;

            if (radioButton_Hex.Checked)
            {
                sendData = strToHexByte(textBox_Send.Text.Trim() + SerialPort_SendData);
            }
            else if (radioButton_ASCII.Checked)
            {
                sendData = Encoding.ASCII.GetBytes(textBox_Send.Text.Trim() + SerialPort_SendData);
            }
            else if (radioButton_UTF8.Checked)
            {
                sendData = Encoding.UTF8.GetBytes(textBox_Send.Text.Trim() + SerialPort_SendData);
            }
            else if (radioButton_Unicode.Checked)
            {
                sendData = Encoding.Unicode.GetBytes(textBox_Send.Text.Trim() + SerialPort_SendData);
            }
            else
            {
                sendData = strToHexByte(textBox_Send.Text.Trim() + SerialPort_SendData);
            }

            SendData(sendData);
        }

        /// <summary>
        /// 此函数将编码后的消息传递给串口
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public bool SendData(byte[] data)
        {
            if (ComDevice.IsOpen)
            {
                try
                {
                    //将消息传递给串口
                    ComDevice.Write(data, 0, data.Length);
                    return true;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "发送失败", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("串口未开启", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return false;
        }



        /// <summary>
        /// 16进制编码
        /// </summary>
        /// <param name="hexString"></param>
        /// <returns></returns>
        private byte[] strToHexByte(string hexString)
        {
            hexString = hexString.Replace(" ", "");//去掉单个空格
            if ((hexString.Length % 2) != 0) hexString += " ";
            byte[] returnBytes = new byte[hexString.Length / 2];
            for (int i = 0; i < returnBytes.Length; i++)
                returnBytes[i] = Convert.ToByte(hexString.Substring(i * 2, 2).Replace(" ", ""), 16);//将字符串转换为16进制，substring：从i*2开始有两位的字符串
            return returnBytes;
        }


        

        #region 读写参数
        /// <summary>
        /// 串口通讯参数文件路径
        /// </summary>
        public string SerialPath = System.AppDomain.CurrentDomain.BaseDirectory + @"SaveDir";

        /// <summary>
        /// 串口通讯参数文件名
        /// </summary>
        public string SerialPar_FileName = "Serial Port parameter";

        private void save_serial_par_Click(object sender, EventArgs e)
        {
            string[] SerialPort_Par = new string[10];


            if (this.radioButton_Hex.Checked == true)
            {
                SerialPort_Par[0] = "编码方式：Hex";
            }
            else if (this.radioButton_ASCII.Checked == true)
            {
                SerialPort_Par[0] = "编码方式：ASCII";
            }
            else if (this.radioButton_UTF8.Checked == true)
            {
                SerialPort_Par[0] = "编码方式：UTF8";
            }
            else if (this.radioButton_Unicode.Checked == true)
            {
                SerialPort_Par[0] = "编码方式：Unicode";
            }


            SerialPort_Par[1] = "Serial port:" + comboBox_Port.Text.ToString();
            SerialPort_Par[2] = "Serial stopbit:" + comboBox_StopBits.Text.ToString();


            SerialPort_Par[3] = "Serial baudrate:" + comboBox_BaudRate.Text.ToString();
            SerialPort_Par[4] = "Serial paritycheck:" + comboBox_CheckBits.Text.ToString();
            SerialPort_Par[5] = "Serial databit:" + comboBox_DataBits.Text.ToString();

            for (int i = 0; i < 8; i++)
            {
                SavaProcess(SerialPort_Par[i], "SerialPort parameter", i != 0, SerialPath);

            }
        }



        private void Read_ClientServer_Par(string path, string filename)
        {

            string[] SerialPar_ReadResult = ReadTxtFile(path + @"\" + filename + ".txt");

            //load parameter
            if (SerialPar_ReadResult[0] != null)
            {
                this.radioButton_Hex.Checked = (SerialPar_ReadResult[0] == "编码方式：Hex");
                this.radioButton_ASCII.Checked = (SerialPar_ReadResult[0] == "编码方式：ASCII");
                this.radioButton_UTF8.Checked = (SerialPar_ReadResult[0] == "编码方式：UTF8");
                this.radioButton_Unicode.Checked = (SerialPar_ReadResult[0] == "编码方式：Unicode");
            }
            else
            {
                this.radioButton_ASCII.Checked = true;
            }


            //if (SerialPar_ReadResult[0] != null) { ClientMode.Checked = (SerialPar_ReadResult[0] == "模式：Client"); }

            if (SerialPar_ReadResult[1] != null) { comboBox_Port.Text = SerialPar_ReadResult[1].Split(':')[1]; }
            if (SerialPar_ReadResult[2] != null) { comboBox_StopBits.Text = SerialPar_ReadResult[2].Split(':')[1]; }
            if (SerialPar_ReadResult[3] != null) { comboBox_BaudRate.Text = SerialPar_ReadResult[3].Split(':')[1]; }
            if (SerialPar_ReadResult[4] != null) { comboBox_CheckBits.Text = SerialPar_ReadResult[4].Split(':')[1]; }
            if (SerialPar_ReadResult[5] != null) { comboBox_DataBits.Text = SerialPar_ReadResult[5].Split(':')[1]; }

        }

        /// <summary>
        /// 保存数据data到文件的处理过程；
        /// </summary>
        /// <param name="data">需要保存的数据</param>
        /// <param name="filename">文件名，不带格式后缀</param>
        /// <param name="append">append 为true时，向文件追加文本</param>
        /// <param name="filepath">不带“\文件名”</param>
        /// <returns>返回完整文件路径</returns>
        public static String SavaProcess(string data, string filename, bool append, string filepath)
        {
            //System.DateTime currentTime = System.DateTime.Now;
            //获取当前日期的前一天转换成ToFileTime
            //string strYMD = currentTime.AddDays(-1).ToString("yyyyMMdd");
            //按照日期建立一个文件名
            //string FileName = "MyFileSend" + strYMD + ".txt";

            string FileName = filename + ".txt";

            //设置目录
            //string CurDir = System.AppDomain.CurrentDomain.BaseDirectory + @"SaveDir";
            //判断路径是否存在,不存在就创建文件夹
            if (!System.IO.Directory.Exists(filepath))
            {
                System.IO.Directory.CreateDirectory(filepath);
            }
            //定义文件路径
            String FilePath = filepath + @"\" + FileName;
            //文件覆盖方式添加内容
            System.IO.StreamWriter file = new System.IO.StreamWriter(FilePath, append);//append 为true时，向文件追加文本
            //保存数据到文件
            file.WriteLine(data);
            //关闭文件
            file.Close();
            //释放对象
            file.Dispose();

            return FilePath;
        }

        /// <summary>
        /// 获取文件中的数据
        /// </summary>
        /// <param name="filePath">完整文件路径，包括文件名和后缀</param>
        public string[] ReadTxtFile(String filePath)
        {
            //string strData = "";
            int i = 0;
            string[] txtdata = new string[100];
            try
            {

                //逐行读取
                ////////////////////////////////////////////////////////
                string line;
                // 创建一个 streamreader 的实例来读取文件 ,using 语句也能关闭 streamreader
                using (System.IO.StreamReader sr = new System.IO.StreamReader(filePath))
                {
                    // 从文件读取并显示行，直到文件的末尾
                    while ((line = sr.ReadLine()) != null)
                    {
                        //console.writeline(line);
                        //strData = line;
                        //txtdata[i++] = strData;
                        txtdata[i++] = line;
                        //lb_msg.Items.Add(line);
                    }
                    sr.Close();
                }

                //读取某一行
                ///////////////////////////////////////////
                //int i = 0;
                //string line;
                //using (System.IO.StreamReader sr = new System.IO.StreamReader(filePath))
                //{
                //    while ((line = sr.ReadLine()) != null)
                //    {
                //        i++;
                //        if (i == 4)
                //        {
                //            strData = line;
                //            lb_msg.Items.Add(strData);
                //        }
                //    }
                //}
                //////////////////////////////////////////
            }
            catch (Exception e)
            {
                // 向用户显示出错消息
                Console.WriteLine("The file could not be read:");
                Console.WriteLine(e.Message);
            }

            return txtdata;
        }
        #endregion

        /// <summary>
        /// 串口接收到的字符串
        /// </summary>
        public string SerialPort_ReceiveData;

        public string SerialPortFileName=Application.StartupPath + "\\Config.ini";

        private void save_serial_par_Click_1(object sender, EventArgs e)
        {
            FilesIni mIni = new FilesIni(SerialPortFileName);
            mIni.WriteString("SerialPort Communication","COM",comboBox_Port.Text);
            mIni.WriteString("SerialPort Communication", "BaudRate", comboBox_BaudRate.Text);
            mIni.WriteString("SerialPort Communication", "DateBits", comboBox_DataBits.Text);
            mIni.WriteString("SerialPort Communication", "StopBits", comboBox_StopBits.Text);
            mIni.WriteString("SerialPort Communication", "CheckBits", comboBox_CheckBits.Text);

            if (radioButton_Hex.Checked)
            {
                mIni.WriteString("SerialPort Communication", "CodedFormat", "Hex");
            }
            else if (radioButton_ASCII.Checked)
            {
                mIni.WriteString("SerialPort Communication", "CodedFormat", "ASCII");
            }
            else if (radioButton_UTF8.Checked)
            {
                mIni.WriteString("SerialPort Communication", "CodedFormat", "UTF8");
            }
            else if (radioButton_Unicode.Checked)
            {
                mIni.WriteString("SerialPort Communication", "CodedFormat", "Unicode");
            }
            
        }

        private void button_Switch_Click_1(object sender, EventArgs e)
        {
            SerialPort_Switch();
        }

        private void button_Send_Click_1(object sender, EventArgs e)
        {
            SerialPort_SendMsg();
        }

        /*
         * 引用方法
         * 
          if (false)
            {
                串口通讯 serialport = new 串口通讯();
                serialport.SerialPort_Open();
                //要发送的数据
                //serialport.SerialPort_SendData = "";
                //接受的数据
                //serialport.SerialPort_ReceiveData

                Thread Sp_thread = new Thread(serialport.SerialPort_Communication);
                Sp_thread.IsBackground = true;
                Sp_thread.Start();
            } 
          
        public void SerialPort_Communication()
        {
            while (true)
            {
                //SerialPort_ReceiveData = textBox_Receive.Text;
                if (SerialPort_ReceiveData != null)
                {
                    SerialPort_SendData = SerialPort_ReceiveData + "#get#";
                    SerialPort_SendMsg();
                    SerialPort_ReceiveData = null;
                }

                //if (textBox_Receive.Text != "")
                //{
                //    SerialPort_ReceiveData = textBox_Receive.Text;
                //    SerialPort_SendData = textBox_Receive.Text + "#get#";
                //    SerialPort_SendMsg();
                //    textBox_Receive.Text = "";
                //}
            }
        }
         * */

    }
}
