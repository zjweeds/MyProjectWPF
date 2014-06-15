﻿//---------------------------------------------------------—-----//
//功能：部门信息业务层逻辑                                        //
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
using Controllers.DataAccess;
using System.Data;

namespace Controllers.Business
{
   public  class PositionManage
   {
       /// <summary>
       /// 根据部门返回所有职位
       /// </summary>
       /// <param name="dIID">部门ID</param>
       /// <returns></returns>
       static public DataTable GetAllPositionNameByDepartment(int dIID)
       {
           return PositionService.GetAllPositionNameByDepartment(dIID);
       }
       /// <summary>
       /// 获取职位ID
       /// </summary>
       /// <param name="pIName">职位名称</param>
       /// <param name="dIID">部门ID</param>
       /// <returns></returns>
       static public int GetPositionIDByPositionName(String pIName, int dIID)
       {
           return PositionService.GetPositionIDByPositionName(pIName,dIID);
       }

       /// <summary>
       /// 删除职位信息
       /// </summary>
       /// <param name="pIID">职位ID</param>
       /// <returns></returns>
       static public bool DeletePosition(int pIID)
       {
           return PositionService.DeletePosition(pIID);
       }

       /// <summary>
       /// 添加职位信息
       /// </summary>
       /// <param name="pIName"></param>
       /// <param name="DIID"></param>
       /// <returns></returns>
       public static int AddPosition(String pIName, int DIID)
       {
           return PositionService.AddPosition(pIName, DIID);
       }

       /// <summary>
       /// 更新职位名称
       /// </summary>
       /// <param name="pIName"></param>
       /// <param name="PIID"></param>
       /// <returns></returns>
       public static int UpdatePosition(String pIName, int PIID)
       {
           return PositionService.UpdatePosition(pIName, PIID);
       }
    }
}