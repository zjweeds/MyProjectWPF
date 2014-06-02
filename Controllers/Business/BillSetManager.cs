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

        static public String GetBillSetNameByID(int bSID)
        {
            return BillSetService.GetBillSetNameByID(bSID);
        }

        static public int UpdateName(String Name, int BSID)
        {
            return BillSetService.UpdateName(Name, BSID);
        }

         static public int insertBillSetInfo(BillSetInfo bsi)
        {
            return BillSetService.insertBillSetInfo(bsi);
         }     
        #endregion
    }
}
