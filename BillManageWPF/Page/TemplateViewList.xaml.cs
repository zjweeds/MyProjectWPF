

#region 引入命名空间
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using BillManageWPF.Content.Template;
using System.Data;
using Controllers.Business;
using Controllers.Models;
using Controllers.Common;
using BillManageWPF.winFormUI;
using System.IO;

#endregion

namespace BillManageWPF.Page
{
    /// <summary>
    /// TemplateViewList.xaml 的交互逻辑
    /// </summary>
    public partial class TemplateViewList : UserControl
    {
        #region 构造函数
        public TemplateViewList()
        {
            InitializeComponent();
        }
        #endregion

        #region 页面属性
        private BillTemplatModel btmItem = new BillTemplatModel();//复制，剪切模板时，临时保存模板信息
        IList<ControlInfo> conList = new List<ControlInfo>();////复制，剪切模板时，临时保存模板控件信息
        private int skiType = 0;//粘贴标记：-1：复制，1，剪切
        private BillTemplatModel btm = new BillTemplatModel();
        private ImageHelper imahelper = new ImageHelper();
        private DataTable dt = new DataTable();
        private List<System.Windows.Forms.ListView> lsvs = new List<System.Windows.Forms.ListView>();
        private List<System.Windows.Forms.ImageList> imgls = new List<System.Windows.Forms.ImageList>();
        public String templateName = String.Empty; 
        #endregion

        #region 自定义方法
        /// <summary>
        /// 加载每一页内容
        /// </summary>
        private void DoLoad()
        {
            tabList.TabPages.Clear();
            DataTable dt = BillTemplateTypeManage.GetAllTypeByBillsetName(SoftUser.Op_Bill);
            if (dt != null && dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    tabList.TabPages.Add(dt.Rows[i]["TTName"].ToString()); //添加票夹名称
                }
                for (int i = 0; i < tabList.TabCount; i++)
                {
                    LoadListView(i);  //生成内容 
                    LoadImage(i, lsvs[i], imgls[i]); //绑定图片和项
                }
            }
        }

        /// <summary>
        /// 刷新指定页
        /// </summary>
        /// <param name="type"></param>
        public void UpdataView(String type)
        {
            for (int i = 0; i < tabList.TabPages.Count; i++)
            {
                if (tabList.TabPages[i].Text == type)
                {
                    LoadImage(i, lsvs[i], imgls[i]);
                }
            }
        }
        /// <summary>
        /// 给每一个tabpage动态生成一个listview
        /// </summary>
        /// <param name="i"></param>
        public void LoadListView(int i)
        {
            System.Windows.Forms.ListView lsv = new System.Windows.Forms.ListView();
            lsv.DoubleClick += new EventHandler(lsv_DoubleClick);//绑定事件
            lsvs.Add(lsv);
            lsvs[i].Name = i.ToString();
            System.Windows.Forms.ImageList imgl = new System.Windows.Forms.ImageList();
            imgls.Add(imgl);
        }

        /// <summary>
        /// 给每一项绑定图片
        /// </summary>
        /// <param name="PageIndex"></param>
        /// <param name="lsvItem"></param>
        /// <param name="imlist"></param>
        public void LoadImage(int PageIndex, System.Windows.Forms.ListView lsvItem, System.Windows.Forms.ImageList imlist)
        {
            String path = AppDomain.CurrentDomain.BaseDirectory + @"Images\" + SoftUser.Op_Bill;
            lsvItem.Items.Clear();
            lsvItem.Dock = System.Windows.Forms.DockStyle.Fill;
            imlist.Images.Clear();
            tabList.TabPages[PageIndex].Controls.Add(lsvItem);
            dt = BillTemplateManage.GetDataTableByTypeName(tabList.TabPages[PageIndex].Text); //bts.GetDataTableByTypeName(tabList.TabPages[PageIndex].Text);
            imlist.ImageSize = new System.Drawing.Size(250, 125);
            lsvItem.LargeImageList = imlist;
            lsvItem.SmallImageList = imlist;
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                String imagepath = path + @"\" + tabList.TabPages[PageIndex].Text + @"\" + dt.Rows[i]["TIID"].ToString() + ".jpg";
                System.Drawing.Image m_image;
                if (File.Exists(imagepath))
                {
                    //存在背景图缓存
                    m_image = imahelper.GetImageByPath(imagepath);
                }
                else
                {
                    //不存在，在数据库中读取
                    try
                    {
                        m_image = imahelper.GetImageByByte(dt.Rows[i]["TIBackground"] as byte[]);
                    }
                    catch
                    {
                        //字节流转换成图片失败
                        String defaultimP = @"D:\\Resource\农行.jpg";//启用默认的背景图
                        m_image = imahelper.GetImageByPath(defaultimP);
                    }
                }
                imlist.Images.Add(m_image);
                lsvItem.Items.Add(dt.Rows[i]["TIName"].ToString());
                lsvItem.Items[i].Name = dt.Rows[i]["TIID"].ToString();
                lsvItem.Items[i].ImageIndex = i;
            }
        }
        
        /// <summary>
        /// 获取当前操作的页面
        /// </summary>
        /// <param name="lsvs"></param>
        /// <returns></returns>
        private System.Windows.Forms.ListView SelectForce(List<System.Windows.Forms.ListView> lsvs)
        {
            int mark = 0;
            foreach (System.Windows.Forms.ListView lsv in lsvs)
            {
                if (lsv.SelectedItems.Count > 0)
                {
                    mark = 1;
                    return lsv;
                }
            }
            if (mark == 0)
            {
                MessageBox.Show("请先选择票据！", "软件提示");
            }
            return null;
        }

        /// <summary>
        /// 获取当前选定的模板
        /// </summary>
        /// <param name="sender">当前操作的对象</param>
        /// <returns>模板编号；若返回-1表示为选择</returns>
        private int GetForceTemplateID(object sender)
        {
            System.Windows.Forms.ListView lsv = (System.Windows.Forms.ListView)(sender);
            if (lsv.SelectedItems.Count > 0)
            {
                return Convert.ToInt32(lsv.SelectedItems[0].Name.ToString());
            }
            else
            {
                return -1;
            }
        }

        //打开文件
        private string OpenPath()
        {
            System.Windows.Forms.OpenFileDialog openFileDialog = new System.Windows.Forms.OpenFileDialog();
            openFileDialog.InitialDirectory = "c:\\";
            openFileDialog.Filter = "EXCEL文件|*.xls";
            openFileDialog.RestoreDirectory = true;
            openFileDialog.FilterIndex = 1;
            if (openFileDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                return openFileDialog.FileName;
            }
            else
            {
                return "";
            }
        }
        #endregion

        #region  页面事件

        /// <summary>
        /// 载入事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
                tabList.ItemSize = new System.Drawing.Size(50, 30);
                DoLoad();
                btnTemplateStick.IsEnabled = false;
        }

        /// <summary>
        /// 按钮经过事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_MouseEnter(object sender, MouseEventArgs e)
        {
            try
            {
                e.Handled = true;
                Button b = sender as Button;
                if (b != null)
                {
                    b.Background = new SolidColorBrush(Colors.Purple);
                    b.Foreground = new SolidColorBrush(Colors.White);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        /// <summary>
        /// 按钮移开事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_MouseLeave(object sender, MouseEventArgs e)
        {
            try
            {
                e.Handled = true;
                Button b = sender as Button;
                if (b != null)
                {
                    b.Background = new SolidColorBrush(Color.FromRgb(150, 135, 199));
                    b.Foreground = new SolidColorBrush(Colors.Black);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        /// <summary>
        /// 双击选择项，跳转到打印界面
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lsv_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                int tIID = GetForceTemplateID(sender);//获取当前操作的ID
                if (tIID > 0)
                {
                    TemplatePrint pf = new TemplatePrint(tIID);
                    pf.Show();
                }
                else
                {
                    MessageBox.Show("请先选择票据", "软件提示");
                    return;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        /// <summary>
        /// 新增模板
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnTemplateAdd_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                TemplateProperyEdit tpe = new TemplateProperyEdit(tabList.SelectedTab.Text);
                tpe.ShowDialog();
                UpdataView(tabList.SelectedTab.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }   

        /// <summary>
        /// 票据设计
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnTemplateDesign_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                System.Windows.Forms.ListView lsvItem = SelectForce(lsvs);
                if (lsvItem != null)
                {
                    if (lsvItem.SelectedItems.Count > 0)
                    {
                        TemplateMain tm = new TemplateMain(Convert.ToInt32(lsvItem.SelectedItems[0].Name.ToString()));
                        tm.Show();
                    }
                    else
                    {
                        MessageBox.Show("请先选择票据", "软件提示");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        /// <summary>
        /// 票据查询
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnBillSerch_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                System.Windows.Forms.ListView lsvItem = SelectForce(lsvs);
                if (lsvItem != null)
                {
                    if (lsvItem.SelectedItems.Count > 0)
                    {
                        BillSerchListForm blf = new BillSerchListForm(Convert.ToInt32(lsvItem.SelectedItems[0].Name.ToString()));
                        blf.Show();
                    }
                    else
                    {
                        MessageBox.Show("请先选择票据", "软件提示");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        /// <summary>
        /// 批量打印
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnPrints_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                System.Windows.Forms.ListView lsvItem = SelectForce(lsvs);
                if (lsvItem != null)
                {
                    if (lsvItem.SelectedItems.Count > 0)
                    {
                        BillSerchListForm blf = new BillSerchListForm(Convert.ToInt32(lsvItem.SelectedItems[0].Name.ToString()));
                        blf.Show();
                    }
                    else
                    {
                        MessageBox.Show("请先选择票据", "软件提示");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        /// <summary>
        /// 新增票夹
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnBillTypeAdd_Click(object sender, RoutedEventArgs e)
        {
            //String typeName =  tabList.SelectedTab.Text.ToString();
            try
            {
                TemplateTypeEdit tte = new TemplateTypeEdit(this);
                tte.ShowDialog();
                if (templateName != string.Empty)//不为空表示有更新
                {
                    tabList.TabPages.Add(templateName);//添加一页
                    templateName = String.Empty;//还原标记
                    int index = tabList.TabPages.Count - 1;
                    LoadListView(index);//添加页面listview 
                    LoadImage(index, lsvs[index], imgls[index]);//添加image
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        /// <summary>
        /// 重命名票夹
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnBillTypeReName_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                String typeName = tabList.SelectedTab.Text.ToString();
                TemplateTypeEdit tte = new TemplateTypeEdit(typeName, this);
                tte.ShowDialog();
                if (templateName != string.Empty)
                {
                    tabList.SelectedTab.Text = templateName;
                    templateName = String.Empty;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        /// <summary>
        /// 删除票夹
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnBillTypeDelete_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                String typeName = tabList.SelectedTab.Text.ToString();
                if (MessageBox.Show("将删除类别：" + typeName
                    + ",确定要删除吗？", "软件提示",
                    MessageBoxButton.YesNo, MessageBoxImage.Exclamation) == MessageBoxResult.Yes)
                {
                    //删除数据
                    BillSetManager.DeleteByName(typeName);

                    #region 刷新
                    tabList.ItemSize = new System.Drawing.Size(50, 30);
                    DoLoad();
                    btnTemplateStick.IsEnabled = false;
                    #endregion
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        /// <summary>
        /// 复制模板
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnTemplateCopy_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (btnTemplateCopy.Content.ToString() == "复制模板")
                {
                    System.Windows.Forms.ListView lsvItem = SelectForce(lsvs);
                    if (lsvItem != null)
                    {
                        if (lsvItem.SelectedItems.Count > 0)
                        {
                            int TIID = Convert.ToInt32(lsvItem.SelectedItems[0].Name.ToString());
                            btmItem = BillTemplateManage.SelectTemplateModeltByID(TIID);
                            conList = ControlsInfoManager.SelectControlInfosByTemplateID(TIID);
                            btnBillSerch.IsEnabled = false;
                            btnBillTypeAdd.IsEnabled = false;
                            btnBillTypeDelete.IsEnabled = false;
                            btnBillTypeReName.IsEnabled = false;
                            btnPrints.IsEnabled = false;
                            btnTemplateAdd.IsEnabled = false;
                            btnTemplateCut.IsEnabled = false;
                            btnTemplateDelet.IsEnabled = false;
                            btnTemplateDesign.IsEnabled = false;
                            btnTemplateExport.IsEnabled = false;
                            btnTemplateStick.IsEnabled = true;
                            btnTemplateCopy.Content = "取消";
                            skiType = -1;
                        }
                        else
                        {
                            MessageBox.Show("请先选择票据模板", "软件提示");
                        }
                    }
                }
                else
                {
                    btmItem = null;
                    conList = null;
                    btnTemplateCopy.Content = "复制模板";
                    btnBillSerch.IsEnabled = true;
                    btnBillTypeAdd.IsEnabled = true;
                    btnBillTypeDelete.IsEnabled = true;
                    btnBillTypeReName.IsEnabled = true;
                    btnPrints.IsEnabled = true;
                    btnTemplateAdd.IsEnabled = true;
                    btnTemplateCut.IsEnabled = true;
                    btnTemplateDelet.IsEnabled = true;
                    btnTemplateDesign.IsEnabled = true;
                    btnTemplateExport.IsEnabled = true;
                    btnTemplateStick.IsEnabled = false;
                    skiType = 0;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        /// <summary>
        /// 剪切模板
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnTemplateCut_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (btnTemplateCut.Content.ToString() == "剪切模板")
                {
                    System.Windows.Forms.ListView lsvItem = SelectForce(lsvs);
                    if (lsvItem != null)
                    {
                        if (lsvItem.SelectedItems.Count > 0)
                        {
                            int TIID = Convert.ToInt32(lsvItem.SelectedItems[0].Name.ToString());
                            btmItem = BillTemplateManage.SelectTemplateModeltByID(TIID);
                            btnBillSerch.IsEnabled = false;
                            btnBillTypeAdd.IsEnabled = false;
                            btnBillTypeDelete.IsEnabled = false;
                            btnBillTypeReName.IsEnabled = false;
                            btnPrints.IsEnabled = false;
                            btnTemplateAdd.IsEnabled = false;
                            btnTemplateCopy.IsEnabled = false;
                            btnTemplateDelet.IsEnabled = false;
                            btnTemplateDesign.IsEnabled = false;
                            btnTemplateExport.IsEnabled = false;
                            btnTemplateStick.IsEnabled = true;
                            btnTemplateCut.Content = "取消";
                            skiType = 1;
                        }
                        else
                        {
                            MessageBox.Show("请先选择票据模板", "软件提示");
                        }
                    }
                }
                else
                {
                    btmItem = null;
                    btnTemplateCut.Content = "剪切模板";
                    btnBillSerch.IsEnabled = true;
                    btnBillTypeAdd.IsEnabled = true;
                    btnBillTypeDelete.IsEnabled = true;
                    btnBillTypeReName.IsEnabled = true;
                    btnPrints.IsEnabled = true;
                    btnTemplateAdd.IsEnabled = true;
                    btnTemplateCopy.IsEnabled = true;
                    btnTemplateDelet.IsEnabled = true;
                    btnTemplateDesign.IsEnabled = true;
                    btnTemplateExport.IsEnabled = true;
                    btnTemplateStick.IsEnabled = false;
                    skiType = 0;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        /// <summary>
        /// 粘贴模板
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnTemplateStick_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                int ttid = BillTemplateTypeManage.GetTemplateTypeIdByName(tabList.SelectedTab.Text);
                String OldTypeName = BillTemplateTypeManage.GetTemplateTypeNameById(btmItem.TITTID);
                if (skiType == -1)
                {
                    //复制
                    btmItem.TITTID = ttid;
                    int tiid = BillTemplateManage.AddByBillTemplatModel(btmItem);
                    foreach (ControlInfo ci in conList)
                    {
                        ci.CTITIID = tiid;
                        ControlsInfoManager.AddControlInfo(ci);
                    }
                }
                else if (skiType == 1)
                {
                    //粘贴
                    btmItem.TITTID = ttid;
                    BillTemplateManage.UpdateByBillTemplatModel(btmItem);
                }
                UpdataView(tabList.SelectedTab.Text);//刷新当前页
                UpdataView(OldTypeName);//刷新被操作的页
                btmItem = null;
                conList = null;
                btnTemplateCopy.Content = "复制模板";
                btnTemplateCopy.IsEnabled = true;
                btnTemplateCut.Content = "剪切模板";
                btnBillSerch.IsEnabled = true;
                btnBillTypeAdd.IsEnabled = true;
                btnBillTypeDelete.IsEnabled = true;
                btnBillTypeReName.IsEnabled = true;
                btnPrints.IsEnabled = true;
                btnTemplateAdd.IsEnabled = true;
                btnTemplateCut.IsEnabled = true;
                btnTemplateDelet.IsEnabled = true;
                btnTemplateDesign.IsEnabled = true;
                btnTemplateExport.IsEnabled = true;
                btnTemplateStick.IsEnabled = false;
                skiType = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        #endregion

        /// <summary>
        /// 导出模板
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnTemplateExport_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                String path = String.Empty;//保存选定的文件路径
                DataSet ds = new DataSet();//保存模板及对应控件的信息
                System.Windows.Forms.ListView lsvItem = SelectForce(lsvs);
                if (lsvItem != null)
                {
                    if (lsvItem.SelectedItems.Count > 0)
                    {
                        int TIID = Convert.ToInt32(lsvItem.SelectedItems[0].Name.ToString());//获取选定的模板编号
                        DataTable dtTemp = BillTemplateManage.GetDataTableByID(TIID);
                        dtTemp.TableName = "模板信息";
                        ds.Tables.Add(dtTemp);
                        DataTable dtControl = ControlsInfoManager.GetControlInfoByTemplateID(TIID);// .GetDataTableByID(TIID);
                        dtControl.TableName = "控件信息";
                        ds.Tables.Add(dtControl);
                        String mesg = String.Format(
                            "即将导出模板{0}，会在您选定的保存文件夹下生成模板信息文件和模板背景图（BackImage文件夹下）\n请注意保持信息文件的完整性和一致性\n确定导出么？"
                            , dtTemp.Rows[0]["TIName"].ToString());
                        if (MessageBox.Show(mesg, "软件提示", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                        {
                            //WaitWindow ww = new WaitWindow();
                            //ww.Show();
                            ExcelHelper.ExportToExcel(ds, out path);
                            String imagepath = path.Substring(0, path.LastIndexOf(@"\")) + @"\BackImage\" + dtTemp.Rows[0]["TIID"].ToString() + ".jpg";
                            imahelper.SaveImage(imahelper.GetImageByByte(dtTemp.Rows[0]["TIBackground"] as byte[]), imagepath);
                            MessageBox.Show("导出成功！", "软件提示");
                        }
                    }
                    else
                    {
                        MessageBox.Show("请先选择票据", "软件提示");
                    }
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.ToString(), "软件提示");
            }
        }

        private void btnTemplateLeading_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                DataSet dsExcelTemp = new DataSet();
                DataSet dsExcelControl = new DataSet();
                ExcelHelper exh = new ExcelHelper();
                String s_OpenPath = OpenPath();
                if (s_OpenPath != String.Empty)
                {
                    //dsExcelTemp = ExcelHelper.ImportExcel(s_OpenPath);
                    dsExcelTemp = exh.GetExcelDs(s_OpenPath, "模板信息");
                    dsExcelControl = exh.GetExcelDs(s_OpenPath, "控件信息");
                    byte[] imageByte = null;
                    String imagepath = s_OpenPath.Substring(0, s_OpenPath.LastIndexOf(@"\"))
                        + @"\BackImage\" + dsExcelTemp.Tables[0].Rows[0]["TIID"].ToString() + ".jpg";
                    if (File.Exists(imagepath))
                    {
                        imageByte = new ImageHelper().GetBytesByImagepath(imagepath);
                    }
                    else
                    {
                        if (MessageBox.Show("未找到对应的模板背景图信息，是否手动指定图片？", "软件提示", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                        {

                            System.Windows.Forms.OpenFileDialog dlgPicture = new System.Windows.Forms.OpenFileDialog();
                            if (dlgPicture.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                            {
                                imageByte = new ImageHelper().GetBytesByImagepath(dlgPicture.FileName);
                            }
                            else
                            {
                                imageByte = new ImageHelper().GetBytesByImagepath(AppDomain.CurrentDomain.BaseDirectory + "\\Resource\\defaulticon.jpg");
                            }
                        }
                        else
                        {
                            imageByte = new ImageHelper().GetBytesByImagepath(AppDomain.CurrentDomain.BaseDirectory + "\\Resource\\defaulticon.jpg");
                        }
                    }
                    dsExcelTemp.Tables[0].Rows[0]["TITTID"] = BillTemplateTypeManage.GetTemplateTypeIdByName(tabList.SelectedTab.Text);
                    int TIID = BillTemplateManage.AddByDataTable(dsExcelTemp.Tables[0], imageByte);
                    if (TIID > 0)
                    {
                        for (int j = 0; j < dsExcelControl.Tables[0].Rows.Count; j++)
                        {
                            dsExcelControl.Tables[0].Rows[j]["CTITIID"] = TIID;
                        }
                        if (ControlsInfoManager.AddByDataTable(dsExcelControl.Tables[0]))
                        {
                            MessageBox.Show("导入成功！");
                            UpdataView(tabList.SelectedTab.Text);
                        }
                    }
                    else
                    {
                        MessageBox.Show("导入失败！");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
    }
}
