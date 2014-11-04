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
        }
        #endregion
        #region  页面变量
        public MoneyPanel tmp = null;
       // private MoneyPanelInfo moneypanel = null;
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
        private void LoadBanding(ComboBox cb)
        {
            foreach (Control cn in tm.DesignContext.board.Controls)
            {
                if (cn.GetType() == typeof(MyTextBox))
                {
                    comboxItem ci = null;
                    MyTextBox txb = cn as MyTextBox;
                    if (txb.ControlID == 0)
                    {
                        ci = new comboxItem(txb.ControlName, txb.NewNumber, 0);
                    }
                    else
                    {
                        ci = new comboxItem(txb.ControlName, txb.ControlID, 1);
                    }
                    cb.Items.Add(ci);
                    cb.DisplayMember = ci.name;
                }                
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
                chbIsShowUnit.Checked = tmp.IsShowUnit;
                chbIsvisible.Checked = tmp.Visible;
                chbIsmust.Checked = tmp.IsMust ? false : true;
                chbIsprInt.Checked = tmp.IsPrint  ? false : true;
                txttab.Text = tmp.TabIndex.ToString();
                txtfont.Text = tmp.Font.ToString();
                txtForeColor.Text = tmp.ForeColor.ToString();
                txtBackColor.Text = tmp.BackColor.ToString();
                txttop.Text = tmp.Top.ToString();
                txtleft.Text = tmp.Left.ToString();
                txtwidth.Text = tmp.Width.ToString();
                txtheight.Text = tmp.Height.ToString();
                txtRows.Text = tmp.RowCount.ToString();
                cbbHeight.SelectedIndex = tmp.Hight.GetHashCode();
                cbbLow.SelectedIndex = tmp.Low.GetHashCode();
                cbbBandings.SelectedValue = tmp.BindsID;
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
                tmp.IsShowUnit = chbIsShowUnit.Checked;
                tmp.Visible = chbIsvisible.Checked;
                tmp.IsMust = chbIsmust.Checked ;
                tmp.IsPrint = chbIsprInt.Checked;
                tmp.TabIndex = Convert.ToInt32(txttab.Text);
                tmp.Top = Convert.ToInt32(txttop.Text);
                tmp.Left = Convert.ToInt32(txtleft.Text);
                tmp.Width = Convert.ToInt32(txtwidth.Text);
                tmp.Height = Convert.ToInt32(txtheight.Text);
                tmp.Hight = cbbHeight.SelectedIndex;
                tmp.RowCount = Convert.ToInt32(txtRows.Text);
                tmp.Low = cbbLow.SelectedIndex;
                if ((cbbBandings.SelectedItem as comboxItem).type == 0)
                {
                    tmp.BindsID = tm.AddTextControlByNewNumber((cbbBandings.SelectedItem as comboxItem).ID);
                }
                else
                {
                    tmp.BindsID = (cbbBandings.SelectedItem as comboxItem).ID;
                }
                tmp.MoneyPanel_Paint();
            }
        }

        /// <summary>
        /// 更新对应实体信息
        /// </summary>
        /// <param name="moneypanel"></param>
        /// <param name="moneypanel"></param>
        //public void UpdateModel()
        //{
        //    if (moneypanel != null)
        //    {
        //        if (moneypanel.MPName != txtName.Text)
        //        {
        //            moneypanel.MPName = txtName.Text;
        //        }
        //        if (moneypanel.MPDefault != txtDefalutValue.Text)
        //        {
        //            moneypanel.MPDefault = txtDefalutValue.Text;
        //        }
        //        String sfont = new CommonClass().GetStringByFont(tmp.Font);
        //        if (moneypanel.MPFont != sfont)
        //        {
        //            moneypanel.MPFont = sfont;
        //            moneypanel.UpdateFlage = true;
        //        }
        //        String sbuff = System.Drawing.ColorTranslator.ToHtml(tmp.ForeColor);
        //        if (moneypanel.MPFontColor != sbuff)
        //        {
        //            moneypanel.MPFontColor = sbuff;
        //            moneypanel.UpdateFlage = true;
        //        }
        //        sbuff = System.Drawing.ColorTranslator.ToHtml(tmp.BackColor);
        //        if (moneypanel.MPBackColor != sbuff)
        //        {
        //            moneypanel.MPBackColor = sbuff;
        //            moneypanel.UpdateFlage = true;
        //        }
        //        if (moneypanel.MPIsBorder != (chbisborestyle.Checked ? 1 : 0))
        //        {
        //            moneypanel.MPIsBorder = chbisborestyle.Checked ? 1 : 0;
        //            moneypanel.UpdateFlage = true;
        //        }
        //        if (moneypanel.MPVisiable != (chbIsvisible.Checked ? 1 : 0))
        //        {
        //            moneypanel.MPVisiable = chbIsvisible.Checked ? 1 : 0;
        //            moneypanel.UpdateFlage = true;
        //        }
        //        if (moneypanel.MPIsMust != (chbIsmust.Checked ? 1 : 0))
        //        {
        //            moneypanel.MPIsMust = chbIsmust.Checked ? 1 : 0;
        //            moneypanel.UpdateFlage = true;
        //        }
        //        if (moneypanel.MPIsPrint != (chbIsprInt.Checked ? 1 : 0))
        //        {
        //            moneypanel.MPIsPrint = chbIsprInt.Checked ? 1 : 0;
        //            moneypanel.UpdateFlage = true;
        //        }
        //        moneypanel.MPTabKey = Convert.ToInt32(txttab.Text);
        //        int xitem = Convert.ToInt32(txttop.Text);
        //        if (moneypanel.MPTop != xitem)
        //        {
        //            moneypanel.MPTop = xitem;
        //            moneypanel.UpdateFlage = true;
        //        }
        //        xitem = Convert.ToInt32(txtleft.Text);
        //        if (moneypanel.MPLeft != xitem)
        //        {
        //            moneypanel.MPLeft = xitem;
        //            moneypanel.UpdateFlage = true;
        //        }
        //        xitem = Convert.ToInt32(txtwidth.Text);
        //        if (moneypanel.MPWidth != xitem)
        //        {
        //            moneypanel.MPWidth = xitem;
        //            moneypanel.UpdateFlage = true;
        //        }
        //        xitem = Convert.ToInt32(txtheight.Text);
        //        if (moneypanel.MPHeight != xitem)
        //        {
        //            moneypanel.MPHeight = xitem;
        //            moneypanel.UpdateFlage = true;
        //        }
        //        if (moneypanel.MPTabKey != Convert.ToInt32(txttab.Text))
        //        {
        //            moneypanel.MPTabKey = Convert.ToInt32(txttab.Text);
        //            moneypanel.UpdateFlage = true;
        //        }
        //        if (moneypanel.MPLowUnit != cbbLow.SelectedIndex)
        //        {
        //            moneypanel.MPLowUnit = cbbLow.SelectedIndex;
        //            moneypanel.UpdateFlage = true;
        //        }
        //        if (moneypanel.MPHighUnit != cbbHeight.SelectedIndex)
        //        {
        //            moneypanel.MPHighUnit = cbbHeight.SelectedIndex;
        //            moneypanel.UpdateFlage = true;
        //        }
        //    }
        //}
        #endregion 
        #region 窗体事件
        private void MonyPanelProperyForm_Load(object sender, EventArgs e)
        {
            LoadDanWei(cbbHeight);//最高位加载
            LoadDanWei(cbbLow);//最低位加载
            LoadBanding(cbbBandings);//加载绑定源
            if (tm != null && tmp != null)
            {
                GetPropery();
                font = tmp.Font;
                bgc = tmp.BackColor;
                frc = tmp.ForeColor;
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
        
        //只能输入数字
        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(Char.IsNumber(e.KeyChar)) && e.KeyChar != (char)13 && e.KeyChar != (char)8)
            {
                e.Handled = true;
            } 
        }
    }
    public class comboxItem
    {
        /// <summary>
        /// 显示的名称
        /// </summary>
        public String name
        {
            get;
            set;
        }

        /// <summary>
        /// 对应的控件ID
        /// </summary>
        public int ID
        {
            get;
            set;
        }

        /// <summary>
        /// 类型
        /// </summary>
        public int type//0:新增；1：修改
        {
            get;
            set;
        }
        public comboxItem(String s, int n,int t)
        {
            name = s;
            ID = n;
            type = t;
        }
    }
}
