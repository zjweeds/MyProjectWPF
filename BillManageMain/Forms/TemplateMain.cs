using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Controllers.Common;

namespace BillManageMain.Forms
{
    public partial class TemplateMain : Form
    {
        public TemplateMain()
        {
            InitializeComponent();
        }
        int codes;
        public TemplateMain(int code)
        {
            InitializeComponent();
            codes = code;
        }
        private void Template_Load(object sender, EventArgs e)
        {
            FormSetTemplate child = new FormSetTemplate(codes,this);
            this.splitContainer1.Panel1.Controls.Clear();           
            child.TopLevel = false;
            child.Dock = System.Windows.Forms.DockStyle.Fill;
            child.FormBorderStyle = FormBorderStyle.None;
            this.splitContainer1.Panel1.Controls.Add(child);
            child.Show();

        }

        private void splitContainer1_Panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void cbbControls_SelectedIndexChanged(object sender, EventArgs e)
        {
            PropertyForm child = new PropertyForm(Convert.ToInt32(((ComboxItem)cbbControls.SelectedItem).Value));
            this.splitContainer1.Panel1.Controls.Clear();           
            child.TopLevel = false;
            child.Dock = System.Windows.Forms.DockStyle.Fill;
            child.FormBorderStyle = FormBorderStyle.None;
            PropertyPanel.Controls.Add(child);
            child.Show();
            
        }
    }
}
