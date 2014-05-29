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
using Controllers.Models;
using Controllers.Common;
using System.IO;
using FirstFloor.ModernUI.Windows.Controls;
using BillManageWPF.Page;

namespace BillManageWPF.Content.UserManage.SetInfo
{
    /// <summary>
    /// UserPhoto.xaml交互逻辑
    /// </summary>
    public partial class UserPhoto : UserControl
    {
        public UserPhoto()
        {
            InitializeComponent();
        }
        private String path = String.Empty;//新头像源路径
        private String photoPath = AppDomain.CurrentDomain.BaseDirectory + @"Configs\" + SoftUser.UserCode 
            + @"\user.jpg"; //用户头像缓存路径
        private BitmapImage bitmap = null;//保存头像对象
        private System.Windows.Forms.OpenFileDialog dlgPicture 
            = new System.Windows.Forms.OpenFileDialog(); //文件选择对话框

        private void UIimage_MouseEnter(object sender, MouseEventArgs e)
        {
            imageborder.BorderBrush = new SolidColorBrush(Colors.AliceBlue);
            UIimage.Cursor = Cursors.Hand;
        }

        private void UIimage_MouseLeave(object sender, MouseEventArgs e)
        {
            imageborder.BorderBrush = new SolidColorBrush(Colors.DarkCyan);
            UIimage.Cursor = Cursors.Arrow;
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

        private void UIimage_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (dlgPicture.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                path = dlgPicture.FileName;
                Uri uri = new Uri(dlgPicture.FileName, UriKind.RelativeOrAbsolute);
                bitmap = new BitmapImage(uri);
                UIimageRE.Source = bitmap;
            }
        }

        /// <summary>
        /// 提交修改
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSubmit_Click(object sender, RoutedEventArgs e)
        {
            String newphoto = AppDomain.CurrentDomain.BaseDirectory + @"Configs\" + SoftUser.UserCode 
            + @"\userNew.jpg"; //用户头像缓存路径
            byte[] buff=new ImageHelper().GetBytesByImagepath(path);
            if (EmployeeInfoManager.updateUerPhotoByEINO(SoftUser.UserCode, buff))
            {
                UIimage.Source = bitmap;
                File.Copy(path,newphoto, true); //覆盖原缓存
            }
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
             UIimage.Source = new BitmapImage(new Uri(photoPath, UriKind.Absolute));
        }


    }
}
