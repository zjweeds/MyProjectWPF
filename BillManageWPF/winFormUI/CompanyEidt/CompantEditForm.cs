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

        public String ItemName = String.Empty;

        /// <summary>
        /// 加载子公司节点
        /// </summary>
        /// <param name="prentNode"></param>
        private void LoadNode(TreeNode prentNode)
        {
            try
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
            catch(Exception ex)
            {
                MessageBox.Show(ex.ToString(), "软件提示");
            }
        }

        /// <summary>
        /// 加载公司信息
        /// </summary>
        /// <param name="CIID"></param>
        private void LoadInfo(int CIID)
        {
            try
            {
                CompanyInfo ci = CompanyInfoManager.SelectCompanyInfoByCIID(CIID);
                txtCompanyName.Text = ci.CIName;
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
                DataTable dtDp = DepartmentManage.GetAllDepartmentNameByCompanyName(ci.CIName);
                ListDpm.Items.Clear();
                if (dtDp != null && dtDp.Rows.Count > 0)
                {

                    for (int i = 0; i < dtDp.Rows.Count; i++)
                    {
                        ListDpm.Items.Add(dtDp.Rows[i]["DIName"].ToString());                       
                    }
                }
            }
            catch (Exception ex)
            {
            }
        }

        /// <summary>
        /// 窗体加载
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CompantEditForm_Load(object sender, EventArgs e)
        {
            try
            {
                TreeNode node = new TreeNode();
                node.Text = SoftUser.UserCompany;
                node.Tag = CompanyInfoManager.GetIDByCompanyName(SoftUser.UserCompany);
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
            catch (Exception ex)
            {
            }
        }

        /// <summary>
        /// 点击节点展开下一级
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tvCompanyInfo_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            try
            {
                if (e.Node.Tag != null)
                {
                    txtCompanyName.Text = e.Node.Text;
                    e.Node.Nodes.Clear();
                    LoadNode(e.Node);
                    LoadInfo(Convert.ToInt32(e.Node.Tag));
                }
            }
            catch (Exception ex)
            {
            }
        }

        /// <summary>
        /// 子公司添加
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void 添加子公司ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                TreeNode tn = tvCompanyInfo.SelectedNode;
                CompanyAddForm cdf = new CompanyAddForm(tn.Text);
                cdf.ShowDialog();
                TreeNode node = new TreeNode();
                node.Text = SoftUser.UserCompany;
                node.Tag = CompanyInfoManager.GetIDByCompanyName(SoftUser.UserCompany);
                LoadNode(node);
            }
            catch (Exception ex)
            {
            }
        }

        /// <summary>
        /// 退出
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolbtnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// 点击部门获得职位信息
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ListDpm_Click(object sender, EventArgs e)
        {
            if (ListDpm.SelectedItem.ToString() != String.Empty)
            {
                int DIID = DepartmentManage.GetAllDepartmentIDByCompanyName(txtCompanyName.Text, ListDpm.SelectedItem.ToString());
                DataTable dtpo = PositionManage.GetAllPositionNameByDepartment(DIID);
                listPost.Items.Clear();
                if (dtpo != null && dtpo.Rows.Count > 0)
                {
                    for (int i = 0; i < dtpo.Rows.Count; i++)
                    {
                        listPost.Items.Add(dtpo.Rows[i]["PIName"].ToString());
                    }
                }
            }
        }

        /// <summary>
        /// 添加部门
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolDadd_Click(object sender, EventArgs e)
        {
            DepartmentEditForm def = new DepartmentEditForm(this,0);
            def.ShowDialog();
            if (ItemName != String.Empty)
            {
                int ciid = CompanyInfoManager.GetIDByCompanyName(txtCompanyName.Text);
                if (DepartmentManage.AddDepartment(ItemName, ciid)>0)
                {
                    ItemName = String.Empty;
                    LoadInfo(ciid);
                }
            }
        }

        /// <summary>
        /// 修改部门信息
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolDModify_Click(object sender, EventArgs e)
        {
            DepartmentEditForm def = new DepartmentEditForm(this,0);
            def.ShowDialog();
            if (ItemName != String.Empty)
            {
                int ciid = CompanyInfoManager.GetIDByCompanyName(txtCompanyName.Text);
                if (DepartmentManage.UpdateDepartment(ItemName, ciid) > 0)
                {
                    ItemName = String.Empty;
                    LoadInfo(ciid);
                }
            }
        }

        /// <summary>
        /// 删除部门信息
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolDeleteD_Click(object sender, EventArgs e)
        {
            if (ListDpm.SelectedItem != null && ListDpm.SelectedItem.ToString() != String.Empty)
            {
                int DIID = DepartmentManage.GetAllDepartmentIDByCompanyName(txtCompanyName.Text, ListDpm.SelectedItem.ToString());
                DepartmentManage.DeleteDepartment(DIID);
                DataTable dtDp = DepartmentManage.GetAllDepartmentNameByCompanyName(txtCompanyName.Text);
                ListDpm.Items.Clear();
                if (dtDp != null && dtDp.Rows.Count > 0)
                {

                    for (int i = 0; i < dtDp.Rows.Count; i++)
                    {
                        ListDpm.Items.Add(dtDp.Rows[i]["DIName"].ToString());                       
                    }
                }
            }
        }

        /// <summary>
        /// 增加职位信息
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tooladdP_Click(object sender, EventArgs e)
        {
            DepartmentEditForm def = new DepartmentEditForm(this,1);
            def.ShowDialog();
            if (ItemName != String.Empty)
            {
                if (ListDpm.SelectedItem != null && ListDpm.SelectedItem.ToString() != String.Empty)
                {
                    int DIID = DepartmentManage.GetAllDepartmentIDByCompanyName(txtCompanyName.Text, ListDpm.SelectedItem.ToString());
                    if (PositionManage.AddPosition(ItemName, DIID) > 0)
                    {
                        ItemName = String.Empty;
                        #region 刷新
                        DataTable dtpo = PositionManage.GetAllPositionNameByDepartment(DIID);
                        listPost.Items.Clear();
                        if (dtpo != null && dtpo.Rows.Count > 0)
                        {
                            for (int i = 0; i < dtpo.Rows.Count; i++)
                            {
                                listPost.Items.Add(dtpo.Rows[i]["PIName"].ToString());
                            }
                        }
                        #endregion
                    }
                }
            }
        }

        /// <summary>
        ///修改职位信息
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolModify_Click(object sender, EventArgs e)
        {
            DepartmentEditForm def = new DepartmentEditForm(this, 1);
            def.ShowDialog();
            if (ItemName != String.Empty)
            {
                if (ListDpm.SelectedItem != null && ListDpm.SelectedItem.ToString() != String.Empty
                    && listPost.SelectedItem != null && listPost.SelectedItem.ToString() != String.Empty)
                {
                    int DIID = DepartmentManage.GetAllDepartmentIDByCompanyName(txtCompanyName.Text, ListDpm.SelectedItem.ToString());
                    int PIID = PositionManage.GetPositionIDByPositionName(listPost.SelectedItem.ToString(), DIID);
                    if (PositionManage.UpdatePosition(ItemName, PIID) > 0)
                    {
                        ItemName = String.Empty;
                        #region 刷新
                        DataTable dtpo = PositionManage.GetAllPositionNameByDepartment(DIID);
                        listPost.Items.Clear();
                        if (dtpo != null && dtpo.Rows.Count > 0)
                        {
                            for (int i = 0; i < dtpo.Rows.Count; i++)
                            {
                                listPost.Items.Add(dtpo.Rows[i]["PIName"].ToString());
                            }
                        }
                        #endregion
                    }
                }
            }
        }

        /// <summary>
        /// 删除职位信息
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolDelete_Click(object sender, EventArgs e)
        {
            if (ListDpm.SelectedItem != null && ListDpm.SelectedItem.ToString() != String.Empty
                   && listPost.SelectedItem != null && listPost.SelectedItem.ToString() != String.Empty)
            {
                int DIID = DepartmentManage.GetAllDepartmentIDByCompanyName(txtCompanyName.Text, ListDpm.SelectedItem.ToString());
                int PIID = PositionManage.GetPositionIDByPositionName(listPost.SelectedItem.ToString(), DIID);
                if (PositionManage.DeletePosition(PIID))
                {
                    #region 刷新
                    DataTable dtpo = PositionManage.GetAllPositionNameByDepartment(DIID);
                    listPost.Items.Clear();
                    if (dtpo != null && dtpo.Rows.Count > 0)
                    {
                        for (int i = 0; i < dtpo.Rows.Count; i++)
                        {
                            listPost.Items.Add(dtpo.Rows[i]["PIName"].ToString());
                        }
                    }
                    #endregion
                }
            }
        }

    }
}
