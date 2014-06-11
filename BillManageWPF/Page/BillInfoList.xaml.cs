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
using Controllers.Business;
using System.Data;
using Controllers.Models;

namespace BillManageWPF.Page
{
    /// <summary>
    /// BillInfoList.xaml 的交互逻辑
    /// </summary>
    public partial class BillInfoList : UserControl
    {
        public BillInfoList()
        {
            InitializeComponent();
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                DataTable dt = BillTemplateManage.GetTemplatBagroundByBSName(SoftUser.Op_Bill);
                cbbTemplate.ItemsSource = dt.DefaultView;
                cbbTemplate.DisplayMemberPath = "TIName";
                cbbTemplate.SelectedValuePath = "TIID";
                txtLow.Text = String.Empty; ;
                txtHigh.Text = String.Empty;
                dgvView.DataSource = BillInfoManager.GetBillInfoByBillSet(SoftUser.Op_Bill, String.Empty);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void btnSelect_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                StringBuilder linqStr = new StringBuilder();
                if (cbbTemplate.Text != String.Empty)
                {
                    linqStr.AppendFormat(" and TIName= '{0}' ", cbbTemplate.Text);
                }
                if (dtptStart.Text != string.Empty)
                {
                    linqStr.AppendFormat(" and BICreatTime > '{0}' ", dtptStart.Text);
                }
                if (dtptEnd.Text != string.Empty)
                {
                    linqStr.AppendFormat(" and BICreatTime < '{0}' ", dtptEnd.Text);
                }
                if (txtLow.Text != string.Empty)
                {
                    linqStr.AppendFormat(" and BIAmount >= '{0}' ", txtLow.Text);
                }
                if (txtHigh.Text != string.Empty)
                {
                    linqStr.AppendFormat(" and BIAmount <= '{0}' ", txtHigh.Text);
                }
                dgvView.DataSource = BillInfoManager.GetBillInfoByBillSet(SoftUser.Op_Bill, linqStr.ToString());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
    }
}
