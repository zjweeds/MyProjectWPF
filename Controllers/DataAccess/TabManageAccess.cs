using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using Controllers.DataAccess.DAL;

namespace Controllers.DataAccess
{
    public class TabManageAccess
    {
        MySqlHelper MySqlHelpers = new MySqlHelper();

        public DataSet SelectTemplateType(string BillSetName, string CompanyName)
        {
            try
            {
                string sql = "select TTName from TemplateType with (nolock) ";
                sql += "          join BillSetInfo with (nolock) on BSIID = TTBillSetID ";
                sql += "          join CompanyInfo with (nolock) on CIID = BSICompanyID ";
                sql += "        where 1=1 ";
                sql += "          and CIName = '" + CompanyName+"'";
                sql += "          and BSIName = '" + BillSetName+"'";
                sql += "        and BSIIsEnable = 1 ";
                sql += "        and CIIsEnable = 1 ";
                sql += "        and TTIsEnable = 1 ";
                return MySqlHelpers.GetDataSet(sql, "Tempy", null);
            }
            catch
            {
                return new DataSet();
            }
        }
    }
}
