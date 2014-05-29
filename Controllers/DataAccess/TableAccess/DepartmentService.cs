using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Controllers.DataAccess.SQLHELPER;
using System.Data;

namespace Controllers.DataAccess
{
    public class DepartmentService
    {
        static public DataTable GetAllDepartmentNameByCompanyName(String CompanyName)
        {
            StringBuilder cmdText = new StringBuilder();
            cmdText.Append("SELECT DIID,DIName ");
            cmdText.Append("From DepartmentInfo with(nolock)  ");
            cmdText.Append(" left join  CompanyInfo  with(nolock)  on  CIID = DICIID ");
            cmdText.Append("WHERE DIIsEnable = 1  ");
            cmdText.AppendFormat(" and CIName = '{0}'  ", CompanyName);
            return new MySqlHelper().GetDataTable(cmdText.ToString());
        }
    }
}
