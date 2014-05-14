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

namespace BillManageWPF
{
    /// <summary>
    /// MertoUIWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MertoUIWindow : Window
    {
        #region  构造器
        public MertoUIWindow()
        {
            InitializeComponent();
        }
        #endregion

        #region 自定义方法
        /// <summary>
        /// 设置Grid可见性
        /// </summary>
        /// <param name="g1"></param>
        /// <param name="g2"></param>
        private void SetGridVisiable(Grid g1, Grid g2)
        {
            g1.Visibility = Visibility.Visible;
            g2.Visibility = Visibility.Hidden;
        }

        private void NavToWindows(int index)
        {
            AppMainWindow amw = new AppMainWindow(index);
            amw.Show();
            this.Close();
        }
        #endregion

        #region 事件
            #region 退出按钮事件
        /// <summary>
        /// 退出事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
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

            #endregion

            #region 按磁贴跳转到对应窗体
        private void btnTemplate_MouseDown(object sender, MouseButtonEventArgs e)
        {
            e.Handled = true;
            NavToWindows(0);
            //转到模板中心
        }
        private void btnDatasource_MouseDown(object sender, MouseButtonEventArgs e)
        {
            e.Handled = true;
            NavToWindows(1);
            //转到资料中心
        }
        private void btnBill_MouseDown(object sender, MouseButtonEventArgs e)
        {
            e.Handled = true;
            //转到票据中心
            NavToWindows(2);
        }

        private void btnUsers_MouseDown(object sender, MouseButtonEventArgs e)
        {
            e.Handled = true;
            //跳转到用户中心
            NavToWindows(3);
        }
        private void btnSystemsSet_MouseDown(object sender, MouseButtonEventArgs e)
        {
            e.Handled = true;
            //转到设置中心
            NavToWindows(4);
        }
        private void btnHelper_MouseDown(object sender, MouseButtonEventArgs e)
        {
            e.Handled = true;
            //转到帮助中心
            NavToWindows(5);
        }
        #endregion

            #region 磁贴Grid的显示
            private void btnTemplateIcon_MouseEnter(object sender, MouseEventArgs e)
            {
                SetGridVisiable(btnTemplate, btnTemplateIcon);
            }

            private void btnTemplate_MouseLeave(object sender, MouseEventArgs e)
            {
                SetGridVisiable(btnTemplateIcon, btnTemplate);
            }

            private void btnDatasourceIcon_MouseEnter(object sender, MouseEventArgs e)
            {
                SetGridVisiable(btnDatasource, btnDatasourceIcon);
            }

            private void btnDatasource_MouseLeave(object sender, MouseEventArgs e)
            {
                SetGridVisiable(btnDatasourceIcon,btnDatasource);
            }

            private void btnBillIcon_MouseEnter(object sender, MouseEventArgs e)
            {
                SetGridVisiable(btnBill, btnBillIcon);
            }

            private void btnBill_MouseLeave(object sender, MouseEventArgs e)
            {
                SetGridVisiable(btnBillIcon,btnBill);
            }

            private void btnUsersIcon_MouseEnter(object sender, MouseEventArgs e)
            {
                SetGridVisiable(btnUsers, btnUsersIcon);
            }

            private void btnUsers_MouseLeave(object sender, MouseEventArgs e)
            {
                SetGridVisiable(btnUsersIcon,btnUsers);
            }

            private void btnSystemsSetIcon_MouseEnter(object sender, MouseEventArgs e)
            {
                SetGridVisiable(btnSystemsSet, btnSystemsSetIcon);
            }

            private void btnSystemsSet_MouseLeave(object sender, MouseEventArgs e)
            {
                SetGridVisiable(btnSystemsSetIcon, btnSystemsSet);
            }

            private void btnHelperIcon_MouseEnter(object sender, MouseEventArgs e)
            {
                SetGridVisiable(btnHelper, btnHelperIcon);
            }

            private void btnHelper_MouseLeave(object sender, MouseEventArgs e)
            {
                SetGridVisiable(btnHelperIcon, btnHelper);
            }

            #endregion
        #endregion

    }
}
