//---------------------------------------------------------—-----//
//功能：Department部门信息业务层逻辑                             //
//作者：赵建                                                      //
//版本：v1.1                                                      //
//创建时间：2014/3/30   12:55:00                                  //
//最后修改时间：2014/5/30   8:55:00                               //
//---------------------------------------------------------------//
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Controllers.DataAccess;
using System.Data;

namespace Controllers.Business
{
    public class DepartmentManage
    {
        /// <summary>
        /// 根据公司名返回所有部门
        /// </summary>
        /// <param name="CompanyName"></param>
        /// <returns></returns>
        static public DataTable GetAllDepartmentNameByCompanyName(String CompanyName)
        {
            return DepartmentService.GetAllDepartmentNameByCompanyName(CompanyName);
        }

        /// <summary>
        /// 根据部门ID返回名称
        /// </summary>
        /// <param name="DID"></param>
        /// <returns></returns>
        static public int GetDepartmentNameByID(Int32 DID)
        {
            return DepartmentService.GetDepartmentNameByID(DID);
        }
        /// <summary>
        /// 根据部门返回部门ID
        /// </summary>
        /// <param name="CompanyName"></param>
        /// <param name="Dname"></param>
        /// <returns></returns>
        static public int GetAllDepartmentIDByCompanyName(String CompanyName, String Dname)
        {
            return DepartmentService.GetAllDepartmentIDByCompanyName(CompanyName, Dname);
        }

        /// <summary>
        /// 添加部门信息
        /// </summary>
        /// <param name="DIName"></param>
        /// <param name="DICIID"></param>
        /// <returns></returns>
        public static int AddDepartment(String DIName, int DICIID)
        {
            return DepartmentService.AddDepartment(DIName, DICIID);
        }

        /// <summary>
        /// 更新部门信息
        /// </summary>
        /// <param name="DIName"></param>
        /// <param name="DIID"></param>
        /// <returns></returns>
        public static int UpdateDepartment(String DIName, int DIID)
        {
            return DepartmentService.UpdateDepartment(DIName, DIID);
        }

        /// <summary>
        /// 删除部门信息
        /// </summary>
        /// <param name="DIName"></param>
        /// <param name="DIID"></param>
        /// <returns></returns>
        public static bool DeleteDepartment(int DIID)
        {
            return DepartmentService.DeleteDepartment(DIID);
        }
    }
}
