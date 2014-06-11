//----------------------------------------------------------------//
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

namespace Controllers.DataAccess.SQLHELPER
{
   public  class MySqlHelper
   {
        #region 只读属性
        /// <summary>
        /// 数据库连接
        /// </summary>
        private SqlConnection m_Conn;
        public SqlConnection Conn
        {
            get { return m_Conn; }
        }
             
        /// <summary>
        /// 数据库命令
        /// </summary>
        private SqlCommand m_Cmd;
        public SqlCommand Cmd
        {
            get{return m_Cmd;}
        }
        #endregion

        #region 重载的构造函数
        /// <summary>
        /// 直接根据 数据库连接字符串构建
        /// </summary>
        /// <param name="strConn"></param>
        public MySqlHelper(String strConn)
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
        /// 无参构造函数，从配置文件中读取连接字符串
        /// </summary>
        public MySqlHelper()
        {
            try
            {
                Models.SoftConfigModel scfm = new MyXmlHelper().readXMl(AppDomain.CurrentDomain.BaseDirectory + @"\Configs\SoftConfig.xml");
                String strServer = scfm.softServerIP;//ReadFiles.GetIniFileString("DataBase", "Server", "", AppDomain.CurrentDomain.BaseDirectory + "\\BillManage.ini");
                String database = scfm.softDBName; //ReadFiles.GetIniFileString("DataBase", "Database", "", AppDomain.CurrentDomain.BaseDirectory + "\\BillManage.ini");
                //获取登录用户
                String strUserID = scfm.softDBUser; //ReadFiles.GetIniFileString("DataBase", "UserID", "", AppDomain.CurrentDomain.BaseDirectory + "\\BillManage.ini");
                //获取登录密码
                String strPwd = scfm.softDBPwd; //ReadFiles.GetIniFileString("DataBase", "Pwd", "", AppDomain.CurrentDomain.BaseDirectory + "\\BillManage.ini");
                //数据库连接字符串
                String strConn = "Server = " + strServer + ";Database = " + database + ";User id=" + strUserID + ";PWD=" + strPwd;
                //strConn = "server=.;database = BillManage;User id =sa ; PWD = zhaojian ";

                m_Conn = new SqlConnection(strConn);
                m_Cmd = new SqlCommand();
                m_Cmd.Connection = m_Conn;
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        #endregion
       
        #region  私有方法
        public static void OpenConn(SqlConnection conn)
        {
            if (conn != null && conn.State == ConnectionState.Closed)
                conn.Open();
        }
        public static void CloseConn(SqlConnection conn)
        {
            if (conn != null && conn.State == ConnectionState.Open)
                conn.Close();
        }
        private static SqlCommand CreateCMD(String cmdText, SqlParameter[] paramers, SqlConnection conn)
        {
            SqlCommand cmd = new SqlCommand(cmdText, conn);
            if (paramers != null)
                cmd.Parameters.AddRange(paramers);
            OpenConn(conn);
            return cmd;
        }
        #endregion 

        #region 公共方法
        /// <summary>
        /// 插入数据，返回自增ID
       /// </summary>
       /// <param name="strSql"></param>
       /// <returns></returns>
        public int ExecSqlReturnId(String strSql)
        {
            int intReturnValue;
            m_Cmd.CommandType = CommandType.Text;
            m_Cmd.CommandText = strSql;
            try
            {
                OpenConn(m_Conn);
                intReturnValue = Convert.ToInt32(m_Cmd.ExecuteScalar());
            }
            catch (Exception e)
            {
                throw e;
            }
            finally
            {
                CloseConn(m_Conn);//连接关闭，但不释放掉该对象所占的内存单元
            }
            return intReturnValue;
        }

       /// <summary>
        /// 插入数据，返回自增ID
       /// </summary>
       /// <param name="strSql"></param>
       /// <param name="param"></param>
       /// <param name="count"></param>
       /// <returns></returns>
       //public int ExecSqlReturnId(String strSql, SqlParameter[] param, int count)
       // {
       //     int intReturnValue;
       //     m_Cmd.CommandType = CommandType.Text;
       //     m_Cmd.CommandText = strSql;
       //     m_Cmd.Parameters.Clear();
       //     for (int i = 0; i < count; i++)
       //     {
       //         m_Cmd.Parameters.Add(param[i]);
       //     }
       //     try
       //     {
       //         if (m_Conn.State == ConnectionState.Closed)
       //         {
       //             m_Conn.Open();
       //         }
       //         intReturnValue = Convert.ToInt32(m_Cmd.ExecuteScalar());
       //     }
       //     catch (Exception e)
       //     {
       //         throw e;
       //     }
       //     finally
       //     {
       //         m_Conn.Close();//连接关闭，但不释放掉该对象所占的内存单元
       //     }
       //     return intReturnValue;
       // }

       public int ExecSqlReturnId(String cmdText, params SqlParameter[] paramers)
       {
           int intReturnValue;
           try
           {
               m_Cmd  = CreateCMD(cmdText, paramers, m_Conn);
               intReturnValue = Convert.ToInt32(m_Cmd.ExecuteScalar());
           }
           catch (Exception e)
           {
               throw e;
           }
           finally
           {
               CloseConn(m_Conn);//连接关闭，但不释放掉该对象所占的内存单元
           }
           return intReturnValue;
       }
       /// <summary>
       /// 通过Transact-SQL语句提交数据
       /// </summary>
       /// <param name="strSql"></param>
       /// <param name="param"></param>
       /// <param name="count"></param>
       /// <returns></returns>
       public int ExecDataBySql(String cmdText, params SqlParameter[] paramers)
       {
           int intReturnValue;
           try
           {
               m_Cmd = CreateCMD(cmdText, paramers, m_Conn);
               intReturnValue = m_Cmd.ExecuteNonQuery();
           }
           catch (Exception e)
           {
               throw e;
           }
           finally
           {
               CloseConn(m_Conn);//连接关闭，但不释放掉该对象所占的内存单元
           }
           return intReturnValue;
       }      

        /// <summary>
        /// 通过Transact-SQL语句提交数据
        /// </summary>
        /// <param name="strSql"></param>
        /// <returns></returns>
        public int ExecDataBySql(String strSql)
        {
            int intReturnValue;
            m_Cmd.CommandType = CommandType.Text;
            m_Cmd.CommandText = strSql;           
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
        public bool ExecDataBySqls(IList<String> strSqls)
        {
            
                bool booIsSucceed;

                OpenConn(m_Conn);
                SqlTransaction sqlTran = m_Conn.BeginTransaction();
                try
                {
                    m_Cmd.Transaction = sqlTran;
                    foreach (String item in strSqls)
                    {
                        m_Cmd.CommandType = CommandType.Text;
                        m_Cmd.CommandText = item;
                        m_Cmd.ExecuteNonQuery();
                    }
                    sqlTran.Commit(); //保存事务的修改
                    booIsSucceed = true;  //表示提交数据库成功
                }
                catch(Exception ex)
                {
                 
                    sqlTran.Rollback();   
                    booIsSucceed = false;  //表示提交数据库失败！
               throw ex; 
                }
                finally
                {
                    CloseConn(m_Conn);
                    strSqls.Clear();
                }
                return booIsSucceed;          
        }

        /// <summary>
        /// 通过Transact-SQL语句得到DataSet实例
        /// </summary>
        /// <param name="strSql">Transact-SQL语句</param>
        /// <returns>DataSet实例的引用</returns>
        public DataSet GetDataSet(String strSql)
        {
            DataSet ds = null;
            m_Cmd.CommandType = CommandType.Text;
            m_Cmd.CommandText = strSql;           
            try
            {
                SqlDataAdapter sda = new SqlDataAdapter(m_Cmd);
                ds = new DataSet();
                sda.Fill(ds);
            }
            catch (Exception e)
            {
                throw e;
            }

            return ds;
        }

        /// <summary>
        /// 通过Transact-SQL语句得到DataSet实例
        /// </summary>
        /// <param name="strSql">Transact-SQL语句</param>
        /// <param name="strTable">相关的数据表</param>
        /// <returns>DataSet实例的引用</returns>
        public DataSet GetDataSet(String cmdText, params SqlParameter[] paramers)
        {
            DataSet ds = null;
            try
            {
                m_Cmd = CreateCMD(cmdText, paramers, m_Conn);
                SqlDataAdapter sda = new SqlDataAdapter(m_Cmd);
                ds = new DataSet();
                sda.Fill(ds);
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
        public SqlDataReader GetDataReader(String strSql)
        {
            SqlDataReader sdr;
            m_Cmd.CommandType = CommandType.Text;
            m_Cmd.CommandText = strSql;
            try
            {
                OpenConn(m_Conn);

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
        /// 通过Transact-SQL语句得到SqlDataReader实例
        /// </summary>
        /// <param name="strSql">Transact-SQL语句</param>
        /// <returns>SqlDataReader实例的引用</returns>
        public SqlDataReader GetDataReader(String cmdText, params SqlParameter[] paramers)
        {
            SqlDataReader sdr;
            try
            {
                m_Cmd = CreateCMD(cmdText, paramers, m_Conn);
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
        public int GetNumberOf(String strSql, SqlParameter[] param)
        {
            int item;
            SqlDataReader Dr = this.GetDataReader(strSql, param);
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
       /// 执行SQL，返回符合条件的第一行第一列值
       /// </summary>
       /// <param name="strSql"></param>
       /// <returns></returns>
        public object GetSingleObject(String strSql)
        {
            object obj = null;
            m_Cmd.CommandType = CommandType.Text;
            m_Cmd.CommandText = strSql;           
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
        /// 重新封装ExecuteScalar方法，得到结果集中的第一行的第一列
        /// </summary>
        /// <param name="strSql">Transact-SQL语句</param>
        /// <returns>结果集中的第一行的第一列</returns>
        public object GetSingleObject(String cmdText, params SqlParameter[] paramers)
        {
            object obj = null;
            try
            {
                m_Cmd = CreateCMD(cmdText, paramers, m_Conn);                
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
       /// <param name="strSql"></param>
       /// <returns></returns>
        public DataTable GetDataTable(String strSql)
        {
            DataTable dt = null;
            SqlDataAdapter sda = null;
            m_Cmd.CommandType = CommandType.Text;
            m_Cmd.CommandText = strSql;            
            try
            {
                sda = new SqlDataAdapter(m_Cmd);
                dt = new DataTable();
                sda.Fill(dt);
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return dt; //dt.Rows.Count可能等于零
        }

        /// <summary>
        /// 通过Transact-SQL语句，得到DataTable实例
        /// </summary>
        /// <param name="strSqlCode">Transact-SQL语句</param>
        /// <param name="strTableName">数据表的名称</param>
        /// <returns>DataTable实例的引用</returns>
        //public DataTable GetDataTable(String cmdText, params SqlParameter[] paramers)
        //{
        //    DataTable dt = new DataTable(); ;
        //    SqlDataAdapter sda = null;
        //    try
        //    {
        //        m_Cmd = CreateCMD(cmdText, paramers, m_Conn);
        //        sda= new SqlDataAdapter(m_Cmd);
        //        sda.Fill(dt);
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }

        //    return dt; //dt.Rows.Count可能等于零
        //}

        /// <summary>
        /// 通过存储过程，得到DataTable实例
        /// </summary>
        /// <param name="strProcedureName">存储过程名称</param>
        /// <param name="inputParameters">存储过程的参数数组</param>
        /// <returns>DataTable实例的引用</returns>
        public DataTable GetDataTable(String strProcedureName, SqlParameter[] inputParameters)
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


       /// <summary>
       /// 根据数据源更新数据库
       /// </summary>
       /// <param name="sqlText"></param>
       /// <param name="dt"></param>
       /// <returns></returns>
        public bool updateByDt(String sqlText, DataTable dt)
        {
            SqlDataAdapter sda = null;
            m_Cmd.CommandType = CommandType.Text;
            m_Cmd.CommandText = sqlText;
            try
            {
                sda = new SqlDataAdapter(m_Cmd);
                SqlCommandBuilder scb = new SqlCommandBuilder(sda);
                sda.Update(dt);
                dt.AcceptChanges();
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion
   }
}