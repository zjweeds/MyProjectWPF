/******************************************************************
 * 创 建 人：  赵建
 * 创建时间：  2013-11-16 9:59
 * 描    述：
 *             printset信息数据层
 * 版    本：  V1.0      
 * 环    境：  VS2013
******************************************************************/
using System;
using System.Collections.Generic;
using System.Text;
using Controllers.Models;
using System.Data.SqlClient;
using Controllers.DataAccess.SQLHELPER; 
namespace Controllers.DataAccess
{
    public class PrintSetService
    {
        /// <summary>
        /// 添加一个PrintSet
        /// </summary>
        /// <param name="printSet">对象实例</param>
        public static int AddPrintSet(PrintSetInfo printSet)
        {
            string cmdText="INSERT INTO PrintSet ( PSName,PSLeft,PSRight,PSIsEnable ) VALUES(@PSName,@PSLeft,@PSRight,@PSIsEnable)";
            SqlParameter[] paras = new SqlParameter[]
            {
                new SqlParameter("@PSID",printSet.PSID),
                new SqlParameter("@PSName",printSet.PSName),
                new SqlParameter("@PSLeft",printSet.PSLeft),
                new SqlParameter("@PSRight",printSet.PSRight),
                new SqlParameter("@PSIsEnable",printSet.PSIsEnable)
            };
            return new MySqlHelper().ExecDataBySql(cmdText, paras);
        }
     
     
        /// <summary>
        /// 根据PSID删除PrintSet
        /// </summary>
        /// <param name="PSID">对象属性</param>
        public static int DeletePrintSetByPSID(Int32  _pSID)
        {
            string cmdText="DELETE PrintSet WHERE  PSID = " +  _pSID;
            return new MySqlHelper().ExecDataBySql(cmdText);
        }
     
     
        /// <summary>
        /// 更新PrintSet
        /// </summary>
        /// <param name="printSet">新的对象实例</param>
        public static int UpdatePrintSet(PrintSetInfo printSet)
        {
            string cmdText="UPDATE PrintSet SET  PSName = @PSName, PSLeft = @PSLeft, PSRight = @PSRight, PSIsEnable = @PSIsEnable  WHERE PSID =  @PSID";
            SqlParameter[] paras = new SqlParameter[]
            {
                new SqlParameter("@PSID",printSet.PSID),
                new SqlParameter("@PSName",printSet.PSName),
                new SqlParameter("@PSLeft",printSet.PSLeft),
                new SqlParameter("@PSRight",printSet.PSRight),
                new SqlParameter("@PSIsEnable",printSet.PSIsEnable)
            };
            return new MySqlHelper().ExecDataBySql(cmdText, paras);
        }
     
     
        /// <summary>
        /// 查询PrintSet
        /// </summary>
        /// <param name="cmdText">sql命令</param>
        public static IList<PrintSetInfo> SelectPrintSetByCmdText(String cmdText)
        {
            IList<PrintSetInfo> printSets = new List<PrintSetInfo>();
            using (SqlDataReader sdr = new MySqlHelper().GetDataReader(cmdText))
            {
                while (sdr.Read())
                {
                    PrintSetInfo printSet = new PrintSetInfo();
                    printSet.PSID = (Convert.ToInt32(sdr[0]));
                    printSet.PSName = (Convert.ToString(sdr[1]));
                    printSet.PSLeft = (Convert.ToInt32(sdr[2]));
                    printSet.PSRight = (Convert.ToInt32(sdr[3]));
                    printSet.PSIsEnable = (Convert.ToBoolean(sdr[4]));
                printSets.Add(printSet);
                }
            }
            return printSets;
        }
     
        /// <summary>
        /// 根据PSID查询PrintSet
        /// </summary>
        /// <param name=" _pSID">属性值</param>
        public static PrintSetInfo SelectPrintSetByPSID(Int32  _pSID)
        {
            string cmdText="SELECT * FROM PrintSet WHERE  PSID = " +  _pSID;
            IList<PrintSetInfo> printSets = SelectPrintSetByCmdText(cmdText);
            return printSets.Count>0 ? printSets[0] : null;
        }
     
        /// <summary>
        /// 查询所有PrintSet
        /// </summary>
        public static IList<PrintSetInfo> SelectAllPrintSet()
        {
            string cmdText="SELECT * FROM PrintSet";
            return SelectPrintSetByCmdText(cmdText);
        }
      
    }
}
