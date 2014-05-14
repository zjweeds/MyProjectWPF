//-----------------------------------------------------------------------------------------------------------------------/
//功能：操作公司表类
//作者：赵建
//版本：v1.0
//创建时间：2013/11/7   15:34:00
//最后一次修改时间：2014/3/17   17:22:00
//----------------------------------------------------------------------------------------------------------------------/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Controllers.Models;
using System.Data;
using System.Data.SqlClient;
using Controllers.DataAccess.SQLHELPER;

namespace Controllers.DataAccess
{    
    public class CompanAccess
    {
        /// <summary>
        /// 数据库帮助类
        /// </summary>
        public MySqlHelper m_sqlHelper = new MySqlHelper();
        
       /// <summary>
       /// 格局指定条件和显示字段，获取SQL查询语句
       /// </summary>
       /// <param name="sFields">要显示的字段</param>
       /// <param name="sWhere">查询条件</param>
       /// <returns>sql查询语句</returns>
        public StringBuilder GetSelectString(String sFields, String sWhere)
        {
            StringBuilder sbSqlString = new StringBuilder();
            if ((sFields == null) || (sFields == String.Empty))
            {
                //字段为null时，默认返回列
                sFields = " * ";
            }
            sbSqlString.Append("select  " + sFields + " from CompanyInfo   with (nolock) ");
            sbSqlString.Append(" where 1=1  and CIIsEnable = 1");
            if ((sWhere != null) && (sWhere != String.Empty))
            {
                sbSqlString.Append(" and  " + sWhere);
            }
            return sbSqlString;
        }

        /// <summary>
        /// 返回sql参数列表
        /// </summary>
        /// <param name="comModers">表实体</param>
        /// <returns>参数列表</returns>
        private List<SqlParameter> GetSqlParameter(CompanyModel comModers)
        {
            List<SqlParameter> SqlPars = new List<SqlParameter>();
            SqlPars.Add(new SqlParameter("@CIName", SqlDbType.NVarChar, 30));
            SqlPars[0].Value = comModers.CIName.Trim();
            SqlPars.Add(new SqlParameter("@CIDescription", SqlDbType.NVarChar, 100));
            SqlPars[1].Value = comModers.CIName.Trim();
            SqlPars.Add(new SqlParameter("@CIParentID", SqlDbType.Int));
            SqlPars[2].Value = comModers.CIName.Trim();
            SqlPars.Add(new SqlParameter("@CICreaterID", SqlDbType.NVarChar, 10));
            SqlPars[3].Value = comModers.CIName.Trim();
            SqlPars.Add(new SqlParameter("@CICreateTime", SqlDbType.DateTime));
            SqlPars[4].Value = comModers.CIName.Trim();
            return SqlPars;
        }

        /// <summary>
        /// 获取实体列表
        /// </summary>
        /// <param name="reader">查询出来的dataRead</param>
        /// <returns>实体列表</returns>
        public static List<CompanyModel> GetList( SqlDataReader reader)
        {
            List<CompanyModel> list = new List<CompanyModel>();
            while (reader.Read())
            {
                CompanyModel company = new CompanyModel();
                if (reader["CIID"] != DBNull.Value)
                {
                    company.CIID = Convert.ToInt32(reader["CIID"]);
                }

                if (reader["CIName"] != DBNull.Value)
                {
                    company.CIName = reader["CIName"].ToString();
                }

                if ( reader["CIDescription"] != DBNull.Value)
                {
                    company.CIDescription = reader["CIDescription"].ToString();
                }

                if ( reader["CIParentID"] != DBNull.Value)
                {
                    company.CIParentID = Convert.ToInt32(reader["CIParentID"].ToString());
                }

                if (reader["CICreateTime"] != DBNull.Value)
                {
                    company.CICreateTime = DateTime.Parse(reader["CICreateTime"].ToString());
                }

                list.Add(company);
            }
            reader.Close();
            return list;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sFields"></param>
        /// <param name="sWhere"></param>
        /// <returns></returns>
        public List<CompanyModel> GetAllCompanyFields(String sFields,String sWhere)
        {
            SqlDataReader sdr=  m_sqlHelper.GetDataReader(GetSelectString(sFields, sWhere).ToString());
            return GetList(sdr);           
        }

        public DataSet GetCompanToDataSet(String sFields, String sWhere)
        {
            return m_sqlHelper.GetDataSet(GetSelectString(sFields, sWhere).ToString());
        }
    }
}
