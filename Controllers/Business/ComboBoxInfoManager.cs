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
    public class ComboBoxInfoManager
    {
        /// <summary>
        /// 添加一个ComboBoxInfo
        /// <param name="comboBoxInfo">对象实例</param>
        public static bool AddComboBoxInfo(ComboBoxInfo comboBoxInfo)
        {
            return ComboBoxInfoService.AddComboBoxInfo(comboBoxInfo) > 0 ? true : false;
        }
    
      
        /// <summary>
        /// 根据CBBID删除ComboBoxInfo
        /// <param name="CBBID">对象属性</param>
        public static bool DeleteComboBoxInfoByCBBID(Int32  _cBBID)
        {
            return ComboBoxInfoService.DeleteComboBoxInfoByCBBID( _cBBID) > 0 ? true : false;
        }
          
           
        /// <summary>
        /// 更新ComboBoxInfo
        /// <param name="comboBoxInfo">新的对象实例</param>
        public static bool UpdateComboBoxInfo(ComboBoxInfo comboBoxInfo)
        {
            ComboBoxInfo comboBoxInfoTemp = ComboBoxInfoService.SelectComboBoxInfoByCBBID(comboBoxInfo.CBBID);
            comboBoxInfoTemp.CBBID = comboBoxInfo.CBBID;
            comboBoxInfoTemp.CBBName = comboBoxInfo.CBBName;
            comboBoxInfoTemp.CBBType = comboBoxInfo.CBBType;
            comboBoxInfoTemp.CBBDefault = comboBoxInfo.CBBDefault;
            comboBoxInfoTemp.CBBIsBorder = comboBoxInfo.CBBIsBorder;
            comboBoxInfoTemp.CBBIsTransparent = comboBoxInfo.CBBIsTransparent;
            comboBoxInfoTemp.CBBILeft = comboBoxInfo.CBBILeft;
            comboBoxInfoTemp.CBBTop = comboBoxInfo.CBBTop;
            comboBoxInfoTemp.CBBWidth = comboBoxInfo.CBBWidth;
            comboBoxInfoTemp.CBBHeight = comboBoxInfo.CBBHeight;
            comboBoxInfoTemp.CBBTabKey = comboBoxInfo.CBBTabKey;
            comboBoxInfoTemp.CBBIsReadOnly = comboBoxInfo.CBBIsReadOnly;
            comboBoxInfoTemp.CBBVisiable = comboBoxInfo.CBBVisiable;
            comboBoxInfoTemp.CBBIsMust = comboBoxInfo.CBBIsMust;
            comboBoxInfoTemp.CBBIsPrint = comboBoxInfo.CBBIsPrint;
            comboBoxInfoTemp.CBBIsEnable = comboBoxInfo.CBBIsEnable;
            comboBoxInfoTemp.CBBBandsTabel = comboBoxInfo.CBBBandsTabel;
            comboBoxInfoTemp.CBBBandsCoumln = comboBoxInfo.CBBBandsCoumln;
            comboBoxInfoTemp.CBBTIID = comboBoxInfo.CBBTIID;
            comboBoxInfoTemp.CBBFont = comboBoxInfo.CBBFont;
            comboBoxInfoTemp.CBBFontColor = comboBoxInfo.CBBFontColor;
            comboBoxInfoTemp.CBBBorerColor = comboBoxInfo.CBBBorerColor;
            comboBoxInfoTemp.CBBBackColor = comboBoxInfo.CBBBackColor;
            return ComboBoxInfoService.UpdateComboBoxInfo(comboBoxInfoTemp) > 0 ? true : false;
        }
          
           
        /// <summary>
        /// 根据CBBID查询ComboBoxInfo
        /// <param name="comboBoxInfo">对象实例</param>
        public static ComboBoxInfo SelectComboBoxInfoByCBBID(Int32  _cBBID)
        {
            return ComboBoxInfoService.SelectComboBoxInfoByCBBID( _cBBID);
        }
        
        
        /// <summary>
        /// 查询所有ComboBoxInfo
        /// </summary>
        public static IList<ComboBoxInfo> SelectAllComboBoxInfo()
        {
            return  ComboBoxInfoService.SelectAllComboBoxInfo();
        }
    }
}
