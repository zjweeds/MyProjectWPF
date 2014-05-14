//----------------------------------------------------------------//
//功能：软件配置实体类                                             //
//作者：赵建                                                      //
//版本：v1.3                                                      //
//创建时间：2013/11/7   15:34:00                                  //
//最后一次修改时间：2014/3/23   17:22:00                          //
//---------------------------------------------------------------//
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controllers.Models
{
  public  class SoftConfigModel
    {
      /// <summary>
      /// 软件码
      /// </summary>
      public String softKey { get; set; }
      /// <summary>
      /// 数据库服务器IP
      /// </summary>
      public String softServerIP { get; set; }
      /// <summary>
      /// 数据库名称
      /// </summary>
      public String softDBName { get; set; }

      /// <summary>
      /// 数据库用户
      /// </summary>
      public String softDBUser { get; set; }
      /// <summary>
      /// 数据库用户密码
      /// </summary>
      public String softDBPwd { get; set; }

      /// <summary>
      /// 数据库文件路径
      /// </summary>
      public String DbFilePath { get; set; }
      /// <summary>
      /// 配置文件图片保存路径
      /// </summary>
      public String softImagePath { get; set; }
     
      /// <summary>
      /// 配置文件路径
      /// </summary>
      public String softConfigPath { get; set; }
      public SoftConfigModel()
      {
          softImagePath = AppDomain.CurrentDomain.BaseDirectory + @"\\ImageCache\";
          softConfigPath = AppDomain.CurrentDomain.BaseDirectory + @"\\Configs\";
          DbFilePath = "非用户自定义数据库，采用系统路劲"; 
      }
  
    }
}
