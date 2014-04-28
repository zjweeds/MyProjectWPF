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
using BillManageWPF.Pages.BillTemplateList;
using Controllers.MyControls.TemplateContorl;
using BillManageWPF.MyCode;

namespace BillManageWPF.Forms
{
    public partial class TemplateMain : Form
    {
        public TemplateMain()
        {
            InitializeComponent();
        }
        public int codes;
        public List<MyLabel> labels = new List<MyLabel>();
        public PickBox pb = null;
        float fDpiX;
        float fDpiY;
        public TemplateMain(int code)
        {
            InitializeComponent();
            codes = code;
        }
        /// <summary>
        /// 加载所有控件
        /// </summary>
        /// <param name="templateID"></param>
        public void LoadAllControls(int templateID)
        {
 
        }
        private void Template_Load(object sender, EventArgs e)
        {
           pb= new PickBox(this);
           //获取分辨率
           fDpiX = this.CreateGraphics().DpiX;
           fDpiY = this.CreateGraphics().DpiY;
           this.Invalidate();
        }
        private float MillimetersToPixel(float fValue, float fDPI)
        {
            return (fValue / 25.4f) * fDPI;
        }  
        private void splitContainer1_Panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void cbbControls_SelectedIndexChanged(object sender, EventArgs e)
        {
           
            
        }

        /// <summary>
        /// 模板属性修改
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SetTemplatePropery_Click(object sender, EventArgs e)
        {
            TemplateProperyEdit tpe = new TemplateProperyEdit("update", codes);
            tpe.Show();
            this.Close();
        }

        /// <summary>
        /// 添加文本框
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AddLabel_Click(object sender, EventArgs e)
        {
            MyLabel label = new MyLabel();
            label.ControlID = 0;
            label.ControlName = "label" + labels.Count;
            labels.Add(label);
            pb.WireControl(label);
            this.DesignContext.Panel.Controls.Add(label);
        }

        private void DesignContext_Paint(object sender, PaintEventArgs e)
        {
            //offset = new Point(this.Location.X, this.Location.Y);
            ////引入图片
            ////Image img = cc.GetImageByBytes(dt.Rows[0]["背景图片"] as byte[]);
            ////左上角顶点
            //Point point = new Point(0, 0);
            ////新的大小
            //SizeF newSize = new SizeF(MillimetersToPixel(Convert.ToInt32(dt.Rows[0]["宽度"].ToString()), fDpiX), MillimetersToPixel(Convert.ToInt32(dt.Rows[0]["高度"].ToString()), fDpiY));
            ////新的矩形
            //RectangleF NewRect = new RectangleF(point, newSize);
            ////原始图形的参数
            //SizeF oldSize = new SizeF(img.Width, img.Height);
            ////原始图形的大小
            //RectangleF OldRect = new RectangleF(point, oldSize);
            ////缩放图形处理
            //e.Graphics.DrawImage(img, NewRect, OldRect, System.Drawing.GraphicsUnit.Pixel);
            ////若新图形的宽度或高度大于窗体的宽度或高度，窗体会自行调整
            //if (newSize.Width > this.Width || newSize.Height > this.Height)
            //{
            //    Size size = new Size(Convert.ToInt32(MillimetersToPixel(Convert.ToInt32(dt.Rows[0]["宽度"].ToString()), fDpiX)), Convert.ToInt32(MillimetersToPixel(Convert.ToInt32(dt.Rows[0]["高度"].ToString()), fDpiY)));
            //    FormAutoResize(size);
            //}
        }
    }
}
