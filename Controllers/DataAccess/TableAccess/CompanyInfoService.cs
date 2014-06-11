/******************************************************************
 * 创 建 人：  赵建
 * 创建时间：  2013-11-16 9:59
 * 描    述：
 *             公司信息数据访问层
 * 版    本：  V1.0      
 * 环    境：  VS2013
******************************************************************/
using System;
using System.Collections.Generic;
using System.Text;
using Controllers.Models;
using System.Data.SqlClient;
using Controllers.DataAccess.SQLHELPER;
using System.Data;

namespace Controllers.DataAccess
{
    public class CompanyInfoService
    {
        /// <summary>
        /// 添加一个CompanyInfo
        /// </summary>
        /// <param name="companyInfo">对象实例</param>
        public static int AddCompanyInfo(CompanyInfo companyInfo)
        {
            StringBuilder cmdText = new StringBuilder();
            cmdText.Append(" INSERT INTO CompanyInfo ( ");
            cmdText.Append("                           CIName,CIDescription,CIParentID,CICreaterID,CICreateTime,CIIsEnable ");
            cmdText.Append("                        ) ");
            cmdText.Append(" VALUES ( ");
             cmdText.Append("          @CIName,@CIDescription,@CIParentID,@CICreaterID,@CICreateTime,'1' ");
             cmdText.Append("       )");
            cmdText.Append(" Select @@Identity ");
            SqlParameter[] paras = new SqlParameter[]
            {
                new SqlParameter("@CIID",companyInfo.CIID),
                new SqlParameter("@CIName",companyInfo.CIName),
                new SqlParameter("@CIDescription",companyInfo.CIDescription),
                new SqlParameter("@CIParentID",companyInfo.CIParentID),
                new SqlParameter("@CICreaterID",companyInfo.CICreaterID),
                new SqlParameter("@CICreateTime",companyInfo.CICreateTime),
            };
            return  new MySqlHelper().ExecSqlReturnId(cmdText.ToString(), paras);
        }
     
     
        /// <summary>
        /// 根据CIID删除CompanyInfo
        /// </summary>
        /// <param name="CIID">对象属性</param>
        public static int DeleteCompanyInfoByCIID(Int32  _cIID)
        {
            string cmdText = "update CompanyInfo set  CIIsEnable=0 WHERE  CIID = " + _cIID;
            return new MySqlHelper().ExecDataBySql(cmdText);
        }
     
     
        /// <summary>
        /// 更新CompanyInfo
        /// </summary>
        /// <param name="companyInfo">新的对象实例</param>
        public static int UpdateCompanyInfo(CompanyInfo companyInfo)
        {
            StringBuilder cmdText = new StringBuilder();
            cmdText.Append(" UPDATE CompanyInfo SET  CIName = @CIName, CIDescription = @CIDescription, ");
            cmdText.Append("                         CIParentID = @CIParentID, CICreaterID = @CICreaterID, ");
            cmdText.Append("                        CICreateTime = @CICreateTime, CIIsEnable = @CIIsEnable  ");
            cmdText.Append("WHERE CIID =  @CIID");
            SqlParameter[] paras = new SqlParameter[]
            {
                new SqlParameter("@CIID",companyInfo.CIID),
                new SqlParameter("@CIName",companyInfo.CIName),
                new SqlParameter("@CIDescription",companyInfo.CIDescription),
                new SqlParameter("@CIParentID",companyInfo.CIParentID),
                new SqlParameter("@CICreaterID",companyInfo.CICreaterID),
                new SqlParameter("@CICreateTime",companyInfo.CICreateTime),
                new SqlParameter("@CIIsEnable",companyInfo.CIIsEnable)
            };
            return new MySqlHelper().ExecDataBySql(cmdText.ToString(), paras);
        }
     
     
        /// <summary>
        /// 查询CompanyInfo
        /// </summary>
        /// <param name="cmdText">sql命令</param>
        public static IList<CompanyInfo> SelectCompanyInfoByCmdText(String cmdText)
        {
            IList<CompanyInfo> companyInfos = new List<CompanyInfo>();
            using (SqlDataReader sdr = new MySqlHelper().GetDataReader(cmdText))
            {
                while (sdr.Read())
                {
                    CompanyInfo companyInfo = new CompanyInfo();
                    companyInfo.CIID = (Convert.ToInt32(sdr[0]));
                    companyInfo.CIName = (Convert.ToString(sdr[1]));
                    companyInfo.CIDescription = (Convert.ToString(sdr[2]));
                    companyInfo.CIParentID = (Convert.ToInt32(sdr[3]));
                    companyInfo.CICreaterID = (Convert.ToString(sdr[4]));
                    companyInfo.CICreateTime = (Convert.ToDateTime(sdr[5]));
                    companyInfo.CIIsEnable = (Convert.ToByte(sdr[6]));
                companyInfos.Add(companyInfo);
                }
            }
            return companyInfos;
        }
     
        /// <summary>
        /// 根据CIID查询CompanyInfo
        /// </summary>
        /// <param name=" _cIID">属性值</param>
        public static CompanyInfo SelectCompanyInfoByCIID(Int32  _cIID)
        {
            StringBuilder cmdText = new StringBuilder();
            cmdText.Append(" select  ");
            cmdText.Append("      CIID,CIName,CIDescription,CIParentID,CICreaterID,CICreateTime,CIIsEnable ");
            cmdText.Append(" FROM CompanyInfo  with(nolock)         ");  
            cmdText.AppendFormat(" WHERE CIIsEnable = 1 and  CIID = '{0}'" ,  _cIID);
            IList<CompanyInfo> companyInfos = SelectCompanyInfoByCmdText(cmdText.ToString());
            return companyInfos.Count>0 ? companyInfos[0] : null;
        }
       
        /// <summary>
        /// 查询所有CompanyInfo
        /// </summary>
        public static IList<CompanyInfo> SelectAllCompanyInfo()
        {
             StringBuilder cmdText = new StringBuilder();
             cmdText.Append(" select  ");
             cmdText.Append("      CIID,CIName,CIDescription,CIParentID,CICreaterID,CICreateTime,CIIsEnable ");
             cmdText.Append(" FROM CompanyInfo  with(nolock)   ");  
             cmdText.Append(" WHERE CIIsEnable = 1 ");
            return SelectCompanyInfoByCmdText(cmdText.ToString());
        }

        /// <summary>
        /// 返回所有公司名
        /// </summary>
        /// <returns></returns>
        public static DataTable GetAllCompanyName()
        {
            StringBuilder cmdText = new StringBuilder();
            cmdText.Append(" select  ");
            cmdText.Append("      CIID,CIName");
            cmdText.Append(" FROM CompanyInfo  with(nolock)   ");
            cmdText.Append(" WHERE CIIsEnable = 1 ");
            return new MySqlHelper().GetDataTable(cmdText.ToString());
        }

        /// <summary>
        /// 根据公司名返回公司ID
        /// </summary>
        /// <param name="CompanyName"></param>
        /// <returns></returns>
        public static Int32 GetIDByCompanyName(String CompanyName)
        {
            StringBuilder cmdText = new StringBuilder();
            cmdText.Append(" select  ");
            cmdText.Append("      CIID");
            cmdText.Append(" FROM CompanyInfo  with(nolock)   ");
            cmdText.AppendFormat(" WHERE CIIsEnable = 1 and CIName = '{0}'", CompanyName);
            return Convert.ToInt32(new MySqlHelper().GetSingleObject(cmdText.ToString()));
        }

        /// <summary>
        /// 根据公司名称返回所有子公司
        /// </summary>
        /// <param name="CompanyName"></param>
        /// <returns></returns>
        public static DataTable GetChildrenCompanyByCompanyName(String CompanyName)
        {
            StringBuilder cmdText = new StringBuilder();
            cmdText.Append(" select  ");
            cmdText.Append("      CIID,CIName");
            cmdText.Append(" FROM CompanyInfo  with(nolock)   ");
            cmdText.Append(" where CIParentID = ");
            cmdText.Append("            ( select  CIID");
            cmdText.Append("              FROM CompanyInfo  with(nolock)   ");
            cmdText.AppendFormat("        WHERE CIIsEnable = 1 and CIName = '{0}'", CompanyName);
            cmdText.Append("            ) ");
            cmdText.Append("        AND CIIsEnable = 1 ");
            return new MySqlHelper().GetDataTable(cmdText.ToString());
        }

        /// <summary>
        /// 根据公司id返回所有子公司
        /// </summary>
        /// <param name="CompanyID"></param>
        /// <returns></returns>
        public static int GetChildrenCountsByCompany(int  CompanyID)
        {
            StringBuilder cmdText = new StringBuilder();
            cmdText.Append(" select count(CIID) ");
            cmdText.Append(" FROM CompanyInfo  with(nolock)   ");
            cmdText.AppendFormat(" where CIIsEnable = 1 and CIParentID = '{0}'", CompanyID);
            return Convert.ToInt32 (new MySqlHelper().GetSingleObject(cmdText.ToString()));
        }

    }
}
