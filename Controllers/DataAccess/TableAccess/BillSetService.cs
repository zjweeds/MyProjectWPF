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
        MySqlHelper sqlhelper = new MySqlHelper();
        /// <summary>
        /// 根据公司名称获取账套名称
        /// </summary>
        /// <param name="CompaneyName"></param>
        /// <returns></returns>
        public DataTable GetBillSetNameByCompany(String CompaneyName)
        {
            StringBuilder sbsql=new StringBuilder();
            sbsql.Append("select BSIName from BillSetInfo join CompanyInfo on CIID = BSICompanyID ");
            sbsql.Append(" where BSIIsEnable=1 and CIIsEnable=1 and  CIName= '" + CompaneyName + "'");
            return sqlhelper.GetDataTable(sbsql.ToString());
        }
    }
}
