//---------------------------------------------------------—-----//
//功能：EmployeeInfo员工信息业务层逻辑                            //
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
        /// 根据工号公司ID删除员工
        /// </summary>
        /// <param name="eino"></param>
        /// <param name="CampanyName"></param>
        /// <returns></returns>
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

        /// <summary>
        /// 根据员工工号返回员工信息
        /// </summary>
        /// <param name="_eINo"></param>
        /// <returns></returns>
        public static EmployeeInfo SelectEmployeeInfoByEINO(String _eINo)
        {
            return EmployeeInfoService.SelectEmployeeInfoByEINO(_eINo);
        }

        /// <summary>
        /// 根据员工工号更新头像
        /// </summary>
        /// <param name="eINO">工号</param>
        /// <param name="buff">图片流</param>
        /// <returns></returns>
        public static bool updateUerPhotoByEINO(String eINO, byte[] buff)
        {
            return EmployeeInfoService.updateUerPhotoByEINO(eINO,buff);
        }

        /// <summary>
        /// 跟据公司名返回所有员工
        /// </summary>
        /// <param name="CompanyName">公司名</param>
        /// <returns></returns>
        public static DataTable GetAllEmployeeInfoByCompanyName(String CompanyName)
        {
            return EmployeeInfoService.GetAllEmployeeInfoByCompanyName(CompanyName);
        }

        /// <summary>
        /// 返回公司员工数
        /// </summary>
        /// <param name="CompanyName">公司名</param>
        /// <returns></returns>
        public static int GetRowsCount(String CompanyName)
        {
            return EmployeeInfoService.GetRowsCount(CompanyName);
        }


        /// <summary>
        /// 分页查询员工信息
        /// </summary>
        /// <param name="pageSize">页大小</param>
        /// <param name="pageIndex">页索引</param>
        /// <param name="CompanyName">公司名称</param>
        /// <returns></returns>
        public static DataTable GetPagesEmployeeInfoByCompanyName(int pageSize, int pageIndex, String CompanyName)
        {
            return EmployeeInfoService.GetPagesEmployeeInfoByCompanyName(pageSize, pageIndex, CompanyName);
        }

        /// <summary>
        /// 创建一个新工号
        /// </summary>
        /// <param name="CompanyName">公司名</param>
        /// <param name="intLength">工号长度</param>
        /// <returns></returns>
        public static String CreateNewNo(String CompanyName, int intLength)
        {
            return EmployeeInfoService.CreateNewNo(CompanyName, intLength);
        }

        /// <summary>
        /// 添加员工
        /// </summary>
        /// <param name="employeeInfo">员工实体</param>
        /// <returns></returns>
        public static bool AddEmployeeInfoAndUserInfo(EmployeeInfo employeeInfo)
        {
             return EmployeeInfoService.AddEmployeeInfoAndUserInfo(employeeInfo);
        }

        /// <summary>
        /// 批量添加员工
        /// </summary>
        /// <param name="employeeInfoList">员工实体列表</param>
        /// <returns></returns>
        public static bool AddEmployeeInfoAndUserInfoList(IList<EmployeeInfo> employeeInfoList)
        {
            return EmployeeInfoService.AddEmployeeInfoAndUserInfoList(employeeInfoList);
        }

        /// <summary>
        /// 返回公司所有员工数
        /// </summary>
        /// <param name="ciid">公司ID</param>
        /// <returns></returns>
        public static int ConutEmNumberByCompany(int ciid)
        {
            return EmployeeInfoService.ConutEmNumberByCompany(ciid);
        }
    }
}
