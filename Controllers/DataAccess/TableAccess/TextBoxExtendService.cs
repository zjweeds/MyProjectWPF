using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Controllers.DataAccess.SQLHELPER;
using Controllers.Models;

namespace Controllers.DataAccess
{
    public class TextBoxExtendService
    {
        MySqlHelper sqlhelper = new MySqlHelper();
        
        /// <summary>
        /// 跟据控件ID，获得扩展信息
        /// </summary>
        /// <param name="ciid"></param>
        /// <returns></returns>
        public TextBoxExtendModel GetModelByContorlID(int ciid)
        {
            try
            {
                StringBuilder sbsql = new StringBuilder();
                sbsql.Append(" select TCID,TCCIID,TCIsFlage,TCShowType,TCMarkType ");
                sbsql.Append(" from TextControl ");
                sbsql.Append(" where 1=1 ");
                sbsql.Append("       and TCIsEnable = 1 ");
                sbsql.AppendFormat(" and TCCIID = '{0}' ", ciid);
                DataTable dt = sqlhelper.GetDataTable(sbsql.ToString());
                if (dt != null && dt.Rows.Count > 0)
                {
                    TextBoxExtendModel tem = new TextBoxExtendModel();
                    tem.TCID = Convert.ToInt32(dt.Rows[0]["TCID"]);
                    tem.TCCIID = Convert.ToInt32(dt.Rows[0]["TCCIID"]);
                    tem.TCIsFlage = Convert.ToInt32(dt.Rows[0]["TCIsFlage"]) != 0 ? true : false;
                    tem.TCShowType = Convert.ToInt32(dt.Rows[0]["TCShowType"]);
                    tem.TCMarkType = Convert.ToInt32(dt.Rows[0]["TCMarkType"]);
                    return tem;
                }
                else
                {
                    return null;
                }
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// 根据实体更新文本框拓展表
        /// </summary>
        /// <param name="tem"></param>
        /// <returns></returns>
        public bool UpdateByTextBoxExtendModel(TextBoxExtendModel tem)
        {
            try
            {
                int x = 0;
                if (tem != null)
                {
                    if (tem.updateFlage)
                    {
                        StringBuilder sbsql = new StringBuilder();
                        sbsql.Append(" Update TextControl Set ");
                        sbsql.AppendFormat("                  TCIsFlage = '{0}',", tem.TCIsFlage);
                        sbsql.AppendFormat("                  TCShowType = '{0}',", tem.TCShowType);
                        sbsql.AppendFormat("                  TCMarkType= '{0}',", tem.TCMarkType);
                        sbsql.AppendFormat(" where 1=1 and TCCIID = '{0}' and TCIsEnable = 1 ", tem.TCCIID);
                        x = sqlhelper.ExecDataBySql(sbsql.ToString());
                    }
                    else
                    {
                        x = 1;//无需更新
                    }
                }
                if (x > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        /// <summary>
        /// 跟据实体和控件ID 新增文本框拓展信息
        /// </summary>
        /// <param name="tem"></param>
        /// <param name="CIID"></param>
        /// <returns></returns>
        public bool AddByTextBoxExtendModel(TextBoxExtendModel tem,int CIID)
        {
            try
            {
                int x = 0;
                if (tem != null)
                {
                    StringBuilder sbsql = new StringBuilder();
                    sbsql.Append(" insert into TextControl (TCCIID,TCIsFlage,TCShowType,TCMarkType,TCIsEnable) ");
                    sbsql.Append("                     vaules ( ");
                    sbsql.AppendFormat("                        '{0}'", CIID);
                    sbsql.AppendFormat("                        '{0}'", tem.TCIsFlage);
                    sbsql.AppendFormat("                        '{0}'", tem.TCShowType);
                    sbsql.AppendFormat("                        '{0}'", tem.TCMarkType);
                    sbsql.Append("                        '1' ) ");
                    x = sqlhelper.ExecDataBySql(sbsql.ToString());
                }
                if (x > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
