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
using System.Data;

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
        EmployeeInfo ei = new EmployeeInfo();
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

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            lbUserCode.Text = SoftUser.UserCode;
            ei = EmployeeInfoManager.SelectEmployeeInfoByEINO(SoftUser.UserCode);
            txtName.Text = ei.EIName;
            if (ei.EISex)
            {
                raMan.IsChecked = true;
            }
            else
            {
                raWeman.IsChecked = true;
            }
            cbbPosition.Items.Add(ei.EIPosition);
            cbbPosition.SelectedIndex = 0;
            cbbBuMen.Items.Add(ei.EIDepartment);
            cbbBuMen.SelectedIndex = 0;
            dtpBrithDate.Text = ei.EIBirthday.ToShortDateString();
            dtpEnTry.Text = ei.EIEntryDate.ToShortDateString();
            lbCompany.Text = SoftUser.UserCompany;
            txtReMark.Text = ei.EIRemark;
        }

        private void btnSubmit_Click(object sender, RoutedEventArgs e)
        {
            ei.EIName = txtName.Text;
            ei.EISex = raMan.IsChecked.Value;
            ei.EIPosition = cbbPosition.SelectedItem.ToString();
            ei.EIDepartment = cbbBuMen.SelectedItem.ToString();
            ei.EIBirthday = dtpBrithDate.DisplayDateStart.Value;
            ei.EIEntryDate =  dtpEnTry.DisplayDateStart.Value;
            ei.EIRemark = txtReMark.Text;
            if (EmployeeInfoManager.UpdateEmployeeInfo(ei))
            {
                MessageBox.Show("修改成功！","软件提示");
            }
            else
            {
                MessageBox.Show("修改成功！", "软件提示");
            }
        }


    }
}
