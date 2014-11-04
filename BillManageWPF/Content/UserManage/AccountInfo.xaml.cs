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
using Controllers.Models;
using Controllers.Business;

namespace BillManageWPF.Content.UserManage
{
    /// <summary>
    /// Interaction logic for AccountInfo.xaml
    /// </summary>
    public partial class AccountInfo : UserControl
    {
        public AccountInfo()
        {
            InitializeComponent();
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                lbUserCode.Text = SoftUser.UserCode;
                lbUserName.Text = SoftUser.UserName;
                cbbBillSet.ItemsSource = BillSetManager
                  .GetDataTableByCompanyName(SoftUser.UserCompany).DefaultView;
                cbbBillSet.DisplayMemberPath = "BSIName";
                cbbBillSet.SelectedValuePath = "BSID";
                cbbBillSet.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
            }
        }
        private void Button_MouseEnter(object sender, MouseEventArgs e)
        {
            try
            {
                Button btn = sender as Button;
                btn.Background = new SolidColorBrush(Colors.Purple);
                btn.Foreground = new SolidColorBrush(Colors.WhiteSmoke);
                btn.Width = btn.Width + 5;
                btn.Height = btn.Height + 5;
                btn.FontSize = btn.FontSize + 2;
            }
            catch (Exception ex)
            {
            }
        }

        private void Button_MouseLeave(object sender, MouseEventArgs e)
        {
            try
            {
                Button btn = sender as Button;
                btn.Background.Opacity = 0;
                btn.Foreground = new SolidColorBrush(Colors.Purple);
                btn.Width = btn.Width - 5;
                btn.Height = btn.Height - 5;
                btn.FontSize = btn.FontSize - 2;
            }
            catch (Exception ex)
            {
            }
        }

        private void chbDoPass_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (chbDoPass.IsChecked == true)
                {
                    ChangePwd.Visibility = Visibility.Visible;
                }
                else
                {
                    ChangePwd.Visibility = Visibility.Hidden;
                }
            }
            catch (Exception ex)
            {
            }
        }

        private void btnSubmet_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (cbbBillSet.Text != String.Empty)
                {
                    String loginPath = AppDomain.CurrentDomain.BaseDirectory
                              + @"Configs\" + SoftUser.UserCode;
                    ConfigeManage.SaveLoginToXml(loginPath);//保存配置信息
                }
                if (chbDoPass.IsChecked == true)
                {
                    if (txtNewPwd.Password == txtRepeatPwd.Password)
                    {
                        //用户更改密码
                        if (txtOldPwd.Password.ToString() == SoftUser.PassWorld)
                        {
                            if (UserInfoManager.UpdateUserPWDByUIEINO(SoftUser.UserCode, txtNewPwd.Password.ToString()))
                            {
                                MessageBox.Show("修改成功！", "软件提示");
                            }
                        }
                        else
                        {
                            MessageBox.Show("您的原密码输入错误，请重试！", "软件提示");
                            txtNewPwd.Password = String.Empty;
                            txtOldPwd.Password = String.Empty;
                            txtRepeatPwd.Password = String.Empty;
                        }
                    }
                    else
                    {
                        MessageBox.Show("您两次输入的密码不一致，请重试！", "软件提示");
                        txtNewPwd.Password = String.Empty;
                        txtOldPwd.Password = String.Empty;
                        txtRepeatPwd.Password = String.Empty;
                    }
                }
            }
            catch (Exception ex)
            {
            }
        }

    }
}
