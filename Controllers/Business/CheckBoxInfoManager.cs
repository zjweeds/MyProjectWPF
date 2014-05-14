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
    public class CheckBoxInfoManager
    {
        /// <summary>
        /// 添加一个CheckBoxInfo
        /// <param name="checkBoxInfo">对象实例</param>
        public static bool AddCheckBoxInfo(CheckBoxInfo checkBoxInfo)
        {
            return CheckBoxInfoService.AddCheckBoxInfo(checkBoxInfo) > 0 ? true : false;
        }
    
      
        /// <summary>
        /// 根据CHBID删除CheckBoxInfo
        /// <param name="CHBID">对象属性</param>
        public static bool DeleteCheckBoxInfoByCHBID(Int32  _cHBID)
        {
            return CheckBoxInfoService.DeleteCheckBoxInfoByCHBID( _cHBID) > 0 ? true : false;
        }
          
           
        /// <summary>
        /// 更新CheckBoxInfo
        /// <param name="checkBoxInfo">新的对象实例</param>
        public static bool UpdateCheckBoxInfo(CheckBoxInfo checkBoxInfo)
        {
            CheckBoxInfo checkBoxInfoTemp = CheckBoxInfoService.SelectCheckBoxInfoByCHBID(checkBoxInfo.CHBID);
            checkBoxInfoTemp.CHBID = checkBoxInfo.CHBID;
            checkBoxInfoTemp.CHBName = checkBoxInfo.CHBName;
            checkBoxInfoTemp.CHBType = checkBoxInfo.CHBType;
            checkBoxInfoTemp.CHBDefault = checkBoxInfo.CHBDefault;
            checkBoxInfoTemp.CHBIsBorder = checkBoxInfo.CHBIsBorder;
            checkBoxInfoTemp.CHBIsTransparent = checkBoxInfo.CHBIsTransparent;
            checkBoxInfoTemp.CHBLeft = checkBoxInfo.CHBLeft;
            checkBoxInfoTemp.CHBTop = checkBoxInfo.CHBTop;
            checkBoxInfoTemp.CHBWidth = checkBoxInfo.CHBWidth;
            checkBoxInfoTemp.CHBHeight = checkBoxInfo.CHBHeight;
            checkBoxInfoTemp.CHBTabKey = checkBoxInfo.CHBTabKey;
            checkBoxInfoTemp.CHBIsReadOnly = checkBoxInfo.CHBIsReadOnly;
            checkBoxInfoTemp.CHBVisiable = checkBoxInfo.CHBVisiable;
            checkBoxInfoTemp.CHBIsMust = checkBoxInfo.CHBIsMust;
            checkBoxInfoTemp.CHBIsPrint = checkBoxInfo.CHBIsPrint;
            checkBoxInfoTemp.CHBIsEnable = checkBoxInfo.CHBIsEnable;
            checkBoxInfoTemp.CHBBandsTabel = checkBoxInfo.CHBBandsTabel;
            checkBoxInfoTemp.CHBBandsCoumln = checkBoxInfo.CHBBandsCoumln;
            checkBoxInfoTemp.CHBTIID = checkBoxInfo.CHBTIID;
            checkBoxInfoTemp.CHBFont = checkBoxInfo.CHBFont;
            checkBoxInfoTemp.CHBFontColor = checkBoxInfo.CHBFontColor;
            checkBoxInfoTemp.CHBBorerColor = checkBoxInfo.CHBBorerColor;
            checkBoxInfoTemp.CHBBackColor = checkBoxInfo.CHBBackColor;
            return CheckBoxInfoService.UpdateCheckBoxInfo(checkBoxInfoTemp) > 0 ? true : false;
        }
          
           
        /// <summary>
        /// 根据CHBID查询CheckBoxInfo
        /// <param name="checkBoxInfo">对象实例</param>
        public static CheckBoxInfo SelectCheckBoxInfoByCHBID(Int32  _cHBID)
        {
            return CheckBoxInfoService.SelectCheckBoxInfoByCHBID( _cHBID);
        }
        
        
        /// <summary>
        /// 查询所有CheckBoxInfo
        /// </summary>
        public static IList<CheckBoxInfo> SelectAllCheckBoxInfo()
        {
            return  CheckBoxInfoService.SelectAllCheckBoxInfo();
        }
    }
}
