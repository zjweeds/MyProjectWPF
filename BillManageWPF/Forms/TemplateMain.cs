

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
using Controllers.MyControls.RulePanel;
using Controllers.MyControls.TemplateContorl;
using System.Runtime.InteropServices;
using Controllers.Moders.TableModers;
using Controllers.Business;
using BillManageWPF.MyCode;
using BillManageWPF.Pages.BillTemplateList;
using FirstFloor.ModernUI.Windows.Controls;

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
            this.btm = bts.GetTemplateModerListByDataTable(bts.GetDataTableByID(code))[0];
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
        public List<MyLabel> labels = new List<MyLabel>();
        public List<MyTextBox> txts = new List<MyTextBox>();
        public List<MyCheckBox> chbs = new List<MyCheckBox>();
        public List<MyComboBox> cbbs = new List<MyComboBox>();
        public List<MyDateTimePicker> dtps = new List<MyDateTimePicker>();
        public List<MoneyPanel> mps = new List<MoneyPanel>();
        public BillTemplateService bts = new BillTemplateService();
        public BillTemplatModer btm = new BillTemplatModer();
        public List<ControlModer> cmlist = new List<ControlModer>();
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

        public bool SaveToDataBase()
        {

            return false;
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
                    foreach (ControlModer cm in cmlist)
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

        public void AddControl(ControlModer cm)
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
                                            Color.Transparent:new CommonClass().GetColorByByte(cm.CTIBackColor);
                        textbox.Font = new CommonClass().GetFontByByte(cm.CTIFont);
                        textbox.ForeColor = new CommonClass().GetColorByByte(cm.CTIFontColor);
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
                            textbox.IsFlage = tem.TCIsFlage;
                            textbox.showType = tem.TCShowType;
                            textbox.markType = tem.TCMarkType;
                        } 
                        txts.Add(textbox);
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
                                            Color.Transparent : new CommonClass().GetColorByByte(cm.CTIBackColor);
                        label.Font = new CommonClass().GetFontByByte(cm.CTIFont);
                        label.ForeColor = new CommonClass().GetColorByByte(cm.CTIFontColor);
                        label.Left = cm.CTILeft;
                        label.Top = cm.CTITop;
                        label.Width = cm.CTIWidth;
                        label.Height = cm.CTIHeight;
                        label.TabIndex = cm.CTITabKey;
                        //label.ReadOnly = cm.CTIIsReadOnly != 0 ? true : false;
                        label.Visible = cm.CTIVisiable != 0 ? true : false;
                        label.IsMust = cm.CTIIsMust;
                        labels.Add(label);
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
                                            Color.Transparent : new CommonClass().GetColorByByte(cm.CTIBackColor);
                        combobox.Font = new CommonClass().GetFontByByte(cm.CTIFont);
                        combobox.ForeColor = new CommonClass().GetColorByByte(cm.CTIFontColor);
                        combobox.Left = cm.CTILeft;
                        combobox.Top = cm.CTITop;
                        combobox.Width = cm.CTIWidth;
                        combobox.Height = cm.CTIHeight;
                        combobox.TabIndex = cm.CTITabKey;
                        //combobox.ReadOnly = cm.CTIIsReadOnly != 0 ? true : false;
                        combobox.Visible = cm.CTIVisiable != 0 ? true : false;
                        combobox.IsMust = cm.CTIIsMust;
                        cbbs.Add(combobox);
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
                                            Color.Transparent : new CommonClass().GetColorByByte(cm.CTIBackColor);
                        checkbox.Font = new CommonClass().GetFontByByte(cm.CTIFont);
                        checkbox.ForeColor = new CommonClass().GetColorByByte(cm.CTIFontColor);
                        checkbox.Left = cm.CTILeft;
                        checkbox.Top = cm.CTITop;
                        checkbox.Width = cm.CTIWidth;
                        checkbox.Height = cm.CTIHeight;
                        checkbox.TabIndex = cm.CTITabKey;
                        //checkbox.ReadOnly = cm.CTIIsReadOnly != 0 ? true : false;
                        checkbox.Visible = cm.CTIVisiable != 0 ? true : false;
                        checkbox.IsMust = cm.CTIIsMust;
                        chbs.Add(checkbox);
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
                                            Color.Transparent : new CommonClass().GetColorByByte(cm.CTIBackColor);
                        dateTimePicker.Font = new CommonClass().GetFontByByte(cm.CTIFont);
                        dateTimePicker.ForeColor = new CommonClass().GetColorByByte(cm.CTIFontColor);
                        dateTimePicker.Left = cm.CTILeft;
                        dateTimePicker.Top = cm.CTITop;
                        dateTimePicker.Width = cm.CTIWidth;
                        dateTimePicker.Height = cm.CTIHeight;
                        dateTimePicker.TabIndex = cm.CTITabKey;
                        //dateTimePicker.ReadOnly = cm.CTIIsReadOnly != 0 ? true : false;
                        dateTimePicker.Visible = cm.CTIVisiable != 0 ? true : false;
                        dateTimePicker.IsMust = cm.CTIIsMust;
                        dtps.Add(dateTimePicker);
                        pb.WireControl(dateTimePicker);
                        this.DesignContext.board.Controls.Add(dateTimePicker);
                        #endregion 
                        break;
                    }
                case "MoneyPanel":
                    {
                        #region MoneyPanel
                        MoneyPanel moneyPanel = new MoneyPanel();
                        moneyPanel.ControlID = cm.CTIID;
                        moneyPanel.ControlName = cm.CTIName;
                        moneyPanel.DefaultValue = cm.CTIDefault;
                        moneyPanel.BorderStyle = cm.CTIIsBorder == 0 ? BorderStyle.None : BorderStyle.FixedSingle;
                        moneyPanel.BackColor = cm.CTIIsTransparent != 0 ?
                                            Color.Transparent : new CommonClass().GetColorByByte(cm.CTIBackColor);
                        moneyPanel.Font = new CommonClass().GetFontByByte(cm.CTIFont);
                        moneyPanel.ForeColor = new CommonClass().GetColorByByte(cm.CTIFontColor);
                        moneyPanel.Left = cm.CTILeft;
                        moneyPanel.Top = cm.CTITop;
                        moneyPanel.Width = cm.CTIWidth;
                        moneyPanel.Height = cm.CTIHeight;
                        moneyPanel.TabIndex = cm.CTITabKey;
                        //moneyPanel.ReadOnly = cm.CTIIsReadOnly != 0 ? true : false;
                        moneyPanel.Visible = cm.CTIVisiable != 0 ? true : false;
                        moneyPanel.IsMust = cm.CTIIsMust;
                        mps.Add(moneyPanel);
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
            //String typeName = new BillTemplateTypeService().GetTemplateTypeNameById(btm.TITTID);
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
            label.ControlID = labels == null ? 0 : labels.Count;
            label.ControlName = "label" + label.ControlID.ToString();
            labels.Add(label);
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
            label.ControlID = txts == null ? 0 : txts.Count;
            label.ControlName = "TextBox" + label.ControlID.ToString();
            txts.Add(label);
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
            label.ControlID = chbs == null ? 0 : chbs.Count;
            label.ControlName = "ChecBox" + label.ControlID.ToString();
            chbs.Add(label);
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
            label.ControlID = 0;
            label.ControlID = cbbs == null ? 0 : cbbs.Count;
            label.ControlName = "ComboBox" + label.ControlID.ToString();
            cbbs.Add(label);
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
            label.ControlID = dtps == null ? 0 : dtps.Count;
            label.ControlName = "ComboBox" + label.ControlID.ToString();
            dtps.Add(label);
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
            mp.ControlID = mps == null ? 0 : mps.Count;
            mp.ControlName = "ComboBox" + mp.ControlID.ToString();
            mps.Add(mp);
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

        }

        #endregion
    }
}
