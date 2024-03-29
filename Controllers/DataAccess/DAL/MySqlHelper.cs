﻿//----------------------------------------------------------------//
//功能：数据库帮助类                                              //
//作者：赵建                                                      //
//版本：v1.3                                                      //
//创建时间：2013/11/7   15:34:00                                  //
//最后一次修改时间：2014/3/23   17:22:00                          //
//---------------------------------------------------------------//
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using Controllers.Common;

namespace Controllers.DataAccess.DAL
{
   public  class MySqlHelper
    {
        private SqlConnection m_Conn = null;
        private SqlCommand m_Cmd = null;
        public MySqlHelper(string strConn)
        {
            try
            {
                m_Conn = new SqlConnection(strConn);
                m_Cmd = new SqlCommand();
                m_Cmd.Connection = m_Conn;
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        /// <summary>
        /// 创建数据库连接和SqlCommand实例
        /// </summary>
        public MySqlHelper()
        {
            string strServer = ReadFiles.GetIniFileString("DataBase", "Server", "", AppDomain.CurrentDomain.BaseDirectory + "\\BillManage.ini");
            string database = ReadFiles.GetIniFileString("DataBase", "Database", "", AppDomain.CurrentDomain.BaseDirectory + "\\BillManage.ini");
            //获取登录用户
            string strUserID = ReadFiles.GetIniFileString("DataBase", "UserID", "", AppDomain.CurrentDomain.BaseDirectory + "\\BillManage.ini");
            //获取登录密码
            string strPwd = ReadFiles.GetIniFileString("DataBase", "Pwd", "", AppDomain.CurrentDomain.BaseDirectory + "\\BillManage.ini");
            //数据库连接字符串
            string strConn = "Server = " + strServer + ";Database = " + database + ";User id=" + strUserID + ";PWD=" + strPwd;
            strConn = "server=.;database = BillManage;User id =sa ; PWD = zhaojian ";
            try
            {
                m_Conn = new SqlConnection(strConn);
                m_Cmd = new SqlCommand();
                m_Cmd.Connection = m_Conn;
            }
            catch (Exception e)
            {
                throw e;
            }
        }
      
        public SqlConnection Conn
        {
            get { return m_Conn; }
        }

        public SqlCommand Cmd
        {
            get { return m_Cmd; }
        }
        
        /// <summary>
        /// 通过Transact-SQL语句提交数据
        /// </summary>
        /// <param name="strSql">Transact-SQL语句</param>
        /// <returns>受影响的行数</returns>
        public int ExecDataBySql(string strSql,List<SqlParameter> sqlPar)
        {
            int intReturnValue;
            m_Cmd.CommandType = CommandType.Text;
            m_Cmd.CommandText = strSql;
            if (sqlPar != null)
            {
                foreach (SqlParameter sqlpItem in sqlPar)
                {
                    m_Cmd.Parameters.Add(sqlpItem);
                }
            }
            try
            {
                if (m_Conn.State == ConnectionState.Closed)
                {
                    m_Conn.Open();
                }
                intReturnValue = m_Cmd.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                throw e;
            }
            finally
            {
                m_Conn.Close();//连接关闭，但不释放掉该对象所占的内存单元
            }
            return intReturnValue;
        }
       
        /// <summary>
        /// 多条Transact-SQL语句提交数据
        /// </summary>
        /// <param name="strSqls">使用List泛型封装多条SQL语句</param>
        /// <returns>bool值(提交是否成功)</returns>
        public bool ExecDataBySqls(List<string> strSqls)
        {
            
                bool booIsSucceed;

                if (m_Conn.State == ConnectionState.Closed)
                {
                    m_Conn.Open();
                }
                SqlTransaction sqlTran = m_Conn.BeginTransaction();
                try
                {
                    m_Cmd.Transaction = sqlTran;
                    foreach (string item in strSqls)
                    {
                        m_Cmd.CommandType = CommandType.Text;
                        m_Cmd.CommandText = item;
                        m_Cmd.ExecuteNonQuery();
                    }
                    sqlTran.Commit();
                    booIsSucceed = true;  //表示提交数据库成功
                }
                catch
                {                    
                    sqlTran.Rollback();
                    booIsSucceed = false;  //表示提交数据库失败！
                }
                finally
                {
                    m_Conn.Close();
                    strSqls.Clear();
                }
                return booIsSucceed;          
        }

        /// <summary>
        /// 通过Transact-SQL语句得到DataSet实例
        /// </summary>
        /// <param name="strSql">Transact-SQL语句</param>
        /// <param name="strTable">相关的数据表</param>
        /// <returns>DataSet实例的引用</returns>
        public DataSet GetDataSet(string strSql, string strTable,List<SqlParameter> sqlPar)
        {
            DataSet ds = null;
             m_Cmd.CommandType = CommandType.Text;
            m_Cmd.CommandText = strSql;
            if (sqlPar != null)
            {
                foreach (SqlParameter sqlpItem in sqlPar)
                {
                    m_Cmd.Parameters.Add(sqlpItem);
                }
            }
            try
            {
                SqlDataAdapter sda = new SqlDataAdapter(m_Cmd);
                ds = new DataSet();
                sda.Fill(ds, strTable);
            }
            catch (Exception e)
            {
                throw e;
            }

            return ds;
        }

        /// <summary>
        /// 通过Transact-SQL语句得到SqlDataReader实例
        /// </summary>
        /// <param name="strSql">Transact-SQL语句</param>
        /// <returns>SqlDataReader实例的引用</returns>
        public SqlDataReader GetDataReader(string strSql,List<SqlParameter> sqlPar)
        {
            SqlDataReader sdr;
            m_Cmd.CommandType = CommandType.Text;
            m_Cmd.CommandText = strSql;
            if (sqlPar != null)
            {
                foreach (SqlParameter sp in sqlPar)
                {
                    m_Cmd.Parameters.Add(sp);
                }
            }
            try
            {
                if (m_Conn.State == ConnectionState.Closed)
                {
                    m_Conn.Open();
                }

                sdr = m_Cmd.ExecuteReader(CommandBehavior.CloseConnection);
            }
            catch (Exception e)
            {
                throw e;
            }

            //sdr对象和m_Conn对象暂时不能关闭和释放掉，否则在调用时无法使用
            //待使用完毕sdr，再关闭sdr对象（同时会自动关闭关联的m_Conn对象）
            //m_Conn的关闭是指关闭连接通道，但连接对象依然存在
            //m_Conn的释放掉是指销毁连接对象
            return sdr;
        }

        /// <summary>
        /// 通过聚合函数SQL语句得到数值
        /// </summary>
        /// <param name="strSql">Transact-SQL语句</param>
        /// <returns>该数值</returns>
        public int GetNumberOf(string strSql,List<SqlParameter> sqlPar)
        {
            int item;
            SqlDataReader Dr = this.GetDataReader(strSql, sqlPar);
            if (Dr.Read())
            {

                item= Convert.ToInt32(Dr[0].ToString());
            }
            else            
            {
                item= 0;
            }
            Dr.Close();
            return item;
        }

        /// <summary>
        /// 重新封装ExecuteScalar方法，得到结果集中的第一行的第一列
        /// </summary>
        /// <param name="strSql">Transact-SQL语句</param>
        /// <returns>结果集中的第一行的第一列</returns>
        public object GetSingleObject(string strSql,List<SqlParameter> sqlList)
        {
            object obj = null;
            m_Cmd.CommandType = CommandType.Text;
            m_Cmd.CommandText = strSql;
            foreach (SqlParameter sqlItem in sqlList)
            {
                m_Cmd.Parameters.Add(sqlItem);
            }
            try
            {
                if (m_Conn.State == ConnectionState.Closed)
                {
                    m_Conn.Open();
                }
                obj = m_Cmd.ExecuteScalar();
            }
            catch (Exception e)
            {
                throw e;//向上一层抛出异常（上一层使用try{}catch{}）或立刻中断(上一层未使用try{}catch{})
            }
            finally
            {
                m_Conn.Close();
            }

            return obj;
        }

        /// <summary>
        /// 通过Transact-SQL语句，得到DataTable实例
        /// </summary>
        /// <param name="strSqlCode">Transact-SQL语句</param>
        /// <param name="strTableName">数据表的名称</param>
        /// <returns>DataTable实例的引用</returns>
        public DataTable GetDataTable(string strSql, string strTableName)
        {
            DataTable dt = null;
            SqlDataAdapter sda = null;

            try
            {
                sda = new SqlDataAdapter(strSql, m_Conn);
                dt = new DataTable(strTableName);
                sda.Fill(dt);
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return dt; //dt.Rows.Count可能等于零
        }

        /// <summary>
        /// 通过存储过程，得到DataTable实例
        /// </summary>
        /// <param name="strProcedureName">存储过程名称</param>
        /// <param name="inputParameters">存储过程的参数数组</param>
        /// <returns>DataTable实例的引用</returns>
        public DataTable GetDataTable(string strProcedureName, SqlParameter[] inputParameters)
        {
            DataTable dt = new DataTable();
            SqlDataAdapter sda = null;

            try
            {
                m_Cmd.CommandType = CommandType.StoredProcedure;
                m_Cmd.CommandText = strProcedureName;
                sda = new SqlDataAdapter(m_Cmd);
                m_Cmd.Parameters.Clear();

                foreach (SqlParameter param in inputParameters)
                {
                    param.Direction = ParameterDirection.Input;
                    m_Cmd.Parameters.Add(param);
                }

                sda.Fill(dt);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dt; //dt.Rows.Count可能等于零
        } 
    }
}