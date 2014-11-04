//---------------------------------------------------------—-----//
//功能：PrintSet业务层逻辑                                        //
//作者：赵建                                                      //
//版本：v1.1                                                      //
//创建时间：2014/3/30   12:55:00                                  //
//最后修改时间：2014/5/30   8:55:00                               //
//---------------------------------------------------------------//

using System;
using System.Collections.Generic;
using System.Text;
using Controllers.Models;
using Controllers.DataAccess;
namespace Controllers.Business
{
    public class PrintSetManager
    {
        /// <summary>
        /// 添加一个PrintSet
        /// <param name="printSet">对象实例</param>
        public static bool AddPrintSet(PrintSetInfo printSet)
        {
            return PrintSetService.AddPrintSet(printSet) > 0 ? true : false;
        }
    
      
        /// <summary>
        /// 根据PSID删除PrintSet
        /// <param name="PSID">对象属性</param>
        public static bool DeletePrintSetByPSID(Int32  _pSID)
        {
            return PrintSetService.DeletePrintSetByPSID( _pSID) > 0 ? true : false;
        }
          
           
        /// <summary>
        /// 更新PrintSet
        /// <param name="printSet">新的对象实例</param>
        public static bool UpdatePrintSet(PrintSetInfo printSet)
        {
            PrintSetInfo printSetTemp = PrintSetService.SelectPrintSetByPSID(printSet.PSID);
            printSetTemp.PSID = printSet.PSID;
            printSetTemp.PSName = printSet.PSName;
            printSetTemp.PSLeft = printSet.PSLeft;
            printSetTemp.PSRight = printSet.PSRight;
            printSetTemp.PSIsEnable = printSet.PSIsEnable;
            return PrintSetService.UpdatePrintSet(printSetTemp) > 0 ? true : false;
        }
          
           
        /// <summary>
        /// 根据PSID查询PrintSet
        /// <param name="printSet">对象实例</param>
        public static PrintSetInfo SelectPrintSetByPSID(Int32  _pSID)
        {
            return PrintSetService.SelectPrintSetByPSID( _pSID);
        }
        
        
        /// <summary>
        /// 查询所有PrintSet
        /// </summary>
        public static IList<PrintSetInfo> SelectAllPrintSet()
        {
            return  PrintSetService.SelectAllPrintSet();
        }
    }
}
