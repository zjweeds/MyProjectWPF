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
using Controllers.Moders;
using Controllers.Common;
using Controllers.Moders.TableModers;

namespace Controllers.Business
{
    public class ConfigService
    {
        string path = AppDomain.CurrentDomain.BaseDirectory + @"\\Configs";
        string file = @"SoftConfig.xml";
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
                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }
                File.Create(path+"/"+file);
                return false;
            }        
        }


        public bool softConfigSaveToXml(SoftConfigModer softConfig,SoftVerify softVerify)
        {
            if (myxmlhelper.SaveToXml(path + '/' + file, softConfig,softVerify))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public SoftConfigModer readXML()
        {
            SoftConfigModer scmf = myxmlhelper.readXMl(path + '/' + file);
            if (scmf != null)
            {
                return scmf;
            }
            else
            {
               return  new SoftConfigModer();
            }
        }

        public string CheckSoft(string softkey)
        {
            StringBuilder CheckSoftSQL = new StringBuilder();
           CheckSoftSQL.Append("select top 1 CompanyName,StarTime,EndTime from RegistInfo  where SoftKey =@SoftKey");

            return "";
        }
    }
}
