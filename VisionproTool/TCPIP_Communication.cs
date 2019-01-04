using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Net.Sockets;
using System.Threading;
using System.Net;
using Cognex.VisionPro;

namespace VisionproTool
{
    /// <summary>
    /// 网络通讯
    /// </summary>
    public partial class TCPIP_Communication : Form
    {
        public TCPIP_Communication()
        {
            InitializeComponent();
            Read_ClientServer_Par(ClientServerPath, FileName);
        }

        private void TCPIP_Communication_Load(object sender, EventArgs e)
        {
            Control.CheckForIllegalCrossThreadCalls = false;
        }

         #region 客户端代码

        Socket socketSend=null;
        Thread c_thread=null;

        private void bt_connect_Click(object sender, EventArgs e)
        {
            client_socketsendcreate();
        }

        /// <summary>
        /// 客户端绑定IP及端口号
        /// </summary>
        public void client_socketsendcreate()
        {
            try
            {
                //创建客户端Socket，获得远程ip和端口号
                socketSend = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                IPAddress ip = IPAddress.Parse(txt_ip.Text);
                IPEndPoint point = new IPEndPoint(ip, Convert.ToInt32(txt_port.Text));

                socketSend.Connect(point);
                ClientShowMsg("连接成功!");
                //开启新的线程，不停的接收服务器发来的消息
                c_thread = new Thread(Received);
                c_thread.IsBackground = true;
                c_thread.Start();
            }
            catch (Exception)
            {
                ClientShowMsg("IP或者端口号错误...");
            }
        }

        void ClientShowMsg(string str)
        {
            textBox1.AppendText(str + "\r\n");
        }

        /// <summary>
        /// 客户端接收到的字符串
        /// </summary>
        public static string client_receiveddata;

        /// <summary>
        /// 委托：客户端显示信息
        /// </summary>
        /// <param name="newmsg"></param>
        public delegate void delegateclientshowmsg(string newmsg);

        /// <summary>
        /// 接收服务端返回的消息
        /// </summary>
        void Received()
        {
            while (true)
            {
                try
                {
                    byte[] buffer = new byte[1024 * 1024 * 3];
                    //实际接收到的有效字节数
                    int len = socketSend.Receive(buffer);
                    if (len == 0)
                    {
                        break;
                    }
                    client_receiveddata = Encoding.UTF8.GetString(buffer, 0, len);
                   //ClientShowMsg(socketSend.RemoteEndPoint + ":" + client_receiveddata);
                   //delegateclientshowmsg dcs = new delegateclientshowmsg(ClientShowMsg);
                   //this.BeginInvoke(dcs,client_receiveddata);
                   //this.Invoke(new delegateclientshowmsg(ClientShowMsg), new object[] { client_receiveddata });

                   if (this.textBox1.InvokeRequired)//如果调用控件的线程和创建创建控件的线程不是同一个则为True
                   {
                       while (!this.textBox1.IsHandleCreated)
                       {
                           //解决窗体关闭时出现“访问已释放句柄“的异常
                           if (this.textBox1.Disposing || this.textBox1.IsDisposed)
                               return;
                       }
                       delegateclientshowmsg d = new delegateclientshowmsg(ClientShowMsg);
                       this.textBox1.Invoke(d, new object[] { client_receiveddata });
                   }
                   else
                   {
                       ClientShowMsg(socketSend.RemoteEndPoint + ":" + client_receiveddata);
                   }

                }
                catch { }

                //client_senddata = "getmessage";
                //client_send();
            }
        }

        private void bt_send_Click(object sender, EventArgs e)
        {
            client_send();
        }

        /// <summary>
        /// 客户端需要发送的字符串
        /// </summary>
        public static string client_senddata;

        /// <summary>
        /// 客户端发送字符串到服务器
        /// </summary>
        public void client_send()
        {
            try
            {
                string msg = txt_msg.Text.Trim() + client_senddata;
                byte[] buffer = new byte[1024 * 1024 * 3];
                buffer = Encoding.UTF8.GetBytes(msg);
                socketSend.Send(buffer);
                ClientShowMsg(msg);
                txt_msg.Text = "";
            }
            catch { }
        }

        private void bt_disconnect_Click(object sender, EventArgs e)
        {
            client_disconnect();

        }


        void client_disconnect()
        {
            if (socketSend != null && socketSend.Connected)
            {
                socketSend.Shutdown(SocketShutdown.Both);
                System.Threading.Thread.Sleep(10);
                socketSend.Close();
                ClientShowMsg("socketSend close");
            }

            //终止线程
            if (c_thread != null)
            {

                c_thread.Abort();
                //Cthread.Join();
                ClientShowMsg("c_thread close");
            }

        }


        private void bt_clear_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
        }

        #endregion


        #region 服务器端代码

        Socket CsocketWatch = null;
        Thread S_thread = null;
        Thread SR_thread = null;

        /// <summary>
        /// 开始监听按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void bt_connnect_Click(object sender, EventArgs e)
        {
            server_startlisten();

        }

        /// <summary>
        /// 服务器开始监听
        /// </summary>
        public void server_startlisten()
        {
            try
            {
                //点击开始监听时 在服务端创建一个负责监听IP和端口号的Socket
                CsocketWatch = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                IPAddress ip = IPAddress.Any;
                //创建对象端口
                IPEndPoint point = new IPEndPoint(ip, Convert.ToInt32(tb_port.Text));

                CsocketWatch.Bind(point);//绑定端口号
                ServerShowMsg("监听成功!");
                CsocketWatch.Listen(10);//设置监听

                //创建监听线程
                S_thread = new Thread(CListen);
                S_thread.IsBackground = true;//=TRUE时跟随主线程一起退出
                S_thread.Start(CsocketWatch);
            }
            catch { }
        }

        Socket CsocketSend;

        void CListen(object o)
        {
            try
            {
                Socket socketWatch = o as Socket;
                while (true)
                {
                    CsocketSend = socketWatch.Accept();//等待接收客户端连接
                    ServerShowMsg(CsocketSend.RemoteEndPoint.ToString() + ":" + "连接成功!");
                    //开启一个新线程，执行接收消息方法
                    // Cr_thread = new Thread(CReceived)，Cr_thread.Start(CsocketSend)，相当于引用CReceived（CsocketSend）
                    SR_thread = new Thread(CReceived);
                    SR_thread.IsBackground = true;
                    SR_thread.Start(CsocketSend);
                }
            }
            catch { }
        }

        /// <summary>
        /// 服务器接收到的字符串
        /// </summary>
        public static string server_receivedata;

        /// <summary>
        /// 服务器端不停的接收客户端发来的消息
        /// </summary>
        /// <param name="o"></param>
        void CReceived(object o)
        {
            try
            {
                Socket socketSend = o as Socket;
                while (true)
                {
                    //客户端连接服务器成功后，服务器接收客户端发送的消息
                    byte[] buffer = new byte[1024 * 1024 * 3];
                    //实际接收到的有效字节数
                    int len = socketSend.Receive(buffer);
                    if (len == 0)
                    {
                        break;
                    }
                    server_receivedata = Encoding.UTF8.GetString(buffer, 0, len);
                    ServerShowMsg(socketSend.RemoteEndPoint + ":" + server_receivedata);
                }
            }
            catch { }
        }

        /// <summary>
        /// 服务器向客户端发送消息
        /// </summary>
        /// <param name="str"></param>
        void CSend(string str)
        {
            byte[] buffer = Encoding.UTF8.GetBytes(str);
            if (CsocketSend != null)
            {
                CsocketSend.Send(buffer);
            }

        }

        //使用listbox
        //void ServerShowMsg(string msg)
        //{
        //    listBox1.Items.Add(msg + "\r\n");
        //}

        //使用textbox
        void ServerShowMsg(string str)
        {
            textBox2.AppendText(str + "\r\n");
        }

        private void bt_sendserver_Click(object sender, EventArgs e)
        {
            server_sendmsg();
        }

        /// <summary>
        /// 服务器需要发送的字符串
        /// </summary>
        public static string server_senddata;

        /// <summary>
        /// 服务器发送信息
        /// </summary>
        public void server_sendmsg()
        {
            CSend(txt_msgserver.Text.Trim() + server_senddata);
            ServerShowMsg(txt_msgserver.Text);
            txt_msgserver.Clear();
        }

        private void btn_StopListen_Click(object sender, EventArgs e)
        {
            server_stoplisten();
        }

        void server_stoplisten()
        {
            //if (CsocketWatch != null && CsocketWatch.Connected)
            if (CsocketWatch != null)
            {
                //CsocketWatch.Shutdown(SocketShutdown.Both);
                System.Threading.Thread.Sleep(10);
                CsocketWatch.Close();

                ServerShowMsg("CsocketWatch close");
            }

            if (CsocketSend != null && CsocketSend.Connected)
            {
                CsocketSend.Shutdown(SocketShutdown.Both);
                System.Threading.Thread.Sleep(10);
                CsocketSend.Close();
                CsocketSend = null;
                ServerShowMsg("CsocketSend close");
            }


            //终止线程
            if (S_thread != null)
            {

                S_thread.Abort();
                //Cthread.Join();
                ServerShowMsg("Cthread close");
            }
            if (SR_thread != null)
            {
                SR_thread.Abort();
                ServerShowMsg("Cr_thread close");
            }
            ServerShowMsg("停止监听");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //textBox2.Clear();
            textBox2.Clear();
        }




        private void ClientMode_CheckedChanged(object sender, EventArgs e)
        {
            txt_ip.Enabled = true;
            txt_port.Enabled = true;
            bt_connect.Enabled = true;
            bt_disconnect.Enabled = true;
            textBox1.Enabled = true;
            bt_clear.Enabled = true;
            txt_msg.Enabled = true;
            bt_send.Enabled = true;

            tb_ip.Enabled = false;
            bt_connnect.Enabled = false;
            tb_port.Enabled = false;
            btn_StopListen.Enabled = false;
            textBox2.Enabled = false;
            button1.Enabled = false;
            txt_msgserver.Enabled = false;
            bt_sendserver.Enabled = false;
        }

        private void ServerMode_CheckedChanged(object sender, EventArgs e)
        {
            txt_ip.Enabled = false;
            txt_port.Enabled = false;
            bt_connect.Enabled = false;
            bt_disconnect.Enabled = false;
            textBox1.Enabled = false;
            bt_clear.Enabled = false;
            txt_msg.Enabled = false;
            bt_send.Enabled = false;

            tb_ip.Enabled = true;
            bt_connnect.Enabled = true;
            tb_port.Enabled = true;
            btn_StopListen.Enabled = true;
            textBox2.Enabled = true;
            button1.Enabled = true;
            txt_msgserver.Enabled = true;
            bt_sendserver.Enabled = true;
        }
        #endregion


        
        #region save/read parameter

        /// <summary>
        /// TCPIP通信参数存放地址
        /// </summary>
        public string ClientServerPath = System.AppDomain.CurrentDomain.BaseDirectory + @"SaveDir";

        /// <summary>
        /// TCPIP通信参数文件名
        /// </summary>
        public string FileName = "ClientServer parameter";

        private void Save_ClientServer_Par_Click(object sender, EventArgs e)
        {
            string[] ClientServer_Par=new string[10];

            //client or server
            if (this.ServerMode.Checked == true)
            {
                ClientServer_Par[0] = "模式：Server";
            }
            else if (this.ClientMode.Checked == true)
            {
                ClientServer_Par[0] = "模式：Client";
            }

            //client ip and port
            ClientServer_Par[1] = "client ip:"+ txt_ip.Text.ToString();
            ClientServer_Par[2] = "client port:" + txt_port.Text.ToString() ;

            //server ip and port
            ClientServer_Par[3] = "server ip:" + tb_ip.Text.ToString();
            ClientServer_Par[4] = "server port:" + tb_port.Text.ToString();

            for (int i = 0; i < 5;i++ )
            {
                SavaProcess(ClientServer_Par[i], "ClientServer parameter", i != 0, ClientServerPath);
                
            }
        }



        private void Read_ClientServer_Par(string path,string filename)
        {
            
            string[] CSPar_ReadResult = ReadTxtFile(path +@"\" +filename+".txt");

            //load parameter
            if (CSPar_ReadResult[0] != null)
            {
                ServerMode.Checked = (CSPar_ReadResult[0] == "模式：Server");
                ClientMode.Checked = (CSPar_ReadResult[0] == "模式：Client");
            }
            else
            {
                ServerMode.Checked = true;
            }


            //if (CSPar_ReadResult[0] != null) { ClientMode.Checked = (CSPar_ReadResult[0] == "模式：Client"); }

            if (CSPar_ReadResult[1] != null) { txt_ip.Text = CSPar_ReadResult[1].Split(':')[1]; }
            if (CSPar_ReadResult[2] != null) { txt_port.Text = CSPar_ReadResult[2].Split(':')[1]; }
            if (CSPar_ReadResult[3] != null) { tb_ip.Text = CSPar_ReadResult[3].Split(':')[1]; }
            if (CSPar_ReadResult[4] != null) { tb_port.Text = CSPar_ReadResult[4].Split(':')[1]; }

        }


        /// <summary>
        /// 保存数据data到文件的处理过程；
        /// </summary>
        /// <param name="data">需要保存的数据</param>
        /// <param name="filename">参数文本文件名</param>
        /// <param name="append">append 为true时，向文件追加文本；为False时，覆盖之前的文本重新开始写</param>
        /// <param name="filepath">保存到的路径</param>
        /// <returns>返回文件路径</returns>
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
        /// <param name="filePath">文件路径</param>
        /// <returns>返回获取到的字符串数组，每行代表数组一个元素</returns>
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

        private void debugtcp_Click(object sender, EventArgs e)
        {
            txt_ip.Enabled = true;
            txt_port.Enabled = true;
            bt_connect.Enabled = true;
            bt_disconnect.Enabled = true;
            textBox1.Enabled = true;
            bt_clear.Enabled = true;
            txt_msg.Enabled = true;
            bt_send.Enabled = true;

            tb_ip.Enabled = true;
            bt_connnect.Enabled = true;
            tb_port.Enabled = true;
            btn_StopListen.Enabled = true;
            textBox2.Enabled = true;
            button1.Enabled = true;
            txt_msgserver.Enabled = true;
            bt_sendserver.Enabled = true;

            server_stoplisten();

            client_disconnect();
        }

        public static double camera0X;
        public static double camera0Y;
        public static double camera0Angle;
        public static double camera1X;
        public static double camera1Y;
        public static double camera1Angle;
        public static double camera2X;
        public static double camera2Y;
        public static double camera2Angle;
        public static bool camera0Tool0Ok, camera0Tool1Ok, camera0Tool2Ok;
        public static bool camera1Tool0Ok, camera1Tool1Ok, camera1Tool2Ok;
        public static bool camera2Tool0Ok, camera2Tool1Ok, camera2Tool2Ok;

        /*引用方式
         
         
         if (false)
            {

                ClientServer clientserver = new ClientServer();
                string[] ReadResult = clientserver.ReadTxtFile(clientserver.ClientServerPath + @"\" + clientserver.FileName + ".txt");
                if (ReadResult[0] == "模式：Server")
                {
                    clientserver.server_startlisten();
                    ClientServer.server_senddata = "";
                    clientserver.server_sendmsg();

                }
                else if (ReadResult[0] == "模式：Client")
                {
                    clientserver.client_socketsendcreate();
                    if (ClientServer.client_receiveddata == null)
                    {
                        ClientServer.client_senddata = ClientServer.client_receiveddata + "qaz123QAZ!@#";
                    }
                    clientserver.client_send();

                }

                Thread cs_thread = new Thread(clientserver.clientcerver_communication);
                cs_thread.IsBackground = true;
                cs_thread.Start();
            }
         
         
        public void clientcerver_communication()
        {
            while (true)
            {
                if (client_receiveddata != null)
                {
                    client_senddata = client_receiveddata + "???";
                    client_send();
                    client_receiveddata = null;
                }

                if (server_receivedata != null)
                {
                    server_senddata = server_receivedata + "&&&";
                    server_sendmsg();
                    server_receivedata = null;
                }

                CogGraphicCollection gc = null;

                if (ClientServer.client_receiveddata == "TRIGGER0")
                {
                    camera0Tool0Ok = VisionFunc.ToolBlock_AllToolsRun(压缩机正面.Camera0toolblock[0], ref gc);
                    camera0Tool1Ok = VisionFunc.ToolBlock_AllToolsRun(压缩机正面.Camera0toolblock[1], ref gc);
                    camera0Tool2Ok = VisionFunc.ToolBlock_AllToolsRun(压缩机正面.Camera0toolblock[2], ref gc);

                    camera0X = Convert.ToDouble(压缩机正面.Camera0toolblock[1].Outputs["X1"].Value);
                    camera0Y = Convert.ToDouble(压缩机正面.Camera0toolblock[1].Outputs["Y1"].Value);
                    camera0Angle = Convert.ToDouble(压缩机正面.Camera0toolblock[1].Outputs["Angle1"].Value);

                    ClientServer.client_senddata = camera0Tool1Ok.ToString() + camera0X.ToString("f2").PadLeft(5, '0') + camera0Y.ToString("f2").PadLeft(5, '0') + camera0Angle.ToString("f2").PadLeft(5, '0');

                }



                if (ClientServer.client_receiveddata == "TRIGGER1")
                {
                    camera1Tool0Ok = VisionFunc.ToolBlock_AllToolsRun(压缩机反面.Camera1toolblock[0], ref gc);
                    camera1Tool1Ok = VisionFunc.ToolBlock_AllToolsRun(压缩机反面.Camera1toolblock[1], ref gc);
                    camera1Tool2Ok = VisionFunc.ToolBlock_AllToolsRun(压缩机反面.Camera1toolblock[2], ref gc);

                    camera1X = Convert.ToDouble(压缩机反面.Camera1toolblock[1].Outputs["X1"].Value);
                    camera1Y = Convert.ToDouble(压缩机反面.Camera1toolblock[1].Outputs["Y1"].Value);
                    camera1Angle = Convert.ToDouble(压缩机反面.Camera1toolblock[1].Outputs["Angle1"].Value);

                    ClientServer.client_senddata = camera1Tool1Ok.ToString() + camera1X.ToString("f2").PadLeft(5, '0') + camera1Y.ToString("f2").PadLeft(5, '0') + camera1Angle.ToString("f2").PadLeft(5, '0');
                }



                if (ClientServer.client_receiveddata == "TRIGGER2")
                {
                    camera2Tool0Ok = VisionFunc.ToolBlock_AllToolsRun(压缩机底座.Camera2toolblock[0], ref gc);
                    camera2Tool1Ok = VisionFunc.ToolBlock_AllToolsRun(压缩机底座.Camera2toolblock[1], ref gc);
                    camera2Tool2Ok = VisionFunc.ToolBlock_AllToolsRun(压缩机底座.Camera2toolblock[2], ref gc);

                    camera2X = Convert.ToDouble(压缩机底座.Camera2toolblock[1].Outputs["X1"].Value);
                    camera2Y = Convert.ToDouble(压缩机底座.Camera2toolblock[1].Outputs["Y1"].Value);
                    camera2Angle = Convert.ToDouble(压缩机底座.Camera2toolblock[1].Outputs["Angle1"].Value);


                    ClientServer.client_senddata = camera2Tool1Ok.ToString() + camera2X.ToString("f2").PadLeft(5, '0') + camera2Y.ToString("f2").PadLeft(5, '0') + camera2Angle.ToString("f2").PadLeft(5, '0');
                }
        }
            }
         * 
         * */
        

    }
}
