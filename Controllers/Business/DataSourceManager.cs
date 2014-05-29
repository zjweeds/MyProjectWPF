using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Controllers.DataAccess;

namespace Controllers.Business
{
    public class DataSourceManager
    {
        public static DataTable GetAllBandingsInfoByTableAndCoumln(String tableName, String coumlnName)
        {
            return DataSourceService.GetBandingsInfoByTableAndCoumln(tableName, coumlnName, null, null);
        }

        public static DataTable GetBandingsInfoByTableAndCoumln(String tableName, String coumlnName, List<String> whereFeild, List<String> whereVuale)
        {
            return DataSourceService.GetBandingsInfoByTableAndCoumln(tableName, coumlnName, whereFeild, whereVuale);
        }
        public static DataTable GetAllCoumsBandingsInfoByTableAndCoumln(String tableName, String coumlnName, String values)
        {
            return DataSourceService.GetAllCoumsBandingsInfoByTableAndCoumln(tableName, coumlnName, values);
        }
        public static DataTable GetDataTableByCompanyName(String CompanyNmae)
        {
            return DataSourceService.GetDataTableByCompanyName(CompanyNmae);
        }
        static public DataTable SelectAllInfoByTableName(String TabelName)
        {
            return DataSourceService.SelectAllInfoByTableName(TabelName);
        }
        static public DataTable GetDataTableByTableName(String tableName)
        {
            return DataSourceService.GetDataTableByTableName(tableName);
        }

        /// <summary>
        /// 增加表
        /// </summary>
        /// <param name="tableName"></param>
        /// <param name="companyID"></param>
        /// <returns></returns>
        static public bool AddTableByName(String tableName, int companyID)
        {
            return DataSourceService.AddTableByName(tableName, companyID);
        }
        static public bool UpdateByDt(String TabelName, DataTable dt)
        {
            return DataSourceService.UpdateByDt(TabelName,dt);
        }
        /// <summary>
        /// 修改表名
        /// </summary>
        /// <param name="OldName"></param>
        /// <param name="NewName"></param>
        /// <returns></returns>
        static public bool ModifyTabelName(String OldName, String NewName, int CompanyID)
        {
            return DataSourceService.ModifyTabelName(OldName, NewName, CompanyID);
        }

        /// <summary>
        /// 新增列
        /// </summary>
        /// <param name="ColumnName"></param>
        /// <param name="sType"></param>
        /// <param name="TabelName"></param>
        /// <param name="CompanyID"></param>
        /// <returns></returns>
        static public bool AddColumn(String ColumnName, String sType, String TabelName, int CompanyID)
        {
            return DataSourceService.AddColumn(ColumnName, sType, TabelName, CompanyID);
        }

        /// <summary>
        /// 删除列
        /// </summary>
        /// <param name="ColumnName"></param>
        /// <param name="TabelName"></param>
        /// <param name="CompanyID"></param>
        /// <returns></returns>
        static public bool DeleteColummn(String ColumnName, String TabelName, int CompanyID)
        {
            return DataSourceService.DeleteColummn(ColumnName, TabelName, CompanyID);
        }

        /// <summary>
        /// 删除表
        /// </summary>
        /// <param name="tabelName"></param>
        /// <param name="companyID"></param>
        /// <returns></returns>
        static public bool DeleteTabelByTabelName(String tabelName, int companyID)
        {
            return DataSourceService.DeleteTabelByTabelName(tabelName, companyID);
        }
    }
}
