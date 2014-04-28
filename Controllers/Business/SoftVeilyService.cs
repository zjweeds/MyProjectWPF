using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Controllers.DataAccess;
using Controllers.Moders.TableModers;

namespace Controllers.Business
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
        //public bool softVeilySaveToXml(SoftVerify softVerify)
        //{           
        //    if (myxmlhelper.SaveToXml(path + '/' + file, softVerify))
        //    {
        //        return true;
        //    }
        //    else
        //    {
        //        return false;
        //    }
        //}   
        //    if (GetSoftVeily(key)!=null)
        //    {

        //        return true;
        //    }

    }
}
