//---------------------------------------------------------—-----//
//功能：数据库操作相关业务层逻辑                                   //
//作者：赵建                                                      //
//版本：v1.1                                                      //
//创建时间：2014/3/30   12:55:00                                  //
//最后修改时间：2014/5/30   8:55:00                               //
//---------------------------------------------------------------//
using System;
using System.Collections.Generic;
using System.Text;
using Controllers.Models;
using Controllers.DataAccess;
using System.Data;
namespace Controllers.Business
{

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

        /// <summary>
        /// 根据工号去用户信息
        /// </summary>
        /// <param name="uCode"></param>
        /// <param name="comID"></param>
        /// <returns></returns>
        public static DataTable SelectUserInfoByEINo(String uCode, int comID)
        {
            return UserInfoService.SelectUserInfoByEINo(uCode, comID);
        }

        /// <summary>
        /// 更新密码
        /// </summary>
        /// <param name="uCode"></param>
        /// <param name="pwd"></param>
        /// <returns></returns>
        public static bool UpdateUserPWDByUIEINO(String uCode, String pwd)
        {
            return UserInfoService.UpdateUserPWDByUIEINO(uCode, pwd);
        }
        
    }
}
