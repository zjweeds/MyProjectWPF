using System;
using System.Collections.Generic;
using System.Text;
using Controllers.Models;
using Controllers.DAL;
namespace Controllers.BLL
{
    /// <summary>
    ///本逻辑层由Hirer自动生成工具生成
    /// </summary>
    public class MoneyPanelInfoManager
    {
        /// <summary>
        /// 添加一个MoneyPanelInfo
        /// <param name="moneyPanelInfo">对象实例</param>
        public static bool AddMoneyPanelInfo(MoneyPanelInfo moneyPanelInfo)
        {
            return MoneyPanelInfoService.AddMoneyPanelInfo(moneyPanelInfo) > 0 ? true : false;
        }
    
      
        /// <summary>
        /// 根据MPID删除MoneyPanelInfo
        /// <param name="MPID">对象属性</param>
        public static bool DeleteMoneyPanelInfoByMPID(Int32  _mPID)
        {
            return MoneyPanelInfoService.DeleteMoneyPanelInfoByMPID( _mPID) > 0 ? true : false;
        }
          
           
        /// <summary>
        /// 更新MoneyPanelInfo
        /// <param name="moneyPanelInfo">新的对象实例</param>
        public static bool UpdateMoneyPanelInfo(MoneyPanelInfo moneyPanelInfo)
        {
            MoneyPanelInfo moneyPanelInfoTemp = MoneyPanelInfoService.SelectMoneyPanelInfoByMPID(moneyPanelInfo.MPID);
            moneyPanelInfoTemp.MPID = moneyPanelInfo.MPID;
            moneyPanelInfoTemp.MPName = moneyPanelInfo.MPName;
            moneyPanelInfoTemp.MPType = moneyPanelInfo.MPType;
            moneyPanelInfoTemp.MPDefault = moneyPanelInfo.MPDefault;
            moneyPanelInfoTemp.MPIsBorder = moneyPanelInfo.MPIsBorder;
            moneyPanelInfoTemp.MPIsTransparent = moneyPanelInfo.MPIsTransparent;
            moneyPanelInfoTemp.MPLeft = moneyPanelInfo.MPLeft;
            moneyPanelInfoTemp.MPTop = moneyPanelInfo.MPTop;
            moneyPanelInfoTemp.MPWidth = moneyPanelInfo.MPWidth;
            moneyPanelInfoTemp.MPHeight = moneyPanelInfo.MPHeight;
            moneyPanelInfoTemp.MPTabKey = moneyPanelInfo.MPTabKey;
            moneyPanelInfoTemp.MPIsReadOnly = moneyPanelInfo.MPIsReadOnly;
            moneyPanelInfoTemp.MPVisiable = moneyPanelInfo.MPVisiable;
            moneyPanelInfoTemp.MPIsMust = moneyPanelInfo.MPIsMust;
            moneyPanelInfoTemp.MPIsPrint = moneyPanelInfo.MPIsPrint;
            moneyPanelInfoTemp.MPIsEnable = moneyPanelInfo.MPIsEnable;
            moneyPanelInfoTemp.MPTIID = moneyPanelInfo.MPTIID;
            moneyPanelInfoTemp.MPFont = moneyPanelInfo.MPFont;
            moneyPanelInfoTemp.MPFontColor = moneyPanelInfo.MPFontColor;
            moneyPanelInfoTemp.MPBorerColor = moneyPanelInfo.MPBorerColor;
            moneyPanelInfoTemp.MPBackColor = moneyPanelInfo.MPBackColor;
            moneyPanelInfoTemp.MPShowUnit = moneyPanelInfo.MPShowUnit;
            moneyPanelInfoTemp.MPHighUnit = moneyPanelInfo.MPHighUnit;
            moneyPanelInfoTemp.MPLowUnit = moneyPanelInfo.MPLowUnit;
            moneyPanelInfoTemp.MPBindsID = moneyPanelInfo.MPBindsID;
            return MoneyPanelInfoService.UpdateMoneyPanelInfo(moneyPanelInfoTemp) > 0 ? true : false;
        }
          
           
        /// <summary>
        /// 根据MPID查询MoneyPanelInfo
        /// <param name="moneyPanelInfo">对象实例</param>
        public static MoneyPanelInfo SelectMoneyPanelInfoByMPID(Int32  _mPID)
        {
            return MoneyPanelInfoService.SelectMoneyPanelInfoByMPID( _mPID);
        }
        
        
        /// <summary>
        /// 查询所有MoneyPanelInfo
        /// </summary>
        public static IList<MoneyPanelInfo> SelectAllMoneyPanelInfo()
        {
            return  MoneyPanelInfoService.SelectAllMoneyPanelInfo();
        }
    }
}
