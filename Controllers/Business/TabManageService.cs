using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Controllers.Common;
using Controllers.Business;
using Controllers.DataAccess.DAL;
using System.Data;
using Controllers.Moders.TableModers;

namespace Controllers.Business
{    
    public class TabManageService
    {
        MySqlHelper MySqlHelpers = new MySqlHelper();

        /// <summary>
        /// 根据账套名和公司名返回模板类型
        /// </summary>
        /// <param name="BillSetName">账套名</param>
        /// <param name="CompanyName">公司名</param>
        /// <returns>返回datatable</returns>
        public DataTable SelectTemplateType(String BillSetName, String CompanyName)
        {
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.Append("select TTName from TemplateType with (nolock) ");
                sql.Append("          join BillSetInfo with (nolock) on BSIID = TTBillSetID ");
                sql.Append("          join CompanyInfo with (nolock) on CIID = BSICompanyID ");
                sql.Append("        where 1=1 ");
                sql.Append("   and CIName = '" + CompanyName + "' ");
                sql.Append("   and BSIName = '" + BillSetName + "' ");
                //sql.Append( "           and CIName = @Company ");
                //sql.Append("            and BSIName =@BillSet");
                sql.Append("            and BSIIsEnable = 1 ");
                sql.Append("            and CIIsEnable = 1 ");
                sql.Append("           and TTIsEnable = 1 ");

                //List<SqlParameter> sqlParameters = new List<SqlParameter>();
                //sqlParameters.Add(new SqlParameter("@Company", SqlDbType.NVarChar, 30));
                //sqlParameters[0].Value = CompanyName;
                //sqlParameters.Add(new SqlParameter("@BillSet", SqlDbType.NVarChar, 30));
                //sqlParameters[1].Value = BillSetName;
                return MySqlHelpers.GetDataTable(sql.ToString());
            }
            catch
            {
                return new DataTable();
            }
        }

        /// <summary>
        /// 根据账套名和公司名返回模板类型的datatable,将datatable 转换成泛型字符串
        /// </summary>
        /// <param name="BillSetName">账套名</param>
        /// <param name="CompanyName">公司名</param>
        /// <returns></returns>
        public List<String> GetTabName(String BillSetName, String CompanyName)
        {
            List<String> strLists = new List<String>();
            DataTable dt = SelectTemplateType(BillSetName, CompanyName);
            if (dt != null)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    strLists.Add(dt.Rows[i][0].ToString());
                }
            }
            return strLists;
        }

        /// <summary>
        /// 根据模板类别获取模板信息
        /// </summary>
        /// <param name="TypeName">模板类别名</param>
        /// <param name="BillSetName">账套名</param>
        /// <param name="CompanyName">公司名</param>
        /// <returns></returns>
        public DataTable GetTemplateByType(String TypeName, String BillSetName, String CompanyName)
        {
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.Append(" select ti.TIID,ti.TIName,TIBackground,TIWidth,TIHeight,TITTID,TICodeLegth,TIIcon ");
                sql.Append(" from TemplateInfo ti with (nolock) ");
                sql.Append("       join TemplateType tt with (nolock) on tt.TTID = ti.TITTID ");
                sql.Append("       join BillSetInfo bsi with (nolock) on bsi.BSIID = tt.TTBillSetID ");
                sql.Append("       join CompanyInfo ci with (nolock) on ci.CIID = bsi.BSICompanyID ");
                sql.Append(" where 1=1 ");
                sql.Append("       and ti.TIIsEnable = 1 ");
                sql.Append("       and bsi.BSIIsEnable = 1 ");
                sql.Append("       and ci.CIIsEnable = 1 ");
                sql.Append("       and tt.TTIsEnable = 1 ");      
                //sql.Append("       and CIName = @CompanyName ");
                //sql.Append("       and BSIName =@BillSetName");
                //sql.Append("       and TTName = @TTName");
                //List<SqlParameter> SqlPars = new List<SqlParameter>();
                //SqlPars.Add(new SqlParameter("@CompanyName", SqlDbType.NVarChar, 30));
                //SqlPars[0].Value = CompanyName;
                //SqlPars.Add(new SqlParameter("@BillSetName", SqlDbType.NVarChar, 30));
                //SqlPars[1].Value = BillSetName;
                //SqlPars.Add(new SqlParameter("@TTName", SqlDbType.NVarChar, 30));
                //SqlPars[1].Value = TypeName;
                return MySqlHelpers.GetDataTable(sql.ToString(), "template", null);
            }
            catch
            {
                return new DataTable();
            }
        }
        public List<BillTemplatModer> GetListBillTemplatModer(String TypeName, String BillSetName, String CompanyName)
        {
            List<BillTemplatModer> btms = new List<BillTemplatModer>();
            DataTable dtitem = GetTemplateByType(TypeName, BillSetName, CompanyName);
            if (dtitem != null && dtitem.Rows.Count > 0)
            {
                for (int i = 0; i < dtitem.Rows.Count; i++)
                {
                    BillTemplatModer btm = new BillTemplatModer();
                    btm.TIID = Convert.ToInt32(dtitem.Rows[i][0]);
                    btm.TIName = dtitem.Rows[i][1].ToString();
                    btm.TIBackground = dtitem.Rows[i][2] as byte[];
                    btm.TIWidth = Convert.ToInt32(dtitem.Rows[i][3]);
                    btm.TIHeight = Convert.ToInt32(dtitem.Rows[i][4]);
                    btm.TITTID = Convert.ToInt32(dtitem.Rows[i][5]);
                    btm.TICodeLegth = Convert.ToInt32(dtitem.Rows[i][6]);
                    btm.TIIcon = dtitem.Rows[i][7] as byte[];
                    btms.Add(btm);
                }
            }
            return btms;
        }

    }
}
