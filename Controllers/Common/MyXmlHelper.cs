//---------------------------------------------------------—-----//
//功能：XML文件帮助类                                             //
//作者：赵建                                                      //
//版本：v1.3                                                      //
//创建时间：2014/3/30   12:55:00                                  //
//最后修改时间：2014/3/30   12:55:00                              //
//---------------------------------------------------------------//
#region 引入的命名空间
using System;
using System.Collections;//哈希表
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Xml;
using Controllers.Models;
#endregion

namespace Controllers.Common
{
    public class MyXmlHelper
    {
        #region 公共变量
        XmlDocument xmldoc;
        #endregion

        #region 构造函数
        public MyXmlHelper()
        {
        }
        #endregion

        #region 公共接口
        /// <summary>
        /// 保存配置文件
        /// </summary>
        /// <param name="path"></param>
        /// <param name="softConfig"></param>
        /// <param name="softVerify"></param>
        /// <returns></returns>
        public bool SaveToXml(String path, SoftConfigModel softConfig,SoftVerify softVerify)
        {
            try
            {
                XmlTextWriter writer = new XmlTextWriter(path, System.Text.Encoding.UTF8);
                writer.Formatting = Formatting.Indented;
                writer.WriteStartDocument();
                writer.WriteStartElement("config");
                writer.WriteElementString("softKey", softConfig.softKey!=null? softConfig.softKey.ToString():"");
                writer.WriteElementString("ServerIP", softConfig.softServerIP!=null?softConfig.softServerIP.ToString():"");
                writer.WriteElementString("DataBase", softConfig.softDBName!=null?softConfig.softDBName.ToString():"");
                writer.WriteElementString("User id ", softConfig.softDBUser!=null?softConfig.softDBUser.ToString():"");
                writer.WriteElementString("PWD",softConfig.softDBPwd!=null? softConfig.softDBPwd.ToString():"");
                //writer.WriteEndElement(); // 关闭元素  
                //writer.WriteStartElement("softVerify");
                writer.WriteElementString("RegistCompany",softVerify.CompanyName!=null?softVerify.CompanyName.ToString():"");
                writer.WriteElementString("StarTime",softVerify.StarTime!=null?softVerify.StarTime.ToString():"");
                writer.WriteElementString("EndTime", softVerify.EndTime!=null?softVerify.EndTime.ToString():"");
                writer.WriteEndElement(); // 关闭元素 
                writer.Close();
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// 读取节点信息
        /// </summary>
        /// <param name="NodeName"></param>
        /// <param name="xmlread"></param>
        /// <param name="scfm"></param>
        /// <param name="softVerify"></param>
        private void ChoiceNode(String NodeName, XmlReader xmlread, SoftConfigModel scfm, SoftVerify softVerify)
        {
            if (scfm != null)
            {
                switch (NodeName)
                {
                    case "softKey":
                        {
                            scfm.softKey = xmlread.Value;
                            break;
                        }
                    case "ServerIP":
                        {
                            scfm.softServerIP = xmlread.Value;
                            break;
                        }
                    case "DataBase":
                        {
                            scfm.softDBName = xmlread.Value;
                            break;
                        }
                    case "User id":
                        {
                            scfm.softDBUser = xmlread.Value;
                            break;
                        }
                    case "PWD":
                        {
                            scfm.softDBPwd = xmlread.Value;
                            break;
                        }
                    default:
                        {
                            break;
                        }
                }
            }
            else
            {
                switch (NodeName)
                {
                    case "RegistCompany":
                        {
                            scfm.softKey = xmlread.Value;
                            break;
                        }
                    case "StarTime":
                        {
                            scfm.softServerIP = xmlread.Value;
                            break;
                        }
                    case "EndTime":
                        {
                            scfm.softDBName = xmlread.Value;
                            break;
                        }                    
                    default:
                        {
                            break;
                        }
                }
            }
        }


        /// <summary>
        /// 读取配置信息
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public SoftConfigModel readXMl(String path)
        {
            SoftConfigModel scfm = new SoftConfigModel();
            SoftVerify softVerify = new SoftVerify();
            XmlNodeReader xmlread = null;
            try
            {
                this.xmldoc = new XmlDocument();
                this.xmldoc.Load(path);
                String s = String.Empty;
                XmlNode xn = xmldoc.SelectSingleNode("config");
                xmlread = new XmlNodeReader(xn);
                while (xmlread.Read())
                {
                    if (xmlread.NodeType == XmlNodeType.Element)
                    {
                        s = xmlread.Name;
                    }
                    else
                    {
                        ChoiceNode(s, xmlread, scfm,null);
                    }
                }
                XmlNode xln = xmldoc.SelectSingleNode("softVerify");
                xmlread = new XmlNodeReader(xln);
                while (xmlread.Read())
                {
                    if (xmlread.NodeType == XmlNodeType.Element)
                    {
                        s = xmlread.Name;
                    }
                    else
                    {
                        ChoiceNode(s, xmlread, null, softVerify);
                    }
                }
            }
            finally
            {
                //清除打开的数据流
                if (xmlread != null)
                {
                    xmlread.Close();
                }
            }
            return scfm;
        }


        /// <summary>
        /// 保存登录信息
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public bool SaveLoginToXml(String path)
        {
            try
            {
                XmlTextWriter writer = new XmlTextWriter(path, System.Text.Encoding.UTF8);
                writer.Formatting = Formatting.Indented;
                writer.WriteStartDocument();
                writer.WriteStartElement("loginconfig");
                writer.WriteElementString("ID", SoftUser.UserCode);
                writer.WriteElementString("PWD", SoftUser.PassWorld);
                writer.WriteElementString("CompanyName", SoftUser.UserCompany);
                writer.WriteElementString("BillSet", SoftUser.Op_Bill);
                writer.WriteEndElement(); // 关闭元素 
                writer.Close();
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

