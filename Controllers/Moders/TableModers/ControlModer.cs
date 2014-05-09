using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Controllers.Moders.TableModers
{
    public class ControlModer
    {
        /// <summary>
        /// 控件编号
        /// </summary>
        private int m_CTIID = 0;
        public int CTIID
        { 
            get { return m_CTIID; }
            set { m_CTIID = value; }
        }

        /// <summary>
        /// 控件所属模板编号
        /// </summary>
        private int m_CTITIID = 0;
        public int CTITIID
        {
            get { return m_CTITIID; }
            set { m_CTITIID = value; }
        }

        /// <summary>
        /// 控件名称
        /// </summary>
        private String m_CTIName = String.Empty;
        public String CTIName
        {
            get { return m_CTIName; }
            set { m_CTIName = value; }
        }

        /// <summary>
        /// 控件类型
        /// </summary>
        private String m_CTType ="TextBox";
        public String CTType
        {
            get { return m_CTType; }
            set { m_CTType = value; }
        }

        /// <summary>
        /// 控件默认值
        /// </summary>
        private String m_CTIDefault = String.Empty;
        public String CTIDefault
        {
            get { return m_CTIDefault; }
            set { m_CTIDefault = value; }
        }

        /// <summary>
        /// 控件是否边框
        /// </summary>
        private int m_CTIIsBorder = 1;
        public int CTIIsBorder
        {
            get { return m_CTIIsBorder; }
            set { m_CTIIsBorder = value; }
        }

        /// <summary>
        /// 控件背景是否透明
        /// </summary>
        private int m_CTIIsTransparent = 1;
        public int CTIIsTransparent
        {
            get { return m_CTIIsTransparent; }
            set { m_CTIIsTransparent = value; }
        }

        /// <summary>
        /// 控件字体
        /// </summary>
        private byte[] m_CTIFont = new Common.CommonClass().GetByteByFont(new Font("宋体", 11));
        public byte[] CTIFont
        {
            get { return m_CTIFont; }
            set { m_CTIFont = value; }
        }

        /// <summary>
        /// 控件前景色
        /// </summary>
        private byte[] m_ForeColor = new Common.CommonClass().GetByteByColor(Color.Black);
        public byte[] CTIFontColor
        {
            get { return m_ForeColor; }
            set { m_ForeColor = value; }
        }

        /// <summary>
        /// 控件边框色
        /// </summary>
        private byte[] m_BorerColor = new Common.CommonClass().GetByteByColor(Color.Black);
        public byte[] CTIBorerColor
        {
            get { return m_BorerColor; }
            set { m_BorerColor = value; }
        }

        /// <summary>
        /// 控件背景色
        /// </summary>
        private byte[] m_CTIBackColor = new Common.CommonClass().GetByteByColor(Color.White);
        public byte[] CTIBackColor
        {
            get { return m_CTIBackColor; }
            set { m_CTIBackColor = value; }
        }

        /// <summary>
        /// 控件左边距
        /// </summary>
        private int m_left = 0;
        public int CTILeft
        {
            get { return m_left; }
            set { m_left = value; }
        }

        /// <summary>
        /// 控件上边绝
        /// </summary>
        private int m_CTITop = 0;
        public int CTITop
        {
            get { return m_CTITop; }
            set { m_CTITop = value; }
        }

        /// <summary>
        /// 空间宽度
        /// </summary>
        private int m_CTIWidth = 0;
        public int CTIWidth
        {
            get { return m_CTIWidth; }
            set { m_CTIWidth = value; }
        }

        /// <summary>
        /// 控件高度
        /// </summary>
        private int m_CTIHeight = 0;
        public int CTIHeight
        {
            get { return m_CTIHeight; }
            set { m_CTIHeight = value; }
        }

        /// <summary>
        /// 控件tab键顺序
        /// </summary>
        private int m_CTITabKey = 1;
        public int CTITabKey
        {
            get { return m_CTITabKey; }
            set { m_CTITabKey = value; }
        }

        /// <summary>
        ///控件是否只读
        /// </summary>
        private int m_CTIIsReadOnly = 1;
        public int CTIIsReadOnly
        {
            get { return m_CTIIsReadOnly; }
            set { m_CTIIsReadOnly = value; }
        }

        /// <summary>
        /// 控件是否可见
        /// </summary>
        private int m_CTIVisiable = 1;
        public int CTIVisiable
        {
            get { return m_CTIVisiable; }
            set { m_CTIVisiable = value; }
        }

        /// <summary>
        /// 控件是否必填
        /// </summary>
        private int m_CTIIsMust = 1;
        public int CTIIsMust
        {
            get { return m_CTIIsMust; }
            set { m_CTIIsMust = value; }
        }


        /// <summary>
        /// 控件是否打印
        /// </summary>
        private int m_CTIIsPrint =1;
        public int CTIIsPrint
        {
            get { return m_CTIIsPrint; }
            set { m_CTIIsPrint = value; }
        }

        /// <summary>
        /// 数据源的表名
        /// </summary>
        public String m_CTIBandsTabel = String.Empty;
        public String CTIBandsTabel
        {
            get { return m_CTIBandsTabel; }
            set { m_CTIBandsTabel = value; }
        }

        /// <summary>
        /// 数据源的列名
        /// </summary>
        public String m_CTIBandsCoumln = String.Empty;
        public String CTIBandsCoumln
        {
            get { return m_CTIBandsCoumln; }
            set { m_CTIBandsCoumln = value; }
        }
        /// <summary>
        /// 是否被更新标记
        /// </summary>
        private bool m_updateFlage = false;
        public bool updateFlage
        {
            get { return m_updateFlage; }
            set { m_updateFlage = value; }
        }

        /// <summary>
        /// 新增控件的编号（仅在控件为新增时有效）
        /// </summary>
        private int m_NewNumber = 0;
        public int NewNumber
        {
            get { return m_NewNumber; }
            set { m_NewNumber = value; }
        }
    }
}
