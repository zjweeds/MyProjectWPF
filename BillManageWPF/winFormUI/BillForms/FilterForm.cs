using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BillManageWPF.winFormUI.BillForms
{
    public partial class FilterForm : Form
    {
        public FilterForm()
        {
            InitializeComponent();
        }
        public FilterForm(int code)
        {
            InitializeComponent();   
        }
        private void FilterForm_Load(object sender, EventArgs e)
        {
            //加载所有列
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
