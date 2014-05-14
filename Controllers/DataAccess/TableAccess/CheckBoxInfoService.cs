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
    public class CheckBoxInfoService
    {
        /// <summary>
        /// 添加一个CheckBoxInfo
        /// </summary>
        /// <param name="checkBoxInfo">对象实例</param>
        public static int AddCheckBoxInfo(CheckBoxInfo checkBoxInfo)
        {
            string cmdText="INSERT INTO CheckBoxInfo ( CHBName,CHBType,CHBDefault,CHBIsBorder,CHBIsTransparent,CHBLeft,CHBTop,CHBWidth,CHBHeight,CHBTabKey,CHBIsReadOnly,CHBVisiable,CHBIsMust,CHBIsPrint,CHBIsEnable,CHBBandsTabel,CHBBandsCoumln,CHBTIID,CHBFont,CHBFontColor,CHBBorerColor,CHBBackColor ) VALUES(@CHBName,@CHBType,@CHBDefault,@CHBIsBorder,@CHBIsTransparent,@CHBLeft,@CHBTop,@CHBWidth,@CHBHeight,@CHBTabKey,@CHBIsReadOnly,@CHBVisiable,@CHBIsMust,@CHBIsPrint,@CHBIsEnable,@CHBBandsTabel,@CHBBandsCoumln,@CHBTIID,@CHBFont,@CHBFontColor,@CHBBorerColor,@CHBBackColor)";
            SqlParameter[] paras = new SqlParameter[]
            {
                new SqlParameter("@CHBID",checkBoxInfo.CHBID),
                new SqlParameter("@CHBName",checkBoxInfo.CHBName),
                new SqlParameter("@CHBType",checkBoxInfo.CHBType),
                new SqlParameter("@CHBDefault",checkBoxInfo.CHBDefault),
                new SqlParameter("@CHBIsBorder",checkBoxInfo.CHBIsBorder),
                new SqlParameter("@CHBIsTransparent",checkBoxInfo.CHBIsTransparent),
                new SqlParameter("@CHBLeft",checkBoxInfo.CHBLeft),
                new SqlParameter("@CHBTop",checkBoxInfo.CHBTop),
                new SqlParameter("@CHBWidth",checkBoxInfo.CHBWidth),
                new SqlParameter("@CHBHeight",checkBoxInfo.CHBHeight),
                new SqlParameter("@CHBTabKey",checkBoxInfo.CHBTabKey),
                new SqlParameter("@CHBIsReadOnly",checkBoxInfo.CHBIsReadOnly),
                new SqlParameter("@CHBVisiable",checkBoxInfo.CHBVisiable),
                new SqlParameter("@CHBIsMust",checkBoxInfo.CHBIsMust),
                new SqlParameter("@CHBIsPrint",checkBoxInfo.CHBIsPrint),
                new SqlParameter("@CHBIsEnable",checkBoxInfo.CHBIsEnable),
                new SqlParameter("@CHBBandsTabel",checkBoxInfo.CHBBandsTabel),
                new SqlParameter("@CHBBandsCoumln",checkBoxInfo.CHBBandsCoumln),
                new SqlParameter("@CHBTIID",checkBoxInfo.CHBTIID),
                new SqlParameter("@CHBFont",checkBoxInfo.CHBFont),
                new SqlParameter("@CHBFontColor",checkBoxInfo.CHBFontColor),
                new SqlParameter("@CHBBorerColor",checkBoxInfo.CHBBorerColor),
                new SqlParameter("@CHBBackColor",checkBoxInfo.CHBBackColor)
            };
            return (int)DBHelper.Execute(cmdText, paras);
        }
     
     
        /// <summary>
        /// 根据CHBID删除CheckBoxInfo
        /// </summary>
        /// <param name="CHBID">对象属性</param>
        public static int DeleteCheckBoxInfoByCHBID(Int32  _cHBID)
        {
            string cmdText="DELETE CheckBoxInfo WHERE  CHBID = " +  _cHBID;
            return (int)DBHelper.Execute(cmdText);
        }
     
     
        /// <summary>
        /// 更新CheckBoxInfo
        /// </summary>
        /// <param name="checkBoxInfo">新的对象实例</param>
        public static int UpdateCheckBoxInfo(CheckBoxInfo checkBoxInfo)
        {
            string cmdText="UPDATE CheckBoxInfo SET  CHBName = @CHBName, CHBType = @CHBType, CHBDefault = @CHBDefault, CHBIsBorder = @CHBIsBorder, CHBIsTransparent = @CHBIsTransparent, CHBLeft = @CHBLeft, CHBTop = @CHBTop, CHBWidth = @CHBWidth, CHBHeight = @CHBHeight, CHBTabKey = @CHBTabKey, CHBIsReadOnly = @CHBIsReadOnly, CHBVisiable = @CHBVisiable, CHBIsMust = @CHBIsMust, CHBIsPrint = @CHBIsPrint, CHBIsEnable = @CHBIsEnable, CHBBandsTabel = @CHBBandsTabel, CHBBandsCoumln = @CHBBandsCoumln, CHBTIID = @CHBTIID, CHBFont = @CHBFont, CHBFontColor = @CHBFontColor, CHBBorerColor = @CHBBorerColor, CHBBackColor = @CHBBackColor  WHERE CHBID =  @CHBID";
            SqlParameter[] paras = new SqlParameter[]
            {
                new SqlParameter("@CHBID",checkBoxInfo.CHBID),
                new SqlParameter("@CHBName",checkBoxInfo.CHBName),
                new SqlParameter("@CHBType",checkBoxInfo.CHBType),
                new SqlParameter("@CHBDefault",checkBoxInfo.CHBDefault),
                new SqlParameter("@CHBIsBorder",checkBoxInfo.CHBIsBorder),
                new SqlParameter("@CHBIsTransparent",checkBoxInfo.CHBIsTransparent),
                new SqlParameter("@CHBLeft",checkBoxInfo.CHBLeft),
                new SqlParameter("@CHBTop",checkBoxInfo.CHBTop),
                new SqlParameter("@CHBWidth",checkBoxInfo.CHBWidth),
                new SqlParameter("@CHBHeight",checkBoxInfo.CHBHeight),
                new SqlParameter("@CHBTabKey",checkBoxInfo.CHBTabKey),
                new SqlParameter("@CHBIsReadOnly",checkBoxInfo.CHBIsReadOnly),
                new SqlParameter("@CHBVisiable",checkBoxInfo.CHBVisiable),
                new SqlParameter("@CHBIsMust",checkBoxInfo.CHBIsMust),
                new SqlParameter("@CHBIsPrint",checkBoxInfo.CHBIsPrint),
                new SqlParameter("@CHBIsEnable",checkBoxInfo.CHBIsEnable),
                new SqlParameter("@CHBBandsTabel",checkBoxInfo.CHBBandsTabel),
                new SqlParameter("@CHBBandsCoumln",checkBoxInfo.CHBBandsCoumln),
                new SqlParameter("@CHBTIID",checkBoxInfo.CHBTIID),
                new SqlParameter("@CHBFont",checkBoxInfo.CHBFont),
                new SqlParameter("@CHBFontColor",checkBoxInfo.CHBFontColor),
                new SqlParameter("@CHBBorerColor",checkBoxInfo.CHBBorerColor),
                new SqlParameter("@CHBBackColor",checkBoxInfo.CHBBackColor)
            };
            return (int)DBHelper.Execute(cmdText, paras);
        }
     
     
        /// <summary>
        /// 查询CheckBoxInfo
        /// </summary>
        /// <param name="cmdText">sql命令</param>
        public static IList<CheckBoxInfo> SelectCheckBoxInfoByCmdText(String cmdText)
        {
            IList<CheckBoxInfo> checkBoxInfos = new List<CheckBoxInfo>();
            using (SqlDataReader sdr = (SqlDataReader)DBHelper.Execute(cmdText))
            {
                while (sdr.Read())
                {
                    CheckBoxInfo checkBoxInfo = new CheckBoxInfo();
                    checkBoxInfo.CHBID = (Convert.ToInt32(sdr[0]));
                    checkBoxInfo.CHBName = (Convert.ToString(sdr[1]));
                    checkBoxInfo.CHBType = (Convert.ToString(sdr[2]));
                    checkBoxInfo.CHBDefault = (Convert.ToString(sdr[3]));
                    checkBoxInfo.CHBIsBorder = (Convert.ToByte(sdr[4]));
                    checkBoxInfo.CHBIsTransparent = (Convert.ToByte(sdr[5]));
                    checkBoxInfo.CHBLeft = (Convert.ToInt32(sdr[6]));
                    checkBoxInfo.CHBTop = (Convert.ToInt32(sdr[7]));
                    checkBoxInfo.CHBWidth = (Convert.ToInt32(sdr[8]));
                    checkBoxInfo.CHBHeight = (Convert.ToInt32(sdr[9]));
                    checkBoxInfo.CHBTabKey = (Convert.ToInt32(sdr[10]));
                    checkBoxInfo.CHBIsReadOnly = (Convert.ToByte(sdr[11]));
                    checkBoxInfo.CHBVisiable = (Convert.ToByte(sdr[12]));
                    checkBoxInfo.CHBIsMust = (Convert.ToByte(sdr[13]));
                    checkBoxInfo.CHBIsPrint = (Convert.ToByte(sdr[14]));
                    checkBoxInfo.CHBIsEnable = (Convert.ToByte(sdr[15]));
                    checkBoxInfo.CHBBandsTabel = (Convert.ToString(sdr[16]));
                    checkBoxInfo.CHBBandsCoumln = (Convert.ToString(sdr[17]));
                    checkBoxInfo.CHBTIID = (Convert.ToInt32(sdr[18]));
                    checkBoxInfo.CHBFont = (Convert.ToString(sdr[19]));
                    checkBoxInfo.CHBFontColor = (Convert.ToString(sdr[20]));
                    checkBoxInfo.CHBBorerColor = (Convert.ToString(sdr[21]));
                    checkBoxInfo.CHBBackColor = (Convert.ToString(sdr[22]));
                checkBoxInfos.Add(checkBoxInfo);
                }
            }
            return checkBoxInfos;
        }
     
     
        /// <summary>
        /// 根据CHBID查询CheckBoxInfo
        /// </summary>
        /// <param name=" _cHBID">属性值</param>
        public static CheckBoxInfo SelectCheckBoxInfoByCHBID(Int32  _cHBID)
        {
            string cmdText="SELECT * FROM CheckBoxInfo WHERE  CHBID = " +  _cHBID;
            IList<CheckBoxInfo> checkBoxInfos = SelectCheckBoxInfoByCmdText(cmdText);
            return checkBoxInfos.Count>0 ? checkBoxInfos[0] : null;
        }
     
     
        /// <summary>
        /// 查询所有CheckBoxInfo
        /// </summary>
        public static IList<CheckBoxInfo> SelectAllCheckBoxInfo()
        {
            string cmdText="SELECT * FROM CheckBoxInfo";
            return SelectCheckBoxInfoByCmdText(cmdText);
        }
      
    }
}
