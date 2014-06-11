//---------------------------------------------------------—-----//
//功能：数据库操作相关业务层逻辑                                   //
//作者：赵建                                                      //
//版本：v1.1                                                      //
//创建时间：2014/3/30   12:55:00                                  //
//最后修改时间：2014/5/30   8:55:00                               //
//---------------------------------------------------------------//
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Controllers.Models;
using Controllers.DataAccess.SQLHELPER;
using Controllers.DataAccess;
using System.Data;

namespace Controllers.Business
{
    public class SystemDBManage
    {
        /// <summary>
        /// 创建数据库
        /// </summary>
        /// <param name="serverIP">服务器ID</param>
        /// <param name="user">账户名</param>
        /// <param name="pwd">密码</param>
        /// <param name="dbName">数据库名</param>
        /// <param name="path">文件存储地址</param>
        /// <param name="size">初始大小</param>
        /// <param name="maxsize">最大大小</param>
        /// <returns></returns>
        static public bool CreatDataBase(String serverIP, String user, String pwd, String dbName, String path, int size, int maxsize)
        {
            return new SystemDBService().CreatDataBase(serverIP, user, pwd, dbName, path, size, maxsize);
        }

        /// <summary>
        /// 创建管理员账号
        /// </summary>
        /// <param name="serverIP">服务器</param>
        /// <param name="user">账户名</param>
        /// <param name="pwd">密码</param>
        /// <param name="dbName">数据库名</param>
        /// <param name="name">管理员工号</param>
        /// <param name="adPwd">管理员密码</param>
        /// <returns></returns>
        static public bool CreatAdmin(String serverIP, String user, String pwd, String dbName, String name, String adPwd)
        {
            return new SystemDBService().CreatAdmin(serverIP, user, pwd, dbName,name,adPwd);
        }

        /// <summary>
        /// 返回服务器所有数据库
        /// </summary>
        /// <param name="serverIP">服务器IP</param>
        /// <param name="user">账户名</param>
        /// <param name="pwd">密码</param>
        /// <returns></returns>
        static public DataTable GetAllDBName(String serverIP, String user, String pwd)
        {
            return new SystemDBService().GetAllDBName(serverIP, user, pwd);
        }

        /// <summary>
        /// 创建公司及账套
        /// </summary>
        /// <param name="serverIP">服务器IP</param>
        /// <param name="user">账户名</param>
        /// <param name="pwd">密码</param>
        /// <param name="dbName">数据库名称</param>
        /// <param name="comName">公司名</param>
        /// <param name="bsName">帐套名</param>
        /// <returns></returns>
        static public bool CreateCompanyAndBillSet(String serverIP, String user, String pwd, String dbName, String comName, String bsName)
        {
            return new SystemDBService().CreateCompanyAndBillSet(serverIP, user, pwd, dbName, comName, bsName);
        }
    }
}
