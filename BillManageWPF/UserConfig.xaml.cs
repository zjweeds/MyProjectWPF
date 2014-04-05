//----------------------------------------------------------------//
//功能：软件配置界面体                                            //
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
using Controllers.Moders;
using Controllers.Moders.TableModers;
using Controllers.Business;

namespace BillManageWPF
{
    /// <summary>
    /// UserConfig.xaml 的交互逻辑
    /// </summary>
    public partial class UserConfig : UserControl
    {
        public ConfigWindow cfw = null;
        public UserConfig()
        {
            InitializeComponent();           
        }
   
       /// <summary>
       /// 保存配置文件
       /// </summary>
       /// <param name="sender"></param>
       /// <param name="e"></param>
        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            SoftConfigModer scfm = new SoftConfigModer();
            scfm.softKey = txtKEY.Text.Trim();
            scfm.softServerIP = txtServers.Text.Trim();
            scfm.softDBName = cbbDBName.Text.Trim();
            scfm.softDBUser = txtUser.Text.Trim();
            scfm.softDBPwd = txtPWD.Password.Trim();
            SoftVerify softVerify = new SoftVerify();
            ConfigService csf = new ConfigService();
            csf.softConfigSaveToXml(scfm, softVerify);
            cfw.Close();
            MainWindow mw = new MainWindow();
            mw.Show();
        }

        /// <summary>
        /// 测试连接
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnTestConnect_Click(object sender, RoutedEventArgs e)
        {
           
        }

        /// <summary>
        /// 软件注册码测试
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void KeyTest_Click(object sender, RoutedEventArgs e)
        {

        }

  


    }
}
