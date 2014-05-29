using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Controllers.Models;
using Controllers.Business;

namespace BillManageWPF.winFormUI.CompanyEidt
{
    public partial class CompantEditForm : Form
    {
        public CompantEditForm()
        {
            InitializeComponent();
        }

        
        private void LoadNode(TreeNode prentNode)
        {
            DataTable dt = CompanyInfoManager.GetChildrenCompanyByCompanyName(prentNode.Text);
            if (dt != null && dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    TreeNode childnode = new TreeNode();
                    childnode.Text = dt.Rows[i]["CIName"].ToString();
                    childnode.Tag = dt.Rows[i]["CIID"].ToString();
                    prentNode.Nodes.Add(childnode);
                }
            }
        }

        private void LoadInfo(int CIID)
        {
            CompanyInfo ci = CompanyInfoManager.SelectCompanyInfoByCIID(CIID);
           // txtCompanyName.Text = ci.CIName;
            txtDesription.Text = ci.CIDescription;
            lbEMCount.Text = EmployeeInfoManager.ConutEmNumberByCompany(ci.CIID).ToString();
            lbChildCount.Text = CompanyInfoManager.GetChildrenCountsByCompany(ci.CIID).ToString();
            DataTable dtbs = BillSetManager.GetDataTableByCompanyID(ci.CIID);
            lsvBillset.Items.Clear();
            if (dtbs != null && dtbs.Rows.Count > 0)
            {

                for (int i = 0; i < dtbs.Rows.Count; i++)
                {
                    lsvBillset.Items.Add(dtbs.Rows[i]["BSIName"].ToString());
                }
            }
        }
        /// <summary>
        /// 窗体加载
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CompantEditForm_Load(object sender, EventArgs e)
        {
           TreeNode node = new TreeNode();
            node.Text = SoftUser.UserCompany;
            node.Tag =  CompanyInfoManager.GetIDByCompanyName(SoftUser.UserCompany);
            DataTable dt = CompanyInfoManager.GetChildrenCompanyByCompanyName(SoftUser.UserCompany);
            if (dt != null && dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    TreeNode childnode = new TreeNode();
                    childnode.Text = dt.Rows[i]["CIName"].ToString();
                    childnode.Tag = dt.Rows[i]["CIID"].ToString();
                    node.Nodes.Add(childnode);
                }
            }
            tvCompanyInfo.Nodes.Add(node);
        }

        private void tvCompanyInfo_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            if (e.Node.Tag != null)
            {
                txtCompanyName.Text = e.Node.Text;
                e.Node.Nodes.Clear();
                LoadNode(e.Node);
                LoadInfo(Convert.ToInt32(e.Node.Tag));
            }
        }

        private void 添加子公司ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TreeNode tn = tvCompanyInfo.SelectedNode;
            CompanyAddForm cdf = new CompanyAddForm(tn.Text);
            cdf.ShowDialog();
            TreeNode node = new TreeNode();
            node.Text = SoftUser.UserCompany;
            node.Tag = CompanyInfoManager.GetIDByCompanyName(SoftUser.UserCompany);
            LoadNode(node);
        }

        private void toolbtnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
