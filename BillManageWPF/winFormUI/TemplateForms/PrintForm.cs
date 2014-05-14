using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Controllers.Models;
using Controllers.DataAccess;
using Controllers.Common;
using System.Runtime.InteropServices;
using MyExtendControls.MyControls.TemplateContorl;
using FirstFloor.ModernUI.Windows.Controls;
using BillManageWPF.MyCode;

namespace BillManageWPF.Forms
{
    public partial class PrintForm : Form
    {
        #region 构造方法
        public PrintForm()
        {
            InitializeComponent();
        }
        public PrintForm(int code)
        {
            InitializeComponent();
            this.templateID = code;
        }
        #endregion

        #region   页面变量
        private int templateID;//模板编号
        private float fDpiX;
        private float fDpiY;
        private int m_Width;
        private int m_Height;
        private Image image;
        public Point offset = new Point(0, 0); //坐标原点
        private BillTemplatModel btm =new BillTemplatModel();
        public List<ControlModel> cmlist = new List<ControlModel>();
        public List<TextBoxExtendModel> tbemLsit = new List<TextBoxExtendModel>();
        public List<MoneyPanelExtendModel> mpemList = new List<MoneyPanelExtendModel>();
        public ControlService cs = new ControlService();
        #endregion

        #region 自定义方法
        private float MillimetersToPixel(float fValue, float fDPI)
        {
            return (fValue / 25.4f) * fDPI;
        }
       
        [DllImport("gdi32.dll")]
        private static extern int GetDeviceCaps(IntPtr hdc, int Index);
        
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

         private void DesignContext_Paint()
        {
            offset = new Point(this.DesignContext.board.Location.X, this.DesignContext.board.Location.Y);
            Point point = new Point(0, 0);
            ////新的大小
            SizeF newSize = new SizeF(MillimetersToPixel(m_Width, fDpiX), MillimetersToPixel(m_Height, fDpiY));
            ////新的矩形
            RectangleF NewRect = new RectangleF(point, newSize);
            ////原始图形的参数
            SizeF oldSize = new SizeF(image.Width, image.Height);
            ////原始图形的大小
            RectangleF OldRect = new RectangleF(point, oldSize);
            ////缩放图形处理
            Image newImg = image.GetThumbnailImage(m_Width, m_Height, new Image.GetThumbnailImageAbort(IsTrue), IntPtr.Zero);
            this.DesignContext.board.BackgroundImageLayout = ImageLayout.Stretch;
            this.DesignContext.board.BackgroundImage = image;
            ////若新图形的宽度或高度大于窗体的宽度或高度，窗体会自行调整
            if (newSize.Width > this.DesignContext.board.Width || newSize.Height > this.DesignContext.board.Height)
            {
                Size size = new System.Drawing.Size(m_Width, m_Height);
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
            this.DesignContext.board.Location = new Point(this.DesignContext.board.Location.X - (this.DesignContext.board.Width - intOldWidth) / 2, this.DesignContext.board.Location.Y - (this.DesignContext.board.Height - intOldHeight) / 2);
        }
         private static bool IsTrue() // 在Image类别对图片进行缩放的时候,需要一个返回bool类别的委托
         {
             return true;
         }
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
                         TextBoxExtendModel tem = new TextBoxExtendService().GetModelByContorlID(cm.CTIID);
                         textbox.ControlID = cm.CTIID;
                         textbox.ControlName = cm.CTIName;
                         textbox.DefaultValue = cm.CTIDefault;
                         textbox.Text = cm.CTIDefault;
                         textbox.BorderStyle = cm.CTIIsBorder == 0 ? BorderStyle.None : BorderStyle.FixedSingle;
                         textbox.BackColor = cm.CTIIsTransparent != 0 ?
                                             Color.Transparent :ColorTranslator.FromHtml(cm.CTIBackColor);
                         textbox.Font = new CommonClass().GetFontByString(cm.CTIFont);
                         textbox.ForeColor = ColorTranslator.FromHtml(cm.CTIFontColor);
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
                         label.Text = cm.CTIDefault;
                         label.BorderStyle = cm.CTIIsBorder == 0 ? BorderStyle.None : BorderStyle.FixedSingle;
                         label.BackColor = cm.CTIIsTransparent != 0 ?
                                             Color.Transparent : ColorTranslator.FromHtml(cm.CTIBackColor);
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
                         combobox.Text=cm.CTIDefault;
                         //combobox.BorderStyle = cm.CTIIsBorder == 0 ? BorderStyle.None : BorderStyle.FixedSingle;
                         combobox.BackColor = cm.CTIIsTransparent != 0 ?
                                             Color.Transparent : ColorTranslator.FromHtml(cm.CTIBackColor);
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
                         if (cm.CTIBandsTabel != String.Empty && cm.CTIBandsCoumln != String.Empty)
                         {
                             //有绑定数据源信息
                             new ComHelper().SetFormComboBoxItemByDataTable(
                                    new DataSourceService().GetBandingsInfoByTableAndCoumln(cm.CTIBandsTabel, cm.CTIBandsCoumln, null, null),
                                    combobox, cm.CTIBandsCoumln, cm.CTIBandsCoumln
                                 );//设置数据源
                             //添加事件
                             combobox.SelectedIndexChanged += new EventHandler(ComboBox_selectIndexChange);
                         }
                         
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
                         checkbox.Text =  cm.CTIName;
                         checkbox.DefaultValue = cm.CTIDefault;
                         checkbox.Checked = cm.CTIDefault=="true"?true:false;
                         //checkbox.BorderStyle = cm.CTIIsBorder == 0 ? BorderStyle.None : BorderStyle.FixedSingle;
                         checkbox.BackColor = cm.CTIIsTransparent != 0 ?
                                             Color.Transparent : ColorTranslator.FromHtml(cm.CTIBackColor);
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
                         dateTimePicker.Text = cm.CTIDefault;
                         //dateTimePicker.BorderStyle = cm.CTIIsBorder == 0 ? BorderStyle.None : BorderStyle.FixedSingle;
                         dateTimePicker.BackColor = cm.CTIIsTransparent != 0 ?
                                             Color.Transparent : ColorTranslator.FromHtml(cm.CTIBackColor);
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
                         //moneyPanel.DefaultValue = cm.CTIDefault;
                         moneyPanel.BorderStyle = cm.CTIIsBorder == 0 ? BorderStyle.None : BorderStyle.FixedSingle;
                         moneyPanel.BackColor = cm.CTIIsTransparent != 0 ?
                                             Color.Transparent : ColorTranslator.FromHtml(cm.CTIBackColor);
                         moneyPanel.Font = new CommonClass().GetFontByString(cm.CTIFont);
                         moneyPanel.ForeColor = ColorTranslator.FromHtml(cm.CTIFontColor);
                         moneyPanel.Left = cm.CTILeft;
                         moneyPanel.Top = cm.CTITop;
                         moneyPanel.Width = cm.CTIWidth;
                         moneyPanel.Height = cm.CTIHeight;
                         moneyPanel.TabIndex = cm.CTITabKey;
                         //moneyPanel.ReadOnly = cm.CTIIsReadOnly != 0 ? true : false;
                         moneyPanel.Visible = cm.CTIVisiable != 0 ? true : false;
                         moneyPanel.IsMust = cm.CTIIsMust;
                         if (mpe != null)
                         {
                             mpemList.Add(mpe);
                             moneyPanel.Hight = mpe.MCHighUnit;
                             moneyPanel.Low = mpe.MCLowUnit;
                             moneyPanel.IsShowUnit = mpe.MCShowUnit;
                         }
                         this.DesignContext.board.Controls.Add(moneyPanel);
                         #endregion
                         break;
                     }
             }
         }
        #endregion

        #region  窗体事件 
        private void PrintForm_Load(object sender, EventArgs e)
        {
            fDpiX = this.CreateGraphics().DpiX;
            fDpiY = this.CreateGraphics().DpiY;
            btm = new BillTemplateService().GetTemplateModeltByID(templateID);//获得模板对象
            image = new ImageHelper().GetImageByByte(btm.TIBackground);
            m_Width = Convert.ToInt32(MillimetersToPixelsWidth(Convert.ToSingle(btm.TIWidth)));
            m_Height = Convert.ToInt32(MillimetersToPixelsWidth(Convert.ToSingle(btm.TIHeight)));
            DesignContext_Paint();
            LoadAllControls(btm.TIID);
        }
        private void ComboBox_selectIndexChange(object sender, EventArgs e)
        {
            //改变当前票据下所有绑定的信息
        }

        #endregion
    }
}
