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

namespace BillManageWPF.Content.DataSourcesEdit
{
    /// <summary>
    /// TableEditWindow.xaml 的交互逻辑
    /// </summary>
    public partial class TableEditWindow : Window
    {
        public TableEditWindow(DataSourceList sdtl)
        {
            InitializeComponent();
            this.Tdsl = sdtl;
        }
        public TableEditWindow(DataSourceList sdtl,int index )
        {
            InitializeComponent();
            this.Tdsl = sdtl;
            this.tabpageIndex = index;
        }
        private DataSourceList Tdsl = null;
        private int tabpageIndex = 0;//旧表名


        private void ADD()
        {
            bool isRepit = false;//表名重名标记，true 表示有重名
            for (int i = 0; i < Tdsl.tabMeum.TabPages.Count; i++)
            {
                if (txtTypeName.Text.Trim() == Tdsl.tabMeum.TabPages[i].Text)
                {
                    isRepit = true;
                    break;
                }
            }
            if (!isRepit)
            {
                Tdsl.tableName = txtTypeName.Text.Trim();
                this.Close();
            }
            else
            {
                MessageBox.Show(String.Format("已存在表名为{0}的表！", txtTypeName.Text), "软件提示");
                txtTypeName.Focus();
            }
        }

        private void Modify()
        {
            bool isRepit = false;//表名重名标记，true 表示有重名

            for (int i = 0; i < Tdsl.tabMeum.TabPages.Count; i++)
            {
                if (i != tabpageIndex && txtTypeName.Text.Trim() == Tdsl.tabMeum.TabPages[i].Text)
                {
                    isRepit = true;
                    break;
                }
            }
            if (!isRepit)
            {
                Tdsl.tableName = txtTypeName.Text.Trim();
                this.Close();
            }
            else
            {
                MessageBox.Show(String.Format("已存在表名为{0}的表！", txtTypeName.Text), "软件提示");
                txtTypeName.Focus();
            }
        }
        private void btnQueDing_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (txtTypeName.Text != String.Empty)
                {
                    if (Tdsl != null)
                    {
                        if (tabpageIndex == 0)
                        {
                            ADD();
                        }
                        else
                        {
                            Modify();
                        }
                    }
                }
                else
                {
                    MessageBox.Show("表名不能为空！", "软件提示");
                    txtTypeName.Focus();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
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
