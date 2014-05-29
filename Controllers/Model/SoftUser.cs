using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace Controllers.Models
{
    public static class SoftUser
    {
        private static String m_UserCode;
        /// <summary>
        /// 员工工号
        /// </summary>
        public static String UserCode
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

        private static String m_UserName;
        /// <summary>
        /// 姓名
        /// </summary>
        public static String UserName
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
        private static String m_op_bill;
        /// <summary>
        /// 操作帐套
        /// </summary>
        public static String Op_Bill
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

        private static String m_UserCompany;
        /// <summary>
        /// 所属公司
        /// </summary>
        public static String UserCompany
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
        private static String _PassWorld;
        public static String PassWorld
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
