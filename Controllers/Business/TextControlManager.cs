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
    public class TextControlManager
    {
        /// <summary>
        /// 添加一个TextControl
        /// <param name="textControl">对象实例</param>
        public static bool AddTextControl(TextControl textControl)
        {
            return TextControlService.AddTextControl(textControl) > 0 ? true : false;
        }
    
      
        /// <summary>
        /// 根据TCID删除TextControl
        /// <param name="TCID">对象属性</param>
        public static bool DeleteTextControlByTCID(Int32  _tCID)
        {
            return TextControlService.DeleteTextControlByTCID( _tCID) > 0 ? true : false;
        }
          
           
        /// <summary>
        /// 更新TextControl
        /// <param name="textControl">新的对象实例</param>
        public static bool UpdateTextControl(TextControl textControl)
        {
            TextControl textControlTemp = TextControlService.SelectTextControlByTCID(textControl.TCID);
            textControlTemp.TCID = textControl.TCID;
            textControlTemp.TCCIID = textControl.TCCIID;
            textControlTemp.TCIsFlage = textControl.TCIsFlage;
            textControlTemp.TCShowType = textControl.TCShowType;
            textControlTemp.TCMarkType = textControl.TCMarkType;
            textControlTemp.TCIsEnable = textControl.TCIsEnable;
            return TextControlService.UpdateTextControl(textControlTemp) > 0 ? true : false;
        }
          
           
        /// <summary>
        /// 根据TCID查询TextControl
        /// <param name="textControl">对象实例</param>
        public static TextControl SelectTextControlByTCID(Int32  _tCID)
        {
            return TextControlService.SelectTextControlByTCID( _tCID);
        }
        
        
        /// <summary>
        /// 查询所有TextControl
        /// </summary>
        public static IList<TextControl> SelectAllTextControl()
        {
            return  TextControlService.SelectAllTextControl();
        }
    }
}
