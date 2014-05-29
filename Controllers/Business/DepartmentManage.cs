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
        static public DataTable GetAllDepartmentNameByCompanyName(String CompanyName)
        {
            return DepartmentService.GetAllDepartmentNameByCompanyName(CompanyName);
        }
    }
}
