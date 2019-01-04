using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VisionproTool
{
    public class FilesTxt
    {

        public FilesTxt()
        {

        }

        public string SerialPath = System.AppDomain.CurrentDomain.BaseDirectory + @"SaveDir";
        public string SerialPar_FileName = "Serial Port parameter";

        //private void save_serial_par_Click(object sender, EventArgs e)
        //{
        //    string[] SerialPort_Par = new string[10];


        //    if (this.radioButton_Hex.Checked == true)
        //    {
        //        SerialPort_Par[0] = "编码方式：Hex";
        //    }
        //    else if (this.radioButton_ASCII.Checked == true)
        //    {
        //        SerialPort_Par[0] = "编码方式：ASCII";
        //    }
        //    else if (this.radioButton_UTF8.Checked == true)
        //    {
        //        SerialPort_Par[0] = "编码方式：UTF8";
        //    }
        //    else if (this.radioButton_Unicode.Checked == true)
        //    {
        //        SerialPort_Par[0] = "编码方式：Unicode";
        //    }


        //    SerialPort_Par[1] = "Serial port:" + comboBox_Port.Text.ToString();
        //    SerialPort_Par[2] = "Serial stopbit:" + comboBox_StopBits.Text.ToString();


        //    SerialPort_Par[3] = "Serial baudrate:" + comboBox_BaudRate.Text.ToString();
        //    SerialPort_Par[4] = "Serial paritycheck:" + comboBox_CheckBits.Text.ToString();
        //    SerialPort_Par[5] = "Serial databit:" + comboBox_DataBits.Text.ToString();

        //    for (int i = 0; i < 8; i++)
        //    {
        //        SavaProcess(SerialPort_Par[i], "SerialPort parameter", i != 0, SerialPath);

        //    }
        //}



        //private void Read_ClientServer_Par(string path, string filename)
        //{

        //    string[] SerialPar_ReadResult = ReadTxtFile(path + @"\" + filename + ".txt");

        //    //load parameter
        //    if (SerialPar_ReadResult[0] != null)
        //    {
        //        this.radioButton_Hex.Checked = (SerialPar_ReadResult[0] == "编码方式：Hex");
        //        this.radioButton_ASCII.Checked = (SerialPar_ReadResult[0] == "编码方式：ASCII");
        //        this.radioButton_UTF8.Checked = (SerialPar_ReadResult[0] == "编码方式：UTF8");
        //        this.radioButton_Unicode.Checked = (SerialPar_ReadResult[0] == "编码方式：Unicode");
        //    }
        //    else
        //    {
        //        this.radioButton_ASCII.Checked = true;
        //    }


        //    //if (SerialPar_ReadResult[0] != null) { ClientMode.Checked = (SerialPar_ReadResult[0] == "模式：Client"); }

        //    if (SerialPar_ReadResult[1] != null) { comboBox_Port.Text = SerialPar_ReadResult[1].Split(':')[1]; }
        //    if (SerialPar_ReadResult[2] != null) { comboBox_StopBits.Text = SerialPar_ReadResult[2].Split(':')[1]; }
        //    if (SerialPar_ReadResult[3] != null) { comboBox_BaudRate.Text = SerialPar_ReadResult[3].Split(':')[1]; }
        //    if (SerialPar_ReadResult[4] != null) { comboBox_CheckBits.Text = SerialPar_ReadResult[4].Split(':')[1]; }
        //    if (SerialPar_ReadResult[5] != null) { comboBox_DataBits.Text = SerialPar_ReadResult[5].Split(':')[1]; }

        //}

        /// <summary>
        /// 保存数据data到文件的处理过程；
        /// </summary>
        /// <param name="data"></param>
        /// <param name="filename"></param>不带格式后缀
        /// <param name="append"></param>append 为true时，向文件追加文本
        /// <param name="filepath"></param>不带“\文件名”
        /// <returns></returns>
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
        /// <param name="args"></param>
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

    }
}
