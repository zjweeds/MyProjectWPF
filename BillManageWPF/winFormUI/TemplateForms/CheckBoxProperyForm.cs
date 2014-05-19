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

namespace BillManageWPF.Forms
{
    public partial class CheckBoxProperyForm : Form
    {
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

        #region  页面变量
        public MyCheckBox tmp = null;
        public TemplateMain tm = null;
//public CheckBoxInfo checkbox = null;
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

        //public void UpdateModel()
        //{
        //    if (checkbox != null)
        //    {
        //        if (checkbox.CHBName != txtName.Text)
        //        {
        //            checkbox.CHBName = txtName.Text;
        //            checkbox.UpdateFlage = true;
        //        }
        //        if (checkbox.CHBDefault != (chbDefault.Checked ? "true" : "false"))
        //        {
        //            checkbox.CHBDefault = chbDefault.Checked ? "true" : "false";
        //            checkbox.UpdateFlage = true;
        //        }
        //        if (checkbox.CHBTabKey != Convert.ToInt32(txttab.Text))
        //        {
        //            checkbox.CHBTabKey = Convert.ToInt32(txttab.Text);
        //            checkbox.UpdateFlage = true;
        //        }
        //        if (checkbox.CHBVisiable != (chbIsvisible.Checked ? 1 : 0))
        //        {
        //            checkbox.CHBVisiable = chbIsvisible.Checked ? 1 : 0;
        //            checkbox.UpdateFlage = true;
        //        }
        //        String sfont = new CommonClass().GetStringByFont(tmp.Font);
        //        if (checkbox.CHBFont != sfont)
        //        {
        //            checkbox.CHBFont = sfont;
        //            checkbox.UpdateFlage = true;
        //        }
        //        String sbuff = System.Drawing.ColorTranslator.ToHtml(tmp.ForeColor);
        //        if (checkbox.CHBFontColor != sbuff)
        //        {
        //            checkbox.CHBFontColor = sbuff;
        //            checkbox.UpdateFlage = true;
        //        }
        //        sbuff = System.Drawing.ColorTranslator.ToHtml(tmp.BackColor);
        //        if (checkbox.CHBBackColor != sbuff)
        //        {
        //            checkbox.CHBBackColor = sbuff;
        //            checkbox.UpdateFlage = true;
        //        }

        //        int xitem = Convert.ToInt32(txttop.Text);
        //        if (checkbox.CHBTop != xitem)
        //        {
        //            checkbox.CHBTop = xitem;
        //            checkbox.UpdateFlage = true;
        //        }
        //        xitem = Convert.ToInt32(txtleft.Text);
        //        if (checkbox.CHBLeft != xitem)
        //        {
        //            checkbox.CHBLeft = xitem;
        //            checkbox.UpdateFlage = true;
        //        }
        //        xitem = Convert.ToInt32(txtwidth.Text);
        //        if (checkbox.CHBWidth != xitem)
        //        {
        //            checkbox.CHBWidth = xitem;
        //            checkbox.UpdateFlage = true;
        //        }
        //        xitem = Convert.ToInt32(txtheight.Text);
        //        if (checkbox.CHBHeight != xitem)
        //        {
        //            checkbox.CHBHeight = xitem;
        //            checkbox.UpdateFlage = true;
        //        }
        //        if (checkbox.CHBBandsTabel != cbxTablename.Text)
        //        {
        //            checkbox.CHBBandsTabel = cbxTablename.Text;
        //            checkbox.UpdateFlage = true;
        //        }
        //        if (checkbox.CHBBandsCoumln != cbxCoumname.Text)
        //        {
        //            checkbox.CHBBandsCoumln = cbxCoumname.Text;
        //            checkbox.UpdateFlage = true;
        //        }
        //        if (checkbox.CHBIsMust != (chbIsmust.Checked ? 1 : 0))
        //        {
        //            checkbox.CHBIsMust = chbIsmust.Checked ? 1 : 0;
        //            checkbox.UpdateFlage = true;
        //        }
        //        if (checkbox.CHBIsPrint != (chbIsprInt.Checked ? 1 : 0))
        //        {
        //            checkbox.CHBIsPrint = chbIsprInt.Checked ? 1 : 0;
        //            checkbox.UpdateFlage = true;
        //        }               
        //    }
        //}

        #endregion
        /// <summary>
        /// 设置字体
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSetFont_Click(object sender, EventArgs e)
        {
            //fd.ShowDialog();
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
            //cd.ShowDialog();
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
            //cd.ShowDialog();
            if (cd.ShowDialog() != DialogResult.Cancel)
            {
                txtBackColor.Text = cd.Color.ToString();
                bgc = cd.Color;
                tmp.BackColor = bgc;
            }
        }

        private void CheckBoxProperyForm_Load(object sender, EventArgs e)
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
        private void button1_Click(object sender, EventArgs e)
        {
            SetPropery();           
           // UpdateModel();
        }
    }
}
