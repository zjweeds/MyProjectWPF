using System;
using System.Collections.Generic;
using System.Text;
namespace Controllers.Models
{
    /// <summary>
    ///账单信息实体
    /// </summary>
    public class BillManageInfo
    {
        private Int32 _bIID;
   
        public Int32 BIID
        {
            get { return _bIID; }
            set { _bIID = value; }
        }
        private String _bIName;
   
        public String BIName
        {
            get { return _bIName; }
            set { _bIName = value; }
        }
        private Int32 _bITIID;
   
        public Int32 BITIID
        {
            get { return _bITIID; }
            set { _bITIID = value; }
        }
        private String _bISenderCode;
   
        public String BISenderCode
        {
            get { return _bISenderCode; }
            set { _bISenderCode = value; }
        }
        private String _bISender;
   
        public String BISender
        {
            get { return _bISender; }
            set { _bISender = value; }
        }
        private String _bIReciverCode;
   
        public String BIReciverCode
        {
            get { return _bIReciverCode; }
            set { _bIReciverCode = value; }
        }
        private String _bIReciver;
   
        public String BIReciver
        {
            get { return _bIReciver; }
            set { _bIReciver = value; }
        }
        private Int64 _bIAmount;
   
        public Int64 BIAmount
        {
            get { return _bIAmount; }
            set { _bIAmount = value; }
        }
        private Boolean _bIIsEnable;

        /// <summary>
        /// 记录是否有效
        /// </summary>
        public Boolean BIIsEnable
        {
            get { return _bIIsEnable; }
            set { _bIIsEnable = value; }
        }


        private String _BINo;
        /// <summary>
        /// 单据号
        /// </summary>
        public String BINo
        {
            get { return _BINo; }
            set { _BINo = value; }
        }
    }
}
