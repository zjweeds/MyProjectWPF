using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using System.Reflection;
namespace Controllers.DAL
{
    /// <summary>
    /// 数据处理助手(由Hirer实体工具生成)
    /// </summary>
    public class DBHelper
    {
        public static string connString = "Data Source=.;Initial Catalog=BillManage;Integrated Security=True";
   
        // 创建连接connection对象
        public static SqlConnection CreateConn()
        {
            return new SqlConnection(connString);
        }
  
        // 打开数据库连接
        public static void OpenConn(SqlConnection conn)
        {
            if (conn != null && conn.State == ConnectionState.Closed)
                conn.Open();
        }
   
        // 关闭数据库连接
        public static void CloseConn(SqlConnection conn)
        {
            if (conn != null && conn.State == ConnectionState.Open)
                conn.Close();
        }
   
        /// <summary>
        /// 数据处理
        /// </summary>
        /// <param name="cmdText">SQL语句</param>
        /// <param name="paramers">CMD参数</param>
        /// <returns>结果</returns>
        public static Object Execute(string cmdText, params SqlParameter[] paramers)
        {
            //判断数据处理类型
            if (!cmdText.Substring(0, 6).Equals("select", StringComparison.CurrentCultureIgnoreCase))
            {
                using (SqlConnection conn = CreateConn())
                {
                    SqlCommand cmd = CreateCMD(cmdText, paramers, conn);
                    return cmd.ExecuteNonQuery();
                }
            }
            else
            {
                SqlConnection conn = CreateConn();
                SqlCommand cmd = CreateCMD(cmdText, paramers, conn);
                return cmd.ExecuteReader(CommandBehavior.CloseConnection);
            }
        }
   
        private static SqlCommand CreateCMD(string cmdText, SqlParameter[] paramers, SqlConnection conn)
        {
            SqlCommand cmd = new SqlCommand(cmdText, conn);
            if (paramers != null)
                cmd.Parameters.AddRange(paramers);
            OpenConn(conn);
            return cmd;
        }
    }
}
