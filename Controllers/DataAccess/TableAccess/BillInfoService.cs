/******************************************************************
 * 创 建 人：  赵建
 * 创建时间：  2014-3-16 9:59
 * 描    述：
 *             BillInfo账单信息数据访问层
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
    /// <summary>
    /// BillInfo账单信息数据访问层
    /// </summary>
    public class BillInfoService
    {
        /// <summary>
        /// 添加一个BillInfo
        /// </summary>
        /// <param name="billInfo">对象实例</param>
        public static int AddBillInfo(BillInfo billInfo)
        {
            StringBuilder cmdText = new StringBuilder();
            cmdText.Append("INSERT INTO BillInfo ( ");
            cmdText.Append("                      BINo,BIName,BITIID,BISenderCode,BISender,BIReciverCode,BIReciver,");
            cmdText.Append("                      BIAmount,BIIsEnable ");
            cmdText.Append("                      ) VALUES(");
            cmdText.AppendFormat("'{0}',", billInfo.BINo);
            cmdText.AppendFormat("'{0}',", billInfo.BIName);
            cmdText.AppendFormat("'{0}',", billInfo.BITIID);
            cmdText.AppendFormat("'{0}',", billInfo.BISenderCode);
            cmdText.AppendFormat("'{0}',", billInfo.BISender);
            cmdText.AppendFormat("'{0}',", billInfo.BIReciverCode);
            cmdText.AppendFormat("'{0}',", billInfo.BIReciver);
            cmdText.AppendFormat("'{0}',", billInfo.BIAmount);
            cmdText.AppendFormat("'{0}')", billInfo.BIIsEnable);
            cmdText.Append(" Select @@Identity ");
            return new MySqlHelper().ExecSqlReturnId(cmdText.ToString());
        }
     
     
        /// <summary>
        /// 根据BIID删除BillInfo
        /// </summary>
        /// <param name="BIID">对象属性</param>
        public static int DeleteBillInfoByBIID(Int32  _bIID)
        {
            string cmdText = "Update BillInfo Set BIIsEnable = 0 WHERE  BIID = " + _bIID;
            return  new MySqlHelper().ExecDataBySql(cmdText);
        }
     
     
        /// <summary>
        /// 更新BillInfo
        /// </summary>
        /// <param name="billInfo">新的对象实例</param>
        public static int UpdateBillInfo(BillInfo billInfo)
        {
            string cmdText="UPDATE BillInfo SET  BINo = @BINo, BIName = @BIName, BITIID = @BITIID, BISenderCode = @BISenderCode, BISender = @BISender, BIReciverCode = @BIReciverCode, BIReciver = @BIReciver, BIAmount = @BIAmount, BIIsEnable = @BIIsEnable  WHERE BIID =  @BIID";
            SqlParameter[] paras = new SqlParameter[]
            {
                new SqlParameter("@BIID",billInfo.BIID),
                new SqlParameter("@BINo",billInfo.BINo),
                new SqlParameter("@BIName",billInfo.BIName),
                new SqlParameter("@BITIID",billInfo.BITIID),
                new SqlParameter("@BISenderCode",billInfo.BISenderCode),
                new SqlParameter("@BISender",billInfo.BISender),
                new SqlParameter("@BIReciverCode",billInfo.BIReciverCode),
                new SqlParameter("@BIReciver",billInfo.BIReciver),
                new SqlParameter("@BIAmount",billInfo.BIAmount),
                new SqlParameter("@BIIsEnable",billInfo.BIIsEnable)
            };
            return new MySqlHelper().ExecDataBySql(cmdText, paras);
        }
     
     
        /// <summary>
        /// 查询BillInfo
        /// </summary>
        /// <param name="cmdText">sql命令</param>
        public static IList<BillInfo> SelectBillInfoByCmdText(String cmdText)
        {
            IList<BillInfo> billInfos = new List<BillInfo>();
            using (SqlDataReader sdr = new MySqlHelper().GetDataReader(cmdText))
            {
                while (sdr.Read())
                {
                    BillInfo billInfo = new BillInfo();
                    billInfo.BIID = (Convert.ToInt32(sdr[0]));
                    billInfo.BINo = (Convert.ToString(sdr[1]));
                    billInfo.BIName = (Convert.ToString(sdr[2]));
                    billInfo.BITIID = (Convert.ToInt32(sdr[3]));
                    billInfo.BISenderCode = (Convert.ToString(sdr[4]));
                    billInfo.BISender = (Convert.ToString(sdr[5]));
                    billInfo.BIReciverCode = (Convert.ToString(sdr[6]));
                    billInfo.BIReciver = (Convert.ToString(sdr[7]));
                    billInfo.BIAmount = (Convert.ToInt64(sdr[8]));
                    billInfo.BIIsEnable = (Convert.ToInt32(sdr[9]));
                billInfos.Add(billInfo);
                }
            }
            return billInfos;
        }
     
     
        /// <summary>
        /// 根据BIID查询BillInfo
        /// </summary>
        /// <param name=" _bIID">属性值</param>
        public static BillInfo SelectBillInfoByBIID(Int32  _bIID)
        {
            string cmdText="SELECT * FROM BillInfo where BIIsEnable = 1 and  BIID = " +  _bIID;
            IList<BillInfo> billInfos = SelectBillInfoByCmdText(cmdText);
            return billInfos.Count>0 ? billInfos[0] : null;
        }
     
     
        /// <summary>
        /// 查询所有BillInfo
        /// </summary>
        public static IList<BillInfo> SelectAllBillInfo()
        {
            string cmdText="SELECT * FROM BillInfo where BIIsEnable = 1";
            return SelectBillInfoByCmdText(cmdText);
        }

        /// <summary>
        /// 根据账套，查询所有账单信息
        /// </summary>
        /// <param name="billSetName"></param>
        /// <returns></returns>
        public static DataTable GetBillInfoByBillSet(String billSetName,String whereSql)
        {
            StringBuilder cmdText = new StringBuilder();
            cmdText.Append(" select BIID as '流水号', BINO as '账单号',BINAME AS '账单名称',");
            cmdText.Append("        TI.TIName AS '模板名称', BISenderCode as '付款方',");
            cmdText.Append("        BISender as '付款账号',BIReciver as '收款方',BIReciverCode as '收款账号',");
            cmdText.Append("        BIAmount as '总金额',BICreatTime as '开票时间' ,BIIsPrinted as '是否已打印'");
            cmdText.Append(" FROM  ");
            cmdText.Append("( select * from BillInfo where exists ");
            cmdText.Append("    ( select TITTID  from TemplateInfo where exists");
            cmdText.Append("        ( select TTID from TemplateType where  exists ");
            cmdText.Append("	        ( select TTBillSetID from BillSetInfo ");
            cmdText.AppendFormat("        where BSIID= TTBillSetID and BSIName = '{0}' ", billSetName);
            cmdText.Append("		    ) and TemplateType.TTID = TemplateInfo.TITTID");
            cmdText.Append("	    )and BillInfo.BITIID = TemplateInfo.TIID");
            cmdText.Append("    ) and  BillInfo.BIIsEnable = 1 ");
            cmdText.Append(" )Temp ");
            cmdText.Append(" JOIN TemplateInfo TI ON TI.TIID  = BITIID ");
            cmdText.Append("where 1=1 ");
            if (whereSql != String.Empty)
            {
                cmdText.Append(whereSql.ToString());
            }
            return new MySqlHelper().GetDataTable(cmdText.ToString());
        }
        
        /// <summary>
        /// 自动生成单据号
        /// </summary>
        /// <param name="intLength">单据号长度</param>
        /// <returns></returns>
        public static String CreatNewID(int intLength,int tIID)
        {
            String cmdText = "Select Max( BINo ) From  BillInfo where BITIID = '"+tIID+"'";
            try
            {
                string strMaxCode = new MySqlHelper().GetSingleObject(cmdText) as String;
                if (String.IsNullOrEmpty(strMaxCode))
                {
                    strMaxCode = FormatString(intLength);
                }
                return (Convert.ToInt32(strMaxCode) + 1).ToString(FormatString(intLength));
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// 格式化具有流水性质的编号
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
