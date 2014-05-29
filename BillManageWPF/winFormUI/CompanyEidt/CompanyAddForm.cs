using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Controllers.Business;
using Controllers.Models;

namespace BillManageWPF.winFormUI.CompanyEidt
{
    public partial class CompanyAddForm : Form
    {
        public CompanyAddForm()
        {
            InitializeComponent();
        }
        public CompanyAddForm(String   priName)
        {
            InitializeComponent();
            prientName = priName;
        }
        private String prientName = String.Empty;
        private void CompanyAddForm_Load(object sender, EventArgs e)
        {
            lbCompanNmae.Text = prientName;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (txtName.Text != String.Empty)
            {
                CompanyInfo ci = new CompanyInfo();
                ci.CIName = txtName.Text;
                ci.CIParentID = CompanyInfoManager.GetIDByCompanyName(prientName);
                ci.CIDescription = txtDesription.Text;
                ci.CICreaterID = SoftUser.UserCode;
                ci.CICreateTime = DateTime.Now;
                if (CompanyInfoManager.AddCompanyInfo(ci))
                {
                    MessageBox.Show("添加成功！");
                    this.Close();
                }
                else
                {
                    MessageBox.Show("添加失败！");
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
