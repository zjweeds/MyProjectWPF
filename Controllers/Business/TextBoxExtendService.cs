using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Controllers.DataAccess.DAL;
using Controllers.Moders.TableModers;

namespace Controllers.Business
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
    }
}
