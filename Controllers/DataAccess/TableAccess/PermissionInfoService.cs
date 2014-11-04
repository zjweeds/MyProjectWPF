/******************************************************************
 * 创 建 人：  赵建
 * 创建时间：  2013-11-16 9:59
 * 描    述：
 *             权限信息数据层
 * 版    本：  V1.0      
 * 环    境：  VS2013
******************************************************************/
using System;
using System.Collections.Generic;
using System.Text;
using Controllers.Models;
using System.Data.SqlClient;
using Controllers.DataAccess.SQLHELPER;
using System.Data;
namespace Controllers.DataAccess
{
    public class PermissionInfoService
    {
        /// <summary>
        /// 添加一个PermissionInfo
        /// </summary>
        /// <param name="permissionInfo">对象实例</param>
        public static int AddPermissionInfo(PermissionInfo permissionInfo)
        {
            string cmdText = "INSERT INTO PermissionInfo ( PIEINo,PITemplate,PIDataSource,PIBill,PIUser,PISet,PIAdmin ) VALUES(@PIEINo,@PITemplate,@PIDataSource,@PIBill,@PIUser,@PISet，@PIAdmin)";
            SqlParameter[] paras = new SqlParameter[]
            {
                new SqlParameter("@PIID",permissionInfo.PIID),
                new SqlParameter("@PIEINo",permissionInfo.PIEINo),
                new SqlParameter("@PITemplate",permissionInfo.PITemplate),
                new SqlParameter("@PIDataSource",permissionInfo.PIDataSource),
                new SqlParameter("@PIBill",permissionInfo.PIBill),
                new SqlParameter("@PIUser",permissionInfo.PIUser),
                new SqlParameter("@PISet",permissionInfo.PISet),
                new SqlParameter("@PIAdmin",permissionInfo.PIAdmin)
            };
            return  new MySqlHelper().ExecDataBySql(cmdText, paras);
        }
         
        /// <summary>
        /// 根据PIID删除PermissionInfo
        /// </summary>
        /// <param name="PIID">对象属性</param>
        public static int DeletePermissionInfoByPIID(Int32  _pIID)
        {
            string cmdText="DELETE PermissionInfo WHERE  PIID = " +  _pIID;
            return new MySqlHelper().ExecDataBySql(cmdText);
        }
       
        /// <summary>
        /// 更新PermissionInfo
        /// </summary>
        /// <param name="permissionInfo">新的对象实例</param>
        public static int UpdatePermissionInfo(PermissionInfo permissionInfo)
        {
            StringBuilder cmdText = new StringBuilder();
            cmdText.Append(" UPDATE PermissionInfo SET  PIEINo = @PIEINo, PITemplate = @PITemplate, ");
             cmdText.Append("       PIDataSource = @PIDataSource, PIBill = @PIBill, PIUser = @PIUser, ");
             cmdText.Append("       PISet = @PISet, PIAdmin = @PIAdmin WHERE PIID =  @PIID");
            SqlParameter[] paras = new SqlParameter[]
            {
                new SqlParameter("@PIID",permissionInfo.PIID),
                new SqlParameter("@PIEINo",permissionInfo.PIEINo),
                new SqlParameter("@PITemplate",permissionInfo.PITemplate),
                new SqlParameter("@PIDataSource",permissionInfo.PIDataSource),
                new SqlParameter("@PIBill",permissionInfo.PIBill),
                new SqlParameter("@PIUser",permissionInfo.PIUser),
                new SqlParameter("@PISet",permissionInfo.PISet),
                 new SqlParameter("@PIAdmin",permissionInfo.PIAdmin)
            };
            return new MySqlHelper().ExecDataBySql(cmdText.ToString(), paras);
        }
     
        /// <summary>
        /// 查询PermissionInfo
        /// </summary>
        /// <param name="cmdText">sql命令</param>
        public static IList<PermissionInfo> SelectPermissionInfoByCmdText(String cmdText)
        {
            IList<PermissionInfo> permissionInfos = new List<PermissionInfo>();
            using (SqlDataReader sdr = new MySqlHelper().GetDataReader(cmdText))
            {
                while (sdr.Read())
                {
                    PermissionInfo permissionInfo = new PermissionInfo();
                    permissionInfo.PIID = (Convert.ToInt32(sdr[0]));
                    permissionInfo.PIEINo = sdr[1].ToString();
                    permissionInfo.PITemplate = (Convert.ToBoolean(sdr[2]));
                    permissionInfo.PIDataSource = (Convert.ToBoolean(sdr[3]));
                    permissionInfo.PIBill = (Convert.ToBoolean(sdr[4]));
                    permissionInfo.PIUser = (Convert.ToBoolean(sdr[5]));
                    permissionInfo.PISet = (Convert.ToBoolean(sdr[6]));
                    permissionInfo.PIAdmin = (Convert.ToBoolean(sdr[7]));
                permissionInfos.Add(permissionInfo);
                }
            }
            return permissionInfos;
        }
       
        /// <summary>
        /// 根据PIID查询PermissionInfo
        /// </summary>
        /// <param name=" _pIID">属性值</param>
        public static PermissionInfo SelectPermissionInfoByPIID(Int32  _pIID)
        {
            string cmdText="SELECT * FROM PermissionInfo WHERE  PIID = " +  _pIID;
            IList<PermissionInfo> permissionInfos = SelectPermissionInfoByCmdText(cmdText);
            return permissionInfos.Count>0 ? permissionInfos[0] : null;
        }
     
        /// <summary>
        /// 查询所有PermissionInfo
        /// </summary>
        public static IList<PermissionInfo> SelectAllPermissionInfo()
        {
            string cmdText="SELECT * FROM PermissionInfo";
            return SelectPermissionInfoByCmdText(cmdText);
        }

        /// <summary>
        /// 根据工号返回权限信息
        /// </summary>
        /// <param name="eiNo"></param>
        /// <param name="CompanyName"></param>
        /// <returns></returns>
        public static PermissionInfo GetPermissionInfoByEINo(String eiNo, String CompanyName)
        {
            StringBuilder cmdText = new StringBuilder();
            cmdText.Append(" select  *  from PermissionInfo with(nolock)  ");
            cmdText.Append(" join EmployeeInfo with(nolock) on EINO = PIEINO ");
            cmdText.Append(" join CompanyInfo with(nolock) on CIID = EICompanyID ");
            cmdText.Append("  where EIIsEnable = 1 and PIIsEnable=1  and CIIsEnable = 1");
            cmdText.AppendFormat("and EINO = '{0}' and CIName = '{1}' ", eiNo, CompanyName);
            IList<PermissionInfo> permissionInfos = SelectPermissionInfoByCmdText(cmdText.ToString());
            return permissionInfos.Count > 0 ? permissionInfos[0] : null;
        }
        
        /// <summary>
        /// 根据工号返回权限信息
        /// </summary>
        /// <param name="eiNo"></param>
        /// <param name="CompanyID"></param>
        /// <returns></returns>
        public static PermissionInfo GetPermissionInfoByEINo(String eiNo, int CompanyID)
        {
            StringBuilder cmdText = new StringBuilder();
            cmdText.Append(" select  *  from PermissionInfo with(nolock)  ");
            cmdText.Append(" join EmployeeInfo with(nolock) on EINO = PIEINO ");
            cmdText.Append("  where EIIsEnable = 1 and PIIsEnable=1 ");
            cmdText.AppendFormat(" and EINO = '{0}' ", eiNo);
            IList<PermissionInfo> permissionInfos = SelectPermissionInfoByCmdText(cmdText.ToString());
            return permissionInfos.Count > 0 ? permissionInfos[0] : null;
        }

    }
}
