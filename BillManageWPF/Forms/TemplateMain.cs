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
using BillManageWPF.MyCode;

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
            codes = code;
        }
        public TemplateMain(Image m, int w, int h)
        {
            fDpiX = this.CreateGraphics().DpiX;
            fDpiY = this.CreateGraphics().DpiY;
            InitializeComponent();
            width = Convert.ToInt32(MillimetersToPixelsWidth(Convert.ToSingle(w)));//,fDpiX));
            height = Convert.ToInt32(MillimetersToPixelsWidth(Convert.ToSingle(h)));//,fDpiY));
            image = m;
        }
        #endregion

        #region 页面属性值
        public int width;
        public int height;
        public Image image;
        public Point offset = new Point(0, 0);
        public int codes;
        public PickBox pb = null;
        float fDpiX;
        float fDpiY;
        public List<MyLabel> labels = new List<MyLabel>();
        public List<MyTextBox> txts = new List<MyTextBox>();
        public List<MyCheckBox> chbs = new List<MyCheckBox>();
        public List<MyComboBox> cbbs = new List<MyComboBox>();
        public List<MyDateTimePicker> dtps = new List<MyDateTimePicker>();
        public List<MoneyPanel> mps = new List<MoneyPanel>();
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

        #region mm到分辨率的单位转换
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
        /// 加载所有控件
        /// </summary>
        /// <param name="templateID"></param>
        public void LoadAllControls(int templateID)
        {

        }

        #endregion

        /// <summary>
        /// 窗口载入事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Template_Load(object sender, EventArgs e)
        {
            pb = new PickBox(this);
            //获取分辨率
            fDpiX = this.CreateGraphics().DpiX;
            fDpiY = this.CreateGraphics().DpiY;
            DesignContext_Paint();
        }

        /// <summary>
        /// 模板属性修改
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SetTemplatePropery_Click(object sender, EventArgs e)
        {

            MessageBox.Show("弹出属性框");
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

    }
}
