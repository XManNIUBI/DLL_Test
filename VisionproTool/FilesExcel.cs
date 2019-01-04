using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Collections;
using System.Windows.Forms;

namespace VisionproTool
{
    
   public class FilesExcel
    {
       public FilesExcel()
       {
       }

        public void ExcWrite(string Camera_count, string Index, string OKNG, string RunTime, string ZuojierWidth, string ZuojierPosWidth, string YoujierWidth, string YoujierPosWidth, string LiangjierWidth, string L_Ruke, string R_Ruke)
        {
            // true表示追加到.xls文件内容的最后，如果是false表示，覆盖现有文件内容(后面的扩展名可以任意修改)

            string SMonth = DateTime.Now.Month.ToString("F0");
            string SDay = DateTime.Now.Day.ToString("F0");

            string i = DateTime.Now.ToString("HH:mm:ss");

            //AssemblyLibLFX.INIClass mIni = new AssemblyLibLFX.INIClass(CurrentFilePath + "\\config.dat");
            //string CurrentXinghao = mIni.ReadValue_string("Camera_Coordinate", "当前型号");
            string CurrentXinghao = null;
            string CurrentFilePath = null;
            bool cunzai = true;

            string CurrentDirectory = CurrentFilePath + "\\Model" + "\\" + CurrentXinghao + "\\" + Camera_count;
            if (!Directory.Exists(CurrentDirectory + "\\" + SMonth))
            {
                Directory.CreateDirectory(CurrentDirectory + "\\" + SMonth);
            }

            if (File.Exists(@CurrentDirectory + "\\" + SMonth + "\\" + Camera_count + "_" + SDay + ".xls"))
            {
                cunzai = false;

            }

            try
            {
                using (System.IO.StreamWriter sw = new System.IO.StreamWriter(@CurrentDirectory + "\\" + SMonth + "\\" + Camera_count + "_" + SDay + ".xls", true))
                {
                    if (cunzai)
                    {
                        sw.WriteLine("Time" + "\t" + "Index" + "\t" + "OKNG" + "\t" + "RunTime" + "\t" + "ZuojierWidth" + "\t" + "ZuojierPosWidth" + "\t" + "YoujierWidth" + "\t" + "YoujierPosWidth" + "\t" + "LiangjierWidth" + "\t" + "L_Ruke" + "\t" + "R_Ruke" + "\t");
                        sw.WriteLine(i + "\t" + Index + "\t" + OKNG + "\t" + RunTime + "\t" + ZuojierWidth + "\t" + ZuojierPosWidth + "\t" + YoujierWidth + "\t" + YoujierPosWidth + "\t" + LiangjierWidth + "\t" + L_Ruke + "\t" + R_Ruke + "\t");
                    }

                    else
                    {
                        sw.WriteLine(i + "\t" + Index + "\t" + OKNG + "\t" + RunTime + "\t" + ZuojierWidth + "\t" + ZuojierPosWidth + "\t" + YoujierWidth + "\t" + YoujierPosWidth + "\t" + LiangjierWidth + "\t" + L_Ruke + "\t" + R_Ruke + "\t");

                    }
                }
            }
            catch (System.Exception ex)
            {

            }



        }

        public static void ExcelWrite(string Camera_count, ArrayList ValueList, ArrayList ValueName)
        {
            string SMonth = DateTime.Now.Month.ToString("F0");
            string SDay = DateTime.Now.Day.ToString("F0");

            string i = DateTime.Now.ToString("HH:mm:ss");

            //AssemblyLibLFX.INIClass mIni = new AssemblyLibLFX.INIClass(CurrentFilePath + "\\config.dat");
            //string CurrentXinghao = mIni.ReadValue_string("Camera_Coordinate", "当前型号");
            FilesIni FI = new FilesIni();
            string CurrentModel = FI.ReadString("Camera_Coordinate", "当前型号","");
            //CurrentModel = null;
            string CurrentFilePath = Application.StartupPath;
            bool cunzai = true;

            string CurrentDirectory = CurrentFilePath + "\\Model" + "\\" + CurrentModel + "\\" + Camera_count;
            if (!Directory.Exists(CurrentDirectory + "\\" + SMonth))
            {
                Directory.CreateDirectory(CurrentDirectory + "\\" + SMonth);
            }

            if (File.Exists(@CurrentDirectory + "\\" + SMonth + "\\" + Camera_count + "_" + SDay + ".xls"))
            {
                cunzai = false;

            }

            try
            {
                // true表示追加到.xls文件内容的最后，如果是false表示，覆盖现有文件内容(后面的扩展名可以任意修改)
                using (System.IO.StreamWriter sw = new System.IO.StreamWriter(@CurrentDirectory + "\\" + SMonth + "\\" + Camera_count + "_" + SDay + ".xls", true))
                {
                    //if (cunzai)
                    //{
                    //    sw.WriteLine("Time" + "\t" + "Index" + "\t" + "OKNG" + "\t" + "RunTime" + "\t" + "ZuojierWidth" + "\t" + "ZuojierPosWidth" + "\t" + "YoujierWidth" + "\t" + "YoujierPosWidth" + "\t" + "LiangjierWidth" + "\t" + "L_Ruke" + "\t" + "R_Ruke" + "\t");
                    //    sw.WriteLine(i + "\t" + Index + "\t" + OKNG + "\t" + RunTime + "\t" + ZuojierWidth + "\t" + ZuojierPosWidth + "\t" + YoujierWidth + "\t" + YoujierPosWidth + "\t" + LiangjierWidth + "\t" + L_Ruke + "\t" + R_Ruke + "\t");
                    //}

                    //else
                    //{
                    //    sw.WriteLine(i + "\t" + Index + "\t" + OKNG + "\t" + RunTime + "\t" + ZuojierWidth + "\t" + ZuojierPosWidth + "\t" + YoujierWidth + "\t" + YoujierPosWidth + "\t" + LiangjierWidth + "\t" + L_Ruke + "\t" + R_Ruke + "\t");

                    //}

                    if (cunzai)
                    {
                        for (int j = 0; j < ValueName.Count; j++)
                        {

                            if (j == ValueName.Count - 1)
                            {
                                sw.WriteLine(ValueName[j] + "\t");
                            }
                            else
                            {
                                sw.Write(ValueName[j] + "\t");
                            }
                        }
                    }

                        sw.Write(i + "\t");
                        for (int j = 0; j < ValueList.Count; j++)
                        {

                            if (j == ValueList.Count - 1)
                            {
                                sw.WriteLine(ValueList[j] + "\t");
                            }
                            else
                            {
                                sw.Write(ValueList[j] + "\t");
                            }
                        }
                    
                    
                }
            }
            catch (System.Exception ex)
            {

            }



        }
    }
}
