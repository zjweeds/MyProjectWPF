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

        public static PermissionInfo GetPermissionInfoByEINo(String eiNo, String CompanyName)
        {
            return PermissionInfoService.GetPermissionInfoByEINo(eiNo, CompanyName);
        }
    }
}
