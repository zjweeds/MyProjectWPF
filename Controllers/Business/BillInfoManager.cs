//---------------------------------------------------------—-----//
//功能：BillInfo账单信息业务层逻辑                                 //
//作者：赵建                                                      //
//版本：v1.1                                                      //
//创建时间：2014/3/30   12:55:00                                  //
//最后修改时间：2014/5/30   8:55:00                               //
//---------------------------------------------------------------//
#region 引入的命名空间
using System;
using System.Collections.Generic;
using System.Text;
using Controllers.Models;
using Controllers.DataAccess;
using System.Data;
#endregion

namespace Controllers.Business
{
    public class BillInfoManager
    {
        #region insert
        /// <summary>
        /// 添加一个BillInfo
        /// <param name="billInfo">对象实例</param>
        public static int  AddBillInfo(BillInfo billInfo)
        {
            return BillInfoService.AddBillInfo(billInfo) ;
        }
        #endregion

        #region  delete
        /// <summary>
        /// 根据BIID删除BillInfo
        /// <param name="BIID">对象属性</param>
        public static bool DeleteBillInfoByBIID(Int32  _bIID)
        {
            return BillInfoService.DeleteBillInfoByBIID( _bIID) > 0 ? true : false;
        }
        #endregion

        #region update
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
        #endregion

        #region select 
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

        #endregion

        #region 其他
        /// <summary>
        /// 创建一个新ID
        /// </summary>
        /// <param name="intLength">ID长度</param>
        /// <param name="TIID">模板ID</param>
        /// <returns></returns>
        public static String CreatNewID(int intLength,int TIID)
        {
            return BillInfoService.CreatNewID(intLength,TIID);
        }
        public static DataTable GetBillInfoByBillSet(String billSetName,String where)
        {
            return BillInfoService.GetBillInfoByBillSet(billSetName, where);
        }
        #endregion
    }
}
