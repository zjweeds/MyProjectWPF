using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BillManageWPF.winFormUI
{
    public partial class FilterForm : Form
    {
        public  String sLinqString = String.Empty;
        public IList<String> sName = new List<String>();
        public FilterForm()
        {
            InitializeComponent();
 
        }

        public FilterForm(List<String> s)
        {
            InitializeComponent();
            sName = s;
        }

        public String GetLinQString()
        {
            String sLinq = cbbLie1.Text.ToString() + cbbBJ1.Text + "'" + cbbVaule1.Text + "'";
            if (cbbLie2.Enabled)
            {
                sLinq += cbbGX1.Text.ToString() + cbbLie2.SelectedValue.ToString()
                    + cbbBJ2.Text.ToString() + "'" + cbbVaule2.Text + "'";
            }
            if (cbbLie3.Enabled)
            {
                sLinq += cbbGX2.Text.ToString() + cbbLie3.Text.ToString()
                    + cbbBJ3.Text.ToString() + "'" + cbbVaule3.Text + "'";
            }
            if (cbbLie4.Enabled)
            {
                sLinq += cbbGX3.Text.ToString() + cbbLie4.Text.ToString()
                    + cbbBJ4.Text.ToString() + "'" + cbbVaule4.Text + "'";
            }
            if (cbbLie5.Enabled)
            {
                sLinq += cbbGX4.Text.ToString() + cbbLie5.Text.ToString()
                    + cbbBJ5.Text.ToString() + "'" + cbbVaule5.Text + "'";
            }
            if (cbbLie6.Enabled)
            {
                sLinq += cbbGX5.Text.ToString() + cbbLie6.Text.ToString()
                    + cbbBJ6.Text.ToString() + "'" + cbbVaule6.Text + "'";
            }
            return sLinq;
        }
        private void SetEnableFalse()
        {
            cbbGX2.Enabled = false;
            cbbGX3.Enabled = false;
            cbbGX4.Enabled = false;
            cbbGX5.Enabled = false;
            cbbLie2.Enabled = false;
            cbbLie2.DataSource = null;
            cbbVaule2.Enabled = false;
            cbbBJ2.Enabled = false;         
            cbbLie3.Enabled = false;
            cbbLie3.DataSource = null;
            cbbVaule3.Enabled = false;
            cbbBJ3.Enabled = false;
            cbbLie4.Enabled = false;
            cbbLie4.DataSource = null;
            cbbVaule4.Enabled = false;
            cbbBJ4.Enabled = false;
            cbbLie5.Enabled = false;
            cbbLie5.DataSource = null;
            cbbVaule5.Enabled = false;
            cbbBJ5.Enabled = false;
            cbbLie6.Enabled = false;
            cbbLie6.DataSource = null;
            cbbVaule6.Enabled = false;
            cbbBJ6.Enabled = false;
        }
        private void LoadItems(ComboBox cmb)
        {
            cmb.Items.Clear();
            if(sName!=null&&sName.Count>0)
            {
                foreach (String sn in sName)
                {
                    cmb.Items.Add(sn);
                }
            }
        }
        private void FilterForm_Load(object sender, EventArgs e)
        {            
            //加载所有列
            LoadItems(cbbLie1);
            cbbBJ1.SelectedIndex = 0;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void comboBox19_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbbGX1.SelectedIndex != 0)
            {
                cbbLie2.Enabled = true;
                LoadItems(cbbLie2);
                cbbVaule2.Enabled = true;
                cbbBJ2.Enabled = true;
                cbbGX2.Enabled = true;
            }
            else
            {
                cbbLie2.Enabled = false;
                cbbLie2.DataSource = null;
                cbbVaule2.Enabled = false;
                cbbBJ2.Enabled = false;
                cbbGX2.Enabled = false;
            }
        }

        private void cbbGX2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbbGX2.SelectedIndex != 0)
            {
                cbbLie3.Enabled = true;
                LoadItems(cbbLie3);
                cbbVaule3.Enabled = true;
                cbbBJ3.Enabled = true;
                cbbGX3.Enabled = true;
            }
            else
            {
                cbbLie3.Enabled = false;
                cbbLie3.DataSource = null;
                cbbVaule3.Enabled = false;
                cbbBJ3.Enabled = false;
                 cbbGX3.Enabled = false;
            }
        }

        private void cbbGX3_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbbGX3.SelectedIndex != 0)
            {
                cbbLie4.Enabled = true;
                LoadItems(cbbLie4);
                cbbVaule4.Enabled = true;
                cbbBJ4.Enabled = true;
                cbbGX4.Enabled = true;
            }
            else
            {
                cbbLie4.Enabled = false;
                cbbLie4.DataSource = null;
                cbbVaule4.Enabled = false;
                cbbBJ4.Enabled = false;
            }
        }

        private void cbbGX4_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbbGX4.SelectedIndex != 0)
            {
                cbbLie5.Enabled = true;
                LoadItems(cbbLie5);
                cbbVaule5.Enabled = true;
                cbbBJ5.Enabled = true;
                cbbGX5.Enabled = true;
            }
            else
            {
                cbbLie5.Enabled = false;
                cbbLie5.DataSource = null;
                cbbVaule5.Enabled = false;
                cbbBJ5.Enabled = false;
                cbbGX5.Enabled = false;
            }
        }

        private void cbbGX5_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbbGX5.SelectedIndex != 0)
            {
                cbbLie6.Enabled = true;
                LoadItems(cbbLie6);
                cbbVaule6.Enabled = true;
                cbbBJ6.Enabled = true;
            }
            else
            {
                cbbLie6.Enabled = false;
                cbbLie6.DataSource = null;
                cbbVaule6.Enabled = false;
                cbbBJ6.Enabled = false;
            }
        }

        /// <summary>
        /// 全部清除
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnClearAll_Click(object sender, EventArgs e)
        {
            SetEnableFalse();
            LoadItems(cbbLie1);
            cbbBJ1.SelectedIndex = 0;
            cbbVaule1.Text =String.Empty;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.sLinqString = GetLinQString();
            this.Close();
        }
    }
}
