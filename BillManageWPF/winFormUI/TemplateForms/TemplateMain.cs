

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Controllers.Common;
using MyExtendControls.MyControls.RulePanel;
using MyExtendControls.MyControls.TemplateContorl;
using Controllers.Models;
using Controllers.DataAccess;
using Controllers.Business;
using BillManageWPF.MyCode;
using BillManageWPF.Content.Template;
using Controllers.Enum;

namespace BillManageWPF.winFormUI
{
    public partial class TemplateMain : Form
    {
        #region  构造函数
        public TemplateMain()
        {
            InitializeComponent();
            this.DesignContext.board.Paint += new System.Windows.Forms.PaintEventHandler(this.DesignContext_Paint);
        }
        public TemplateMain(int code)
        {
            InitializeComponent();
            this.btm = BillTemplateManage.SelectTemplateModeltByID(code);//bts.GetTemplateModeltByID(code);
            this.DesignContext.board.Paint += new System.Windows.Forms.PaintEventHandler(this.DesignContext_Paint);
        }
        #endregion

        #region 页面属性值
        public int width;//保存背景图片宽度
        public int height;//保存背景图片高度
        public Image image;//保存图片对象
        public Point offset = new Point(0, 0); //坐标原点
        public int codes; //保存模板编号
        public PickBox pb = null; //响应用户拖拽事件的帮助类
        float fDpiX;//横向分辨率
        float fDpiY;//纵向分辨率
        #region  记录控件个数
        #endregion 
        public BillTemplatModel btm = new BillTemplatModel();
        public List<MyTextBox> mytextList = new List<MyTextBox>();
        public IList<MoneyPanel> mympList = new List<MoneyPanel>();
        public IList<MyDateTimePicker> mydtpList = new List<MyDateTimePicker>();
        public IList<MyCheckBox> mychbList = new List<MyCheckBox>();
        public IList<MyComboBox> mycbbList = new List<MyComboBox>();
        public IList<MyLabel> mylbList = new List<MyLabel>();
        //public ControlService cs = new ControlService();
        #endregion

        #region 自定义方法
      
        #region 毫米到分辨率的单位转换
        private float MillimetersToPixel(float fValue, float fDPI)
        {
            return (fValue / 25.4f) * fDPI;
        }
        #endregion

        #region 窗体图片载入
        /// <summary>
        /// 画图片
        /// </summary>
        private void DesignContext_Paint(object sender, PaintEventArgs e)
        {
            offset = new Point(this.DesignContext.board.Location.X, this.DesignContext.board.Location.Y);
            ////引入图片
            ////左上角顶点
            Point point = new Point(0, 0);
            ////新的大小
            SizeF newSize = new SizeF(width,height);
            ////新的矩形
            RectangleF NewRect = new RectangleF(point, newSize);
            ////原始图形的参数
            SizeF oldSize = new SizeF(image.Width, image.Height);
            ////原始图形的大小
            RectangleF OldRect = new RectangleF(point, oldSize);
            ////缩放图形处理
            e.Graphics.DrawImage(image, NewRect, OldRect, System.Drawing.GraphicsUnit.Pixel);
        }
        #endregion
       
        #region 根据控件对象获取实体

       private ControlInfo GetControlPropery(MyTextBox tmp)
        {

            ControlInfo textModel = new ControlInfo();
            if (tmp != null)
            {
                textModel.CIID = tmp.ControlID;
                textModel.CTITIID = btm.TIID;
                textModel.CTType = "TextBox";
                textModel.CTName = tmp.Text;
                textModel.CTDefault = tmp.DefaultValue;
                textModel.CTTabKey = tmp.TabIndex;
                textModel.CTShowType = tmp.showType;
                textModel.CTMarkType = tmp.markType;
                textModel.CTIsBorder = (tmp.BorderStyle == BorderStyle.None ? false : true);
                textModel.CTIsTransparent = (tmp.BorderStyle == BorderStyle.None ? true : false);
                textModel.CTVisiable = tmp.Visible;
                textModel.CTTop = tmp.Top;
                textModel.CTLeft = tmp.Left;
                textModel.CTWidth = tmp.Width;
                textModel.CTHeight = tmp.Height;
                if (tmp.txtDatasource != null)
                {
                    textModel.CTBandsTabel = tmp.txtDatasource.TableName;
                    textModel.CTBandsCoumln = tmp.txtDatasource.Column;
                }
                textModel.CTIsReadOnly = tmp.ReadOnly; 
                textModel.CTIsFlage = tmp.IsFlage ;
                textModel.CTFont = new CommonClass().GetStringByFont(tmp.Font);
                textModel.CTFontColor = System.Drawing.ColorTranslator.ToHtml(tmp.ForeColor);
                textModel.CTBackColor = System.Drawing.ColorTranslator.ToHtml(tmp.BackColor);
                textModel.CTIsMust = tmp.IsMust;
                textModel.CTIsPrint = tmp.IsPrint;
                textModel.updateFlage = tmp.UpdateFlage;
            }
            return textModel;

        }
        private ControlInfo GetControlPropery(MyLabel tmp)
        {
            ControlInfo textModel = new ControlInfo();
            if (tmp != null)
            {
                textModel.CIID = tmp.ControlID;
                textModel.CTITIID = btm.TIID;
                textModel.CTType = "Label";
                textModel.CTName = tmp.ControlName;
                textModel.CTDefault = tmp.DefaultValue;
                textModel.CTTabKey = tmp.TabIndex;
                textModel.CTIsBorder = (tmp.BorderStyle == BorderStyle.None ? true :false);
                textModel.CTIsTransparent = (tmp.BorderStyle == BorderStyle.None ? true : false);
                textModel.CTVisiable = tmp.Visible;
                textModel.CTTop = tmp.Top;
                textModel.CTLeft = tmp.Left;
                textModel.CTWidth = tmp.Width;
                textModel.CTHeight = tmp.Height;
                if (tmp.txtDatasource != null)
                {
                    textModel.CTBandsTabel = tmp.txtDatasource.TableName;
                    textModel.CTBandsCoumln = tmp.txtDatasource.Column;
                }
                textModel.CTFont = new CommonClass().GetStringByFont(tmp.Font);
                textModel.CTFontColor = System.Drawing.ColorTranslator.ToHtml(tmp.ForeColor);
                textModel.CTBackColor = System.Drawing.ColorTranslator.ToHtml(tmp.BackColor);
                textModel.CTIsPrint = tmp.IsPrint;
                textModel.updateFlage = tmp.UpdateFlage;

            }
            return textModel;
        }

        private ControlInfo GetControlPropery(MyCheckBox tmp)
        {
            ControlInfo textModel = new ControlInfo();
            if (tmp != null)
            {
                textModel.CIID = tmp.ControlID;
                textModel.CTITIID = btm.TIID;
                textModel.CTType = "CheckBox";
                textModel.CTName = tmp.ControlName;
                textModel.CTDefault = tmp.DefaultValue;
                textModel.CTTabKey = tmp.TabIndex;
                textModel.CTVisiable = tmp.Visible;
                textModel.CTTop = tmp.Top;
                textModel.CTLeft = tmp.Left;
                textModel.CTWidth = tmp.Width;
                textModel.CTHeight = tmp.Height;
                if (tmp.txtDatasource != null)
                {
                    textModel.CTBandsTabel = tmp.txtDatasource.TableName;
                    textModel.CTBandsCoumln = tmp.txtDatasource.Column;
                }
                textModel.CTFont = new CommonClass().GetStringByFont(tmp.Font);
                textModel.CTFontColor = System.Drawing.ColorTranslator.ToHtml(tmp.ForeColor);
                textModel.CTBackColor = System.Drawing.ColorTranslator.ToHtml(tmp.BackColor);
                textModel.CTIsMust = tmp.IsMust;
                textModel.CTIsPrint = tmp.IsPrint;
                textModel.updateFlage = tmp.UpdateFlage;
            }
            return textModel;
        }

        private ControlInfo GetControlPropery(MyComboBox tmp)
        {
            ControlInfo textModel = new ControlInfo();
            if (tmp != null)
            {
                textModel.CIID = tmp.ControlID;
                textModel.CTITIID = btm.TIID;
                textModel.CTType = "ComboBox";
                textModel.CTName = tmp.ControlName;
                textModel.CTDefault = tmp.DefaultValue;
                textModel.CTTabKey = tmp.TabIndex;
                textModel.CTVisiable = tmp.Visible;
                textModel.CTTop = tmp.Top;
                textModel.CTLeft = tmp.Left;
                textModel.CTWidth = tmp.Width;
                textModel.CTHeight = tmp.Height;
                if (tmp.txtDatasource != null)
                {
                    textModel.CTBandsTabel = tmp.txtDatasource.TableName;
                    textModel.CTBandsCoumln = tmp.txtDatasource.Column;
                }
                textModel.CTFont = new CommonClass().GetStringByFont(tmp.Font);
                textModel.CTFontColor = System.Drawing.ColorTranslator.ToHtml(tmp.ForeColor);
                textModel.CTBackColor = System.Drawing.ColorTranslator.ToHtml(tmp.BackColor);
                textModel.CTIsMust = tmp.IsMust;
                textModel.CTIsPrint = tmp.IsPrint;
                textModel.CTMarkType = tmp.MarkType;
                textModel.updateFlage = tmp.UpdateFlage;
            }
            return textModel;
        }

        private ControlInfo GetControlPropery(MyDateTimePicker tmp)
        {
            ControlInfo textModel = new ControlInfo();
            if (tmp != null)
            {
                textModel.CIID = tmp.ControlID;
                textModel.CTITIID = btm.TIID;
                textModel.CTType = "DateTimePicker";
                textModel.CTName = tmp.ControlName;
                textModel.CTDefault = tmp.DefaultValue;
                textModel.CTTabKey = tmp.TabIndex;
                textModel.CTVisiable = tmp.Visible;
                textModel.CTTop = tmp.Top;
                textModel.CTLeft = tmp.Left;
                textModel.CTWidth = tmp.Width;
                textModel.CTHeight = tmp.Height;
                if (tmp.txtDatasource != null)
                {
                    textModel.CTBandsTabel = tmp.txtDatasource.TableName;
                    textModel.CTBandsCoumln = tmp.txtDatasource.Column;
                }
                textModel.CTFont = new CommonClass().GetStringByFont(tmp.Font);
                textModel.CTFontColor = System.Drawing.ColorTranslator.ToHtml(tmp.ForeColor);
                textModel.CTBackColor = System.Drawing.ColorTranslator.ToHtml(tmp.BackColor);
                textModel.CTIsMust = tmp.IsMust;
                textModel.CTIsPrint = tmp.IsPrint;
                textModel.updateFlage = tmp.UpdateFlage;
            }
            return textModel;
        }
        private ControlInfo GetControlPropery(MoneyPanel mp)
        {
            ControlInfo moneypanel = new ControlInfo();
            if (mp != null)
            {
                moneypanel.CIID = mp.ControlID;
                moneypanel.CTITIID = btm.TIID;
                moneypanel.CTType = "MoneyPanel";
                moneypanel.CTName = mp.ControlName;
                moneypanel.CTDefault = mp.DefaultValue;
                moneypanel.CTFont = new CommonClass().GetStringByFont(mp.Font);
                moneypanel.CTFontColor = System.Drawing.ColorTranslator.ToHtml(mp.ForeColor);
                moneypanel.CTBackColor = System.Drawing.ColorTranslator.ToHtml(mp.BackColor);
                moneypanel.CTVisiable = mp.Visible;
                moneypanel.CTIsMust = mp.IsMust;
                moneypanel.CTIsPrint = mp.IsPrint;
                moneypanel.CTTabKey = mp.TabIndex;
                moneypanel.CTTop = mp.Top;
                moneypanel.CTLeft = mp.Left;
                moneypanel.CTWidth = mp.Width;
                moneypanel.CTMPShowUnit = mp.IsShowUnit ? 1 : 0;
                moneypanel.CTHeight = mp.Height;
                moneypanel.CTMPLowUnit = mp.Low;
                moneypanel.CTMPHighUnit = mp.Hight;
                moneypanel.CTMPBindsID = mp.BindsID;
                moneypanel.updateFlage = mp.UpdateFlage; ;
            }
            return moneypanel;
        }

        private List<ControlInfo> GetControlsList(Control panel)
        {
            List<ControlInfo> ctrList = new List<ControlInfo>();
            foreach (Control con in panel.Controls)
            {
                if (con.GetType() == typeof(MyTextBox))
                {
                    ctrList.Add(GetControlPropery(con as MyTextBox));
                }
                else if (con.GetType() == typeof(MyComboBox))
                {
                    ctrList.Add(GetControlPropery(con as MyComboBox));
                }
                else if (con.GetType() == typeof(MyCheckBox))
                {
                    ctrList.Add(GetControlPropery(con as MyCheckBox));
                }
                else if (con.GetType() == typeof(MyLabel))
                {
                    ctrList.Add(GetControlPropery(con as MyLabel));
                }
                else if (con.GetType() == typeof(MyDateTimePicker))
                {
                    ctrList.Add(GetControlPropery(con as MyDateTimePicker));
                }
                else if (con.GetType() == typeof(MoneyPanel))
                {
                    ctrList.Add(GetControlPropery(con as MoneyPanel));
                }
            }
            return ctrList;
        }
        
        /// <summary>
        /// 控件删除接口
        /// </summary>
        /// <param name="ControlsID">控件编号</param>
        /// <param name="type">控件类型</param>
        public void DeleteControlsByID(int ControlsID)
        {
            ControlsInfoManager.DeleteControlInfoByCIID(ControlsID);
        }
        #endregion
        
        /// <summary>
        /// 根据实体列表，保存控件信息到数据库
        /// </summary>
        /// <param name="textList">TextBox实体列表</param>
        private void SaveToDataBase(List<ControlInfo> textList)
        {
            if (textList != null && textList.Count > 0)
            {
                if (textList.Find((delegate(ControlInfo p) { return p.CTIsFlage ==true; })) != null)
                {
                   int result = ControlsInfoManager.SaveControlsToDataBase(textList);
                    if (result > 0)
                    {
                        MessageBox.Show("保存成功！", "提示");
                    }
                    else if (result < 0)
                    {
                        MessageBox.Show("保存失败！", "提示");
                    }
                    else
                    {
                        MessageBox.Show("模板无控件更新！", "提示");
                    }
                }
                else
                {
                    MessageBox.Show("此模板未添加单据号输入框！无法保存，请先指定单据号输入框？", "提示");
                    return;                    
                }
            }
            else
            {
                MessageBox.Show("此模板没有任何控件！", "提示");
                return; 
            }

        }

        /// <summary>
        /// 根据模板编号，分类查询控件列表
        /// </summary>
        /// <param name="templateID">模板编号</param>
        private void LoadAllControls(int templateID)
        {
            try
            {
                List<ControlInfo> ctList = ControlsInfoManager.SelectControlInfosByTemplateID(templateID) as List<ControlInfo>;
                AddControl(ctList);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "提示", System.Windows.Forms.MessageBoxButtons.OK);
                return;
            }
        }

        private void AddControl(List<ControlInfo> ctList)
        {
            if (ctList != null && ctList.Count > 0)
            {
                foreach (ControlInfo cm in ctList)
                {
                    switch (cm.CTType)
                    {
                        case "TextBox":
                            {
                                #region TextBox
                                MyTextBox textbox = new MyTextBox();
                                textbox.Text = cm.CTName;
                                textbox.ControlID = cm.CIID;
                                textbox.ControlName = cm.CTName;
                                textbox.DefaultValue = cm.CTDefault;
                                textbox.BorderStyle = cm.CTIsBorder ? BorderStyle.FixedSingle : BorderStyle.None;
                                //textbox.BackColor = cm.CTIsTransparent != 0 ?
                                //                    Color.Transparent : ColorTranslator.FromHtml(cm.CTBackColor);
                                textbox.Left = cm.CTLeft;
                                textbox.Top = cm.CTTop;
                                textbox.Width = cm.CTWidth;
                                textbox.Height = cm.CTHeight;
                                textbox.TabIndex = cm.CTTabKey;
                                textbox.ReadOnly = cm.CTIsReadOnly;
                                textbox.Visible = cm.CTVisiable;
                                textbox.IsMust = cm.CTIsMust;
                                textbox.IsPrint = cm.CTIsPrint;
                                textbox.txtDatasource = new ControlDataSource(cm.CTBandsTabel, cm.CTBandsCoumln);
                                textbox.Font = new CommonClass().GetFontByString(cm.CTFont);
                                textbox.ForeColor = ColorTranslator.FromHtml(cm.CTFontColor);
                                textbox.BackColor = ColorTranslator.FromHtml(cm.CTBackColor);
                                textbox.IsFlage = cm.CTIsFlage;
                                textbox.showType = cm.CTShowType;
                                textbox.markType = cm.CTMarkType;
                                pb.WireControl(textbox);
                                this.DesignContext.board.Controls.Add(textbox);
                                #endregion
                                break;
                            }
                        case "Label":
                            {
                                #region Label
                                MyLabel label = new MyLabel();
                                label.ControlID = cm.CIID;
                                label.ControlName = cm.CTName;
                                label.Text = cm.CTName;
                                label.DefaultValue = cm.CTDefault;
                                label.BorderStyle = cm.CTIsBorder ? BorderStyle.FixedSingle : BorderStyle.None;
                                label.BackColor = cm.CTIsTransparent?
                                                    Color.Transparent : ColorTranslator.FromHtml(cm.CTFontColor);
                                label.Font = new CommonClass().GetFontByString(cm.CTFont);
                                label.ForeColor = ColorTranslator.FromHtml(cm.CTFontColor);
                                label.BackColor = ColorTranslator.FromHtml(cm.CTBackColor);
                                label.Left = cm.CTLeft;
                                label.Top = cm.CTTop;
                                label.Width = cm.CTWidth;
                                label.Height = cm.CTHeight;
                                label.TabIndex = cm.CTTabKey;
                                //label.ReadOnly = cm.CTIsReadOnly != 0 ? true : false;
                                label.Visible = cm.CTVisiable;
                                //cbbs.Add(label);
                                pb.WireControl(label);
                                this.DesignContext.board.Controls.Add(label);
                                #endregion
                                break;
                            }
                        case "ComboBox":
                            {
                                #region ComboBox
                                MyComboBox combobox = new MyComboBox();
                                combobox.Text = cm.CTName;
                                combobox.ControlID = cm.CIID;
                                combobox.ControlName = cm.CTName;
                                combobox.DefaultValue = cm.CTDefault;
                                //combobox.BorderStyle = cm.CTIsBorder == 0 ? BorderStyle.None : BorderStyle.FixedSingle;
                                combobox.BackColor = cm.CTIsTransparent?
                                                    Color.Transparent : ColorTranslator.FromHtml(cm.CTFontColor);
                                combobox.Font = new CommonClass().GetFontByString(cm.CTFont);
                                combobox.ForeColor = ColorTranslator.FromHtml(cm.CTFontColor);
                                combobox.BackColor = ColorTranslator.FromHtml(cm.CTBackColor);
                                combobox.Left = cm.CTLeft;
                                combobox.Top = cm.CTTop;
                                combobox.Width = cm.CTWidth;
                                combobox.Height = cm.CTHeight;
                                combobox.TabIndex = cm.CTTabKey;
                                //combobox.ReadOnly = cm.CTIsReadOnly != 0 ? true : false;
                                combobox.Visible = cm.CTVisiable;
                                combobox.IsMust = cm.CTIsMust;
                                combobox.MarkType = cm.CTMarkType;
                                //cbbs.Add(combobox);
                                pb.WireControl(combobox);
                                this.DesignContext.board.Controls.Add(combobox);
                                #endregion
                                break;
                            }
                        case "CheckBox":
                            {
                                #region CheckBox
                                MyCheckBox checkbox = new MyCheckBox();
                                checkbox.Text = cm.CTName;
                                checkbox.ControlID = cm.CIID;
                                checkbox.ControlName = cm.CTName;
                                checkbox.DefaultValue = cm.CTDefault;
                                //checkbox.BorderStyle = cm.CTIsBorder == 0 ? BorderStyle.None : BorderStyle.FixedSingle;
                                checkbox.BackColor = cm.CTIsTransparent ?
                                                    Color.Transparent : ColorTranslator.FromHtml(cm.CTFontColor);
                                checkbox.Font = new CommonClass().GetFontByString(cm.CTFont);
                                checkbox.ForeColor = ColorTranslator.FromHtml(cm.CTFontColor);
                                checkbox.BackColor = ColorTranslator.FromHtml(cm.CTBackColor);
                                checkbox.Left = cm.CTLeft;
                                checkbox.Top = cm.CTTop;
                                checkbox.Width = cm.CTWidth;
                                checkbox.Height = cm.CTHeight;
                                checkbox.TabIndex = cm.CTTabKey;
                                //checkbox.ReadOnly = cm.CTIsReadOnly != 0 ? true : false;
                                checkbox.Visible = cm.CTVisiable ;
                                checkbox.IsMust = cm.CTIsMust;
                                //cbbs.Add(checkbox);
                                pb.WireControl(checkbox);
                                this.DesignContext.board.Controls.Add(checkbox);
                                #endregion
                                break;
                            }
                        case "DateTimePicker":
                            {
                                #region DateTimePicker
                                MyDateTimePicker dateTimePicker = new MyDateTimePicker();
                                dateTimePicker.ControlID = cm.CIID;
                                dateTimePicker.ControlName = cm.CTName;
                                dateTimePicker.DefaultValue = cm.CTDefault;
                                //dateTimePicker.BorderStyle = cm.CTIsBorder == 0 ? BorderStyle.None : BorderStyle.FixedSingle;
                                dateTimePicker.BackColor = cm.CTIsTransparent?
                                                    Color.Transparent : ColorTranslator.FromHtml(cm.CTFontColor);
                                dateTimePicker.Font = new CommonClass().GetFontByString(cm.CTFont);
                                dateTimePicker.ForeColor = ColorTranslator.FromHtml(cm.CTFontColor);
                                dateTimePicker.Left = cm.CTLeft;
                                dateTimePicker.Top = cm.CTTop;
                                dateTimePicker.Width = cm.CTWidth;
                                dateTimePicker.Height = cm.CTHeight;
                                dateTimePicker.TabIndex = cm.CTTabKey;
                                //dateTimePicker.ReadOnly = cm.CTIsReadOnly != 0 ? true : false;
                                dateTimePicker.Visible = cm.CTVisiable;
                                //cbbs.Add(dateTimePicker);
                                pb.WireControl(dateTimePicker);
                                this.DesignContext.board.Controls.Add(dateTimePicker);
                                #endregion
                                break;
                            }
                        default:
                            {
                                #region 金额明细
                                MoneyPanel moneyPanel = new MoneyPanel();
                                moneyPanel.ControlID = cm.CIID;
                                moneyPanel.ControlName = cm.CTName;
                                moneyPanel.BorderStyle = cm.CTIsBorder ? BorderStyle.FixedSingle : BorderStyle.None;
                                moneyPanel.BackColor = cm.CTIsTransparent?
                                                    Color.Transparent : ColorTranslator.FromHtml(cm.CTFontColor);
                                moneyPanel.Font = new CommonClass().GetFontByString(cm.CTFont);
                                moneyPanel.ForeColor = ColorTranslator.FromHtml(cm.CTFontColor);
                                moneyPanel.BackColor = ColorTranslator.FromHtml(cm.CTBackColor);
                                moneyPanel.Left = cm.CTLeft;
                                moneyPanel.Top = cm.CTTop;
                                moneyPanel.Width = cm.CTWidth;
                                moneyPanel.Height = cm.CTHeight;
                                moneyPanel.TabIndex = cm.CTTabKey;
                                moneyPanel.Visible = cm.CTVisiable ;
                                moneyPanel.IsMust = cm.CTIsMust;
                                moneyPanel.Hight = cm.CTMPHighUnit;
                                moneyPanel.Low = cm.CTMPLowUnit;
                                moneyPanel.IsShowUnit = cm.CTMPShowUnit != 0 ? true : false;
                                pb.WireControl(moneyPanel);
                                this.DesignContext.board.Controls.Add(moneyPanel);
                                #endregion
                                break;
                            }
                    }
                }
            }
 
        }
      
        public int AddTextControlByNewNumber(int newNumber)
        {
            MyTextBox mtb = mytextList.Find((delegate(MyTextBox p) { return p.NewNumber == newNumber; }));
            if(mtb!=null)
            {
                mtb.ControlID = ControlsInfoManager.AddControlInfo(this.GetControlPropery(mtb));
                mytextList.Find((delegate(MyTextBox p) { return p.NewNumber == newNumber; })).ControlID = mtb.ControlID;
                return mtb.ControlID;
            }
            return 1;
        }
        #endregion

        #region 窗体事件
        /// <summary>
        /// 窗口载入事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Template_Load(object sender, EventArgs e)
        {
            try
            {
                fDpiX = this.CreateGraphics().DpiX;
                fDpiY = this.CreateGraphics().DpiY;
                image = new ImageHelper().GetImageByByte(btm.TIBackground);
                width = Convert.ToInt32(MillimetersToPixel(Convert.ToSingle(btm.TIWidth), fDpiX));
                height = Convert.ToInt32(MillimetersToPixel(Convert.ToSingle(btm.TIHeight), fDpiY));
                DesignContext.board.Width = width;
                DesignContext.board.Height = height;
                // DesignContext.board.Invalidate();
                pb = new PickBox(this);
                LoadAllControls(btm.TIID);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "软件提示");
            }
        }

        /// <summary>
        /// 模板属性修改
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SetTemplatePropery_Click(object sender, EventArgs e)
        {
            try
            {
                TemplateProperyEdit tpe = new TemplateProperyEdit(btm);
                tpe.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "软件提示");
            }
        }

        /// <summary>
        /// 退出事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        #region  控件添加事件
        /// <summary>
        /// 添加标签框
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AddLabel_Click(object sender, EventArgs e)
        {
            try
            {
                MyLabel label = new MyLabel();
                label.NewNumber = mylbList != null ? mylbList.Count : 0;
                label.ControlID = 0;
                label.ControlName = "label" + label.NewNumber.ToString();
                mylbList.Add(label);
                pb.WireControl(label);
                this.DesignContext.board.Controls.Add(label);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "软件提示");
            }
        }

        /// <summary>
        /// 添加文本框
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AddTextBox_Click(object sender, EventArgs e)
        {
            try
            {
                MyTextBox label = new MyTextBox();
                label.NewNumber = mytextList != null ? mytextList.Count : 0;
                label.ControlID = 0;
                label.ControlName = "TextBox" + label.NewNumber.ToString();
                mytextList.Add(label);
                pb.WireControl(label);
                this.DesignContext.board.Controls.Add(label);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "软件提示");
            }
        }

        /// <summary>
        /// 添加检验框
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AddCheckBox_Click(object sender, EventArgs e)
        {
            try
            {
                MyCheckBox label = new MyCheckBox();
                label.NewNumber = mychbList != null ? mychbList.Count : 0;
                label.ControlID = 0;
                label.ControlName = "CheckBox" + label.NewNumber.ToString();
                mychbList.Add(label);
                pb.WireControl(label);
                this.DesignContext.board.Controls.Add(label);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "软件提示");
            }
        }

        /// <summary>
        /// 添加下拉框
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AddComboBox_Click(object sender, EventArgs e)
        {
            try
            {
                MyComboBox label = new MyComboBox();
                label.NewNumber = mycbbList != null ? mycbbList.Count : 0;
                label.ControlID = 0;
                label.ControlName = "ComboBox" + label.NewNumber.ToString();
                mycbbList.Add(label);
                pb.WireControl(label);
                this.DesignContext.board.Controls.Add(label);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "软件提示");
            }
        }

        /// <summary>
        /// 添加日历
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AddDateTimePicker_Click(object sender, EventArgs e)
        {
            try
            {
                MyDateTimePicker label = new MyDateTimePicker();
                label.NewNumber = mydtpList != null ? mydtpList.Count : 0;
                label.ControlID = 0;
                label.ControlName = "DateTimePicker" + label.NewNumber.ToString();
                mydtpList.Add(label);
                pb.WireControl(label);
                this.DesignContext.board.Controls.Add(label);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "软件提示");
            }
        }

        /// <summary>
        /// 添加金额框
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AddMyMoneyPanel_Click(object sender, EventArgs e)
        {
            try
            {
                MoneyPanel mp = new MoneyPanel();
                mp.NewNumber = mympList != null ? mympList.Count : 0;
                mp.ControlID = 0;
                mp.ControlName = "MoneyPanel" + mp.NewNumber.ToString();
                mympList.Add(mp);
                pb.WireControl(mp);
                this.DesignContext.board.Controls.Add(mp);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "软件提示");
            }
        }
        #endregion
        /// <summary>
        /// 保存功能
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Save_Click(object sender, EventArgs e)
        {
            try
            {
                List<ControlInfo> ctlList = GetControlsList(this.DesignContext.board);
                SaveToDataBase(ctlList);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "软件提示");
            }
        }

        /// <summary>
        /// 鼠标经过工具栏时改变颜色
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolSave_MouseEnter(object sender, EventArgs e)
        {
            try
            {
                ToolStripButton tsb = sender as ToolStripButton;
                if (tsb != null)
                {
                    tsb.BackColor = Color.Orchid;
                    tsb.ForeColor = Color.WhiteSmoke;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "软件提示");
            }
        }

        /// <summary>
        /// 鼠标离开时恢复颜色
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolSave_MouseLeave(object sender, EventArgs e)
        {
            try
            {
                ToolStripButton tsb = sender as ToolStripButton;
                if (tsb != null)
                {
                    tsb.BackColor = Color.SkyBlue;
                    tsb.ForeColor = Color.White;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "软件提示");
            }
        }

        /// <summary>
        /// 窗体关闭时
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TemplateMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                e.Cancel = false;//可以关闭
                List<ControlInfo> con = new List<ControlInfo>();
                if (con.Exists(itm => itm.updateFlage == true))
                {
                    if (MessageBox.Show("模板设置信息已被更新，是否保存？", "软件提示", System.Windows.Forms.MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        Save_Click(sender, e);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "软件提示");
            }
        }

        /// <summary>
        /// 窗体关闭后
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TemplateMain_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Dispose();//释放资源
        }

        #endregion
    }
}
