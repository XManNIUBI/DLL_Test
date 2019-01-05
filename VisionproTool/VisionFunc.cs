using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Cognex.VisionPro;
using Cognex.VisionPro.CalibFix;
using Cognex.VisionPro.Dimensioning;
using Cognex.VisionPro.Caliper;
using Cognex.VisionPro.PMAlign;
using Cognex.VisionPro.ToolGroup;
using Cognex.VisionPro.ToolBlock;
using Cognex.VisionPro.Display;
using System.IO;
using System.Windows.Forms;
using System.Runtime.Serialization.Formatters.Binary;
using Cognex.VisionPro.ImageFile;
using System.Drawing;
using Cognex.VisionPro.Blob;
using Cognex.VisionPro.TwoDSymbol;
using System.Runtime.InteropServices;
using System.Collections;
using System.Runtime.CompilerServices;

namespace VisionproTool
{


    /// <summary>
    /// 视觉工具函数类
    /// </summary>
    public class VisionFunc
    {

        /// <summary>
        /// 显示VisionPro工具
        /// </summary>
        /// <param name="toolforshow">需要显示的工具</param>
        public void ShowVisionTool(ICogTool toolforshow)
        {

            if (toolforshow is CogAcqFifoTool)
            {
                Form_CogAcqFifoTool1 form = new Form_CogAcqFifoTool1();
                form.formtool = toolforshow as CogAcqFifoTool;
                form.ShowDialog();
            }
            else if (toolforshow is CogCalibCheckerboardTool)
            {
                Form_CogCalibCheckerboardTool form = new Form_CogCalibCheckerboardTool();
                form.formtool = toolforshow as CogCalibCheckerboardTool;
                form.ShowDialog();
            }
            else if (toolforshow is CogCalibNPointToNPointTool)
            {
                Form_CogCalibNPointToNPointTool form = new Form_CogCalibNPointToNPointTool();
                form.formtool = toolforshow as CogCalibNPointToNPointTool;
                form.ShowDialog();
            }
            else if (toolforshow is CogCreateSegmentTool)
            {
                Form_CogCreateSegmentTool form = new Form_CogCreateSegmentTool();
                form.formtool = toolforshow as CogCreateSegmentTool;
                form.ShowDialog();
            }
            else if (toolforshow is CogFindCircleTool)
            {
                Form_CogFindCircleTool form = new Form_CogFindCircleTool();
                form.formtool = toolforshow as CogFindCircleTool;
                form.ShowDialog();
            }
            else if (toolforshow is CogPMAlignTool)
            {
                Form_CogPMAlignTool form = new Form_CogPMAlignTool();
                form.formtool = toolforshow as CogPMAlignTool;
                form.ShowDialog();
            }
            else if (toolforshow is CogToolGroup)
            {
                Form_CogToolGroup form = new Form_CogToolGroup();
                form.formtool = toolforshow as CogToolGroup;
                form.ShowDialog();
            }
            else if (toolforshow is CogToolBlock)
            {
                Form_CogToolBlock form = new Form_CogToolBlock();
                form.formtool = toolforshow as CogToolBlock;
                form.ShowDialog();
            }
            else if (toolforshow is CogBlobTool)
            {
                Form_CogBlobTool form = new Form_CogBlobTool();
                form.formtool = toolforshow as CogBlobTool;
                form.ShowDialog();
            }
            else if (toolforshow is CogFindLineTool)
            {
                Form_CogFindLineTool form = new Form_CogFindLineTool();
                form.formtool = toolforshow as CogFindLineTool;
                form.ShowDialog();
            }
            else if (toolforshow is CogCaliperTool)
            {
                Form_CogCaliperTool form = new Form_CogCaliperTool();
                form.formtool = toolforshow as CogCaliperTool;
                form.ShowDialog();
            }
            else if (toolforshow is CogImageFileTool)
            {
                Form_CogImageFileTool form = new Form_CogImageFileTool();
                form.formtool = toolforshow as CogImageFileTool;
                form.ShowDialog();
            }

        }

        /// <summary>
        /// 工具块运行//
        /// </summary>
        /// <param name="toolblock">要运行的工具块</param>
        /// <param name="gc">gc</param>
        /// <returns>是否运行成功</returns>
        public static bool ToolBlock_AllToolsRun(CogToolBlock toolblock, ref CogGraphicCollection gc)
        {
            if ((toolblock == null) || (gc == null))
            {
                return false;
            }
            toolblock.Run();
            foreach (ICogTool tool in toolblock.Tools)
            {
                //CogGraphicCollection graphics = AssemblyLib.VisionTools.Get_ToolResultGC(tool);//使用叶工类库
                CogGraphicCollection graphics = Get_ToolResultGC(tool);//1 Get_ToolResultGC1(tool)
                if ((graphics != null) && (graphics.Count != 0))
                {
                    for (int i = 0; i < graphics.Count; i++)
                    {
                        gc.Add(graphics[i]);
                    }
                }
            }
            bool flag = false;
            switch (toolblock.RunStatus.Result)
            {
                case CogToolResultConstants.Accept:
                    flag = true;
                    break;
            }
            return flag;
        }


        /// <summary>
        /// 获取GC
        /// </summary>
        /// <param name="Tool"></param>
        /// <returns></returns>
        public static CogGraphicCollection Get_ToolResultGC(ICogTool Tool)
        {
            CogGraphicCollection content=null;
            CogGraphicCollection graphics = new CogGraphicCollection();
            switch (Tool.GetType().Name)
            {
                case "CogPMAlignTool":
                    {
                        CogPMAlignTool tool = (CogPMAlignTool)Tool;
                        if (((Tool != null) && (tool.Results != null)) && (tool.Results.Count >= 1))
                        {
                            for (int i = 0; i < tool.Results.Count; i++)
                            {
                                graphics.Add(tool.Results[i].CreateResultGraphics(CogPMAlignResultGraphicConstants.CoordinateAxes | CogPMAlignResultGraphicConstants.MatchFeatures));
                            }
                        }
                        return graphics;
                    }
                case "CogCaliperTool":
                    {
                        try
                        {
                            CogCaliperTool tool4=(CogCaliperTool)Tool;
                            content = (CogGraphicCollection)tool4.CreateLastRunRecord().SubRecords["InputImage"].SubRecords["FoundEdges"].Content;
                            for (int m = 0; m < content.Count;m++ )
                            {
                                graphics.Add(content[m]);
                            }
                        }
                        catch(Exception)
                        { }
                        return content;
                    }
                case "CogFindCircleTool":
                    {
                        CogFindCircleTool tool3 = (CogFindCircleTool)Tool;
                        try
                        {

                            content = (CogGraphicCollection)tool3.CreateLastRunRecord().SubRecords["CompositeResultGraphics"].Content;
                            for (int k = 0; k < content.Count; k++)
                            {
                                graphics.Add(content[k]);
                            }
                        }
                        catch
                        { }

                        if (tool3.Results != null)
                        {
                            graphics.Add(tool3.Results.GetCircle());
                        }
                        return graphics;
                    }
                case "CogFindLineTool":
                    {
                        CogFindLineTool tool3 = (CogFindLineTool)Tool;
                        try
                        {
                            content = (CogGraphicCollection)tool3.CreateLastRunRecord().SubRecords["CompositeResultGraphics"].Content;
                            for (int k = 0; k < content.Count; k++)
                            {
                                graphics.Add(content[k]);
                            }
                        }
                        catch
                        { }
                        if (tool3.Results != null)
                        {
                            graphics.Add(tool3.Results.GetLineSegment());//获取线段，也可以获取线
                        }
                        return graphics;
                    }
                case "CogFitCircleTool":
                    {
                        CogFitCircleTool tool3 = (CogFitCircleTool)Tool;
                        try
                        {
                            content = (CogGraphicCollection)tool3.CreateLastRunRecord().SubRecords["CompositeResultGraphics"].Content;
                            for (int k = 0; k < content.Count; k++)
                            {
                                graphics.Add(content[k]);
                            }
                        }
                        catch
                        { }
                        if (tool3.Result != null)
                        {
                            graphics.Add(tool3.Result.GetCircle());
                        }
                        return graphics;
                    }
                case "CogBlobTool":
                    {
                        try
                        {
                            CogBlobTool cogBlobTool = (CogBlobTool)Tool;
                            //content = (CogGraphicCollection)cogBlobTool.CreateLastRunRecord().get_SubRecords().get_Item("InputImage").get_SubRecords().get_Item("CompositeResultGraphics").get_Content();//可用于研究SubRecords["CompositeResultGraphics"]总共有哪些字符串
                            content = (CogGraphicCollection)cogBlobTool.CreateLastRunRecord().SubRecords["InputImage"].SubRecords["CompositeResultGraphics"].Content;
                            for (int m = 0; m < content.Count; m++)
                            {
                                graphics.Add(content[m]);
                            }
                            //result = graphics;
                            return graphics;
                        }
                        catch (Exception)
                        {
                            //result = cogGraphicCollection;
                            return graphics;
                        }
                        break;
                    }
                case "CogCreateSegmentTool":
                    {
                        try
                        {
                        
                            CogLineSegment outputSegment = ((CogCreateSegmentTool)Tool).GetOutputSegment();
                            if (outputSegment != null)
                            {
                                graphics.Add(outputSegment);
                            }
                            //result = cogGraphicCollection;
                            return graphics;
                        }
                        catch (Exception)
                        {
                            //result = cogGraphicCollection;
                            return graphics;
                        }
                    }
                case "Cog2DSymbolTool":
                    {
                        try
                        {
                            Cog2DSymbolTool cogIDTool = (Cog2DSymbolTool)Tool;
                            content = (CogGraphicCollection)cogIDTool.CreateLastRunRecord().SubRecords["InputImage"].SubRecords["CompositeResultGraphics"].Content;
                            for (int m = 0; m < content.Count; m++)
                            {
                                graphics.Add(content[m]);
                            }
                            //result = cogGraphicCollection;
                            return graphics;
                        }
                        catch (Exception)
                        {
                            //result = cogGraphicCollection;
                            return graphics;
                        }
                    }
                case "CogDistanceSegmentLineTool":
                    {
                        try
                        {
                      
                            CogDistanceSegmentLineTool cogDistanceSegmentLineTool = (CogDistanceSegmentLineTool)Tool;
                            CogLineSegment segment = cogDistanceSegmentLineTool.Segment;
                            if (segment != null)
                            {
                                graphics.Add(segment);
                            }
                            CogLine line = cogDistanceSegmentLineTool.Line;
                            if (line != null)
                            {
                                graphics.Add(line);
                            }
                            //result = cogGraphicCollection;
                            return graphics;
                        }
                        catch (Exception)
                        {
                            //result = cogGraphicCollection;
                            return graphics;
                        }
                    }
                case "CogDistancePointLineTool":
                    {
                        try
                        {

                            CogDistancePointLineTool cogDistancePointLineTool = (CogDistancePointLineTool)Tool;

                            for (int i = 0; i < cogDistancePointLineTool.CreateLastRunRecord().SubRecords["InputImage"].SubRecords.Count; i++)
                            {

                               graphics.Add((ICogGraphic)cogDistancePointLineTool.CreateLastRunRecord().SubRecords["InputImage"].SubRecords[i].Content);

                            }

                            //content = (CogGraphicCollection)cogDistancePointLineTool.CreateLastRunRecord().SubRecords["CompositeResultGraphics"].Content;
                            content = (CogGraphicCollection)cogDistancePointLineTool.CreateLastRunRecord().SubRecords["CompositeResultGraphics"].Content;
                            for (int m = 0; m < content.Count; m++)
                            {
                                graphics.Add(content[m]);
                            }
                            CogLine line = cogDistancePointLineTool.Line;
                            if (line != null)
                            {
                                graphics.Add(line);
                            }
                            //result = cogGraphicCollection;
                            return graphics;
                        }
                        catch (Exception)
                        {
                            //result = cogGraphicCollection;
                            return graphics;
                        }
                    }
                case "CogIntersectLineLineTool":
                    {
                        try
                        {
                        
                            CogIntersectLineLineTool cogIntersectLineLineTool = (CogIntersectLineLineTool)Tool;
                            CogLine lineA = cogIntersectLineLineTool.LineA;
                            if (lineA != null)
                            {
                                graphics.Add(lineA);
                            }
                            CogLine lineB = cogIntersectLineLineTool.LineB;
                            if (lineB != null)
                            {
                                graphics.Add(lineB);
                            }
                            //result = cogGraphicCollection;
                            return graphics;
                        }
                        catch (Exception)
                        {
                            //result = cogGraphicCollection;
                            return graphics;
                        }
                    }
                //case "CogToolBlock":
                //    {
                //        content = (CogGraphicCollection)myTG.CreateLastRunRecord().SubRecords["OutputImage"].;
                //        for (int k = 0; k < content.Count; k++)
                //        {
                //            graphics.Add(content[k]);
                //        }
                //        return graphics;
                //    }

                default:
                    return null;

            }
        }

        /// <summary>
        /// VPP文件工具组
        /// </summary>
        public static CogToolGroup myTG = null;
        /// <summary>
        /// 以相机为单位的工具组,默认最大为5
        /// </summary>
        public static CogToolGroup[] CameraTG = new CogToolGroup[5];
        /// <summary>
        /// 表示相机工具组下一级工具。（x，y）：x为相机工具组编号，y为工具组内工具或工具块编号。x、y默认最大为5
        /// </summary>
        public static ICogTool[,] TGIcogTool = new ICogTool[5, 5];
        /// <summary>
        /// 工具块下一级工具。（x，y，z），x为相机工具组编号，y为工具组内工具或工具块编号，z为工具块下工具编号。x、y默认最大为5,z默认最大为10
        /// </summary>
        public static ICogTool[,,] TBICogTool =new ICogTool[5,5,30];
        /// <summary>
        /// VPP文件路径
        /// </summary>
        public static string VPPPath_Name = Application.StartupPath + "\\Vision.vpp";

        /// <summary>
        /// 加载视觉工具并显示进度
        /// </summary>
        public void LoadVisionProgressFunc()
        {
            LoadVisionProgress lvt = new LoadVisionProgress();
            lvt.ShowDialog();
        }


        /// <summary>
        /// 载入视觉文件
        /// </summary>
        public void LoadVisionFile()
        {

            if (!File.Exists(VPPPath_Name))
            {
                MessageBox.Show(VPPPath_Name + "未找到视觉文件", "错误");
                return;
            }

            ICogTool tools = null;

            try
            {
                tools = (ICogTool)CogSerializer.LoadObjectFromFile(VPPPath_Name, typeof(BinaryFormatter), CogSerializationOptionsConstants.Minimum);
                if (tools == null)
                {
                    tools = (ICogTool)CogSerializer.LoadObjectFromFile(VPPPath_Name, typeof(BinaryFormatter), CogSerializationOptionsConstants.Minimum);
                    if (tools == null)
                    {
                        MessageBox.Show("未能成功加载视觉文件","载入失败");
                        return;
                    }
                }

                myTG = (CogToolGroup)tools;

                if (myTG != null)
                {

                    //取出相机工具组
                    int i=0;
                    foreach(ICogTool ict in myTG.Tools )
                    {
                        CameraTG[i] = (CogToolGroup)ict;
                       
                    
                        //取出下一级工具
                        int j = 0;
                        foreach (ICogTool tgict in CameraTG[i].Tools)
                        {
                            TGIcogTool[i, j] = tgict;

                            if ( (TGIcogTool[i, j] != null) && (TGIcogTool[i, j] is CogToolBlock))
                            {
                                int k=0;
                                foreach (ICogTool tbict in (TGIcogTool[i, j] as CogToolBlock).Tools)
                                {
                                    TBICogTool[i, j, k] = tbict;
                                    k++;
                                }
                            }
                            j++;       
                        }
                        i++;
                    }
                    } 
                }


            
            catch (System.Exception e)
            {
                MessageBox.Show(e.Message + "载入失败，请重新打开", "错误");
                //return false;
            }
        }

        /// <summary>
        /// 从工具组或工具块获取下一级工具，使用字符串寻找
        /// </summary>
        /// <param name="grouporblock">ToolGroup or ToolBlock</param>
        /// <param name="toolname">工具名称</param>
        /// <returns>返回基类工具</returns>
        public static ICogTool Get_ToolsItem(ICogTool grouporblock, string toolname)
        {
            ICogTool tool = null;
            if (grouporblock == null)
            {
                return null;
            }
            try
            {
                if (grouporblock is CogToolBlock)
                {
                    tool = (grouporblock as CogToolBlock).Tools[toolname];
                }
                if (grouporblock is CogToolGroup)
                {
                    tool = (grouporblock as CogToolGroup).Tools[toolname];
                }
            }
            catch
            { }
            return tool;
        }

        /// <summary>
        /// 将像机器人坐标素值转换为标定后的机器人坐标
        /// </summary>
        /// <param name="NPointToNPoint">标定工具</param>
        /// <param name="in_x">像素值X</param>
        /// <param name="in_y">像素值Y</param>
        /// <param name="out_x">输出机器人坐标X</param>
        /// <param name="out_y">输出机器人坐标Y</param>
        /// <returns>返回值表示是否转换成功</returns>
        public static bool CameraSpaceToMachineSpace(CogCalibNPointToNPointTool NPointToNPoint, double in_x,double in_y,out double out_x,out double out_y)
        {
            out_x = 0;
            out_y = 0;

            if (NPointToNPoint==null)
            {
                return false;
            }

            if (NPointToNPoint.Calibration.Calibrated==false)
            {
                return false;
            }

            if (NPointToNPoint.InputImage == null || NPointToNPoint.OutputImage == null)
            {
                return false;
            }

            string InputNamespace = NPointToNPoint.InputImage.SelectedSpaceName;
            string OutputNamespace = NPointToNPoint.OutputImage.SelectedSpaceName;

            ICogTransform2D transform = NPointToNPoint.OutputImage.GetTransform(OutputNamespace,InputNamespace);
            transform.MapPoint(in_x,in_y,out out_x,out out_y);

            return true;
        }

        #region 保存文件
        /// <summary>
        /// 将工具保存到路径
        /// </summary>
        /// <param name="tool">需要保存的工具</param>
        /// <param name="filepath">保存到的路径</param>
        /// <returns>是否操作成功</returns>
        public static bool SaveObjectToFile(ICogTool tool, string filepath)
        {
            if (tool == null)
            {
                return false;
            }

            try
            {
                CogSerializer.SaveObjectToFile(tool, filepath, typeof(BinaryFormatter), CogSerializationOptionsConstants.All);
            }
            catch
            {
                return false;
            }
            return true;
        }

        /// <summary>
        /// 指定路径保存
        /// </summary>
        /// <param name="filename">保存到的路径</param>
        /// <returns>是否操作成功</returns>
        public static bool SaveVisionData(string filename)
        {
            if (myTG == null)
            {
                return false;
            }

            try
            {
                SaveObjectToFile(myTG, filename);
            }
            catch
            {
                return false;
            }

            return true;
        }
        #endregion

        #region 实时画面控制
        /// <summary>
        /// 开始实时函数
        /// </summary>
        /// <param name="displayedit">实时画面显示控件</param>
        /// <param name="acqfifotool">图像源</param>
        public static void StartDisplay(CogDisplay displayedit, CogAcqFifoTool acqfifotool)
        {
            try
            {
                displayedit.StaticGraphics.Clear();
                displayedit.InteractiveGraphics.Clear();
                ICogAcqFifo macqfifo = acqfifotool.Operator;
                displayedit.StartLiveDisplay(macqfifo, true);

                acqfifotool.Run();
                displayedit.Image = acqfifotool.OutputImage;
                displayedit.Fit(true);
            }
            catch (Exception e)
            {
                System.Windows.Forms.MessageBox.Show(e.Message);
            }

        }

        /// <summary>
        /// 停止实时函数
        /// </summary>
        /// <param name="displayedit">实时画面显示控件</param>
        public static void StopDisplay(CogDisplay displayedit)
        {
            displayedit.StopLiveDisplay();
        }

        #endregion

        /// <summary>
        /// 按小时保存图片
        /// </summary>
        /// <param name="_cogimage">原图</param>
        /// <param name="_Display">带GC图片</param>
        /// <param name="Camera_count">图片来源于哪个相机</param>
        public void SaveDisplayImageHour(ICogImage _cogimage, CogDisplay _Display, string Camera_count)
        {
            //判断文件夹是否存在？
            string SMonth = DateTime.Now.Month.ToString("F0");
            string Image_SHour_file = DateTime.Now.ToString("HH");
            //临时
            string CurrentFilePath = null;
            string CurrentXinghao = null;

            //AssemblyLib.INIClass mIni = new AssemblyLib.INIClass(CurrentFilePath + "\\config.dat");
  
            //string CurrentXinghao = mIni.ReadValue_string("Camera_Coordinate", "当前型号");

            string CurrentDirectory = CurrentFilePath + "\\Model" + "\\" + CurrentXinghao + "\\" + Camera_count;
            if (!Directory.Exists(CurrentDirectory + "\\" + SMonth + "\\" + Image_SHour_file))
            {
                Directory.CreateDirectory(CurrentDirectory + "\\" + SMonth + "\\" + Image_SHour_file);
            }

            CogImageFile imagefile = new CogImageFile();
            string filename_Temp = "";
            string filename_Temp1 = "";
            if (_Display.Image != null && _cogimage != null)
            {
                string filename = "";
                try
                {
                    DateTime now = DateTime.Now;
                    filename_Temp = "Image_" + string.Format("{0:d}", now).Replace("/", "_")
                        + " " + now.ToLongTimeString().Replace(":", "_") + ".bmp";
                    filename = CurrentDirectory + "\\" + SMonth + "\\" + Image_SHour_file + "\\" + filename_Temp;

                    Image aaa = _Display.CreateContentBitmap(CogDisplayContentBitmapConstants.Image, null, 0);
                    _Display.CreateContentBitmap(CogDisplayContentBitmapConstants.Image, null, 0).Save(filename);

                    filename_Temp1 = filename_Temp;


                    filename_Temp = "YT_" + "Image_" + string.Format("{0:d}", now).Replace("/", "_")
                        + " " + now.ToLongTimeString().Replace(":", "_") + ".bmp";
                    imagefile.Open(CurrentDirectory + "\\" + SMonth + "\\" + Image_SHour_file + "\\" + filename_Temp, CogImageFileModeConstants.Write);
                    imagefile.Append(_cogimage);
                    imagefile.Close();

                    StreamWriter sw = new StreamWriter(@"E:\图片路径.txt", false);
                    sw.WriteLine(CurrentDirectory + "\\" + SMonth + "\\" + Image_SHour_file + "\\" + filename_Temp1);
                    sw.Close();

                }
                catch (System.Exception e)
                {

                }
                return;
            }
            else
            {
                return;
            }

            return;

        }
    }
}
