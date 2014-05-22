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
    public class BillInfoManager
    {
        /// <summary>
        /// 添加一个BillInfo
        /// <param name="billInfo">对象实例</param>
        public static int  AddBillInfo(BillInfo billInfo)
        {
            return BillInfoService.AddBillInfo(billInfo) ;
        }
    
      
        /// <summary>
        /// 根据BIID删除BillInfo
        /// <param name="BIID">对象属性</param>
        public static bool DeleteBillInfoByBIID(Int32  _bIID)
        {
            return BillInfoService.DeleteBillInfoByBIID( _bIID) > 0 ? true : false;
        }
          
           
        /// <summary>
        /// 更新BillInfo
        /// <param name="billInfo">新的对象实例</param>
        public static bool UpdateBillInfo(BillInfo billInfo)
        {
            BillInfo billInfoTemp = BillInfoService.SelectBillInfoByBIID(billInfo.BIID);
            billInfoTemp.BIID = billInfo.BIID;
            billInfoTemp.BINo = billInfo.BINo;
            billInfoTemp.BIName = billInfo.BIName;
            billInfoTemp.BITIID = billInfo.BITIID;
            billInfoTemp.BISenderCode = billInfo.BISenderCode;
            billInfoTemp.BISender = billInfo.BISender;
            billInfoTemp.BIReciverCode = billInfo.BIReciverCode;
            billInfoTemp.BIReciver = billInfo.BIReciver;
            billInfoTemp.BIAmount = billInfo.BIAmount;
            billInfoTemp.BIIsEnable = billInfo.BIIsEnable;
            return BillInfoService.UpdateBillInfo(billInfoTemp) > 0 ? true : false;
        }
          
           
        /// <summary>
        /// 根据BIID查询BillInfo
        /// <param name="billInfo">对象实例</param>
        public static BillInfo SelectBillInfoByBIID(Int32  _bIID)
        {
            return BillInfoService.SelectBillInfoByBIID( _bIID);
        }
        
        
        /// <summary>
        /// 查询所有BillInfo
        /// </summary>
        public static IList<BillInfo> SelectAllBillInfo()
        {
            return  BillInfoService.SelectAllBillInfo();
        }

        public static String CreatNewID(int intLength,int TIID)
        {
            return BillInfoService.CreatNewID(intLength,TIID);
        }
    }
}
