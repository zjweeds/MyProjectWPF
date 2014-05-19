using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Drawing.Printing;
using System.Threading.Tasks;
using System.Windows.Forms;
using Controllers.Business;
using Controllers.Models;
using Controllers.Common;

namespace BillManageWPF.winFormUI
{
    public partial class BillSerchListForm : Form
    {
        #region 页面变量
        private float fDpiX=96;//横向分辨率
        private float fDpiY= 96;//纵向分辨率
        private Int32 width;//保存背景图片宽度
        private Int32 height;//保存背景图片高度
        private Image image;//保存图片对象
        private DataTable dtControls = null;
        private DataTable dtBillList = null;
        private BillTemplatModel btm = new BillTemplatModel();
        private IList<Int32> printBIIDlists = new List<Int32>();
        private int page_Number = 0;//总打印页数
        private int print_Index = 0;//当前打印的页数；
        #endregion

        #region 构造函数
        public BillSerchListForm()
        {
            InitializeComponent();
        }
        public BillSerchListForm(int code)
        {
            InitializeComponent();
            btm =BillTemplateManage.SelectTemplateModeltByID(code);
        }
        #endregion

        #region 自定义方法
        
        /// <summary>
        /// 毫米到分辨率转换
        /// </summary>
        /// <param name="fValue"></param>
        /// <param name="fDPI"></param>
        /// <returns></returns>
        private float MillimetersToPixel(float fValue, float fDPI)
        {
            return (fValue / 25.4f) * fDPI;
        }

        /// <summary>
        /// 根据票据号获取打印的一页内容
        /// </summary>
        /// <param name="BillCode">票据号</param>
        /// <param name="e"></param>
        private void getOnePage(int BillCode, PrintPageEventArgs e)
        {
            if (btm.TIIsPrintBg != 0)
            {
                Rectangle destRect = new System.Drawing.Rectangle(0, 0, width, height);
                e.Graphics.DrawImage(image, destRect, 0, 0, image.Width, image.Height, GraphicsUnit.Pixel);
            }
            DataTable dtCtrText = ControlDetailManager.SeclectControlsDetailByBIID(BillCode);
            for (int i = 0; i < dtControls.Rows.Count; i++)
            {
                if (Convert.ToInt32(dtControls.Rows[i]["CTIsPrint"]) == 1)
                {
                    DataRow[] dr = dtCtrText.Select("CDCTIID = '" + Convert.ToInt32(dtControls.Rows[i]["CIID"]) + "'");
                    Brush brush = new SolidBrush(ColorTranslator.FromHtml(dtControls.Rows[i]["CTFontColor"].ToString()));
                    TextBox c = new TextBox();
                    c.Text = dr[0]["CDText"].ToString();
                    c.Location = new Point(Convert.ToInt32(dtControls.Rows[i]["CTLeft"]), Convert.ToInt32(dtControls.Rows[i]["CTTop"]));
                    c.Size = new Size(Convert.ToInt32(dtControls.Rows[i]["CTWidth"]), Convert.ToInt32(dtControls.Rows[i]["CTHeight"]));
                    c.Font = new CommonClass().GetFontByString(dtControls.Rows[i]["CTFont"].ToString());
                    e.Graphics.DrawString(c.Text, c.Font, brush,
                          c.Location.X,// + Convert.ToInt32(MillimetersToPixel(Convert.ToInt32(UserPrintSet.Left), fDpiX)),
                          c.Location.Y);// + Convert.ToInt32(MillimetersToPixel(Convert.ToInt32(UserPrintSet.Top), fDpiY)));
                }
            }
        }

        /// <summary>
        /// 获得所有选中行的单据号
        /// </summary>
        /// <returns></returns>
        private IList<Int32> GetSelectedBIID()
        {
            IList<Int32> bIIDList = new List<Int32>();
            int count = 0;//用于保存选中的checkbox数量 
            for (int i = 0; i < dgvBillInfo.RowCount; i++)
            {
                if (dgvBillInfo.Rows[i].Cells[0].EditedFormattedValue.ToString() == "True")//这里判断复选框是否选中 
                {
                    Int32 bIID =Convert.ToInt32(dgvBillInfo.Rows[i].Cells["单据号"].Value);
                    bIIDList.Add(bIID);
                    count++;
                }
            }
            if (count == 0)
            {
                MessageBox.Show("请至少选择一条数据！", "提示");
                return null; ;
            }
            else
            {
                return bIIDList;
            }
        }

        private 
        #endregion


        private void toolSave_MouseEnter(object sender, EventArgs e)
        {
            ToolStripButton tsb = sender as ToolStripButton;
            if (tsb != null)
            {
                tsb.BackColor = Color.Purple;
            }
        }

        private void toolSave_MouseLeave(object sender, EventArgs e)
        {
            ToolStripButton tsb = sender as ToolStripButton;
            if (tsb != null)
            {
                tsb.BackColor = Color.SkyBlue;
            }
        }

        /// <summary>
        /// 窗体加载
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BillSerchListForm_Load(object sender, EventArgs e)
        {
            fDpiX = this.CreateGraphics().DpiX;
            fDpiY = this.CreateGraphics().DpiY;
            image = new ImageHelper().GetImageByByte(btm.TIBackground);
            width = Convert.ToInt32(MillimetersToPixel(Convert.ToSingle(btm.TIWidth), fDpiX));
            height = Convert.ToInt32(MillimetersToPixel(Convert.ToSingle(btm.TIHeight), fDpiY));
            dtControls = ControlsInfoManager.GetContrilPrintInfoByTemplateID(btm.TIID);
            dtBillList = ControlDetailManager.QueryBillInfoCDByPROCEDURE(btm.TIID);
            dgvBillInfo.DataSource = dtBillList;
        }

        private void toolPrInt32View_Click(object sender, EventArgs e)
        {
            PrintPreviewDialog dialog = new PrintPreviewDialog();
            Margins margin = new Margins(0, 0, 0, 0);
            pd.DefaultPageSettings.Margins = margin;
            PaperSize pageSize = new PaperSize("单据打印", Convert.ToInt32(MillimetersToPixel(Convert.ToInt32(btm.TIWidth), fDpiX)), Convert.ToInt32(MillimetersToPixel(Convert.ToInt32(btm.TIHeight), fDpiY)));
            pd.DefaultPageSettings.PaperSize = pageSize;
            dialog.Document = this.pd;
            dialog.PrintPreviewControl.AutoZoom = false;
            dialog.PrintPreviewControl.Zoom = 0.75;
            dialog.TopLevel = true;
            dialog.ShowDialog();
        }

        private void pd_PrintPage(object sender, PrintPageEventArgs e)
        {
            if (printBIIDlists != null && printBIIDlists.Count > 0)
            {
                page_Number = printBIIDlists.Count - 1;
                getOnePage(printBIIDlists[print_Index], e);
                if (print_Index != page_Number)
                {
                    e.HasMorePages = true;
                    print_Index++;
                    return;
                }
                print_Index = 0;
                page_Number = 0;
                e.HasMorePages = false;
            }
        }

        private void pd_BeginPrint(object sender, PrintEventArgs e)
        {
            printBIIDlists =this.GetSelectedBIID();
        }

        private void toolPrInt32_Click(object sender, EventArgs e)
        {
            Margins margin = new Margins(0, 0, 0, 0);
            pd.DefaultPageSettings.Margins = margin;
            //设置<打印文档>的纸张大小
            PaperSize pageSize = new PaperSize("单据打印", Convert.ToInt32(MillimetersToPixel(Convert.ToInt32(btm.TIWidth), fDpiX)), Convert.ToInt32(MillimetersToPixel(Convert.ToInt32(btm.TIHeight), fDpiY)));
            pd.DefaultPageSettings.PaperSize = pageSize;
            pd.Print();
        }

        private void toolPrInt32More_Click(object sender, EventArgs e)
        {
            Margins margin = new Margins(0, 0, 0, 0);
            pd.DefaultPageSettings.Margins = margin;
            //设置<打印文档>的纸张大小
            PaperSize pageSize = new PaperSize("单据打印", Convert.ToInt32(MillimetersToPixel(Convert.ToInt32(btm.TIWidth), fDpiX)), Convert.ToInt32(MillimetersToPixel(Convert.ToInt32(btm.TIHeight), fDpiY)));
            pd.DefaultPageSettings.PaperSize = pageSize;
            pd.Print();
        }

        private void toolSelectAll_Click(object sender, EventArgs e)
        {
            //全选

        }

        private void toolExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
