using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Controllers.DataAccess.SQLHELPER;
using System.Data;

namespace Controllers.DataAccess
{
    public class PositionService
    {
        static public DataTable GetAllDepartmentNameByCompanyName(int  dIID)
        {
            StringBuilder cmdText = new StringBuilder();
            cmdText.Append("SELECT PIName ");
            cmdText.Append("From PositionInfo with(nolock)  ");
            cmdText.Append("WHERE PIIsEnable = 1  ");
            cmdText.AppendFormat(" and PIDIID = '{0}'  ", dIID);
            return new MySqlHelper().GetDataTable(cmdText.ToString());
        }
    }
}
