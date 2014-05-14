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

namespace BillManageWPF.Page
{
    /// <summary>
    /// SystemSettingView.xaml 的交互逻辑
    /// </summary>
    public partial class SystemSettingView : UserControl
    {
        public SystemSettingView()
        {
            InitializeComponent();
        }

        private void SetGridVisiable(Grid g1, Grid g2)
        {
            g1.Visibility = Visibility.Visible;
            g2.Visibility = Visibility.Hidden;
        }

        private void Grid_MouseEnter(object sender, MouseEventArgs e)
        {
            SetGridVisiable(PrintSetInfo, PrintSetIco);
        }

        private void PrintSetInfo_MouseLeave(object sender, MouseEventArgs e)
        {
            SetGridVisiable(PrintSetIco, PrintSetInfo);
        }

        private void PrintSetInfo_MouseDown(object sender, MouseButtonEventArgs e)
        {

            e.Handled = true;
            MessageBox.Show("打印");
        }

        private void UsersIco_MouseEnter(object sender, MouseEventArgs e)
        {
            SetGridVisiable(Usersinfo, UsersIco);
        }
        private void Usersinfo_MouseLeave(object sender, MouseEventArgs e)
        {
            SetGridVisiable(UsersIco, Usersinfo);

        }
        private void Usersinfo_MouseDown(object sender, MouseButtonEventArgs e)
        {
            e.Handled = true;
            MessageBox.Show("用户管理");
        }

        private void BillSetADDico_MouseEnter(object sender, MouseEventArgs e)
        {
            SetGridVisiable(BillSetADDinfo, BillSetADDico);
        }

        private void BillSetADDinfo_MouseLeave(object sender, MouseEventArgs e)
        {
            SetGridVisiable(BillSetADDico,BillSetADDinfo);
        }

        private void BillSetADDinfo_MouseDown(object sender, MouseButtonEventArgs e)
        {
            e.Handled = true;
            MessageBox.Show("新增账套");
        }

    }
}
