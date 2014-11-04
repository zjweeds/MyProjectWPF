/******************************************************************
 * 创 建 人：  赵建
 * 创建时间：  2013-11-16 9:59
 * 描    述：
 *            数据源实体
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
    /// 数据源实体
    /// </summary>
    public class DataSourceModel
    {
        /// <summary>
        /// 数据源ID
        /// </summary>
        public Int32 DSIID
        {
            get;
            set;
        }
        /// <summary>
        /// 数据源表名
        /// </summary>
        public String DSITableName
        {
            get;
            set;
        }

        /// <summary>
        /// 关联列名
        /// </summary>
        public String DSIColums
        {
            get;
            set;
        }
        /// <summary>
        /// 所属公司
        /// </summary>
        public int DSICIID
        {
            get;
            set;
        }
    }
}
