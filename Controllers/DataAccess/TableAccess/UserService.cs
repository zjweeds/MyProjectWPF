using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Controllers.Models;
using System.Data;
using Controllers.DataAccess.SQLHELPER;

namespace Controllers.DataAccess
{
    public class UserService
    {
        UserModel um = new UserModel();
        MySqlHelper sqlhelper = new MySqlHelper();
        public DataTable GetUserInfoByNo(String uno)
        {
            StringBuilder sbsql = new StringBuilder();
            sbsql.Append("select UIEINo,EIName,UIPassword,EIPhoto,EISex,EIDepartment, ");
            sbsql.Append("       EIPosition,EIBirthday,EIEntryDate,EIRemark,EICompanyID,CIName ");
            sbsql.Append("from EmployeeInfo with(nolock)");
            sbsql.Append("  join CompanyInfo on CIID=EICompanyID ");
            sbsql.Append("  join UserInfo  on UIEINo = EIID ");
            sbsql.Append(" where 1=1 ");
            sbsql.Append("       and EIIsEnable =1 ");
            sbsql.Append("       and UIIsEnable =1 ");
            sbsql.Append("       and CIIsEnable =1 ");
            sbsql.AppendFormat(" and EIID = '{0}'", uno);
            return sqlhelper.GetDataTable(sbsql.ToString());
        }

        public UserModel GetUserModerByNo(String uno)
        {
            DataTable dt = GetUserInfoByNo(uno);
            UserModel um = null;
            if (dt != null)
            {
                um =new UserModel();
                um.ID = dt.Rows[0][0].ToString();
                um.Name = dt.Rows[0][1].ToString();
                um.Pwd = dt.Rows[0][2].ToString();
                um.Photo = dt.Rows[0][3] as byte[];
                um.Sex = dt.Rows[0][4].ToString();
                um.Department = dt.Rows[0][5].ToString();
                um.Position = dt.Rows[0][6].ToString();
                um.Birthday = (DateTime)dt.Rows[0][7];
                um.EntryDate = (DateTime)dt.Rows[0][8];
                um.Remark = dt.Rows[0][9].ToString();
                um.CompanyID =Convert.ToInt32(dt.Rows[0][10]);
                um.Company = dt.Rows[0][11].ToString();
            }
            return um;
        }
    }
}
