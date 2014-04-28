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
using Controllers.Moders.TableModers;
using System.Data;
using System.Data.SqlClient;
using Controllers.DataAccess.DAL;

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
            List<SqlParameter> SqlPars = new List<SqlParameter>();
            SqlPars.Add(new SqlParameter("@SoftKey", SqlDbType.NVarChar, 50));
            SqlPars[0].Value = softKey;
            return new MySqlHelper().GetDataSet(GetSelectSQL().ToString(),"soft",SqlPars);
        }

        public bool UpdateSoftVerify(DateTime newtime, String softKey)
        {
            List<SqlParameter> SqlPars = new List<SqlParameter>();
            SqlPars.Add(new SqlParameter("@SoftKey", SqlDbType.NVarChar, 50));
            SqlPars[0].Value = softKey;
            SqlPars.Add(new SqlParameter("@EndTime", SqlDbType.DateTime));
            SqlPars[1].Value = newtime;
            StringBuilder sb = GetUpdateSQL();
            return (new MySqlHelper().ExecDataBySql(sb.ToString(), SqlPars)>0);
        }

    }
}
