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
    public class BillTemplateService
    {
        public BillTemplatModer btm = new BillTemplatModer();
        public MySqlHelper sqlhelper = new MySqlHelper();

        /// <summary>
        /// 根据实体添加模板
        /// </summary>
        /// <param name="btm"></param>
        /// <returns></returns>
        public int AddByBillTemplatModer(BillTemplatModer btm)
        {
            try
            {
                StringBuilder sbSql = new StringBuilder();
                sbSql.Append("insert into TemplateInfo (TIName,TIBackground,TIWidth,TIHeight,TITTID,TICodeLegth) ");
                sbSql.Append("values (@TIName,@TIBackground,@TIWidth,@TIHeight,@TITTID,@TICodeLegth) ");
                sbSql.Append(" Select @@Identity ");
                List<SqlParameter> SqlPars = new List<SqlParameter>();
                SqlPars.Add(new SqlParameter("@TIName", SqlDbType.NVarChar, 30));
                SqlPars[0].Value = btm.TIName;
                SqlPars.Add(new SqlParameter("@TIBackground", SqlDbType.Image));
                SqlPars[1].Value = btm.TIBackground;
                SqlPars.Add(new SqlParameter("@TIWidth", SqlDbType.Int));
                SqlPars[2].Value = btm.TIWidth;
                SqlPars.Add(new SqlParameter("@TIHeight", SqlDbType.Int));
                SqlPars[3].Value = btm.TIHeight;
                SqlPars.Add(new SqlParameter("@TITTID", SqlDbType.Int));
                SqlPars[4].Value = btm.TITTID;
                SqlPars.Add(new SqlParameter("@TICodeLegth", SqlDbType.Int));
                SqlPars[5].Value = btm.TICodeLegth;
                return sqlhelper.ExecSqlReturnId(sbSql.ToString(), SqlPars);
            }
            catch (Exception ex)
            {
                throw ex;
            }
         }
       
        /// <summary>
        /// 根据实体更新模板
        /// </summary>
        /// <param name="btm"></param>
        /// <returns></returns>
        public int UpdateByBillTemplatModer(BillTemplatModer btm)
        {
            try
            {
                StringBuilder sbSql = new StringBuilder();
                sbSql.Append("update TemplateInfo set TIName =@TIName,TIBackground=@TIBackground,TIWidth =@TIWidth, ");
                sbSql.Append("                        TIHeight=@TIHeight,TITTID=@TITTID,TICodeLegth=@TICodeLegth   ");
                sbSql.Append(" where TIID=@TIID ");
                List<SqlParameter> SqlPars = new List<SqlParameter>();
                SqlPars.Add(new SqlParameter("@TIName", SqlDbType.NVarChar, 30));
                SqlPars[0].Value = btm.TIName;
                SqlPars.Add(new SqlParameter("@TIBackground", SqlDbType.Image));
                SqlPars[1].Value = btm.TIBackground;
                SqlPars.Add(new SqlParameter("@TIWidth", SqlDbType.Int));
                SqlPars[2].Value = btm.TIWidth;
                SqlPars.Add(new SqlParameter("@TIHeight", SqlDbType.Int));
                SqlPars[3].Value = btm.TIHeight;
                SqlPars.Add(new SqlParameter("@TITTID", SqlDbType.Int));
                SqlPars[4].Value = btm.TITTID;
                SqlPars.Add(new SqlParameter("@TIID", SqlDbType.Int));
                SqlPars[5].Value = btm.TIID;
                SqlPars.Add(new SqlParameter("@TICodeLegth", SqlDbType.Int));
                SqlPars[5].Value = btm.TICodeLegth;
                return sqlhelper.ExecDataBySql(sbSql.ToString(), SqlPars);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        
        /// <summary>
        /// 根据模板编号返回datatable
        /// </summary>
        /// <param name="billTemplateID"></param>
        /// <returns></returns>
        public DataTable GetDataTableByID(int billTemplateID)
        {
            StringBuilder sbsql = new StringBuilder();
            sbsql.Append(" select TIID,TIName,TIBackground,TIWidth,TIHeight,TITTID,TICodeLegth ");
            sbsql.Append(" from TemplateInfo with(nolock) ");
            sbsql.Append(" where 1=1 ");
            sbsql.Append("       and TIID = @TIID ");
            sbsql.Append("       and TIIsEnable = 1");
            List<SqlParameter> SqlPars = new List<SqlParameter>();
            SqlPars.Add(new SqlParameter("@TIID", SqlDbType.Int));
            SqlPars[0].Value = billTemplateID;
            return  sqlhelper.GetDataTable(sbsql.ToString(), "", SqlPars);
        }

        /// <summary>
        /// 根据datatable返回模板实体
        /// </summary>
        /// <param name="billTemplateID"></param>
        /// <returns></returns>
        public List<BillTemplatModer> GetTemplateModerListByDataTable(DataTable dtitem)
        {
            try
            {
                List<BillTemplatModer> btmlist = new List<BillTemplatModer>();
                //DataTable dtitem = SelectDataTableByID(billTemplateID);
                if (dtitem != null && dtitem.Rows.Count > 0)
                {
                    for (int i = 0; i < dtitem.Rows.Count; i++)
                    {
                        BillTemplatModer btm = new BillTemplatModer();
                        btm.TIID = Convert.ToInt32(dtitem.Rows[i][0]);
                        btm.TIName = Convert.ToString(dtitem.Rows[i][1]);
                        btm.TIBackground = dtitem.Rows[i][2] as byte[];
                        btm.TIWidth = Convert.ToInt32(dtitem.Rows[i][3]);
                        btm.TIHeight = Convert.ToInt32(dtitem.Rows[i][4]);
                        btm.TITTID = Convert.ToInt32(dtitem.Rows[i][5]);
                        btm.TICodeLegth = Convert.ToInt32(dtitem.Rows[i][6]);
                        btmlist.Add(btm);
                    }
                    return btmlist;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable GetDataTableByTypeName(String  sTemplateName)
        {
            StringBuilder sbsql = new StringBuilder();
            sbsql.Append(" select TIID,TIName,TIBackground,TIWidth,TIHeight,TITTID,TICodeLegth ");
            sbsql.Append(" from TemplateInfo with(nolock) ");
            sbsql.Append("  join TemplateType with(nolock) ");
            sbsql.Append("     on TemplateType.TTID = TemplateInfo.TITTID ");
            sbsql.Append(" where 1=1 ");
            sbsql.Append("       and TTIsEnable = 1 ");
            sbsql.Append("       and TIIsEnable = 1 ");
            sbsql.AppendFormat(" and TTName = '{0}' ", sTemplateName);
            return sqlhelper.GetDataTable(sbsql.ToString(), "", null);
        }


        #region 废弃
        /// <summary>
        /// 根据页面编号 返回模板datatable
        /// </summary>
        /// <param name="pageID"></param>
        /// <returns></returns>
        public DataTable GetTemplateListByTypePageID(int pageID)
        {
            try
            {
                StringBuilder sbsql = new StringBuilder();
                sbsql.Append(" select TIID,TIName,TIBackground,TIWidth,TIHeight,TITTID,TICodeLegth ");
                sbsql.Append(" from TemplateInfo with(nolock) ");
                sbsql.Append(" join TemplateType with(nolock) ");
                sbsql.Append("     on TemplateType.TTID = TemplateInfo.TITTID ");
                sbsql.Append(" where 1=1 ");
                sbsql.AppendFormat(" and TemplateType.TTIPageID ='{0}' ", pageID);
                sbsql.Append("       and TTIsEnable = 1 and TIIsEnable = 1");
                return sqlhelper.GetDataTable(sbsql.ToString());
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
        #endregion
    }
}
