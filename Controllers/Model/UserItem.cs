/******************************************************************
 * 创 建 人：  赵建
 * 创建时间：  2013-11-16 9:59
 * 描    述：
 *            用户实体，临时保存用户信息
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
    /// 保存用户临时信息
    /// </summary>
    public class UserItem
    {
        private  String m_UserCode;
        /// <summary>
        /// 员工工号
        /// </summary>
        public  String UserCode
        {
            get
            {
                return m_UserCode;
            }
            set
            {
                m_UserCode = value;
            }
        }

        private  String m_UserName;
        /// <summary>
        /// 姓名
        /// </summary>
        public  String UserName
        {
            get
            {
                return m_UserName;
            }
            set
            {
                m_UserName = value;
            }
        }
        private  String m_op_bill;
        /// <summary>
        /// 操作帐套
        /// </summary>
        public  String Op_Bill
        {
            get
            {
                return m_op_bill;
            }
            set
            {
                m_op_bill = value;
            }
        }

        private  String m_UserCompany;
        /// <summary>
        /// 所属公司
        /// </summary>
        public  String UserCompany
        {
            get
            {
                return m_UserCompany;
            }
            set
            {
                m_UserCompany = value;
            }
        }

        /// <summary>
        /// 密码
        /// </summary>
        private  String _PassWorld;
        public  String PassWorld
        {
            get
            {
                return _PassWorld;
            }
            set
            {
                _PassWorld = value;
            }
        }
    }
}
