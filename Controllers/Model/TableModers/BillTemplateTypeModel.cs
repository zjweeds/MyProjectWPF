/******************************************************************
 * 创 建 人：  赵建
 * 创建时间：  2013-11-16 9:59
 * 描    述：
 *            TemplateType实体
 * 版    本：  V1.0      
 * 环    境：  VS2013
******************************************************************/
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

        public Int32 TTID { get; set; }
        public String TTName { get; set; }
        public int TTBillSetID { get; set; }
    }
}
