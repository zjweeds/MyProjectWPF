//---------------------------------------------------------—-----//
//功能：部门信息业务层逻辑                                        //
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
   public  class PositionManage
   {
       /// <summary>
       /// 根据部门返回所有职位
       /// </summary>
       /// <param name="dIID">部门ID</param>
       /// <returns></returns>
       static public DataTable GetAllDepartmentNameByCompanyName(int dIID)
       {
           return PositionService.GetAllDepartmentNameByCompanyName(dIID);
       }
    }
}
