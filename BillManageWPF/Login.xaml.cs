﻿using System;
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
using System.Windows.Media.Animation;
using System.Threading;
using BillManageWPF.softConfig;
using Controllers.Business;
using System.Windows.Threading;
using Controllers.Models;
using BillManageWPF.MyCode;
using System.Data;
using Controllers.Common;
using System.IO;

namespace BillManageWPF
{
    /// <summary>
    /// Login.xaml 的交互逻辑
    /// </summary>
    public partial class Login : Window
    {
        public Login()
        {
            InitializeComponent();
        }
        #region  页面变量
        private DispatcherTimer _timer;//计时器
        private static String BSName = String.Empty; 
        private Storyboard result = new Storyboard(); //动画故事面板
        private int iCount = 0;//保存动画执行成功次数
        private delegate bool LoadImageMethod(bool Diameter); //定义子进程执行的事件的委托
        private static LoadImageMethod calcMethod;
        private Thread beginInvokeThread; //子线程
        private int waitSecond = 0; //主线程等待秒数
        String userPhotoPath = AppDomain.CurrentDomain.BaseDirectory
    + @"Configs\" + SoftUser.UserCode + @"\user.jpg"; //用户头像路径
        #endregion

        #region 自定义方法
        /// <summary>
        /// 控件移动动画方法
        /// </summary>
        /// <param name="fe">控件名</param>
        /// <param name="left">移动的left距离</param>
        /// <param name="top">移动的top距离</param>
        /// <param name="right">移动的right距离</param>
        /// <param name="bottom">移动的bottom距离</param>
        private void DoMove(FrameworkElement fe, double left, double top,double right, double bottom)
        {
            ThicknessAnimation animation = new ThicknessAnimation();
            animation.From = fe.Margin;
            animation.To = new Thickness(fe.Margin.Left - left, fe.Margin.Top - top,
                fe.Margin.Right - right, fe.Margin.Bottom - bottom);
            // lbTitle.Margin.Top, lbTitle.Margin.Right, lbTitle.Margin.Bottom);
            //margin顺序        2.↑  
            //                       1.←   3. →
            //                             4.↓
            animation.Duration = new Duration(TimeSpan.FromSeconds(1.5));
            Storyboard.SetTarget(animation, fe);
            Storyboard.SetTargetProperty(animation, new PropertyPath("Margin"));
            animation.Completed += new EventHandler(sb_Completed);
            result.Children.Add(animation);
            result.Begin();
        }
        
        /// <summary>
        /// 动画完成后事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void sb_Completed(object sender, EventArgs e)
        {
            iCount++; //循环计数
            if (iCount == 1)
            {
                //第一次动画结束时
                loginPanel.Visibility = Visibility.Visible;//显示登陆框
                imUserphoto.Visibility = Visibility.Visible;
            }
            else 
            {
                iCount = 2;
            }
        }

        /// <summary>
        /// 开始动画
        /// </summary>
        public void LoadingAnime()
        {
            DoMove(ju, 180, 0, 0, 0);
            DoMove(tong, 300, -90, 0, 0);
            DoMove(piao, 60, 90, 0, 0);
        }

        /// <summary>
        /// 线程开始方法
        /// </summary>
        private void StartMethod()
        {
            calcMethod = new LoadImageMethod(LoadImage);
            calcMethod.BeginInvoke(true, new AsyncCallback(TaskFinished), null);
        }
        ///<summary>
        ///线程调用的函数
        ///<summary>
        public static bool LoadImage(bool childThred)
        {
            if (BSName != String.Empty)
            {
                ConfigeManage.LoadImage(BillTemplateManage.GetTemplatBagroundByBSName(BSName), BSName);
                return false;
            }
            else
            {
                MessageBox.Show(BSName);
                return false;
            }
        }

        public void LoadCompanyName()
        {
            cbbCompany.ItemsSource= CompanyInfoManager.GetAllCompanyName().DefaultView;
            cbbCompany.DisplayMemberPath = "CIName";
            cbbCompany.SelectedValuePath = "CIID"; 
        }
        ///<summary>
        ///线程完成之后回调的函数
        ///<summary>
        public static void TaskFinished(IAsyncResult childThred)
        {
            calcMethod.EndInvoke(childThred);
        }

        private void doThreadLoading()
        {
            beginInvokeThread = new Thread(StartMethod);//new ThreadStart(StartMethod));
            beginInvokeThread.Start();
            loginPanel.Visibility = Visibility.Hidden;
            DoMove(ju, -300, 0, 0, 0);
            DoMove(tong, -400, 90, 0, 0);
            DoMove(piao, -200, -90, 0, 0);
            DoMove(imUserphoto, 150, 0, 0, 0);
            PBar.Visibility = Visibility.Visible;
            _timer = new DispatcherTimer();
            _timer.Interval = TimeSpan.FromSeconds(3);
            _timer.Tick += _timer1_Tick;
            _timer.Start();
        }

        private void GetUserPhotoFromDisk(String userCode)
        {
            String photoPath = AppDomain.CurrentDomain.BaseDirectory
                   + @"Configs\" + userCode + @"\user.jpg"; //用户头像路径
            String photoPathTemp = AppDomain.CurrentDomain.BaseDirectory
                + @"Configs\" + userCode + @"\userNew.jpg"; //用户新头像路径
            if (File.Exists(photoPathTemp))
            {
                try
                //存在新头像，就覆盖老头像
                {
                    File.Copy(photoPathTemp, photoPath, true);
                    File.Delete(photoPathTemp);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            }
            if (File.Exists(photoPath))
            {
                imUserphoto.Source = new BitmapImage(new Uri(photoPath, UriKind.Absolute));
            }
        }

        /// <summary>
        /// 保存登录信息
        /// </summary>
        public void SaveLoginInfo()
        {
            String loginPath = AppDomain.CurrentDomain.BaseDirectory
                        + @"Configs\" + SoftUser.UserCode;
            ConfigeManage.SaveLoginToXml(loginPath);
               
        }
        #endregion
        #region 窗体事件
        /// <summary>
        /// 窗体载入事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            iCount = 0;
            if (ConfigeManage.isConfigFilesExist())
            {
                LoadingAnime();
                LoadCompanyName();
                cbbCompany.SelectedIndex = 0;
                txtPassWord.Password = "0001";
            }
            else
            {
                if (MessageBox.Show("您是第一次运行程序！或者是系统配置文件丢失\n转到配置页面么？", "软件提示", MessageBoxButton.YesNo, MessageBoxImage.Information) == MessageBoxResult.Yes)
                {
                    WindowSoftConfig wsf = new WindowSoftConfig(this);
                    wsf.Top = this.Top;
                    wsf.Left = this.Left;
                    wsf.Show();
                    this.WindowState = System.Windows.WindowState.Minimized;
                }
                else
                {
                    this.Close();
                }
            }
        }

    
        /// <summary>
        /// 登录按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
           DataTable dtUser = UserInfoManager.SelectUserInfoByPassworld
                (txtName.Text, Convert.ToInt32(cbbCompany.SelectedValue));
            if (dtUser != null && dtUser.Rows.Count != 0)
            {
                if (dtUser.Rows[0]["UIPassword"].ToString() == txtPassWord.Password.ToString())
                {
                    BSName = cbbBillSet.Text.ToString();
                    doThreadLoading();//分线程处理加载图片工作，主线程登录
                    SoftUser.UserCode = dtUser.Rows[0]["UIEINo"].ToString();
                    SoftUser.UserName = dtUser.Rows[0]["EIName"].ToString();
                    SoftUser.UserCompany = cbbCompany.Text;
                    SoftUser.PassWorld = txtPassWord.Password.ToString();
                    ImageHelper imher= new ImageHelper();
                    GetUserPhotoFromDisk(txtName.Text);
                    if (!File.Exists(userPhotoPath))
                    {//头像文件不存在
                        try
                        {
                            if (dtUser.Rows[0]["EIPhoto"] != null && (dtUser.Rows[0]["EIPhoto"] as byte[]).Length != 0)
                            {
                                imher.SaveImage(imher.GetImageByByte(dtUser.Rows[0]["EIPhoto"] as byte[]), userPhotoPath);
                            }
                            else
                            {
                                if (!Directory.Exists(AppDomain.CurrentDomain.BaseDirectory
                            + @"Configs\" + SoftUser.UserCode))//若文件夹不存在则新建文件夹  
                                {
                                    Directory.CreateDirectory(AppDomain.CurrentDomain.BaseDirectory
                            + @"Configs\" + SoftUser.UserCode); //新建文件夹 
                                }
                                File.Copy(AppDomain.CurrentDomain.BaseDirectory + @"\Resource\user.jpg",
                                         userPhotoPath, true);
                            }
                        }
                        catch
                        {
                            File.Copy(AppDomain.CurrentDomain.BaseDirectory + @"\Resource\user.jpg",
                                        userPhotoPath, true);
                        }
                    }
                    SoftUser.Op_Bill = cbbBillSet.Text;
                    if (chbSavePassword.IsChecked == true)
                    {
                        SaveLoginInfo();
                    }
                }
                else
                {
                    MessageBox.Show("密码错误！请确认后再次输入！");
                    return;
                }
            }
            else
            {
                //用户不存在
                MessageBox.Show(String.Format("所选公司不存在工号:{0}的员工，请确认输入！",txtName.Text),"软件提示");
                txtName.Text=String.Empty;
                txtPassWord.Password=string.Empty;
                return;
            }
        }

        /// <summary>
        /// 计时器事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void _timer1_Tick(object sender, EventArgs e)
        {
            waitSecond++;
            if (waitSecond>2)
            {
                waitSecond = 0;

                ModerUIMain mum = new ModerUIMain();
                mum.Show();
                _timer.Stop();
                this.Close();
            }
        }

        #region 关闭按钮
        private void Button_MouseEnter(object sender, MouseEventArgs e)
        {
            btnEXIT.Opacity = 0.8;
        }
        private void btnEXIT_MouseLeave(object sender, MouseEventArgs e)
        {
            btnEXIT.Opacity = 1.0;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown(-1);
        }
        #endregion 

        /// <summary>
        /// 选择的公司更改，对应加载该公司下的账套
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cbbCompany_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
           cbbBillSet.ItemsSource=BillSetManager
               .GetDataTableByCompanyID(Convert.ToInt32(cbbCompany.SelectedValue)).DefaultView;
            cbbBillSet.DisplayMemberPath = "BSIName";
            cbbBillSet.SelectedValuePath = "BSID";
            cbbBillSet.SelectedIndex = 0;
        }

        private void txtName_LostFocus(object sender, RoutedEventArgs e)
        {
            GetUserPhotoFromDisk(txtName.Text);
        }

        #endregion

        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                DragMove();
            }
        }

      
    }
}
