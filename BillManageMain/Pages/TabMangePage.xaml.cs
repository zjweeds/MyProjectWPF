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
using FirstFloor.ModernUI.Presentation;
using FirstFloor;
using FirstFloor.ModernUI;
using FirstFloor.ModernUI.Windows.Controls;
using Controllers.Business;
using Controllers.Moders;
using BillManageMain.UserControls;

namespace BillManageMain.Pages
{
    /// <summary>
    /// Interaction logic for TabMangePage.xaml
    /// </summary>
    public partial class TabMangePage : UserControl
    {
        TabManageService TMS = new TabManageService();
        UserModer UM = new UserModer();
        public TabMangePage()
        {
            InitializeComponent();
        }
       
        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            MyLink item = link1 as MyLink;
            mtab.Links.Clear();
            mtab.Links.Add(item);
            List<string> strlists=new List<string>();
            strlists = TMS.GetTabName("测试账套", "测试公司");
            if (strlists != null)
            {
                foreach (string str in strlists)
                {
                    MyLink Linkitem = new MyLink();
                   // Linkitem.UserControlBtnClicked += new MyLink.BtnClickHandle(Linkitem.LinkBtnClick(str));
                    Linkitem.DisplayName = str;
                    mtab.Links.Add(Linkitem);
                }
            }
    }
    }
}
