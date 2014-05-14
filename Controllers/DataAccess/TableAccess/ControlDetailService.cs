using System;
using System.Collections.Generic;
using System.Text;
using Controllers.Models;
using System.Data.SqlClient;
namespace Controllers.DAL
{
    /// <summary>
    ///本数据访问类由Hirer实体数据访问层工具生成
    /// </summary>
    public class ControlDetailService
    {
        /// <summary>
        /// 添加一个ControlDetail
        /// </summary>
        /// <param name="controlDetail">对象实例</param>
        public static int AddControlDetail(ControlDetail controlDetail)
        {
            string cmdText="INSERT INTO ControlDetails ( CDCTIID,CDBIID,CDText,CDIsEnable,CDControlType ) VALUES(@CDCTIID,@CDBIID,@CDText,@CDIsEnable,@CDControlType)";
            SqlParameter[] paras = new SqlParameter[]
            {
                new SqlParameter("@CDID",controlDetail.CDID),
                new SqlParameter("@CDCTIID",controlDetail.CDCTIID),
                new SqlParameter("@CDBIID",controlDetail.CDBIID),
                new SqlParameter("@CDText",controlDetail.CDText),
                new SqlParameter("@CDIsEnable",controlDetail.CDIsEnable),
                new SqlParameter("@CDControlType",controlDetail.CDControlType)
            };
            return (int)DBHelper.Execute(cmdText, paras);
        }
     
     
        /// <summary>
        /// 根据CDID删除ControlDetail
        /// </summary>
        /// <param name="CDID">对象属性</param>
        public static int DeleteControlDetailByCDID(Int32  _cDID)
        {
            string cmdText="DELETE ControlDetails WHERE  CDID = " +  _cDID;
            return (int)DBHelper.Execute(cmdText);
        }
     
     
        /// <summary>
        /// 更新ControlDetail
        /// </summary>
        /// <param name="controlDetail">新的对象实例</param>
        public static int UpdateControlDetail(ControlDetail controlDetail)
        {
            string cmdText="UPDATE ControlDetails SET  CDCTIID = @CDCTIID, CDBIID = @CDBIID, CDText = @CDText, CDIsEnable = @CDIsEnable, CDControlType = @CDControlType  WHERE CDID =  @CDID";
            SqlParameter[] paras = new SqlParameter[]
            {
                new SqlParameter("@CDID",controlDetail.CDID),
                new SqlParameter("@CDCTIID",controlDetail.CDCTIID),
                new SqlParameter("@CDBIID",controlDetail.CDBIID),
                new SqlParameter("@CDText",controlDetail.CDText),
                new SqlParameter("@CDIsEnable",controlDetail.CDIsEnable),
                new SqlParameter("@CDControlType",controlDetail.CDControlType)
            };
            return (int)DBHelper.Execute(cmdText, paras);
        }
     
     
        /// <summary>
        /// 查询ControlDetail
        /// </summary>
        /// <param name="cmdText">sql命令</param>
        public static IList<ControlDetail> SelectControlDetailByCmdText(String cmdText)
        {
            IList<ControlDetail> controlDetails = new List<ControlDetail>();
            using (SqlDataReader sdr = (SqlDataReader)DBHelper.Execute(cmdText))
            {
                while (sdr.Read())
                {
                    ControlDetail controlDetail = new ControlDetail();
                    controlDetail.CDID = (Convert.ToInt32(sdr[0]));
                    controlDetail.CDCTIID = (Convert.ToInt32(sdr[1]));
                    controlDetail.CDBIID = (Convert.ToInt32(sdr[2]));
                    controlDetail.CDText = (Convert.ToString(sdr[3]));
                    controlDetail.CDIsEnable = (Convert.ToBoolean(sdr[4]));
                    controlDetail.CDControlType = (Convert.ToString(sdr[5]));
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
            string cmdText="SELECT * FROM ControlDetails WHERE  CDID = " +  _cDID;
            IList<ControlDetail> controlDetails = SelectControlDetailByCmdText(cmdText);
            return controlDetails.Count>0 ? controlDetails[0] : null;
        }
     
     
        /// <summary>
        /// 查询所有ControlDetail
        /// </summary>
        public static IList<ControlDetail> SelectAllControlDetail()
        {
            string cmdText="SELECT * FROM ControlDetails";
            return SelectControlDetailByCmdText(cmdText);
        }
      
    }
}
