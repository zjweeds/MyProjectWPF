using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Controllers.Models
{
    /// <summary>
    /// 控件实体
    /// </summary>
    public class ControlInfo
    {

        private Int32 _cIID;

        public Int32 CIID
        {
            get { return _cIID; }
            set { _cIID = value; }
        }
        private String _cTName;

        public String CTName
        {
            get { return _cTName; }
            set { _cTName = value; }
        }
        private Int32 _cTITIID;

        public Int32 CTITIID
        {
            get { return _cTITIID; }
            set { _cTITIID = value; }
        }
        private String _cTType;

        public String CTType
        {
            get { return _cTType; }
            set { _cTType = value; }
        }
        private String _cTDefault;

        public String CTDefault
        {
            get { return _cTDefault; }
            set { _cTDefault = value; }
        }
        private bool _cTIsBorder = true;

        public bool CTIsBorder
        {
            get { return _cTIsBorder; }
            set { _cTIsBorder = value; }
        }
        private bool _cTIsTransparent = false;

        public bool CTIsTransparent 
        {
            get { return _cTIsTransparent; }
            set { _cTIsTransparent = value; }
        }
        private Int32 _cTLeft;

        public Int32 CTLeft
        {
            get { return _cTLeft; }
            set { _cTLeft = value; }
        }
        private Int32 _cTTop;

        public Int32 CTTop
        {
            get { return _cTTop; }
            set { _cTTop = value; }
        }
        private Int32 _cTWidth;

        public Int32 CTWidth
        {
            get { return _cTWidth; }
            set { _cTWidth = value; }
        }
        private Int32 _cTHeight;

        public Int32 CTHeight
        {
            get { return _cTHeight; }
            set { _cTHeight = value; }
        }
        private Int32 _cTTabKey;

        public Int32 CTTabKey
        {
            get { return _cTTabKey; }
            set { _cTTabKey = value; }
        }
        private bool _cTIsReadOnly = false;

        public bool CTIsReadOnly
        {
            get { return _cTIsReadOnly; }
            set { _cTIsReadOnly = value; }
        }
        private bool _cTVisiable =true;

        public bool CTVisiable
        {
            get { return _cTVisiable; }
            set { _cTVisiable = value; }
        }
        private bool _cTIsMust = true;

        public bool CTIsMust
        {
            get { return _cTIsMust; }
            set { _cTIsMust = value; }
        }
        private bool _cTIsPrint = true;

        public bool CTIsPrint
        {
            get { return _cTIsPrint; }
            set { _cTIsPrint = value; }
        }
        private bool _cTIsEnable = true;

        public bool CTIsEnable
        {
            get { return _cTIsEnable; }
            set { _cTIsEnable = value; }
        }
        private String _cTBandsTabel;

        public String CTBandsTabel
        {
            get { return _cTBandsTabel; }
            set { _cTBandsTabel = value; }
        }
        private String _cTBandsCoumln;

        public String CTBandsCoumln
        {
            get { return _cTBandsCoumln; }
            set { _cTBandsCoumln = value; }
        }
        private String _cTFont;

        public String CTFont
        {
            get { return _cTFont; }
            set { _cTFont = value; }
        }
        private String _cTFontColor;

        public String CTFontColor
        {
            get { return _cTFontColor; }
            set { _cTFontColor = value; }
        }
        private String _cTBorerColor;

        public String CTBorerColor
        {
            get { return _cTBorerColor; }
            set { _cTBorerColor = value; }
        }
        private String _cTBackColor;

        public String CTBackColor
        {
            get { return _cTBackColor; }
            set { _cTBackColor = value; }
        }
        private bool _cTIsFlage = false;

        public bool CTIsFlage
        {
            get { return _cTIsFlage; }
            set { _cTIsFlage = value; }
        }
        private int _cTShowType;

        public int CTShowType
        {
            get { return _cTShowType; }
            set { _cTShowType = value; }
        }
        private int _cTMarkType;

        public int CTMarkType
        {
            get { return _cTMarkType; }
            set { _cTMarkType = value; }
        }
        private Int32 _cTMPShowUnit;

        public Int32 CTMPShowUnit
        {
            get { return _cTMPShowUnit; }
            set { _cTMPShowUnit = value; }
        }
        private Int32 _cTMPHighUnit;

        public Int32 CTMPHighUnit
        {
            get { return _cTMPHighUnit; }
            set { _cTMPHighUnit = value; }
        }
        private Int32 _cTMPLowUnit;

        public Int32 CTMPLowUnit
        {
            get { return _cTMPLowUnit; }
            set { _cTMPLowUnit = value; }
        }
        private Int32 _cTMPBindsID;

        public Int32 CTMPBindsID
        {
            get { return _cTMPBindsID; }
            set { _cTMPBindsID = value; }
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

    }
}
