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
using System.Windows.Threading;


namespace BillManageWPF.Content.Others
{
    /// <summary>
    /// WaitWindow.xaml 的交互逻辑
    /// </summary>
    public partial class WaitWindow : Window
    {
        public WaitWindow()
        {
            InitializeComponent();
        }
        private int icount = 0;
         private DispatcherTimer _timer = new DispatcherTimer(); //计时器。窗体右移消失后 控制多久关闭     
         public void _timer_Tick(object sender, EventArgs e)
         {
             icount++;
             if (icount > 3)
             {
                 _timer.Stop();//停止计时器
                 this.Close(); //关闭窗体
             }
         }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            _timer.Interval = TimeSpan.FromSeconds(1);
            _timer.Tick += new EventHandler(_timer_Tick);
            _timer.Start();
        }
    }
}
