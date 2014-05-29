//---------------------------------------------------------—-----//
//功能：TemplateInfo模板信息业务层逻辑                              //
//作者：赵建                                                      //
//版本：v1.1                                                      //
//创建时间：2014/4/10   18:33:00                                  //
//最后修改时间：2014/4/12   16:12:00                               //
//---------------------------------------------------------------//
#region 引入的命名空间
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Controllers.Models;
using Controllers.DataAccess.SQLHELPER;
using Controllers.DataAccess;
#endregion

namespace Controllers.Business
{
    public class BillTemplateManage
    {
        #region insert
        /// <summary>
        /// 根据模板实体增加模板信息
        /// </summary>
        /// <param name="btm">模板实体</param>
        /// <returns></returns>
        public static int AddByBillTemplatModel(BillTemplatModel btm)
        {
            return BillTemplateService.AddByBillTemplatModel(btm);
        }
        #endregion

        #region update
        /// <summary>
        /// 根据模板实体更新模板信息
        /// </summary>
        /// <param name="btm"></param>
        /// <returns></returns>
        public static int UpdateByBillTemplatModel(BillTemplatModel btm)
        {
            return BillTemplateService.UpdateByBillTemplatModel(btm);
        }
        #endregion

        #region  select
        /// <summary>
        /// 根据模板编号返回模板实体
        /// </summary>
        /// <param name="code">模板编号</param>
        /// <returns></returns>
        public static BillTemplatModel SelectTemplateModeltByID(int code)
        {
            return BillTemplateService.GetTemplateModeltByID(code);
        }

        /// <summary>
        /// 根据模板名称返回模板信息（DataTable）
        /// </summary>
        /// <param name="sTemplateName">模板名称</param>
        /// <returns></returns>
        public static DataTable GetDataTableByTypeName(String sTemplateName)
        {
            return BillTemplateService.GetDataTableByTypeName(sTemplateName);
        }
       
        /// <summary>
        /// 根据账套名取模板信息
        /// </summary>
        /// <param name="Sname">账套名</param>
        /// <returns></returns>
        public static DataTable GetTemplatBagroundByBSName(String Sname)
        {
            return BillTemplateService.GetTemplatBagroundByBSName(Sname);
        }
        #endregion
    }
}
