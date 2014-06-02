using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Controllers.DataAccess;
using Controllers.Models;
using System.Data;

namespace Controllers.Business
{
    public class ControlsInfoManager
    {
        
        /// <summary>
        /// 添加一个ControlInfo
        /// <param name="controlInfo">对象实例</param>
        public static int  AddControlInfo(ControlInfo controlInfo)
        {
            return ControlInfoService.AddControlInfo(controlInfo);
        }
        public static bool AddByDataTable(DataTable controlInfo)
        {
            return ControlInfoService.AddByDataTable(controlInfo);
        }
        /// <summary>
        /// 根据CIID删除ControlInfo
        /// <param name="CIID">对象属性</param>
        public static bool DeleteControlInfoByCIID(Int32  _cIID)
        {
            return ControlInfoService.DeleteControlInfoByCIID( _cIID) > 0 ? true : false;
        }
                 
        /// <summary>
        /// 更新ControlInfo
        /// <param name="controlInfo">新的对象实例</param>
        public static bool UpdateControlInfo(ControlInfo controlInfo)
        {
            ControlInfo controlInfoTemp = ControlInfoService.SelectControlInfoByCIID(controlInfo.CIID);
            controlInfoTemp.CIID = controlInfo.CIID;
            controlInfoTemp.CTName = controlInfo.CTName;
            controlInfoTemp.CTITIID = controlInfo.CTITIID;
            controlInfoTemp.CTType = controlInfo.CTType;
            controlInfoTemp.CTDefault = controlInfo.CTDefault;
            controlInfoTemp.CTIsBorder = controlInfo.CTIsBorder;
            controlInfoTemp.CTIsTransparent = controlInfo.CTIsTransparent;
            controlInfoTemp.CTLeft = controlInfo.CTLeft;
            controlInfoTemp.CTTop = controlInfo.CTTop;
            controlInfoTemp.CTWidth = controlInfo.CTWidth;
            controlInfoTemp.CTHeight = controlInfo.CTHeight;
            controlInfoTemp.CTTabKey = controlInfo.CTTabKey;
            controlInfoTemp.CTIsReadOnly = controlInfo.CTIsReadOnly;
            controlInfoTemp.CTVisiable = controlInfo.CTVisiable;
            controlInfoTemp.CTIsMust = controlInfo.CTIsMust;
            controlInfoTemp.CTIsPrint = controlInfo.CTIsPrint;
            controlInfoTemp.CTIsEnable = controlInfo.CTIsEnable;
            controlInfoTemp.CTBandsTabel = controlInfo.CTBandsTabel;
            controlInfoTemp.CTBandsCoumln = controlInfo.CTBandsCoumln;
            controlInfoTemp.CTFont = controlInfo.CTFont;
            controlInfoTemp.CTFontColor = controlInfo.CTFontColor;
            controlInfoTemp.CTBorerColor = controlInfo.CTBorerColor;
            controlInfoTemp.CTBackColor = controlInfo.CTBackColor;
            controlInfoTemp.CTIsFlage = controlInfo.CTIsFlage;
            controlInfoTemp.CTShowType = controlInfo.CTShowType;
            controlInfoTemp.CTMarkType = controlInfo.CTMarkType;
            controlInfoTemp.CTMPShowUnit = controlInfo.CTMPShowUnit;
            controlInfoTemp.CTMPHighUnit = controlInfo.CTMPHighUnit;
            controlInfoTemp.CTMPLowUnit = controlInfo.CTMPLowUnit;
            controlInfoTemp.CTMPBindsID = controlInfo.CTMPBindsID;
            return ControlInfoService.UpdateControlInfo(controlInfoTemp) > 0 ? true : false;
        }
 
        /// <summary>
        /// 根据ID返回Controlinfo
        /// </summary>
        /// <param name="_cIID"></param>
        /// <returns></returns>
        public static ControlInfo SelectControlInfoByCIID(Int32  _cIID)
        {
            return ControlInfoService.SelectControlInfoByCIID( _cIID);
        }
               
        /// <summary>
        /// 查询所有ControlInfo
        /// </summary>
        public static IList<ControlInfo> SelectAllControlInfo()
        {
            return  ControlInfoService.SelectAllControlInfo();
        }

        /// <summary>
        /// 根据控件实体保存控件信息到数据库
        /// </summary>
        /// <param name="ctList">控件实体</param>
        /// <returns></returns>
        public static int SaveControlsToDataBase(IList<ControlInfo> ctList)
        {
            return ControlInfoService.SaveControlsToDataBase(ctList);
        }

        /// <summary>
        /// 根据模板编号返回控件列表
        /// </summary>
        /// <param name="templateID"></param>
        /// <returns></returns>
        public static IList<ControlInfo> SelectControlInfosByTemplateID(int templateID)
        {
            return ControlInfoService.SelectControlInfosByTemplateID(templateID);
        }

        /// <summary>
        /// 根据模板编号查询返回所有控件编号
        /// </summary>
        /// <param name="templateID">模板编号</param>
        /// <returns>控件编号列表</returns>
        public static IList<Int32> SelectControlsInfoIDByTenplateID(int templateID)
        {
            IList<Int32> intList=new List<Int32>();
            DataTable dt = ControlInfoService.SelectContrilInfoIDByTemplateID(templateID);
            if (dt != null && dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    intList.Add(Convert.ToInt32(dt.Rows[i][0]));
                }
            }
            return intList;
        }

        /// <summary>
        /// 根据控件编号返回DataTable;
        /// </summary>
        /// <param name="templateID">模板编号</param>
        /// <returns>信息列表</returns>
        public static DataTable GetControlInfoByTemplateID(int templateID)
        {
            return ControlInfoService.GetControlInfoByTemplateID(templateID);
        }
    }
}
