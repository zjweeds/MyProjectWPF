//---------------------------------------------------------—-----//
//功能：软件验证数据逻辑                                            //
//作者：赵建                                                      //
//版本：v1.3                                                      //
//创建时间：2014/3/30   12:55:00                                  //
//最后修改时间：2014/3/30   12:55:00                              //
//---------------------------------------------------------------//
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Controllers.Models;
using System.Data;
using System.Data.SqlClient;
using Controllers.DataAccess.SQLHELPER;

namespace Controllers.DataAccess
{    
    public class SoftVeilyAccess
    {
        private StringBuilder GetSelectSQL()
        {
            StringBuilder sbsql = new StringBuilder();
            sbsql.Append("select top 1 CompanyName,StarTime,EndTime from RegistInfo  where SoftKey =@SoftKey");
            return sbsql;
          
        }
        private StringBuilder GetUpdateSQL()
        {
            StringBuilder sbsql = new StringBuilder();
            sbsql.Append("Update RegistInfo set EndTime =@EndTime where RegistID = ( ");
            sbsql.Append("select top 1  RegistID from RegistInfo  where SoftKey =@SoftKey) ");
            return sbsql;
        }
        public DataSet  GetSoftVerify(String softKey)
        {
            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@SoftKey", SqlDbType.NVarChar, 50);
            param[0].Value = softKey;
            return new MySqlHelper().GetDataSet(GetSelectSQL().ToString(), param,1);
        }

        public bool UpdateSoftVerify(DateTime newtime, String softKey)
        {
            SqlParameter[] param = new SqlParameter[2];
            param[0]=new SqlParameter("@SoftKey", SqlDbType.NVarChar, 50);
            param[0].Value = softKey;
            param[1]=new SqlParameter("@EndTime", SqlDbType.DateTime);
            param[1].Value = newtime;
            StringBuilder sb = GetUpdateSQL();
            return (new MySqlHelper().ExecDataBySql(sb.ToString(), param,2) > 0);
        }

    }
}
