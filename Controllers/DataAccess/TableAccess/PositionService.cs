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
        static public DataTable GetAllPositionNameByDepartment(int dIID)
        {
            StringBuilder cmdText = new StringBuilder();
            cmdText.Append("SELECT PIName ");
            cmdText.Append("From PositionInfo with(nolock)  ");
            cmdText.Append("WHERE PIIsEnable = 1  ");
            cmdText.AppendFormat(" and PIDIID = '{0}'  ", dIID);
            return new MySqlHelper().GetDataTable(cmdText.ToString());
        }

        /// <summary>
        /// 获取职位ID
        /// </summary>
        /// <param name="pIName">职位名称</param>
        /// <param name="dIID">部门ID</param>
        /// <returns></returns>
        static public int GetPositionIDByPositionName(String pIName, int dIID)
        {
            StringBuilder cmdText = new StringBuilder();
            cmdText.Append("SELECT pIID ");
            cmdText.Append("From PositionInfo with(nolock)  ");
            cmdText.Append("WHERE PIIsEnable = 1  ");
            cmdText.AppendFormat(" and PIDIID = '{0}'  ", dIID);
            cmdText.AppendFormat(" and PIName = '{0}' ", pIName);
            return Convert.ToInt32(new MySqlHelper().GetSingleObject(cmdText.ToString()));
        }

        /// <summary>
        /// 删除职位信息
        /// </summary>
        /// <param name="pIID">职位ID</param>
        /// <returns></returns>
        static public bool DeletePosition(int pIID)
        {
            String cmdText = String.Format("Update PositionInfo Set PIIsEnable = '0' where PIID ='{0}'", pIID);
            return new MySqlHelper().ExecDataBySql(cmdText)<0?false:true;
        }

        /// <summary>
        /// 添加职位信息
        /// </summary>
        /// <param name="pIName"></param>
        /// <param name="DIID"></param>
        /// <returns></returns>
        public static int AddPosition(String pIName, int DIID)
        {
            String cmdText = String.Format("INSERT INTO PositionInfo ( PIName,PIDIID) VALUES('{0}','{1}')", pIName, DIID);
            return new MySqlHelper().ExecDataBySql(cmdText);
        }

        /// <summary>
        /// 更新职位名称
        /// </summary>
        /// <param name="pIName"></param>
        /// <param name="PIID"></param>
        /// <returns></returns>
        public static int UpdatePosition(String pIName, int PIID)
        {
            String cmdText = String.Format("Update PositionInfo Set PIName = '{0}' where pIID ='{1}' ", pIName, PIID);
            return new MySqlHelper().ExecDataBySql(cmdText);
        }
    }
}
