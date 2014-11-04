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
using FirstFloor.ModernUI.Windows.Controls;
using BillManageWPF.Page;
using Controllers.Models;
using System.IO;

namespace BillManageWPF
{
    /// <summary>
    /// ModerUIMain.xaml 的交互逻辑
    /// </summary>
    public partial class ModerUIMain : Window
    {
        public ModerUIMain()
        {
            InitializeComponent();
        }
        #region 退出按钮事件
        /// <summary>
        /// 退出事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown(-1);
        }

        /// <summary>
        ///   关闭按钮获得鼠标焦点时，修改透明度
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_MouseEnter(object sender, MouseEventArgs e)
        {
            btnEXIT.Opacity = 0.8;
        }
        private void btnEXIT_MouseLeave(object sender, MouseEventArgs e)
        {
            btnEXIT.Opacity = 1.0;
        }
        #endregion

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                tbUserName.Text = SoftUser.UserName;
                String photoPath = AppDomain.CurrentDomain.BaseDirectory + @"\Configs\" + SoftUser.UserCode + @"\user.jpg"; //用户头像文件
                if (File.Exists(photoPath))
                {
                    imUserPhoto.Source = new BitmapImage(new Uri(photoPath, UriKind.Absolute));
                }
                ModernFrame mf = new ModernFrame();
                //mf.Content = new FunctionListPage();
                mf.Source = new Uri(@"Content\Main\MainMeumList.xaml", UriKind.Relative);
                grid.Children.Add(mf);
            }
            catch (Exception ex)
            {
            }
        }
        private void imUserPhoto_MouseEnter(object sender, MouseEventArgs e)
        {
            imUserPhoto.Opacity = 0.5;
            imUserPhoto.Cursor = Cursors.Hand;
        }

        private void imUserPhoto_MouseDown(object sender, MouseButtonEventArgs e)
        {
            UserWindow yw = new UserWindow(this);
            yw.Show();
        }

        private void imUserPhoto_MouseLeave(object sender, MouseEventArgs e)
        {
            imUserPhoto.Opacity = 1.0;
            imUserPhoto.Cursor = Cursors.Arrow;
        }


    }
}
