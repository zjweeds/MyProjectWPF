using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Controllers.Models;
using Controllers.DataAccess.SQLHELPER;

namespace Controllers.DataAccess
{
    public class MoneyPanelExtenService
    {
        MySqlHelper sqlhelper = new MySqlHelper();
       
        /// <summary>
        /// 跟据
        /// </summary>
        /// <param name="ciid"></param>
        /// <returns></returns>
        public MoneyPanelExtendModel GetMoneyPanelExtendModelByCIID(int ciid)
        {
            try
            {
                MoneyPanelExtendModel mpem = new MoneyPanelExtendModel();
                StringBuilder sbsql = new StringBuilder();
                sbsql.Append(" select MCID,MCCIID,MCHeight,MCShowUnit,MCHighUnit,MCLowUnit,MCBindsID ");
                sbsql.Append(" from MoneyControl with(nolock) ");
                sbsql.Append(" where 1=1 ");
                sbsql.Append("       and MCIsEnable = 1");
                sbsql.AppendFormat(" and MCCIID = '{0}'", ciid);
                DataTable dt = sqlhelper.GetDataTable(sbsql.ToString());
                if (dt != null && dt.Rows.Count > 0)
                {
                    mpem.MCID = Convert.ToInt32(dt.Rows[0]["MCID"]);
                    mpem.MCCIID = Convert.ToInt32(dt.Rows[0]["MCCIID"]);
                    mpem.MCHeight = Convert.ToInt32(dt.Rows[0]["MCHeight"]);
                    mpem.MCShowUnit = Convert.ToInt32(dt.Rows[0]["MCShowUnit"]) != 0 ? true : false;
                    mpem.MCHighUnit = Convert.ToInt32(dt.Rows[0]["MCHighUnit"]);
                    mpem.MCLowUnit = Convert.ToInt32(dt.Rows[0]["MCLowUnit"]);
                    mpem.MCBindsID = Convert.ToInt32(dt.Rows[0]["MCBindsID"]);
                }
                return mpem;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public bool AddByTMoneyPanelExtendModel(MoneyPanelExtendModel mpem, int CIID)
        {
            try
            {
                int x = 0;
                if (mpem != null)
                {
                    StringBuilder sbsql = new StringBuilder();
                    sbsql.Append(" insert into MoneyControl ( ");
                    sbsql.Append("                            MCCIID,MCHeight,MCShowUnit,MCHighUnit,MCLowUnit,MCBindsID，MCIsEnable");
                    sbsql.Append("                         )");
                    sbsql.Append("                     vaules ( ");
                    sbsql.AppendFormat("                        '{0}'", mpem.MCCIID);
                    sbsql.AppendFormat("                        '{0}'", mpem.MCHeight);
                    sbsql.AppendFormat("                        '{0}'", mpem.MCShowUnit);
                    sbsql.AppendFormat("                        '{0}'", mpem.MCHighUnit);
                    sbsql.AppendFormat("                        '{0}'", mpem.MCLowUnit);
                    sbsql.AppendFormat("                        '{0}'", mpem.MCBindsID);
                    sbsql.Append("                        '1' )");
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
