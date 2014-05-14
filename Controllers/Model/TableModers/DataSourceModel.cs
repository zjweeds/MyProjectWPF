using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controllers.Models
{
    public class DataSourceModel
    {
        /// <summary>
        /// 数据源ID
        /// </summary>
        public int DSIID
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
