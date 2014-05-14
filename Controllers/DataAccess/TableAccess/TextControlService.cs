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
    public class TextControlService
    {
        /// <summary>
        /// 添加一个TextControl
        /// </summary>
        /// <param name="textControl">对象实例</param>
        public static int AddTextControl(TextControl textControl)
        {
            string cmdText="INSERT INTO TextControl ( TCCIID,TCIsFlage,TCShowType,TCMarkType,TCIsEnable ) VALUES(@TCCIID,@TCIsFlage,@TCShowType,@TCMarkType,@TCIsEnable)";
            SqlParameter[] paras = new SqlParameter[]
            {
                new SqlParameter("@TCID",textControl.TCID),
                new SqlParameter("@TCCIID",textControl.TCCIID),
                new SqlParameter("@TCIsFlage",textControl.TCIsFlage),
                new SqlParameter("@TCShowType",textControl.TCShowType),
                new SqlParameter("@TCMarkType",textControl.TCMarkType),
                new SqlParameter("@TCIsEnable",textControl.TCIsEnable)
            };
            return (int)DBHelper.Execute(cmdText, paras);
        }
     
     
        /// <summary>
        /// 根据TCID删除TextControl
        /// </summary>
        /// <param name="TCID">对象属性</param>
        public static int DeleteTextControlByTCID(Int32  _tCID)
        {
            string cmdText="DELETE TextControl WHERE  TCID = " +  _tCID;
            return (int)DBHelper.Execute(cmdText);
        }
     
     
        /// <summary>
        /// 更新TextControl
        /// </summary>
        /// <param name="textControl">新的对象实例</param>
        public static int UpdateTextControl(TextControl textControl)
        {
            string cmdText="UPDATE TextControl SET  TCCIID = @TCCIID, TCIsFlage = @TCIsFlage, TCShowType = @TCShowType, TCMarkType = @TCMarkType, TCIsEnable = @TCIsEnable  WHERE TCID =  @TCID";
            SqlParameter[] paras = new SqlParameter[]
            {
                new SqlParameter("@TCID",textControl.TCID),
                new SqlParameter("@TCCIID",textControl.TCCIID),
                new SqlParameter("@TCIsFlage",textControl.TCIsFlage),
                new SqlParameter("@TCShowType",textControl.TCShowType),
                new SqlParameter("@TCMarkType",textControl.TCMarkType),
                new SqlParameter("@TCIsEnable",textControl.TCIsEnable)
            };
            return (int)DBHelper.Execute(cmdText, paras);
        }
     
     
        /// <summary>
        /// 查询TextControl
        /// </summary>
        /// <param name="cmdText">sql命令</param>
        public static IList<TextControl> SelectTextControlByCmdText(String cmdText)
        {
            IList<TextControl> textControls = new List<TextControl>();
            using (SqlDataReader sdr = (SqlDataReader)DBHelper.Execute(cmdText))
            {
                while (sdr.Read())
                {
                    TextControl textControl = new TextControl();
                    textControl.TCID = (Convert.ToInt32(sdr[0]));
                    textControl.TCCIID = (Convert.ToInt32(sdr[1]));
                    textControl.TCIsFlage = (Convert.ToBoolean(sdr[2]));
                    textControl.TCShowType = (Convert.ToByte(sdr[3]));
                    textControl.TCMarkType = (Convert.ToByte(sdr[4]));
                    textControl.TCIsEnable = (Convert.ToByte(sdr[5]));
                textControls.Add(textControl);
                }
            }
            return textControls;
        }
     
     
        /// <summary>
        /// 根据TCID查询TextControl
        /// </summary>
        /// <param name=" _tCID">属性值</param>
        public static TextControl SelectTextControlByTCID(Int32  _tCID)
        {
            string cmdText="SELECT * FROM TextControl WHERE  TCID = " +  _tCID;
            IList<TextControl> textControls = SelectTextControlByCmdText(cmdText);
            return textControls.Count>0 ? textControls[0] : null;
        }
     
     
        /// <summary>
        /// 查询所有TextControl
        /// </summary>
        public static IList<TextControl> SelectAllTextControl()
        {
            string cmdText="SELECT * FROM TextControl";
            return SelectTextControlByCmdText(cmdText);
        }
      
    }
}
