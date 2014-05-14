using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controllers.Models
{
    /// <summary>
    /// 模板类型实体
    /// </summary>
    public class BillTemplateTypeModel
    {

        public int TTID { get; set; }
        public String TTName { get; set; }
        public int TTBillSetID { get; set; }
    }
}
