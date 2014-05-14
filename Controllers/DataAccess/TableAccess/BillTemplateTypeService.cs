using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Controllers.Models;
using Controllers.DataAccess.SQLHELPER;
using System.Data;

namespace Controllers.DataAccess
{
    public class BillTemplateTypeService
    {
        MySqlHelper sqlhelper = new MySqlHelper();
        
        /// <summary>
        /// 根据账套名称获得所有票夹信息
        /// </summary>
        /// <param name="BillSetName"></param>
        /// <returns></returns>
        public DataTable GetAllTypeByBillsetID(String BillSetName)
        {
            try
            {
                StringBuilder sb = new StringBuilder();
                sb.Append(" select TTID,TTName,TTIPageID ");
                sb.Append(" from TemplateType ");
                sb.Append(" join BillSetInfo ");
                sb.Append("      on BillSetInfo.BSIID = TemplateType.TTBillSetID ");
                sb.Append("where 1=1 and TemplateType.TTIsEnable=1 ");
                sb.Append("          and BillSetInfo.BSIIsEnable =1 ");
                sb.AppendFormat("    and BillSetInfo.BSIName = '{0}' ", BillSetName);
                return sqlhelper.GetDataTable(sb.ToString());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// 根据模板类别（票夹）名称 返回票夹ID
        /// </summary>
        /// <param name="TypeName"></param>
        /// <returns></returns>
        public int GetTemplateTypeIdByName(String TypeName)
        {
            String sql = "select TTID from TemplateType where TTName = '" + TypeName + "' and TTIsEnable = 1 ";
            object ob = sqlhelper.GetSingleObject(sql);
            if (ob != null)
            {
                return (int)ob;
            }
            else
            {
                return 0;
            }
        }

        /// <summary>
        /// 跟据编号查询出类型名称
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        public String GetTemplateTypeNameById(int code)
        {
            try
            {
                String sql = "select TTName from TemplateType where TTID = '" + code + "' and TTIsEnable = 1 ";
                object ob = sqlhelper.GetSingleObject(sql);
                if (ob != null)
                {
                    return (String)ob;
                }
                else
                {
                    return String.Empty;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// 跟据页面ID获取票夹ID
        /// </summary>
        /// <param name="pageID"></param>
        /// <returns></returns>
        public String GetTemplateTypeIDByPageID(int pageID)
        {
            String sql = "select TTID from TemplateType where TTIPageID = '" + pageID + "' and TTIsEnable = 1 ";
            object ob = sqlhelper.GetSingleObject(sql);
            if (ob != null)
            {
                return ob.ToString();
            }
            else
            {
                return "";
            }
        }
    }
}
