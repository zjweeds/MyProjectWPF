using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Controllers.DataAccess.DAL;

namespace Controllers.Business
{
    public class ContorlService
    {
        MySqlHelper sqlHelpr = new MySqlHelper();
        
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
                return sqlHelpr.ExecDataBySqls(sqls);
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
                return sqlHelpr.ExecDataBySqls(sqls);
            }
            else
            {
                return false;
            }
        }


    }
}
