using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Controllers.Models;
using Controllers.DataAccess.SQLHELPER;
using System.Data;
using System.Data.SqlClient;
using Controllers.DataAccess;

namespace Controllers.DataAccess
{
    public class ControlInfoService
    {
         /// <summary>
         /// 根据控件实体得到sql语句
         /// </summary>
         /// <param name="ctList"></param>
         /// <returns></returns>
        public static IList<String> GetSqlStrings(IList<ControlInfo> ctList)
        {
            IList<String> sqlList = new List<String>();
            if (ctList != null)
            {
                foreach (ControlInfo clb in ctList)
                {
                    if (clb.CIID == 0)
                    {
                        //新增控件
                        sqlList.Add(GetAddString(clb));
                    }
                    else if (clb.updateFlage)
                    {
                        sqlList.Add(GetUpdateString(clb));
                    }
                }
            }
            return sqlList;
        }
        
        /// <summary>
        /// 根据控件实体得到insert语句
        /// </summary>
        /// <param name="controlInfo">控件实体</param>
        /// <returns>insert语句</returns>
        private static  String GetAddString(ControlInfo controlInfo)
        {
            StringBuilder cmdText = new StringBuilder();
            cmdText.Append("INSERT INTO ControlInfo ");
            cmdText.Append("                     ( CTName,CTITIID,CTType,CTDefault,CTIsBorder,CTIsTransparent,CTLeft,CTTop,");
            cmdText.Append("                       CTWidth,CTHeight,CTTabKey,CTIsReadOnly,CTVisiable,CTIsMust,CTIsPrint,");
            cmdText.Append("                       CTIsEnable,CTBandsTabel,CTBandsCoumln,CTFont,CTFontColor,CTBorerColor,");
            cmdText.Append("                       CTBackColor,CTIsFlage,CTShowType,CTMarkType,CTMPShowUnit,CTMPHighUnit,");
            cmdText.Append("                       CTMPLowUnit,CTMPBindsID");
            cmdText.Append("                     ) VALUES(");
            cmdText.AppendFormat("'{0}',", controlInfo.CTName);
            cmdText.AppendFormat("'{0}',", controlInfo.CTITIID);
            cmdText.AppendFormat("'{0}',", controlInfo.CTType);
            cmdText.AppendFormat("'{0}',", controlInfo.CTDefault);
            cmdText.AppendFormat("'{0}',", controlInfo.CTIsBorder ? 1 : 0);
            cmdText.AppendFormat("'{0}',", controlInfo.CTIsTransparent ? 1 : 0);
            cmdText.AppendFormat("'{0}',", controlInfo.CTLeft);
            cmdText.AppendFormat("'{0}',", controlInfo.CTTop);
            cmdText.AppendFormat("'{0}',", controlInfo.CTWidth);
            cmdText.AppendFormat("'{0}',", controlInfo.CTHeight);
            cmdText.AppendFormat("'{0}',", controlInfo.CTTabKey);
            cmdText.AppendFormat("'{0}',", controlInfo.CTIsReadOnly?1:0);
            cmdText.AppendFormat("'{0}',", controlInfo.CTVisiable?1:0);
            cmdText.AppendFormat("'{0}',", controlInfo.CTIsMust?1:0);
            cmdText.AppendFormat("'{0}',", controlInfo.CTIsPrint?1:0);
            cmdText.AppendFormat("'{0}',", controlInfo.CTIsEnable?1:0);
            cmdText.AppendFormat("'{0}',", controlInfo.CTBandsTabel);
            cmdText.AppendFormat("'{0}',", controlInfo.CTBandsCoumln);
            cmdText.AppendFormat("'{0}',", controlInfo.CTFont);
            cmdText.AppendFormat("'{0}',", controlInfo.CTFontColor);
            cmdText.AppendFormat("'{0}',", controlInfo.CTBorerColor);
            cmdText.AppendFormat("'{0}',", controlInfo.CTBackColor);
            cmdText.AppendFormat("'{0}',", controlInfo.CTIsFlage?1:0);
            cmdText.AppendFormat("'{0}',", controlInfo.CTShowType);
            cmdText.AppendFormat("'{0}',", controlInfo.CTMarkType);
            cmdText.AppendFormat("'{0}',", controlInfo.CTMPShowUnit);
            cmdText.AppendFormat("'{0}',", controlInfo.CTMPHighUnit);
            cmdText.AppendFormat("'{0}',", controlInfo.CTMPLowUnit);
            cmdText.AppendFormat("'{0}')", controlInfo.CTMPBindsID);
            cmdText.Append(" Select @@Identity ");
            return cmdText.ToString();
        }

        /// <summary>
        /// 根据控件实体得到update语句
        /// </summary>
        /// <param name="controlInfo">控件实体</param>
        /// <returns>update语句</returns>
        private static String GetUpdateString(ControlInfo controlInfo)
        {
            StringBuilder cmdText = new StringBuilder();
            cmdText.Append("UPDATE ControlInfo SET ");
            cmdText.AppendFormat(" CTName = '{0}',", controlInfo.CTName);
            cmdText.AppendFormat(" CTITIID = '{0}',", controlInfo.CTITIID);
            cmdText.AppendFormat(" CTType = '{0}',", controlInfo.CTType);
            cmdText.AppendFormat(" CTDefault = '{0}',", controlInfo.CTDefault);
            cmdText.AppendFormat(" CTIsBorder = '{0}',", controlInfo.CTIsBorder ? 1 : 0);
            cmdText.AppendFormat(" CTIsTransparent = '{0}',", controlInfo.CTIsTransparent?1:0);
            cmdText.AppendFormat(" CTLeft = '{0}',", controlInfo.CTLeft);
            cmdText.AppendFormat(" CTTop = '{0}',", controlInfo.CTTop);
            cmdText.AppendFormat(" CTWidth = '{0}',", controlInfo.CTWidth);
            cmdText.AppendFormat(" CTHeight = '{0}',", controlInfo.CTHeight);
            cmdText.AppendFormat(" CTTabKey = '{0}',", controlInfo.CTTabKey);
            cmdText.AppendFormat(" CTIsReadOnly = '{0}',", controlInfo.CTIsReadOnly ? 1 : 0);
            cmdText.AppendFormat(" CTVisiable = '{0}',", controlInfo.CTVisiable ? 1 : 0);
            cmdText.AppendFormat(" CTIsMust = '{0}',", controlInfo.CTIsMust ? 1 : 0);
            cmdText.AppendFormat(" CTIsPrint = '{0}',", controlInfo.CTIsPrint?1:0);
            cmdText.AppendFormat(" CTIsEnable = '{0}',", controlInfo.CTIsEnable?1:0);
            cmdText.AppendFormat(" CTBandsTabel = '{0}',", controlInfo.CTBandsTabel);
            cmdText.AppendFormat(" CTBandsCoumln = '{0}',", controlInfo.CTBandsCoumln);
            cmdText.AppendFormat(" CTFont = '{0}',", controlInfo.CTFont);
            cmdText.AppendFormat(" CTFontColor = '{0}',", controlInfo.CTFontColor);
            cmdText.AppendFormat(" CTBorerColor = '{0}',", controlInfo.CTBorerColor);
            cmdText.AppendFormat(" CTBackColor = '{0}',", controlInfo.CTBackColor);
            cmdText.AppendFormat(" CTIsFlage = '{0}',", controlInfo.CTIsFlage?1:0);
            cmdText.AppendFormat(" CTShowType = '{0}',", controlInfo.CTShowType);
            cmdText.AppendFormat(" CTMarkType = '{0}',", controlInfo.CTMarkType);
            cmdText.AppendFormat(" CTMPShowUnit = '{0}',", controlInfo.CTMPShowUnit);
            cmdText.AppendFormat(" CTMPHighUnit = '{0}',", controlInfo.CTMPHighUnit);
            cmdText.AppendFormat(" CTMPLowUnit = '{0}',", controlInfo.CTMPLowUnit);
            cmdText.AppendFormat(" CTMPBindsID = '{0}' ", controlInfo.CTMPBindsID);
            cmdText.AppendFormat(" where CIID = '{0}'", controlInfo.CIID);
            return cmdText.ToString();
        }

        /// <summary>
        /// 根据页面控件列表更新数据库
        /// </summary>
        /// <param name="ctList">控件列表集合</param>
        /// <returns>返回保存结果（1成功，-1失败；0无更新）</returns>
        public static int SaveControlsToDataBase(IList<ControlInfo> ctList)
        {
            IList<String> sqlList = new List<String>();
            sqlList = GetSqlStrings(ctList);
            if (sqlList != null && sqlList.Count != 0)
            {
                return new MySqlHelper().ExecDataBySqls(sqlList) ? 1 : -1;//1成功，-1失败；
            }
            else
            {
                return 0;//0无更新
            }
        }
        
        /// <summary>
        /// 添加一个ControlInfo
        /// </summary>
        /// <param name="controlInfo">对象实例</param>
        public static int AddControlInfo(ControlInfo controlInfo)
        {
            return new MySqlHelper().ExecSqlReturnId(GetAddString(controlInfo));
        }


        /// <summary>
        /// 根据CIID删除ControlInfo
        /// </summary>
        /// <param name="CIID">对象属性</param>
        public static int DeleteControlInfoByCIID(Int32 _cIID)
        {
            string cmdText = "DELETE ControlInfo WHERE  CIID = " + _cIID;
            return new MySqlHelper().ExecDataBySql(cmdText);
        }

        /// <summary>
        /// 更新ControlInfo
        /// </summary>
        /// <param name="controlInfo">新的对象实例</param>
        public static int UpdateControlInfo(ControlInfo controlInfo)
        {
            return new MySqlHelper().ExecDataBySql(GetUpdateString(controlInfo));
        }

        /// <summary>
        /// 查询ControlInfo
        /// </summary>
        /// <param name="cmdText">sql命令</param>
        public static IList<ControlInfo> SelectControlInfoByCmdText(String cmdText)
        {
            IList<ControlInfo> controlInfos = new List<ControlInfo>();
            using (SqlDataReader sdr = (SqlDataReader)new MySqlHelper().GetDataReader(cmdText))
            {
                while (sdr.Read())
                {
                    ControlInfo controlInfo = new ControlInfo();
                    controlInfo.CIID = (Convert.ToInt32(sdr[0]));
                    controlInfo.CTName = (Convert.ToString(sdr[1]));
                    controlInfo.CTITIID = (Convert.ToInt32(sdr[2]));
                    controlInfo.CTType = (Convert.ToString(sdr[3]));
                    controlInfo.CTDefault = (Convert.ToString(sdr[4]));
                    controlInfo.CTIsBorder = (Convert.ToInt32(sdr[5])==1?true:false);
                    controlInfo.CTIsTransparent = (Convert.ToInt32(sdr[6]) == 1 ? true : false);
                    controlInfo.CTLeft = (Convert.ToInt32(sdr[7]));
                    controlInfo.CTTop = (Convert.ToInt32(sdr[8]));
                    controlInfo.CTWidth = (Convert.ToInt32(sdr[9]));
                    controlInfo.CTHeight = (Convert.ToInt32(sdr[10]));
                    controlInfo.CTTabKey = (Convert.ToInt32(sdr[11]));
                    controlInfo.CTIsReadOnly = (Convert.ToInt32(sdr[12]) == 1 ? true : false);
                    controlInfo.CTVisiable = (Convert.ToInt32(sdr[13]) == 1 ? true : false);
                    controlInfo.CTIsMust = (Convert.ToInt32(sdr[14]) == 1 ? true : false);
                    controlInfo.CTIsPrint = (Convert.ToInt32(sdr[15]) == 1 ? true : false);
                    controlInfo.CTIsEnable = (Convert.ToInt32(sdr[16]) == 1 ? true : false);
                    controlInfo.CTBandsTabel = (Convert.ToString(sdr[17]));
                    controlInfo.CTBandsCoumln = (Convert.ToString(sdr[18]));
                    controlInfo.CTFont = (Convert.ToString(sdr[19]));
                    controlInfo.CTFontColor = (Convert.ToString(sdr[20]));
                    controlInfo.CTBorerColor = (Convert.ToString(sdr[21]));
                    controlInfo.CTBackColor = (Convert.ToString(sdr[22]));
                    controlInfo.CTIsFlage = (Convert.ToInt32(sdr[23]) == 1 ? true : false);
                    controlInfo.CTShowType = (Convert.ToInt32(sdr[24]));
                    controlInfo.CTMarkType = (Convert.ToInt32(sdr[25]));
                    controlInfo.CTMPShowUnit = (Convert.ToInt32(sdr[26]));
                    controlInfo.CTMPHighUnit = (Convert.ToInt32(sdr[27]));
                    controlInfo.CTMPLowUnit = (Convert.ToInt32(sdr[28]));
                    controlInfo.CTMPBindsID = (Convert.ToInt32(sdr[29]));
                    controlInfos.Add(controlInfo);
                }
            }
            return controlInfos;
        }

        /// <summary>
        /// 根据CIID查询ControlInfo
        /// </summary>
        /// <param name=" _cIID">属性值</param>
        public static ControlInfo SelectControlInfoByCIID(Int32 _cIID)
        {
            StringBuilder cmdText = new StringBuilder();
            cmdText.Append("SELECT ");
            cmdText.Append("     CIID,CTName,CTITIID,CTType,CTDefault,CTIsBorder,CTIsTransparent,CTLeft,CTTop,");
            cmdText.Append("     CTWidth,CTHeight,CTTabKey,CTIsReadOnly,CTVisiable,CTIsMust,CTIsPrint,");
            cmdText.Append("     CTIsEnable,CTBandsTabel,CTBandsCoumln,CTFont,CTFontColor,CTBorerColor,");
            cmdText.Append("     CTBackColor,CTIsFlage,CTShowType,CTMarkType,CTMPShowUnit,CTMPHighUnit,");
            cmdText.Append("     CTMPLowUnit,CTMPBindsID");
            cmdText.Append("WHERE CTIsEnable = 1 and ");
            cmdText.AppendFormat("CIID = '{0}' " ,_cIID);
            IList<ControlInfo> controlInfos = SelectControlInfoByCmdText(cmdText.ToString());
            return controlInfos.Count > 0 ? controlInfos[0] : null;
        }       
        
        /// <summary>
        /// 查询返回所有控件实体列表
        /// </summary>
        /// <returns></returns>
        public static IList<ControlInfo> SelectAllControlInfo()
        {
            StringBuilder cmdText = new StringBuilder();
            cmdText.Append("SELECT ");
            cmdText.Append("     CIID,CTName,CTITIID,CTType,CTDefault,CTIsBorder,CTIsTransparent,CTLeft,CTTop,");
            cmdText.Append("     CTWidth,CTHeight,CTTabKey,CTIsReadOnly,CTVisiable,CTIsMust,CTIsPrint,");
            cmdText.Append("     CTIsEnable,CTBandsTabel,CTBandsCoumln,CTFont,CTFontColor,CTBorerColor,");
            cmdText.Append("     CTBackColor,CTIsFlage,CTShowType,CTMarkType,CTMPShowUnit,CTMPHighUnit,");
            cmdText.Append("     CTMPLowUnit,CTMPBindsID ");
            cmdText.Append("From ControlInfo ");
            cmdText.Append(" WHERE CTIsEnable = 1  ");
            return SelectControlInfoByCmdText(cmdText.ToString());
        }

        /// <summary>
        /// 根据模板号查询返回控件实体列表
        /// </summary>
        /// <param name="TemplateID"></param>
        /// <returns></returns>
        public static IList<ControlInfo> SelectControlInfosByTemplateID(int TemplateID)
        {
            StringBuilder cmdText = new StringBuilder();
            cmdText.Append("SELECT ");
            cmdText.Append("     CIID,CTName,CTITIID,CTType,CTDefault,CTIsBorder,CTIsTransparent,CTLeft,CTTop,");
            cmdText.Append("     CTWidth,CTHeight,CTTabKey,CTIsReadOnly,CTVisiable,CTIsMust,CTIsPrint,");
            cmdText.Append("     CTIsEnable,CTBandsTabel,CTBandsCoumln,CTFont,CTFontColor,CTBorerColor,");
            cmdText.Append("     CTBackColor,CTIsFlage,CTShowType,CTMarkType,CTMPShowUnit,CTMPHighUnit,");
            cmdText.Append("     CTMPLowUnit,CTMPBindsID ");
            cmdText.Append("From ControlInfo ");
            cmdText.AppendFormat(" WHERE CTIsEnable = 1 and CTITIID ='{0}' ", TemplateID);
            return SelectControlInfoByCmdText(cmdText.ToString());
        }

        public static DataTable SelectContrilInfoIDByTemplateID(int templateID)
        {
            StringBuilder cmdText = new StringBuilder();
            cmdText.Append("SELECT ");
            cmdText.Append("     CIID ");
            cmdText.Append("From ControlInfo "); 
            cmdText.AppendFormat(" WHERE CTIsEnable = 1 and CTITIID ='{0}' ", templateID);
            return new MySqlHelper().GetDataTable(cmdText.ToString());
        }

        public static DataTable GetContrilPrintInfoByTemplateID(int templateID)
        {

            StringBuilder cmdText = new StringBuilder();
            cmdText.Append("SELECT ");
            cmdText.Append("     CIID,CTName,CTType,CTLeft,CTTop,CTWidth,CTHeight,CTIsPrint,CTFont, ");
            cmdText.Append("     CTFontColor,CTIsFlage  ");
            cmdText.Append("From ControlInfo with(nolock) ");
            cmdText.AppendFormat(" WHERE CTIsEnable = 1 and CTITIID ='{0}' ", templateID);
            return new MySqlHelper().GetDataTable(cmdText.ToString());
        }
    }
}
