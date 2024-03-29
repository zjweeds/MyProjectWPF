﻿//----------------------------------------------------------------//
//功能：登陆界面主窗体                                             //
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
using System.Windows.Threading;
using Controllers.Business;

namespace BillManageWPF
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
         DispatcherTimer _timer = new DispatcherTimer();
         bool flage = true;

        /// <summary>
        /// 时钟类执行的方法，用于动态改变标题位置
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
         public void _timer_Tick(object sender, EventArgs e)
         {
             if (flage)
             {
                 if (title.Margin.Left > 70)
                 {
                     title.Margin = new Thickness(title.Margin.Left - 3, title.Margin.Top, title.Margin.Right + 3, title.Margin.Bottom);
                     title1.Margin = new Thickness(title1.Margin.Left - 3, title1.Margin.Top, title1.Margin.Right + 3, title1.Margin.Bottom);
                     title2.Margin = new Thickness(title2.Margin.Left - 3, title2.Margin.Top, title2.Margin.Right + 3, title2.Margin.Bottom);
                 }
                 else
                 {
                     _timer.Stop();
                     if (new ConfigService().isConfigFilesExist())
                     {
                         Login.Opacity = 1.0;
                     }
                     else
                     {
                         if (MessageBox.Show("您是第一次运行程序！或者是系统配置文件丢失\n转到配置页面么？", "软件提示", MessageBoxButton.YesNo, MessageBoxImage.Information) == MessageBoxResult.Yes)
                         {
                             ConfigWindow cfw = new ConfigWindow();
                             cfw.Top = this.Top;
                             cfw.Left = this.Left;
                             cfw.Show();
                         }
                         else
                         {
                             this.Close();
                         }
                     }
                    

                 }
             }
             else
             {
                 if (title.Margin.Left < 210)
                 {
                     title.Margin = new Thickness(title.Margin.Left + 3, title.Margin.Top, title.Margin.Right - 3, title.Margin.Bottom);
                     title1.Margin = new Thickness(title1.Margin.Left + 3, title1.Margin.Top, title1.Margin.Right - 3, title1.Margin.Bottom);
                     title2.Margin = new Thickness(title2.Margin.Left + 3, title2.Margin.Top, title2.Margin.Right - 3, title2.Margin.Bottom);
                 }
                 else
                 {
                     _timer.Stop();
                     PBar.Opacity = 1.0;
                 }
             }

         }

        /// <summary>
        /// 回调函数，显示进度条
        /// </summary>
        public void DoCallBack()
        {
            Login.Opacity = 0;
            flage = false;
            _timer.Start();            
        }

        public void DoShowLogin()
        {
            //分一个线程处理淡入显示
            while(Login.Opacity <= 1.0)
            {
                System.Threading.Thread.Sleep(50);
                Login.Opacity += 0.05;
            }
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            
            Login.mw = this;
            System.Threading.Thread.Sleep(5000);
            _timer.Interval = TimeSpan.FromMilliseconds(20);
            _timer.Tick += new EventHandler(_timer_Tick);
            _timer.Start();          
        }


        /// <summary>
        /// 鼠标移动改变窗体位置
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Window_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                this.DragMove();    
            }                     
        }


        /// <summary>
        /// 最小化窗体
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }

        /// <summary>
        /// 退出
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
    }
}
