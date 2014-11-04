//---------------------------------------------------------—-----//
//功能：DataSource数据源信息业务层逻辑                            //
//作者：赵建                                                      //
//版本：v1.1                                                      //
//创建时间：2014/3/30   12:55:00                                  //
//最后修改时间：2014/5/30   8:55:00                               //
//---------------------------------------------------------------//

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
        /// <summary>
        /// 根据数据源信息返回数据
        /// </summary>
        /// <param name="tableName">数据源表名</param>
        /// <param name="coumlnName">数据源列名</param>
        /// <returns></returns>
        public static DataTable GetAllBandingsInfoByTableAndCoumln(String tableName, String coumlnName)
        {
            return DataSourceService.GetBandingsInfoByTableAndCoumln(tableName, coumlnName, null, null);
        }

        /// <summary>
        /// 根据数据源信息返回数据
        /// </summary>
        /// <param name="tableName">数据源表名</param>
        /// <param name="coumlnName">数据源列名</param>
        /// <param name="whereFeild">条件字段</param>
        /// <param name="whereVuale">字段值</param>
        /// <returns></returns>
        public static DataTable GetBandingsInfoByTableAndCoumln(String tableName, String coumlnName, List<String> whereFeild, List<String> whereVuale)
        {
            return DataSourceService.GetBandingsInfoByTableAndCoumln(tableName, coumlnName, whereFeild, whereVuale);
        }

        /// <summary>
        /// 根据数据源信息返回数据
        /// </summary>
        /// <param name="tableName">数据源表名</param>
        /// <param name="coumlnName">数据源列名</param>
        /// <param name="values">数据源列值</param>
        /// <returns></returns>
        public static DataTable GetAllCoumsBandingsInfoByTableAndCoumln(String tableName, String coumlnName, String values)
        {
            return DataSourceService.GetAllCoumsBandingsInfoByTableAndCoumln(tableName, coumlnName, values);
        }

        /// <summary>
        /// 根据公司名返回公司所有数据源
        /// </summary>
        /// <param name="CompanyNmae"></param>
        /// <returns></returns>
        public static DataTable GetDataTableByCompanyName(String CompanyNmae)
        {
            return DataSourceService.GetDataTableByCompanyName(CompanyNmae);
        }

        /// <summary>
        /// 返回数据源所有列
        /// </summary>
        /// <param name="TabelName">数据源表名</param>
        /// <returns></returns>
        static public DataTable SelectAllInfoByTableName(String TabelName)
        {
            return DataSourceService.SelectAllInfoByTableName(TabelName);
        }

        /// <summary>
        /// 返回数据源所有列
        /// </summary>
        /// <param name="tableName">数据源表名</param>
        /// <returns></returns>
        static public DataTable GetDataTableByTableName(String tableName)
        {
            return DataSourceService.GetDataTableByTableName(tableName);
        }

        /// <summary>
        /// 增加表
        /// </summary>
        /// <param name="tableName">数据源表名</param>
        /// <param name="companyID">公司ID</param>
        /// <returns></returns>
        static public bool AddTableByName(String tableName, int companyID)
        {
            return DataSourceService.AddTableByName(tableName, companyID);
        }

        /// <summary>
        /// 更新数据源
        /// </summary>
        /// <param name="TabelName">数据源表名</param>
        /// <param name="dt"></param>
        /// <returns></returns>
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
