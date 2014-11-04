//---------------------------------------------------------—-----//
//功能：软件配置业务逻辑                                             //
//作者：赵建                                                      //
//版本：v1.3                                                      //
//创建时间：2014/3/30   12:55:00                                  //
//最后修改时间：2014/3/30   12:55:00                              //
//---------------------------------------------------------------//
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Xml;
using Controllers.Models;
using System.Drawing;
using Controllers.Common;

namespace Controllers.DataAccess
{
    public class ConfigService
    {
        static String ImagePath = AppDomain.CurrentDomain.BaseDirectory + @"\\Images\\";//票据图片路径
        MyXmlHelper myxmlhelper = new MyXmlHelper(); //xml帮助类

        /// <summary>
        /// 判断配置文件是否存在
        /// </summary>
        /// <returns>true 存在；false 不存在 </returns>
        public static bool  isFilesExist(String spath, string sfile)
        {
            String truePath = spath + "/" + sfile;
            if (File.Exists(truePath))
            {
                return true;
            }
            else
            {
                return false;
            }        
        }

        /// <summary>
        /// 创建文件
        /// </summary>
        /// <returns></returns>
        public bool CreateXmlFile( String spath,String sfile)
        {
            if (!isFilesExist(spath,sfile))
            {
                if (!Directory.Exists(spath))
                {
                    Directory.CreateDirectory(spath);
                }
                File.Create(spath + "/" + sfile).Close();
                return true;
            }
            else
            {
                //文件已存在
                return false;
            }
         }

        /// <summary>
        /// 配置信息保存到xml文件
        /// </summary>
        /// <param name="softConfig"></param>
        /// <param name="softVerify"></param>
        /// <returns></returns>
        public bool softConfigSaveToXml(SoftConfigModel softConfig,SoftVerify softVerify)
        {
            string sfile = @"SoftConfig.xml";
            String spath = AppDomain.CurrentDomain.BaseDirectory + @"\\Configs";//配置文件路径
            if (!isFilesExist(spath, sfile))
            {
                CreateXmlFile(spath,sfile);
            }
            if (myxmlhelper.SaveToXml(spath + '/' + sfile, softConfig, softVerify))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
       
        /// <summary>
        /// 保存登陆信息到xml
        /// </summary>
        /// <param name="spath"></param>
        /// <returns></returns>
        public bool SaveLoginToXml(String spath)
        {
            string sfile = @"LoginConfig.xml";
            if (!isFilesExist(spath, sfile))
            {
                CreateXmlFile(spath, sfile);
            }
            if (myxmlhelper.SaveLoginToXml(spath + '/' + sfile))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// 图片是否存在
        /// </summary>
        /// <param name="ipathName"></param>
        /// <param name="fileName"></param>
        /// <returns></returns>
        public static bool IsImageExit(String ipathName, String fileName)
        {
            if (!Directory.Exists(ipathName))//若文件夹不存在则新建文件夹  
            {
                Directory.CreateDirectory(ipathName); //新建文件夹 
                return false;
            }
            else
            {
                if (File.Exists((ipathName + "/" + fileName)))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }           
        }

        /// <summary>
        /// 创建图片
        /// </summary>
        /// <param name="ipathName"></param>
        /// <param name="fileName"></param>
        /// <param name="buff"></param>
        /// <returns></returns>
        public static bool CreateImages(String ipathName, String fileName, byte[] buff)
        {
            try
            {
                ipathName = ImagePath + ipathName;
                ImageHelper im = new ImageHelper();
                if (!IsImageExit(ipathName, fileName))
                {
                    im.SaveImage(im.GetImageByByte(buff), ipathName + "/" + fileName+".jpg");
                }
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
       
    }
}
