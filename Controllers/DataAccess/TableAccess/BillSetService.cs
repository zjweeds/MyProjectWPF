using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Controllers.DataAccess.SQLHELPER;

namespace Controllers.DataAccess
{
    public class BillSetService
    {
        
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
    }
}
