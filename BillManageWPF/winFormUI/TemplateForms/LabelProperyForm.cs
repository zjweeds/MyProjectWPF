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
    public partial class LabelProperyForm : Form
    {
        #region  构造函数
        public LabelProperyForm()
        {
            InitializeComponent();
        }
        public LabelProperyForm(TemplateMain fm, MyLabel tb)
        {
            InitializeComponent();
            tmp = tb;
            tm = fm;          
        }
        #endregion 

        #region  页面变量
        public MyLabel tmp = null;
        public TemplateMain tm = null;
        //public LabelInfo label = null;
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
                    cbxTablename.Text = tmp.txtDatasource.TableName.ToString();
                    cbxCoumname.Text = tmp.txtDatasource.Column.ToString();
                }
                chbIsmust.Checked = tmp.IsMust;
                chbIsprInt.Checked = tmp.IsPrint;
            }
        }

        public void SetPropery()
        {
            if (tmp != null)
            {
                tmp.ControlName = txtName.Text;
                tmp.DefaultValue = txtDefalutValue.Text;
                tmp.TabIndex = Convert.ToInt32(txttab.Text);
                tmp.BorderStyle = chbisborestyle.Checked ? BorderStyle.None : BorderStyle.FixedSingle;
                tmp.Visible = chbIsvisible.Checked;
                tmp.Top = Convert.ToInt32(txttop.Text);
                tmp.Left = Convert.ToInt32(txtleft.Text);
                tmp.Width = Convert.ToInt32(txtwidth.Text);
                tmp.Height = Convert.ToInt32(txtheight.Text);
                tmp.txtDatasource = new ControlDataSource(cbxTablename.Text, cbxCoumname.Text);
                tmp.IsMust = chbIsmust.Checked;
                tmp.IsPrint = chbIsprInt.Checked;
            }
        }
        //public void UpdateModel()
        //{
        //    if (label != null)
        //    {
        //        if (label.LBName != txtName.Text)
        //        {
        //            label.LBName = txtName.Text;
        //            label.UpdateFlage = true;
        //        }
        //        if (label.LBDefault != txtDefalutValue.Text)
        //        {
        //            label.LBDefault = txtDefalutValue.Text;
        //            label.UpdateFlage = true;
        //        }
        //        if (label.LBTabKey != Convert.ToInt32(txttab.Text))
        //        {
        //            label.LBTabKey = Convert.ToInt32(txttab.Text);
        //            label.UpdateFlage = true;
        //        }
        //        if (label.LBIsBorder != (chbisborestyle.Checked ? 1 : 0))
        //        {
        //            label.LBIsBorder = chbisborestyle.Checked ? 1 : 0;
        //            label.UpdateFlage = true;
        //        }
        //        if (label.LBVisiable != (chbIsvisible.Checked ? 1 : 0))
        //        {
        //            label.LBVisiable = chbIsvisible.Checked ? 1 : 0;
        //            label.UpdateFlage = true;
        //        }
        //        String sbuff = new CommonClass().GetStringByFont(tmp.Font);
        //        if (label.LBFont != sbuff)
        //        {
        //            label.LBFont = sbuff;
        //            label.UpdateFlage = true;

        //        }
        //        sbuff = System.Drawing.ColorTranslator.ToHtml(tmp.ForeColor);
        //        if (label.LBFontColor != sbuff)
        //        {
        //            label.LBFontColor = sbuff;
        //            label.UpdateFlage = true;
        //        }
        //        sbuff = System.Drawing.ColorTranslator.ToHtml(tmp.BackColor);
        //        if (label.LBBackColor != sbuff)
        //        {
        //            label.LBBackColor = sbuff;
        //            label.UpdateFlage = true;
        //        }

        //        int xitem = Convert.ToInt32(txttop.Text);
        //        if (label.LBTop != xitem)
        //        {
        //            label.LBTop = xitem;
        //            label.UpdateFlage = true;
        //        } 
        //        xitem= Convert.ToInt32(txtleft.Text);
        //        if (label.LBLeft != xitem)
        //        {
        //            label.LBLeft = xitem;
        //            label.UpdateFlage = true;
        //        }
        //        xitem = Convert.ToInt32(txtwidth.Text);
        //        if (label.LBWidth != xitem)
        //        {
        //            label.LBWidth = xitem;
        //            label.UpdateFlage = true;
        //        }
        //        xitem = Convert.ToInt32(txtheight.Text);
        //        if (label.LBHeight != xitem)
        //        {
        //            label.LBHeight = xitem;
        //            label.UpdateFlage = true;
        //        }
        //        if (label.LBBandsTabel != cbxTablename.Text)
        //        {
        //            label.LBBandsTabel = cbxTablename.Text;
        //            label.UpdateFlage = true;
        //        }
        //        if (label.LBBandsCoumln != cbxCoumname.Text)
        //        {
        //            label.LBBandsCoumln = cbxCoumname.Text;
        //            label.UpdateFlage = true;
        //        }
        //        if (label.LBIsPrint != (chbIsprInt.Checked ? 1 : 0))
        //        {
        //            label.LBIsPrint = chbIsprInt.Checked ? 1 : 0;
        //            label.UpdateFlage = true;
        //        }               
        //    }
        //}
        #endregion

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                SetPropery();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "软件提示");
            }
        }

        private void LabelProperyForm_Load(object sender, EventArgs e)
        {
            try
            {
                if (tm != null && tmp != null)
                {
                    GetPropery();
                    font = tmp.Font;
                    bgc = tmp.BackColor;
                    frc = tmp.ForeColor;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "软件提示");
            }
        }

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
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "软件提示");
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
                MessageBox.Show(ex.ToString(), "软件提示");
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
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "软件提示");
            }
        }
    }
}

