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
