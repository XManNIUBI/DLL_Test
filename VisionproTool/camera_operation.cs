using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Cognex.VisionPro;
using Cognex.VisionPro.FGGigE;
//using Cognex.VisionPro.Interop;

namespace VisionproTool
{
    public class camera_operation
    {
        #region 获得相机信息方法
        /// <summary>
        /// 公有静态方法，查找单个相机。例如“Basler”
        /// </summary>
        public static ICogFrameGrabber FindFrameGrabber(string CameraType)
        {
            CogFrameGrabberGigEs frameGrabbers = new CogFrameGrabberGigEs();
            foreach (ICogFrameGrabber fg in frameGrabbers)
            {
                if (fg.Name.Contains(CameraType))
                {
                    return (fg);
                }
            }
            return null;
        }
        /// <summary>
        /// 公有静态方法，查找相机列表。
        /// </summary>
        public static void FindFrameGrabber(List<ICogFrameGrabber> List)
        {
            CogFrameGrabberGigEs frameGrabbers = new CogFrameGrabberGigEs();
            foreach (ICogFrameGrabber fg in frameGrabbers)
            {
                if (fg.Name.Contains("Basler"))
                {
                    List.Add(fg);
                }
            }
        }
        /// <summary>
        /// 公有静态方法，创建相机初始化工具获取信息。
        /// </summary>
        public static ICogAcqFifo GetCogAcqFifo(int index)
        {
            List<ICogFrameGrabber> list = new List<ICogFrameGrabber>();
            FindFrameGrabber(list);
            ICogFrameGrabber frameGrabbers = list[index];
            ICogAcqFifo mCogAcqFifo = null; ;

            if (frameGrabbers == null)
            {
                mCogAcqFifo = null;
                return mCogAcqFifo;
            }
            if (frameGrabbers.Name.Contains("gm"))
            {
                mCogAcqFifo = frameGrabbers.CreateAcqFifo("Generic GigEVision (Mono)", CogAcqFifoPixelFormatConstants.Format8Grey, 0, false);
            }
            else if (frameGrabbers.Name.Contains("gc"))
            {
                mCogAcqFifo = frameGrabbers.CreateAcqFifo("Generic GigEVision (Bayer Color)", CogAcqFifoPixelFormatConstants.Format32RGB, 0, false);
            }
            return mCogAcqFifo;
        }
        /// <summary>
        /// 公有静态方法，查找相机数量。
        /// </summary>
        public static int GetAllCCDCount()
        {
            CogFrameGrabberGigEs frameGrabbers = new CogFrameGrabberGigEs();

            int count = frameGrabbers.Count;

            return count;
        }
        /// <summary>
        /// 公有静态方法，获得CCD曝光exposure。
        /// </summary>
        public static double GetCurCCDExposure(ICogAcqFifo acqFifo)
        {
            ICogAcqExposure exposureParams = acqFifo.OwnedExposureParams;
            double exposure;
            if (exposureParams == null)
            {
                exposure = 0;
            }
            else
            {
                exposure = exposureParams.Exposure;
            }
            return exposure;
        }
        /// <summary>
        /// 公有静态方法，获得CCD亮度light。
        /// </summary>
        public static double GetCurCCDLight(ICogAcqFifo acqFifo)
        {
            ICogAcqLight lightParams = acqFifo.OwnedLightParams;
            double light;
            if (lightParams == null)
            {
                light = 0;
            }
            else
            {
                light = lightParams.LightPower;
            }
            return light;
        }

        /// <summary>
        /// 公有静态方法，获得CCD对比度Contrast。
        /// </summary>
        public static double GetCurCCDContrast(ICogAcqFifo acqFifo)
        {
            ICogAcqContrast ContrastParams = acqFifo.OwnedContrastParams;
            double Contrast;
            if (ContrastParams == null)
            {
                Contrast = 0;
            }
            else
            {
                Contrast = ContrastParams.Contrast;
            }
            return Contrast;
        }
        /// <summary>
        /// 公有静态方法，获得CCD序列号SN
        /// </summary>
        public static string GetCurCCDSN(ICogAcqFifo acqFifo)
        {
            string SerialNumber;
            if (acqFifo == null)
            {
                SerialNumber = "";
            }
            else
            {
                SerialNumber = acqFifo.FrameGrabber.SerialNumber;
            }
            return SerialNumber;
        }
        /// <summary>
        /// 公有静态方法，获得CCD名称Name
        /// </summary>
        public static string GetCurCCDName(ICogAcqFifo acqFifo)
        {
            string CCDName;
            if (acqFifo == null)
            {
                CCDName = "";
            }
            else
            {
                CCDName = acqFifo.FrameGrabber.Name;
            }
            return CCDName;
        }
        /// <summary>
        /// 公有静态方法，获得CCD名称IP
        /// </summary>
        public static string GetCurCCDIP(ICogAcqFifo acqFifo)
        {
            string IP;
            if (acqFifo == null)
            {
                IP = "0.0.0.0";
            }
            else
            {
                IP = acqFifo.FrameGrabber.OwnedGigEAccess.CurrentIPAddress;
            }
            return IP;
        }
        /// <summary>
        /// 公有静态方法，获得CCD名称HostIP
        /// </summary>
        public static string GetCurCCDHostIP(ICogAcqFifo acqFifo)
        {
            string HostIP;
            if (acqFifo == null)
            {
                HostIP = "0.0.0.0";
            }
            else
            {
                HostIP = acqFifo.FrameGrabber.OwnedGigEAccess.HostIPAddress;
            }
            return HostIP;
        }
        /// <summary>
        /// 公有静态方法，获得CCD信号反跳转时间参数。
        /// </summary>
        public static double GetCurCCDLineDebouncerTime(ICogGigEAccess gigEAccess)
        {
            double LineDebouncerTimeAbs = 0;
            try
            {
                LineDebouncerTimeAbs = gigEAccess.GetDoubleFeature("LineDebouncerTimeAbs");
                return LineDebouncerTimeAbs;
            }
            catch { }
            return LineDebouncerTimeAbs;
        }
        /// <summary>
        /// 公有静态方法，获得CCD帧率参数。
        /// </summary>
        public static double GetCurCCDAcquisitionLineRate(ICogGigEAccess gigEAccess)
        {
            double AcquisitionLineRateAbs = 0;
            try
            {
                AcquisitionLineRateAbs = gigEAccess.GetDoubleFeature("AcquisitionLineRateAbs");
                return AcquisitionLineRateAbs;
            }
            catch { }
            return AcquisitionLineRateAbs;
        }
        #endregion 获得相机信息方法

        #region 设置相机参数方法
        /// <summary>
        /// 公有静态方法，设置CCD曝光exposure
        /// </summary>
        public static void ConfigureExposure(ICogAcqFifo acqFifo, double exposure)
        {
            ICogAcqExposure exposureParams = acqFifo.OwnedExposureParams;
            if (exposureParams != null)
            {
                exposureParams.Exposure = exposure;
                acqFifo.Prepare();
            }
        }

        /// <summary>
        /// 公有静态方法，设置CCD亮度light。
        /// </summary>
        public static void ConfigureLight(ICogAcqFifo acqFifo, double light)
        {
            ICogAcqLight lightParams = acqFifo.OwnedLightParams;

            if (lightParams != null)
            {
                if (light > 1 || light < 0)
                {
                    System.Windows.Forms.MessageBox.Show("参数需要在0-1区间！", "提示");
                }
                else
                {
                    lightParams.LightPower = light;
                    acqFifo.Prepare();
                }
            }
        }

        /// <summary>
        /// 公有静态方法，设置CCD对比度Contrast。
        /// </summary>
        public static void ConfigureContrast(ICogAcqFifo acqFifo, double Contrast)
        {
            ICogAcqContrast ContrastParams = acqFifo.OwnedContrastParams;

            if (ContrastParams != null)
            {
                if (Contrast > 1 || Contrast < 0)
                {
                    System.Windows.Forms.MessageBox.Show("参数需要在0-1区间！", "提示");
                }
                else
                {
                    ContrastParams.Contrast = Contrast;
                    acqFifo.Prepare();
                }
            }
        }

        /// <summary>
        /// 公有静态方法，设置CCD外触发参数。
        /// </summary>
        public static void ConfigureTrigger(ICogGigEAccess gigEAccess, double lineDebouncerTime, double AcquisitionLineRateAbs)
        {
            //gigEAccess.SetFeature("TriggerSelector", "LineStart");
            //gigEAccess.SetFeature("TriggerMode", "Off");
            gigEAccess.SetFeature("TriggerSelector", "FrameStart");//帧
            gigEAccess.SetFeature("TriggerMode", "On");
            gigEAccess.SetFeature("TriggerSource", "Line3");
            // gigEAccess.SetFeature("TriggerActivation", "RisingEdge");
            // 或者可以触发激活到fallingedge。
            gigEAccess.SetFeature("TriggerActivation", "FallingEdge");
            //gigEAccess.SetFeature("LineSelector", "Line3");
            gigEAccess.SetFeature("LineTermination", "false");
            gigEAccess.SetDoubleFeature("LineDebouncerTimeAbs", lineDebouncerTime);
            gigEAccess.SetDoubleFeature("AcquisitionLineRateAbs", AcquisitionLineRateAbs);
        }
        public static void SetlineDebouncerTime(ICogGigEAccess gigEAccess, double time)
        {
            gigEAccess.SetFeature("TriggerSelector", "FrameStart");//帧
            gigEAccess.SetFeature("TriggerSource", "Line1");
            gigEAccess.SetFeature("TriggerActivation", "FallingEdge");
            //gigEAccess.SetFeature("TriggerActivation", "RisingEdge");
            gigEAccess.SetFeature("LineSelector", "Line1");
            //gigEAccess.SetFeature("LineTermination", "false");
            gigEAccess.SetDoubleFeature("LineDebouncerTimeAbs", time);
        }
        /// <summary>
        /// 公有静态方法，设置CCD旋转编码器触发。
        /// </summary>
        public static void ConfigureEncoder(ICogGigEAccess gigEAccess)
        {
            gigEAccess.SetFeature("ShaftEncoderModuleLineSelector", "PhaseA");
            gigEAccess.SetFeature("ShaftEncoderModuleLineSource", "Line2");
            gigEAccess.SetFeature("ShaftEncoderModuleLineSelector", "PhaseB");
            gigEAccess.SetFeature("ShaftEncoderModuleLineSource", "Line3");
            // Enable line termination for the RS-422 encoder signals
            gigEAccess.SetFeature("LineSelector", "Line2");
            gigEAccess.SetFeature("LineTermination", "true");
            gigEAccess.SetFeature("LineSelector", "Line3");
            gigEAccess.SetFeature("LineTermination", "true");
            // Set the shaft encoder module counter mode
            gigEAccess.SetFeature("ShaftEncoderModuleCounterMode", "IgnoreDirection");
            gigEAccess.SetFeature("TriggerSelector", "LineStart");
            gigEAccess.SetFeature("TriggerMode", "On");
            gigEAccess.SetFeature("TriggerSource", "ShaftEncoderModuleOut");
            gigEAccess.SetFeature("TriggerActivation", "FallingEdge");
            //gigEAccess.SetFeature("TriggerActivation", "RisingEdge");
        }

        public static void ConfigureAcquisitionLineRateAbs(ICogGigEAccess gigEAccess, double _AcquisitionLineRateAbs)
        {
            gigEAccess.SetDoubleFeature("AcquisitionLineRateAbs", _AcquisitionLineRateAbs);
        }
        public static void ConfigurelineDebouncerTime(ICogGigEAccess gigEAccess, double _lineDebouncerTime)
        {
            gigEAccess.SetDoubleFeature("LineDebouncerTimeAbs", _lineDebouncerTime);
        }


        /// <summary>
        /// 公有静态方法，设置位宽。
        /// </summary>
        public static void SetBandwidth(ICogGigEAccess gigEAccess,
            double percentageOfBandwidth)
        {
            Double maxRate = 100 * 1024 * 1024;
            uint packetSize = gigEAccess.GetIntegerFeature("GevSCPSPacketSize");
            Double packetTime = packetSize / maxRate;
            Double desiredTime = packetTime / percentageOfBandwidth;
            Double delaySec = desiredTime - packetTime;
            ulong timeStampFreq = gigEAccess.TimeStampFrequency;
            uint delay = (uint)(delaySec * timeStampFreq);
            gigEAccess.SetIntegerFeature("GevSCPD", delay);
        }
        #endregion 设置相机参数方法
        /// <summary>
        /// 公有静态方法，保存用户设置参数。
        /// </summary>
        public static void SaveUserSet(ICogGigEAccess gigEAccess)
        {
            gigEAccess.SetFeature("UserSetSelector", "UserSet1");
            gigEAccess.ExecuteCommand("UserSetSave");
            gigEAccess.SetFeature("UserSetDefaultSelector", "UserSet1");
        }



    }
}
