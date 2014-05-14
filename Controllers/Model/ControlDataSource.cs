//-------------------------------------------------------------------------
// <copyright  company="" path="Controllers.Enum" >
//  Copyright  (c) 版本 V1
//  作者：赵建
//  创建日期：2014-1-24 19：42:20
//  功能描述：该类表示自定义控件绑定的数据源
//  版本历史:    
//</copyright>
//-------------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controllers.Models
{
   public  class ControlDataSource
    {
       /// <summary>
       /// 绑定的表名
       /// </summary>
       public String TableName
       { get; set; }

       /// <summary>
       /// 绑定的列名
       /// </summary>
       public String Column
       { get; set; }


       public ControlDataSource( String table,String couml)
       {
           TableName = table;
           Column = couml;
       }
    }
}
