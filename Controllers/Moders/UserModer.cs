﻿//-----------------------------------------------------------------//
//功能：用户实体类                                                 //
//作者：赵建                                                       //
//版本：v1.3                                                      //
//创建时间：2013/10/27   12:34:00                                 //
//最后一次修改时间：2014/3/24   19:22:00                          //
//---------------------------------------------------------------//
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controllers.Moders
{
   public  class UserModer
    {
       /// <summary>
       /// 用户工号
       /// </summary>
       public string ID
       {
           get;
           set;
       }

       /// <summary>
       /// 用户姓名
       /// </summary>
       public string Name
       {
           get;
           set;
       }

       /// <summary>
       /// 用户密码
       /// </summary>
       public string Pwd
       {
           get;
           set;
       }

       /// <summary>
       /// 用户头像
       /// </summary>
       public byte Photo
       {
           get;
           set;
       }

       /// <summary>
       /// 用户性别
       /// </summary>
       public int m_sex;
       public string Sex
       {
           get
           {
               if (this.m_sex == 1)
               {
                   return "男";
               }
               else 
               {
                   return "女";
               }
           }
           set
           {
               if (value == "男")
               {
                   this.m_sex = 1;
               }
               else
               {
                   this.m_sex = 0;
               }
           }
       }


       /// <summary>
       /// 所属公司ID
       /// </summary>
       public int CompanyID
       {
           get;
           set;
       }

       /// <summary>
       /// 所属公司
       /// </summary>
       public string Company
       {
           get;
           set;
       }

       /// <summary>
       /// 所属部门
       /// </summary>
       public string Department
       {
           get;
           set;
       }

       /// <summary>
       /// 职位
       /// </summary>
       public string Position
       {
           get;
           set;
       }

       /// <summary>
       /// 出生日期
       /// </summary>
       public DateTime Birthday
       {
           get;
           set;
       }

       /// <summary>
       /// 入职时间
       /// </summary>
       public DateTime EntryDate
       {
           get;
           set;
       }

       /// <summary>
       /// 备注
       /// </summary>
       public string Remark
       {
           get;
           set;
       }

    }
}
