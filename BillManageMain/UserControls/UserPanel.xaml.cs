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

namespace BillManageMain.UserControls
{
    /// <summary>
    /// UserPanel.xaml 的交互逻辑
    /// </summary>
    public partial class UserPanel : UserControl
    {
        string Name = string.Empty;
        public UserPanel()
        {
            InitializeComponent();
        }
        public UserPanel(string Name)
        {
            InitializeComponent();

            this.Name = Name;
        }

        public void LoadImage(int PageIndex, ListView lsvItem)//, ImageList imlist)
        {
            //加载图片
            lsvItem.Items.Clear();
           
        }
        private void UListView_Loaded(object sender, RoutedEventArgs e)
        {

        }
    }
}
