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
    public class DateTimePickerInfoManager
    {
        /// <summary>
        /// 添加一个DateTimePickerInfo
        /// <param name="dateTimePickerInfo">对象实例</param>
        public static bool AddDateTimePickerInfo(DateTimePickerInfo dateTimePickerInfo)
        {
            return DateTimePickerInfoService.AddDateTimePickerInfo(dateTimePickerInfo) > 0 ? true : false;
        }
    
      
        /// <summary>
        /// 根据DTPID删除DateTimePickerInfo
        /// <param name="DTPID">对象属性</param>
        public static bool DeleteDateTimePickerInfoByDTPID(Int32  _dTPID)
        {
            return DateTimePickerInfoService.DeleteDateTimePickerInfoByDTPID( _dTPID) > 0 ? true : false;
        }
          
           
        /// <summary>
        /// 更新DateTimePickerInfo
        /// <param name="dateTimePickerInfo">新的对象实例</param>
        public static bool UpdateDateTimePickerInfo(DateTimePickerInfo dateTimePickerInfo)
        {
            DateTimePickerInfo dateTimePickerInfoTemp = DateTimePickerInfoService.SelectDateTimePickerInfoByDTPID(dateTimePickerInfo.DTPID);
            dateTimePickerInfoTemp.DTPID = dateTimePickerInfo.DTPID;
            dateTimePickerInfoTemp.DTPName = dateTimePickerInfo.DTPName;
            dateTimePickerInfoTemp.DTPDefault = dateTimePickerInfo.DTPDefault;
            dateTimePickerInfoTemp.DTPIsBorder = dateTimePickerInfo.DTPIsBorder;
            dateTimePickerInfoTemp.DTPIsTransparent = dateTimePickerInfo.DTPIsTransparent;
            dateTimePickerInfoTemp.DTPLeft = dateTimePickerInfo.DTPLeft;
            dateTimePickerInfoTemp.DTPTop = dateTimePickerInfo.DTPTop;
            dateTimePickerInfoTemp.DTPWidth = dateTimePickerInfo.DTPWidth;
            dateTimePickerInfoTemp.DTPHeight = dateTimePickerInfo.DTPHeight;
            dateTimePickerInfoTemp.DTPTabKey = dateTimePickerInfo.DTPTabKey;
            dateTimePickerInfoTemp.DTPIsReadOnly = dateTimePickerInfo.DTPIsReadOnly;
            dateTimePickerInfoTemp.DTPVisiable = dateTimePickerInfo.DTPVisiable;
            dateTimePickerInfoTemp.DTPIsMust = dateTimePickerInfo.DTPIsMust;
            dateTimePickerInfoTemp.DTPIsPrint = dateTimePickerInfo.DTPIsPrint;
            dateTimePickerInfoTemp.DTPIsEnable = dateTimePickerInfo.DTPIsEnable;
            dateTimePickerInfoTemp.DTPBandsTable = dateTimePickerInfo.DTPBandsTable;
            dateTimePickerInfoTemp.DTPBandsCoumln = dateTimePickerInfo.DTPBandsCoumln;
            dateTimePickerInfoTemp.DTPTIID = dateTimePickerInfo.DTPTIID;
            dateTimePickerInfoTemp.DTPIFont = dateTimePickerInfo.DTPIFont;
            dateTimePickerInfoTemp.DTPFontColor = dateTimePickerInfo.DTPFontColor;
            dateTimePickerInfoTemp.DTPBorerColor = dateTimePickerInfo.DTPBorerColor;
            dateTimePickerInfoTemp.DTPBackColor = dateTimePickerInfo.DTPBackColor;
            return DateTimePickerInfoService.UpdateDateTimePickerInfo(dateTimePickerInfoTemp) > 0 ? true : false;
        }
          
           
        /// <summary>
        /// 根据DTPID查询DateTimePickerInfo
        /// <param name="dateTimePickerInfo">对象实例</param>
        public static DateTimePickerInfo SelectDateTimePickerInfoByDTPID(Int32  _dTPID)
        {
            return DateTimePickerInfoService.SelectDateTimePickerInfoByDTPID( _dTPID);
        }
        
        
        /// <summary>
        /// 查询所有DateTimePickerInfo
        /// </summary>
        public static IList<DateTimePickerInfo> SelectAllDateTimePickerInfo()
        {
            return  DateTimePickerInfoService.SelectAllDateTimePickerInfo();
        }
    }
}
