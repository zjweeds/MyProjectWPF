using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BillManageWPF.winFormUI.CompanyEidt
{
    public partial class DepartmentEditForm : Form
    {
        public DepartmentEditForm(CompantEditForm sdef,int  itype)
        {
            InitializeComponent();
            cef = sdef;
            type = itype;
        }
        private CompantEditForm cef = null;
        private int type=0;
        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != String.Empty)
            {
                cef.ItemName = textBox1.Text;
                this.Close();
            }
            else
            {
                MessageBox.Show("部门名称不能为空！", "软件提示");
            }

        }

        private void DepartmentEditForm_Load(object sender, EventArgs e)
        {
            if (type == 0)
            {
                //部门操作
                this.Text = "部门信息";
                label1.Text = "部门名称";
            }
            else
            {
                //职位操作
                this.Text = "职位信息";
                label1.Text = "职位名称";
            }
        }
    }
}
