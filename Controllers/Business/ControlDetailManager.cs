using System;
using System.Collections.Generic;
using System.Text;
using Controllers.Models;
using Controllers.DAL;
namespace Controllers.BLL
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
    }
}
