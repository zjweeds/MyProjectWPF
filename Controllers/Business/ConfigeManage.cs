//---------------------------------------------------------—-----//
//功能：软件配置相关业务层逻辑                                    //
//作者：赵建                                                      //
//版本：v1.1                                                      //
//创建时间：2014/3/30   12:55:00                                  //
//最后修改时间：2014/5/30   8:55:00                               //
//---------------------------------------------------------------//
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Controllers.DataAccess;
using Controllers.Models;
using System.Data;
namespace Controllers.Business
{
   public  class ConfigeManage
    {
       public static bool isConfigFilesExist()
       {
           String sfile = @"SoftConfig.xml";
           String spath = AppDomain.CurrentDomain.BaseDirectory + @"\\Configs";//配置文件路径
           return ConfigService.isFilesExist(spath, sfile);
       }

       public static bool isFilesExist(String spath, String sfile)
       {
          return ConfigService.isFilesExist(spath, sfile);
       }

       public static bool LoadImage(DataTable dt,String bsname)
       {
           try
           {
               if (dt != null && dt.Rows.Count > 0)
               {
                   for (int i = 0; i < dt.Rows.Count; i++)
                   {
                       ConfigService.CreateImages(bsname + "/" + dt.Rows[i]["TTName"].ToString(),
                           dt.Rows[i]["TIID"].ToString(), dt.Rows[i]["TIBackground"] as byte[]);
                   }

               }
               return true;
           }
           catch (Exception ex)
           {
               throw ex;
           }
       }

       public static bool SaveLoginToXml(string spath)
       {
           return new ConfigService().SaveLoginToXml(spath);
       }
       static public bool softConfigSaveToXml(SoftConfigModel softConfig, SoftVerify softVerify)
       {
           return new ConfigService().softConfigSaveToXml(softConfig, softVerify);
       }
    }
}
