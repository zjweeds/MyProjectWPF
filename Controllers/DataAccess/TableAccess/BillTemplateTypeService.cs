/******************************************************************
 * 创 建 人：  赵建
 * 创建时间：  2013-11-16 9:59
 * 描    述：
 *             模板类别信息数据访问层
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
using System.Collections;

namespace Controllers.DataAccess
{
    public class BillTemplateTypeService
    {
        
        /// <summary>
        /// 根据账套名称获得所有票夹信息
        /// </summary>
        /// <param name="BillSetName"></param>
        /// <returns></returns>
        static public DataTable GetAllTypeByBillsetName(String BillSetName)
        {
            try
            {
                StringBuilder sb = new StringBuilder();
                sb.Append(" select TTID,TTName ");
                sb.Append(" from TemplateType ");
                sb.Append(" join BillSetInfo ");
                sb.Append("      on BillSetInfo.BSIID = TemplateType.TTBillSetID ");
                sb.Append("where 1=1 and TemplateType.TTIsEnable=1 ");
                sb.Append("          and BillSetInfo.BSIIsEnable =1 ");
                sb.AppendFormat("    and BillSetInfo.BSIName = '{0}' ", BillSetName);
                return new MySqlHelper().GetDataTable(sb.ToString());
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
       static public int GetTemplateTypeIdByName(String TypeName)
        {
            String sql = "select TTID from TemplateType where TTName = '" + TypeName + "' and TTIsEnable = 1 ";
            object ob = new MySqlHelper().GetSingleObject(sql);
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
        static public String GetTemplateTypeNameById(int code)
        {
            try
            {
                String sql = "select TTName from TemplateType where TTID = '" + code + "' and TTIsEnable = 1 ";
                object ob = new MySqlHelper().GetSingleObject(sql);
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
        /// 添加模板分类
        /// </summary>
        /// <param name="typeName">类别名</param>
        /// <param name="bsID">账套ID</param>
        /// <param name="userCode">添加人工号</param>
        /// <returns></returns>
        static public int AddTemplateType(String typeName,String bsName,String userCode)
        {
            StringBuilder scmd =new StringBuilder();
            scmd.Append("select BSIID from BillSetInfo  with(nolock) ");
            scmd.AppendFormat(" where BSIIsEnable = 1 and BSIName = '{0}'", bsName);
            int bsid = Convert.ToInt32(new MySqlHelper().GetSingleObject(scmd.ToString()));
            StringBuilder cmdText = new StringBuilder();
            cmdText.Append("insert into TemplateType (TTName,TTBillSetID,TTCreaterID) ");
            cmdText.AppendFormat("       values ('{0}','{1}','{2}')  ", typeName, bsid, userCode);
            cmdText.Append(" Select @@Identity ");
            return new MySqlHelper().ExecSqlReturnId(cmdText.ToString());
        }

        /// <summary>
        /// 更新类别名称
        /// </summary>
        /// <param name="typeNewName"></param>
        /// <param name="oldName"></param>
        /// <param name="bsName"></param>
        /// <returns></returns>
        static public int UpdateTemplateName(String typeNewName, String oldName, String bsName)
        {
            StringBuilder cmdText = new StringBuilder();
            cmdText.AppendFormat("update TemplateType set TTName = '{0}'  ", typeNewName);
            cmdText.Append("       where  exists ( ");
             cmdText.Append("                     select BSIID from BillSetInfo  with(nolock) ");
             cmdText.AppendFormat("                      where BSIIsEnable = 1 and BSIName = '{0}'",bsName);
             cmdText.Append("                        )");
             cmdText.AppendFormat("    and TTName = '{0}')  ", oldName);
            return new MySqlHelper().ExecDataBySql(cmdText.ToString());
        }

        /// <summary>
        /// 返回类别名称是否存在
        /// </summary>
        /// <param name="Name"></param>
        /// <returns> false 不存在：true 存在</returns>
        static public bool IsTypeNameExsit(String typeName,String bsName)
        {
            StringBuilder cmdText = new StringBuilder();
            cmdText.Append("select TTID From TemplateType with(nolock) ");
            cmdText.Append(" join BillSetInfo  with(nolock)  on BSIID=TTBillSetID ");
            cmdText.AppendFormat("where TTIsEnable = 1 and TTName='{0}' and  BSIName = '{1}' ", typeName, bsName);
            return new MySqlHelper().GetSingleObject(cmdText.ToString()) == null ? false : true;         
        }


        /// <summary>
        /// 删除（废弃）
        /// </summary>
        /// <returns></returns>
        static public bool DeleteTemplateTypeByName()
        {
            IList<String> sqlList = new List<String>();
            StringBuilder cmdText = new StringBuilder();
            //cmdText.Append("delete from ControlDetails ")
            return false;
        }
    }
}
