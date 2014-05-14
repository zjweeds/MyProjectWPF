using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Controllers.Models;
using Controllers.DataAccess;

namespace Controllers.Business
{
    public class BillSetManager
    {
        /// <summary>
        /// 根据公司名返回账套列表（datatable）
        /// </summary>
        /// <param name="name">公司名</param>
        /// <returns></returns>
        public DataTable GetDataTableByCompanyName(String name)
        {
            return new BillSetService().GetBillSetNameByCompany(name);
        }
    }
}
