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
            font = tb.Font;
            bgc = tb.BackColor;
            frc = tb.ForeColor;
        }
        #endregion 

        #region  页面变量
        public MyComboBox tmp = null;
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
                chbIsmust.Checked = tmp.IsMust == 0 ? false : true;
                chbIsprint.Checked = tmp.IsPrint == 0 ? false : true;  
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
                tmp.IsMust = chbIsmust.Checked ? 1 : 0;
                tmp.IsPrint = chbIsprint.Checked ? 1 : 0;
            }
        }
        public void UpdateModel(ControlModel cm)
        {
            if (cm != null)
            {
                if (cm.CTIName != txtName.Text)
                {
                    cm.CTIName = txtName.Text;
                    cm.updateFlage = true;
                }
                if (cm.CTIDefault != txtDefalutValue.Text)
                {
                    cm.CTIDefault = txtDefalutValue.Text;
                    cm.updateFlage = true;
                }
                if (cm.CTITabKey != Convert.ToInt32(txttab.Text))
                {
                    cm.CTITabKey = Convert.ToInt32(txttab.Text);
                    cm.updateFlage = true;
                }
                if (cm.CTIVisiable != (chbIsvisible.Checked ? 1 : 0))
                {
                    cm.CTIVisiable = chbIsvisible.Checked ? 1 : 0;
                    cm.updateFlage = true;
                }
                String sbuff = tmp.Font.ToString();
                if (cm.CTIFont != sbuff)
                {
                    cm.CTIFont = sbuff;
                    cm.updateFlage = true;

                }
                sbuff = System.Drawing.ColorTranslator.ToHtml(tmp.ForeColor);
                if (cm.CTIFontColor != sbuff)
                {
                    cm.CTIFontColor = sbuff;
                    cm.updateFlage = true;
                }
                sbuff = System.Drawing.ColorTranslator.ToHtml(tmp.BackColor);
                if (cm.CTIBackColor != sbuff)
                {
                    cm.CTIBackColor = sbuff;
                    cm.updateFlage = true;
                }

                int xitem = Convert.ToInt32(txttop.Text);
                if (cm.CTITop != xitem)
                {
                    cm.CTITop = xitem;
                    cm.updateFlage = true;
                } 
                xitem= Convert.ToInt32(txtleft.Text);
                if (cm.CTILeft != xitem)
                {
                    cm.CTILeft = xitem;
                    cm.updateFlage = true;
                }
                xitem = Convert.ToInt32(txtwidth.Text);
                if (cm.CTIWidth != xitem)
                {
                    cm.CTIWidth = xitem;
                    cm.updateFlage = true;
                }
                xitem = Convert.ToInt32(txtheight.Text);
                if (cm.CTIHeight != xitem)
                {
                    cm.CTIHeight = xitem;
                    cm.updateFlage = true;
                }
                if (cm.CTIBandsTabel != cbxTablename.Text)
                {
                    cm.CTIBandsTabel = cbxTablename.Text;
                    cm.updateFlage = true;
                }
                if (cm.CTIBandsCoumln != cbxCoumname.Text)
                {
                    cm.CTIBandsCoumln = cbxCoumname.Text;
                    cm.updateFlage = true;
                }
                if (cm.CTIIsMust != (chbIsmust.Checked ? 1 : 0))
                {
                    cm.CTIIsMust = chbIsmust.Checked ? 1 : 0;
                    cm.updateFlage = true;
                }
                if (cm.CTIIsPrint != (chbIsprint.Checked ? 1 : 0))
                {
                    cm.CTIIsPrint = chbIsprint.Checked ? 1 : 0;
                    cm.updateFlage = true;
                }
            }
        }
        #endregion
        private void button1_Click(object sender, EventArgs e)
        {
            SetPropery();
            ControlModel cm = new ControlModel();
            if (tmp.ControlID != 0)
            {
                cm = tm.cmlist.Find((delegate(ControlModel p) { return p.CTIID == tmp.ControlID; }));//返回符合条件的第一个元素)
            }
            else
            {
                cm = tm.cmlist.Find((delegate(ControlModel p) { return p.NewNumber == tmp.NewNumber; }));//返回符合条件的第一个元素)
            }
            UpdateModel(cm);
        }

        private void ComboBoxProperyForm_Load(object sender, EventArgs e)
        {
            GetPropery();
        }

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
    }
}
