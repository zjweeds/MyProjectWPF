using System;
using System.Collections.Generic;
using System.Text;
using Controllers.Models;
using Controllers.DataAccess;
namespace Controllers.Business
{
    /// <summary>
    ///本逻辑层由Hirer自动生成工具生成
    /// </summary>
    public class BillManageManager
    {
        /// <summary>
        /// 添加一个BillManage
        /// <param name="billManage">对象实例</param>
        public static bool AddBillManage(BillManageInfo billManage)
        {
            return BillManageService.AddBillManage(billManage) > 0 ? true : false;
        }
    
      
        /// <summary>
        /// 根据BIID删除BillManage
        /// <param name="BIID">对象属性</param>
        public static bool DeleteBillManageByBIID(Int32  _bIID)
        {
            return BillManageService.DeleteBillManageByBIID( _bIID) > 0 ? true : false;
        }
          
           
        /// <summary>
        /// 更新BillManage
        /// <param name="billManage">新的对象实例</param>
        public static bool UpdateBillManage(BillManageInfo billManage)
        {
            BillManageInfo billManageTemp = BillManageService.SelectBillManageByBIID(billManage.BIID);
            billManageTemp.BIID = billManage.BIID;
            billManageTemp.BIName = billManage.BIName;
            billManageTemp.BITIID = billManage.BITIID;
            billManageTemp.BISenderCode = billManage.BISenderCode;
            billManageTemp.BISender = billManage.BISender;
            billManageTemp.BIReciverCode = billManage.BIReciverCode;
            billManageTemp.BIReciver = billManage.BIReciver;
            billManageTemp.BIAmount = billManage.BIAmount;
            billManageTemp.BIIsEnable = billManage.BIIsEnable;
            return BillManageService.UpdateBillManage(billManageTemp) > 0 ? true : false;
        }
          
           
        /// <summary>
        /// 根据BIID查询BillManage
        /// <param name="billManage">对象实例</param>
        public static BillManageInfo SelectBillManageByBIID(Int32  _bIID)
        {
            return BillManageService.SelectBillManageByBIID( _bIID);
        }
        
        
        /// <summary>
        /// 查询所有BillManage
        /// </summary>
        public static IList<BillManageInfo> SelectAllBillManage()
        {
            return  BillManageService.SelectAllBillManage();
        }
    }
}
