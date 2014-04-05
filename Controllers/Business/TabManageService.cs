using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Controllers.DataAccess;
using System.Data;

namespace Controllers.Business
{    
    public class TabManageService
    {
        public TabManageAccess TMA = new TabManageAccess();
        public List<string> GetTabName(string BillSetName, string CompanyName)
        {
            List<string> strLists = new List<string>();
            DataSet ds = TMA.SelectTemplateType(BillSetName, CompanyName);
            if (ds != null && ds.Tables.Count!=0)
            {
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    strLists.Add(ds.Tables[0].Rows[i][0].ToString());
                }
            }
            return strLists;
        }

    }
}
