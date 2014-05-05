using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Controllers.MyControls.TemplateContorl;
using Controllers.Enum;

namespace BillManageWPF.Forms
{
    public partial class MonyPanelProperyForm : Form
    {
        public MonyPanelProperyForm()
        {
            InitializeComponent();
        }
        public MoneyPanel tmp = null;
        public TemplateMain tm;
        public  Font font=null;
        public Color bgc ;
        public Color frc ;
        public MonyPanelProperyForm(TemplateMain fm,MoneyPanel mp)
        {
            InitializeComponent();
            tmp = mp;
            tm = fm;
            font=mp.Font;
            bgc = mp.BackColor;
            frc = mp.ForeColor;
        }

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
        }
        public void SetPropery()
        {
            if (tmp != null)
            {
                tmp.ControlName=txtName.Text;
                tmp.DefaultValue=txtDefalutValue.Text;
                tmp.BorderStyle =chbisborestyle.Checked? BorderStyle.None : BorderStyle.FixedSingle;
                tmp.Visible=chbIsvisible.Checked;
                tmp.IsMust=chbIsmust.Checked? 1 : 0;
                tmp.IsPrint=chbIsprint.Checked? 1 : 0;
                tmp.TabIndex=Convert.ToInt32(txttab.Text);
                tmp.Top = Convert.ToInt32(txttop.Text);
                tmp.Left = Convert.ToInt32(txtleft.Text);
                tmp.Width = Convert.ToInt32(txtwidth.Text);
                tmp.Height = Convert.ToInt32(txtheight.Text);
                tmp.Hight = (ComEnum.Danwei)cbbHeight.SelectedIndex;
                tmp.Low = (ComEnum.Danwei)cbbLow.SelectedIndex;
                tmp.MoneyPanel_Paint();
            }
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
    }
}
