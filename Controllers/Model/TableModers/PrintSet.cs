using System;
using System.Collections.Generic;
using System.Text;
namespace Controllers.Models
{
    /// <summary>
    ///本实体类由Hirer实体工具生成
    /// </summary>
    public class PrintSetInfo
    {
        private Int32 _pSID;
   
        public Int32 PSID
        {
            get { return _pSID; }
            set { _pSID = value; }
        }
        private String _pSName;
   
        public String PSName
        {
            get { return _pSName; }
            set { _pSName = value; }
        }
        private Int32 _pSLeft;
   
        public Int32 PSLeft
        {
            get { return _pSLeft; }
            set { _pSLeft = value; }
        }
        private Int32 _pSRight;
   
        public Int32 PSRight
        {
            get { return _pSRight; }
            set { _pSRight = value; }
        }
        private Boolean _pSIsEnable;
   
        public Boolean PSIsEnable
        {
            get { return _pSIsEnable; }
            set { _pSIsEnable = value; }
        }
    }
}
