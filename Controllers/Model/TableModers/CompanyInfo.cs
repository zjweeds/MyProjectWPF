/******************************************************************
 * 创 建 人：  赵建
 * 创建时间：  2013-11-16 9:59
 * 描    述：
 *            CompanyInfo实体
 * 版    本：  V1.0      
 * 环    境：  VS2013
******************************************************************/
using System;
using System.Collections.Generic;
using System.Text;
namespace Controllers.Models
{
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
