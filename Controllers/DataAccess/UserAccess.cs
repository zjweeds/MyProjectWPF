using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Controllers.Models;
using Controllers.Common;
using Controllers.DataAccess.SQLHELPER;

namespace Controllers.DataAccess
{
    public class UserAccess
    {
        UserModel userModer = new UserModel();
        private StringBuilder GetSelectString(String showFields,String swhere)
        {
            StringBuilder sbSql =new StringBuilder();
            sbSql.Append("select "+ showFields + "from UserInfo  UI ");
            sbSql.Append("  left join EmployeeInfo EI on EI.EINo = UI.UIEINo ");
            sbSql.Append(" where 1=1 and EI.EIIsEnable = 1 and UI.UIISenable ");
            //sbSql.Append()
            return sbSql;
        }
        public UserModel GetUserInfo(List<String> slists)
        {
           //
            return null;
        }
    }
}
