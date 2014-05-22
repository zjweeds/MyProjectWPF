using System;
using System.Collections.Generic;
using System.Text;
using Controllers.Models;
using System.Data.SqlClient;
using Controllers.DataAccess.SQLHELPER;
namespace Controllers.DataAccess
{
    /// <summary>
    ///本数据访问类由Hirer实体数据访问层工具生成
    /// </summary>
    public class UserInfoService
    {
        /// <summary>
        /// 添加一个UserInfo
        /// </summary>
        /// <param name="userInfo">对象实例</param>
        public static int AddUserInfo(UserInfo userInfo)
        {
            StringBuilder cmdText = new StringBuilder();
            cmdText.Append(" INSERT INTO UserInfo ( ");
            cmdText.Append("                        UIEINo,UIPassword,UICreateTime,UIIsEnable ");
            cmdText.Append("  ) VALUES( ");
            cmdText.Append("                        @UIEINo,@UIPassword,@UICreateTime,@UIIsEnable)");
            cmdText.Append(" Select @@Identity ");
            SqlParameter[] paras = new SqlParameter[]
            {
                new SqlParameter("@UIID",userInfo.UIID),
                new SqlParameter("@UIEINo",userInfo.UIEINo),
                new SqlParameter("@UIPassword",userInfo.UIPassword),
                new SqlParameter("@UICreateTime",userInfo.UICreateTime),
                new SqlParameter("@UIIsEnable",userInfo.UIIsEnable)
            };
            return new MySqlHelper().ExecSqlReturnId(cmdText.ToString(),paras);
        }
     
     
        /// <summary>
        /// 根据UIID删除UserInfo
        /// </summary>
        /// <param name="UIID">对象属性</param>
        public static int DeleteUserInfoByUIID(Int32  _uIID)
        {
            String cmdText = "UPDATE UserInfo SET UIIsEnable = 0 WHERE  UIID = " + _uIID;
            return new MySqlHelper().ExecDataBySql(cmdText);
        }
     
     
        /// <summary>
        /// 更新UserInfo
        /// </summary>
        /// <param name="userInfo">新的对象实例</param>
        public static int UpdateUserInfo(UserInfo userInfo)
        {
            StringBuilder cmdText = new StringBuilder();
            cmdText.Append(" UPDATE UserInfo SET  UIEINo = @UIEINo, UIPassword = @UIPassword, ");
            cmdText.Append("                      UICreateTime = @UICreateTime, UIIsEnable = @UIIsEnable ");
            cmdText.Append("  WHERE UIID =  @UIID");
            SqlParameter[] paras = new SqlParameter[]
            {
                new SqlParameter("@UIID",userInfo.UIID),
                new SqlParameter("@UIEINo",userInfo.UIEINo),
                new SqlParameter("@UIPassword",userInfo.UIPassword),
                new SqlParameter("@UICreateTime",userInfo.UICreateTime),
                new SqlParameter("@UIIsEnable",userInfo.UIIsEnable)
            };
            return new MySqlHelper().ExecDataBySql(cmdText.ToString(), paras);
        }
     
     
        /// <summary>
        /// 查询UserInfo
        /// </summary>
        /// <param name="cmdText">sql命令</param>
        public static IList<UserInfo> SelectUserInfoByCmdText(String cmdText)
        {
            IList<UserInfo> userInfos = new List<UserInfo>();
            using (SqlDataReader sdr = new MySqlHelper().GetDataReader(cmdText))
            {
                while (sdr.Read())
                {
                    UserInfo userInfo = new UserInfo();
                    userInfo.UIID = (Convert.ToInt32(sdr[0]));
                    userInfo.UIEINo = (Convert.ToString(sdr[1]));
                    userInfo.UIPassword = (Convert.ToString(sdr[2]));
                    userInfo.UICreateTime = (Convert.ToDateTime(sdr[3]));
                    userInfo.UIIsEnable = (Convert.ToBoolean(sdr[4]));
                userInfos.Add(userInfo);
                }
            }
            return userInfos;
        }
     
     
        /// <summary>
        /// 根据UIID查询UserInfo
        /// </summary>
        /// <param name=" _uIID">属性值</param>
        public static UserInfo SelectUserInfoByUIID(Int32  _uIID)
        {
            StringBuilder cmdText = new StringBuilder();
            cmdText.Append(" select  ");
            cmdText.Append("                       UIID,UIEINo,UIPassword,UICreateTime,UIIsEnable ");
            cmdText.Append(" From  UserInfo with(nolock) ");
            cmdText.Append("   where UIIsEnable = 1");
            cmdText.AppendFormat("  and UIID = '{0}' ", _uIID);
            IList<UserInfo> userInfos = SelectUserInfoByCmdText(cmdText.ToString());
            return userInfos.Count>0 ? userInfos[0] : null;
        }
     
     
        /// <summary>
        /// 查询所有UserInfo
        /// </summary>
        public static IList<UserInfo> SelectAllUserInfo()
        {
            StringBuilder cmdText = new StringBuilder();
            cmdText.Append(" select  ");
            cmdText.Append("                       UIID,UIEINo,UIPassword,UICreateTime,UIIsEnable ");
            cmdText.Append(" From  UserInfo with(nolock) ");
            cmdText.Append("   where UIIsEnable = 1");
            return SelectUserInfoByCmdText(cmdText.ToString());
        }
      
    }
}
