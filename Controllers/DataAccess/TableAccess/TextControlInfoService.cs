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
    public class TextControlInfoService
    {
        /// <summary>
        /// 添加一个TextControlInfo
        /// </summary>
        /// <param name="textControlInfo">对象实例</param>
        public static int AddTextControlInfo(TextControlInfo textControlInfo)
        {
            string cmdText="INSERT INTO TextControlInfo ( TCName,TCDefault,TCIsBorder,TCIsTransparent,TCLeft,TCTop,TCWidth,TCHeight,TCTabKey,TCIsReadOnly,TCVisiable,TCIsMust,TCIsPrint,TCIsEnable,TCBandsTabel,TCBandsCoumln,TCTIID,TCFont,TCFontColor,TCBorerColor,TCBackColor,TCIsFlage,TCShowType,TCMarkType ) VALUES(@TCName,@TCDefault,@TCIsBorder,@TCIsTransparent,@TCLeft,@TCTop,@TCWidth,@TCHeight,@TCTabKey,@TCIsReadOnly,@TCVisiable,@TCIsMust,@TCIsPrint,@TCIsEnable,@TCBandsTabel,@TCBandsCoumln,@TCTIID,@TCFont,@TCFontColor,@TCBorerColor,@TCBackColor,@TCIsFlage,@TCShowType,@TCMarkType)";
            SqlParameter[] paras = new SqlParameter[]
            {
                new SqlParameter("@TCID",textControlInfo.TCID),
                new SqlParameter("@TCName",textControlInfo.TCName),
                new SqlParameter("@TCDefault",textControlInfo.TCDefault),
                new SqlParameter("@TCIsBorder",textControlInfo.TCIsBorder),
                new SqlParameter("@TCIsTransparent",textControlInfo.TCIsTransparent),
                new SqlParameter("@TCLeft",textControlInfo.TCLeft),
                new SqlParameter("@TCTop",textControlInfo.TCTop),
                new SqlParameter("@TCWidth",textControlInfo.TCWidth),
                new SqlParameter("@TCHeight",textControlInfo.TCHeight),
                new SqlParameter("@TCTabKey",textControlInfo.TCTabKey),
                new SqlParameter("@TCIsReadOnly",textControlInfo.TCIsReadOnly),
                new SqlParameter("@TCVisiable",textControlInfo.TCVisiable),
                new SqlParameter("@TCIsMust",textControlInfo.TCIsMust),
                new SqlParameter("@TCIsPrint",textControlInfo.TCIsPrint),
                new SqlParameter("@TCIsEnable",textControlInfo.TCIsEnable),
                new SqlParameter("@TCBandsTabel",textControlInfo.TCBandsTabel),
                new SqlParameter("@TCBandsCoumln",textControlInfo.TCBandsCoumln),
                new SqlParameter("@TCTIID",textControlInfo.TCTIID),
                new SqlParameter("@TCFont",textControlInfo.TCFont),
                new SqlParameter("@TCFontColor",textControlInfo.TCFontColor),
                new SqlParameter("@TCBorerColor",textControlInfo.TCBorerColor),
                new SqlParameter("@TCBackColor",textControlInfo.TCBackColor),
                new SqlParameter("@TCIsFlage",textControlInfo.TCIsFlage),
                new SqlParameter("@TCShowType",textControlInfo.TCShowType),
                new SqlParameter("@TCMarkType",textControlInfo.TCMarkType)
            };
            return (int)DBHelper.Execute(cmdText, paras);
        }
     
     
        /// <summary>
        /// 根据TCID删除TextControlInfo
        /// </summary>
        /// <param name="TCID">对象属性</param>
        public static int DeleteTextControlInfoByTCID(Int32  _tCID)
        {
            string cmdText="DELETE TextControlInfo WHERE  TCID = " +  _tCID;
            return (int)DBHelper.Execute(cmdText);
        }
     
     
        /// <summary>
        /// 更新TextControlInfo
        /// </summary>
        /// <param name="textControlInfo">新的对象实例</param>
        public static int UpdateTextControlInfo(TextControlInfo textControlInfo)
        {
            string cmdText="UPDATE TextControlInfo SET  TCName = @TCName, TCDefault = @TCDefault, TCIsBorder = @TCIsBorder, TCIsTransparent = @TCIsTransparent, TCLeft = @TCLeft, TCTop = @TCTop, TCWidth = @TCWidth, TCHeight = @TCHeight, TCTabKey = @TCTabKey, TCIsReadOnly = @TCIsReadOnly, TCVisiable = @TCVisiable, TCIsMust = @TCIsMust, TCIsPrint = @TCIsPrint, TCIsEnable = @TCIsEnable, TCBandsTabel = @TCBandsTabel, TCBandsCoumln = @TCBandsCoumln, TCTIID = @TCTIID, TCFont = @TCFont, TCFontColor = @TCFontColor, TCBorerColor = @TCBorerColor, TCBackColor = @TCBackColor, TCIsFlage = @TCIsFlage, TCShowType = @TCShowType, TCMarkType = @TCMarkType  WHERE TCID =  @TCID";
            SqlParameter[] paras = new SqlParameter[]
            {
                new SqlParameter("@TCID",textControlInfo.TCID),
                new SqlParameter("@TCName",textControlInfo.TCName),
                new SqlParameter("@TCDefault",textControlInfo.TCDefault),
                new SqlParameter("@TCIsBorder",textControlInfo.TCIsBorder),
                new SqlParameter("@TCIsTransparent",textControlInfo.TCIsTransparent),
                new SqlParameter("@TCLeft",textControlInfo.TCLeft),
                new SqlParameter("@TCTop",textControlInfo.TCTop),
                new SqlParameter("@TCWidth",textControlInfo.TCWidth),
                new SqlParameter("@TCHeight",textControlInfo.TCHeight),
                new SqlParameter("@TCTabKey",textControlInfo.TCTabKey),
                new SqlParameter("@TCIsReadOnly",textControlInfo.TCIsReadOnly),
                new SqlParameter("@TCVisiable",textControlInfo.TCVisiable),
                new SqlParameter("@TCIsMust",textControlInfo.TCIsMust),
                new SqlParameter("@TCIsPrint",textControlInfo.TCIsPrint),
                new SqlParameter("@TCIsEnable",textControlInfo.TCIsEnable),
                new SqlParameter("@TCBandsTabel",textControlInfo.TCBandsTabel),
                new SqlParameter("@TCBandsCoumln",textControlInfo.TCBandsCoumln),
                new SqlParameter("@TCTIID",textControlInfo.TCTIID),
                new SqlParameter("@TCFont",textControlInfo.TCFont),
                new SqlParameter("@TCFontColor",textControlInfo.TCFontColor),
                new SqlParameter("@TCBorerColor",textControlInfo.TCBorerColor),
                new SqlParameter("@TCBackColor",textControlInfo.TCBackColor),
                new SqlParameter("@TCIsFlage",textControlInfo.TCIsFlage),
                new SqlParameter("@TCShowType",textControlInfo.TCShowType),
                new SqlParameter("@TCMarkType",textControlInfo.TCMarkType)
            };
            return (int)DBHelper.Execute(cmdText, paras);
        }
     
     
        /// <summary>
        /// 查询TextControlInfo
        /// </summary>
        /// <param name="cmdText">sql命令</param>
        public static IList<TextControlInfo> SelectTextControlInfoByCmdText(String cmdText)
        {
            IList<TextControlInfo> textControlInfos = new List<TextControlInfo>();
            using (SqlDataReader sdr = (SqlDataReader)DBHelper.Execute(cmdText))
            {
                while (sdr.Read())
                {
                    TextControlInfo textControlInfo = new TextControlInfo();
                    textControlInfo.TCID = (Convert.ToInt32(sdr[0]));
                    textControlInfo.TCName = (Convert.ToString(sdr[1]));
                    textControlInfo.TCDefault = (Convert.ToString(sdr[2]));
                    textControlInfo.TCIsBorder = (Convert.ToByte(sdr[3]));
                    textControlInfo.TCIsTransparent = (Convert.ToByte(sdr[4]));
                    textControlInfo.TCLeft = (Convert.ToInt32(sdr[5]));
                    textControlInfo.TCTop = (Convert.ToInt32(sdr[6]));
                    textControlInfo.TCWidth = (Convert.ToInt32(sdr[7]));
                    textControlInfo.TCHeight = (Convert.ToInt32(sdr[8]));
                    textControlInfo.TCTabKey = (Convert.ToInt32(sdr[9]));
                    textControlInfo.TCIsReadOnly = (Convert.ToByte(sdr[10]));
                    textControlInfo.TCVisiable = (Convert.ToByte(sdr[11]));
                    textControlInfo.TCIsMust = (Convert.ToByte(sdr[12]));
                    textControlInfo.TCIsPrint = (Convert.ToByte(sdr[13]));
                    textControlInfo.TCIsEnable = (Convert.ToByte(sdr[14]));
                    textControlInfo.TCBandsTabel = (Convert.ToString(sdr[15]));
                    textControlInfo.TCBandsCoumln = (Convert.ToString(sdr[16]));
                    textControlInfo.TCTIID = (Convert.ToInt32(sdr[17]));
                    textControlInfo.TCFont = (Convert.ToString(sdr[18]));
                    textControlInfo.TCFontColor = (Convert.ToString(sdr[19]));
                    textControlInfo.TCBorerColor = (Convert.ToString(sdr[20]));
                    textControlInfo.TCBackColor = (Convert.ToString(sdr[21]));
                    textControlInfo.TCIsFlage = (Convert.ToByte(sdr[22]));
                    textControlInfo.TCShowType = (Convert.ToByte(sdr[23]));
                    textControlInfo.TCMarkType = (Convert.ToByte(sdr[24]));
                textControlInfos.Add(textControlInfo);
                }
            }
            return textControlInfos;
        }
     
     
        /// <summary>
        /// 根据TCID查询TextControlInfo
        /// </summary>
        /// <param name=" _tCID">属性值</param>
        public static TextControlInfo SelectTextControlInfoByTCID(Int32  _tCID)
        {
            string cmdText="SELECT * FROM TextControlInfo WHERE  TCID = " +  _tCID;
            IList<TextControlInfo> textControlInfos = SelectTextControlInfoByCmdText(cmdText);
            return textControlInfos.Count>0 ? textControlInfos[0] : null;
        }
     
     
        /// <summary>
        /// 查询所有TextControlInfo
        /// </summary>
        public static IList<TextControlInfo> SelectAllTextControlInfo()
        {
            string cmdText="SELECT * FROM TextControlInfo";
            return SelectTextControlInfoByCmdText(cmdText);
        }
      
    }
}
