//-----------------------------------------------------------------------------------------------------------------------/
//功能：公司表实体
//作者：赵建
//版本：v1.0
//创建时间：2013/11/7   14:34:00
//修改时间：2014/3/17   15:22:00
//----------------------------------------------------------------------------------------------------------------------/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controllers.Moders.TableModers
{
   public  class CompanyModer
    {
        /// <summary>
        /// 公司编号
        /// </summary>
        public int CIID { get; set; }

        /// <summary>
        /// 公司名称
        /// </summary>
        public String CIName { get; set; }

        /// <summary>
        /// 公司简介
        /// </summary>
        public String CIDescription { get; set; }

        /// <summary>
        ///父公司ID
        /// </summary>
        public int CIParentID { get; set; }

        /// <summary>
        /// 记录创建人ID
        /// </summary>
        public String CICreaterID { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime CICreateTime { set; get; }
    }
}
