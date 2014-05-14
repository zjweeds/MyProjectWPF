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
    public class MoneyPanelInfoService
    {
        /// <summary>
        /// 添加一个MoneyPanelInfo
        /// </summary>
        /// <param name="moneyPanelInfo">对象实例</param>
        public static int AddMoneyPanelInfo(MoneyPanelInfo moneyPanelInfo)
        {
            string cmdText="INSERT INTO MoneyPanelInfo ( MPName,MPType,MPDefault,MPIsBorder,MPIsTransparent,MPLeft,MPTop,MPWidth,MPHeight,MPTabKey,MPIsReadOnly,MPVisiable,MPIsMust,MPIsPrint,MPIsEnable,MPTIID,MPFont,MPFontColor,MPBorerColor,MPBackColor,MPShowUnit,MPHighUnit,MPLowUnit,MPBindsID ) VALUES(@MPName,@MPType,@MPDefault,@MPIsBorder,@MPIsTransparent,@MPLeft,@MPTop,@MPWidth,@MPHeight,@MPTabKey,@MPIsReadOnly,@MPVisiable,@MPIsMust,@MPIsPrint,@MPIsEnable,@MPTIID,@MPFont,@MPFontColor,@MPBorerColor,@MPBackColor,@MPShowUnit,@MPHighUnit,@MPLowUnit,@MPBindsID)";
            SqlParameter[] paras = new SqlParameter[]
            {
                new SqlParameter("@MPID",moneyPanelInfo.MPID),
                new SqlParameter("@MPName",moneyPanelInfo.MPName),
                new SqlParameter("@MPType",moneyPanelInfo.MPType),
                new SqlParameter("@MPDefault",moneyPanelInfo.MPDefault),
                new SqlParameter("@MPIsBorder",moneyPanelInfo.MPIsBorder),
                new SqlParameter("@MPIsTransparent",moneyPanelInfo.MPIsTransparent),
                new SqlParameter("@MPLeft",moneyPanelInfo.MPLeft),
                new SqlParameter("@MPTop",moneyPanelInfo.MPTop),
                new SqlParameter("@MPWidth",moneyPanelInfo.MPWidth),
                new SqlParameter("@MPHeight",moneyPanelInfo.MPHeight),
                new SqlParameter("@MPTabKey",moneyPanelInfo.MPTabKey),
                new SqlParameter("@MPIsReadOnly",moneyPanelInfo.MPIsReadOnly),
                new SqlParameter("@MPVisiable",moneyPanelInfo.MPVisiable),
                new SqlParameter("@MPIsMust",moneyPanelInfo.MPIsMust),
                new SqlParameter("@MPIsPrint",moneyPanelInfo.MPIsPrint),
                new SqlParameter("@MPIsEnable",moneyPanelInfo.MPIsEnable),
                new SqlParameter("@MPTIID",moneyPanelInfo.MPTIID),
                new SqlParameter("@MPFont",moneyPanelInfo.MPFont),
                new SqlParameter("@MPFontColor",moneyPanelInfo.MPFontColor),
                new SqlParameter("@MPBorerColor",moneyPanelInfo.MPBorerColor),
                new SqlParameter("@MPBackColor",moneyPanelInfo.MPBackColor),
                new SqlParameter("@MPShowUnit",moneyPanelInfo.MPShowUnit),
                new SqlParameter("@MPHighUnit",moneyPanelInfo.MPHighUnit),
                new SqlParameter("@MPLowUnit",moneyPanelInfo.MPLowUnit),
                new SqlParameter("@MPBindsID",moneyPanelInfo.MPBindsID)
            };
            return (int)DBHelper.Execute(cmdText, paras);
        }
     
     
        /// <summary>
        /// 根据MPID删除MoneyPanelInfo
        /// </summary>
        /// <param name="MPID">对象属性</param>
        public static int DeleteMoneyPanelInfoByMPID(Int32  _mPID)
        {
            string cmdText="DELETE MoneyPanelInfo WHERE  MPID = " +  _mPID;
            return (int)DBHelper.Execute(cmdText);
        }
     
     
        /// <summary>
        /// 更新MoneyPanelInfo
        /// </summary>
        /// <param name="moneyPanelInfo">新的对象实例</param>
        public static int UpdateMoneyPanelInfo(MoneyPanelInfo moneyPanelInfo)
        {
            string cmdText="UPDATE MoneyPanelInfo SET  MPName = @MPName, MPType = @MPType, MPDefault = @MPDefault, MPIsBorder = @MPIsBorder, MPIsTransparent = @MPIsTransparent, MPLeft = @MPLeft, MPTop = @MPTop, MPWidth = @MPWidth, MPHeight = @MPHeight, MPTabKey = @MPTabKey, MPIsReadOnly = @MPIsReadOnly, MPVisiable = @MPVisiable, MPIsMust = @MPIsMust, MPIsPrint = @MPIsPrint, MPIsEnable = @MPIsEnable, MPTIID = @MPTIID, MPFont = @MPFont, MPFontColor = @MPFontColor, MPBorerColor = @MPBorerColor, MPBackColor = @MPBackColor, MPShowUnit = @MPShowUnit, MPHighUnit = @MPHighUnit, MPLowUnit = @MPLowUnit, MPBindsID = @MPBindsID  WHERE MPID =  @MPID";
            SqlParameter[] paras = new SqlParameter[]
            {
                new SqlParameter("@MPID",moneyPanelInfo.MPID),
                new SqlParameter("@MPName",moneyPanelInfo.MPName),
                new SqlParameter("@MPType",moneyPanelInfo.MPType),
                new SqlParameter("@MPDefault",moneyPanelInfo.MPDefault),
                new SqlParameter("@MPIsBorder",moneyPanelInfo.MPIsBorder),
                new SqlParameter("@MPIsTransparent",moneyPanelInfo.MPIsTransparent),
                new SqlParameter("@MPLeft",moneyPanelInfo.MPLeft),
                new SqlParameter("@MPTop",moneyPanelInfo.MPTop),
                new SqlParameter("@MPWidth",moneyPanelInfo.MPWidth),
                new SqlParameter("@MPHeight",moneyPanelInfo.MPHeight),
                new SqlParameter("@MPTabKey",moneyPanelInfo.MPTabKey),
                new SqlParameter("@MPIsReadOnly",moneyPanelInfo.MPIsReadOnly),
                new SqlParameter("@MPVisiable",moneyPanelInfo.MPVisiable),
                new SqlParameter("@MPIsMust",moneyPanelInfo.MPIsMust),
                new SqlParameter("@MPIsPrint",moneyPanelInfo.MPIsPrint),
                new SqlParameter("@MPIsEnable",moneyPanelInfo.MPIsEnable),
                new SqlParameter("@MPTIID",moneyPanelInfo.MPTIID),
                new SqlParameter("@MPFont",moneyPanelInfo.MPFont),
                new SqlParameter("@MPFontColor",moneyPanelInfo.MPFontColor),
                new SqlParameter("@MPBorerColor",moneyPanelInfo.MPBorerColor),
                new SqlParameter("@MPBackColor",moneyPanelInfo.MPBackColor),
                new SqlParameter("@MPShowUnit",moneyPanelInfo.MPShowUnit),
                new SqlParameter("@MPHighUnit",moneyPanelInfo.MPHighUnit),
                new SqlParameter("@MPLowUnit",moneyPanelInfo.MPLowUnit),
                new SqlParameter("@MPBindsID",moneyPanelInfo.MPBindsID)
            };
            return (int)DBHelper.Execute(cmdText, paras);
        }
     
     
        /// <summary>
        /// 查询MoneyPanelInfo
        /// </summary>
        /// <param name="cmdText">sql命令</param>
        public static IList<MoneyPanelInfo> SelectMoneyPanelInfoByCmdText(String cmdText)
        {
            IList<MoneyPanelInfo> moneyPanelInfos = new List<MoneyPanelInfo>();
            using (SqlDataReader sdr = (SqlDataReader)DBHelper.Execute(cmdText))
            {
                while (sdr.Read())
                {
                    MoneyPanelInfo moneyPanelInfo = new MoneyPanelInfo();
                    moneyPanelInfo.MPID = (Convert.ToInt32(sdr[0]));
                    moneyPanelInfo.MPName = (Convert.ToString(sdr[1]));
                    moneyPanelInfo.MPType = (Convert.ToString(sdr[2]));
                    moneyPanelInfo.MPDefault = (Convert.ToString(sdr[3]));
                    moneyPanelInfo.MPIsBorder = (Convert.ToByte(sdr[4]));
                    moneyPanelInfo.MPIsTransparent = (Convert.ToByte(sdr[5]));
                    moneyPanelInfo.MPLeft = (Convert.ToInt32(sdr[6]));
                    moneyPanelInfo.MPTop = (Convert.ToInt32(sdr[7]));
                    moneyPanelInfo.MPWidth = (Convert.ToInt32(sdr[8]));
                    moneyPanelInfo.MPHeight = (Convert.ToInt32(sdr[9]));
                    moneyPanelInfo.MPTabKey = (Convert.ToInt32(sdr[10]));
                    moneyPanelInfo.MPIsReadOnly = (Convert.ToByte(sdr[11]));
                    moneyPanelInfo.MPVisiable = (Convert.ToByte(sdr[12]));
                    moneyPanelInfo.MPIsMust = (Convert.ToByte(sdr[13]));
                    moneyPanelInfo.MPIsPrint = (Convert.ToByte(sdr[14]));
                    moneyPanelInfo.MPIsEnable = (Convert.ToByte(sdr[15]));
                    moneyPanelInfo.MPTIID = (Convert.ToInt32(sdr[16]));
                    moneyPanelInfo.MPFont = (Convert.ToString(sdr[17]));
                    moneyPanelInfo.MPFontColor = (Convert.ToString(sdr[18]));
                    moneyPanelInfo.MPBorerColor = (Convert.ToString(sdr[19]));
                    moneyPanelInfo.MPBackColor = (Convert.ToString(sdr[20]));
                    moneyPanelInfo.MPShowUnit = (Convert.ToBoolean(sdr[21]));
                    moneyPanelInfo.MPHighUnit = (Convert.ToString(sdr[22]));
                    moneyPanelInfo.MPLowUnit = (Convert.ToString(sdr[23]));
                    moneyPanelInfo.MPBindsID = (Convert.ToInt32(sdr[24]));
                moneyPanelInfos.Add(moneyPanelInfo);
                }
            }
            return moneyPanelInfos;
        }
     
     
        /// <summary>
        /// 根据MPID查询MoneyPanelInfo
        /// </summary>
        /// <param name=" _mPID">属性值</param>
        public static MoneyPanelInfo SelectMoneyPanelInfoByMPID(Int32  _mPID)
        {
            string cmdText="SELECT * FROM MoneyPanelInfo WHERE  MPID = " +  _mPID;
            IList<MoneyPanelInfo> moneyPanelInfos = SelectMoneyPanelInfoByCmdText(cmdText);
            return moneyPanelInfos.Count>0 ? moneyPanelInfos[0] : null;
        }
     
     
        /// <summary>
        /// 查询所有MoneyPanelInfo
        /// </summary>
        public static IList<MoneyPanelInfo> SelectAllMoneyPanelInfo()
        {
            string cmdText="SELECT * FROM MoneyPanelInfo";
            return SelectMoneyPanelInfoByCmdText(cmdText);
        }
      
    }
}
