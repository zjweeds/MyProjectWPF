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
    public class BillSetService
    {

        static public int  UpdateName(String Name,int  BSID)
        {
            StringBuilder cmdText = new StringBuilder();
            cmdText.AppendFormat("update BillSetInfo set BSIName = '{0}' where BSIID = '{1}' ",Name,BSID);
            return new MySqlHelper().ExecDataBySql(cmdText.ToString());
        }

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

        static public DataTable GetBillSetNameByCompanyID(int comID)
        {
            StringBuilder sbsql = new StringBuilder();
            sbsql.Append("select BSIID,BSIName from BillSetInfo with(nolock) ");
            sbsql.AppendFormat(" where BSIIsEnable=1  and  BSICompanyID= ' {0}'",comID);
            return new MySqlHelper().GetDataTable(sbsql.ToString());
        }

        static public String GetBillSetNameByID(int bSID)
        {
            StringBuilder sbsql = new StringBuilder();
            sbsql.Append("select BSIName from BillSetInfo with(nolock) ");
            sbsql.AppendFormat(" where BSIIsEnable=1  and  BSIID= ' {0}'", bSID);
            return Convert.ToString(new MySqlHelper().GetSingleObject(sbsql.ToString()));
        }
    }
}
