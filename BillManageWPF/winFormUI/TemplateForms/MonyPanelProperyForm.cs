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
    public partial class MonyPanelProperyForm : Form
    {
        #region 构造函数
        public MonyPanelProperyForm()
        {
            InitializeComponent();
        }
        public MonyPanelProperyForm(TemplateMain fm, MoneyPanel mp)
        {
            InitializeComponent();
            tmp = mp;
            tm = fm;
            font = mp.Font;
            bgc = mp.BackColor;
            frc = mp.ForeColor;
        }
        #endregion
        #region  页面变量
        public MoneyPanel tmp = null;
        public TemplateMain tm;
        public  Font font=null;
        public Color bgc ;
        public Color frc ;
        #endregion
        #region 自定义方法
        /// <summary>
        /// 加载所有单位
        /// </summary>
        /// <param name="cb"></param>
        private void LoadDanWei(ComboBox cb)
        {
            foreach (ComEnum.Danwei item in Enum.GetValues(typeof(ComEnum.Danwei)))
            {
                cb.Items.Add(item.ToString());
            }
        }
        /// <summary>
        /// 获取控件属性
        /// </summary>
        public void GetPropery()
        {
            if (tmp != null)
            {
                txtName.Text = tmp.ControlName;
                txtDefalutValue.Text = tmp.DefaultValue;
                chbisborestyle.Checked = tmp.BorderStyle == BorderStyle.None ? false : true;
                chbIsvisible.Checked = tmp.Visible;
                chbIsmust.Checked = tmp.IsMust == 0 ? false : true;
                chbIsprint.Checked = tmp.IsPrint == 0 ? false : true;
                txttab.Text = tmp.TabIndex.ToString();
                txtfont.Text = tmp.Font.ToString();
                txtForeColor.Text = tmp.ForeColor.ToString();
                txtBackColor.Text = tmp.BackColor.ToString();
                txttop.Text = tmp.Top.ToString();
                txtleft.Text = tmp.Left.ToString();
                txtwidth.Text = tmp.Width.ToString();
                txtheight.Text = tmp.Height.ToString();
                cbbHeight.SelectedIndex = tmp.Hight.GetHashCode();
                cbbLow.SelectedIndex = tmp.Low.GetHashCode();
            }
        }

        /// <summary>
        /// 设置控件属性
        /// </summary>
        public void SetPropery()
        {
            if (tmp != null)
            {
                tmp.ControlName = txtName.Text;
                tmp.DefaultValue = txtDefalutValue.Text;
                tmp.BorderStyle = chbisborestyle.Checked ? BorderStyle.None : BorderStyle.FixedSingle;
                tmp.Visible = chbIsvisible.Checked;
                tmp.IsMust = chbIsmust.Checked ? 1 : 0;
                tmp.IsPrint = chbIsprint.Checked ? 1 : 0;
                tmp.TabIndex = Convert.ToInt32(txttab.Text);
                tmp.Top = Convert.ToInt32(txttop.Text);
                tmp.Left = Convert.ToInt32(txtleft.Text);
                tmp.Width = Convert.ToInt32(txtwidth.Text);
                tmp.Height = Convert.ToInt32(txtheight.Text);
                tmp.Hight = cbbHeight.SelectedIndex;
                tmp.Low = cbbLow.SelectedIndex;
                tmp.MoneyPanel_Paint();
            }
        }

        /// <summary>
        /// 更新对应实体信息
        /// </summary>
        /// <param name="cm"></param>
        /// <param name="mpem"></param>
        public void UpdateModel(ControlModel cm,MoneyPanelExtendModel mpem)
        {
            if (cm != null)
            {
                if (cm.CTIName != txtName.Text)
                {
                    cm.CTIName = txtName.Text;
                }
                if (cm.CTIDefault != txtDefalutValue.Text)
                {
                    cm.CTIDefault = txtDefalutValue.Text;
                }
                String sfont = tmp.Font.ToString();
                if (cm.CTIFont != sfont)
                {
                    cm.CTIFont = sfont;
                    cm.updateFlage = true;
                }
                String sbuff = System.Drawing.ColorTranslator.ToHtml(tmp.ForeColor);
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
                if( cm.CTIIsBorder != (chbisborestyle.Checked ? 1 : 0))
                {
                    cm.CTIIsBorder = chbisborestyle.Checked ? 1 : 0;
                    cm.updateFlage = true;
                }
                if ( cm.CTIVisiable != (chbIsvisible.Checked ? 1 : 0))
                {
                    cm.CTIVisiable = chbIsvisible.Checked ? 1 : 0;
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
                cm.CTITabKey = Convert.ToInt32(txttab.Text);
                int xitem = Convert.ToInt32(txttop.Text);
                if (cm.CTITop != xitem)
                {
                    cm.CTITop = xitem;
                    cm.updateFlage = true;
                }
                xitem = Convert.ToInt32(txtleft.Text);
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
                if (cm.CTITabKey != Convert.ToInt32(txttab.Text))
                {
                    cm.CTITabKey = Convert.ToInt32(txttab.Text);
                    cm.updateFlage = true;
                }
                if (mpem != null)
                {
                    if (mpem.MCLowUnit != cbbLow.SelectedIndex)
                    {
                        mpem.MCLowUnit = cbbLow.SelectedIndex;
                        mpem.updateFlage = true;
                    }
                    if (mpem.MCHighUnit != cbbHeight.SelectedIndex)
                    {
                        mpem.MCHighUnit = cbbHeight.SelectedIndex;
                        mpem.updateFlage = true;
                    }
                }
            }
        }
        #endregion 
        #region 窗体事件
        private void MonyPanelProperyForm_Load(object sender, EventArgs e)
        {
            LoadDanWei(cbbHeight);//最高位加载
            LoadDanWei(cbbLow);//最低位加载
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
            if(cd.ShowDialog()!=DialogResult.Cancel)
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

        /// <summary>
        /// 设置属性
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            SetPropery();
            ControlModel cm = new ControlModel();
            MoneyPanelExtendModel mpem = new MoneyPanelExtendModel();
            if (tmp.ControlID != 0)
            {
                cm = tm.cmlist.Find((delegate(ControlModel p) { return p.CTIID == tmp.ControlID; }));//返回符合条件的第一个元素)
                mpem = tm.mpemList.Find((delegate(MoneyPanelExtendModel p) { return p.MCCIID == tmp.ControlID; }));
            }
            else
            {
                cm = tm.cmlist.Find((delegate(ControlModel p) { return p.NewNumber == tmp.NewNumber; }));//返回符合条件的第一个元素)
                mpem = tm.mpemList.Find((delegate(MoneyPanelExtendModel p) { return p.MCCIID == cm.CTIID; }));
            }
            UpdateModel(cm, mpem);
        }
        
        /// <summary>
        /// 单位选择是保证最高位大于等于最低位（验证）
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cbbHeight_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbbHeight.SelectedIndex < cbbLow.SelectedIndex)
            {
                cbbHeight.SelectedIndex = cbbLow.SelectedIndex;
                MessageBox.Show("最高位应大于最低位");
            }
        }
        #endregion
    }
}
