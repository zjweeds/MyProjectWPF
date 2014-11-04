//---------------------------------------------------------—-----//
//功能：PermissionInfo权限信息业务层逻辑                            //
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
namespace Controllers.Business
{
    public class PermissionInfoManager
    {
        /// <summary>
        /// 添加一个PermissionInfo
        /// <param name="permissionInfo">对象实例</param>
        public static bool AddPermissionInfo(PermissionInfo permissionInfo)
        {
            return PermissionInfoService.AddPermissionInfo(permissionInfo) > 0 ? true : false;
        }
    
      
        /// <summary>
        /// 根据PIID删除PermissionInfo
        /// <param name="PIID">对象属性</param>
        public static bool DeletePermissionInfoByPIID(Int32  _pIID)
        {
            return PermissionInfoService.DeletePermissionInfoByPIID( _pIID) > 0 ? true : false;
        }
          
           
        /// <summary>
        /// 更新PermissionInfo
        /// <param name="permissionInfo">新的对象实例</param>
        public static bool UpdatePermissionInfo(PermissionInfo permissionInfo)
        {
            PermissionInfo permissionInfoTemp = PermissionInfoService.SelectPermissionInfoByPIID(permissionInfo.PIID);
            permissionInfoTemp.PIID = permissionInfo.PIID;
            permissionInfoTemp.PIEINo = permissionInfo.PIEINo;
            permissionInfoTemp.PITemplate = permissionInfo.PITemplate;
            permissionInfoTemp.PIDataSource = permissionInfo.PIDataSource;
            permissionInfoTemp.PIBill = permissionInfo.PIBill;
            permissionInfoTemp.PIUser = permissionInfo.PIUser;
            permissionInfoTemp.PISet = permissionInfo.PISet;
            return PermissionInfoService.UpdatePermissionInfo(permissionInfoTemp) > 0 ? true : false;
        }
          
           
        /// <summary>
        /// 根据PIID查询PermissionInfo
        /// <param name="permissionInfo">对象实例</param>
        public static PermissionInfo SelectPermissionInfoByPIID(Int32  _pIID)
        {
            return PermissionInfoService.SelectPermissionInfoByPIID( _pIID);
        }
        
        
        /// <summary>
        /// 查询所有PermissionInfo
        /// </summary>
        public static IList<PermissionInfo> SelectAllPermissionInfo()
        {
            return  PermissionInfoService.SelectAllPermissionInfo();
        }

        /// <summary>
        /// 根据工号返回权限信息
        /// </summary>
        /// <param name="eiNo">工号</param>
        /// <param name="CompanyName">公司名</param>
        /// <returns></returns>
        public static PermissionInfo GetPermissionInfoByEINo(String eiNo, String CompanyName)
        {
            return PermissionInfoService.GetPermissionInfoByEINo(eiNo, CompanyName);
        }
    }
}
