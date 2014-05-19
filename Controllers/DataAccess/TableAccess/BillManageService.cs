using System;
using System.Collections.Generic;
using System.Text;
using Controllers.Models;
using System.Data.SqlClient;
using Controllers.DataAccess.SQLHELPER;
namespace Controllers.DataAccess
{
    /// <summary>
    ///本数据访问类由Hirer实体数据访问层工具生成
    /// </summary>
    public class BillManageService
    {
        /// <summary>
        /// 添加一个BillManage
        /// </summary>
        /// <param name="billManage">对象实例</param>
        public static int AddBillManage(BillManageInfo billManage)
        {
            StringBuilder cmdText = new StringBuilder();
            cmdText.Append("INSERT INTO BillManage ( ");
            cmdText.Append("                        BINo,BIName,BITIID,BISenderCode,BISender,");
            cmdText.Append("                        BIReciverCode,BIReciver,BIAmount,BIIsEnable" );
            cmdText.Append("                       )" );
            cmdText.Append("                 VALUES( ");
            cmdText.Append("                        @BIName,@BITIID,@BISenderCode,@BISender,@BIReciverCode, ");
            cmdText.Append("                        @BIReciver,@BIAmount,@BIIsEnable ");
            cmdText.Append("                       )Select @@Identity ");
            SqlParameter[] paras = new SqlParameter[]
            {
                new SqlParameter("@BIID",billManage.BIID),
                 new SqlParameter("@BINo",billManage.BINo),
                new SqlParameter("@BIName",billManage.BIName),
                new SqlParameter("@BITIID",billManage.BITIID),
                new SqlParameter("@BISenderCode",billManage.BISenderCode),
                new SqlParameter("@BISender",billManage.BISender),
                new SqlParameter("@BIReciverCode",billManage.BIReciverCode),
                new SqlParameter("@BIReciver",billManage.BIReciver),
                new SqlParameter("@BIAmount",billManage.BIAmount),
                new SqlParameter("@BIIsEnable",billManage.BIIsEnable)
            };
            return new MySqlHelper().ExecSqlReturnId(cmdText.ToString(), paras);
        }
     
     
        /// <summary>
        /// 根据BIID删除BillManage
        /// </summary>
        /// <param name="BIID">对象属性</param>
        public static int DeleteBillManageByBIID(Int32  _bIID)
        {
            String cmdText = "Update BillManage  Set  BIIsEnable = '0' WHERE  BIID = " + _bIID;
            return new MySqlHelper().ExecDataBySql(cmdText);
        }
     
     
        /// <summary>
        /// 更新BillManage
        /// </summary>
        /// <param name="billManage">新的对象实例</param>
        public static int UpdateBillManage(BillManageInfo billManage)
        {
            StringBuilder cmdText =new StringBuilder();
            cmdText.Append(" UPDATE BillManage SET BINo=@BINo, BIName = @BIName, BITIID = @BITIID,");
            cmdText.Append("                       BISenderCode = @BISenderCode, BISender = @BISender, ");
            cmdText.Append("                       BIReciverCode = @BIReciverCode, BIReciver = @BIReciver,");
            cmdText.Append("                       BIAmount = @BIAmount, BIIsEnable = @BIIsEnable  ");
            cmdText.Append(" WHERE BIID =  @BIID ");
            SqlParameter[] paras = new SqlParameter[]
            {
                new SqlParameter("@BIID",billManage.BIID),
                new SqlParameter("@BINo",billManage.BINo),
                new SqlParameter("@BIName",billManage.BIName),
                new SqlParameter("@BITIID",billManage.BITIID),
                new SqlParameter("@BISenderCode",billManage.BISenderCode),
                new SqlParameter("@BISender",billManage.BISender),
                new SqlParameter("@BIReciverCode",billManage.BIReciverCode),
                new SqlParameter("@BIReciver",billManage.BIReciver),
                new SqlParameter("@BIAmount",billManage.BIAmount),
                new SqlParameter("@BIIsEnable",billManage.BIIsEnable)
            };
            return new MySqlHelper().ExecDataBySql(cmdText.ToString(), paras);
        }
     
     
        /// <summary>
        /// 查询BillManage
        /// </summary>
        /// <param name="cmdText">sql命令</param>
        public static IList<BillManageInfo> SelectBillManageByCmdText(String cmdText)
        {
            IList<BillManageInfo> billManages = new List<BillManageInfo>();
            using (SqlDataReader sdr = new MySqlHelper().GetDataReader(cmdText))
            {
                while (sdr.Read())
                {
                    BillManageInfo billManage = new BillManageInfo();
                    billManage.BIID = (Convert.ToInt32(sdr[0]));
                    billManage.BINo = (Convert.ToString(sdr[1]));
                    billManage.BIName = (Convert.ToString(sdr[2]));
                    billManage.BITIID = (Convert.ToInt32(sdr[3]));
                    billManage.BISenderCode = (Convert.ToString(sdr[4]));
                    billManage.BISender = (Convert.ToString(sdr[5]));
                    billManage.BIReciverCode = (Convert.ToString(sdr[6]));
                    billManage.BIReciver = (Convert.ToString(sdr[7]));
                    billManage.BIAmount = (Convert.ToInt64(sdr[8]));
                    billManage.BIIsEnable = (Convert.ToBoolean(sdr[9]));
                billManages.Add(billManage);
                }
            }
            return billManages;
        }
     
     
        /// <summary>
        /// 根据BIID查询BillManage
        /// </summary>
        /// <param name=" _bIID">属性值</param>
        public static BillManageInfo SelectBillManageByBIID(Int32  _bIID)
        {
            StringBuilder cmdText = new StringBuilder();
            cmdText.Append("SELECT ");
            cmdText.Append("    BIID,BINo,BIName,BITIID,BISenderCode,BISender,");
            cmdText.Append("    BIReciverCode,BIReciver,BIAmount,BIIsEnable");
            cmdText.Append(" FROM BillManage with(nolock) ");
            cmdText.AppendFormat("  WHERE  BIIsEnable = '1' and BIID = '{0}'",_bIID);
            IList<BillManageInfo> billManages = SelectBillManageByCmdText(cmdText.ToString());
            return billManages.Count>0 ? billManages[0] : null;
        }
     
     
        /// <summary>
        /// 查询所有BillManage
        /// </summary>
        public static IList<BillManageInfo> SelectAllBillManage()
        {
            StringBuilder cmdText = new StringBuilder();
            cmdText.Append(" SELECT ");
            cmdText.Append("    BIID,BINo,BIName,BITIID,BISenderCode,BISender,");
            cmdText.Append("    BIReciverCode,BIReciver,BIAmount,BIIsEnable");
            cmdText.Append(" FROM BillManage with(nolock) ");
            cmdText.Append(" WHERE  BIIsEnable = '1' ");
            return SelectBillManageByCmdText(cmdText.ToString());
        }

        public String GetNewCodeBINoByTIID(int _TIID)
        {
            StringBuilder cmdText = new StringBuilder();
            cmdText.AppendFormat("Select Max(BIID) From BillManage where BITIID = '{0}'", _TIID);
            try
            {
                String strMaxCode = new MySqlHelper().GetSingleObject(cmdText.ToString()) as String;
                if (String.IsNullOrEmpty(strMaxCode))
                {
                    strMaxCode =FormatString(intLength);
                }
                string strMaxSeqNum = strMaxCode.Substring(strHeader.Length);
                return strHeader + (Convert.ToInt32(strMaxSeqNum) + 1).ToString(FormatString(intLength));
            }
        }
    }
}
