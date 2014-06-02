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
        private String strBillCode = String.Empty;// 保存单据号控件列名
        private Int32 StrBillCoumtID = 0;//保存 单据号控件对应控件ID
        private float fDpiX = 96;//横向分辨率
        private float fDpiY = 96;//纵向分辨率
        private Int32 width;//保存背景图片宽度
        private Int32 height;//保存背景图片高度
        private Image image;//保存图片对象
        private DataTable dtControls = null; //保存控件信息的datatable
        private DataTable dtBillLists = null; //保存票据信息的datatable
        private DataTable dtBillListItem = null;//dgv的数据源
        private BillTemplatModel btm = new BillTemplatModel();
        private IList<Int32> printBIIDlists = new List<Int32>();//打印的票据单号集合
        private int page_Number = 0;//总打印页数
        private int print_Index = 0;//当前打印的页数；
        private int pageSize = 0;//每页显示行数
        private int nMax = 0; //总记录数
        private int pageCount = 0;//页数=总记录数/每页显示行数
        private int pageCurrent = 0; //当前页号
        private int nCurrent = 0;//当前记录行
        public DataTable dtColumns = new DataTable(); //列信息的datatable
        private List<String> CoumnsName = new List<String>(); //列名集合
        private DataTable dtExcel = null;//保存从Excel 中读出的数据
        private bool Isleading = false;//标记是否导入了数据：false表示未导入
        #endregion

        #region 构造函数
        public BillSerchListForm()
        {
            InitializeComponent();
        }
        public BillSerchListForm(int code)
        {
            InitializeComponent();
            btm = BillTemplateManage.SelectTemplateModeltByID(code);
        }
        #endregion

        #region 自定义方法
       
        /// <summary>
        /// 计算页数
        /// </summary>
        private void InitDataTable(DataTable dtBillList)
        {
            pageSize = 10;      //设置页面行数
            nMax = dtBillList.Rows.Count;
            pageCount = (nMax / pageSize);    //计算出总页数
            if ((nMax % pageSize) > 0) pageCount++;
            pageCurrent = 1;    //当前页数从1开始
            nCurrent = 0;       //当前记录数从0开始
            LoadData(dtBillList);
        }

        
        /// <summary>
        /// 加载 dataGridView数据
        /// </summary>
        private void LoadData(DataTable dtBillList)
        {
            int nStartPos = 0;   //当前页面开始记录行
            int nEndPos = 0;     //当前页面结束记录行
            DataTable dtTemp = dtBillList.Clone();   //克隆DataTable结构框架
            if (pageCurrent == pageCount)
                nEndPos = nMax;
            else
                nEndPos = pageSize * pageCurrent;
            nStartPos = nCurrent;
            lblPageCount.Text = pageCount.ToString();
            lbCurrentPage.Text = Convert.ToString(pageCurrent);
            //从元数据源复制记录行
            for (int i = nStartPos; i < nEndPos; i++)
            {
                if (dtBillList.Rows[i] != null)
                {
                    dtTemp.ImportRow(dtBillList.Rows[i]);
                    nCurrent++;
                }
            }
            bdsInfo.DataSource = dtTemp;
            bdnInfo.BindingSource = bdsInfo;
            dgvBillInfo.DataSource = bdsInfo;
        }


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
                    try
                    {
                        //DataRow[] drs = dtCtrText.Select("CDCTIID = '" + Convert.ToInt32(dtControls.Rows[i]["CIID"]) + "'");
                        DataTable drtable = dtCtrText.Select("CDCTIID = '" + Convert.ToInt32(dtControls.Rows[i]["CIID"]) + "'").CopyToDataTable();
                        Brush brush = new SolidBrush(ColorTranslator.FromHtml(dtControls.Rows[i]["CTFontColor"].ToString()));
                        TextBox c = new TextBox();
                        if (drtable != null && drtable.Rows.Count > 0)
                        {
                            c.Text = drtable.Rows[0]["CDText"].ToString();
                            c.Location = new Point(Convert.ToInt32(dtControls.Rows[i]["CTLeft"]), Convert.ToInt32(dtControls.Rows[i]["CTTop"]));
                            c.Size = new Size(Convert.ToInt32(dtControls.Rows[i]["CTWidth"]), Convert.ToInt32(dtControls.Rows[i]["CTHeight"]));
                            c.Font = new CommonClass().GetFontByString(dtControls.Rows[i]["CTFont"].ToString());
                            if (dtControls.Rows[i]["CTType"].ToString() == "CheckBox")
                            {
                                if (c.Text == "是")
                                {
                                    e.Graphics.DrawString("√", c.Font, brush,
                                         c.Location.X,// + Convert.ToInt32(MillimetersToPixel(Convert.ToInt32(UserPrintSet.Left), fDpiX)),
                                         c.Location.Y);
                                }
                            }
                            else
                            {
                                e.Graphics.DrawString(c.Text, c.Font, brush,
                                    c.Location.X,// + Convert.ToInt32(MillimetersToPixel(Convert.ToInt32(UserPrintSet.Left), fDpiX)),
                                    c.Location.Y);// + Convert.ToInt32(MillimetersToPixel(Convert.ToInt32(UserPrintSet.Top), fDpiY)));

                            }
                        }
                    }
                    catch
                    {
 
                    }
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
                if (dgvBillInfo.Rows[i].Cells[0].EditedFormattedValue.ToString() == "True"
                    && dgvBillInfo.Rows[i].Cells[strBillCode] != null && dgvBillInfo.Rows[i].Cells[strBillCode].Value!=null
                    && dgvBillInfo.Rows[i].Cells[strBillCode].Value.ToString()!=String.Empty)//这里判断复选框是否选中 
                {
                    Int32 bIID = ControlDetailManager.SelectCDBIIDByCDText
                        (StrBillCoumtID, dgvBillInfo.Rows[i].Cells[strBillCode].Value.ToString());
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

        private void LoadGridViewData(DataTable dtList )
        {
            try
            {
            //    //清除现有列
                dgvBillInfo.DataSource = null;
                dgvBillInfo.Columns.Clear();
                DataGridViewCheckBoxColumn db = new DataGridViewCheckBoxColumn();
                db.Name = "Selected";
                db.HeaderText = "选择";
                dgvBillInfo.Columns.Add(db);
                dtControls = ControlsInfoManager.GetControlInfoByTemplateID(btm.TIID);
                if (dtControls != null && dtControls.Rows.Count > 0)
                {                   
                    DataRow[] matches = dtControls.Select(" CTIsFlage='true' ");
                    if (matches != null)
                    {
                        foreach (DataRow dr in dtControls.Rows)
                        {
                            String strColumnName = dr["CIID"].ToString();
                            dtList.Columns[strColumnName].ColumnName = dr["CTName"].ToString();
                            CoumnsName.Add(dr["CTName"].ToString());
                            //dgvBillInfo.Columns.Add(strColumnName, dr["CTName"].ToString());
                            //dgvBillInfo.Columns[strColumnName].DataPropertyName = strColumnName;
                            if (Convert.ToBoolean(dr["CTIsFlage"]))
                            {
                                strBillCode = dr["CTName"].ToString();
                                StrBillCoumtID =Convert.ToInt32(dr["CIID"].ToString());
                               // dgvBillInfo.Columns[strColumnName].ReadOnly = true;

                            }
                            DataRow drCO = dtColumns.NewRow();
                            drCO["CIID"] = Convert.ToInt32(dr["CIID"].ToString());
                            drCO["CIName"] = dr["CTName"].ToString();
                            dtColumns.Rows.Add(drCO);
                        }
                        InitDataTable(dtList);
                    }
                    else
                    {
                        MessageBox.Show("当前票据模板未设置单据号！无法打印！");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "软件提示");
            }
        }
        #endregion

        #region  窗体事件
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
            try
            {
                fDpiX = this.CreateGraphics().DpiX;
                fDpiY = this.CreateGraphics().DpiY;
                dtColumns.Columns.Add("CIID", typeof(Int32));
                dtColumns.Columns.Add("CIName", typeof(string));
                image = new ImageHelper().GetImageByByte(btm.TIBackground);
                width = Convert.ToInt32(MillimetersToPixel(Convert.ToSingle(btm.TIWidth), fDpiX));
                height = Convert.ToInt32(MillimetersToPixel(Convert.ToSingle(btm.TIHeight), fDpiY));
                dtControls = ControlsInfoManager.GetControlInfoByTemplateID(btm.TIID);
                dtBillLists = ControlDetailManager.QueryBillInfoCDByPROCEDURE(btm.TIID);
                dtBillListItem = dtBillLists;
                LoadGridViewData(dtBillListItem);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "软件提示");
            }
        }

        /// <summary>
        /// 打印预览
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolPrInt32View_Click(object sender, EventArgs e)
        {
            try
            {
                if (!Isleading)
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
                else
                {
                    MessageBox.Show("您导入了数据，请先点击保存后再打印", "软件提示");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "软件提示");
            }
        }

        /// <summary>
        /// 画打印上下文
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void pd_PrintPage(object sender, PrintPageEventArgs e)
        {
            try
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
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "软件提示");
            }
        }

        /// <summary>
        /// 打印前事件，每次打印只调用一次
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void pd_BeginPrint(object sender, PrintEventArgs e)
        {
            try
            {
                printBIIDlists = this.GetSelectedBIID();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "软件提示");
            }

        }


        /// <summary>
        /// 批量打印按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolPrInt32More_Click(object sender, EventArgs e)
        {
            try
            {
                if (!Isleading)
                {
                    Margins margin = new Margins(0, 0, 0, 0);
                    pd.DefaultPageSettings.Margins = margin;
                    //设置<打印文档>的纸张大小
                    PaperSize pageSize = new PaperSize("单据打印", Convert.ToInt32(MillimetersToPixel(Convert.ToInt32(btm.TIWidth), fDpiX)), Convert.ToInt32(MillimetersToPixel(Convert.ToInt32(btm.TIHeight), fDpiY)));
                    pd.DefaultPageSettings.PaperSize = pageSize;
                    pd.Print();
                }
                else
                {
                    MessageBox.Show("您导入了数据，请先点击保存后再打印");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(),"软件提示");
            }
        }

        /// <summary>
        /// 退出
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// 导航按钮点击
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void bdnInfo_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            try
            {
                if (e.ClickedItem.Text == "上一页")
                {
                    pageCurrent--;
                    if (pageCurrent <= 0)
                    {

                        btnHome.Enabled = false;
                        btnPrevious.Enabled = false;
                        btnNext.Enabled = true;
                        btnLastPage.Enabled = true;
                        MessageBox.Show("已经是第一页，请点击“下一页”查看！");
                        return;
                    }
                    else
                    {

                        nCurrent = pageSize * (pageCurrent - 1);
                        btnNext.Enabled = true;
                        btnLastPage.Enabled = true;
                    }
                    LoadData(dtBillListItem);
                }
                if (e.ClickedItem.Text == "下一页")
                {
                    pageCurrent++;
                    if (pageCurrent > pageCount)
                    {

                        btnHome.Enabled = true;
                        btnPrevious.Enabled = true;
                        btnNext.Enabled = false;
                        btnLastPage.Enabled = false;
                        MessageBox.Show("已经是最后一页，请点击“上一页”查看！");
                        return;
                    }
                    else
                    {
                        nCurrent = pageSize * (pageCurrent - 1);
                        btnHome.Enabled = true;
                        btnPrevious.Enabled = true;
                    }
                    LoadData(dtBillListItem);
                }
                if (e.ClickedItem.Text == "首页")
                {
                    pageCurrent = 1;//当前页号设置为1   
                    nCurrent = pageSize * (pageCurrent - 1);
                    //当前记录行 == 每页显示行数 * (当前页号减1 )   
                    LoadData(dtBillListItem);//执行分页功能显示出数据 
                    btnPrevious.Enabled = false;
                    btnHome.Enabled = false;
                    btnNext.Enabled = true;
                    btnLastPage.Enabled = true;
                }
                if (e.ClickedItem.Text == "尾页")
                {
                    pageCurrent = Convert.ToInt32(lblPageCount.Text);//当前页号设置为 总页数   
                    nCurrent = pageSize * (pageCurrent - 1);//当前记录行 == 每页显示行数 * (当前页号减1 )   
                    LoadData(dtBillListItem);////执行分页功能显示出数据 
                    btnHome.Enabled = true;
                    btnPrevious.Enabled = true;
                    btnNext.Enabled = false;
                    btnLastPage.Enabled = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "软件提示");
            }
        }

        /// <summary>
        /// 全选
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolSelectAll_Click(object sender, EventArgs e)
        {
            try
            {
                for (int i = 0; i < this.dgvBillInfo.Rows.Count; i++)
                {
                    this.dgvBillInfo["Selected", i].Value = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "软件提示");
            }
        }

        /// <summary>
        /// 取消
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolClearAll_Click(object sender, EventArgs e)
        {
            try
            {
                for (int i = 0; i < this.dgvBillInfo.Rows.Count; i++)
                {
                    this.dgvBillInfo["Selected", i].Value = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "软件提示");
            }

        }

        /// <summary>
        /// 弹出过滤窗口
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolSerch_Click(object sender, EventArgs e)
        {
            try
            {
                FilterForm ff = new FilterForm(CoumnsName);
                ff.ShowDialog();
                if (ff.sLinqString != string.Empty)
                {
                    DataTable dtItem = dtBillLists.Select(ff.sLinqString).CopyToDataTable();
                    dtBillListItem = dtItem;
                    InitDataTable(dtItem);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        /// <summary>
        /// 导入
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolLeading_Click(object sender, EventArgs e)
        { 
            try
            {
                OpenFileDialog openfile = new OpenFileDialog();
                if (openfile.ShowDialog() == DialogResult.OK)
                {
                    DataSet dsexcel = ExcelHelper.ImportExcel(openfile.FileName);
                    dtExcel = dsexcel.Tables[0];
                    if (dtExcel.Columns.Count == dtBillListItem.Columns.Count)
                    {
                        for (int i = 1; i < dtExcel.Rows.Count; i++)
                        {
                            //从第二行开始添加
                            dtBillListItem.Rows.Add(dtExcel.Rows[i].ItemArray);
                        }
                        Isleading = true;
                        InitDataTable(dtBillListItem);
                    }
                    else
                    {
                        MessageBox.Show("所加载的EXCEL文件数据和当前票据不符", "软件提示");
                    }
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        /// <summary>
        /// 导出
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolExport_Click(object sender, EventArgs e)
        {
            try
            {
                dtBillListItem.TableName = "票据信息";
                ExcelHelper.SaveAsExcel(dtBillListItem);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "软件提示");
            }
        }

        /// <summary>
        /// 保存按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolSave_Click(object sender, EventArgs e)
        {
            try
            {
                List<ControlDetail> cdlist = new List<ControlDetail>();//保存控件明细实体
                if (dtExcel != null && dtExcel.Rows.Count > 0)
                {
                    //导入了数据
                    for (int i = 1; i < dtExcel.Rows.Count; i++)
                    {//从第二行开始添加数据
                        BillInfo bi = new BillInfo();
                        bi.BINo = BillInfoManager.CreatNewID(btm.TICodeLegth, btm.TIID);///创建新的票据单号
                        bi.BIName = bi.BINo;
                        bi.BITIID = btm.TIID;
                        bi.BIIsEnable = 1;
                        bi.BIID = BillInfoManager.AddBillInfo(bi);//更新数据库返回自增ID
                        for (int k = 0; k < dtExcel.Columns.Count; k++)
                        {
                            ControlDetail cd = new ControlDetail();
                            cd.CDBIID = bi.BIID;
                            cd.CDCTIID = Convert.ToInt32(dtColumns.Rows[k]["CIID"].ToString());//获取列名对应的控件ID
                            cd.CDText = dtExcel.Rows[i][k].ToString();//控件内容
                            cd.CDTIID = btm.TIID;
                            cd.CDIsEnable = 1;
                            cdlist.Add(cd);
                        }
                    }
                    if (cdlist != null && cdlist.Count > 0)
                    {
                        if (ControlDetailManager.AddlControlDetailByList(cdlist) > 0)
                        {
                            #region 刷新数据源
                            dtControls = ControlsInfoManager.GetControlInfoByTemplateID(btm.TIID);
                            dtBillLists = ControlDetailManager.QueryBillInfoCDByPROCEDURE(btm.TIID);
                            dtBillListItem = dtBillLists;
                            LoadGridViewData(dtBillListItem);
                            #endregion
                            MessageBox.Show("更新成功！您现在可以打印了！");
                            Isleading = false;
                        }
                    }
                }
                else
                {
                    MessageBox.Show("未导入数据，无需保存！");
                    return;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        #endregion
    }
}
