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
using Controllers.Business;
using Controllers.Moders.TableModers;
using Controllers.Moders;
using Controllers.Common;
using System.Data;

namespace BillManageMain.Pages.UserControlPages
{
    /// <summary>
    /// BillTemplateView.xaml 的交互逻辑
    /// </summary>
    public partial class BillTemplateView : UserControl
    {
        public BillTemplateView()
        {
            InitializeComponent();
        }
        DataTable dt = null;
        TabManageService tms = new TabManageService();
        String BillSetName = String.Empty;
        String CompanyName = String.Empty;
        List<ListView> lsvs = new List<ListView>();
        List<BitmapImage> imagelist = new List<BitmapImage>();
        List<BillTemplatModer> btms = null;
        ImageHelper imhelper = new ImageHelper();
        /// <summary>
        /// 加载所有模板类别
        /// </summary>
        /// <param name="BillSetName"></param>
        /// <param name="CompanyName"></param>
        public void loadItem(String BillSetName, String CompanyName)
        {
            dt = tms.SelectTemplateType(BillSetName, CompanyName);
            if (dt != null)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    TabItem ti = new TabItem();
                    ListView lsv = new ListView();
                    lsvs.Add(lsv);
                    ti.Name = dt.Rows[i][0].ToString();
                    ti.Header = ti.Name;
                    ti.Content = lsv;
                    TabMenu.Items.Add(ti);
                }
            }
        }
        /// <summary>
        /// 加载模板信息
        /// </summary>
        /// <param name="tabIndex"></param>
        /// <param name="Billtype"></param>
        /// <param name="BillSetName"></param>
        /// <param name="CompanyName"></param>
        public void loadImage(int tabIndex, String BillSetName, String CompanyName)
        {
            btms = tms.GetListBillTemplatModer(((TabItem)TabMenu.Items[tabIndex]).Header.ToString(), BillSetName, CompanyName);
            if (btms != null && btms.Count >= 0)
            {
                foreach(BillTemplatModer btm in btms )
                {
                    BitmapImage im = imhelper.GetBitmapImageByByte(btm.TIIcon);                    
                    imagelist.Add(im);
                    lsvs[tabIndex].Items.Add(btm.TIName);
                    lsvs[tabIndex].MouseDoubleClick +=new MouseButtonEventHandler(lsv_DoubleClick);
                    lsvs[tabIndex].ItemsSource = imagelist;
                }
            }
        }
        private void lsv_DoubleClick(object sender, EventArgs e)
        {
            ListView lsv = (ListView)(sender);
            if (lsv.SelectedItems.Count > 0)
            {
               //转到打印界面
            }
            else
            {
                MessageBox.Show("请先选择票据", "软件提示");
            }
        }
        private void BilltemplateViewPanel_Loaded(object sender, RoutedEventArgs e)
        {
            BillSetName = "测试账套";
            CompanyName = "测试公司";
            loadItem(BillSetName, CompanyName);
            loadImage(0, BillSetName, CompanyName);//只加载第一页

        }

        private void TabMenu_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            loadImage(TabMenu.SelectedIndex, BillSetName, CompanyName);
        }
    }
}
