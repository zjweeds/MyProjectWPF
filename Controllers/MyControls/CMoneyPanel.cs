using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Controllers.Common;

namespace Controllers.MyControls
{

    //自定义控件CMoneyPanel扩展自PictureBox
    public partial class CMoneyPanel : PictureBox
    {
        #region 声明变量
        bool isMoving = false;//定义一个bool型变量，表示鼠标按下标记
        Point offset;//声明一个Point类型引用，表示光标位置
        int intWidth;//定义一个整形变量，表示控件的宽度
        int intHeight;//定义一个整形变量，表示控件的高度
        #endregion

        /// <summary>
        /// 控件的行数
        /// </summary>
        public int intRow
        { get; set; }
        /// <summary>
        ///控件显示时的最高位 
        /// </summary>
        public int HighUnit
        {
            get;
            set;
        }

        /// <summary>
        ///控件显示的最低位 
        /// </summary>
        public int LowUnit
        {
            get;
            set;
        }

        /// <summary>
        /// 表示当前控件是否使用数字大小写转换函数
        /// </summary>
        public String IsUserFunction
        {
            get;
            set;
        }
        
        /// <summary>
        /// 指示当前控件的父窗体
        /// </summary>
        public Form FormParent
        {
            get;
            set;
        }

        /// <summary>
        /// 控件编号
        /// </summary>
        public int ControlId
        {
            get;
            set;
        }

        /// <summary>
        /// 控件名称
        /// </summary>
        public String ControlName
        {
            get;
            set;
        }

        /// <summary>
        /// 跳转控件名称
        /// </summary>
        public String TurnControlName
        {
            get;
            set;
        }
        
        /// <summary>
        /// 默认值
        /// </summary>
        public String DefaultValue
        {
            get;
            set;
        }
       

        private static String[] DanWei =
        { "分", "角", "元", "十", "百", "千", "万", "十", "百", "千", "亿", "十", "百", "千", "万", "十", "百", "千" };
        
        /// <summary>
        /// 
        /// </summary>
        public CMoneyPanel()
        {
            InitializeComponent();
            ///this.Multiline = true;

        }
        /// <summary>
        /// 鼠标按下事件的绑定方法
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CMoneyPanel_MouseDown(object sender, MouseEventArgs e)
        {
            isMoving = true;//表示鼠标按下
            offset = new Point(e.X, e.Y);//创建光标位置对象
            intWidth = this.Width;//获取控件的初始宽度值
            intHeight = this.Height;
        }
        
      

        /// <summary>
        /// 从当前控件容器中获取所有此控件泛型列表
        /// </summary>
        /// <param name="control">控件容器</param>
        /// <returns></returns>
        public List<CMoneyPanel> GetCMoneyPaneles(Control control)
        {
            List<CMoneyPanel> ctxts = new List<CMoneyPanel>();
            foreach (Control con in control.Controls)
            {
                if (con.GetType() == typeof(CMoneyPanel))
                {
                    ctxts.Add((CMoneyPanel)con);
                }
                if (con.GetType() == typeof(GroupBox))
                {
                    this.GetCMoneyPaneles(con);
                }
            }
            return ctxts;
        }

        /// <summary>
        /// 重绘事件
        /// </summary>
        /// <param name="pe"></param>
        protected override void OnPaint(PaintEventArgs pe)
        {
            CPicture_Paint(null, pe);
        }
        
        /// <summary>
        /// 自定义控件的鼠标移动事件绑定方法
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CMoneyPanel_MouseMove(object sender, MouseEventArgs e)
        {
            if (isMoving)
            {
                # region 根据鼠标移动动态地设置控件的位置
                if (this.Cursor == System.Windows.Forms.Cursors.SizeAll)
                {
                    this.Location = new Point(this.Location.X + (e.X - offset.X),
                        this.Location.Y + (e.Y - offset.Y));
                    this.BackColor = Color.Red;
                }
                #endregion
                #region  根据鼠标移动动态地设置控件宽度
                if (this.Cursor == System.Windows.Forms.Cursors.SizeWE)
                {
                    this.Width = intWidth + (e.X - offset.X);
                    this.BackColor = Color.Red;
                }
                #endregion
                #region  根据鼠标移动动态地设置控件高度
                if (this.Cursor == System.Windows.Forms.Cursors.SizeNS)
                {
                    this.Height = intHeight + (e.Y - offset.Y);
                    // this.Font.Size = this.Height;
                    this.BackColor = Color.Red;
                }
                #endregion
                #region 鼠标双向移动  同时设定高度和宽度
                if (this.Cursor == System.Windows.Forms.Cursors.SizeNWSE)
                {
                    this.Width = intWidth + (e.Y - offset.Y);
                    this.Height = intHeight + (e.Y - offset.Y);
                    this.BackColor = Color.Red;
                }
                #endregion
            }
        }

        /// <summary>
        /// 鼠标按键释放停止移动
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CMoneyPanel_MouseUp(object sender, MouseEventArgs e)
        {
            isMoving = false;
        }

        /// <summary>
        /// 删除控件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolDeleteCMoneyPanel_Click(object sender, EventArgs e)
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

        /// <summary>
        /// 弹出属性窗口
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolSetProperty_Click(object sender, EventArgs e)
        {
            //CommClass cc = new CommClass();
            //cc.ShowDialogForm(typeof(FormSetProperty), this, FormParent);
        }


        /// <summary>
        /// 按下键盘事件处理方法
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CMoneyPanel_KeyDown(object sender, KeyEventArgs e)
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
                        ///    this.SelectAll();
                        MessageBox.Show("非法的金额数字", "软件提示");
                        return;
                    }
                    this.Text = NumGetString.NumGetStr(iNum);
                }
            }
        }

        /// <summary>
        /// 画线和单位
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <param name="cloum">画的的列数</param>
        /// <param name="rows">画的行数</param>
          private void CPicture_Paint(object sender, PaintEventArgs e)
        {
            int WeiShu = Convert.ToInt32(HighUnit-LowUnit+1);//列数
            int HangShu = Convert.ToInt32(intRow);//行数
            if (WeiShu != 1)//列数为1不画
            {
                int f_Height = (this.intHeight / HangShu);//单位的字体高度
                int f_width = (this.intWidth / WeiShu);//单位的字体宽度 
                float f_size = 10;//字体的大小
                if (f_Height > f_width)//字体的大小根据小的那个确定
                {
                    f_size = (float)(f_width * 0.6);
                }
                else
                {
                    f_size = (float)(f_Height * 0.6);
                }
                e.Graphics.DrawString(DanWei[WeiShu - 1], new Font("宋体", f_size), Brushes.Blue, 0, 0);//画第一个单位
                Point Ponitset = new Point(0, 0);//原点
                for (int i = 1; i < WeiShu; i++)//循环画所有列
                {
                    int m_width = f_width * i;//每个格子的宽度
                    int X = Ponitset.X + m_width;//每个格子的横坐标
                    int y = Ponitset.Y;//每个格子的纵坐标
                    Point p1 = new Point(Ponitset.X + m_width, Ponitset.Y);//画线的起点
                    e.Graphics.DrawString(DanWei[WeiShu - i - 1], new Font("宋体", f_size), Brushes.Blue, X, y);//画所有单位
                    Point p2 = new Point(Ponitset.X + m_width, Ponitset.Y + this.intHeight);//画线的终点
                    e.Graphics.DrawLine(System.Drawing.Pens.Red, p1, p2);//画线
                }
                for (int i = 1; i < HangShu; i++)//循环画所有行
                {
                    int m_Height = f_Height * i;
                    Point p1 = new Point(Ponitset.X, Ponitset.Y + m_Height);
                    Point p2 = new Point(Ponitset.X + this.intWidth, Ponitset.Y + m_Height);
                    e.Graphics.DrawLine(System.Drawing.Pens.DarkGray, p1, p2);
                }
            }  
        }
    }
}
