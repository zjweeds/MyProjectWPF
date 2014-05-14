using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Controllers.Models;
using Controllers.DataAccess.SQLHELPER;
using System.Data;
using System.Data.SqlClient;

namespace Controllers.DataAccess
{
    public class ControlService
    {
        public ControlModel ctm = new ControlModel();
        public MySqlHelper sqlhelper = new MySqlHelper();
       
        /// <summary>
        /// 根据页面控件信息 添加到数据库 （事务）
        /// </summary>
        /// <param name="dt">包含所有控件信息的DATATABLE</param>
        /// <returns>插入结果</returns>
        public bool AddControlsByDataTable(DataTable dt)
        {
            List<String> sqls = new List<string>();
            if (dt != null && dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    DataRow dr = dt.Rows[i];
                    #region 拼SQL
                    StringBuilder sb = new StringBuilder();
                    sb.Append(" insert  into ControlInfo ( ");
                    sb.Append("                             CTITIID,CTIName,CTType,CTIDefault,CTIIsBorder,CTIIsTransparent, ");
                    sb.Append("                             CTIFont,CTIFontColor,CTIBorerColor,CTIBackColor,CTILeft,CTITop, ");
                    sb.Append("                             CTIWidth,CTIHeight,CTITabKey,CTIIsReadOnly,CTIVisiable, ");
                    sb.Append("                             CTIIsMust,CTIIsPrint,CTIBandsTabel,CTIBandsCoumln ");
                    sb.Append("                          ) ");
                    sb.Append("                   vaules ( ");
                    sb.AppendFormat("                     '{0}',", Convert.ToInt32(dr["CTITIID"]));
                    sb.AppendFormat("                     '{0}',", dr["CTIName"].ToString());
                    sb.AppendFormat("                     '{0}',", dr["CTType"].ToString());
                    sb.AppendFormat("                     '{0}',", dr["CTIDefault"].ToString());
                    sb.AppendFormat("                     '{0}',", Convert.ToInt32(dr["CTIIsBorder"]));
                    sb.AppendFormat("                     '{0}',", Convert.ToInt32(dr["CTIIsTransparent"]));
                    sb.AppendFormat("                     '{0}',", dr["CTIFont"].ToString());
                    sb.AppendFormat("                     '{0}',", dr["CTIFontColor"].ToString());
                    sb.AppendFormat("                     '{0}',", dr["CTIBorerColor"].ToString());
                    sb.AppendFormat("                     '{0}',", dr["CTIBackColor"].ToString());
                    sb.AppendFormat("                     '{0}',", Convert.ToInt32(dr["CTILeft"]));
                    sb.AppendFormat("                     '{0}',", Convert.ToInt32(dr["CTITop"]));
                    sb.AppendFormat("                     '{0}',", Convert.ToInt32(dr["CTIWidth"]));
                    sb.AppendFormat("                     '{0}',", Convert.ToInt32(dr["CTIHeight"]));
                    sb.AppendFormat("                     '{0}',", Convert.ToInt32(dr["CTITabKey"]));
                    sb.AppendFormat("                     '{0}',", Convert.ToInt32(dr["CTIIsReadOnly"]));
                    sb.AppendFormat("                     '{0}',", Convert.ToInt32(dr["CTIVisiable"]));
                    sb.AppendFormat("                     '{0}',", Convert.ToInt32(dr["CTIIsMust"]));
                    sb.AppendFormat("                     '{0}',", Convert.ToInt32(dr["CTIIsPrint"]));
                    sb.AppendFormat("                     '{0}',", dr["CTIBandsTabel"].ToString());
                    sb.AppendFormat("                     '{0}')", dr["CTIBandsCoumln"]).ToString();
                    #endregion
                    sqls.Add(sb.ToString());
                }
            }
            if (sqls.Count != 0)
            {
                return sqlhelper.ExecDataBySqls(sqls);
            }
            else
            {
                return false;
            }
        }

         /// <summary>
        /// 根据页面控件信息 更新数据库 （事务）
        /// </summary>
        /// <param name="dt">包含所有控件信息的DATATABLE</param>
        /// <returns></returns>
        public bool UpdateControlsByDataTable(DataTable dt)
        {
            List<String> sqls = new List<string>();
            if (dt != null && dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    DataRow dr = dt.Rows[i];
                    #region 拼SQL
                    StringBuilder sb = new StringBuilder();
                    sb.Append(" update ControlInfo Set ");
                    sb.AppendFormat("                   CTITIID='{0}',", Convert.ToInt32(dr["CTITIID"]));
                    sb.AppendFormat("                   CTIName='{0}',", dr["CTIName"].ToString());
                    sb.AppendFormat("                   CTType='{0}',", dr["CTType"].ToString());
                    sb.AppendFormat("                   CTIDefault='{0}',", dr["CTIDefault"].ToString());
                    sb.AppendFormat("                   CTIIsBorder='{0}',", Convert.ToInt32(dr["CTIIsBorder"]));
                    sb.AppendFormat("                   CTIIsTransparent='{0}',", Convert.ToInt32(dr["CTIIsTransparent"]));
                    sb.AppendFormat("                   CTIFont='{0}',", dr["CTIFont"].ToString());
                    sb.AppendFormat("                   CTIFontColor='{0}',", dr["CTIFontColor"].ToString());
                    sb.AppendFormat("                   CTIBorerColor='{0}',", dr["CTIBorerColor"].ToString());
                    sb.AppendFormat("                   CTIBackColor='{0}',", dr["CTIBackColor"].ToString());
                    sb.AppendFormat("                   CTILeft='{0}',", Convert.ToInt32(dr["CTILeft"]));
                    sb.AppendFormat("                   CTITop='{0}',", Convert.ToInt32(dr["CTITop"]));
                    sb.AppendFormat("                   CTIWidth='{0}',", Convert.ToInt32(dr["CTIWidth"]));
                    sb.AppendFormat("                   CTIHeight='{0}',", Convert.ToInt32(dr["CTIHeight"]));
                    sb.AppendFormat("                   CTITabKey='{0}',", Convert.ToInt32(dr["CTITabKey"]));
                    sb.AppendFormat("                   CTIIsReadOnly='{0}',", Convert.ToInt32(dr["CTIIsReadOnly"]));
                    sb.AppendFormat("                   CTIVisiable='{0}',", Convert.ToInt32(dr["CTIVisiable"]));
                    sb.AppendFormat("                   CTIIsMust='{0}',", Convert.ToInt32(dr["CTIIsMust"]));
                    sb.AppendFormat("                   CTIIsPrint='{0}',", Convert.ToInt32(dr["CTIIsPrint"]));
                    sb.AppendFormat("                   CTIBandsTabel='{0}',", dr["CTIBandsTabel"].ToString());
                    sb.AppendFormat("                   CTIBandsCoumln='{0}' ", dr["CTIBandsCoumln"]).ToString();
                    sb.AppendFormat("       where 1=1 and CIID = '{0}' ", Convert.ToInt32(dr["CTIID"]));
                    #endregion
                    sqls.Add(sb.ToString());
                }
            }
            if (sqls.Count != 0)
            {
                return sqlhelper.ExecDataBySqls(sqls);
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// 跟据实体信息，得到更新的SQL语句列表
        /// </summary>
        /// <param name="controls"></param>
        /// <param name="textboxextens"></param>
        /// <param name="moneyExtends"></param>
        /// <returns></returns>
        public List<String> GetUpdateStringsByModel(List<ControlModel> controls, List<TextBoxExtendModel> textboxextens, List<MoneyPanelExtendModel> moneyExtends)
        {
            List<String> SqlStrings = new List<string>();
            if (controls != null)
            {
                foreach (ControlModel cm in controls)
                {
                    #region 修改时拼SQL
                    if (cm.updateFlage)
                    {
                        StringBuilder sb = new StringBuilder();
                        sb.Append(" update ControlInfo Set ");
                        sb.AppendFormat("                   CTITIID='{0}',", cm.CTITIID);
                        sb.AppendFormat("                   CTIName='{0}',", cm.CTIName);
                        sb.AppendFormat("                   CTType='{0}',", cm.CTType);
                        sb.AppendFormat("                   CTIDefault='{0}',", cm.CTIDefault);
                        sb.AppendFormat("                   CTIIsBorder='{0}',", cm.CTIIsBorder);
                        sb.AppendFormat("                   CTIIsTransparent='{0}',", cm.CTIIsTransparent);
                        sb.AppendFormat("                   CTIFont='{0}',", cm.CTIFont);
                        sb.AppendFormat("                   CTIFontColor='{0}',", cm.CTIFontColor);
                        sb.AppendFormat("                   CTIBorerColor='{0}',", cm.CTIBorerColor);
                        sb.AppendFormat("                   CTIBackColor='{0}',", cm.CTIBackColor);
                        sb.AppendFormat("                   CTILeft='{0}',", cm.CTILeft);
                        sb.AppendFormat("                   CTITop='{0}',", cm.CTITop);
                        sb.AppendFormat("                   CTIWidth='{0}',", cm.CTIWidth);
                        sb.AppendFormat("                   CTIHeight='{0}',", cm.CTIHeight);
                        sb.AppendFormat("                   CTITabKey='{0}',", cm.CTITabKey);
                        sb.AppendFormat("                   CTIIsReadOnly='{0}',", cm.CTIIsReadOnly);
                        sb.AppendFormat("                   CTIVisiable='{0}',", cm.CTIVisiable);
                        sb.AppendFormat("                   CTIIsMust='{0}',", cm.CTIIsMust);
                        sb.AppendFormat("                   CTIIsPrint='{0}',", cm.CTIIsPrint);
                        sb.AppendFormat("                   CTIBandsTabel='{0}',", cm.CTIBandsTabel);
                        sb.AppendFormat("                   CTIBandsCoumln='{0}' ", cm.CTIBandsCoumln);
                        sb.AppendFormat("       where 1=1 and CIID = '{0}' ", cm.CTIID);
                        SqlStrings.Add(sb.ToString());                   
                    } 
                    #endregion
                    if (cm.CTType == "TextBox")
                    {
                        #region 如果是 TextBox 的话 需要修改 TextBox 拓展表记录
                        TextBoxExtendModel tem = textboxextens.Find((delegate(TextBoxExtendModel p) { return p.TCCIID == cm.CTIID; }));//返回符合条件的第一个元素
                        if (tem.updateFlage)
                        {
                            StringBuilder sbsql = new StringBuilder();
                            sbsql.Append(" Update TextControl Set ");
                            sbsql.AppendFormat("                  TCIsFlage = '{0}',", tem.TCIsFlage);
                            sbsql.AppendFormat("                  TCShowType = '{0}',", tem.TCShowType);
                            sbsql.AppendFormat("                  TCMarkType= '{0}',", tem.TCMarkType);
                            sbsql.AppendFormat(" where 1=1 and TCCIID = '{0}' and TCIsEnable = 1 ", tem.TCCIID);
                            SqlStrings.Add(sbsql.ToString());
                        }
                        #endregion
                    }
                    if (cm.CTType == "MoneyPanel")
                    {
                        #region 如果是 MoneyPanel 的话 需要修改 MoneyPanel 拓展表记录
                        MoneyPanelExtendModel mpem = moneyExtends.Find((delegate(MoneyPanelExtendModel p) { return p.MCCIID == cm.CTIID; }));//返回符合条件的第一个元素
                        if (mpem.updateFlage)
                        {
                            StringBuilder sbsql = new StringBuilder();
                            sbsql.Append(" Update MoneyControl Set ");
                            sbsql.AppendFormat("               MCHeight =    '{0}'", mpem.MCHeight);
                            sbsql.AppendFormat("               MCShowUnit =  '{0}'", mpem.MCShowUnit);
                            sbsql.AppendFormat("               MCHighUnit =  '{0}'", mpem.MCHighUnit);
                            sbsql.AppendFormat("               MCLowUnit  =  '{0}'", mpem.MCLowUnit);
                            sbsql.AppendFormat("               MCBindsID  =  '{0}'", mpem.MCBindsID);
                            sbsql.AppendFormat("  where 1=1 and  MCIsEnable '1'  and MCCIID = '{0}' ", mpem.MCCIID);
                            SqlStrings.Add(sbsql.ToString());
                        }
                        #endregion
                    }
                }
            }
            return SqlStrings;
        }
      
        /// <summary>
        /// 更具控件实体列表，得到更新到数据库的sql语句列表
        /// </summary>
        /// <param name="controls"></param>
        /// <param name="textboxextens"></param>
        /// <param name="moneyExtends"></param>
        /// <returns></returns>
        public List<String> GetAddSqlStringsByModels(List<ControlModel> controls)
        {
            List<String> SqlStrings = new List<string>();
            if (controls != null)
            {
                foreach (ControlModel cm in controls)
                {
                        //新增的控件
                        #region 拼insert SQL
                        StringBuilder sb = new StringBuilder();
                        sb.Append(" insert  into ControlInfo ( ");
                        sb.Append("                             CTITIID,CTIName,CTType,CTIDefault,CTIIsBorder,CTIIsTransparent, ");
                        sb.Append("                             CTIFont,CTIFontColor,CTIBorerColor,CTIBackColor,CTILeft,CTITop, ");
                        sb.Append("                             CTIWidth,CTIHeight,CTITabKey,CTIIsReadOnly,CTIVisiable, ");
                        sb.Append("                             CTIIsMust,CTIIsPrint,CTIBandsTabel,CTIBandsCoumln ");
                        sb.Append("                          ) ");
                        sb.Append("                   vaules ( ");
                        sb.AppendFormat("                     '{0}',", cm.CTITIID);
                        sb.AppendFormat("                     '{0}',", cm.CTIName);
                        sb.AppendFormat("                     '{0}',", cm.CTType);
                        sb.AppendFormat("                     '{0}',", cm.CTIDefault);
                        sb.AppendFormat("                     '{0}',", cm.CTIIsBorder);
                        sb.AppendFormat("                     '{0}',", cm.CTIIsTransparent);
                        sb.AppendFormat("                     '{0}',", cm.CTIFont);
                        sb.AppendFormat("                     '{0}',", cm.CTIFontColor);
                        sb.AppendFormat("                     '{0}',", cm.CTIBorerColor);
                        sb.AppendFormat("                     '{0}',", cm.CTIBackColor);
                        sb.AppendFormat("                     '{0}',", cm.CTILeft);
                        sb.AppendFormat("                     '{0}',", cm.CTITop);
                        sb.AppendFormat("                     '{0}',", cm.CTIWidth);
                        sb.AppendFormat("                     '{0}',", cm.CTIHeight);
                        sb.AppendFormat("                     '{0}',", cm.CTITabKey);
                        sb.AppendFormat("                     '{0}',", cm.CTIIsReadOnly);
                        sb.AppendFormat("                     '{0}',", cm.CTIVisiable);
                        sb.AppendFormat("                     '{0}',", cm.CTIIsMust);
                        sb.AppendFormat("                     '{0}', ", cm.CTIIsPrint);
                        sb.AppendFormat("                     '{0}',", cm.CTIBandsTabel);
                        sb.AppendFormat("                     '{0}') ", cm.CTIBandsCoumln);     
                        #endregion
                        SqlStrings.Add(sb.ToString());
                        #region  废弃
                        //if (cm.CTType == "TextBox")
                        //{
                        //    #region 如果是 TextBox 的话 需要增加 TextBox 拓展表记录
                        //    TextBoxExtendModel tem = textboxextens.Find((delegate(TextBoxExtendModel p) { return p.TCCIID == cm.CTIID; }));//返回符合条件的第一个元素
                        //    StringBuilder sbsql = new StringBuilder();
                        //    sbsql.Append(" insert into TextControl (TCCIID,TCIsFlage,TCShowType,TCMarkType,TCIsEnable) ");
                        //    sbsql.Append("                     vaules ( ");
                        //    sbsql.AppendFormat("                        '{0}'", tem.TCCIID);
                        //    sbsql.AppendFormat("                        '{0}'", tem.TCIsFlage);
                        //    sbsql.AppendFormat("                        '{0}'", tem.TCShowType);
                        //    sbsql.AppendFormat("                        '{0}'", tem.TCMarkType);
                        //    sbsql.Append("                        '1'");
                        //    SqlStrings.Add(sbsql.ToString());
                        //    #endregion
                        //}
                        //if (cm.CTType == "MoneyPanel")
                        //{
                        //    #region 如果是 MoneyPanel 的话 需要增加 MoneyPanel 拓展表记录
                        //    MoneyPanelExtendModel mpem = moneyExtends.Find((delegate(MoneyPanelExtendModel p) { return p.MCCIID == cm.CTIID; }));//返回符合条件的第一个元素
                        //    StringBuilder sbsql = new StringBuilder();
                        //    sbsql.Append(" insert into MoneyControl ( ");
                        //    sbsql.Append("                            MCCIID,MCHeight,MCShowUnit,MCHighUnit,MCLowUnit,MCBindsID，MCIsEnable");
                        //    sbsql.Append("                         )");
                        //    sbsql.Append("                     vaules ( ");
                        //    sbsql.AppendFormat("                        '{0}'", mpem.MCCIID);
                        //    sbsql.AppendFormat("                        '{0}'", mpem.MCHeight);
                        //    sbsql.AppendFormat("                        '{0}'", mpem.MCShowUnit);
                        //    sbsql.AppendFormat("                        '{0}'", mpem.MCHighUnit);
                        //    sbsql.AppendFormat("                        '{0}'", mpem.MCLowUnit);
                        //    sbsql.AppendFormat("                        '{0}'", mpem.MCBindsID);
                        //    sbsql.Append("                        '1'");
                        //    SqlStrings.Add(sbsql.ToString());
                        //    #endregion
                        //}
                        #endregion
                }
            }
            return SqlStrings;
        }
        
        /// <summary>
        /// 根据sql字符串列表更新信息
        /// </summary>
        /// <param name="sqlStrings"></param>
        /// <returns></returns>
        public bool UpdateControlsInfoByStrings(List<String> sqlStrings)
        {
            return sqlhelper.ExecDataBySqls(sqlStrings);
        }

        /// <summary>
        /// 根据实体信息，更新数据库信息(所有)
        /// </summary>
        /// <param name="controls"></param>
        /// <param name="textboxextens"></param>
        /// <param name="moneyExtends"></param>
        /// <returns></returns>
        public bool UpdateControlsByModels(List<ControlModel> controls, List<TextBoxExtendModel> textboxextens, List<MoneyPanelExtendModel> moneyExtends)
        {
            return sqlhelper.ExecDataBySqls(GetUpdateStringsByModel(controls, textboxextens, moneyExtends));
        }
        /// <summary>
        /// 根据实体列表新增数据库信息（排除TextBox和MoneyPanel）
        /// </summary>
        /// <param name="controls"></param>
        /// <param name="textboxextens"></param>
        /// <param name="moneyExtends"></param>
        /// <returns></returns>
        public bool AddControlsByModels(List<ControlModel> controls)
        {
            return sqlhelper.ExecDataBySqls(GetAddSqlStringsByModels(controls));
        }

        /// <summary>
        /// 跟据模板编号查询 模板控件信息(datatable)
        /// </summary>
        /// <param name="templateID"></param>
        /// <returns></returns>
        public DataTable GetDataTableByTemplateID(int templateID)
        {
            try
            {
                StringBuilder sbsql = new StringBuilder();
                sbsql.Append(" select CTIID,CTIName,CTITIID,CTType,CTIDefault,CTIIsBorder,CTIIsTransparent, ");
                sbsql.Append("        CTIFont,CTIFontColor,CTIBorerColor,CTIBackColor,CTILeft,CTITop, ");
                sbsql.Append("        CTIWidth,CTIHeight,CTITabKey,CTIIsReadOnly,CTIVisiable, ");
                sbsql.Append("        CTIIsMust,CTIIsPrint,CTIBandsTabel,CTIBandsCoumln");
                sbsql.Append(" from ControlInfo with (nolock) ");
                sbsql.Append(" where 1=1 ");
                sbsql.Append("       and CTIIsEnable = 1 ");
                sbsql.AppendFormat(" and CTITIID = '{0}' ", templateID);
                return sqlhelper.GetDataTable(sbsql.ToString());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// 跟据datatable返回控件实体列表
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        public List<ControlModel> GetControlModerList(DataTable dt)
        {
            List<ControlModel> cmlist = new List<ControlModel>();
            try
            {
                if (dt != null && dt.Rows.Count > 0)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        ControlModel cm = new ControlModel();
                        cm.CTIID = Convert.ToInt32(dt.Rows[i]["CTIID"]);
                        cm.CTITIID = Convert.ToInt32(dt.Rows[i]["CTITIID"]);
                        cm.CTIName = dt.Rows[i]["CTIName"].ToString();
                        cm.CTType = dt.Rows[i]["CTType"].ToString();
                        cm.CTIDefault = dt.Rows[i]["CTIDefault"].ToString();
                        cm.CTIIsBorder = Convert.ToInt32(dt.Rows[i]["CTIIsBorder"]);
                        cm.CTIIsTransparent = Convert.ToInt32(dt.Rows[i]["CTIIsTransparent"]);
                        cm.CTIFont = dt.Rows[i]["CTIFont"].ToString();
                        cm.CTIFontColor = dt.Rows[i]["CTIFontColor"].ToString();
                        cm.CTIBorerColor = dt.Rows[i]["CTIBorerColor"].ToString();
                        cm.CTIBackColor = dt.Rows[i]["CTIBackColor"].ToString();
                        cm.CTILeft = Convert.ToInt32(dt.Rows[i]["CTILeft"]);
                        cm.CTITop = Convert.ToInt32(dt.Rows[i]["CTITop"]);
                        cm.CTIWidth = Convert.ToInt32(dt.Rows[i]["CTIWidth"]);
                        cm.CTIHeight = Convert.ToInt32(dt.Rows[i]["CTIHeight"]);
                        cm.CTITabKey = Convert.ToInt32(dt.Rows[i]["CTITabKey"]);
                        cm.CTIIsReadOnly = Convert.ToInt32(dt.Rows[i]["CTIIsReadOnly"]);
                        cm.CTIVisiable = Convert.ToInt32(dt.Rows[i]["CTIVisiable"]);
                        cm.CTIIsMust = Convert.ToInt32(dt.Rows[i]["CTIIsMust"]);
                        cm.CTIIsPrint = Convert.ToInt32(dt.Rows[i]["CTIIsPrint"]);
                        cm.CTIBandsTabel = dt.Rows[i]["CTIBandsTabel"].ToString();
                        cm.CTIBandsCoumln = dt.Rows[i]["CTIBandsCoumln"].ToString();
                        cmlist.Add(cm);
                    }
                }
                return cmlist;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #region  废弃
        //public DataTable SelectControlsByTemplateID(int TemplateID)
        //{
        //    StringBuilder sbSql = new StringBuilder();
        //    sbSql.Append(" select CTIID,CTITIID,CTIName,CTType,CTIDefault,CTIIsBorder,CTIIsTransparent,CTIFont,CTIFontColor, ");
        //    sbSql.Append("        CTIBorerColor,CTIBackColor,CTILeft,CTITop,CTIWidth,CTIHeight,CTITabKey,CTIIsReadOnly,");
        //    sbSql.Append("        CTIVisiable,CTIIsMust,CTIIsPrint ");
        //    sbSql.Append(" from ControlInfo with (nolock) ");
        //    sbSql.Append(" where 1=1 ");
        //    sbSql.Append("       and CTIIsEnable = 1 ");
        //    sbSql.Append("       and  CTITIID = @CTITIID");
        //    List<SqlParameter> SqlPars = new List<SqlParameter>();
        //    SqlPars.Add(new SqlParameter("@CTITIID", SqlDbType.Int));
        //    SqlPars[0].Value = TemplateID;
        //    return sqlhelper.GetDataTable(sbSql.ToString(), "", SqlPars);
        //}
        #endregion

        /// <summary>
        /// 跟据控件ID 返回控件信息（datatable）
        /// </summary>
        /// <param name="ControlId"></param>
        /// <returns></returns>
        public DataTable GetControlDataTableByID(int ControlId)
        {
            StringBuilder sbSql = new StringBuilder();
            sbSql.Append(" select CTIID,CTITIID,CTIName,CTType,CTIDefault,CTIIsBorder,CTIIsTransparent,CTIFont,CTIFontColor, ");
            sbSql.Append("        CTIBorerColor,CTIBackColor,CTILeft,CTITop,CTIWidth,CTIHeight,CTITabKey,CTIIsReadOnly,");
            sbSql.Append("        CTIVisiable,CTIIsMust,CTIIsPrint,CTIBandsTabel,CTIBandsCoumln ");
            sbSql.Append(" from ControlInfo with (nolock) ");
            sbSql.Append(" where 1=1 ");
            sbSql.Append("       and CTIIsEnable = 1 ");
            sbSql.AppendFormat(" and  CTIID ='{0}'",ControlId);
            return sqlhelper.GetDataTable(sbSql.ToString());
        }
        
        ///// <summary>
        ///// 跟据控件ID 返回控件信息（实体）
        ///// </summary>
        ///// <param name="ControlId"></param>
        ///// <returns></returns>
        //public ControlModer GetControlModerByID(int ControlId)
        //{
        //    ControlModer cm = null;
        //    DataTable dt = GetControlDataTableByID(ControlId);
        //    return GetControlModerList(dt)[0];//只返回符合条件的第一个
        //}

        /// <summary>
        /// 跟据控件编号，删除控件信息（事务）
        /// </summary>
        /// <param name="CTIID"></param>
        /// <returns></returns>
        public bool DeleteTextBoxByCIID(int CTIID)
        {
            try
            {
                List<String> sqls = new List<String>();
                StringBuilder sbsql = new StringBuilder();
                sbsql.Append(" update ControlInfo Set CTIIsEnable = 0 ");
                sbsql.AppendFormat(" where CTIID = '{0}'", CTIID);
                sqls.Add(sbsql.ToString());
                sbsql.Append(" update TextControl Set TCIsEnable = 0 ");
                sbsql.AppendFormat(" where TCCIID = '{0}'", CTIID);
                sqls.Add(sbsql.ToString());
                sbsql.Append(" update ControlDetails Set CDIsEnable = 0 ");
                sbsql.AppendFormat(" where CDCTIID = '{0}'", CTIID);
                sqls.Add(sbsql.ToString());
                return sqlhelper.ExecDataBySqls(sqls);
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// 跟据金额控件ID，删除金额控件（事务）
        /// </summary>
        /// <param name="CTIID"></param>
        /// <returns></returns>
        public bool DeleteMonyPanelByCIID(int CTIID)
        {
            try
            {
                List<String> sqls = new List<String>();
                StringBuilder sbsql = new StringBuilder();
                sbsql.Append(" update ControlInfo Set CTIIsEnable = 0 ");
                sbsql.AppendFormat(" where CTIID = '{0}'", CTIID);
                sqls.Add(sbsql.ToString());
                sbsql.Append(" update MoneyControl Set MCIsEnable = 0 ");
                sbsql.AppendFormat(" where MCCIID = '{0}'", CTIID);
                sqls.Add(sbsql.ToString());
                sbsql.Append(" update ControlDetails Set CDIsEnable = 0 ");
                sbsql.AppendFormat(" where CDCTIID = '{0}'", CTIID);
                sqls.Add(sbsql.ToString());
                return sqlhelper.ExecDataBySqls(sqls);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// 跟据控件ID，删除控件（事务）
        /// </summary>
        /// <param name="CTIID"></param>
        /// <returns></returns>
        public bool DeleteControlByCIID(int CTIID)
        {
           try
            {
                List<String> sqls = new List<String>();
                StringBuilder sbsql = new StringBuilder();
                sbsql.Append(" update ControlInfo Set CTIIsEnable = 0 ");
                sbsql.AppendFormat(" where CTIID = '{0}'", CTIID);
                sqls.Add(sbsql.ToString());
                sbsql.Append(" update ControlDetails Set CDIsEnable = 0 ");
                sbsql.AppendFormat(" where CDCTIID = '{0}'", CTIID);
                sqls.Add(sbsql.ToString());
                return sqlhelper.ExecDataBySqls(sqls);
            }
            catch (Exception ex)
            {
                throw ex;
            }            
        }

        /// <summary>
        /// 跟据TextBox实体列表更新数据库（含拓展表）
        /// </summary>
        /// <param name="cmtexts"></param>
        /// <param name="textextends"></param>
        /// <returns></returns>
        public bool AddTextBoxByModels(List<ControlModel> cmtexts, List<TextBoxExtendModel> textextends)
        {
            try
            {
                int textCode = 1;
                if (cmtexts != null)
                {
                    foreach (ControlModel cm in cmtexts)
                    {
                        StringBuilder sb = new StringBuilder();
                        sb.Append(" insert  into ControlInfo ( ");
                        sb.Append("                             CTITIID,CTIName,CTType,CTIDefault,CTIIsBorder,CTIIsTransparent, ");
                        sb.Append("                             CTIFont,CTIFontColor,CTIBorerColor,CTIBackColor,CTILeft,CTITop, ");
                        sb.Append("                             CTIWidth,CTIHeight,CTITabKey,CTIIsReadOnly,CTIVisiable, ");
                        sb.Append("                             CTIIsMust,CTIIsPrint,CTIBandsTabel,CTIBandsCoumln ");
                        sb.Append("                          ) ");
                        sb.Append("                   vaules ( ");
                        sb.AppendFormat("                     '{0}',", cm.CTITIID);
                        sb.AppendFormat("                     '{0}',", cm.CTIName);
                        sb.AppendFormat("                     '{0}',", cm.CTType);
                        sb.AppendFormat("                     '{0}',", cm.CTIDefault);
                        sb.AppendFormat("                     '{0}',", cm.CTIIsBorder);
                        sb.AppendFormat("                     '{0}',", cm.CTIIsTransparent);
                        sb.AppendFormat("                     '{0}',", cm.CTIFont);
                        sb.AppendFormat("                     '{0}',", cm.CTIFontColor);
                        sb.AppendFormat("                     '{0}',", cm.CTIBorerColor);
                        sb.AppendFormat("                     '{0}',", cm.CTIBackColor);
                        sb.AppendFormat("                     '{0}',", cm.CTILeft);
                        sb.AppendFormat("                     '{0}',", cm.CTITop);
                        sb.AppendFormat("                     '{0}',", cm.CTIWidth);
                        sb.AppendFormat("                     '{0}',", cm.CTIHeight);
                        sb.AppendFormat("                     '{0}',", cm.CTITabKey);
                        sb.AppendFormat("                     '{0}',", cm.CTIIsReadOnly);
                        sb.AppendFormat("                     '{0}',", cm.CTIVisiable);
                        sb.AppendFormat("                     '{0}',", cm.CTIIsMust);
                        sb.AppendFormat("                     '{0}',", cm.CTIIsPrint);
                        sb.AppendFormat("                     '{0}',", cm.CTIBandsTabel);
                        sb.AppendFormat("                     '{0}' )", cm.CTIBandsCoumln);                       
                        textCode = sqlhelper.ExecSqlReturnId(sb.ToString());
                        TextBoxExtendModel tem = textextends.Find((delegate(TextBoxExtendModel p) { return p.TCCIID == cm.CTIID; }));//返回符合条件的第一个元素
                        if (textCode != 0 && new TextBoxExtendService().AddByTextBoxExtendModel(tem, textCode))
                        {
                            return true;
                        }
                        else
                        {
                            return false;
                        }
                    }
                }
                return true;
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
        
        /// <summary>
        /// 跟据金额实体列表更新数据库（含拓展表）
        /// </summary>
        /// <param name="cmmoneys"></param>
        /// <param name="MoneyPaneltends"></param>
        /// <returns></returns>
        public bool AddMoneyPanelByModels(List<ControlModel> cmmoneys, List<MoneyPanelExtendModel> MoneyPaneltends)
        {
            try
            {
                int MoneyCode = 1;
                if (cmmoneys != null)
                {
                    foreach (ControlModel cm in cmmoneys)
                    {
                        StringBuilder sb = new StringBuilder();
                        sb.Append(" insert  into ControlInfo ( ");
                        sb.Append("                             CTITIID,CTIName,CTType,CTIDefault,CTIIsBorder,CTIIsTransparent, ");
                        sb.Append("                             CTIFont,CTIFontColor,CTIBorerColor,CTIBackColor,CTILeft,CTITop, ");
                        sb.Append("                             CTIWidth,CTIHeight,CTITabKey,CTIIsReadOnly,CTIVisiable, ");
                        sb.Append("                             CTIIsMust,CTIIsPrint,CTIBandsTabel,CTIBandsCoumln ");
                        sb.Append("                          ) ");
                        sb.Append("                   vaules ( ");
                        sb.AppendFormat("                     '{0}',", cm.CTITIID);
                        sb.AppendFormat("                     '{0}',", cm.CTIName);
                        sb.AppendFormat("                     '{0}',", cm.CTType);
                        sb.AppendFormat("                     '{0}',", cm.CTIDefault);
                        sb.AppendFormat("                     '{0}',", cm.CTIIsBorder);
                        sb.AppendFormat("                     '{0}',", cm.CTIIsTransparent);
                        sb.AppendFormat("                     '{0}',", cm.CTIFont);
                        sb.AppendFormat("                     '{0}',", cm.CTIFontColor);
                        sb.AppendFormat("                     '{0}',", cm.CTIBorerColor);
                        sb.AppendFormat("                     '{0}',", cm.CTIBackColor);
                        sb.AppendFormat("                     '{0}',", cm.CTILeft);
                        sb.AppendFormat("                     '{0}',", cm.CTITop);
                        sb.AppendFormat("                     '{0}',", cm.CTIWidth);
                        sb.AppendFormat("                     '{0}',", cm.CTIHeight);
                        sb.AppendFormat("                     '{0}',", cm.CTITabKey);
                        sb.AppendFormat("                     '{0}',", cm.CTIIsReadOnly);
                        sb.AppendFormat("                     '{0}',", cm.CTIVisiable);
                        sb.AppendFormat("                     '{0}',", cm.CTIIsMust);
                        sb.AppendFormat("                     '{0}',", cm.CTIIsPrint);
                        sb.AppendFormat("                     '{0}',", cm.CTIBandsTabel);
                        sb.AppendFormat("                     '{0}' )", cm.CTIBandsCoumln);
                        sb.Append(" Select @@Identity ");
                        MoneyCode = sqlhelper.ExecSqlReturnId(sb.ToString());
                        MoneyPanelExtendModel tem = MoneyPaneltends.Find((delegate(MoneyPanelExtendModel p) { return p.MCCIID == cm.CTIID; }));//返回符合条件的第一个元素
                        if (MoneyCode != 0 && new MoneyPanelExtenService().AddByTMoneyPanelExtendModel(tem, MoneyCode))
                        {
                            return true;
                        }
                        else
                        {
                            return false;
                        }
                    }
                }
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
