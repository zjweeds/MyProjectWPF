using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Controllers.MyControls;
using Controllers.Business;
using Controllers.Common;
using Controllers.Moders.TableModers;
using Controllers.MyControls.TemplateContorl;

namespace BillManageWPF.Forms
{
    public partial class PropertyForm : Form
    {
        #region 变量初始化
        public String type = String.Empty;//保存传入的控件类型 
        public MyTextBox ctxt = null;
        public MyCheckBox chb = null;
        public MyComboBox cbb = null;
        public MyLabel clb = null;
        public MyDateTimePicker cdtp = null;
        public MoneyPanel cmp = null;
        public int ControlId;
        public Control control = null;
        public String Type;
        public TemplateMain tm = null;
        ControlModer cm = null;
        BillTemplateService btmService = new BillTemplateService();
        ControlService ctmService = new ControlService();
        #endregion

        #region 重载构造函数
        public PropertyForm()
        {
            InitializeComponent();
        }
        public PropertyForm(TemplateMain mtm, Control mtxt)
        {
            InitializeComponent();
            control = mtxt;
            GetControlsType(mtxt);
            this.tm = mtm;
        }
        #endregion
        #region
        public PropertyForm(TemplateMain mtm,MyTextBox mtxt)
        {
            InitializeComponent();
            this.ctxt = mtxt;
            this.tm = mtm;
        }
        public PropertyForm(TemplateMain mtm, MyCheckBox mtxt)
        {
            InitializeComponent();
            this.chb = mtxt;
            this.tm = mtm;
        }
        public PropertyForm(TemplateMain mtm, MyComboBox mtxt)
        {
            InitializeComponent();
            this.cbb = mtxt;
            this.tm = mtm;
        }
        public PropertyForm(TemplateMain mtm, MyLabel mtxt)
        {
            InitializeComponent();
            this.clb = mtxt;
            this.tm = mtm;
        }
        public PropertyForm(TemplateMain mtm, MyDateTimePicker mtxt)
        {
            InitializeComponent();
            this.cdtp = mtxt;
            this.tm = mtm;
        }
        public PropertyForm(TemplateMain mtm, MoneyPanel mtxt)
        {
            InitializeComponent();
            this.cmp = mtxt;
            this.tm = mtm;
        }
        public PropertyForm(int code)
        {
            InitializeComponent();
            ControlId = code;
            Type = "ByID";
        }
#endregion     


        /// <summary>
        /// 根据传入的控件，获取控件类别
        /// </summary>
        /// <param name="sc"></param>
        public void GetControlsType(Control sc)
        {
            if (sc != null)
            {
                // MessageBox.Show(contrls.GetType().ToString());
                switch (sc.GetType().ToString())
                {
                    case "Controllers.MyControls.TemplateContorl.MyTextBox":
                        {
                            ctxt = sc as MyTextBox;
                            break;
                        }
                    case "Controllers.MyControls.TemplateContorl.MyComboBox":
                        {
                            cbb = sc as MyComboBox;
                            break;
                        }
                    case "Controllers.MyControls.TemplateContorl.MyCheckBox":
                        {
                            chb = sc as MyCheckBox;
                            break;
                        }
                    case "Controllers.MyControls.TemplateContorl.MyDateTimePicker":
                        {
                            cdtp = sc as MyDateTimePicker;
                            break;
                        }
                    case "Controllers.MyControls.TemplateContorl.MyLabel":
                        {
                            clb = sc as MyLabel;
                            break;
                        }
                    case "Controllers.MyControls.TemplateContorl.MyMoneyPanel":
                        {
                            cmp = sc as MoneyPanel;
                            break;
                        }
                }
            }
        }
 

        private void textBox2_MouseHover(object sender, EventArgs e)
        {
            txtMark.Text = "控件名称";
        }

        private void txtDefalutValue_MouseHover(object sender, EventArgs e)
        {
            txtMark.Text = "控件默认值";
        }
       public void GetNomulProperyInfo(Control sc)
       {
           txttab.Text = sc.TabIndex.ToString();
           txtfont.Text = sc.Font.ToString();
           txtForeColor.Text = sc.ForeColor.ToString();
           txtBackColor.Text = sc.BackColor.ToString();
           txttop.Text = sc.Top.ToString();
           txtleft.Text = sc.Left.ToString();
           txtwidth.Text = sc.Width.ToString();
           txtheight.Text = sc.Height.ToString();
       }
        private void PropertyForm_Load(object sender, EventArgs e)
        {
            GetNomulProperyInfo(control);
            if (ctxt != null)
            {
 
            }
        }
    }
}
