using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Controllers.Moders.TableModers;
using Controllers.DataAccess.DAL;
using System.Data;
using System.Data.SqlClient;

namespace Controllers.Business
{
    public class ControlService
    {
        public ControlModer ctm = new ControlModer();
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
                    sb.Append("                             CTIIsMust,CTIIsPrint ");
                    sb.Append("                          ) ");
                    sb.Append("                   vaules ( ");
                    sb.AppendFormat("                     '{0}',", Convert.ToInt32(dr["CTITIID"]));
                    sb.AppendFormat("                     '{0}',", dr["CTIName"].ToString());
                    sb.AppendFormat("                     '{0}',", dr["CTType"].ToString());
                    sb.AppendFormat("                     '{0}',", dr["CTIDefault"].ToString());
                    sb.AppendFormat("                     '{0}',", Convert.ToInt32(dr["CTIIsBorder"]));
                    sb.AppendFormat("                     '{0}',", Convert.ToInt32(dr["CTIIsTransparent"]));
                    sb.AppendFormat("                     '{0}',", dr["CTIFont"] as byte[]);
                    sb.AppendFormat("                     '{0}',", dr["CTIFontColor"] as byte[]);
                    sb.AppendFormat("                     '{0}',", dr["CTIBorerColor"] as byte[]);
                    sb.AppendFormat("                     '{0}',", dr["CTIBackColor"] as byte[]);
                    sb.AppendFormat("                     '{0}',", Convert.ToInt32(dr["CTILeft"]));
                    sb.AppendFormat("                     '{0}',", Convert.ToInt32(dr["CTITop"]));
                    sb.AppendFormat("                     '{0}',", Convert.ToInt32(dr["CTIWidth"]));
                    sb.AppendFormat("                     '{0}',", Convert.ToInt32(dr["CTIHeight"]));
                    sb.AppendFormat("                     '{0}',", Convert.ToInt32(dr["CTITabKey"]));
                    sb.AppendFormat("                     '{0}',", Convert.ToInt32(dr["CTIIsReadOnly"]));
                    sb.AppendFormat("                     '{0}',", Convert.ToInt32(dr["CTIVisiable"]));
                    sb.AppendFormat("                     '{0}',", Convert.ToInt32(dr["CTIIsMust"]));
                    sb.AppendFormat("                     '{0}',", Convert.ToInt32(dr["CTIIsPrint"]));
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
                    sb.AppendFormat("                   CTIFont='{0}',", dr["CTIFont"] as byte[]);
                    sb.AppendFormat("                   CTIFontColor='{0}',", dr["CTIFontColor"] as byte[]);
                    sb.AppendFormat("                   CTIBorerColor='{0}',", dr["CTIBorerColor"] as byte[]);
                    sb.AppendFormat("                   CTIBackColor='{0}',", dr["CTIBackColor"] as byte[]);
                    sb.AppendFormat("                   CTILeft='{0}',", Convert.ToInt32(dr["CTILeft"]));
                    sb.AppendFormat("                   CTITop='{0}',", Convert.ToInt32(dr["CTITop"]));
                    sb.AppendFormat("                   CTIWidth='{0}',", Convert.ToInt32(dr["CTIWidth"]));
                    sb.AppendFormat("                   CTIHeight='{0}',", Convert.ToInt32(dr["CTIHeight"]));
                    sb.AppendFormat("                   CTITabKey='{0}',", Convert.ToInt32(dr["CTITabKey"]));
                    sb.AppendFormat("                   CTIIsReadOnly='{0}',", Convert.ToInt32(dr["CTIIsReadOnly"]));
                    sb.AppendFormat("                   CTIVisiable='{0}',", Convert.ToInt32(dr["CTIVisiable"]));
                    sb.AppendFormat("                   CTIIsMust='{0}',", Convert.ToInt32(dr["CTIIsMust"]));
                    sb.AppendFormat("                   CTIIsPrint='{0}',", Convert.ToInt32(dr["CTIIsPrint"]));
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
                sbsql.Append("        CTIIsMust,CTIIsPrint ");
                sbsql.Append(" form ControlInfo with (nolock) ");
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
        public List<ControlModer> GetControlModerList(DataTable dt)
        {
            List<ControlModer> cmlist = new List<ControlModer>();
            try
            {
                if (dt != null && dt.Rows.Count > 0)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        ControlModer cm = new ControlModer();
                        cm.CTIID = Convert.ToInt32(dt.Rows[i]["CTIID"]);
                        cm.CTITIID = Convert.ToInt32(dt.Rows[i]["CTITIID"]);
                        cm.CTIName = dt.Rows[i]["CTIName"].ToString();
                        cm.CTType = dt.Rows[i]["CTType"].ToString();
                        cm.CTIDefault = dt.Rows[i]["CTIDefault"].ToString();
                        cm.CTIIsBorder = Convert.ToInt32(dt.Rows[i]["CTIIsBorder"]);
                        cm.CTIIsTransparent = Convert.ToInt32(dt.Rows[i]["CTIIsTransparent"]);
                        cm.CTIFont = dt.Rows[i]["CTIFont"] as byte[];
                        cm.CTIFontColor = dt.Rows[i]["CTIFontColor"] as byte[];
                        cm.CTIBorerColor = dt.Rows[i]["CTIBorerColor"] as byte[];
                        cm.CTIBackColor = dt.Rows[i]["CTIBackColor"] as byte[];
                        cm.CTILeft = Convert.ToInt32(dt.Rows[i]["CTILeft"]);
                        cm.CTITop = Convert.ToInt32(dt.Rows[i]["CTITop"]);
                        cm.CTIWidth = Convert.ToInt32(dt.Rows[i]["CTIWidth"]);
                        cm.CTIHeight = Convert.ToInt32(dt.Rows[i]["CTIHeight"]);
                        cm.CTITabKey = Convert.ToInt32(dt.Rows[i]["CTITabKey"]);
                        cm.CTIIsReadOnly = Convert.ToInt32(dt.Rows[i]["CTIIsReadOnly"]);
                        cm.CTIVisiable = Convert.ToInt32(dt.Rows[i]["CTIVisiable"]);
                        cm.CTIIsMust = Convert.ToInt32(dt.Rows[i]["CTIIsMust"]);
                        cm.CTIIsPrint = Convert.ToInt32(dt.Rows[i]["CTIIsPrint"]);

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
            sbSql.Append("        CTIVisiable,CTIIsMust,CTIIsPrint ");
            sbSql.Append(" from ControlInfo with (nolock) ");
            sbSql.Append(" where 1=1 ");
            sbSql.Append("       and CTIIsEnable = 1 ");
            sbSql.Append("       and  CTIID = @CTIID");
            List<SqlParameter> SqlPars = new List<SqlParameter>();
            SqlPars.Add(new SqlParameter("@CTIID", SqlDbType.Int));
            SqlPars[0].Value = ControlId;
            return sqlhelper.GetDataTable(sbSql.ToString(), "", SqlPars);
        }
        
        /// <summary>
        /// 跟据控件ID 返回控件信息（实体）
        /// </summary>
        /// <param name="ControlId"></param>
        /// <returns></returns>
        public ControlModer GetControlModerByID(int ControlId)
        {
            ControlModer cm = null;
            DataTable dt = GetControlDataTableByID(ControlId);
            return GetControlModerList(dt)[0];//只返回符合条件的第一个
        }
    }
}
