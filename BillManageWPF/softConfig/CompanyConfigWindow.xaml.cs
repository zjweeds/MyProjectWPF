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
using Controllers.Models;
using Controllers.Business;

namespace BillManageWPF.softConfig
{
    /// <summary>
    /// CompanyConfigWindow.xaml 的交互逻辑
    /// </summary>
    public partial class CompanyConfigWindow : Window
    {
        #region 页面构造函数
        public CompanyConfigWindow()
        {
            InitializeComponent();
        }
        public CompanyConfigWindow(String IP,String user,String pwd,String dbname)
        {
            InitializeComponent();
            this.serverIP = IP;
            this.DBUser = user;
            this.DBPWD = pwd;
            this.DBName = dbname;
        }
        #endregion

        #region 页面变量
        private String serverIP = String.Empty; //数据库服务器IP
        private String DBUser = String.Empty; //数据库用户名
        private String DBPWD = String.Empty;//数据库密码
        private String DBName = String.Empty; //数据库名
        #endregion

        #region 页面事件
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                SystemDBManage.CreatAdmin(serverIP, DBUser, DBPWD, DBName, txtAdmin.Text.Trim(), pass.Password);
                SystemDBManage.CreateCompanyAndBillSet(serverIP, DBUser, DBPWD, DBName, txtCompany.Text, txtBillSet.Text);
                this.Close();
            }
            catch (Exception ex)
            {
            }
        }
        #endregion

    }
}
