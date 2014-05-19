using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Controllers.DataAccess;

namespace Controllers.Business
{
    public class DataSourceManager
    {
        public static  DataTable GetAllBandingsInfoByTableAndCoumln(String tableName, String coumlnName)
        {
            return new DataSourceService().GetBandingsInfoByTableAndCoumln(tableName, coumlnName,null,null);
        }

        public static DataTable GetBandingsInfoByTableAndCoumln(String tableName, String coumlnName, List<String> whereFeild, List<String> whereVuale)
        {
            return new DataSourceService().GetBandingsInfoByTableAndCoumln(tableName, coumlnName, whereFeild, whereVuale);
        }
        public  static DataTable GetAllCoumsBandingsInfoByTableAndCoumln(String tableName, String coumlnName, String values)
        {
            return new DataSourceService().GetAllCoumsBandingsInfoByTableAndCoumln(tableName, coumlnName, values);
        }
    }
}
