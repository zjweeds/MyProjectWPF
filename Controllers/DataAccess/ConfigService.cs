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
       static  String path = AppDomain.CurrentDomain.BaseDirectory + @"\\Configs";//配置文件路径
       static String ImagePath = AppDomain.CurrentDomain.BaseDirectory + @"\\Images\\";//票据图片路径
       static String file = @"SoftConfig.xml";
        MyXmlHelper myxmlhelper = new MyXmlHelper();
        /// <summary>
        /// 判断配置文件是否存在
        /// </summary>
        /// <returns>true 存在；false 不存在 </returns>
        public static bool  isConfigFilesExist()
        {           
            if (File.Exists((path + "/" + file))) 
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
        public bool CreateXmlFile()
        {
            if (!isConfigFilesExist())
            {                
                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }
                File.Create(path + "/" + file).Close();
                return true;
            }
            else
            {
                //文件已存在
                return false;
            }
         }
        public bool softConfigSaveToXml(SoftConfigModel softConfig,SoftVerify softVerify)
        {
            if (!isConfigFilesExist())
            {
                CreateXmlFile();
            }
            if (myxmlhelper.SaveToXml(path + '/' + file, softConfig,softVerify))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

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
