/******************************************************************
 * 创 建 人：  赵建
 * 创建时间：  2013-11-16 9:59
 * 描    述：
 *             模板信息数据访问层
 * 版    本：  V1.0      
 * 环    境：  VS2013
******************************************************************/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Controllers.Models;
using Controllers.DataAccess.SQLHELPER;
using System.Data;
using System.Data.SqlClient;
namespace Controllers.DataAccess
{   
    public class BillTemplateService
    {
        /// <summary>
        /// 根据实体添加模板
        /// </summary>
        /// <param name="btm"></param>
        /// <returns></returns>
        public static int AddByBillTemplatModel(BillTemplatModel btm)
        {
            try
            {
                StringBuilder sbSql = new StringBuilder();
                sbSql.Append("insert into TemplateInfo (TIName,TIBackground,TIWidth,TIHeight,TITTID,TICodeLegth,TIIsPrintBg) ");
                sbSql.Append("                 values (@TIName,@TIBackground,@TIWidth,@TIHeight,@TITTID,@TICodeLegth,@TIIsPrintBg) ");
                sbSql.Append(" Select @@Identity ");
                SqlParameter[] param = new SqlParameter[7];
                param[0] = new SqlParameter("@TIName", SqlDbType.NVarChar, 30);
                param[0].Value = btm.TIName; ;
                param[1] = new SqlParameter("@TIBackground ", SqlDbType.Image);
                param[1].Value = btm.TIBackground;
                param[2] = new SqlParameter("@TIWidth ", SqlDbType.Int);
                param[2].Value = btm.TIWidth;
                param[3] = new SqlParameter("@TIHeight ", SqlDbType.Int);
                param[3].Value = btm.TIHeight;
                param[4] = new SqlParameter("@TITTID ", SqlDbType.Int);
                param[4].Value =btm.TITTID;
                param[5] = new SqlParameter("@TICodeLegth ", SqlDbType.Int);
                param[5].Value = btm.TICodeLegth;
                param[6] = new SqlParameter("@TIIsPrintBg ", SqlDbType.Int);
                param[6].Value = btm.TIIsPrintBg;
                return new MySqlHelper().ExecSqlReturnId(sbSql.ToString(), param);
            }
            catch (Exception ex)
            {
                throw ex;
            }
         }

        /// <summary>
        /// 根据datatable添加信息
        /// </summary>
        /// <param name="dt"></param>
        /// <param name="simagebyte"></param>
        /// <returns></returns>
        public static int AddByDataTable(DataTable dt,byte[] simagebyte)
        {
           // BillTemplatModel btm =new BillTemplatModel()
            try
            {
                StringBuilder sbSql = new StringBuilder();
                sbSql.Append("insert into TemplateInfo (TIName,TIBackground,TIWidth,TIHeight,TITTID,TICodeLegth,TIIsPrintBg) ");
                sbSql.Append("                 values (@TIName,@TIBackground,@TIWidth,@TIHeight,@TITTID,@TICodeLegth,@TIIsPrintBg) ");
                sbSql.Append(" Select @@Identity ");
                SqlParameter[] param = new SqlParameter[7];
                param[0] = new SqlParameter("@TIName", SqlDbType.NVarChar, 30);
                param[0].Value = dt.Rows[0]["TIName"].ToString();
                param[1] = new SqlParameter("@TIBackground ", SqlDbType.Image);
                param[1].Value = simagebyte;
                param[2] = new SqlParameter("@TIWidth ", SqlDbType.Int);
                param[2].Value = Convert.ToInt32(dt.Rows[0]["TIWidth"].ToString());
                param[3] = new SqlParameter("@TIHeight ", SqlDbType.Int);
                param[3].Value = Convert.ToInt32(dt.Rows[0]["TIHeight"].ToString());
                param[4] = new SqlParameter("@TITTID ", SqlDbType.Int);
                param[4].Value = Convert.ToInt32(dt.Rows[0]["TITTID"].ToString());
                param[5] = new SqlParameter("@TICodeLegth ", SqlDbType.Int);
                param[5].Value = Convert.ToInt32(dt.Rows[0]["TICodeLegth"].ToString());
                param[6] = new SqlParameter("@TIIsPrintBg ", SqlDbType.Int);
                param[6].Value = Convert.ToInt32(dt.Rows[0]["TIIsPrintBg"].ToString());
                return new MySqlHelper().ExecSqlReturnId(sbSql.ToString(), param);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// 根据实体更新模板
        /// </summary>
        /// <param name="btm"></param>
        /// <returns></returns>
        public  static int UpdateByBillTemplatModel(BillTemplatModel btm)
        {
            try
            {
                StringBuilder sbSql = new StringBuilder();
                sbSql.Append("update TemplateInfo set ");
                sbSql.Append("     TIName =@TIName ");
                sbSql.Append("     ,TIBackground =@TIBackground ");
                sbSql.Append("     ,TIWidth =@TIWidth ");
                sbSql.Append("     ,TIHeight =@TIHeight ");
                sbSql.Append("     ,TITTID =@TITTID ");
                sbSql.Append("     ,TICodeLegth =@TICodeLegth ");
                sbSql.Append("     ,TIIsPrintBg =@TIIsPrintBg ");
                sbSql.Append(" where TIID=@TIID " );
                SqlParameter[] param = new SqlParameter[8];
                param[0] = new SqlParameter("@TIName", SqlDbType.NVarChar, 30);
                param[0].Value = btm.TIName; ;
                param[1] = new SqlParameter("@TIBackground ", SqlDbType.Image);
                param[1].Value = btm.TIBackground;
                param[2] = new SqlParameter("@TIWidth ", SqlDbType.Int);
                param[2].Value = btm.TIWidth;
                param[3] = new SqlParameter("@TIHeight ", SqlDbType.Int);
                param[3].Value = btm.TIHeight;
                param[4] = new SqlParameter("@TITTID ", SqlDbType.Int);
                param[4].Value = btm.TITTID;
                param[5] = new SqlParameter("@TICodeLegth ", SqlDbType.Int);
                param[5].Value = btm.TICodeLegth;
                param[6] = new SqlParameter("@TIIsPrintBg ", SqlDbType.Int);
                param[6].Value = btm.TIIsPrintBg;
                param[7] = new SqlParameter("@TIID ", SqlDbType.Int);
                param[7].Value = btm.TIID;
                return new MySqlHelper().ExecDataBySql(sbSql.ToString(), param);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// 根据
        /// </summary>
        /// <param name="tiid"></param>
        /// <returns></returns>
        public static int DeleteByID(Int32 tiid)
        {
            try
            {
                StringBuilder sbSql = new StringBuilder();
                sbSql.Append("update TemplateInfo set TIIsEnable ='0' ");
                sbSql.AppendFormat(" where TIID='{0}' ", tiid);               
                return new MySqlHelper().ExecDataBySql(sbSql.ToString());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// 根据模板编号返回datatable
        /// </summary>
        /// <param name="billTemplateID"></param>
        /// <returns></returns>
        public static DataTable GetDataTableByID(int billTemplateID)
        {
            StringBuilder sbsql = new StringBuilder();
            sbsql.Append(" select TIID,TIName,TIBackground,TIWidth,TIHeight,TITTID,TICodeLegth,TIIsPrintBg ");
            sbsql.Append(" from TemplateInfo with(nolock) ");
            sbsql.Append(" where 1=1 ");
            sbsql.AppendFormat("       and TIID ='{0}' ", billTemplateID);
            sbsql.Append("       and TIIsEnable = 1");
            return new MySqlHelper().GetDataTable(sbsql.ToString());
        }

        /// <summary>
        /// 根据datatable返回模板实体
        /// </summary>
        /// <param name="billTemplateID"></param>
        /// <returns></returns>
        public static List<BillTemplatModel> GetTemplateModerListByDataTable(DataTable dtitem)
        {
            try
            {
                List<BillTemplatModel> btmlist = new List<BillTemplatModel>();
                //DataTable dtitem = SelectDataTableByID(billTemplateID);
                if (dtitem != null && dtitem.Rows.Count > 0)
                {
                    for (int i = 0; i < dtitem.Rows.Count; i++)
                    {
                        BillTemplatModel btm = new BillTemplatModel();
                        btm.TIID = Convert.ToInt32(dtitem.Rows[i][0]);
                        btm.TIName = Convert.ToString(dtitem.Rows[i][1]);
                        btm.TIBackground = dtitem.Rows[i][2] as byte[];
                        btm.TIWidth = Convert.ToInt32(dtitem.Rows[i][3]);
                        btm.TIHeight = Convert.ToInt32(dtitem.Rows[i][4]);
                        btm.TITTID = Convert.ToInt32(dtitem.Rows[i][5]);
                        btm.TICodeLegth = Convert.ToInt32(dtitem.Rows[i][6]);
                        btm.TIIsPrintBg = Convert.ToInt32(dtitem.Rows[i][7]);
                        btmlist.Add(btm);
                    }
                    return btmlist;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// 根据模板编号返回模板实体
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        public static BillTemplatModel GetTemplateModeltByID(int code)
        {
            DataTable dt = GetDataTableByID(code);
            BillTemplatModel btm = new BillTemplatModel();
            if (dt != null && dt.Rows.Count > 0)
            {
                btm.TIID = Convert.ToInt32(dt.Rows[0]["TIID"]);
                btm.TIName = Convert.ToString(dt.Rows[0]["TIName"]);
                btm.TIBackground = dt.Rows[0]["TIBackground"] as byte[];
                btm.TIWidth = Convert.ToInt32(dt.Rows[0]["TIWidth"]);
                btm.TIHeight = Convert.ToInt32(dt.Rows[0]["TIHeight"]);
                btm.TITTID = Convert.ToInt32(dt.Rows[0]["TITTID"]);
                btm.TICodeLegth = Convert.ToInt32(dt.Rows[0]["TICodeLegth"]);
                btm.TIIsPrintBg = Convert.ToInt32(dt.Rows[0]["TIIsPrintBg"]);

            }
            return btm;
        }

        /// <summary>
        /// 根据类别名称返回模板信息
        /// </summary>
        /// <param name="sTemplateName"></param>
        /// <returns></returns>
        public static DataTable GetDataTableByTypeName(String sTemplateName)
        {
            StringBuilder sbsql = new StringBuilder();
            sbsql.Append(" select TIID,TIName,TIBackground,TIWidth,TIHeight,TITTID,TICodeLegth,TIIsPrintBg ");
            sbsql.Append(" from TemplateInfo with(nolock) ");
            sbsql.Append("  join TemplateType with(nolock) ");
            sbsql.Append("     on TemplateType.TTID = TemplateInfo.TITTID ");
            sbsql.Append(" where 1=1 ");
            sbsql.Append("       and TTIsEnable = 1 ");
            sbsql.Append("       and TIIsEnable = 1 ");
            sbsql.AppendFormat(" and TTName = '{0}' ", sTemplateName);
            return new MySqlHelper().GetDataTable(sbsql.ToString());
        }

        /// <summary>
        /// 根据账套ID取模板信息
        /// </summary>
        /// <param name="bsName"></param>
        /// <returns></returns>
        public static DataTable GetTemplatBagroundByBSName(String bsName)
        {
            StringBuilder cmdText = new StringBuilder();
            cmdText.Append("select TTName,TIID,TIBackground,TIName from TemplateInfo with(nolock) ");
            cmdText.Append(" join TemplateType with(nolock) on TTID = TITTID ");
            cmdText.Append(" join BillSetInfo  with(nolock) on BSIID = TTBillSetID ");
            cmdText.Append(" where TIIsEnable =1 and TTIsEnable = 1 and BSIIsEnable = 1");
            cmdText.AppendFormat(" and BSIName = '{0}'", bsName);
            return new MySqlHelper().GetDataTable(cmdText.ToString());
        }

    }
}
