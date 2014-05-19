﻿//----------------------------------------------------------------//
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
using Controllers.Models;
using Controllers.Common;
using Controllers.DataAccess;
using Controllers.Business;
using System.Windows.Threading;
using System.Threading;

namespace BillManageWPF
{
    /// <summary>
    /// UCLogin.xaml 的交互逻辑
    /// </summary>
    public partial class UCLogin : UserControl
    {
        public LoginWindow lw { get; set; }
        public CompanyManager ComSer = null;
        DispatcherTimer _timer = new DispatcherTimer();
        int Count = 0;
        public UCLogin()
        {
            this.ComSer = new CompanyManager();
            InitializeComponent();           
        }
        public void LoginAsyc()
        {
            Thread th = new Thread(new ThreadStart(() =>
            {
                System.Threading.Thread.Sleep(3000);
               
            })
            );
            th.Start();
        }



        private void Button_Click(object sender, RoutedEventArgs e)
        {
           // LoginAsyc();
            _timer.Start();  
             
                     
        }

        public void LoadCompany()
        {
            DataSet dsItem = ComSer.GetAllCompanyNames();
            if (dsItem != null)
            {
                //new CommonClass().SetComboBoxItemByDataTable(dsItem.Tables[0], cbbCompany, "CIName", "CIName");
                for (int i = 0; i < dsItem.Tables[0].Rows.Count; i++)
                {
                    cbbCompany.Items.Add(dsItem.Tables[0].Rows[i][0].ToString());
                }
            }
        }
        public void timer_tick(object sender, EventArgs e)
        {
            Count++;
            if (Count < 6)
            {
                lw.DoCallBack();
            }
            else
            {
                MertoUIWindow amw = new MertoUIWindow();
                amw.WindowState = WindowState.Maximized;
                amw.Show();
                _timer.Stop();
                lw.Close(); 
            }
        }
        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            LoadCompany();
            _timer.Interval=TimeSpan.FromMilliseconds(1000);
            _timer.Tick += new EventHandler(timer_tick);
                      
        }
    }
}
