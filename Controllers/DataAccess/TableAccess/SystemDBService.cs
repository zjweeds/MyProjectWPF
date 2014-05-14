using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Controllers.DataAccess.SQLHELPER;
using System.Data;


namespace Controllers.DataAccess
{
    public class SystemDBService
    {
        /// <summary>
        /// 动态创建数据库
        /// </summary>
        /// <param name="serverIP">服务器IP</param>
        /// <param name="user">用户名</param>
        /// <param name="pwd">密码</param>
        /// <param name="dbName">数据库名称</param>
        /// <param name="path">文件保存路径</param>
        /// <param name="size">初始大小</param>
        /// <param name="maxsize">最大大小</param>
        /// <returns></returns>
        public bool CreatDataBase(String serverIP, String user, String pwd, String dbName, String path, int size, int maxsize)
        {
            try
            {
                String sqlConString = "Server = " + serverIP + ";Database = master;User id=" + user + ";PWD=" + pwd;
                MySqlHelper msql = new MySqlHelper(sqlConString);
                StringBuilder sb = new StringBuilder();
                sb.AppendFormat("CREATE DATABASE {0} ON PRIMARY", dbName);
                sb.AppendFormat("                     ( name={0},", dbName);
                sb.AppendFormat("                       filename ='{0}.mdf',", path + @"\" + dbName);
                sb.AppendFormat("                       size={0}mb,", size);
                sb.AppendFormat("                       maxsize={0}mb,", maxsize);
                sb.Append("                             filegrowth=10%");
                sb.Append(")");
                sb.Append("log on");
                sb.AppendFormat("                     ( name={0}_log,", dbName);
                sb.AppendFormat("                       filename ='{0}_log.ldf',", path + @"\" + dbName);
                sb.AppendFormat("                       size={0}mb,", size);
                sb.Append("                             filegrowth=1mb");
                sb.Append(")");
                msql.ExecDataBySql(sb.ToString());
                return true;
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// 返回目标服务器所有数据库名称
        /// </summary>
        /// <param name="serverIP"></param>
        /// <param name="user"></param>
        /// <param name="pwd"></param>
        /// <returns></returns>
        public DataTable GetAllDBName(String serverIP, String user, String pwd)
        {
            try
            {
                DataTable dt = new DataTable();
                String sqlConString = "Server = " + serverIP + ";Database = master;User id=" + user + ";PWD=" + pwd;
                MySqlHelper msql = new MySqlHelper(sqlConString);
                StringBuilder sb = new StringBuilder();
                sb.Append("select name from sysdatabases");
                return msql.GetDataTable(sb.ToString());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
