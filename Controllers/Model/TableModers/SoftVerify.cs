﻿//---------------------------------------------------------—-----//
//功能：软件验证类                                               //
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

namespace Controllers.Models
{
    public class SoftVerify
    {
        public String CompanyName
        {
            get;
            set;
        }
        public DateTime StarTime
        {
            get;
            set;
        }
        public DateTime EndTime
        {
            get;
            set;
        }
    }
}