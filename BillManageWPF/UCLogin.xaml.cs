//----------------------------------------------------------------//
//功能：用户登录自定义控件                                         //
//作者：赵建                                                      //
//版本：v1.3                                                      //
//创建时间：2013/11/7   15:34:00                                  //
//最后一次修改时间：2014/3/23   17:22:00                          //
//---------------------------------------------------------------//
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
using System.Data;
using Controllers.Moders.TableModers;
using Controllers.Business;
using BillManageMain;

namespace BillManageWPF
{
    /// <summary>
    /// UCLogin.xaml 的交互逻辑
    /// </summary>
    public partial class UCLogin : UserControl
    {
        public LoginWindow lw { get; set; }
        public CompanyService ComSer = null;
        public UCLogin()
        {
            this.ComSer = new CompanyService();
            InitializeComponent();           
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            lw.DoCallBack();
            MainWindow wmv = new MainWindow();
            wmv.Show();
            lw.Close();
            //BillManageMain.MainWindow bmw = new BillManageMain.MainWindow();
           
        }

        public void LoadCompany()
        {
            DataSet dsItem = ComSer.GetAllCompanyNames();
            if (dsItem != null)
            {
                for (int i = 0; i < dsItem.Tables[0].Rows.Count; i++)
                {
                    cbbCompany.Items.Add(dsItem.Tables[0].Rows[i][0].ToString());
                }
            }
        }
        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            LoadCompany();
        }
    }
}
