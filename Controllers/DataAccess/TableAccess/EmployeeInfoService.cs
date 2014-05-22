using System;
using System.Collections.Generic;
using System.Text;
using Controllers.Model;
using System.Data.SqlClient;
using Controllers.DataAccess.SQLHELPER;
using System.Data;
namespace Controllers.DAL
{
    /// <summary>
    ///本数据访问类由Hirer实体数据访问层工具生成
    /// </summary>
    public class EmployeeInfoService
    {
        /// <summary>
        /// 添加一个EmployeeInfo
        /// </summary>
        /// <param name="employeeInfo">对象实例</param>
        public static int AddEmployeeInfo(EmployeeInfo employeeInfo)
        {
           StringBuilder cmdText = new StringBuilder();
           cmdText.Append(" INSERT INTO EmployeeInfo ( ");
           cmdText.Append("             EINo,EIName,EIPhoto,EISex,EIDepartment,EIPosition,EIBirthday, ");
           cmdText.Append("             EIEntryDate,EIRemark,EICompanyID,EIIsEnable ");
           cmdText.Append(" ) VALUES( ");
           cmdText.Append("             @EINo,@EIName,@EIPhoto,@EISex,@EIDepartment,@EIPosition,@EIBirthday, ");
           cmdText.Append("             @EIEntryDate,@EIRemark,@EICompanyID,@EIIsEnable) ");
           cmdText.Append(" Select @@Identity ");
            SqlParameter[] paras = new SqlParameter[]
            {
                new SqlParameter("@EIID",employeeInfo.EIID),
                new SqlParameter("@EINo",employeeInfo.EINo),
                new SqlParameter("@EIName",employeeInfo.EIName),
                new SqlParameter("@EIPhoto",employeeInfo.EIPhoto),
                new SqlParameter("@EISex",employeeInfo.EISex),
                new SqlParameter("@EIDepartment",employeeInfo.EIDepartment),
                new SqlParameter("@EIPosition",employeeInfo.EIPosition),
                new SqlParameter("@EIBirthday",employeeInfo.EIBirthday),
                new SqlParameter("@EIEntryDate",employeeInfo.EIEntryDate),
                new SqlParameter("@EIRemark",employeeInfo.EIRemark),
                new SqlParameter("@EICompanyID",employeeInfo.EICompanyID),
                new SqlParameter("@EIIsEnable",employeeInfo.EIIsEnable)
            };
            return new MySqlHelper().ExecSqlReturnId(cmdText.ToString(), paras);
        }


        /// <summary>
        /// 根据EIID删除EmployeeInfo
        /// </summary>
        /// <param name="EIID">对象属性</param>
        public static int DeleteEmployeeInfoByEIID(Int32 _eIID)
        {
            string cmdText = "Update EmployeeInfo set EIIsEnable = 0  WHERE  EIID = " + _eIID;
            return new MySqlHelper().ExecDataBySql(cmdText);
        }


        /// <summary>
        /// 更新EmployeeInfo
        /// </summary>
        /// <param name="employeeInfo">新的对象实例</param>
        public static int UpdateEmployeeInfo(EmployeeInfo employeeInfo)
        {
            StringBuilder cmdText = new StringBuilder();
            cmdText.Append(" UPDATE EmployeeInfo SET  EINo = @EINo, EIName = @EIName, EIPhoto = @EIPhoto, EISex = @EISex,");
            cmdText.Append("                          EIDepartment = @EIDepartment, EIPosition = @EIPosition, ");
            cmdText.Append("              EIBirthday = @EIBirthday, EIEntryDate = @EIEntryDate, EIRemark = @EIRemark, ");
            cmdText.Append("              EICompanyID = @EICompanyID, EIIsEnable = @EIIsEnable  WHERE EIID =  @EIID") ;
            SqlParameter[] paras = new SqlParameter[]
            {
                new SqlParameter("@EIID",employeeInfo.EIID),
                new SqlParameter("@EINo",employeeInfo.EINo),
                new SqlParameter("@EIName",employeeInfo.EIName),
                new SqlParameter("@EIPhoto",employeeInfo.EIPhoto),
                new SqlParameter("@EISex",employeeInfo.EISex),
                new SqlParameter("@EIDepartment",employeeInfo.EIDepartment),
                new SqlParameter("@EIPosition",employeeInfo.EIPosition),
                new SqlParameter("@EIBirthday",employeeInfo.EIBirthday),
                new SqlParameter("@EIEntryDate",employeeInfo.EIEntryDate),
                new SqlParameter("@EIRemark",employeeInfo.EIRemark),
                new SqlParameter("@EICompanyID",employeeInfo.EICompanyID),
                new SqlParameter("@EIIsEnable",employeeInfo.EIIsEnable)
            };
            return new MySqlHelper().ExecDataBySql(cmdText.ToString(), paras);
        }


        /// <summary>
        /// 查询EmployeeInfo
        /// </summary>
        /// <param name="cmdText">sql命令</param>
        public static IList<EmployeeInfo> SelectEmployeeInfoByCmdText(String cmdText)
        {
            IList<EmployeeInfo> employeeInfos = new List<EmployeeInfo>();

            using (SqlDataReader sdr = (SqlDataReader)new MySqlHelper().GetDataReader(cmdText))
            {
                while (sdr.Read())
                {
                    EmployeeInfo employeeInfo = new EmployeeInfo();
                    employeeInfo.EIID= (Convert.ToInt32(sdr[0]));
                    employeeInfo.EINo = (Convert.ToString(sdr[1]));
                    employeeInfo.EIName = (Convert.ToString(sdr[2]));
                    employeeInfo.EIPhoto = (sdr[3]) as byte[];
                    employeeInfo.EISex = (Convert.ToBoolean(sdr[4]));
                    employeeInfo.EIDepartment = Convert.ToString(sdr[5]);
                    employeeInfo.EIPosition = Convert.ToString(sdr[6]);
                    employeeInfo.EIBirthday = Convert.ToDateTime(sdr[7]).Date;
                    employeeInfo.EIEntryDate = Convert.ToDateTime(sdr[8]).Date;
                    employeeInfo.EIRemark = (Convert.ToString(sdr[9]));
                    employeeInfo.EICompanyID = (Convert.ToInt32(sdr[10]));
                    employeeInfo.EIIsEnable = (Convert.ToBoolean(sdr[11]));
                    employeeInfos.Add(employeeInfo);
                }
            }
            return employeeInfos;
        }

        /// <summary>
        /// 根据EIID查询EmployeeInfo
        /// </summary>
        /// <param name=" _eIID">属性值</param>
        public static EmployeeInfo SelectEmployeeInfoByEIID(Int32 _eIID)
        {
            StringBuilder cmdText = new StringBuilder();
            cmdText.Append("SELECT ");
            cmdText.Append("             EIID,EINo,EIName,EIPhoto,EISex,EIDepartment,EIPosition,EIBirthday, ");
            cmdText.Append("             EIEntryDate,EIRemark,EICompanyID,EIIsEnable ");
            cmdText.Append("WHERE EIIsEnable = 1 and ");
            cmdText.AppendFormat("CIID = '{0}' ", _eIID);
            IList<EmployeeInfo> controlInfos = SelectEmployeeInfoByCmdText(cmdText.ToString());
            return controlInfos.Count > 0 ? controlInfos[0] : null;
        }

        public static IList<EmployeeInfo> SelectAllEmployeeInfo()
        {
            StringBuilder cmdText = new StringBuilder();
            cmdText.Append("SELECT ");
            cmdText.Append("             EIID,EINo,EIName,EIPhoto,EISex,EIDepartment,EIPosition,EIBirthday, ");
            cmdText.Append("             EIEntryDate,EIRemark,EICompanyID,EIIsEnable ");
            cmdText.Append("WHERE EIIsEnable = 1  ");
            return SelectEmployeeInfoByCmdText(cmdText.ToString());
        } 
    }
}