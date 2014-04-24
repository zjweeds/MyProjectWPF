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
        public DataTable SelectDataTableByID(int billTemplateID)
        {
            StringBuilder sbsql = new StringBuilder();
            sbsql.Append(" select TIID,TIName,TIBackground,TIWidth,TIHeight,TITTID,TICodeLegth ");
            sbsql.Append(" from TemplateInfo with(nolock) ");
            sbsql.Append(" where 1=1 ");
            sbsql.Append("       and TIID = @TIID ");
            List<SqlParameter> SqlPars = new List<SqlParameter>();
            SqlPars.Add(new SqlParameter("@TIID", SqlDbType.Int));
            SqlPars[0].Value = billTemplateID;
            return  sqlhelper.GetDataTable(sbsql.ToString(), "", SqlPars);
        }
        /// <summary>
        /// 根据模版号返回模板实体
        /// </summary>
        /// <param name="billTemplateID"></param>
        /// <returns></returns>
        public BillTemplatModer SelectModerByID(int billTemplateID)
        {
            DataTable dtitem = SelectDataTableByID(billTemplateID);
            if (dtitem != null && dtitem.Rows.Count > 0)
            {
                BillTemplatModer btm = new BillTemplatModer();
                btm.TIID = Convert.ToInt32(dtitem.Rows[0][0]);
                btm.TIName = Convert.ToString(dtitem.Rows[0][1]);
                btm.TIBackground = dtitem.Rows[0][2] as byte[];
                btm.TIWidth = Convert.ToInt32(dtitem.Rows[0][3]);
                btm.TIHeight = Convert.ToInt32(dtitem.Rows[0][4]);
                btm.TITTID = Convert.ToInt32(dtitem.Rows[0][5]);
                btm.TICodeLegth = Convert.ToInt32(dtitem.Rows[0][6]);
                return btm;
            }
            else
            {
                return null;
            }
        }


        public int GetTemplateTypeIdByName(String TypeName)
        {
            String sql = "select TTID from TemplateType where TTName = '"+TypeName+"' and TTIsEnable = 1 ";
            object ob=sqlhelper.GetSingleObject(sql);
            if (ob != null)
            {
                return (int)ob;
            }
            else
            {
                return 0;
            }
        }
    }
}
