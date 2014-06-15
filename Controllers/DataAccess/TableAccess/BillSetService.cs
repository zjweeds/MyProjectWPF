/******************************************************************
 * 创 建 人：  赵建
 * 创建时间：  2013-11-16 9:59
 * 描    述：
 *             BillSetS账套信息数据访问层
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
    /// <summary>
    /// BillSetS账套信息数据访问层
    /// </summary>
    public class BillSetService
    {
        /// <summary>
        /// 更新帐套名
        /// </summary>
        /// <param name="Name"></param>
        /// <param name="BSID"></param>
        /// <returns></returns>
        static public int  UpdateName(String Name,int  BSID)
        {
            StringBuilder cmdText = new StringBuilder();
            cmdText.AppendFormat("update BillSetInfo set BSIName = '{0}' where BSIID = '{1}' ",Name,BSID);
            return new MySqlHelper().ExecDataBySql(cmdText.ToString());
        }

        /// <summary>
        /// 根据名称删除
        /// </summary>
        /// <param name="Name"></param>
        /// <returns></returns>
        static public int DeleteByName(String Name)
        {
            StringBuilder cmdText = new StringBuilder();
            cmdText.AppendFormat(" update BillSetInfo set BSIIsEnable = '0' where BSIName = '{0}' ", Name);
            return new MySqlHelper().ExecDataBySql(cmdText.ToString());
        }

        /// <summary>
        /// 根据实体插入信息
        /// </summary>
        /// <param name="bsi"></param>
        /// <returns></returns>
        static public int insertBillSetInfo(BillSetInfo bsi)
        {
            StringBuilder cmdText = new StringBuilder();
            cmdText.Append(" insert into BillSetInfo (BSIName,BSICompanyID,BSICreaterID,BSIIsEnable) ");
            cmdText.Append(" values( " );
            cmdText.AppendFormat(" '{0}', ", bsi.BSIName);
            cmdText.AppendFormat(" '{0}' , ", bsi.BSICompanyID);
            cmdText.AppendFormat(" '{0}', ", bsi.BSICreaterID);
            cmdText.Append(" '1' " );
            cmdText.Append("      ) " );
            return new MySqlHelper().ExecDataBySql(cmdText.ToString());
        }

        /// <summary>
        /// 根据公司名称获取账套名称
        /// </summary>
        /// <param name="CompaneyName"></param>
        /// <returns></returns>
        static public DataTable GetBillSetNameByCompany(String CompaneyName)
        {
            StringBuilder sbsql=new StringBuilder();
            sbsql.Append("select BSIID,BSIName from BillSetInfo join CompanyInfo on CIID = BSICompanyID ");
            sbsql.AppendFormat(" where BSIIsEnable=1 and CIIsEnable=1 and  CIName= '{0}'", CompaneyName);
            return new MySqlHelper().GetDataTable(sbsql.ToString());
        }

        /// <summary>
        /// 根据公司ID 返回账套信息
        /// </summary>
        /// <param name="comID"></param>
        /// <returns></returns>
        static public DataTable GetBillSetNameByCompanyID(int comID)
        {
            StringBuilder sbsql = new StringBuilder();
            sbsql.Append("select BSIID,BSIName from BillSetInfo with(nolock) ");
            sbsql.AppendFormat(" where BSIIsEnable=1  and  BSICompanyID= ' {0}'",comID);
            return new MySqlHelper().GetDataTable(sbsql.ToString());
        }

        /// <summary>
        /// 根据账套名称返回账套ID
        /// </summary>
        /// <param name="BsName"></param>
        /// <returns></returns>
        static public int  GetBillSetID(String BsName)
        {
            StringBuilder sbsql = new StringBuilder();
            sbsql.Append("select BSIID from BillSetInfo with(nolock) ");
            sbsql.AppendFormat(" where BSIIsEnable=1  and  BSIName= ' {0}'", BsName);
            return Convert.ToInt32(new MySqlHelper().GetSingleObject(sbsql.ToString()));
        }

        /// <summary>
        /// 更具账套ID返回信息
        /// </summary>
        /// <param name="bSID"></param>
        /// <returns></returns>
        static public String GetBillSetNameByID(int bSID)
        {
            StringBuilder sbsql = new StringBuilder();
            sbsql.Append("select BSIName from BillSetInfo with(nolock) ");
            sbsql.AppendFormat(" where BSIIsEnable=1  and  BSIID= ' {0}'", bSID);
            return Convert.ToString(new MySqlHelper().GetSingleObject(sbsql.ToString()));
        }
    }
}
