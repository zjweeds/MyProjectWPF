using System;
using System.Collections.Generic;
using System.Text;
namespace Controllers.Models
{
    public class BillSetInfo
    {
        private Int32 _bSIID;
   
        public Int32 BSIID
        {
            get { return _bSIID; }
            set { _bSIID = value; }
        }
        private String _bSIName;
   
        public String BSIName
        {
            get { return _bSIName; }
            set { _bSIName = value; }
        }
        private Int32 _bSICompanyID;
   
        public Int32 BSICompanyID
        {
            get { return _bSICompanyID; }
            set { _bSICompanyID = value; }
        }
        private String _bSICreaterID;
   
        public String BSICreaterID
        {
            get { return _bSICreaterID; }
            set { _bSICreaterID = value; }
        }
        private DateTime _bSICreateTime;
   
        public DateTime BSICreateTime
        {
            get { return _bSICreateTime; }
            set { _bSICreateTime = value; }
        }


        private Byte _bSIIsEnable;
   
        public Byte BSIIsEnable
        {
            get { return _bSIIsEnable; }
            set { _bSIIsEnable = value; }
        }
    }
}
