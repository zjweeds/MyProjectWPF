﻿//---------------------------------------------------------—-----//
//功能：XML文件帮助类                                             //
//作者：赵建                                                      //
//版本：v1.3                                                      //
//创建时间：2014/3/30   12:55:00                                  //
//最后修改时间：2014/3/30   12:55:00                              //
//---------------------------------------------------------------//
using System;
using System.Collections;//哈希表
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Xml;
using Controllers.Moders;
using Controllers.Moders.TableModers;

namespace Controllers.Common
{
    public class MyXmlHelper
    {
        #region 公共变量
        XmlDocument xmldoc;
        #endregion
        public MyXmlHelper()
        {
        }
      
        public bool SaveToXml(string path, SoftConfigModer softConfig,SoftVerify softVerify)
        {
            try
            {
                XmlTextWriter writer = new XmlTextWriter(path, System.Text.Encoding.UTF8);
                writer.Formatting = Formatting.Indented;
                writer.WriteStartDocument();
                writer.WriteStartElement("config");
                writer.WriteElementString("softKey", softConfig.softKey.ToString());
                writer.WriteElementString("ServerIP", softConfig.softServerIP.ToString());
                writer.WriteElementString("DataBase", softConfig.softDBName.ToString());
                writer.WriteElementString("User id ", softConfig.softDBUser.ToString());
                writer.WriteElementString("PWD", softConfig.softDBPwd.ToString());
                writer.WriteEndElement(); // 关闭元素  
                writer.WriteStartElement("softVerify");
                writer.WriteElementString("RegistCompany", softVerify.CompanyName.ToString());
                writer.WriteElementString("StarTime", softVerify.StarTime.ToString());
                writer.WriteElementString("EndTime", softVerify.EndTime.ToString());
                writer.WriteEndElement(); // 关闭元素 
                writer.Close();
                return true;
            }
            catch
            {
                return false;
            }
        }
        private void ChoiceNode(string NodeName, XmlReader xmlread, SoftConfigModer scfm, SoftVerify softVerify)
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

        public SoftConfigModer readXMl(string path)
        {
            SoftConfigModer scfm = new SoftConfigModer();
            SoftVerify softVerify = new SoftVerify();
            XmlNodeReader xmlread = null;
            try
            {
                this.xmldoc = new XmlDocument();
                this.xmldoc.Load(path);
                string s = string.Empty;
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
    }
}

