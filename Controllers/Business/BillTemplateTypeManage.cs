//---------------------------------------------------------—----- //
//功能：TemplateType模板类别信息业务层逻辑                          //
//作者：赵建                                                       //
//版本：v1.7                                                       //
//创建时间：2014/3/10   13:33:00                                  //
//最后修改时间：2014/4/22   18:12:00                              //
//---------------------------------------------------------------//

#region 引入的命名空间
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Controllers.DataAccess;
using Controllers.Models;
using System.Data;
#endregion

namespace Controllers.Business
{
     public class BillTemplateTypeManage
     {
         #region insert
         /// <summary>
        /// 添加模板分类
        /// </summary>
        /// <param name="typeName">类别名称</param>
        /// <param name="bsID">账套ID</param>
        /// <param name="userCode">添加人工号</param>
        /// <returns></returns>
        static public int AddTemplateType(String typeName, String bsName, String userCode)
        {
            return BillTemplateTypeService.AddTemplateType(typeName, bsName, userCode);
        }
        #endregion

         #region update
        /// <summary>
        /// 更新模板类别名称
        /// </summary>
        /// <param name="typeNewName">新的名称</param>
        /// <param name="oldName">原名称</param>
        /// <param name="bsName">账套名称</param>
        /// <returns></returns>
        static public int UpdateTemplateName(String typeNewName, String oldName, String bsName)
        {
            return BillTemplateTypeService.UpdateTemplateName(typeNewName, oldName, bsName);
        }
        
        #endregion
        
         #region select
        /// <summary>
         /// 返回该账套的所有类别
         /// </summary>
         /// <param name="BillSetName"></param>
         /// <returns></returns>
        static public DataTable GetAllTypeByBillsetName(String BillSetName)
        {
            return BillTemplateTypeService.GetAllTypeByBillsetName(BillSetName);
        }

         /// <summary>
         /// 根据类别名称得到类别编号
         /// </summary>
         /// <param name="TypeName"></param>
         /// <returns></returns>
        static public int GetTemplateTypeIdByName(String TypeName)
        {
            return BillTemplateTypeService.GetTemplateTypeIdByName(TypeName);
        }
         /// <summary>
         /// 根据模板类别编号得到类别名称
         /// </summary>
         /// <param name="code"></param>
         /// <returns></returns>
        static public String GetTemplateTypeNameById(int code)
        {
            return BillTemplateTypeService.GetTemplateTypeNameById(code);
        }
         #endregion

         #region 其他
        /// <summary>
        /// 返回类别名称是否存在
        /// </summary>
        /// <param name="Name"></param>
        /// <returns> false 不存在：true 存在</returns>
        static public bool IsTypeNameExsit(String typeName, String bsName)
        {
            return BillTemplateTypeService.IsTypeNameExsit(typeName, bsName);
        }
        #endregion
     } 
    
}
