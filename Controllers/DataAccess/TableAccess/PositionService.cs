/******************************************************************
 * 创 建 人：  赵建
 * 创建时间：  2013-11-16 9:59
 * 描    述：
 *             职位信息数据层
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
    public class PositionService
    {
        /// <summary>
        /// 根据部门返回职位信息
        /// </summary>
        /// <param name="dIID"></param>
        /// <returns></returns>
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
