/******************************************************************
 * 创 建 人：  赵建
 * 创建时间：  2013-11-16 9:59
 * 描    述：
 *             数据源信息表数据层
 * 版    本：  V1.0      
 * 环    境：  VS2013
******************************************************************/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Controllers.DataAccess.SQLHELPER;
using Controllers.Models;

namespace Controllers.DataAccess
{
    public class DataSourceService
    {
        /// <summary>
        /// 根据公司名称，返回公司所有数据源
        /// </summary>
        /// <param name="sCompanyName"></param>
        /// <returns></returns>
        static public DataTable GetDAllinfoByCompanyName(String sCompanyName)
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
                return new MySqlHelper().GetDataTable(sbsql.ToString());
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// 根据公司名返回所有数据源
        /// </summary>
        /// <param name="sCompanyName"></param>
        /// <returns></returns>
        static public DataTable GetDataTableByCompanyName(String sCompanyName)
        {
            StringBuilder sbsql = new StringBuilder();
                sbsql.Append( "select distinct(DSITableName) ");
                sbsql.Append(" from DataSourceInfo with(nolock) ");
                sbsql.Append("  join CompanyInfo with(nolock)");
                sbsql.Append("       on CompanyInfo.CIID = DataSourceInfo.DSICIID ");
                sbsql.Append("  where 1=1 ");
                sbsql.Append("        and CompanyInfo.CIIsEnable = 1 ");
                sbsql.Append("        and DataSourceInfo.DSIIsEnable = 1");
                sbsql.AppendFormat("  and CompanyInfo.CIName ='{0}' ", sCompanyName);
                return new MySqlHelper().GetDataTable(sbsql.ToString());
        }

        /// <summary>
        /// 根据数据源表名返回所有列
        /// </summary>
        /// <param name="tableName"></param>
        /// <returns></returns>
        static public DataTable GetDataTableByTableName(String tableName)
        {
            StringBuilder sbsql = new StringBuilder();
            sbsql.Append("select DSIID,DSIColums ");
            sbsql.Append(" from DataSourceInfo with(nolock) ");
            sbsql.AppendFormat("  where DSITableName ='{0}'  and DSIIsEnable = 1 ", tableName);
            return new MySqlHelper().GetDataTable(sbsql.ToString());
        }

        /// <summary>
        /// 根据ID号返回数据源
        /// </summary>
        /// <param name="dsiid"></param>
        /// <returns></returns>
       static public DataTable GetDataTablelByID(int dsiid)
        {
            try
            {
                StringBuilder sbsql = new StringBuilder();
                sbsql.Append(" select DSIID,DSITableName,DSIColums,DSICIID ");
                sbsql.Append(" from DataSourceInfo with(nolock) ");
                sbsql.Append("      where 1=1 ");
                sbsql.AppendFormat("      and  DSIID= '{0}' ", dsiid);
                return new MySqlHelper().GetDataTable(sbsql.ToString());

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
       static public DataSourceModel GetDataSourceModelByID(int dsiid)
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

        /// <summary>
        /// 根据公司名返回所有数据源实体列表
        /// </summary>
        /// <param name="sCompanyName"></param>
        /// <returns></returns>
       static public List<DataSourceModel> GetDataSourceModelListByComanyName(String sCompanyName)
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

        /// <summary>
        /// 根据数据源信息返回数据
        /// </summary>
        /// <param name="tableName"></param>
        /// <param name="coumlnName"></param>
        /// <returns></returns>
       static public DataTable GetBandingsInfoByTableAndCoumln(String tableName, String coumlnName,List<String> whereFeild,List<String> whereValue)
        {
            try
            {
                StringBuilder sb = new StringBuilder();
                sb.AppendFormat("select {0} from {1} where 1=1 ", coumlnName, tableName);
                if (whereFeild != null && whereValue !=null)
                {
                    //有查询条件
                    int i = 0;
                    foreach (String swhere in whereFeild)
                    {
                        //循环添加每一个查询条件
                        sb.AppendFormat(" and {0} = '{1}' ", swhere, whereValue[i]!=null?whereValue[i]:String.Empty);
                        i++;
                    }
                }
                return new MySqlHelper().GetDataTable(sb.ToString());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
     
        /// <summary>
       /// 根据数据源信息返回数据
        /// </summary>
        /// <param name="tableName"></param>
        /// <param name="coumlnName"></param>
        /// <param name="values"></param>
        /// <returns></returns>
        static  public DataTable GetAllCoumsBandingsInfoByTableAndCoumln(String tableName, String coumlnName, String values)
        {
            try
            {
                StringBuilder sb = new StringBuilder();
                sb.AppendFormat("select * from {0} where 1=1 and {1} = '{2}'", tableName,coumlnName,values);
                return new MySqlHelper().GetDataTable(sb.ToString());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// 根据数据源表名返回所有信息
        /// </summary>
        /// <param name="TabelName"></param>
        /// <returns></returns>
       static public DataTable SelectAllInfoByTableName(String TabelName)
       {
          return new MySqlHelper().GetDataTable(String.Format("select * from {0} ", TabelName));
       }

       static public bool UpdateByDt(String TabelName, DataTable dt)
       {
          return  new MySqlHelper().updateByDt(String.Format("select * from {0} ", TabelName), dt);
       }
        /// <summary>
        /// 增加资料表
        /// </summary>
        /// <param name="tableName"></param>
       /// <param name="companyID"></param>
        /// <returns></returns>
       static public bool AddTableByName(String tableName, int companyID)
       {
           StringBuilder cmdText = new StringBuilder();
           cmdText.AppendFormat(" CREATE TABLE {0} ( ", tableName);
           cmdText.Append("	                    [ID] [int] IDENTITY(1,1) NOT NULL, ");
           cmdText.AppendFormat("	                    CONSTRAINT pk_{0} PRIMARY KEY CLUSTERED                 ", tableName);
           cmdText.Append("		                    ( [ID] ASC )   ");
           cmdText.Append("		                WITH( ");
           cmdText.Append("                             PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, ");
           cmdText.Append("                             IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON,");
           cmdText.Append("                            ALLOW_PAGE_LOCKS  = ON");
           cmdText.Append("                         ) ON [PRIMARY]");
           cmdText.Append("                ) ON [PRIMARY]");
           new MySqlHelper().ExecDataBySql(cmdText.ToString());
           StringBuilder sqlText = new StringBuilder();
           sqlText.AppendFormat
               ("insert into DataSourceInfo (DSITableName,DSIColums,DSICIID) values ('{0}','ID','{1}')"
               , tableName, companyID);
           return new MySqlHelper().ExecDataBySql(sqlText.ToString()) > 0 ? true : false;
       }

        /// <summary>
        /// 修改表名
        /// </summary>
        /// <param name="OldName"></param>
        /// <param name="NewName"></param>
        /// <returns></returns>
       static public bool ModifyTabelName(String OldName, String NewName, int CompanyID)
       {
           StringBuilder cmdText = new StringBuilder();
           cmdText.AppendFormat("exec sp_rename '{0}','{1}'", OldName, NewName);
           new MySqlHelper().ExecDataBySql(cmdText.ToString());
           StringBuilder sqlText = new StringBuilder();
           sqlText.AppendFormat
               ("update DataSourceInfo set DSITableName = '{0}'  where  DSIIsEnable = 1 and DSITableName = '{1}' and DSICIID = '{2}'",
                NewName, OldName, CompanyID);          
           StringBuilder sqlText2 = new StringBuilder();
           sqlText2.AppendFormat
                  ("update ControlInfo set CTBandsTabel = '{0}'  where  CTBandsTabel = '{1}'",
                   NewName, OldName);
           List<String> cmdTextList = new List<string>();
           cmdTextList.Add(sqlText.ToString());
           cmdTextList.Add(sqlText2.ToString());
           return new MySqlHelper().ExecDataBySqls(cmdTextList);
     
       }

        /// <summary>
        /// 增加列
        /// </summary>
        /// <param name="ColumnName">列名</param>
        /// <param name="Type">列类型</param>
        /// <param name="TabelName">表名</param>
        /// <param name="CompanyID">公司ID</param>
        /// <returns></returns>
       static public bool AddColumn(String ColumnName, String sType, String TabelName, int CompanyID)
       {
           StringBuilder cmdText = new StringBuilder();
           cmdText.AppendFormat("Alter   Table   {0}   add   {1}   {2} ", TabelName, ColumnName, sType);
           new MySqlHelper().ExecDataBySql(cmdText.ToString());         
               StringBuilder sqlText = new StringBuilder();
               sqlText.AppendFormat
                  ("insert into DataSourceInfo (DSITableName,DSIColums,DSICIID) values ('{0}','{1}','{2}')"
                  , TabelName,ColumnName, CompanyID);
               return new MySqlHelper().ExecDataBySql(sqlText.ToString()) > 0 ? true : false;
       }

        /// <summary>
        /// 删除列
        /// </summary>
        /// <param name="ColumnName"></param>
        /// <param name="sType"></param>
        /// <param name="TabelName"></param>
        /// <param name="CompanyID"></param>
        /// <returns></returns>
       static public bool DeleteColummn(String ColumnName, String TabelName, int CompanyID)
       {
           StringBuilder cmdText = new StringBuilder();
           cmdText.AppendFormat("Alter   table   {0}   drop   column   {1}   ", TabelName, ColumnName);
           new MySqlHelper().ExecDataBySql(cmdText.ToString());
               StringBuilder sqlText = new StringBuilder();
               sqlText.AppendFormat
                  ("update  DataSourceInfo set DSIIsEnable = 0 where DSITableName ='{0}' and  DSIColums = '{1}' and DSICIID = '{2}'"
                  , TabelName, ColumnName, CompanyID);
               return new MySqlHelper().ExecDataBySql(sqlText.ToString()) > 0 ? true : false;
       }

        /// <summary>
        /// 删除数据源
        /// </summary>
        /// <param name="tabelName"></param>
        /// <param name="companyID"></param>
        /// <returns></returns>
       static public bool DeleteTabelByTabelName(String tabelName, int companyID)
       {
           StringBuilder cmdText = new StringBuilder();
           cmdText.AppendFormat("update  DataSourceInfo set DSIIsEnable = 0 where DSITableName ='{0}' and DSICIID = '{1}'"
               , tabelName, companyID);
           return new MySqlHelper().ExecDataBySql(cmdText.ToString()) > 0 ? true : false;
       }
    }
}
