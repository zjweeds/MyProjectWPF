using System;
using System.Collections.Generic;
using System.Text;
namespace Controllers.Models
{
    /// <summary>
    ///本实体类由Hirer实体工具生成
    /// </summary>
    public class UserInfo
    {
        private Int32 _uIID;
   
        public Int32 UIID
        {
            get { return _uIID; }
            set { _uIID = value; }
        }
        private String _uIEINo;
   
        public String UIEINo
        {
            get { return _uIEINo; }
            set { _uIEINo = value; }
        }
        private String _uIPassword;
   
        public String UIPassword
        {
            get { return _uIPassword; }
            set { _uIPassword = value; }
        }
        private DateTime _uICreateTime;
   
        public DateTime UICreateTime
        {
            get { return _uICreateTime; }
            set { _uICreateTime = value; }
        }
        private Boolean _uIIsEnable;
   
        public Boolean UIIsEnable
        {
            get { return _uIIsEnable; }
            set { _uIIsEnable = value; }
        }
    }
}
