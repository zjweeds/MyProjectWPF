

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
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                tabList.TabPages.Add(dt.Rows[i]["TTName"].ToString());
            }
            for (int i = 0; i < tabList.TabCount; i++)
            {
                LoadListView(i);  //生成内容 
                LoadImage(i, lsvs[i], imgls[i]); //绑定图片和项
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
                //MessageBox.Show(dt.Rows[i]["TIBackground"].ToString());
                //String imagepath = new SoftConfigModer().softImagePath + @"\\" + dt.Rows[i]["TITTID"].ToString() + @"\\" + dt.Rows[i]["TIID"].ToString() +".png";
                //String imagepath = "D:\\2.jpg";
                //System.Drawing.Image m_image = imahelper.GetImageByPath(imagepath);
                System.Drawing.Image m_image;
                try
                {
                     m_image = imahelper.GetImageByByte(dt.Rows[i]["TIBackground"] as byte[]);
                }
                catch
                {
                    String imagepath =@"D:\\Resource\农行.jpg";
                    m_image = imahelper.GetImageByPath(imagepath);
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
        }

        /// <summary>
        /// 按钮经过事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_MouseEnter(object sender, MouseEventArgs e)
        {
            e.Handled = true;
            Button b = sender as Button;
            if (b != null)
            {
                b.Background = new SolidColorBrush(Colors.Purple);
                b.Foreground = new SolidColorBrush(Colors.White);
            }
        }

        /// <summary>
        /// 按钮移开事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_MouseLeave(object sender, MouseEventArgs e)
        {
             e.Handled = true;
            Button b = sender as Button;
                        if (b != null)
            {
                b.Background = new SolidColorBrush(Color.FromRgb(150,135,199));
                b.Foreground = new SolidColorBrush(Colors.Black);
            }
        }

        /// <summary>
        /// 双击选择项，跳转到打印界面
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lsv_DoubleClick(object sender, EventArgs e)
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

        /// <summary>
        /// 新增模板
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnTemplateAdd_Click(object sender, RoutedEventArgs e)
        {
            TemplateProperyEdit tpe = new TemplateProperyEdit();
            tpe.Show();
        }      

        /// <summary>
        /// 票据设计
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnTemplateDesign_Click(object sender, RoutedEventArgs e)
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

        /// <summary>
        /// 票据查询
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnBillSerch_Click(object sender, RoutedEventArgs e)
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

        /// <summary>
        /// 批量打印
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnPrints_Click(object sender, RoutedEventArgs e)
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

        /// <summary>
        /// 新增票夹
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnBillTypeAdd_Click(object sender, RoutedEventArgs e)
        {
            //String typeName =  tabList.SelectedTab.Text.ToString();
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

        /// <summary>
        /// 重命名票夹
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnBillTypeReName_Click(object sender, RoutedEventArgs e)
        {
            String typeName = tabList.SelectedTab.Text.ToString();
            TemplateTypeEdit tte = new TemplateTypeEdit(typeName,this);
            tte.ShowDialog();
            if (templateName != string.Empty)
            {
                tabList.SelectedTab.Text = templateName;
                templateName = String.Empty;
            }
        }

        /// <summary>
        /// 删除票夹
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnBillTypeDelete_Click(object sender, RoutedEventArgs e)
        {
            String typeName = tabList.SelectedTab.Text.ToString();
            if (MessageBox.Show("将删除类别：" + typeName 
                + "下的所有票据和账单，此操作不可恢复，确定要删除吗？", "软件提示", 
                MessageBoxButton.YesNo,MessageBoxImage.Exclamation)==MessageBoxResult.Yes)
            {
                //删除数据
            }
        }

        /// <summary>
        /// 复制模板
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnTemplateCopy_Click(object sender, RoutedEventArgs e)
        {


        }

        /// <summary>
        /// 剪切模板
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnTemplateCut_Click(object sender, RoutedEventArgs e)
        {
            System.Windows.Forms.ListView lsvItem = SelectForce(lsvs);
            if (lsvItem != null)
            {
                if (lsvItem.SelectedItems.Count > 0)
                {
                    //BillSerchListForm blf = new BillSerchListForm(Convert.ToInt32(lsvItem.SelectedItems[0].Name.ToString()));
                    //blf.Show();
                    
                }
                else
                {
                    MessageBox.Show("请先选择票据", "软件提示");
                }
            }
        }

        /// <summary>
        /// 票据粘贴
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnTemplateStick_Click(object sender, RoutedEventArgs e)
        {
            System.Windows.Forms.ListView lsvItem = SelectForce(lsvs);
            if (lsvItem != null)
            {
                if (lsvItem.SelectedItems.Count > 0)
                {
                    //BillSerchListForm blf = new BillSerchListForm(Convert.ToInt32(lsvItem.SelectedItems[0].Name.ToString()));
                    //blf.Show();

                }
                else
                {
                    MessageBox.Show("请先选择票据", "软件提示");
                }
            }
        }
        #endregion
    }
}
