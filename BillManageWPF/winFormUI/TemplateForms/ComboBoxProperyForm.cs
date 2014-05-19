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
    public partial class ComboBoxProperyForm : Form
    {
        #region 构造函数
        public ComboBoxProperyForm()
        {
            InitializeComponent();
        }
        public ComboBoxProperyForm(TemplateMain fm, MyComboBox tb)
        {
            InitializeComponent();
            tmp = tb;
            tm = fm;          
        }
        #endregion 

        #region  页面变量
        public MyComboBox tmp = null;
        public TemplateMain tm = null;
        //private ComboBoxInfo combobox = null;
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
                cbbMarktype.SelectedIndex = tmp.MarkType;
                chbIsmust.Checked = tmp.IsMust ? false : true;
                chbIsprInt.Checked = tmp.IsPrint  ? false : true;  
            }
        }

        public void SetPropery()
        {
            if (tmp != null)
            {
                tmp.ControlName = txtName.Text;
                tmp.DefaultValue = txtDefalutValue.Text;
                tmp.TabIndex = Convert.ToInt32(txttab.Text);
                tmp.Visible = chbIsvisible.Checked;
                tmp.Top = Convert.ToInt32(txttop.Text);
                tmp.Left = Convert.ToInt32(txtleft.Text);
                tmp.Width = Convert.ToInt32(txtwidth.Text);
                tmp.Height = Convert.ToInt32(txtheight.Text);
                tmp.txtDatasource = new ControlDataSource(cbxTablename.Text, cbxCoumname.Text);
                tmp.IsMust = chbIsmust.Checked ;
                tmp.IsPrint = chbIsprInt.Checked ;
                tmp.MarkType = cbbMarktype.SelectedIndex;
            }
        }

        //public void UpdateModel()
        //{
        //    if (combobox != null)
        //    {
        //        if (combobox.CBBName != txtName.Text)
        //        {
        //            combobox.CBBName = txtName.Text;
        //            combobox.UpdateFlage = true;
        //        }
        //        if (combobox.CBBDefault != txtDefalutValue.Text)
        //        {
        //            combobox.CBBDefault = txtDefalutValue.Text;
        //            combobox.UpdateFlage = true;
        //        }
        //        if (combobox.CBBTabKey != Convert.ToInt32(txttab.Text))
        //        {
        //            combobox.CBBTabKey = Convert.ToInt32(txttab.Text);
        //            combobox.UpdateFlage = true;
        //        }
        //        if (combobox.CBBVisiable != (chbIsvisible.Checked ? 1 : 0))
        //        {
        //            combobox.CBBVisiable = chbIsvisible.Checked ? 1 : 0;
        //            combobox.UpdateFlage = true;
        //        }
        //        String sbuff = new CommonClass().GetStringByFont(tmp.Font);
        //        if (combobox.CBBFont != sbuff)
        //        {
        //            combobox.CBBFont = sbuff;
        //            combobox.UpdateFlage = true;

        //        }
        //        sbuff = System.Drawing.ColorTranslator.ToHtml(tmp.ForeColor);
        //        if (combobox.CBBFontColor != sbuff)
        //        {
        //            combobox.CBBFontColor = sbuff;
        //            combobox.UpdateFlage = true;
        //        }
        //        sbuff = System.Drawing.ColorTranslator.ToHtml(tmp.BackColor);
        //        if (combobox.CBBBackColor != sbuff)
        //        {
        //            combobox.CBBBackColor = sbuff;
        //            combobox.UpdateFlage = true;
        //        }

        //        int xitem = Convert.ToInt32(txttop.Text);
        //        if (combobox.CBBTop != xitem)
        //        {
        //            combobox.CBBTop = xitem;
        //            combobox.UpdateFlage = true;
        //        } 
        //        xitem= Convert.ToInt32(txtleft.Text);
        //        if (combobox.CBBILeft != xitem)
        //        {
        //            combobox.CBBILeft = xitem;
        //            combobox.UpdateFlage = true;
        //        }
        //        xitem = Convert.ToInt32(txtwidth.Text);
        //        if (combobox.CBBWidth != xitem)
        //        {
        //            combobox.CBBWidth = xitem;
        //            combobox.UpdateFlage = true;
        //        }
        //        xitem = Convert.ToInt32(txtheight.Text);
        //        if (combobox.CBBHeight != xitem)
        //        {
        //            combobox.CBBHeight = xitem;
        //            combobox.UpdateFlage = true;
        //        }
        //        if (combobox.CBBBandsTabel != cbxTablename.Text)
        //        {
        //            combobox.CBBBandsTabel = cbxTablename.Text;
        //            combobox.UpdateFlage = true;
        //        }
        //        if (combobox.CBBBandsCoumln != cbxCoumname.Text)
        //        {
        //            combobox.CBBBandsCoumln = cbxCoumname.Text;
        //            combobox.UpdateFlage = true;
        //        }
        //        if (combobox.CBBIsMust != (chbIsmust.Checked ? 1 : 0))
        //        {
        //            combobox.CBBIsMust = chbIsmust.Checked ? 1 : 0;
        //            combobox.UpdateFlage = true;
        //        }
        //        if (combobox.CBBIsPrint != (chbIsprInt.Checked ? 1 : 0))
        //        {
        //            combobox.CBBIsPrint = chbIsprInt.Checked ? 1 : 0;
        //            combobox.UpdateFlage = true;
        //        }
        //    }
        //}
        #endregion
        private void button1_Click(object sender, EventArgs e)
        {
            SetPropery();
            //UpdateModel();
        }

        private void ComboBoxProperyForm_Load(object sender, EventArgs e)
        {
            if (tm != null && tmp != null)
            {
                font = tmp.Font;
                bgc = tmp.BackColor;
                frc = tmp.ForeColor;
                //combobox = tm.cbbList[tmp.NewNumber] as ComboBoxInfo;
                GetPropery();
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
    }
}
