

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
using System.Runtime.InteropServices;
using Controllers.Models;
using Controllers.DataAccess;
using BillManageWPF.MyCode;
using BillManageWPF.Content.Template;
using FirstFloor.ModernUI.Windows.Controls;
using Controllers.Enum;

namespace BillManageWPF.Forms
{
    public partial class TemplateMain : Form
    {
        #region  构造函数
        public TemplateMain()
        {
            InitializeComponent();
        }
        public TemplateMain(int code)
        {
            InitializeComponent();
            this.btm = bts.GetTemplateModeltByID(code);
        }
        #endregion

        #region 页面属性值
        public int width;//保存背景图片宽度
        public int height;//保存背景图片高度
        public Image image;//保存图片对象
        public Point offset = new Point(0, 0); //坐标原点
        public int codes; //保存模板编号
        public PickBox pb = null; 
        float fDpiX;//横向分辨率
        float fDpiY;//纵向分辨率
        private int labelCount = 0;
        private int TextConut = 0;
        private int checkboxCount = 0;
        private int comboboxCount = 0;
        private int datetimerConut = 0;
        private int moneypanelCount=0;
        public BillTemplateService bts = new BillTemplateService();
        public BillTemplatModel btm = new BillTemplatModel();
        public List<ControlModel> cmlist = new List<ControlModel>();
        public List<TextBoxExtendModel> tbemLsit = new List<TextBoxExtendModel>();
        public List<MoneyPanelExtendModel> mpemList = new List<MoneyPanelExtendModel>();
        public ControlService cs = new ControlService();
        #endregion

        #region 自定义方法
        public static double MillimetersToPixelsWidth(double length) //length是毫米，1厘米=10毫米
        {
            System.Windows.Forms.Panel p = new System.Windows.Forms.Panel();
            System.Drawing.Graphics g = System.Drawing.Graphics.FromHwnd(p.Handle);
            IntPtr hdc = g.GetHdc();
            int width = GetDeviceCaps(hdc, 4);     // HORZRES 
            int pixels = GetDeviceCaps(hdc, 8);     // BITSPIXEL
            g.ReleaseHdc(hdc);
            return (((double)pixels / (double)width) * (double)length);
        }

        #region 毫米到分辨率的单位转换
        [DllImport("gdi32.dll")]
        private static extern int GetDeviceCaps(IntPtr hdc, int Index);
        private float MillimetersToPixel(float fValue, float fDPI)
        {
            return (fValue / 25.4f) * fDPI;
        }
        #endregion

        #region 窗体图片载入
        private void DesignContext_Paint()
        {
            offset = new Point(this.DesignContext.board.Location.X, this.DesignContext.board.Location.Y);
            // MessageBox.Show("X:"+offset.X.ToString()+"\n Y:"+offset.Y.ToString());
            ////引入图片
            ////Image img = cc.GetImageByBytes(dt.Rows[0]["背景图片"] as byte[]);
            ////左上角顶点
            Point point = new Point(0, 0);
            ////新的大小
            SizeF newSize = new SizeF(MillimetersToPixel(width, fDpiX), MillimetersToPixel(height, fDpiY));
            ////新的矩形
            RectangleF NewRect = new RectangleF(point, newSize);
            ////原始图形的参数
            SizeF oldSize = new SizeF(image.Width, image.Height);
            ////原始图形的大小
            RectangleF OldRect = new RectangleF(point, oldSize);
            ////缩放图形处理
            //e.Graphics.DrawImage(image, NewRect, OldRect, System.Drawing.GraphicsUnit.Pixel);
            Image newImg = image.GetThumbnailImage(width, height, new Image.GetThumbnailImageAbort(IsTrue), IntPtr.Zero);
            this.DesignContext.board.BackgroundImageLayout = ImageLayout.Stretch;
            this.DesignContext.board.BackgroundImage = image;
            ////若新图形的宽度或高度大于窗体的宽度或高度，窗体会自行调整
            if (newSize.Width > this.DesignContext.board.Width || newSize.Height > this.DesignContext.board.Height)
            {
                Size size = new System.Drawing.Size(width, height);//new Size(Convert.ToInt32(MillimetersToPixel(width, fDpiX)), Convert.ToInt32(MillimetersToPixel(height, fDpiY)));
                FormAutoResize(size);
            }
        }
        public void FormAutoResize(Size size)
        {
            //获取窗体原始Size
            int intOldWidth = this.DesignContext.board.Width;
            int intOldHeight = this.DesignContext.board.Height;
            //设置窗体新的Size
            this.DesignContext.board.Width = size.Width + 50;
            this.DesignContext.board.Height = size.Height + 70;
            //设置新的位置(Location)居中
            //this.DesignContext.board.Location = new Point(this.DesignContext.board.Location.X - (this.DesignContext.board.Width - intOldWidth) / 2, this.DesignContext.board.Location.Y - (this.DesignContext.board.Height - intOldHeight) / 2);
        }
        private static bool IsTrue() // 在Image类别对图片进行缩放的时候,需要一个返回bool类别的委托
        {
            return true;
        }
        #endregion

        #region  得到按类别分类的控件集合
        public List<MyCheckBox> GetMyCheckBoxs(Control control)
        {
            List<MyCheckBox> ctxts = new List<MyCheckBox>();
            foreach (Control con in control.Controls)
            {
                if (con.GetType() == typeof(MyCheckBox))
                {
                    ctxts.Add((MyCheckBox)con);
                }
                if (con.GetType() == typeof(GroupBox))
                {
                    this.GetMyCheckBoxs(con);
                }
            }
            return ctxts;
        }
        public List<MyComboBox> GetMyComboBoxs(Control control)
        {
            List<MyComboBox> ctxts = new List<MyComboBox>();
            foreach (Control con in control.Controls)
            {
                if (con.GetType() == typeof(MyComboBox))
                {
                    ctxts.Add((MyComboBox)con);
                }
                if (con.GetType() == typeof(GroupBox))
                {
                    this.GetMyComboBoxs(con);
                }
            }
            return ctxts;
        }
        public List<MyLabel> GetMyLabels(Control control)
        {
            List<MyLabel> ctxts = new List<MyLabel>();
            foreach (Control con in control.Controls)
            {
                if (con.GetType() == typeof(MyLabel))
                {
                    ctxts.Add((MyLabel)con);
                }
                if (con.GetType() == typeof(GroupBox))
                {
                    this.GetMyLabels(con);
                }
            }
            return ctxts;
        }
        public List<MyDateTimePicker> GetMyDateTimePickers(Control control)
        {
            List<MyDateTimePicker> ctxts = new List<MyDateTimePicker>();
            foreach (Control con in control.Controls)
            {
                if (con.GetType() == typeof(MyDateTimePicker))
                {
                    ctxts.Add((MyDateTimePicker)con);
                }
                if (con.GetType() == typeof(GroupBox))
                {
                    this.GetMyDateTimePickers(con);
                }
            }
            return ctxts;
        }
        public List<MyTextBox> GetMyTextBoxs(Control control)
        {
            List<MyTextBox> ctxts = new List<MyTextBox>();
            foreach (Control con in control.Controls)
            {
                if (con.GetType() == typeof(MyTextBox))
                {
                    ctxts.Add((MyTextBox)con);
                }
                if (con.GetType() == typeof(GroupBox))
                {
                    this.GetMyTextBoxs(con);
                }
            }
            return ctxts;
        }
        public List<MoneyPanel> GetMoneyPanels(Control control)
        {
            List<MoneyPanel> ctxts = new List<MoneyPanel>();
            foreach (Control con in control.Controls)
            {
                if (con.GetType() == typeof(MoneyPanel))
                {
                    ctxts.Add((MoneyPanel)con);
                }
                if (con.GetType() == typeof(GroupBox))
                {
                    this.GetMoneyPanels(con);
                }
            }
            return ctxts;
        }

        #endregion


        /// <summary>
        /// 保存控件到数据库
        /// </summary>
        /// <returns></returns>
        public void SaveToDataBase(Control control)
        {
            String msg=String.Empty;
            ControlService cs = new ControlService();
            List<ControlModel> m_cmsUpdate = cmlist.FindAll((delegate(ControlModel p) { return p.CTIID != 0; }));//所有更新的控件实体集合
            List<ControlModel> textList = new List<ControlModel>();//文本框集合
            List<ControlModel> moneyList = new List<ControlModel>();//金额明细集合
            List<ControlModel> otherList = new List<ControlModel>();//其他控件类型
            List<ControlModel> m_cmsAdd =   cmlist.FindAll((delegate(ControlModel p) { return p.CTIID == 0; })); //所有新增的控件集合
            foreach (ControlModel cm in m_cmsAdd)
            {
                if (cm.CTType == "TextBox")
                {
                    textList.Add(cm);
                }
                else if (cm.CTType == "MoneyPanel")
                {
                    moneyList.Add(cm);
                }
                else
                {
                    otherList.Add(cm);
                }
            }
            if (m_cmsUpdate != null)
            {
                if (cs.UpdateControlsByModels(m_cmsUpdate, tbemLsit, mpemList))
                {
                    int num = m_cmsUpdate != null ? textList.Count : 0;
                    msg += "更新控件信息:" + num + " 条成功！\n";
                }
                else
                {
                    int num = m_cmsUpdate != null ? textList.Count : 0;
                    msg += "更新控件信息:" + num + " 条失败！\n";
                }
            }
            if(cs.AddTextBoxByModels(textList, tbemLsit)&&cs.AddMoneyPanelByModels(moneyList, mpemList)&&
                cs.AddControlsByModels(otherList))
            {
                int num = textList != null ? textList.Count : 0;
                num += textList != null ? moneyList.Count : 0;
                num += textList != null ? m_cmsAdd.Count : 0; 
                msg += "新增控件信息:" + num + " 条成功！\n";
            }
            else
            {
                int num = textList != null ? textList.Count : 0;
                num += textList != null ? moneyList.Count : 0;
                num += textList != null ? m_cmsAdd.Count : 0; 
                msg += "更新控件信息:" + num + " 条失败！\n";
            }
            ModernDialog.ShowMessage(msg, "提示", System.Windows.MessageBoxButton.OK);
        }


        public void SaveControlToDataBase(Control panel)
        {
 
        }
        /// <summary>
        ///跟据模板编号，加载所有控件信息
        /// </summary>
        /// <param name="templateID"></param>
        public void LoadAllControls(int templateID)
        {
            try
            {
                cmlist = cs.GetControlModerList(cs.GetDataTableByTemplateID(templateID));
                if (cmlist != null)
                {
                    foreach (ControlModel cm in cmlist)
                    {
                        AddControl(cm);
                    }
                }

            }
            catch (Exception ex)
            {
                ModernDialog.ShowMessage(ex.ToString(), "提示", System.Windows.MessageBoxButton.OK);
                return;
            }
        }

        public void AddControl(ControlModel cm)
        {
            switch (cm.CTType)
            {
                case "TextBox":
                    {
                        #region TextBox
                        MyTextBox textbox = new MyTextBox();
                        TextBoxExtendModel tem=new TextBoxExtendService().GetModelByContorlID(cm.CTIID);
                        textbox.ControlID = cm.CTIID;
                        textbox.ControlName =cm.CTIName;
                        textbox.DefaultValue = cm.CTIDefault;
                        textbox.BorderStyle = cm.CTIIsBorder==0?BorderStyle.None:BorderStyle.FixedSingle;
                        textbox.BackColor = cm.CTIIsTransparent!=0?
                                            Color.Transparent : ColorTranslator.FromHtml(cm.CTIFontColor);
                        textbox.Font = new CommonClass().GetFontByString(cm.CTIFont);
                        textbox.ForeColor =  ColorTranslator.FromHtml(cm.CTIFontColor);
                        textbox.Left = cm.CTILeft;
                        textbox.Top = cm.CTITop;
                        textbox.Width = cm.CTIWidth;
                        textbox.Height = cm.CTIHeight;
                        textbox.TabIndex = cm.CTITabKey;
                        textbox.ReadOnly = cm.CTIIsReadOnly != 0 ? true : false;
                        textbox.Visible = cm.CTIVisiable != 0 ? true : false;
                        textbox.IsMust = cm.CTIIsMust;
                        if (tem != null)
                        {
                            tbemLsit.Add(tem);
                            textbox.IsFlage = tem.TCIsFlage;
                            textbox.showType = tem.TCShowType;
                            textbox.markType = tem.TCMarkType;
                        } 
                        //txts.Add(textbox);
                        pb.WireControl(textbox);
                        this.DesignContext.board.Controls.Add(textbox);
                        #endregion
                        break;
                    }
                case "Label":
                    {
                        #region Label
                        MyLabel label = new MyLabel();
                        label.ControlID = cm.CTIID;
                        label.ControlName = cm.CTIName;
                        label.DefaultValue = cm.CTIDefault;
                        label.BorderStyle = cm.CTIIsBorder == 0 ? BorderStyle.None : BorderStyle.FixedSingle;
                        label.BackColor = cm.CTIIsTransparent != 0 ?
                                            Color.Transparent : ColorTranslator.FromHtml(cm.CTIFontColor);
                        label.Font = new CommonClass().GetFontByString(cm.CTIFont);
                        label.ForeColor = ColorTranslator.FromHtml(cm.CTIFontColor);
                        label.Left = cm.CTILeft;
                        label.Top = cm.CTITop;
                        label.Width = cm.CTIWidth;
                        label.Height = cm.CTIHeight;
                        label.TabIndex = cm.CTITabKey;
                        //label.ReadOnly = cm.CTIIsReadOnly != 0 ? true : false;
                        label.Visible = cm.CTIVisiable != 0 ? true : false;
                        label.IsMust = cm.CTIIsMust;
                        //labels.Add(label);
                        pb.WireControl(label);
                        this.DesignContext.board.Controls.Add(label);
                        #endregion
                        break;
                    }
                case "ComboBox":
                    {
                        #region ComboBox
                        MyComboBox combobox = new MyComboBox();
                        combobox.ControlID = cm.CTIID;
                        combobox.ControlName = cm.CTIName;
                        combobox.DefaultValue = cm.CTIDefault;
                        //combobox.BorderStyle = cm.CTIIsBorder == 0 ? BorderStyle.None : BorderStyle.FixedSingle;
                        combobox.BackColor = cm.CTIIsTransparent != 0 ?
                                            Color.Transparent : ColorTranslator.FromHtml(cm.CTIFontColor);
                        combobox.Font = new CommonClass().GetFontByString(cm.CTIFont);
                        combobox.ForeColor = ColorTranslator.FromHtml(cm.CTIFontColor);
                        combobox.Left = cm.CTILeft;
                        combobox.Top = cm.CTITop;
                        combobox.Width = cm.CTIWidth;
                        combobox.Height = cm.CTIHeight;
                        combobox.TabIndex = cm.CTITabKey;
                        //combobox.ReadOnly = cm.CTIIsReadOnly != 0 ? true : false;
                        combobox.Visible = cm.CTIVisiable != 0 ? true : false;
                        combobox.IsMust = cm.CTIIsMust;
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
                        checkbox.ControlID = cm.CTIID;
                        checkbox.ControlName = cm.CTIName;
                        checkbox.DefaultValue = cm.CTIDefault;
                        //checkbox.BorderStyle = cm.CTIIsBorder == 0 ? BorderStyle.None : BorderStyle.FixedSingle;
                        checkbox.BackColor = cm.CTIIsTransparent != 0 ?
                                            Color.Transparent : ColorTranslator.FromHtml(cm.CTIFontColor);
                        checkbox.Font = new CommonClass().GetFontByString(cm.CTIFont);
                        checkbox.ForeColor = ColorTranslator.FromHtml(cm.CTIFontColor);
                        checkbox.Left = cm.CTILeft;
                        checkbox.Top = cm.CTITop;
                        checkbox.Width = cm.CTIWidth;
                        checkbox.Height = cm.CTIHeight;
                        checkbox.TabIndex = cm.CTITabKey;
                        //checkbox.ReadOnly = cm.CTIIsReadOnly != 0 ? true : false;
                        checkbox.Visible = cm.CTIVisiable != 0 ? true : false;
                        checkbox.IsMust = cm.CTIIsMust;
                        //chbs.Add(checkbox);
                        pb.WireControl(checkbox);
                        this.DesignContext.board.Controls.Add(checkbox);
                        #endregion
                        break;
                    }
                case "DateTimePicker":
                    {
                        #region DateTimePicker
                        MyDateTimePicker dateTimePicker = new MyDateTimePicker();
                        dateTimePicker.ControlID = cm.CTIID;
                        dateTimePicker.ControlName = cm.CTIName;
                        dateTimePicker.DefaultValue = cm.CTIDefault;
                        //dateTimePicker.BorderStyle = cm.CTIIsBorder == 0 ? BorderStyle.None : BorderStyle.FixedSingle;
                        dateTimePicker.BackColor = cm.CTIIsTransparent != 0 ?
                                            Color.Transparent : ColorTranslator.FromHtml(cm.CTIFontColor);
                        dateTimePicker.Font = new CommonClass().GetFontByString(cm.CTIFont);
                        dateTimePicker.ForeColor = ColorTranslator.FromHtml(cm.CTIFontColor);
                        dateTimePicker.Left = cm.CTILeft;
                        dateTimePicker.Top = cm.CTITop;
                        dateTimePicker.Width = cm.CTIWidth;
                        dateTimePicker.Height = cm.CTIHeight;
                        dateTimePicker.TabIndex = cm.CTITabKey;
                        //dateTimePicker.ReadOnly = cm.CTIIsReadOnly != 0 ? true : false;
                        dateTimePicker.Visible = cm.CTIVisiable != 0 ? true : false;
                        dateTimePicker.IsMust = cm.CTIIsMust;
                        //dtps.Add(dateTimePicker);
                        pb.WireControl(dateTimePicker);
                        this.DesignContext.board.Controls.Add(dateTimePicker);
                        #endregion 
                        break;
                    }
                case "MoneyPanel":
                    {
                        #region MoneyPanel
                        MoneyPanel moneyPanel = new MoneyPanel();
                        MoneyPanelExtendModel mpe = new MoneyPanelExtenService().GetMoneyPanelExtendModelByCIID(moneyPanel.ControlID);
                        moneyPanel.ControlID = cm.CTIID;
                        moneyPanel.ControlName = cm.CTIName;
                        moneyPanel.BorderStyle = cm.CTIIsBorder == 0 ? BorderStyle.None : BorderStyle.FixedSingle;
                        moneyPanel.BackColor = cm.CTIIsTransparent != 0 ?
                                            Color.Transparent : ColorTranslator.FromHtml(cm.CTIFontColor);
                        moneyPanel.Font = new CommonClass().GetFontByString(cm.CTIFont);
                        moneyPanel.ForeColor = ColorTranslator.FromHtml(cm.CTIFontColor);
                        moneyPanel.Left = cm.CTILeft;
                        moneyPanel.Top = cm.CTITop;
                        moneyPanel.Width = cm.CTIWidth;
                        moneyPanel.Height = cm.CTIHeight;
                        moneyPanel.TabIndex = cm.CTITabKey;
                        moneyPanel.Visible = cm.CTIVisiable != 0 ? true : false;
                        moneyPanel.IsMust = cm.CTIIsMust;
                        if(mpe!=null)
                        {
                            mpemList.Add(mpe);
                            moneyPanel.Hight =mpe.MCHighUnit;
                            moneyPanel.Low = mpe.MCLowUnit;
                            moneyPanel.IsShowUnit = mpe.MCShowUnit;
                        }
                        //mps.Add(moneyPanel);
                        pb.WireControl(moneyPanel);
                        this.DesignContext.board.Controls.Add(moneyPanel);
                        #endregion
                        break;
                    }
            }
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
            fDpiX = this.CreateGraphics().DpiX;
            fDpiY = this.CreateGraphics().DpiY;
            image = new ImageHelper().GetImageByByte(btm.TIBackground);
            width = Convert.ToInt32(MillimetersToPixelsWidth(Convert.ToSingle(btm.TIWidth)));//,fDpiX));
            height = Convert.ToInt32(MillimetersToPixelsWidth(Convert.ToSingle(btm.TIHeight)));//,fDpiY));
            DesignContext_Paint();
            pb = new PickBox(this);
            LoadAllControls(btm.TIID);
        }

        /// <summary>
        /// 模板属性修改
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SetTemplatePropery_Click(object sender, EventArgs e)
        {
            TemplateProperyEdit tpe = new TemplateProperyEdit(btm); 
            tpe.ShowDialog();
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
            MyLabel label = new MyLabel();
            label.NewNumber = TextConut + labelCount + datetimerConut + comboboxCount + checkboxCount + comboboxCount + moneypanelCount;
            labelCount++;
            label.ControlID = 0;
            label.ControlName = "label" + labelCount.ToString();
            ControlModel cm = new ControlModel();
            cm.CTIID = label.ControlID;
            cm.CTIName = label.ControlName;
            cm.CTType = "label";
            cm.NewNumber = label.NewNumber;
            cmlist.Add(cm);
            pb.WireControl(label);
            this.DesignContext.board.Controls.Add(label);
        }

        /// <summary>
        /// 添加文本框
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AddTextBox_Click(object sender, EventArgs e)
        { 
            MyTextBox label = new MyTextBox();
            label.NewNumber = TextConut + labelCount + datetimerConut + comboboxCount + checkboxCount + comboboxCount + moneypanelCount;
            TextConut++;            
            label.ControlID = 0;
            label.ControlName = "TextBox" + TextConut.ToString();
            ControlModel cm = new ControlModel();
            cm.CTIID = label.ControlID;
            cm.CTIName = label.ControlName;
            cm.CTType = "TextBox";
            cm.NewNumber = label.NewNumber;
            TextBoxExtendModel tbem = new TextBoxExtendModel();
            tbem.TCCIID = cm.CTIID;
            tbem.TCShowType = 0;
            tbem.TCMarkType = 0;
            tbemLsit.Add(tbem);
            cmlist.Add(cm);
            pb.WireControl(label);
            this.DesignContext.board.Controls.Add(label);
        }

        /// <summary>
        /// 添加检验框
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AddCheckBox_Click(object sender, EventArgs e)
        {
            MyCheckBox label = new MyCheckBox();
            label.NewNumber = TextConut + labelCount + datetimerConut + comboboxCount + checkboxCount + comboboxCount + moneypanelCount;
            checkboxCount++;
            label.ControlID=0;
            label.ControlName = "CheckBox" + checkboxCount.ToString();
            ControlModel cm = new ControlModel();
            cm.CTIID = label.ControlID;
            cm.CTIName = label.ControlName;
            cm.CTType = "CheckBox";
            cm.NewNumber = label.NewNumber;
            cmlist.Add(cm);
            pb.WireControl(label);
            this.DesignContext.board.Controls.Add(label);
        }

        /// <summary>
        /// 添加下拉框
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AddComboBox_Click(object sender, EventArgs e)
        {
            MyComboBox label = new MyComboBox();
            label.NewNumber = TextConut + labelCount + datetimerConut + comboboxCount + checkboxCount + comboboxCount + moneypanelCount;
            comboboxCount++;//cbbs.Add(label);
            label.ControlID = 0;           
            label.ControlName = "ComboBox" + comboboxCount.ToString();
            ControlModel cm = new ControlModel();
            cm.CTIID = label.ControlID;
            cm.CTIName = label.ControlName;
            cm.CTType = "ComboBox";
            cm.NewNumber = label.NewNumber;
            cmlist.Add(cm);
            pb.WireControl(label);
            this.DesignContext.board.Controls.Add(label);
        }

        /// <summary>
        /// 添加日历
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AddDateTimePicker_Click(object sender, EventArgs e)
        {
            MyDateTimePicker label = new MyDateTimePicker();
            label.NewNumber = TextConut + labelCount + datetimerConut + comboboxCount + checkboxCount + comboboxCount + moneypanelCount;
            datetimerConut++;//dtps.Add(label);
            label.ControlID = 0;
            label.ControlName = "DateTimePicker" + datetimerConut.ToString();
            ControlModel cm = new ControlModel();
            cm.CTIID = label.ControlID;
            cm.CTIName = label.ControlName;
            cm.CTType = "DateTimePicker";
            cm.NewNumber = label.NewNumber;
            cmlist.Add(cm);
            pb.WireControl(label);
            this.DesignContext.board.Controls.Add(label);
        }

        /// <summary>
        /// 添加金额框
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AddMyMoneyPanel_Click(object sender, EventArgs e)
        {
            MoneyPanel mp = new MoneyPanel();
            mp.NewNumber = TextConut + labelCount + datetimerConut + comboboxCount + checkboxCount + comboboxCount + moneypanelCount;
            moneypanelCount++;
            mp.ControlID = 0;          
            mp.ControlName = "ComboBox" + moneypanelCount.ToString();
            ControlModel cm = new ControlModel();
            cm.CTIID = mp.ControlID;
            cm.CTIName = mp.ControlName;
            cm.CTType = "MoneyPanel";
            cm.NewNumber = mp.NewNumber;
            MoneyPanelExtendModel mpm = new MoneyPanelExtendModel();
            mpm.MCCIID = cm.CTIID;
            mpm.MCHighUnit = mp.Hight;
            mpm.MCLowUnit = mp.Low;
            mpemList.Add(mpm);
            cmlist.Add(cm);
            pb.WireControl(mp);
            this.DesignContext.board.Controls.Add(mp);
        }
        #endregion
        /// <summary>
        /// 保存功能
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Save_Click(object sender, EventArgs e)
        {
            SaveToDataBase(this.DesignContext.board);
        }

        /// <summary>
        /// 鼠标经过工具栏时改变颜色
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolSave_MouseEnter(object sender, EventArgs e)
        {
            ToolStripButton tsb = sender as ToolStripButton;
            if (tsb != null)
            {
                tsb.BackColor = Color.Purple;
            }
        }

        /// <summary>
        /// 鼠标离开时恢复颜色
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolSave_MouseLeave(object sender, EventArgs e)
        {
            ToolStripButton tsb = sender as ToolStripButton;
            if (tsb != null)
            {
                tsb.BackColor = Color.SkyBlue;
            }
        }

        private void TemplateMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = false;//可以关闭
            List<ControlModel> con = new List<ControlModel>();
            if (con.Exists(itm => itm.updateFlage == true))
            {
                if (ModernDialog.ShowMessage("模板设置信息已被更新，是否保存？", "软件提示", System.Windows.MessageBoxButton.YesNo) == System.Windows.MessageBoxResult.Yes)
                {
                    Save_Click(sender, e);
                }
            }
        }

        private void TemplateMain_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Dispose();//释放资源
        }

        #endregion
    }
}
