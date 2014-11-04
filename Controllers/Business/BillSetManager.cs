//---------------------------------------------------------—-----//
//功能：BillSetInfo账套信息业务层逻辑                              //
//作者：赵建                                                      //
//版本：v1.1                                                      //
//创建时间：2014/3/20   19:33:00                                  //
//最后修改时间：2014/5/12   16:12:00                               //
//---------------------------------------------------------------//
#region 引入的命名空间
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Controllers.Models;
using Controllers.DataAccess;
#endregion

namespace Controllers.Business
{
    /// <summary>
    /// BillSetInfo账套信息业务层逻辑 
    /// </summary>
    public class BillSetManager
    {
        #region select 
        /// <summary>
        /// 根据公司名返回账套列表（datatable）
        /// </summary>
        /// <param name="name">公司名</param>
        /// <returns></returns>
        static public DataTable GetDataTableByCompanyName(String name)
        {
            return BillSetService.GetBillSetNameByCompany(name);
        }

        /// <summary>
        /// 根据公司ID返回账套列表（datatable）
        /// </summary>
        /// <param name="comID">公司ID</param>
        /// <returns></returns>
        static public DataTable GetDataTableByCompanyID(Int32 comID)
        {
            return BillSetService.GetBillSetNameByCompanyID(comID);
        }


        /// <summary>
        /// 根据ID返回账套名称
        /// </summary>
        /// <param name="bSID"></param>
        /// <returns></returns>
        static public String GetBillSetNameByID(int bSID)
        {
            return BillSetService.GetBillSetNameByID(bSID);
        }

        /// <summary>
        /// 根据ID更新账套名称
        /// </summary>
        /// <param name="Name"></param>
        /// <param name="BSID"></param>
        /// <returns></returns>
        static public int UpdateName(String Name, int BSID)
        {
            return BillSetService.UpdateName(Name, BSID);
        }

        /// <summary>
        /// 根据账套名称删除
        /// </summary>
        /// <param name="Name"></param>
        /// <returns></returns>
        static public int DeleteByName(String Name)
        {
            return BillSetService.DeleteByName(Name);
        }

        /// <summary>
        /// 根据实体插入账套信息
        /// </summary>
        /// <param name="bsi"></param>
        /// <returns></returns>
         static public int insertBillSetInfo(BillSetInfo bsi)
        {
            return BillSetService.insertBillSetInfo(bsi);
         }

        /// <summary>
        /// 根据名称返回ID
        /// </summary>
        /// <param name="BsName"></param>
        /// <returns></returns>
         static public int GetBillSetID(String BsName)
         {
             return BillSetService.GetBillSetID(BsName);
         }
        #endregion
    }
}
