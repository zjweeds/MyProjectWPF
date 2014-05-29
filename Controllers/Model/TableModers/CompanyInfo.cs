using System;
using System.Collections.Generic;
using System.Text;
namespace Controllers.Models
{
    /// <summary>
    ///本实体类由Hirer实体工具生成
    /// </summary>
    public class CompanyInfo
    {
        private Int32 _cIID;
   
        public Int32 CIID
        {
            get { return _cIID; }
            set { _cIID = value; }
        }
        private String _cIName;
   
        public String CIName
        {
            get { return _cIName; }
            set { _cIName = value; }
        }
        private String _cIDescription;
   
        public String CIDescription
        {
            get { return _cIDescription; }
            set { _cIDescription = value; }
        }
        private Int32 _cIParentID;
   
        public Int32 CIParentID
        {
            get { return _cIParentID; }
            set { _cIParentID = value; }
        }
        private String _cICreaterID;
   
        public String CICreaterID
        {
            get { return _cICreaterID; }
            set { _cICreaterID = value; }
        }
        private DateTime _cICreateTime;
   
        public DateTime CICreateTime
        {
            get { return _cICreateTime; }
            set { _cICreateTime = value; }
        }
        private Byte _cIIsEnable;
   
        public Byte CIIsEnable
        {
            get { return _cIIsEnable; }
            set { _cIIsEnable = value; }
        }
    }
}
