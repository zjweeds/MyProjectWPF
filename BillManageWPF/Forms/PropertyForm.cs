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

namespace BillManageMain.Forms
{
    public partial class PropertyForm : Form
    {
        #region 变量初始化
        public String type = String.Empty;//保存传入的控件类型 
        public CTextBox ctxt = null;
        public CCheckBox chb = null;
        public CComboBox ccb = null;
        public CLabel clb = null;
        public CDateTimePicker cdtp = null;
        public int ControlId;
        public String Type;
        ControlModer tm = null;
        BillTemplateService btmService = new BillTemplateService();
        ControlService ctmService = new ControlService();
        #endregion

        #region 重载构造函数
        public PropertyForm()
        {
            InitializeComponent();
        }
        public PropertyForm(int code)
        {
            InitializeComponent();
            ControlId = code;
            Type = "ByID";
        }
        
        public PropertyForm(CTextBox txt)
        {
            InitializeComponent();
            ctxt = txt;
            Type = "ByControls";
        }
        public PropertyForm(CCheckBox txt)
        {
            InitializeComponent();
            chb = txt;
            Type = "ByControls";
        }
        public PropertyForm(CLabel txt)
        {
            InitializeComponent();
            clb = txt;
            Type = "ByControls";
        }
        public PropertyForm(CComboBox txt)
        {
            InitializeComponent();
            ccb = txt;
            Type = "ByControls";
        }
        public PropertyForm(CDateTimePicker txt)
        {
            InitializeComponent();
            cdtp = txt;
            Type = "ByControls";
        }
        #endregion

        private void textBox2_MouseHover(object sender, EventArgs e)
        {
            txtMark.Text = "控件名称";
        }

        private void txtDefalutValue_MouseHover(object sender, EventArgs e)
        {
            txtMark.Text = "控件默认值";
        }

        private void PropertyForm_Load(object sender, EventArgs e)
        {
            if(Type =="ByID")
            {
                //tm = ctmService.GetControlModerByID(ControlId);
                //txtName.Text = tm.CTIName;
                //txtDefalutValue.Text = tm.CTIDefault;
               

             }
        }
    }
}
