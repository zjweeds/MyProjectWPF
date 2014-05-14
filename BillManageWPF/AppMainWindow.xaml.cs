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
using System.Windows.Shapes;
using WPF.DazzleUI2.Controls;

namespace BillManageWPF
{
    /// <summary>
    /// AppMainWindowxaml.xaml 的交互逻辑
    /// </summary>
    public partial class AppMainWindow : DazzleWindow
    {
        public AppMainWindow()
        {
            InitializeComponent();
        }
        public AppMainWindow( int  index)
        {
            InitializeComponent();
            this.tabMenu.SelectedIndex = index;
        }
        private void DazzleButton_Click(object sender, RoutedEventArgs e)
        {
            MertoUIWindow muw = new MertoUIWindow();
            muw.Show();
            this.Close();
        }

        private void DazzleButton_Click_1(object sender, RoutedEventArgs e)
        {
            this.WindowState = System.Windows.WindowState.Maximized;
        }

        private void DazzleButton_Click_2(object sender, RoutedEventArgs e)
        {
            this.WindowState = System.Windows.WindowState.Minimized;
        }

        private void btnGotoStart_MouseDown(object sender, MouseButtonEventArgs e)
        {
            MertoUIWindow muw = new MertoUIWindow();
            muw.Show();
            this.Close();
        }

    }
}
