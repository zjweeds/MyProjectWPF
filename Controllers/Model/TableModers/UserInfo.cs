/******************************************************************
 * 创 建 人：  赵建
 * 创建时间：  2013-11-16 9:59
 * 描    述：
 *            UserInfo实体
 * 版    本：  V1.0      
 * 环    境：  VS2013
******************************************************************/
using System;
using System.Collections.Generic;
using System.Text;
namespace Controllers.Models
{
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
