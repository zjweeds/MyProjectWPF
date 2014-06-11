using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MyExtendControls.MyControls.TemplateContorl;
using Controllers.Enum;
using Controllers.Models;
using Controllers.Business;
using Controllers.Common;

namespace BillManageWPF.winFormUI
{
    public partial class TextBoxProperyForm : Form
    {
        #region 构造函数
        public TextBoxProperyForm()
        {
            InitializeComponent();
        }
        public TextBoxProperyForm(TemplateMain fm, MyTextBox tb)
        {
            InitializeComponent();
            tmp = tb;
            tm = fm;          
        }
        #endregion 
        #region  页面变量
        public MyTextBox tmp = null;
        public TemplateMain tm = null;
      //  public TextControlInfo textModel=null;
        public Font font = null;
        public Color bgc;
        public Color frc;
        #endregion
        #region 自定义方法
        public void GetPropery()
        {
            if (tmp != null)
            {
                txtName.Text = tmp.ControlName;
                txtDefalutValue.Text = tmp.DefaultValue;
                txttab.Text = tmp.TabIndex.ToString();
                cbbShowType.SelectedIndex = tmp.showType;
                cbbMarkType.SelectedIndex = tmp.markType;
                chbisborestyle.Checked = tmp.BorderStyle == BorderStyle.None ? false : true;
                chbIsvisible.Checked = tmp.Visible;
                txtfont.Text = tmp.Font.ToString();
                txtForeColor.Text = tmp.ForeColor.ToString();
                txtBackColor.Text = tmp.BackColor.ToString();
                txttop.Text = tmp.Top.ToString();
                txtleft.Text = tmp.Left.ToString();
                txtwidth.Text = tmp.Width.ToString();
                txtheight.Text = tmp.Height.ToString();
                if (tmp.txtDatasource != null)
                {
                    cbxTablename.SelectedText = tmp.txtDatasource.TableName.ToString();
                    cbxCoumname.SelectedText = tmp.txtDatasource.Column.ToString();
                }
                chbIsreadonly.Checked = tmp.ReadOnly;
                chbIsFalge.Checked = tmp.IsFlage;
                chbIsmust.Checked = tmp.IsMust ? true : false;
                chbIsprInt.Checked = tmp.IsPrint ? true : false;  
            }
        }

        public void SetPropery()
        {
            if (tmp != null)
            {
                tmp.ControlName = txtName.Text;
                tmp.Text = txtName.Text;
                tmp.DefaultValue = txtDefalutValue.Text;
                tmp.TabIndex = Convert.ToInt32(txttab.Text);              
                tmp.showType = cbbShowType.SelectedIndex;
                tmp.markType = cbbMarkType.SelectedIndex;
                tmp.BorderStyle = chbisborestyle.Checked ? BorderStyle.None : BorderStyle.FixedSingle;
                tmp.Visible = chbIsvisible.Checked;
                tmp.Top = Convert.ToInt32(txttop.Text);
                tmp.Left = Convert.ToInt32(txtleft.Text);
                tmp.Width = Convert.ToInt32(txtwidth.Text);
                tmp.Height = Convert.ToInt32(txtheight.Text);
                tmp.txtDatasource = new ControlDataSource(cbxTablename.Text, cbxCoumname.Text);
                tmp.ReadOnly = chbIsreadonly.Checked;
                tmp.IsFlage = chbIsFalge.Checked;
                tmp.IsMust = chbIsmust.Checked ;
                tmp.IsPrint = chbIsprInt.Checked;
            }
        }       
        #endregion
        private void button1_Click(object sender, EventArgs e)
        {
            SetPropery();
           // UpdateModel();
        }

        /// <summary>
        /// 窗体加载事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TextBoxProperyForm_Load(object sender, EventArgs e)
        {
            if (tm != null && tmp != null)
            {
                GetPropery();
                font = tmp.Font;
                bgc = tmp.BackColor;
                frc = tmp.ForeColor;
                DataTable dt = DataSourceManager.GetDataTableByCompanyName(SoftUser.UserCompany);
                cbxTablename.Items.Add(String.Empty);
                if (dt != null && dt.Rows.Count > 0)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        cbxTablename.Items.Add(dt.Rows[i][0].ToString());
                    }
                }
            }
        }

        /// <summary>
        /// 设置字体
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSetFont_Click(object sender, EventArgs e)
        {
            if (fd.ShowDialog() != DialogResult.Cancel)
            {
                txtfont.Text = fd.Font.ToString();
                font = fd.Font;
                tmp.Font = font;
            }
        }

        /// <summary>
        /// 设置前景色
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnForeColor_Click(object sender, EventArgs e)
        {
            cd.Color = frc;
            if (cd.ShowDialog() != DialogResult.Cancel)
            {
                txtForeColor.Text = cd.Color.ToString();
                frc = cd.Color;
                tmp.ForeColor = frc;
            }
        }

        /// <summary>
        /// 设置背景色
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnBackgroud_Click(object sender, EventArgs e)
        {
            cd.Color = bgc;
            if (cd.ShowDialog() != DialogResult.Cancel)
            {
                txtBackColor.Text = cd.Color.ToString();
                bgc = cd.Color;
                tmp.BackColor = bgc;
            }
        }

        private void TextBoxProperyForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            SetPropery();
            //UpdateModel();
        }

        private void TextBoxProperyForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Dispose();//释放资源
        }

        private void cbxTablename_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                cbxCoumname.Items.Clear();
                cbxCoumname.Items.Add(String.Empty);
                if (cbxTablename.Text != String.Empty)
                {
                    DataTable dt = DataSourceManager.GetDataTableByTableName(cbxTablename.Text);
                    if (dt != null && dt.Rows.Count > 0)
                    {
                        for (int i = 0; i < dt.Rows.Count; i++)
                        {
                            cbxCoumname.Items.Add(dt.Rows[i][1].ToString());
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "软件提示");
            }
        }
    }
}
