/******************************************************************
 * 创 建 人：  赵建
 * 创建时间：  2013-11-16 9:59
 * 描    述：
 *            员工实体
 * 版    本：  V1.0      
 * 环    境：  VS2013
******************************************************************/
using System;
using System.Collections.Generic;
using System.Text;

namespace Controllers.Models
{
    public class EmployeeInfo
    {
        private Int32 _eIID;

        public Int32 EIID
        {
            get { return _eIID; }
            set { _eIID = value; }
        }
        private String _eINo;

        public String EINo
        {
            get { return _eINo; }
            set { _eINo = value; }
        }
        private String _eIName;

        public String EIName
        {
            get { return _eIName; }
            set { _eIName = value; }
        }
        private System.Byte[] _eIPhoto;

        public System.Byte[] EIPhoto
        {
            get { return _eIPhoto; }
            set { _eIPhoto = value; }
        }
        private Boolean _eISex;

        public Boolean EISex
        {
            get { return _eISex; }
            set { _eISex = value; }
        }
        private String _EIDepartment;

        public String EIDepartment
        {
            get { return _EIDepartment; }
            set { _EIDepartment = value; }
        }
        private String _EIPosition;

        public String EIPosition
        {
            get { return _EIPosition; }
            set { _EIPosition = value; }
        }
        private DateTime _EIBirthday;

        public DateTime EIBirthday
        {
            get { return _EIBirthday; }
            set { _EIBirthday = value; }
        }
        private DateTime _EIEntryDate;

        public DateTime EIEntryDate
        {
            get { return _EIEntryDate; }
            set { _EIEntryDate = value; }
        }
        private String _EIRemark;

        public String EIRemark
        {
            get { return _EIRemark; }
            set { _EIRemark = value; }
        }
        private Int32 _EICompanyID;

        public Int32 EICompanyID
        {
            get { return _EICompanyID; }
            set { _EICompanyID = value; }
        }

        private Boolean _EIIsEnable;

        public Boolean EIIsEnable
        {
            get { return _EIIsEnable; }
            set { _EIIsEnable = value; }
        }
    }
}