/******************************************************************
 * 创 建 人：  赵建
 * 创建时间：  2013-11-16 9:59
 * 描    述：
 *             部门信息表数据层
 * 版    本：  V1.0      
 * 环    境：  VS2013
******************************************************************/

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
        /// <summary>
        /// 根据公司名返回所有部门
        /// </summary>
        /// <param name="CompanyName"></param>
        /// <returns></returns>
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
