/******************************************************************
 * 创 建 人：  赵建
 * 创建时间：  2013-11-16 9:59
 * 描    述：
 *             软件验证信息数据层
 * 版    本：  V1.0      
 * 环    境：  VS2013
******************************************************************/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Controllers.DataAccess;
using Controllers.Models;

namespace Controllers.DataAccess
{
    public class SoftVeilyService
    {
        public SoftVerify GetSoftVeily(String softkey)
        {
            DataSet ds = new SoftVeilyAccess().GetSoftVerify(softkey);
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                SoftVerify softVeily = new SoftVerify();
                softVeily.CompanyName = ds.Tables[0].Rows[0]["RegistCompany"].ToString();
                softVeily.StarTime = DateTime.Parse(ds.Tables[0].Rows[0]["StarTime"].ToString());
                softVeily.EndTime = DateTime.Parse(ds.Tables[0].Rows[0]["EndTime"].ToString());
                return softVeily;
            }
            else
            {
                return new SoftVerify();
            }
        }
    }
}
