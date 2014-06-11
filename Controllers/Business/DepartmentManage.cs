//---------------------------------------------------------—-----//
//功能：Department部门信息业务层逻辑                            //
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
    }
}
