using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Controllers.DataAccess.DAL;
using Controllers.Moders.TableModers;

namespace Controllers.Business
{
    public class DataSourceService
    {
        public MySqlHelper sqlhelper = new MySqlHelper();
        /// <summary>
        /// 根据公司名称，返回公司所有数据源
        /// </summary>
        /// <param name="sCompanyName"></param>
        /// <returns></returns>
        public DataTable GetDataTableByCompanyName(String sCompanyName)
        {
            try
            {
                StringBuilder sbsql = new StringBuilder();
                sbsql.Append(" select DSIID,DSITableName,DSIColums,DSICIID ");
                sbsql.Append(" from DataSourceInfo with(nolock) ");
                sbsql.Append("  join CompanyInfo with(nolock)");
                sbsql.Append("       on CompanyInfo.CIID = DataSourceInfo.DSICIID ");
                sbsql.Append("  where 1=1 ");
                sbsql.Append("        and CompanyInfo.CIIsEnable = 1 ");
                sbsql.Append("        and DataSourceInfo.DSIIsEnable = 1");
                sbsql.AppendFormat("  and CompanyInfo.CIName ='{0}' ", sCompanyName);
                return sqlhelper.GetDataTable(sbsql.ToString());
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// 根据ID号返回数据源
        /// </summary>
        /// <param name="dsiid"></param>
        /// <returns></returns>
        public DataTable GetDataTablelByID(int dsiid)
        {
            try
            {
                StringBuilder sbsql = new StringBuilder();
                sbsql.Append(" select DSIID,DSITableName,DSIColums,DSICIID ");
                sbsql.Append(" from DataSourceInfo with(nolock) ");
                sbsql.Append("      where 1=1 ");
                sbsql.AppendFormat("      and  DSIID= '{0}' ", dsiid);
                return sqlhelper.GetDataTable(sbsql.ToString());

            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// 根据ID 返回 数据源实体
        /// </summary>
        /// <param name="dsiid"></param>
        /// <returns></returns>
        public DataSourceModel GetDataSourceModelByID(int dsiid)
        {
            try
            {
                DataTable dt = GetDataTablelByID(dsiid);
                DataSourceModel dsm = null;
                if (dt != null && dt.Rows.Count > 0)
                {
                    dsm = new DataSourceModel();
                    dsm.DSIID = Convert.ToInt32(dt.Rows[0][0]);
                    dsm.DSITableName = dt.Rows[0][1].ToString();
                    dsm.DSIColums = dt.Rows[0][2].ToString();
                    dsm.DSICIID = Convert.ToInt32(dt.Rows[0][3]);
                }
                return dsm;
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public List<DataSourceModel> GetDataSourceModelListByComanyName(String sCompanyName)
        {
            try
            {
                DataTable dt = GetDataTableByCompanyName(sCompanyName);
                List<DataSourceModel> dsmlist = new List<DataSourceModel>();
                if (dt != null && dt.Rows.Count > 0)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        DataSourceModel dsm = new DataSourceModel();
                        dsm.DSIID = Convert.ToInt32(dt.Rows[i][0]);
                        dsm.DSITableName = dt.Rows[i][1].ToString();
                        dsm.DSIColums = dt.Rows[i][2].ToString();
                        dsm.DSICIID = Convert.ToInt32(dt.Rows[i][3]);
                        dsmlist.Add(dsm);
                    }
                }
                return dsmlist;
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

    }
}
