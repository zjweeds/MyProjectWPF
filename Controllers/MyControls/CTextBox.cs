using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Controllers.Business;
using Controllers.Common;

namespace Controllers.MyControls
{

    //自定义控件CTextBox扩展自TextBox
    public partial class CTextBox : TextBox
    {
        bool isMoving = false;//定义一个bool型变量，表示鼠标按下标记
        Point offset;//声明一个Point类型引用，表示光标位置
        int intWidth;//定义一个整形变量，表示控件的宽度
        int intHeight;
       
        //控件的构造器
        public CTextBox()
        {
            InitializeComponent();
            this.Multiline = true;

        }
        public ComboBox cbbItem
        {
            get;
            set;
        }
        private String m_IsFlag;
        //定义一个属性，用于表示当前控件是否为单据编号控件
        public String IsFlag
        {
            get
            { return m_IsFlag; }
            set
            { m_IsFlag = value; }
        }
        private String m_IsUserFunction;
        //定义一个属性，用于表示当前控件是否使用数字大小写转换函数
        public String IsUserFunction
        {
            get
            { return m_IsUserFunction; }
            set
            { m_IsUserFunction = value; }
        }



        private Form m_FormParent;
        public Form FormParent
        {
            get
            {
                return m_FormParent;
            }
            set
            {
                m_FormParent = value;
            }
        }

        private int m_ControlId;
        public int ControlId
        {
            get
            {
                return m_ControlId;
            }
            set
            {
                m_ControlId = value;
            }
        }

        private String m_ControlName;
        public String ControlName
        {
            get
            {
                return m_ControlName;
            }
            set
            {
                m_ControlName = value;
            }
        }

        private String m_TurnControlName;
        public String TurnControlName
        {
            get
            {
                return m_TurnControlName;
            }
            set
            {
                m_TurnControlName = value;
            }
        }

        private String m_DefaultValue;
        public String DefaultValue
        {
            get
            {
                return m_DefaultValue;
            }
            set
            {
                m_DefaultValue = value;
            }
        }

        public List<CTextBox> GetCTextBoxes(Control control)
        {
            List<CTextBox> ctxts = new List<CTextBox>();
            foreach (Control con in control.Controls)
            {
                if (con.GetType() == typeof(CTextBox))
                {
                    ctxts.Add((CTextBox)con);
                }
                if (con.GetType() == typeof(GroupBox))
                {
                    this.GetCTextBoxes(con);
                }
            }
            return ctxts;
        }

        protected override void OnPaint(PaintEventArgs pe)
        {
            base.OnPaint(pe);
        }
        private void CTextBox_MouseDown(object sender, MouseEventArgs e)
        {
            isMoving = true;//表示鼠标按下
            offset = new Point(e.X, e.Y);//创建光标位置对象
            intWidth = this.Width;//获取控件的初始宽度值
            intHeight = this.Height;
        }
        //自定义控件的鼠标移动事件绑定方法
        private void CTextBox_MouseMove(object sender, MouseEventArgs e)
        {
            if (isMoving)
            {
                //根据鼠标移动动态地设置控件的位置
                if (this.Cursor == System.Windows.Forms.Cursors.SizeAll)
                {
                    this.Location = new Point(this.Location.X + (e.X - offset.X),
                        this.Location.Y + (e.Y - offset.Y));
                    this.BackColor = Color.Red;
                }
                //根据鼠标移动动态地设置控件宽度
                if (this.Cursor == System.Windows.Forms.Cursors.SizeWE)
                {
                    this.Width = intWidth + (e.X - offset.X);
                    this.BackColor = Color.Red;
                }
                if (this.Cursor == System.Windows.Forms.Cursors.SizeNS)
                {
                    this.Height = intHeight + (e.Y - offset.Y);
                    // this.Font.Size = this.Height;
                    this.BackColor = Color.Red;
                }
                if (this.Cursor == System.Windows.Forms.Cursors.SizeNWSE)
                {
                    this.Width = intWidth + (e.Y - offset.Y);
                    this.Height = intHeight + (e.Y - offset.Y);
                    this.BackColor = Color.Red;
                }
            }
        }

        private void CTextBox_MouseUp(object sender, MouseEventArgs e)
        {
            isMoving = false;
        }

        private void toolDeleteCTextBox_Click(object sender, EventArgs e)
        {
            //if (MessageBox.Show("确定要删除吗？", "软件提示", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes)
            //{
            //    if (ControlId != 0)  //旧的控件
            //    {
            //        CommClass cc = new CommClass();
            //        DataOperate dataOper = new DataOperate();
            //        try
            //        {
            //            if (cc.IsExistConstraint("控件明细表", ControlId.ToString()))  //对应的子表tb_BillText已生成外键数据，先删除外键记录
            //            {
            //                if (MessageBox.Show("该输入框已生成账单数据，若继续执行将删除与之相关的数据，是否继续执行？", "软件提示", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.No)
            //                {
            //                    return;  //停止执行
            //                }
            //                //if (dataOper.ExecDataBySql("Delete From tb_BillText Where ControlId = '" + ControlId + "'") == 0)
            //                //{
            //                //    MessageBox.Show("删除失败！", "软件提示");
            //                //    return;
            //                //}
            //            }
            //            if (dataOper.ExecDataBySql("Delete From 控件明细表 Where 控件编号 = '" + ControlId + "'") == 0)  //从模板表中删除该控件对应的记录
            //            {
            //                MessageBox.Show("删除失败！", "软件提示");
            //                return;
            //            }
            //        }
            //        catch (Exception ex)
            //        {
            //            MessageBox.Show(ex.Message, "软件提示");
            //            return;
            //        }
            //    }
            //    this.Dispose();
            //    MessageBox.Show("删除成功！", "软件提示");
            //}
        }

        //设置单据号输入框"
        private void toolSetFlag_Click(object sender, EventArgs e)
        {
            List<CTextBox> ctxts = GetCTextBoxes(this.FormParent);
            foreach (CTextBox ctxt in ctxts)
            {
                if (ctxt.IsFlag == "1")
                {
                    ctxt.Text = "请输入名称";
                }
                ctxt.IsFlag = "0";
            }
            this.IsFlag = "1";
            this.Text = "单据号输入框";
        }

        private void toolSetProperty_Click(object sender, EventArgs e)
        {
            //CommClass cc = new CommClass();
            //cc.ShowDialogForm(typeof(FormSetProperty_CTXT), this, FormParent);
            cbbItem.SelectedItem= new ComboxItem(this.ControlName.ToString(),this.ControlId.ToString());
        }
        private void CTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                //把e传递给EventArgs是多态的特性
                if (this.IsUserFunction == "1")
                {
                    Double iNum = 0.0;
                    if (Double.TryParse(this.Text, out iNum) == false)
                    {
                        this.Focus();
                        this.SelectAll();
                        MessageBox.Show("非法的金额数字", "软件提示");
                        return;
                    }
                    this.Text = NumGetString.NumGetStr(iNum);
                }
            }
        }
    }
}
