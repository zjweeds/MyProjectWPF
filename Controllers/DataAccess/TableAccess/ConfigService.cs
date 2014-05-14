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
using Controllers.Common;

namespace Controllers.DataAccess
{
    public class ConfigService
    {
        String path = AppDomain.CurrentDomain.BaseDirectory + @"\\Configs";
        String file = @"SoftConfig.xml";
        MyXmlHelper myxmlhelper = new MyXmlHelper();
        /// <summary>
        /// 判断配置文件是否存在
        /// </summary>
        /// <returns>true 存在；false 不存在 </returns>
        public bool  isConfigFilesExist()
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

        public SoftConfigModel readXML()
        {
            SoftConfigModel scmf = myxmlhelper.readXMl(path + '/' + file);
            if (scmf != null)
            {
                return scmf;
            }
            else
            {
               return  new SoftConfigModel();
            }
        }

        public String CheckSoft(String softkey)
        {
            StringBuilder CheckSoftSQL = new StringBuilder();
           CheckSoftSQL.Append("select top 1 CompanyName,StarTime,EndTime from RegistInfo  where SoftKey =@SoftKey");

            return "";
        }
    }
}
