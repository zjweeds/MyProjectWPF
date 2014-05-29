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
           string sfile = @"SoftConfig.xml";
           String spath = AppDomain.CurrentDomain.BaseDirectory + @"\\Configs";//配置文件路径
           return ConfigService.isConfigFilesExist(spath, sfile);
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
    }
}
