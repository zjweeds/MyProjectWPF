/******************************************************************
 * 创 建 人：  赵建
 * 创建时间：  2013-11-16 9:59
 * 描    述：
 *            权限实体
 * 版    本：  V1.0      
 * 环    境：  VS2013
******************************************************************/
using System;
using System.Collections.Generic;
using System.Text;
namespace Controllers.Models
{
    public class PermissionInfo
    {
        private Int32 _pIID;
   
        public Int32 PIID
        {
            get { return _pIID; }
            set { _pIID = value; }
        }
        private String _pIEINo;

        public String PIEINo
        {
            get { return _pIEINo; }
            set { _pIEINo = value; }
        }
        private Boolean _pITemplate;
   
        public Boolean PITemplate
        {
            get { return _pITemplate; }
            set { _pITemplate = value; }
        }
        private Boolean _pIDataSource;
   
        public Boolean PIDataSource
        {
            get { return _pIDataSource; }
            set { _pIDataSource = value; }
        }
        private Boolean _pIBill;
   
        public Boolean PIBill
        {
            get { return _pIBill; }
            set { _pIBill = value; }
        }
        private Boolean _pIUser;
   
        public Boolean PIUser
        {
            get { return _pIUser; }
            set { _pIUser = value; }
        }
        private Boolean _pISet;
   
        public Boolean PISet
        {
            get { return _pISet; }
            set { _pISet = value; }
        }


        private Boolean _PIAdmin;
   
        public Boolean PIAdmin
        {
            get { return _PIAdmin; }
            set { _PIAdmin = value; }
        }

        
    }
}
