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
using Controllers.DataAccess;
using Controllers.Common;

namespace BillManageWPF.winFormUI
{
    public partial class CheckBoxProperyForm : Form
    {
        #region 构造函数
        public CheckBoxProperyForm()
        {
            InitializeComponent();
        }
        public CheckBoxProperyForm(TemplateMain fm, MyCheckBox tb)
        {
            InitializeComponent();
            tmp = tb;
            tm = fm;          
        }
        #endregion 

        #region  页面变量
        public MyCheckBox tmp = null;
        public TemplateMain tm = null;
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
                chbDefault.Checked = tmp.DefaultValue!="true"?false:true;
                txttab.Text = tmp.TabIndex.ToString();
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
                    cbxTablename.Text = tmp.txtDatasource.TableName.ToString();
                    cbxCoumname.Text = tmp.txtDatasource.Column.ToString();
                }            
                chbIsmust.Checked = tmp.IsMust ? false : true;
                chbIsprInt.Checked = tmp.IsPrint? false : true;
            }
        }

        public void SetPropery()
        {
            if (tmp != null)
            {
                tmp.ControlName = txtName.Text;
                tmp.DefaultValue = chbDefault.Checked?"true":"false";
                tmp.TabIndex = Convert.ToInt32(txttab.Text);
                tmp.Visible = chbIsvisible.Checked;
                tmp.Top = Convert.ToInt32(txttop.Text);
                tmp.Left = Convert.ToInt32(txtleft.Text);
                tmp.Width = Convert.ToInt32(txtwidth.Text);
                tmp.Height = Convert.ToInt32(txtheight.Text);
                tmp.txtDatasource = new ControlDataSource(cbxTablename.Text, cbxCoumname.Text);
                tmp.IsMust = chbIsmust.Checked ;
                tmp.IsPrint = chbIsprInt.Checked ;
            }
        }
        #endregion

        /// <summary>
        /// 设置字体
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSetFont_Click(object sender, EventArgs e)
        {
            try
            {
                if (fd.ShowDialog() != DialogResult.Cancel)
                {
                    txtfont.Text = fd.Font.ToString();
                    font = fd.Font;
                    tmp.Font = font;
                }
            }            
            catch(Exception ex)
            {
            }
        }

        /// <summary>
        /// 设置前景色
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnForeColor_Click(object sender, EventArgs e)
        {
            try
            {
                cd.Color = frc;
                if (cd.ShowDialog() != DialogResult.Cancel)
                {
                    txtForeColor.Text = cd.Color.ToString();
                    frc = cd.Color;
                    tmp.ForeColor = frc;
                }
            }
            catch (Exception ex)
            {
            }
        }

        /// <summary>
        /// 设置背景色
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnBackgroud_Click(object sender, EventArgs e)
        {
            try
            {
                cd.Color = bgc;
                if (cd.ShowDialog() != DialogResult.Cancel)
                {
                    txtBackColor.Text = cd.Color.ToString();
                    bgc = cd.Color;
                    tmp.BackColor = bgc;
                }
            }            
            catch(Exception ex)
            {
            }
        }

        private void CheckBoxProperyForm_Load(object sender, EventArgs e)
        {
            try
            {
                if (tmp != null && tm != null)
                {
                    GetPropery();
                    //checkbox = tm.chbList[tmp.NewNumber] as CheckBoxInfo;
                    font = tmp.Font;
                    bgc = tmp.BackColor;
                    frc = tmp.ForeColor; ;
                }
            }
            catch (Exception ex)
            {
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                SetPropery();
            }
            catch (Exception ex)
            {
            }
        }
    }
}
