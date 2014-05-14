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
    public class TextControlInfoManager
    {
        /// <summary>
        /// 添加一个TextControlInfo
        /// <param name="textControlInfo">对象实例</param>
        public static bool AddTextControlInfo(TextControlInfo textControlInfo)
        {
            return TextControlInfoService.AddTextControlInfo(textControlInfo) > 0 ? true : false;
        }
    
      
        /// <summary>
        /// 根据TCID删除TextControlInfo
        /// <param name="TCID">对象属性</param>
        public static bool DeleteTextControlInfoByTCID(Int32  _tCID)
        {
            return TextControlInfoService.DeleteTextControlInfoByTCID( _tCID) > 0 ? true : false;
        }
          
           
        /// <summary>
        /// 更新TextControlInfo
        /// <param name="textControlInfo">新的对象实例</param>
        public static bool UpdateTextControlInfo(TextControlInfo textControlInfo)
        {
            TextControlInfo textControlInfoTemp = TextControlInfoService.SelectTextControlInfoByTCID(textControlInfo.TCID);
            textControlInfoTemp.TCID = textControlInfo.TCID;
            textControlInfoTemp.TCName = textControlInfo.TCName;
            textControlInfoTemp.TCDefault = textControlInfo.TCDefault;
            textControlInfoTemp.TCIsBorder = textControlInfo.TCIsBorder;
            textControlInfoTemp.TCIsTransparent = textControlInfo.TCIsTransparent;
            textControlInfoTemp.TCLeft = textControlInfo.TCLeft;
            textControlInfoTemp.TCTop = textControlInfo.TCTop;
            textControlInfoTemp.TCWidth = textControlInfo.TCWidth;
            textControlInfoTemp.TCHeight = textControlInfo.TCHeight;
            textControlInfoTemp.TCTabKey = textControlInfo.TCTabKey;
            textControlInfoTemp.TCIsReadOnly = textControlInfo.TCIsReadOnly;
            textControlInfoTemp.TCVisiable = textControlInfo.TCVisiable;
            textControlInfoTemp.TCIsMust = textControlInfo.TCIsMust;
            textControlInfoTemp.TCIsPrint = textControlInfo.TCIsPrint;
            textControlInfoTemp.TCIsEnable = textControlInfo.TCIsEnable;
            textControlInfoTemp.TCBandsTabel = textControlInfo.TCBandsTabel;
            textControlInfoTemp.TCBandsCoumln = textControlInfo.TCBandsCoumln;
            textControlInfoTemp.TCTIID = textControlInfo.TCTIID;
            textControlInfoTemp.TCFont = textControlInfo.TCFont;
            textControlInfoTemp.TCFontColor = textControlInfo.TCFontColor;
            textControlInfoTemp.TCBorerColor = textControlInfo.TCBorerColor;
            textControlInfoTemp.TCBackColor = textControlInfo.TCBackColor;
            textControlInfoTemp.TCIsFlage = textControlInfo.TCIsFlage;
            textControlInfoTemp.TCShowType = textControlInfo.TCShowType;
            textControlInfoTemp.TCMarkType = textControlInfo.TCMarkType;
            return TextControlInfoService.UpdateTextControlInfo(textControlInfoTemp) > 0 ? true : false;
        }
          
           
        /// <summary>
        /// 根据TCID查询TextControlInfo
        /// <param name="textControlInfo">对象实例</param>
        public static TextControlInfo SelectTextControlInfoByTCID(Int32  _tCID)
        {
            return TextControlInfoService.SelectTextControlInfoByTCID( _tCID);
        }
        
        
        /// <summary>
        /// 查询所有TextControlInfo
        /// </summary>
        public static IList<TextControlInfo> SelectAllTextControlInfo()
        {
            return  TextControlInfoService.SelectAllTextControlInfo();
        }
    }
}
