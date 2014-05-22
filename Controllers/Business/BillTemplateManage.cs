using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Controllers.Models;
using Controllers.DataAccess.SQLHELPER;
using Controllers.DataAccess;

namespace Controllers.Business
{
    public class BillTemplateManage
    {
        /// <summary>
        /// 根据模板编号返回模板实体
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        public static BillTemplatModel SelectTemplateModeltByID(int code)
        {
            return BillTemplateService.GetTemplateModeltByID(code);
        }
        public static DataTable GetDataTableByTypeName(String sTemplateName)
        {
            return BillTemplateService.GetDataTableByTypeName(sTemplateName);
        }
        public static int AddByBillTemplatModel(BillTemplatModel btm)
        {
            return BillTemplateService.AddByBillTemplatModel(btm);
        }
        public static int UpdateByBillTemplatModel(BillTemplatModel btm)
        {
            return BillTemplateService.UpdateByBillTemplatModel(btm);
        }
        public static DataTable GetTemplatBagroundByBSName(String Sname)
        {
            return BillTemplateService.GetTemplatBagroundByBSName(Sname);
        }
    }
}
