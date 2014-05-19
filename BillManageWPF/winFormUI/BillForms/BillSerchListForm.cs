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

namespace BillManageWPF.winFormUI.BillForms
{
    public partial class BillSerchListForm : Form
    {
        public BillSerchListForm()
        {
            InitializeComponent();
        }
        public BillSerchListForm(int code)
        {
            InitializeComponent();
        }

        private void toolSave_MouseEnter(object sender, EventArgs e)
        {
            ToolStripButton tsb = sender as ToolStripButton;
            if (tsb != null)
            {
                tsb.BackColor = Color.Purple;
            }
        }

        private void toolSave_MouseLeave(object sender, EventArgs e)
        {
            ToolStripButton tsb = sender as ToolStripButton;
            if (tsb != null)
            {
                tsb.BackColor = Color.SkyBlue;
            }
        }
    }
}
