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

namespace BillManageWPF.Content.SystemSet
{
    /// <summary>
    /// PrInt32Set.xaml 的交互逻辑
    /// </summary>
    public partial class PrintSet : Window
    {
        public PrintSet()
        {
            InitializeComponent();
        }
        private IList<PrintSetInfo> psList = null;
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            psList = PrintSetManager.SelectAllPrintSet();
            if (psList != null && psList.Count > 0)
            {
                foreach (PrintSetInfo psi in psList)
                {
                    list.Items.Add(psi.PSName);
                }
            }
        }

        private void list_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int index = list.SelectedIndex;
            txtName.Text = psList[index].PSName;
            txtLeft.Text = psList[index].PSLeft.ToString();
            txtRight.Text = psList[index].PSRight.ToString();
        }

        private void btnNew_Click(object sender, RoutedEventArgs e)
        {
            txtName.Text = String.Empty;
            txtLeft.Text = String.Empty;
            txtRight.Text = String.Empty;
        }
    }
}
