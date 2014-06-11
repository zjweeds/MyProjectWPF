//---------------------------------------------------------—-----//
//功能：ControlDetail控件明细信息业务层逻辑                        //
//作者：赵建                                                      //
//版本：v1.1                                                      //
//创建时间：2014/3/30   12:55:00                                  //
//最后修改时间：2014/5/30   8:55:00                               //
//---------------------------------------------------------------//

using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using Controllers.Models;
using Controllers.DataAccess;

namespace Controllers.Business
{
    /// <summary>
    ///本逻辑层由Hirer自动生成工具生成
    /// </summary>
    public class ControlDetailManager
    {
        /// <summary>
        /// 添加一个ControlDetail
        /// <param name="controlDetail">对象实例</param>
        public static bool AddControlDetail(ControlDetail controlDetail)
        {
            return ControlDetailService.AddControlDetail(controlDetail) > 0 ? true : false;
        }
    
      
        /// <summary>
        /// 根据CDID删除ControlDetail
        /// <param name="CDID">对象属性</param>
        public static bool DeleteControlDetailByCDID(Int32  _cDID)
        {
            return ControlDetailService.DeleteControlDetailByCDID( _cDID) > 0 ? true : false;
        }
          
           
        /// <summary>
        /// 更新ControlDetail
        /// <param name="controlDetail">新的对象实例</param>
        public static bool UpdateControlDetail(ControlDetail controlDetail)
        {
            ControlDetail controlDetailTemp = ControlDetailService.SelectControlDetailByCDID(controlDetail.CDID);
            controlDetailTemp.CDID = controlDetail.CDID;
            controlDetailTemp.CDCTIID = controlDetail.CDCTIID;
            controlDetailTemp.CDBIID = controlDetail.CDBIID;
            controlDetailTemp.CDText = controlDetail.CDText;
            controlDetailTemp.CDIsEnable = controlDetail.CDIsEnable;
            controlDetailTemp.CDControlType = controlDetail.CDControlType;
            controlDetailTemp.CDTIID = controlDetail.CDTIID;
            return ControlDetailService.UpdateControlDetail(controlDetailTemp) > 0 ? true : false;
        }
          
           
        /// <summary>
        /// 根据CDID查询ControlDetail
        /// <param name="controlDetail">对象实例</param>
        public static ControlDetail SelectControlDetailByCDID(Int32  _cDID)
        {
            return ControlDetailService.SelectControlDetailByCDID( _cDID);
        }
        
        
        /// <summary>
        /// 查询所有ControlDetail
        /// </summary>
        public static IList<ControlDetail> SelectAllControlDetail()
        {
            return  ControlDetailService.SelectAllControlDetail();
        }

        /// <summary>
        /// 批量插入控件明细
        /// </summary>
        /// <param name="cdList"></param>
        /// <returns>1成功，-1失败，0 无更新</returns>
        public static int  AddlControlDetailByList(IList<ControlDetail> cdList)
        {
            return ControlDetailService.AddControlDetailByList(cdList);
        }

        /// <summary>
        /// 存储过程查询账单信息
        /// </summary>
        /// <param name="templateID"></param>
        /// <returns></returns>
        public static DataTable QueryBillInfoCDByPROCEDURE(int templateID)
        {
            return ControlDetailService.QueryBillInfoCDByPROCEDURE(templateID);
        }

        /// <summary>
        /// 根据模板编号查询票据信息
        /// </summary>
        /// <param name="templateID">模板编号</param>
        /// <returns>按账单编号分类的账单信息</returns>
        public static DataTable QueryBillInfoControlsDetailByTemplateID(int templateID)
        {
            IList<Int32> cIIDList = ControlsInfoManager.
                SelectControlsInfoIDByTenplateID(templateID);//查询返回当前模板用到的所有控件ID列表
            return ControlDetailService.QueryBillInfoControlsDetailByCIIDList(cIIDList, templateID);
        }

        /// <summary>
        /// 根据账单信息返回控件明细
        /// </summary>
        /// <param name="bIID"></param>
        /// <returns></returns>
        public static DataTable SeclectControlsDetailByBIID(int bIID)
        {
            return ControlDetailService.SeclectControlsDetailByBIID(bIID);
        }

        /// <summary>
        /// 根据控件文本返回控件明细ID
        /// </summary>
        /// <param name="cDcIID"></param>
        /// <param name="cdText"></param>
        /// <returns></returns>
        public static int SelectCDBIIDByCDText(int cDcIID, String cdText)
        {
            return ControlDetailService.SelectCDBIIDByCDText(cDcIID, cdText);
        }
    }
}
