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

        public DataTable SelectControlsByTemplateID(int TemplateID)
        {
            StringBuilder sbSql = new StringBuilder();
            sbSql.Append(" select CTIID,CTITIID,CTIName,CTType,CTIDefault,CTIIsBorder,CTIIsTransparent,CTIFont,CTIFontColor, ");
            sbSql.Append("        CTIBorerColor,CTIBackColor,CTILeft,CTITop,CTIWidth,CTIHeight,CTITabKey,CTIIsReadOnly,");
            sbSql.Append("        CTIVisiable,CTIIsMust,CTIIsPrint ");
            sbSql.Append(" from ControlInfo with (nolock) ");
            sbSql.Append(" where 1=1 ");
            sbSql.Append("       and CTIIsEnable = 1 ");
            sbSql.Append("       and  CTITIID = @CTITIID");
            List<SqlParameter> SqlPars = new List<SqlParameter>();
            SqlPars.Add(new SqlParameter("@CTITIID", SqlDbType.Int));
            SqlPars[0].Value = TemplateID;
            return sqlhelper.GetDataTable(sbSql.ToString(), "", SqlPars);
        }
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
        public ControlModer GetControlModerByID(int ControlId)
        {
            ControlModer cm = null;
            DataTable dt = GetControlDataTableByID(ControlId);
            if (dt!= null)
            {
                DataRow dr = dt.Rows[0];
                cm = new ControlModer();
                cm.CTIID = Convert.ToInt32(dr["CTIID"]);
                cm.CTITIID = Convert.ToInt32(dr["CTITIID"]);
                cm.CTIName = dr["CTIName"].ToString();
                cm.CTType =dr["CTType"].ToString();
                cm.CTIDefault =dr["CTIDefault"].ToString();
                cm.CTIIsBorder = Convert.ToInt32(dr["CTIIsBorder"]);
                cm.CTIIsTransparent = Convert.ToInt32(dr["CTIIsTransparent"]);
                cm.CTIFont = dr["CTIFont"].ToString();
                cm.CTIFontColor = dr["CTIFontColor"].ToString();
                cm.CTIBorerColor =dr["CTIBorerColor"].ToString();
                cm.CTILeft = Convert.ToInt32(dr["CTILeft"]);
                cm.CTITop = Convert.ToInt32(dr["CTITop"]);
                cm.CTIWidth = Convert.ToInt32(dr["CTIWidth"]);
                cm.CTIHeight = Convert.ToInt32(dr["CTIHeight"]);
                cm.CTITabKey = Convert.ToInt32(dr["CTITabKey"]);
                cm.CTIIsReadOnly = Convert.ToInt32(dr["CTIIsReadOnly"]);
                cm.CTIVisiable = Convert.ToInt32(dr["CTIVisiable"]);
                cm.CTIIsMust = Convert.ToInt32(dr["CTIIsMust"]);
                cm.CTIIsPrint = Convert.ToInt32(dr["CTIIsPrint"]);
            }
            return cm;
        }
    }
}
