//----------------------------------------------------------------//
//功能：软件配置业务逻辑                                           //
//作者：赵建                                                      //
//版本：v1.3                                                      //
//创建时间：2013/11/7   15:34:00                                  //
//最后一次修改时间：2014/3/23   17:22:00                          //
//---------------------------------------------------------------//
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Threading.Tasks;
using Controllers.Models;
using Controllers.DataAccess;

namespace Controllers.Business
{
    public class CompanyManager
    {
        CompanAccess comAcess = new CompanAccess();
        public List<CompanyModel> GetAllCompanyFields(String sFields, String sWhere)
        {
            return comAcess.GetAllCompanyFields(sFields, sWhere);
        }

        public DataSet GetAllCompanyNames()
        {
            return comAcess.GetCompanToDataSet("CIName", null);
        }
    }
}
