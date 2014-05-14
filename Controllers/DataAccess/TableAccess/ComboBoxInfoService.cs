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
    public class ComboBoxInfoService
    {
        /// <summary>
        /// 添加一个ComboBoxInfo
        /// </summary>
        /// <param name="comboBoxInfo">对象实例</param>
        public static int AddComboBoxInfo(ComboBoxInfo comboBoxInfo)
        {
            string cmdText="INSERT INTO ComboBoxInfo ( CBBName,CBBType,CBBDefault,CBBIsBorder,CBBIsTransparent,CBBILeft,CBBTop,CBBWidth,CBBHeight,CBBTabKey,CBBIsReadOnly,CBBVisiable,CBBIsMust,CBBIsPrint,CBBIsEnable,CBBBandsTabel,CBBBandsCoumln,CBBTIID,CBBFont,CBBFontColor,CBBBorerColor,CBBBackColor ) VALUES(@CBBName,@CBBType,@CBBDefault,@CBBIsBorder,@CBBIsTransparent,@CBBILeft,@CBBTop,@CBBWidth,@CBBHeight,@CBBTabKey,@CBBIsReadOnly,@CBBVisiable,@CBBIsMust,@CBBIsPrint,@CBBIsEnable,@CBBBandsTabel,@CBBBandsCoumln,@CBBTIID,@CBBFont,@CBBFontColor,@CBBBorerColor,@CBBBackColor)";
            SqlParameter[] paras = new SqlParameter[]
            {
                new SqlParameter("@CBBID",comboBoxInfo.CBBID),
                new SqlParameter("@CBBName",comboBoxInfo.CBBName),
                new SqlParameter("@CBBType",comboBoxInfo.CBBType),
                new SqlParameter("@CBBDefault",comboBoxInfo.CBBDefault),
                new SqlParameter("@CBBIsBorder",comboBoxInfo.CBBIsBorder),
                new SqlParameter("@CBBIsTransparent",comboBoxInfo.CBBIsTransparent),
                new SqlParameter("@CBBILeft",comboBoxInfo.CBBILeft),
                new SqlParameter("@CBBTop",comboBoxInfo.CBBTop),
                new SqlParameter("@CBBWidth",comboBoxInfo.CBBWidth),
                new SqlParameter("@CBBHeight",comboBoxInfo.CBBHeight),
                new SqlParameter("@CBBTabKey",comboBoxInfo.CBBTabKey),
                new SqlParameter("@CBBIsReadOnly",comboBoxInfo.CBBIsReadOnly),
                new SqlParameter("@CBBVisiable",comboBoxInfo.CBBVisiable),
                new SqlParameter("@CBBIsMust",comboBoxInfo.CBBIsMust),
                new SqlParameter("@CBBIsPrint",comboBoxInfo.CBBIsPrint),
                new SqlParameter("@CBBIsEnable",comboBoxInfo.CBBIsEnable),
                new SqlParameter("@CBBBandsTabel",comboBoxInfo.CBBBandsTabel),
                new SqlParameter("@CBBBandsCoumln",comboBoxInfo.CBBBandsCoumln),
                new SqlParameter("@CBBTIID",comboBoxInfo.CBBTIID),
                new SqlParameter("@CBBFont",comboBoxInfo.CBBFont),
                new SqlParameter("@CBBFontColor",comboBoxInfo.CBBFontColor),
                new SqlParameter("@CBBBorerColor",comboBoxInfo.CBBBorerColor),
                new SqlParameter("@CBBBackColor",comboBoxInfo.CBBBackColor)
            };
            return (int)DBHelper.Execute(cmdText, paras);
        }
     
     
        /// <summary>
        /// 根据CBBID删除ComboBoxInfo
        /// </summary>
        /// <param name="CBBID">对象属性</param>
        public static int DeleteComboBoxInfoByCBBID(Int32  _cBBID)
        {
            string cmdText="DELETE ComboBoxInfo WHERE  CBBID = " +  _cBBID;
            return (int)DBHelper.Execute(cmdText);
        }
     
     
        /// <summary>
        /// 更新ComboBoxInfo
        /// </summary>
        /// <param name="comboBoxInfo">新的对象实例</param>
        public static int UpdateComboBoxInfo(ComboBoxInfo comboBoxInfo)
        {
            string cmdText="UPDATE ComboBoxInfo SET  CBBName = @CBBName, CBBType = @CBBType, CBBDefault = @CBBDefault, CBBIsBorder = @CBBIsBorder, CBBIsTransparent = @CBBIsTransparent, CBBILeft = @CBBILeft, CBBTop = @CBBTop, CBBWidth = @CBBWidth, CBBHeight = @CBBHeight, CBBTabKey = @CBBTabKey, CBBIsReadOnly = @CBBIsReadOnly, CBBVisiable = @CBBVisiable, CBBIsMust = @CBBIsMust, CBBIsPrint = @CBBIsPrint, CBBIsEnable = @CBBIsEnable, CBBBandsTabel = @CBBBandsTabel, CBBBandsCoumln = @CBBBandsCoumln, CBBTIID = @CBBTIID, CBBFont = @CBBFont, CBBFontColor = @CBBFontColor, CBBBorerColor = @CBBBorerColor, CBBBackColor = @CBBBackColor  WHERE CBBID =  @CBBID";
            SqlParameter[] paras = new SqlParameter[]
            {
                new SqlParameter("@CBBID",comboBoxInfo.CBBID),
                new SqlParameter("@CBBName",comboBoxInfo.CBBName),
                new SqlParameter("@CBBType",comboBoxInfo.CBBType),
                new SqlParameter("@CBBDefault",comboBoxInfo.CBBDefault),
                new SqlParameter("@CBBIsBorder",comboBoxInfo.CBBIsBorder),
                new SqlParameter("@CBBIsTransparent",comboBoxInfo.CBBIsTransparent),
                new SqlParameter("@CBBILeft",comboBoxInfo.CBBILeft),
                new SqlParameter("@CBBTop",comboBoxInfo.CBBTop),
                new SqlParameter("@CBBWidth",comboBoxInfo.CBBWidth),
                new SqlParameter("@CBBHeight",comboBoxInfo.CBBHeight),
                new SqlParameter("@CBBTabKey",comboBoxInfo.CBBTabKey),
                new SqlParameter("@CBBIsReadOnly",comboBoxInfo.CBBIsReadOnly),
                new SqlParameter("@CBBVisiable",comboBoxInfo.CBBVisiable),
                new SqlParameter("@CBBIsMust",comboBoxInfo.CBBIsMust),
                new SqlParameter("@CBBIsPrint",comboBoxInfo.CBBIsPrint),
                new SqlParameter("@CBBIsEnable",comboBoxInfo.CBBIsEnable),
                new SqlParameter("@CBBBandsTabel",comboBoxInfo.CBBBandsTabel),
                new SqlParameter("@CBBBandsCoumln",comboBoxInfo.CBBBandsCoumln),
                new SqlParameter("@CBBTIID",comboBoxInfo.CBBTIID),
                new SqlParameter("@CBBFont",comboBoxInfo.CBBFont),
                new SqlParameter("@CBBFontColor",comboBoxInfo.CBBFontColor),
                new SqlParameter("@CBBBorerColor",comboBoxInfo.CBBBorerColor),
                new SqlParameter("@CBBBackColor",comboBoxInfo.CBBBackColor)
            };
            return (int)DBHelper.Execute(cmdText, paras);
        }
     
     
        /// <summary>
        /// 查询ComboBoxInfo
        /// </summary>
        /// <param name="cmdText">sql命令</param>
        public static IList<ComboBoxInfo> SelectComboBoxInfoByCmdText(String cmdText)
        {
            IList<ComboBoxInfo> comboBoxInfos = new List<ComboBoxInfo>();
            using (SqlDataReader sdr = (SqlDataReader)DBHelper.Execute(cmdText))
            {
                while (sdr.Read())
                {
                    ComboBoxInfo comboBoxInfo = new ComboBoxInfo();
                    comboBoxInfo.CBBID = (Convert.ToInt32(sdr[0]));
                    comboBoxInfo.CBBName = (Convert.ToString(sdr[1]));
                    comboBoxInfo.CBBType = (Convert.ToString(sdr[2]));
                    comboBoxInfo.CBBDefault = (Convert.ToString(sdr[3]));
                    comboBoxInfo.CBBIsBorder = (Convert.ToByte(sdr[4]));
                    comboBoxInfo.CBBIsTransparent = (Convert.ToByte(sdr[5]));
                    comboBoxInfo.CBBILeft = (Convert.ToInt32(sdr[6]));
                    comboBoxInfo.CBBTop = (Convert.ToInt32(sdr[7]));
                    comboBoxInfo.CBBWidth = (Convert.ToInt32(sdr[8]));
                    comboBoxInfo.CBBHeight = (Convert.ToInt32(sdr[9]));
                    comboBoxInfo.CBBTabKey = (Convert.ToInt32(sdr[10]));
                    comboBoxInfo.CBBIsReadOnly = (Convert.ToByte(sdr[11]));
                    comboBoxInfo.CBBVisiable = (Convert.ToByte(sdr[12]));
                    comboBoxInfo.CBBIsMust = (Convert.ToByte(sdr[13]));
                    comboBoxInfo.CBBIsPrint = (Convert.ToByte(sdr[14]));
                    comboBoxInfo.CBBIsEnable = (Convert.ToByte(sdr[15]));
                    comboBoxInfo.CBBBandsTabel = (Convert.ToString(sdr[16]));
                    comboBoxInfo.CBBBandsCoumln = (Convert.ToString(sdr[17]));
                    comboBoxInfo.CBBTIID = (Convert.ToInt32(sdr[18]));
                    comboBoxInfo.CBBFont = (Convert.ToString(sdr[19]));
                    comboBoxInfo.CBBFontColor = (Convert.ToString(sdr[20]));
                    comboBoxInfo.CBBBorerColor = (Convert.ToString(sdr[21]));
                    comboBoxInfo.CBBBackColor = (Convert.ToString(sdr[22]));
                comboBoxInfos.Add(comboBoxInfo);
                }
            }
            return comboBoxInfos;
        }
     
     
        /// <summary>
        /// 根据CBBID查询ComboBoxInfo
        /// </summary>
        /// <param name=" _cBBID">属性值</param>
        public static ComboBoxInfo SelectComboBoxInfoByCBBID(Int32  _cBBID)
        {
            string cmdText="SELECT * FROM ComboBoxInfo WHERE  CBBID = " +  _cBBID;
            IList<ComboBoxInfo> comboBoxInfos = SelectComboBoxInfoByCmdText(cmdText);
            return comboBoxInfos.Count>0 ? comboBoxInfos[0] : null;
        }
     
     
        /// <summary>
        /// 查询所有ComboBoxInfo
        /// </summary>
        public static IList<ComboBoxInfo> SelectAllComboBoxInfo()
        {
            string cmdText="SELECT * FROM ComboBoxInfo";
            return SelectComboBoxInfoByCmdText(cmdText);
        }
      
    }
}
