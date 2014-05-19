using System;
using System.Collections.Generic;
using System.Text;
namespace Controllers.Models
{
    /// <summary>
    ///本实体类由Hirer实体工具生成
    /// </summary>
    public class BillInfo
    {
        private Int32 _bIID;
   
        public Int32 BIID
        {
            get { return _bIID; }
            set { _bIID = value; }
        }
        private String _bINo;
   
        public String BINo
        {
            get { return _bINo; }
            set { _bINo = value; }
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
        private int _bIIsEnable;
   
        public int BIIsEnable
        {
            get { return _bIIsEnable; }
            set { _bIIsEnable = value; }
        }
    }
}