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
                writer.WriteElementString("Userid", softConfig.softDBUser!=null?softConfig.softDBUser.ToString():"");
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
                    case "Userid":
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
        /// 读取节点信息
        /// </summary>
        /// <param name="NodeName"></param>
        /// <param name="xmlread"></param>
        /// <param name="scfm"></param>
        private void ChoiceNode(String NodeName, XmlReader xmlread, SoftConfigModel scfm)
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
                case "Userid":
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

        /// <summary>
        /// 读取配置信息
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public SoftConfigModel readXMl(String path)
        {
            SoftConfigModel scfm = new SoftConfigModel();
          XmlDocument xmlDoc = new XmlDocument();
          try
          {
              xmlDoc.Load(path);
              XmlNode root = xmlDoc.SelectSingleNode("//config");//当节点Workflow带有属性是，使用SelectSingleNode无法读取          
              if (root != null)
              {
                  scfm.softServerIP = (root.SelectSingleNode("ServerIP")).InnerText;
                  scfm.softDBName = (root.SelectSingleNode("DataBase")).InnerText;
                  scfm.softDBUser = (root.SelectSingleNode("Userid")).InnerText;
                  scfm.softDBPwd = (root.SelectSingleNode("PWD")).InnerText;
              }
          }
          catch (Exception ex)
          {
              throw ex;
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
                writer.WriteElementString("PWD", EnCryption.MiYao(SoftUser.PassWorld));
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

        public  UserItem ReadLoginInfo(String path)
        { 
          XmlDocument xmlDoc = new XmlDocument();
          UserItem usei =new UserItem();
          try
          {
              xmlDoc.Load(path);
              XmlNode root = xmlDoc.SelectSingleNode("//loginconfig");//当节点Workflow带有属性是，使用SelectSingleNode无法读取          
              if (root != null)
              {
                  usei.UserCode = (root.SelectSingleNode("ID")).InnerText;
                  usei.PassWorld = EnCryption.JieMi((root.SelectSingleNode("PWD")).InnerText);
                  usei.UserCompany = (root.SelectSingleNode("CompanyName")).InnerText;
                  usei.Op_Bill = (root.SelectSingleNode("BillSet")).InnerText;
              }
          }
          catch (Exception ex)
          {
              throw ex;
          }
          return usei;
        }

        #endregion

    }
}

