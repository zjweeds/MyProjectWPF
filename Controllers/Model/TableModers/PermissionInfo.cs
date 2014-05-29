using System;
using System.Collections.Generic;
using System.Text;
namespace Controllers.Models
{
    /// <summary>
    ///本实体类由Hirer实体工具生成
    /// </summary>
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
