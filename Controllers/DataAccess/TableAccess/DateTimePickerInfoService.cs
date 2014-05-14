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
    public class DateTimePickerInfoService
    {
        /// <summary>
        /// 添加一个DateTimePickerInfo
        /// </summary>
        /// <param name="dateTimePickerInfo">对象实例</param>
        public static int AddDateTimePickerInfo(DateTimePickerInfo dateTimePickerInfo)
        {
            string cmdText="INSERT INTO DateTimePickerInfo ( DTPName,DTPDefault,DTPIsBorder,DTPIsTransparent,DTPLeft,DTPTop,DTPWidth,DTPHeight,DTPTabKey,DTPIsReadOnly,DTPVisiable,DTPIsMust,DTPIsPrint,DTPIsEnable,DTPBandsTable,DTPBandsCoumln,DTPTIID,DTPIFont,DTPFontColor,DTPBorerColor,DTPBackColor ) VALUES(@DTPName,@DTPDefault,@DTPIsBorder,@DTPIsTransparent,@DTPLeft,@DTPTop,@DTPWidth,@DTPHeight,@DTPTabKey,@DTPIsReadOnly,@DTPVisiable,@DTPIsMust,@DTPIsPrint,@DTPIsEnable,@DTPBandsTable,@DTPBandsCoumln,@DTPTIID,@DTPIFont,@DTPFontColor,@DTPBorerColor,@DTPBackColor)";
            SqlParameter[] paras = new SqlParameter[]
            {
                new SqlParameter("@DTPID",dateTimePickerInfo.DTPID),
                new SqlParameter("@DTPName",dateTimePickerInfo.DTPName),
                new SqlParameter("@DTPDefault",dateTimePickerInfo.DTPDefault),
                new SqlParameter("@DTPIsBorder",dateTimePickerInfo.DTPIsBorder),
                new SqlParameter("@DTPIsTransparent",dateTimePickerInfo.DTPIsTransparent),
                new SqlParameter("@DTPLeft",dateTimePickerInfo.DTPLeft),
                new SqlParameter("@DTPTop",dateTimePickerInfo.DTPTop),
                new SqlParameter("@DTPWidth",dateTimePickerInfo.DTPWidth),
                new SqlParameter("@DTPHeight",dateTimePickerInfo.DTPHeight),
                new SqlParameter("@DTPTabKey",dateTimePickerInfo.DTPTabKey),
                new SqlParameter("@DTPIsReadOnly",dateTimePickerInfo.DTPIsReadOnly),
                new SqlParameter("@DTPVisiable",dateTimePickerInfo.DTPVisiable),
                new SqlParameter("@DTPIsMust",dateTimePickerInfo.DTPIsMust),
                new SqlParameter("@DTPIsPrint",dateTimePickerInfo.DTPIsPrint),
                new SqlParameter("@DTPIsEnable",dateTimePickerInfo.DTPIsEnable),
                new SqlParameter("@DTPBandsTable",dateTimePickerInfo.DTPBandsTable),
                new SqlParameter("@DTPBandsCoumln",dateTimePickerInfo.DTPBandsCoumln),
                new SqlParameter("@DTPTIID",dateTimePickerInfo.DTPTIID),
                new SqlParameter("@DTPIFont",dateTimePickerInfo.DTPIFont),
                new SqlParameter("@DTPFontColor",dateTimePickerInfo.DTPFontColor),
                new SqlParameter("@DTPBorerColor",dateTimePickerInfo.DTPBorerColor),
                new SqlParameter("@DTPBackColor",dateTimePickerInfo.DTPBackColor)
            };
            return (int)DBHelper.Execute(cmdText, paras);
        }
     
     
        /// <summary>
        /// 根据DTPID删除DateTimePickerInfo
        /// </summary>
        /// <param name="DTPID">对象属性</param>
        public static int DeleteDateTimePickerInfoByDTPID(Int32  _dTPID)
        {
            string cmdText="DELETE DateTimePickerInfo WHERE  DTPID = " +  _dTPID;
            return (int)DBHelper.Execute(cmdText);
        }
     
     
        /// <summary>
        /// 更新DateTimePickerInfo
        /// </summary>
        /// <param name="dateTimePickerInfo">新的对象实例</param>
        public static int UpdateDateTimePickerInfo(DateTimePickerInfo dateTimePickerInfo)
        {
            string cmdText="UPDATE DateTimePickerInfo SET  DTPName = @DTPName, DTPDefault = @DTPDefault, DTPIsBorder = @DTPIsBorder, DTPIsTransparent = @DTPIsTransparent, DTPLeft = @DTPLeft, DTPTop = @DTPTop, DTPWidth = @DTPWidth, DTPHeight = @DTPHeight, DTPTabKey = @DTPTabKey, DTPIsReadOnly = @DTPIsReadOnly, DTPVisiable = @DTPVisiable, DTPIsMust = @DTPIsMust, DTPIsPrint = @DTPIsPrint, DTPIsEnable = @DTPIsEnable, DTPBandsTable = @DTPBandsTable, DTPBandsCoumln = @DTPBandsCoumln, DTPTIID = @DTPTIID, DTPIFont = @DTPIFont, DTPFontColor = @DTPFontColor, DTPBorerColor = @DTPBorerColor, DTPBackColor = @DTPBackColor  WHERE DTPID =  @DTPID";
            SqlParameter[] paras = new SqlParameter[]
            {
                new SqlParameter("@DTPID",dateTimePickerInfo.DTPID),
                new SqlParameter("@DTPName",dateTimePickerInfo.DTPName),
                new SqlParameter("@DTPDefault",dateTimePickerInfo.DTPDefault),
                new SqlParameter("@DTPIsBorder",dateTimePickerInfo.DTPIsBorder),
                new SqlParameter("@DTPIsTransparent",dateTimePickerInfo.DTPIsTransparent),
                new SqlParameter("@DTPLeft",dateTimePickerInfo.DTPLeft),
                new SqlParameter("@DTPTop",dateTimePickerInfo.DTPTop),
                new SqlParameter("@DTPWidth",dateTimePickerInfo.DTPWidth),
                new SqlParameter("@DTPHeight",dateTimePickerInfo.DTPHeight),
                new SqlParameter("@DTPTabKey",dateTimePickerInfo.DTPTabKey),
                new SqlParameter("@DTPIsReadOnly",dateTimePickerInfo.DTPIsReadOnly),
                new SqlParameter("@DTPVisiable",dateTimePickerInfo.DTPVisiable),
                new SqlParameter("@DTPIsMust",dateTimePickerInfo.DTPIsMust),
                new SqlParameter("@DTPIsPrint",dateTimePickerInfo.DTPIsPrint),
                new SqlParameter("@DTPIsEnable",dateTimePickerInfo.DTPIsEnable),
                new SqlParameter("@DTPBandsTable",dateTimePickerInfo.DTPBandsTable),
                new SqlParameter("@DTPBandsCoumln",dateTimePickerInfo.DTPBandsCoumln),
                new SqlParameter("@DTPTIID",dateTimePickerInfo.DTPTIID),
                new SqlParameter("@DTPIFont",dateTimePickerInfo.DTPIFont),
                new SqlParameter("@DTPFontColor",dateTimePickerInfo.DTPFontColor),
                new SqlParameter("@DTPBorerColor",dateTimePickerInfo.DTPBorerColor),
                new SqlParameter("@DTPBackColor",dateTimePickerInfo.DTPBackColor)
            };
            return (int)DBHelper.Execute(cmdText, paras);
        }
     
     
        /// <summary>
        /// 查询DateTimePickerInfo
        /// </summary>
        /// <param name="cmdText">sql命令</param>
        public static IList<DateTimePickerInfo> SelectDateTimePickerInfoByCmdText(String cmdText)
        {
            IList<DateTimePickerInfo> dateTimePickerInfos = new List<DateTimePickerInfo>();
            using (SqlDataReader sdr = (SqlDataReader)DBHelper.Execute(cmdText))
            {
                while (sdr.Read())
                {
                    DateTimePickerInfo dateTimePickerInfo = new DateTimePickerInfo();
                    dateTimePickerInfo.DTPID = (Convert.ToInt32(sdr[0]));
                    dateTimePickerInfo.DTPName = (Convert.ToString(sdr[1]));
                    dateTimePickerInfo.DTPDefault = (Convert.ToString(sdr[2]));
                    dateTimePickerInfo.DTPIsBorder = (Convert.ToByte(sdr[3]));
                    dateTimePickerInfo.DTPIsTransparent = (Convert.ToByte(sdr[4]));
                    dateTimePickerInfo.DTPLeft = (Convert.ToInt32(sdr[5]));
                    dateTimePickerInfo.DTPTop = (Convert.ToInt32(sdr[6]));
                    dateTimePickerInfo.DTPWidth = (Convert.ToInt32(sdr[7]));
                    dateTimePickerInfo.DTPHeight = (Convert.ToInt32(sdr[8]));
                    dateTimePickerInfo.DTPTabKey = (Convert.ToInt32(sdr[9]));
                    dateTimePickerInfo.DTPIsReadOnly = (Convert.ToByte(sdr[10]));
                    dateTimePickerInfo.DTPVisiable = (Convert.ToByte(sdr[11]));
                    dateTimePickerInfo.DTPIsMust = (Convert.ToByte(sdr[12]));
                    dateTimePickerInfo.DTPIsPrint = (Convert.ToByte(sdr[13]));
                    dateTimePickerInfo.DTPIsEnable = (Convert.ToByte(sdr[14]));
                    dateTimePickerInfo.DTPBandsTable = (Convert.ToString(sdr[15]));
                    dateTimePickerInfo.DTPBandsCoumln = (Convert.ToString(sdr[16]));
                    dateTimePickerInfo.DTPTIID = (Convert.ToInt32(sdr[17]));
                    dateTimePickerInfo.DTPIFont = (Convert.ToString(sdr[18]));
                    dateTimePickerInfo.DTPFontColor = (Convert.ToString(sdr[19]));
                    dateTimePickerInfo.DTPBorerColor = (Convert.ToString(sdr[20]));
                    dateTimePickerInfo.DTPBackColor = (Convert.ToString(sdr[21]));
                dateTimePickerInfos.Add(dateTimePickerInfo);
                }
            }
            return dateTimePickerInfos;
        }
     
     
        /// <summary>
        /// 根据DTPID查询DateTimePickerInfo
        /// </summary>
        /// <param name=" _dTPID">属性值</param>
        public static DateTimePickerInfo SelectDateTimePickerInfoByDTPID(Int32  _dTPID)
        {
            string cmdText="SELECT * FROM DateTimePickerInfo WHERE  DTPID = " +  _dTPID;
            IList<DateTimePickerInfo> dateTimePickerInfos = SelectDateTimePickerInfoByCmdText(cmdText);
            return dateTimePickerInfos.Count>0 ? dateTimePickerInfos[0] : null;
        }
     
     
        /// <summary>
        /// 查询所有DateTimePickerInfo
        /// </summary>
        public static IList<DateTimePickerInfo> SelectAllDateTimePickerInfo()
        {
            string cmdText="SELECT * FROM DateTimePickerInfo";
            return SelectDateTimePickerInfoByCmdText(cmdText);
        }
      
    }
}
