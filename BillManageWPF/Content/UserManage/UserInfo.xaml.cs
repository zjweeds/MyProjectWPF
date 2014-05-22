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

namespace BillManageWPF.Content.UserManage.SetInfo
{
    /// <summary>
    /// Interaction logic for UserInfo.xaml
    /// </summary>
    public partial class UserInfo : UserControl
    {
        public UserInfo()
        {
            InitializeComponent();
        }
        private void Button_MouseEnter(object sender, MouseEventArgs e)
        {
            Button btn = sender as Button;
            btn.Background = new SolidColorBrush(Colors.Purple);
            btn.Foreground = new SolidColorBrush(Colors.WhiteSmoke);
            btn.Width = btn.Width + 5;
            btn.Height = btn.Height + 5;
            btn.FontSize = btn.FontSize + 2;
        }

        private void Button_MouseLeave(object sender, MouseEventArgs e)
        {
            Button btn = sender as Button;
            btn.Background.Opacity = 0;
            btn.Foreground = new SolidColorBrush(Colors.Purple);
            btn.Width = btn.Width - 5;
            btn.Height = btn.Height - 5;
            btn.FontSize = btn.FontSize - 2;
        }
    }
}
