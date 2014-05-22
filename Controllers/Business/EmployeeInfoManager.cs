using System;
using System.Collections.Generic;
using System.Text;
using Controllers.Model;
using Controllers.DAL;
namespace Controllers.BLL
{
    /// <summary>
    ///本逻辑层由Hirer自动生成工具生成
    /// </summary>
    public class EmployeeInfoManager
    {
        /// <summary>
        /// 添加一个EmployeeInfo
        /// <param name="employeeInfo">对象实例</param>
        public static bool AddEmployeeInfo(EmployeeInfo employeeInfo)
        {
            return EmployeeInfoService.AddEmployeeInfo(employeeInfo) > 0 ? true : false;
        }
    
      
        /// <summary>
        /// 根据EIID删除EmployeeInfo
        /// <param name="EIID">对象属性</param>
        public static bool DeleteEmployeeInfoByEIID(Int32  _eIID)
        {
            return EmployeeInfoService.DeleteEmployeeInfoByEIID( _eIID) > 0 ? true : false;
        }
          
           
        /// <summary>
        /// 更新EmployeeInfo
        /// <param name="employeeInfo">新的对象实例</param>
        public static bool UpdateEmployeeInfo(EmployeeInfo employeeInfo)
        {
            EmployeeInfo employeeInfoTemp = EmployeeInfoService.SelectEmployeeInfoByEIID(employeeInfo.EIID);
            employeeInfoTemp.EIID = employeeInfo.EIID;
            employeeInfoTemp.EINo = employeeInfo.EINo;
            employeeInfoTemp.EIName = employeeInfo.EIName;
            employeeInfoTemp.EIPhoto = employeeInfo.EIPhoto;
            employeeInfoTemp.EISex = employeeInfo.EISex;
            employeeInfoTemp.EIDepartment = employeeInfo.EIDepartment;
            employeeInfoTemp.EIPosition = employeeInfo.EIPosition;
            employeeInfoTemp.EIBirthday = employeeInfo.EIBirthday;
            employeeInfoTemp.EIEntryDate = employeeInfo.EIEntryDate;
            employeeInfoTemp.EIRemark = employeeInfo.EIRemark;
            employeeInfoTemp.EICompanyID = employeeInfo.EICompanyID;
            employeeInfoTemp.EIIsEnable = employeeInfo.EIIsEnable;
            return EmployeeInfoService.UpdateEmployeeInfo(employeeInfoTemp) > 0 ? true : false;
        }
          
           
        /// <summary>
        /// 根据EIID查询EmployeeInfo
        /// <param name="employeeInfo">对象实例</param>
        public static EmployeeInfo SelectEmployeeInfoByEIID(Int32  _eIID)
        {
            return EmployeeInfoService.SelectEmployeeInfoByEIID( _eIID);
        }
        
        
        /// <summary>
        /// 查询所有EmployeeInfo
        /// </summary>
        public static IList<EmployeeInfo> SelectAllEmployeeInfo()
        {
            return  EmployeeInfoService.SelectAllEmployeeInfo();
        }
    }
}
