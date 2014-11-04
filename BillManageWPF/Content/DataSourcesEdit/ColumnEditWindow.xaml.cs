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
using BillManageWPF.Page;
using Controllers.Business;

namespace BillManageWPF.Content.DataSourcesEdit
{
    /// <summary>
    /// ColumnEditWindow.xaml 的交互逻辑
    /// </summary>
    public partial class ColumnEditWindow : Window
    {
        public ColumnEditWindow()
        {
            InitializeComponent();
        }

        private DataSourceList tdsl = null;
        private int pageIndex = 0;
        public ColumnEditWindow(DataSourceList dsl,int index)
        {
            InitializeComponent();
            tdsl = dsl;
            pageIndex = index;
        }

        private void btnQueDing_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (txtTypeName.Text != String.Empty)
                {
                    if (tdsl != null)
                    {
                        bool isRepit = false;//名称是否重复
                        for (int i = 0; i < tdsl.dgvList[pageIndex].ColumnCount; i++)
                        {
                            if (tdsl.dgvList[pageIndex].Columns[i].HeaderText == txtTypeName.Text.Trim())
                            {
                                isRepit = true;
                                break;
                            }
                        }
                        if (!isRepit)
                        {
                            tdsl.columnName = txtTypeName.Text.Trim();
                            this.Close();
                        }
                        else
                        {
                            MessageBox.Show(String.Format("已存在名为{0}的列", txtTypeName.Text), "软件提示");
                            txtTypeName.Text = String.Empty;
                            txtTypeName.Focus();
                        }
                    }
                }
                else
                {
                    MessageBox.Show(String.Format("列名不能为空！", "软件提示"));
                    txtTypeName.Focus();
                }
            }
            catch (Exception ex)
            {
            }
        }

        private void btnQuXiao_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

        }
    }
}
