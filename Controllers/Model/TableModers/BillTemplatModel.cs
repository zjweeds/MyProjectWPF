/******************************************************************
 * 创 建 人：  赵建
 * 创建时间：  2013-11-16 9:59
 * 描    述：
 *            Template实体
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
    /// 模板信息实体
    /// </summary>
   public class BillTemplatModel
    {
       public Int32 TIID { get; set; }
       public String TIName { get; set; }
       public byte[] TIBackground { get; set; }
       public int TIWidth { get; set; }
       public int TIHeight { get; set; }
       public Int32 TITTID { get; set; }
       public int TICodeLegth { get; set; }

       public byte[] TIIcon { get; set; }
       public int TIIsPrintBg { get; set; }
       public int TIIsVoidBg { get; set; }

    }
}
