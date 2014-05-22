using System;
using System.Collections.Generic;
using System.Text;
using Controllers.Models;
using Controllers.DataAccess;
namespace Controllers.Business
{
    /// <summary>
    ///本逻辑层由Hirer自动生成工具生成
    /// </summary>
    public class UserInfoManager
    {
        /// <summary>
        /// 添加一个UserInfo
        /// <param name="userInfo">对象实例</param>
        public static bool AddUserInfo(UserInfo userInfo)
        {
            return UserInfoService.AddUserInfo(userInfo) > 0 ? true : false;
        }
    
      
        /// <summary>
        /// 根据UIID删除UserInfo
        /// <param name="UIID">对象属性</param>
        public static bool DeleteUserInfoByUIID(Int32  _uIID)
        {
            return UserInfoService.DeleteUserInfoByUIID( _uIID) > 0 ? true : false;
        }
          
           
        /// <summary>
        /// 更新UserInfo
        /// <param name="userInfo">新的对象实例</param>
        public static bool UpdateUserInfo(UserInfo userInfo)
        {
            UserInfo userInfoTemp = UserInfoService.SelectUserInfoByUIID(userInfo.UIID);
            userInfoTemp.UIID = userInfo.UIID;
            userInfoTemp.UIEINo = userInfo.UIEINo;
            userInfoTemp.UIPassword = userInfo.UIPassword;
            userInfoTemp.UICreateTime = userInfo.UICreateTime;
            userInfoTemp.UIIsEnable = userInfo.UIIsEnable;
            return UserInfoService.UpdateUserInfo(userInfoTemp) > 0 ? true : false;
        }
          
           
        /// <summary>
        /// 根据UIID查询UserInfo
        /// <param name="userInfo">对象实例</param>
        public static UserInfo SelectUserInfoByUIID(Int32  _uIID)
        {
            return UserInfoService.SelectUserInfoByUIID( _uIID);
        }
        
        
        /// <summary>
        /// 查询所有UserInfo
        /// </summary>
        public static IList<UserInfo> SelectAllUserInfo()
        {
            return  UserInfoService.SelectAllUserInfo();
        }
    }
}
