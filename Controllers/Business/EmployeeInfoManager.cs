using System;
using System.Collections.Generic;
using System.Text;
using Controllers.Models;
using Controllers.DataAccess;
using System.Data;
namespace Controllers.Business
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
        public static bool DeleteEmployeeInfoByEINo(String eino, String CampanyName)
        {
            return EmployeeInfoService.DeleteEmployeeInfoByEINo(eino, CampanyName);
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
        public static IList<EmployeeInfo> SelectEmployeeInfoByCompanyName(String CompanyName)
        {
            return EmployeeInfoService.SelectEmployeeInfoByCompanyName(CompanyName);
        }

        /// <summary>
        /// 根据公司名称返回员工列表
        /// </summary>
        /// <param name="CompanyName"></param>
        /// <returns></returns>
        public static DataTable GetEmployeeInfoByCompanyName(String CompanyName)
        {
            return EmployeeInfoService.GetEmployeeInfoByCompanyName(CompanyName);
        }

        public static EmployeeInfo SelectEmployeeInfoByEINO(String _eINo)
        {
            return EmployeeInfoService.SelectEmployeeInfoByEINO(_eINo);
        }
        public static bool updateUerPhotoByEINO(String eINO, byte[] buff)
        {
            return EmployeeInfoService.updateUerPhotoByEINO(eINO,buff);
        }

        public static DataTable GetAllEmployeeInfoByCompanyName(String CompanyName)
        {
            return EmployeeInfoService.GetAllEmployeeInfoByCompanyName(CompanyName);
        }

        public static int GetRowsCount(String CompanyName)
        {
            return EmployeeInfoService.GetRowsCount(CompanyName);
        }


        /// <summary>
        /// 分页查询员工信息
        /// </summary>
        /// <param name="pageSize"></param>
        /// <param name="pageIndex"></param>
        /// <param name="CompanyName"></param>
        /// <returns></returns>
        public static DataTable GetPagesEmployeeInfoByCompanyName(int pageSize, int pageIndex, String CompanyName)
        {
            return EmployeeInfoService.GetPagesEmployeeInfoByCompanyName(pageSize, pageIndex, CompanyName);
        }
        public static String CreateNewNo(String CompanyName, int intLength)
        {
            return EmployeeInfoService.CreateNewNo(CompanyName, intLength);
        }
        public static bool AddEmployeeInfoAndUserInfo(EmployeeInfo employeeInfo)
        {
             return EmployeeInfoService.AddEmployeeInfoAndUserInfo(employeeInfo);
        }
        public static bool AddEmployeeInfoAndUserInfoList(IList<EmployeeInfo> employeeInfoList)
        {
            return EmployeeInfoService.AddEmployeeInfoAndUserInfoList(employeeInfoList);
        }
        public static int ConutEmNumberByCompany(int ciid)
        {
            return EmployeeInfoService.ConutEmNumberByCompany(ciid);
        }
    }
}
