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

namespace Controllers.Moders
{
  public  class SoftConfigModer
    {
      public String softKey { get; set; }
      public String softServerIP { get; set; }
      public String softDBName { get; set; }

      public String softDBUser { get; set; }

      public String softDBPwd { get; set; }

      public String softImagePath { get; set; }
      public String softConfigPath { get; set; }
      public SoftConfigModer()
      {
          softImagePath = AppDomain.CurrentDomain.BaseDirectory + @"\\ImageCache\";
          softConfigPath = AppDomain.CurrentDomain.BaseDirectory + @"\\Configs\"; 
      }
  
    }
}
