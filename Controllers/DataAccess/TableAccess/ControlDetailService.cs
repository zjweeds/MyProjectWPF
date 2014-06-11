/******************************************************************
 * 创 建 人：  赵建
 * 创建时间：  2013-11-16 9:59
 * 描    述：
 *             控件明细表数据层
 * 版    本：  V1.0      
 * 环    境：  VS2013
******************************************************************/
using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using Controllers.Models;
using System.Data.SqlClient;
using Controllers.DataAccess.SQLHELPER;

namespace Controllers.DataAccess
{
    public class ControlDetailService
    {
        /// <summary>
        /// 添加一个ControlDetail
        /// </summary>
        /// <param name="controlDetail">对象实例</param>
        public static int AddControlDetail(ControlDetail controlDetail)
        {
            StringBuilder cmdText=new StringBuilder();
            cmdText.Append("INSERT into ControlDetails ( CDCTIID,CDBIID,CDText,CDIsEnable,CDControlType,CDTIID) ");
            cmdText.Append("                     VALUES(@CDCTIID,@CDBIID,@CDText,@CDIsEnable,@CDControlType,@CDTIID) ");
            cmdText.Append(" Select @@Identity ");
            SqlParameter[] paras = new SqlParameter[]
            {
                new SqlParameter("@CDID",controlDetail.CDID),
                new SqlParameter("@CDCTIID",controlDetail.CDCTIID),
                new SqlParameter("@CDBIID",controlDetail.CDBIID),
                new SqlParameter("@CDText",controlDetail.CDText),
                new SqlParameter("@CDIsEnable",controlDetail.CDIsEnable),
                new SqlParameter("@CDControlType",controlDetail.CDControlType),
                new SqlParameter("@CDTIID",controlDetail.CDTIID)
            };
            return new MySqlHelper().ExecSqlReturnId(cmdText.ToString(), paras);
        }

        /// <summary>
        /// 批量插入控件明细
        /// </summary>
        /// <param name="controlDetailList"></param>
        /// <returns>1成功，-1失败，0 无更新</returns>
        public static int  AddControlDetailByList(IList<ControlDetail> controlDetailList)
        {
            List<String> cmdTextList = new List<String>();
            if (controlDetailList != null && controlDetailList.Count > 0)
            {
                foreach (ControlDetail controlDetail in controlDetailList)
                {
                    StringBuilder cmdText = new StringBuilder();
                    cmdText.Append("INSERT into ControlDetails ( CDCTIID,CDBIID,CDText,CDIsEnable,CDControlType,CDTIID ) ");
                    cmdText.AppendFormat("                     VALUES('{0}','{1}','{2}','{3}','{4}','{5}') ", controlDetail.CDCTIID,
                        controlDetail.CDBIID, controlDetail.CDText, controlDetail.CDIsEnable, controlDetail.CDControlType, controlDetail.CDTIID);
                    cmdTextList.Add(cmdText.ToString());
                }
                return new MySqlHelper().ExecDataBySqls(cmdTextList)?1:-1;//1成功，-1失败
            }
            else
            {
                return 0;//没有更新
            }
        }

        /// <summary>
        /// 根据CDID删除ControlDetail
        /// </summary>
        /// <param name="CDID">对象属性</param>
        public static int DeleteControlDetailByCDID(Int32  _cDID)
        {
            String cmdText = "Update ControlDetails Set CDIsEnable = '0'  WHERE  CDID = " + _cDID;
            return new MySqlHelper().ExecDataBySql(cmdText);
        }
     
        /// <summary>
        /// 更新ControlDetail
        /// </summary>
        /// <param name="controlDetail">新的对象实例</param>
        public static int UpdateControlDetail(ControlDetail controlDetail)
        {
            StringBuilder cmdText = new StringBuilder();
            cmdText.Append("UPDATE ControlDetails SET  CDCTIID = @CDCTIID, CDBIID = @CDBIID, CDText = @CDText, ");
            cmdText.Append("CDIsEnable = @CDIsEnable, CDControlType = @CDControlType,CDTIID= @CDTIID  WHERE CDID =  @CDID ");
            SqlParameter[] paras = new SqlParameter[]
            {
                new SqlParameter("@CDID",controlDetail.CDID),
                new SqlParameter("@CDCTIID",controlDetail.CDCTIID),
                new SqlParameter("@CDBIID",controlDetail.CDBIID),
                new SqlParameter("@CDText",controlDetail.CDText),
                new SqlParameter("@CDIsEnable",controlDetail.CDIsEnable),
                new SqlParameter("@CDControlType",controlDetail.CDControlType),
                 new SqlParameter("@CDTIID",controlDetail.CDTIID)
            };
            return new MySqlHelper().ExecDataBySql(cmdText.ToString(), paras);
        }
        
        /// <summary>
        /// 查询ControlDetail
        /// </summary>
        /// <param name="cmdText">sql命令</param>
        public static IList<ControlDetail> SelectControlDetailByCmdText(String cmdText)
        {
            IList<ControlDetail> controlDetails = new List<ControlDetail>();
            using (SqlDataReader sdr = (SqlDataReader)new MySqlHelper().GetDataReader(cmdText))
            {
                while (sdr.Read())
                {
                    ControlDetail controlDetail = new ControlDetail();
                    controlDetail.CDID = (Convert.ToInt32(sdr[0]));
                    controlDetail.CDCTIID = (Convert.ToInt32(sdr[1]));
                    controlDetail.CDBIID = (Convert.ToInt32(sdr[2]));
                    controlDetail.CDText = (Convert.ToString(sdr[3]));
                    controlDetail.CDIsEnable = (Convert.ToInt32(sdr[4]));
                    controlDetail.CDControlType = (Convert.ToString(sdr[5]));
                    controlDetail.CDTIID = (Convert.ToInt32(sdr[6]));
                controlDetails.Add(controlDetail);
                }
            }
            return controlDetails;
        }
     
        /// <summary>
        /// 根据CDID查询ControlDetail
        /// </summary>
        /// <param name=" _cDID">属性值</param>
        public static ControlDetail SelectControlDetailByCDID(Int32  _cDID)
        {
            String cmdText = "SELECT * FROM ControlDetails WHERE  CDIsEnable = '1' and  CDID = " + _cDID;
            IList<ControlDetail> controlDetails = SelectControlDetailByCmdText(cmdText);
            return controlDetails.Count>0 ? controlDetails[0] : null;
        }
       
        /// <summary>
        /// 查询所有ControlDetail
        /// </summary>
        public static IList<ControlDetail> SelectAllControlDetail()
        {
            String cmdText = "SELECT * FROM ControlDetails where CDIsEnable = '1'";
            return SelectControlDetailByCmdText(cmdText);
        }

        /// <summary>
        /// 查询票据信息，将CIID作列名，CText作列值
        /// </summary>
        /// <param name="cIIDList">当前模板的控件ID列表</param>
        /// <param name="templateID">模板ID</param>
        /// <returns>按账单编号分组的票据信息</returns>
        public static DataTable QueryBillInfoControlsDetailByCIIDList(IList<Int32> cIIDList,int templateID)
        {
            DataTable dt = new DataTable();
            if (cIIDList != null && cIIDList.Count > 0)
            {
                StringBuilder cmdText = new StringBuilder();
                cmdText.Append("select");
                foreach (int cIID in cIIDList)
                {
                    if (cmdText.ToString() != "select")
                    {
                        cmdText.Append(" , ");
                    }
                    cmdText.AppendFormat(" ,MAX(CASE CDCTIID WHEN  '{0}' THEN CDText ELSE NULL END) as '{0}' ", Convert.ToString(cIID));
                }
                cmdText.AppendFormat(" FROM ControlDetails Where CDTIID ='{0}' GROUP BY CDBIID ", templateID);
                dt = new MySqlHelper().GetDataTable(cmdText.ToString());
            }
            return dt;
        }


        /// <summary>
        /// 根据模板编号使用存储过程查询账单信息
        /// </summary>
        /// <param name="templateID"></param>
        /// <returns></returns>
        public static DataTable QueryBillInfoCDByPROCEDURE(int templateID)
        {
            DataTable dtView = new DataTable();
            //创建SqlParameter对象，并赋值
            SqlParameter param = new SqlParameter("@TIID", SqlDbType.NVarChar);
            param.Value = templateID;
            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(param);
            //把泛型中的元素复制到数组中
            SqlParameter[] inputParameters = parameters.ToArray();
            return new MySqlHelper().GetDataTable("P_QueryBill", inputParameters);
        }

        /// <summary>
        /// 根据账单信息返回控件明细信息
        /// </summary>
        /// <param name="bIID"></param>
        /// <returns></returns>
        public static DataTable SeclectControlsDetailByBIID(int bIID)
        {
            StringBuilder cmdText = new StringBuilder();
            cmdText.AppendFormat("select CDCTIID,CDText from ControlDetails where  CDBIID = '{0}' and CDIsEnable = 1", bIID);
            return new MySqlHelper().GetDataTable(cmdText.ToString());
        }

        /// <summary>
        /// 根据控件文本返回控件明细ID
        /// </summary>
        /// <param name="BINO"></param>
        /// <param name="strVaule"></param>
        /// <returns></returns>
        public static int SelectCDBIIDByCDText(int BINO,String strVaule)
        {
            StringBuilder cmdText = new StringBuilder();
            cmdText.AppendFormat("select CDBIID from ControlDetails  with(nolock) where CDCTIID ='{0}' AND CDText ='{1}' ", BINO, strVaule);
            return (int)new MySqlHelper().GetSingleObject(cmdText.ToString());
        }
    }
}
