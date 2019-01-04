using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.Specialized;
using System.Windows.Forms;
using System.IO;
using System.Runtime.InteropServices;

namespace VisionproTool
{
    /// <summary>
    /// ini文件读写
    /// </summary>
    public class FilesIni
    {
        //用法
        //IniFiles ini1 = new IniFiles();
        //        ini1.FileName = Application.StartupPath + @"\ini1.ini";
        //        ini1.WriteString("A", "name", "leo");
        //        ini1.WriteInteger("B", "age", 65530);
        //        ini1.WriteBool("C", "xingbie", true);

        //        bool XINGBIE = ini1.ReadBool("C", "xingbie", false);
        //        int aa = ini1.ReadInteger("B", "age", 0);
        //        string st = ini1.ReadString("A", "name", "");
        //        ini1.WriteInteger("B", "height", 0);
        //        ini1.WriteInteger("B", "age", 30);
        //        ini1.DeleteKey("A", null);
        //        ini1.UpdateFile();

        ////读取test.ini文件中A 段落  键=姓名 的值
        // IniReadValue("A"，"姓名"，"f:/test.ini")
        ////读取test.ini文件中A 段落中所有值
        //IniReadValue("A"，null，"f:/test.ini")

        ////删除test.ini文件中A 段落中所有键(没有键，也就没有值了)
        //IniWrite("A"，null，null，"f:/test.ini")
        ////删除test.ini文件中所有段落
        //IniWrite(null，null，null，"f:/test.ini")

        /// <summary>
        /// 完整文件路径，包括文件名后缀
        /// </summary>
        public string FileName = Application.StartupPath + "\\Config.ini";//INI文件名
        //声明读写INI文件的API函数
        [DllImport("kernel32")]
        private static extern bool WritePrivateProfileString(string section, string key, string val, string filePath);
        [DllImport("kernel32")]
        private static extern int GetPrivateProfileString(string section, string key, string def, byte[] retVal, int size, string filePath);

        /// <summary> 
        /// 构造方法 
        /// </summary> 
        /// <param name="INIPath">文件路径</param> 
        public FilesIni(string INIPath)
        {
            FileName = INIPath;
        }

        /// <summary>
        /// 构造函数
        /// </summary>
        public FilesIni()
        {
        }

        /// <summary>
        /// 检查文件是否存在，暂不需要用，直接write可以创建
        /// 类的构造函数，传递INI文件名
        /// </summary>
        /// <param name="AFileName"></param>
        public void IniFilesExists(string AFileName)
        {
            // 判断文件是否存在
            FileInfo fileInfo = new FileInfo(AFileName);
            //Todo:搞清枚举的用法
            if ((!fileInfo.Exists))
            { //|| (FileAttributes.Directory in fileInfo.Attributes))
                ////文件不存在，建立文件
                //System.IO.StreamWriter sw = new System.IO.StreamWriter(AFileName, false, System.Text.Encoding.Default);
                //try
                //{
                //  sw.Write("#表格配置档案");
                //  sw.Close();
                //}

                //catch
                //{
                //  throw (new ApplicationException("Ini文件不存在"));
                //}

                MessageBox.Show("文件不存在", "错误");
            }
            //必须是完全路径，不能是相对路径
            FileName = fileInfo.FullName;
        }

        /// <summary>
        /// 写字符串
        /// </summary>
        /// <param name="Section">段落</param>
        /// <param name="Ident">变量名</param>
        /// <param name="Value">变量值</param>
        public void WriteString(string Section, string Ident, string Value)
        {
            
            if (!WritePrivateProfileString(Section, Ident, Value, FileName))
            {

                throw (new ApplicationException("写Ini文件出错"));
            }
        }
        /// <summary>
        /// 读取字符串
        /// </summary>
        /// <param name="Section">段落名</param>
        /// <param name="Ident">变量名</param>
        /// <param name="Default">读取异常时的默认值</param>
        /// <returns>字符串</returns>
        public string ReadString(string Section, string Ident, string Default)
        {
            Byte[] Buffer = new Byte[8192];
            int bufLen = GetPrivateProfileString(Section, Ident, Default, Buffer, Buffer.GetUpperBound(0), FileName);
            //必须设定0（系统默认的代码页）的编码方式，否则无法支持中文
            string s = Encoding.GetEncoding(0).GetString(Buffer); 
            s = s.Substring(0, bufLen);
            return s.Trim();
        }

        /// <summary>
        /// 读int数据
        /// </summary>
        /// <param name="Section">段落</param>
        /// <param name="Ident">变量名</param>
        /// <param name="Default">默认值</param>
        /// <returns>int型数值</returns>
        public int ReadInt(string Section, string Ident, int Default)
        {
            string intStr = ReadString(Section, Ident, Convert.ToString(Default));
            try
            {
                return Convert.ToInt32(intStr);

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return Default;
            }
        }

        /// <summary>
        /// 读double数据
        /// </summary>
        /// <param name="Section">段落</param>
        /// <param name="Ident">变量名</param>
        /// <param name="Default">默认值</param>
        /// <returns>int型数值</returns>
        public double ReadDouble(string Section, string Ident, double Default)
        {
            string intStr = ReadString(Section, Ident, Convert.ToString(Default));
            try
            {
                return Convert.ToDouble(intStr);

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return Default;
            }
        }

        /// <summary>
        /// 写整数
        /// </summary>
        /// <param name="Section">段落</param>
        /// <param name="Ident">变量名</param>
        /// <param name="Value">变量值</param>
        public void WriteInt(string Section, string Ident, int Value)
        {
            WriteString(Section, Ident, Value.ToString());
        }

        /// <summary>
        /// 写Double
        /// </summary>
        /// <param name="Section">段落</param>
        /// <param name="Ident">变量名</param>
        /// <param name="Value">变量值</param>
        public void WriteDouble(string Section, string Ident, double Value)
        {
            WriteString(Section, Ident, Value.ToString());
        }

        /// <summary>
        /// 读bool型值
        /// </summary>
        /// <param name="Section">段落</param>
        /// <param name="Ident">变量名</param>
        /// <param name="Default">默认值</param>
        /// <returns>true or false</returns>
        public bool ReadBool(string Section, string Ident, bool Default)
        {
            try
            {
                return Convert.ToBoolean(ReadString(Section, Ident, Convert.ToString(Default)));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return Default;
            }
        }

        /// <summary>
        /// 写bool值
        /// </summary>
        /// <param name="Section">段落</param>
        /// <param name="Ident">变量名</param>
        /// <param name="Value">bool值</param>
        public void WriteBool(string Section, string Ident, bool Value)
        {
            WriteString(Section, Ident, Convert.ToString(Value));
        }

        
        /// <summary>
        /// 从Ini文件中，将指定的Section名称中的所有Ident添加到列表中
        /// </summary>
        /// <param name="Section"></param>
        /// <param name="Idents"></param>
        public void ReadSection(string Section, StringCollection Idents)
        {
            Byte[] Buffer = new Byte[16384];
            //Idents.Clear();

            int bufLen = GetPrivateProfileString(Section, null, null, Buffer, Buffer.GetUpperBound(0),
             FileName);
            //对Section进行解析
            GetStringsFromBuffer(Buffer, bufLen, Idents);
        }

        /// <summary> 
        /// 验证文件是否存在 
        /// </summary> 
        /// <returns>布尔值</returns> 
        public bool ExistINIFile()
        {
            return File.Exists(FileName);
        } 

        /// <summary>
        /// 
        /// </summary>
        /// <param name="Buffer"></param>
        /// <param name="bufLen"></param>
        /// <param name="Strings"></param>
        private void GetStringsFromBuffer(Byte[] Buffer, int bufLen, StringCollection Strings)
        {
            Strings.Clear();
            if (bufLen != 0)
            {
                int start = 0;
                for (int i = 0; i < bufLen; i++)
                {
                    if ((Buffer[i] == 0) && ((i - start) > 0))
                    {
                        String s = Encoding.GetEncoding(0).GetString(Buffer, start, i - start);
                        Strings.Add(s);
                        start = i + 1;
                    }
                }
            }
        }
        
        /// <summary>
        /// 从Ini文件中，读取所有的Sections的名称
        /// </summary>
        /// <param name="SectionList"></param>
        public void ReadSections(StringCollection SectionList)
        {
            //Note:必须得用Bytes来实现，StringBuilder只能取到第一个Section
            byte[] Buffer = new byte[65535];
            int bufLen = 0;
            bufLen = GetPrivateProfileString(null, null, null, Buffer,
             Buffer.GetUpperBound(0), FileName);
            GetStringsFromBuffer(Buffer, bufLen, SectionList);
        }
        
        /// <summary>
        /// 读取指定的Section的所有Value到列表中
        /// </summary>
        /// <param name="Section"></param>
        /// <param name="Values"></param>
        public void ReadSectionValues(string Section, NameValueCollection Values)
        {
            StringCollection KeyList = new StringCollection();
            ReadSection(Section, KeyList);
            Values.Clear();
            foreach (string key in KeyList)
            {
                Values.Add(key, ReadString(Section, key, ""));

            }
        }
        ////读取指定的Section的所有Value到列表中，
        //public void ReadSectionValues(string Section, NameValueCollection Values,char splitString)
        //{　 string sectionValue;
        //　　string[] sectionValueSplit;
        //　　StringCollection KeyList = new StringCollection();
        //　　ReadSection(Section, KeyList);
        //　　Values.Clear();
        //　　foreach (string key in KeyList)
        //　　{
        //　　　　sectionValue=ReadString(Section, key, "");
        //　　　　sectionValueSplit=sectionValue.Split(splitString);
        //　　　　Values.Add(key, sectionValueSplit[0].ToString(),sectionValueSplit[1].ToString());

        //　　}
        //}
        
        /// <summary>
        /// 清除某个Section
        /// </summary>
        /// <param name="Section"></param>
        public void EraseSection(string Section)
        {
            //
            if (!WritePrivateProfileString(Section, null, null, FileName))
            {

                throw (new ApplicationException("无法清除Ini文件中的Section"));
            }
        }
        /// <summary>
        /// 删除某个Section下的键
        /// </summary>
        /// <param name="Section">段落</param>
        /// <param name="Ident">变量名，该值空则清除该段落</param>
        public void DeleteKey(string Section, string Ident)
        {
            WritePrivateProfileString(Section, Ident, null, FileName);
        }

        //Note:对于Win9X，来说需要实现UpdateFile方法将缓冲中的数据写入文件
        //在Win NT, 2000和XP上，都是直接写文件，没有缓冲，所以，无须实现UpdateFile
        //执行完对Ini文件的修改之后，应该调用本方法更新缓冲区。
        /// <summary>
        /// 无作用
        /// </summary>
        public void UpdateFile()
        {
            WritePrivateProfileString(null, null, null, FileName);
        }

        /// <summary>
        /// 检查某个Section下的某个键值是否存在
        /// </summary>
        /// <param name="Section">段落</param>
        /// <param name="Ident">变量名</param>
        /// <returns>true or false</returns>
        public bool ValueExists(string Section, string Ident)
        {
            //
            StringCollection Idents = new StringCollection();
            ReadSection(Section, Idents);
            return Idents.IndexOf(Ident) > -1;
        }

        //确保资源的释放
        ~FilesIni()
        {
            UpdateFile();
        }
    }
}
