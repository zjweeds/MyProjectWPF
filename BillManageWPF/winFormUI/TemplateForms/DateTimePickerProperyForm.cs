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
    public partial class DateTimePickerProperyForm : Form
    {
        #region 构造函数
        public DateTimePickerProperyForm()
        {
            InitializeComponent();
        }
        public DateTimePickerProperyForm(TemplateMain fm, MyDateTimePicker tbi)
        {
            InitializeComponent();
            tmp = tbi;
            tm = fm;          
        }
        #endregion 

        #region  页面变量
        public MyDateTimePicker tmp = null;
        //private DateTimePickerInfo dateTimePicker = null;
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
                dtpDefault.Text = tmp.DefaultValue;
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
                chbIsmust.Checked = tmp.IsMust;
                chbIsprInt.Checked = tmp.IsPrint; 
            }
        }

        public void SetPropery()
        {
            if (tmp != null)
            {
                tmp.ControlName = txtName.Text;
                tmp.DefaultValue = dtpDefault.Text;
                tmp.TabIndex = Convert.ToInt32(txttab.Text);
                tmp.Visible = chbIsvisible.Checked;
                tmp.Top = Convert.ToInt32(txttop.Text);
                tmp.Left = Convert.ToInt32(txtleft.Text);
                tmp.Width = Convert.ToInt32(txtwidth.Text);
                tmp.Height = Convert.ToInt32(txtheight.Text);
                tmp.txtDatasource = new ControlDataSource(cbxTablename.Text, cbxCoumname.Text);
                tmp.IsMust = chbIsmust.Checked;
                tmp.IsPrint = chbIsprInt.Checked; ;
            }
        }
        //public void UpdateModel()
        //{
        //    if (dateTimePicker != null)
        //    {
        //        if (dateTimePicker.DTPName != txtName.Text)
        //        {
        //            dateTimePicker.DTPName = txtName.Text;
        //            dateTimePicker.UpdateFlage = true;
        //        }
        //        if (dateTimePicker.DTPDefault != dtpDefault.Text)
        //        {
        //            dateTimePicker.DTPDefault = dtpDefault.Text;
        //            dateTimePicker.UpdateFlage = true;
        //        }
        //        if (dateTimePicker.DTPTabKey != Convert.ToInt32(txttab.Text))
        //        {
        //            dateTimePicker.DTPTabKey = Convert.ToInt32(txttab.Text);
        //            dateTimePicker.UpdateFlage = true;
        //        }
        //        if (dateTimePicker.DTPVisiable != (chbIsvisible.Checked ? 1 : 0))
        //        {
        //            dateTimePicker.DTPVisiable = chbIsvisible.Checked ? 1 : 0;
        //            dateTimePicker.UpdateFlage = true;
        //        }
        //        String sfont = new CommonClass().GetStringByFont(tmp.Font);
        //        if (dateTimePicker.DTPIFont != sfont)
        //        {
        //            dateTimePicker.DTPIFont = sfont;
        //            dateTimePicker.UpdateFlage = true;
        //        }
        //        String sbuff = System.Drawing.ColorTranslator.ToHtml(tmp.ForeColor);
        //        if (dateTimePicker.DTPFontColor != sbuff)
        //        {
        //            dateTimePicker.DTPFontColor = sbuff;
        //            dateTimePicker.UpdateFlage = true;
        //        }
        //        sbuff = System.Drawing.ColorTranslator.ToHtml(tmp.BackColor);
        //        if (dateTimePicker.DTPBackColor != sbuff)
        //        {
        //            dateTimePicker.DTPBackColor = sbuff;
        //            dateTimePicker.UpdateFlage = true;
        //        }

        //        int xitem = Convert.ToInt32(txttop.Text);
        //        if (dateTimePicker.DTPTop != xitem)
        //        {
        //            dateTimePicker.DTPTop = xitem;
        //            dateTimePicker.UpdateFlage = true;
        //        } 
        //        xitem= Convert.ToInt32(txtleft.Text);
        //        if (dateTimePicker.DTPLeft != xitem)
        //        {
        //            dateTimePicker.DTPLeft = xitem;
        //            dateTimePicker.UpdateFlage = true;
        //        }
        //        xitem = Convert.ToInt32(txtwidth.Text);
        //        if (dateTimePicker.DTPWidth != xitem)
        //        {
        //            dateTimePicker.DTPWidth = xitem;
        //            dateTimePicker.UpdateFlage = true;
        //        }
        //        xitem = Convert.ToInt32(txtheight.Text);
        //        if (dateTimePicker.DTPHeight != xitem)
        //        {
        //            dateTimePicker.DTPHeight = xitem;
        //            dateTimePicker.UpdateFlage = true;
        //        }
        //        if (dateTimePicker.DTPBandsTable != cbxTablename.Text)
        //        {
        //            dateTimePicker.DTPBandsTable = cbxTablename.Text;
        //            dateTimePicker.UpdateFlage = true;
        //        }
        //        if (dateTimePicker.DTPBandsCoumln != cbxCoumname.Text)
        //        {
        //            dateTimePicker.DTPBandsCoumln = cbxCoumname.Text;
        //            dateTimePicker.UpdateFlage = true;
        //        }
        //        if (dateTimePicker.DTPIsMust != (chbIsmust.Checked ? 1 : 0))
        //        {
        //            dateTimePicker.DTPIsMust = chbIsmust.Checked ? 1 : 0;
        //            dateTimePicker.UpdateFlage = true;
        //        }
        //        if (dateTimePicker.DTPIsPrint != (chbIsprInt.Checked ? 1 : 0))
        //        {
        //            dateTimePicker.DTPIsPrint = chbIsprInt.Checked ? 1 : 0;
        //            dateTimePicker.UpdateFlage = true;
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

        private void DateTimePickerProperyForm_Load(object sender, EventArgs e)
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

