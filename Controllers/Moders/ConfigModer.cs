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
      public string softKey { get; set; }
      public string softServerIP { get; set; }
      public string softDBName { get; set; }

      public string softDBUser { get; set; }

      public string softDBPwd { get; set; }
  
    }
}
