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
       static public DataTable GetAllDepartmentNameByCompanyName(int dIID)
       {
           return PositionService.GetAllDepartmentNameByCompanyName(dIID);
       }
    }
}
