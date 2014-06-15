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
    /// <summary>
    /// 部门信息表数据层
    /// </summary>
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

        /// <summary>
        /// 根据部门返回部门ID
        /// </summary>
        /// <param name="CompanyName"></param>
        /// <param name="Dname"></param>
        /// <returns></returns>
        static public int GetAllDepartmentIDByCompanyName(String CompanyName,String Dname)
        {
            StringBuilder cmdText = new StringBuilder();
            cmdText.Append("SELECT DIID ");
            cmdText.Append("From DepartmentInfo with(nolock)  ");
            cmdText.Append(" left join  CompanyInfo  with(nolock)  on  CIID = DICIID ");
            cmdText.Append("WHERE DIIsEnable = 1  ");
            cmdText.AppendFormat(" and CIName = '{0}' and  DIName = '{1}' ", CompanyName,Dname);
            return Convert.ToInt32(new MySqlHelper().GetSingleObject(cmdText.ToString()));
        }

        /// <summary>
        /// 根据ID返回名称
        /// </summary>
        /// <param name="DID"></param>
        /// <returns></returns>
        static public int GetDepartmentNameByID(Int32  DID)
        {
            StringBuilder cmdText = new StringBuilder();
            cmdText.Append("SELECT DIName ");
            cmdText.Append("From DepartmentInfo with(nolock)  ");
            cmdText.Append("WHERE DIIsEnable = 1  ");
            cmdText.AppendFormat(" and DIID = '{0}' ", DID);
            return Convert.ToInt32(new MySqlHelper().GetSingleObject(cmdText.ToString()));
        }
        /// <summary>
        /// 添加部门信息
        /// </summary>
        /// <param name="DIName"></param>
        /// <param name="DICIID"></param>
        /// <returns></returns>
        public static int AddDepartment(String DIName, int DICIID)
        {
            String cmdText = String.Format("INSERT INTO DepartmentInfo ( DIName,DICIID) VALUES('{0}','{1}')", DIName, DICIID);
            return new MySqlHelper().ExecDataBySql(cmdText);
        }

        /// <summary>
        /// 更新部门信息
        /// </summary>
        /// <param name="DIName"></param>
        /// <param name="DIID"></param>
        /// <returns></returns>
        public static int UpdateDepartment(String DIName, int DIID)
        {
            String cmdText = String.Format("Update DepartmentInfo Set DIName = '{0}' where DIID ='{1}'", DIName, DIID);
            return new MySqlHelper().ExecDataBySql(cmdText);
        }

       /// <summary>
        /// 删除部门信息
       /// </summary>
       /// <param name="DIID"></param>
       /// <returns></returns>
        public static bool DeleteDepartment(int DIID)
        {
            List<String> cmdList = new List<String>();
            cmdList .Add(String.Format("Update PositionInfo Set PIIsEnable = '0' where PIDIID ='{0}'", DIID));
            cmdList.Add(String.Format("Update DepartmentInfo Set DIIsEnable = '0' where DIID ='{0}'", DIID));
            return new MySqlHelper().ExecDataBySqls(cmdList);
        }
    }
}
