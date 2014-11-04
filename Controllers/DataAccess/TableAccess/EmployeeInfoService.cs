/******************************************************************
 * 创 建 人：  赵建
 * 创建时间：  2013-11-16 9:59
 * 描    述：
 *             员工信息表数据层
 * 版    本：  V1.0      
 * 环    境：  VS2013
******************************************************************/
using System;
using System.Collections.Generic;
using System.Text;
using Controllers.Models;
using System.Data.SqlClient;
using Controllers.DataAccess.SQLHELPER;
using System.Data;

namespace Controllers.DataAccess
{
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
        /// 根据员工实体添加信息
        /// </summary>
        /// <param name="employeeInfo"></param>
        /// <returns></returns>
        public static bool AddEmployeeInfoAndUserInfo(EmployeeInfo employeeInfo)
        {
            List<String> cmdList = new List<string>();
            StringBuilder cmdText = new StringBuilder();
            cmdText.Append(" INSERT INTO EmployeeInfo ( ");
            cmdText.Append("             EINo,EIName,EISex,EIDepartment,EIPosition,EIBirthday, ");
            cmdText.Append("             EIEntryDate,EIRemark,EICompanyID,EIIsEnable ");
            cmdText.Append(" ) VALUES(  ");
            cmdText.AppendFormat(" '{0}' , ",employeeInfo.EINo);
             cmdText.AppendFormat(" '{0}' , ",employeeInfo.EIName);
             cmdText.AppendFormat(" '{0}' , ",employeeInfo.EISex);
             cmdText.AppendFormat(" '{0}' , ",employeeInfo.EIDepartment);
             cmdText.AppendFormat(" '{0}' , ",employeeInfo.EIPosition);
             cmdText.AppendFormat(" '{0}' , ",employeeInfo.EIBirthday);
             cmdText.AppendFormat(" '{0}' , ",employeeInfo.EIEntryDate);
             cmdText.AppendFormat(" '{0}' , ",employeeInfo.EIRemark);
             cmdText.AppendFormat(" '{0}' , ",employeeInfo.EICompanyID);
             cmdText.Append(" '1' ) ");
             cmdList.Add(cmdText.ToString());
             StringBuilder sqlText = new StringBuilder();
             sqlText.AppendFormat(" INSERT INTO UserInfo (UIEINo,UICompanyID) values ('{0}','{1}') ", employeeInfo.EINo, employeeInfo.EICompanyID);
             cmdList.Add(sqlText.ToString());
             StringBuilder perText = new StringBuilder();
             perText.Append("INSERT INTO PermissionInfo ( PIEINo,PITemplate,PIDataSource,PIBill,PIUser,PISet,PIAdmin ) ");
             perText.AppendFormat("               values('{0}','1','1','1','0','0','0' ) ", employeeInfo.EINo);
             cmdList.Add(perText.ToString());//更新用户表
             return new MySqlHelper().ExecDataBySqls(cmdList);
        }

        /// <summary>
        /// 根据员工实体列表批量添加信息
        /// </summary>
        /// <param name="employeeInfoList"></param>
        /// <returns></returns>
        public static bool AddEmployeeInfoAndUserInfoList(IList<EmployeeInfo> employeeInfoList)
        {
            List<String> cmdList = new List<string>();
            if (employeeInfoList != null && employeeInfoList.Count > 0)
            {
                foreach (EmployeeInfo employeeInfo in employeeInfoList)
                {
                    StringBuilder cmdText = new StringBuilder();
                    cmdText.Append(" INSERT INTO EmployeeInfo ( ");
                    cmdText.Append("             EINo,EIName,EISex,EIDepartment,EIPosition,EIBirthday, ");
                    cmdText.Append("             EIEntryDate,EIRemark,EICompanyID,EIIsEnable ");
                    cmdText.Append(" ) VALUES(  ");
                    cmdText.AppendFormat(" '{0}' , ", employeeInfo.EINo);
                    cmdText.AppendFormat(" '{0}' , ", employeeInfo.EIName);
                    cmdText.AppendFormat(" '{0}' , ", employeeInfo.EISex);
                    cmdText.AppendFormat(" '{0}' , ", employeeInfo.EIDepartment);
                    cmdText.AppendFormat(" '{0}' , ", employeeInfo.EIPosition);
                    cmdText.AppendFormat(" '{0}' , ", employeeInfo.EIBirthday);
                    cmdText.AppendFormat(" '{0}' , ", employeeInfo.EIEntryDate);
                    cmdText.AppendFormat(" '{0}' , ", employeeInfo.EIRemark);
                    cmdText.AppendFormat(" '{0}' , ", employeeInfo.EICompanyID);
                    cmdText.Append(" '1' ) ");
                    cmdList.Add(cmdText.ToString()); //更新员工表
                    StringBuilder sqlText = new StringBuilder();
                    sqlText.AppendFormat(" INSERT INTO UserInfo (UIEINo,UICompanyID) values ('{0}','{1}') ", employeeInfo.EINo, employeeInfo.EICompanyID);
                    cmdList.Add(sqlText.ToString());//更新用户表
                    StringBuilder perText = new StringBuilder();
                    perText.Append("INSERT INTO PermissionInfo ( PIEINo,PITemplate,PIDataSource,PIBill,PIUser,PISet,PIAdmin ) ");
                    perText.AppendFormat("               values('{0}','1','1','1','0','0','0' ) ", employeeInfo.EINo);
                    cmdList.Add(perText.ToString());//更新用户表
                }
            }
            return new MySqlHelper().ExecDataBySqls(cmdList);
        }

        /// <summary>
        /// 根据EIID删除EmployeeInfo
        /// </summary>
        /// <param name="EIID">对象ID</param>
        public static int DeleteEmployeeInfoByEIID(Int32 _eIID)
        {
            string cmdText = "Update EmployeeInfo set EIIsEnable = 0  WHERE  EIID = " + _eIID;
            return new MySqlHelper().ExecDataBySql(cmdText);
        }

        /// <summary>
        /// 根据工号删除
        /// </summary>
        /// <param name="eino">工号</param>
        /// <param name="CampanyName">公司名</param>
        /// <returns></returns>
        public static bool DeleteEmployeeInfoByEINo(String eino,String CampanyName)
        {
            List<String> cmdList = new List<string>(); 
            StringBuilder cmdText = new StringBuilder();
            cmdText.Append(" Update EmployeeInfo set EIIsEnable = 0  ");
            cmdText.Append(" WHERE EXISTS   ( SELECT * FROM companyinfo ");
            cmdText.Append("                  where companyinfo.CIID = EmployeeInfo.EICompanyID ");
            cmdText.AppendFormat("                 and companyinfo.CIName = '{0}'",CampanyName);
            cmdText.AppendFormat("         ) and EINo = '{0}'",eino);
            cmdList.Add(cmdText.ToString());
            StringBuilder sqlText = new StringBuilder();
            sqlText.Append(" Update UserInfo set UIIsEnable = 0  ");
            sqlText.Append(" WHERE EXISTS   ( SELECT * FROM companyinfo ");
            sqlText.Append("                  where companyinfo.CIID = UserInfo.UICompanyID ");
            sqlText.AppendFormat("                 and companyinfo.CIName = '{0}'", CampanyName);
            sqlText.AppendFormat("         ) and UIEINo = '{0}'", eino);
            cmdList.Add(sqlText.ToString());
            return new MySqlHelper().ExecDataBySqls(cmdList);
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
            cmdText.Append("From EmployeeInfo with(nolock)  ");
            cmdText.Append("WHERE EIIsEnable = 1 and ");
            cmdText.AppendFormat("EIID = '{0}' ", _eIID);
            IList<EmployeeInfo> controlInfos = SelectEmployeeInfoByCmdText(cmdText.ToString());
            return controlInfos.Count > 0 ? controlInfos[0] : null;
        }

        /// <summary>
        /// 根据工号查询EmployeeInfo
        /// </summary>
        /// <param name="_eINo"></param>
        /// <returns></returns>
        public static EmployeeInfo SelectEmployeeInfoByEINO(String _eINo)
        {
            StringBuilder cmdText = new StringBuilder();
            cmdText.Append("SELECT ");
            cmdText.Append("             EIID,EINo,EIName,EIPhoto,EISex,EIDepartment,EIPosition,EIBirthday, ");
            cmdText.Append("             EIEntryDate,EIRemark,EICompanyID,EIIsEnable ");
            cmdText.Append("From EmployeeInfo with(nolock)  ");
            cmdText.Append("WHERE EIIsEnable = 1 and ");
            cmdText.AppendFormat("EINo = '{0}' ", _eINo);
            IList<EmployeeInfo> controlInfos = SelectEmployeeInfoByCmdText(cmdText.ToString());
            return controlInfos.Count > 0 ? controlInfos[0] : null;
        }

        /// <summary>
        /// 返回所有员工
        /// </summary>
        /// <returns></returns>
        public static IList<EmployeeInfo> SelectAllEmployeeInfo()
        {
            StringBuilder cmdText = new StringBuilder();
            cmdText.Append("SELECT ");
            cmdText.Append("             EIID,EINo,EIName,EIPhoto,EISex,EIDepartment,EIPosition,EIBirthday, ");
            cmdText.Append("             EIEntryDate,EIRemark,EICompanyID,EIIsEnable ");
            cmdText.Append("From EmployeeInfo with(nolock)  ");
            cmdText.Append("WHERE EIIsEnable = 1  ");
            return SelectEmployeeInfoByCmdText(cmdText.ToString());
        }

        /// <summary>
        /// 根据公司名称返回员工列表
        /// </summary>
        /// <param name="CompanyName"></param>
        /// <returns></returns>
        public static IList<EmployeeInfo> SelectEmployeeInfoByCompanyName(String CompanyName)
        {
            StringBuilder cmdText = new StringBuilder();
            cmdText.Append("SELECT ");
            cmdText.Append("             EIID,EINo,EIName,EIPhoto,EISex,EIDepartment,EIPosition,EIBirthday, ");
            cmdText.Append("             EIEntryDate,EIRemark,EICompanyID,EIIsEnable ");
            cmdText.Append("From EmployeeInfo with(nolock)  ");
            cmdText.Append(" left join  CompanyInfo  with(nolock)  on  CIID = EICompanyID ");
            cmdText.Append("WHERE EIIsEnable = 1  ");
            cmdText.AppendFormat(" and CIName = '{0}'  ", CompanyName);
            return SelectEmployeeInfoByCmdText(cmdText.ToString());
        }

        /// <summary>
        /// 返回某公司所有员工
        /// </summary>
        /// <param name="CompanyName"></param>
        /// <returns></returns>
        public static DataTable GetAllEmployeeInfoByCompanyName(String CompanyName)
        {
            StringBuilder cmdText = new StringBuilder();
            cmdText.Append("SELECT ");
            cmdText.Append("             EIID,EINo,EIName,EIPhoto,(Case EISex when 1 then '男' else '女' end) as EISex,EIDepartment,EIPosition,EIBirthday, ");
            cmdText.Append("             EIEntryDate,EIRemark,EICompanyID,EIIsEnable ");
            cmdText.Append("From EmployeeInfo with(nolock)  ");
            cmdText.Append(" left join  CompanyInfo  with(nolock)  on  CIID = EICompanyID ");
            cmdText.Append("WHERE EIIsEnable = 1  ");
            cmdText.AppendFormat(" and CIName = '{0}'  ", CompanyName);
            return  new MySqlHelper().GetDataTable(cmdText.ToString());
        }

        /// <summary>
        /// 分页查询
        /// </summary>
        /// <param name="pageSize"></param>
        /// <param name="pageIndex"></param>
        /// <param name="CompanyName"></param>
        /// <returns></returns>
        public static DataTable GetPagesEmployeeInfoByCompanyName(int pageSize,int pageIndex,String CompanyName)
        {
            StringBuilder cmdText = new StringBuilder();
            cmdText.Append("SELECT ");
            cmdText.Append("             EIID,EINo,EIName,(Case EISex when 1 then '男' else '女' end) as EISex ,");
            cmdText.Append("             EIDepartment,EIPosition,substring(CONVERT(nvarchar(20),EIBirthday),0,11)as EIBirthday, ");
            cmdText.Append("             substring(CONVERT(nvarchar(20),EIEntryDate),0,11)as EIEntryDate,EIRemark  ");
            cmdText.Append(" From (");
            if (pageIndex > 1)
            {
                //不是第一页，计算显示的项ID
                cmdText.AppendFormat("select top {0}   ", pageSize);
                cmdText.Append("             EIID,EINo,EIName,EISex,EIDepartment,EIPosition,EIBirthday, ");
                cmdText.Append("             EIEntryDate,EIRemark,EICompanyID,EIIsEnable ");
                cmdText.Append("    From EmployeeInfo with(nolock)  ");
                cmdText.Append("    where( EIID>( select max(EIID) From ");
                cmdText.AppendFormat(" 				(select top {0} EIID From EmployeeInfo order by EIID)as TempTable", pageSize * (pageIndex - 1));
                cmdText.Append("                ) ");
                cmdText.Append("         ) and EIIsEnable = 1  order by EIID ");
            }
            else
            {
                //是第一页直接显示前几条数据
                cmdText.AppendFormat("select top {0}   ", pageSize);
                cmdText.Append("             EIID,EINo,EIName,EISex,EIDepartment,EIPosition,EIBirthday, ");
                cmdText.Append("             EIEntryDate,EIRemark,EICompanyID,EIIsEnable ");
                cmdText.Append("    From EmployeeInfo with(nolock)  ");
                cmdText.Append("     where EIIsEnable = 1  order by EIID ");
            }
            cmdText.Append("     ) Temp ");
            cmdText.Append(" left join  CompanyInfo  with(nolock)  on  CIID =Temp.EICompanyID ");
            cmdText.AppendFormat("WHERE  CIName = '{0}'  ", CompanyName);
            return new MySqlHelper().GetDataTable(cmdText.ToString());
        }

        /// <summary>
        /// 跟据公司名返回员工数
        /// </summary>
        /// <param name="CompanyName"></param>
        /// <returns></returns>
        public static int GetRowsCount(String CompanyName)
        {
            StringBuilder cmdText = new StringBuilder();
            cmdText.Append("SELECT Count(*) ");
            cmdText.Append("From EmployeeInfo with(nolock)  ");
            cmdText.Append(" left join  CompanyInfo  with(nolock)  on  CIID = EICompanyID ");
            cmdText.Append("WHERE EIIsEnable = 1  ");
            cmdText.AppendFormat(" and CIName = '{0}'  ", CompanyName);
            return Convert.ToInt32( new MySqlHelper().GetSingleObject(cmdText.ToString()));
        }

        /// <summary>
        /// 根据公司名称返回员工列表
        /// </summary>
        /// <param name="CompanyName"></param>
        /// <returns></returns>
        public static DataTable GetEmployeeInfoByCompanyName(String CompanyName)
        {
            StringBuilder cmdText = new StringBuilder();
            cmdText.Append("SELECT ");
            cmdText.Append("             EIID,EINo,EIName,EIPhoto,EISex,EIDepartment,EIPosition,EIBirthday, ");
            cmdText.Append("             EIEntryDate,EIRemark,EICompanyID,EIIsEnable ");
            cmdText.Append("From EmployeeInfo with(nolock)  ");
            cmdText.Append(" left join  CompanyInfo  with(nolock)  on  CIID = EICompanyID ");
            cmdText.Append("WHERE EIIsEnable = 1  ");
            cmdText.AppendFormat(" and CIName = '{0}'  ", CompanyName);
            return new MySqlHelper().GetDataTable(cmdText.ToString());
        }

        /// <summary>
        /// 更新员工头像
        /// </summary>
        /// <param name="eINO"></param>
        /// <param name="buff"></param>
        /// <returns></returns>
        public static bool updateUerPhotoByEINO(String eINO, byte[] buff)
        {
            StringBuilder cmdText = new StringBuilder();
            cmdText.AppendFormat("Update EmployeeInfo set EIPhoto =@EIPhoto  WHERE  EINo = @EINo", eINO, buff);
            SqlParameter[] paras = new SqlParameter[]
            {
                new SqlParameter("@EINo",eINO),
                new SqlParameter("@EIPhoto",buff),
            };
            return new MySqlHelper().ExecDataBySql(cmdText.ToString(),paras)>0?true:false;
        }

        /// <summary>
        /// 生成员工号
        /// </summary>
        /// <param name="CompanyName"></param>
        /// <param name="intLength">工号长度</param>
        /// <returns></returns>
        public static String CreateNewNo(String CompanyName, int intLength)
        {
            StringBuilder cmdText = new StringBuilder();
            cmdText.Append("Select max(EINo) from EmployeeInfo with(nolock)  ");
            cmdText.Append(" left join  CompanyInfo  with(nolock)  on  CIID = EICompanyID ");
            cmdText.Append("WHERE EIIsEnable = 1  ");
            cmdText.AppendFormat(" and CIName = '{0}'  ", CompanyName);
            try
            {
                string strMaxCode = new MySqlHelper().GetSingleObject(cmdText.ToString()) as String;
                if (String.IsNullOrEmpty(strMaxCode))
                {
                    strMaxCode = FormatString(intLength);
                }
                return (Convert.ToInt32(strMaxCode) + 1).ToString(FormatString(intLength));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// 根据公司ID返回员工数
        /// </summary>
        /// <param name="ciid"></param>
        /// <returns></returns>
        public static int ConutEmNumberByCompany(int ciid)
        {
            StringBuilder cmdText = new StringBuilder();
            cmdText.Append(" Select count(EINo) from EmployeeInfo with(nolock)  ");
            cmdText.AppendFormat("  where EICompanyID = '{0}' ", ciid);
            return Convert.ToInt32(new MySqlHelper().GetSingleObject(cmdText.ToString()));
        }

        /// <summary>
        /// 拼接员工工号
        /// </summary>
        /// <param name="intLength"></param>
        /// <returns></returns>
        private static string FormatString(int intLength)
        {
            string strFormat = String.Empty;
            for (int i = 0; i < intLength; i++)
            {
                strFormat = strFormat + "0";
            }
            return strFormat;
        }

    }
}