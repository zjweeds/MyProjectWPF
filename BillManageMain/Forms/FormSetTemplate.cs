using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.ComponentModel;
using System.Data;
using System.IO;
using System.Drawing;
using System.Drawing.Imaging;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Controllers.MyControls;
using Controllers.Business;
using Controllers.Common;

namespace BillManageMain.Forms
{
    public partial class FormSetTemplate : Form
    {
        private CTextBox ctxt = null;
        private CDateTimePicker cdtp = null;
        private CComboBox cbxt = null;
        private CLabel clb = null;
        private CCheckBox chb = null;     
        private Point offset;
        private int BillCode;
        private DataTable dt = new DataTable();
        private CommonClass cc = new CommonClass();
        ImageHelper imageHelper = new ImageHelper();
        TemplateMain tm = new TemplateMain();
        float fDpiX;
        float fDpiY;
        BillTemplateService btmService = new BillTemplateService();
        ControlService ctmService = new ControlService();
        public FormSetTemplate()
        {
            InitializeComponent();
        }
        public FormSetTemplate(int Templatecode,TemplateMain item)
        {
            InitializeComponent();
            BillCode = Templatecode;            
            dt = btmService.SelectDataTableByID(BillCode);
            tm = item;
        }

        #region 分类获取控件的
        public List<CLabel> GetClabels(Control control)
        {
            List<CLabel> ctxts = new List<CLabel>();
            foreach (Control con in control.Controls)
            {
                if (con.GetType() == typeof(CLabel))
                {
                    ctxts.Add((CLabel)con);
                }
                if (con.GetType() == typeof(GroupBox))
                {
                    this.GetClabels(con);
                }
            }
            return ctxts;
        }
        public List<CCheckBox> GetCCheckBoxs(Control control)
        {
            List<CCheckBox> ctxts = new List<CCheckBox>();
            foreach (Control con in control.Controls)
            {
                if (con.GetType() == typeof(CCheckBox))
                {
                    ctxts.Add((CCheckBox)con);
                }
                if (con.GetType() == typeof(GroupBox))
                {
                    this.GetCCheckBoxs(con);
                }
            }
            return ctxts;
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

        public List<CComboBox> GetCComboBox(Control control)
        {
            List<CComboBox> cbxts = new List<CComboBox>();
            foreach (Control con in control.Controls)
            {
                if (con.GetType() == typeof(CComboBox))
                {
                    cbxts.Add((CComboBox)con);
                }
                if (con.GetType() == typeof(GroupBox))
                {
                    this.GetCComboBox(con);
                }
            }
            return cbxts;
        }
        public List<CDateTimePicker> GetCDateTimePicker(Control control)
        {
            List<CDateTimePicker> cbxts = new List<CDateTimePicker>();
            foreach (Control con in control.Controls)
            {
                if (con.GetType() == typeof(CDateTimePicker))
                {
                    cbxts.Add((CDateTimePicker)con);
                }
                if (con.GetType() == typeof(GroupBox))
                {
                    this.GetCComboBox(con);
                }
            }
            return cbxts;
        }

        #endregion
        #region 删除控件释放资源
        public void DisposeAllControls(Control ctrl)
        {
            Control.ControlCollection ctrls = ctrl.Controls;
            int intCount = ctrls.Count;
            for (int i = 0; i < intCount; i++)
            {
                ctrls[i].Dispose();
                i -= 1;
                intCount -= 1;

                if (i >= 0)
                {
                    if (ctrls[i].GetType() == typeof(GroupBox))
                    {
                        this.DisposeAllControls(ctrls[i]);
                    }
                }
            }
        }
        public void DisposeAllCTextBoxes(Control ctrl)
        {
            Control.ControlCollection ctrls = ctrl.Controls;
            int intCount = ctrls.Count;
            for (int i = 0; i < intCount; i++)
            {
                if (ctrls[i].GetType() == typeof(CTextBox))
                {
                    ctrls[i].Dispose();
                    i -= 1;
                    intCount -= 1;
                }
                if (i >= 0)
                {
                    if (ctrls[i].GetType() == typeof(GroupBox))
                    {
                        this.DisposeAllCTextBoxes(ctrls[i]);
                    }
                }
            }
        }
        public void DisposeAllCComboBoxs(Control ctrl)
        {
            Control.ControlCollection ctrls = ctrl.Controls;
            int intCount = ctrls.Count;
            for (int i = 0; i < intCount; i++)
            {
                if (ctrls[i].GetType() == typeof(CComboBox))
                {
                    ctrls[i].Dispose();
                    i -= 1;
                    intCount -= 1;
                }
                if (i >= 0)
                {
                    if (ctrls[i].GetType() == typeof(GroupBox))
                    {
                        this.DisposeAllCComboBoxs(ctrls[i]);
                    }
                }
            }
        }
        public void DisposeAllCCheckBoxs(Control ctrl)
        {
            Control.ControlCollection ctrls = ctrl.Controls;
            int intCount = ctrls.Count;
            for (int i = 0; i < intCount; i++)
            {
                if (ctrls[i].GetType() == typeof(CCheckBox))
                {
                    ctrls[i].Dispose();
                    i -= 1;
                    intCount -= 1;
                }
                if (i >= 0)
                {
                    if (ctrls[i].GetType() == typeof(GroupBox))
                    {
                        this.DisposeAllCCheckBoxs(ctrls[i]);
                    }
                }
            }
        }
        public void DisposeAllCLabels(Control ctrl)
        {
            Control.ControlCollection ctrls = ctrl.Controls;
            int intCount = ctrls.Count;
            for (int i = 0; i < intCount; i++)
            {
                if (ctrls[i].GetType() == typeof(CLabel))
                {
                    ctrls[i].Dispose();
                    i -= 1;
                    intCount -= 1;
                }
                if (i >= 0)
                {
                    if (ctrls[i].GetType() == typeof(GroupBox))
                    {
                        this.DisposeAllCLabels(ctrls[i]);
                    }
                }
            }
        }
        public void DisposeAllCDateTimePickers(Control ctrl)
        {
            Control.ControlCollection ctrls = ctrl.Controls;
            int intCount = ctrls.Count;
            for (int i = 0; i < intCount; i++)
            {
                if (ctrls[i].GetType() == typeof(CDateTimePicker))
                {
                    ctrls[i].Dispose();
                    i -= 1;
                    intCount -= 1;
                }
                if (i >= 0)
                {
                    if (ctrls[i].GetType() == typeof(GroupBox))
                    {
                        this.DisposeAllCDateTimePickers(ctrls[i]);
                    }
                }
            }
        }
        #endregion
      

        public void InitTemplate(int  strBillTypeCode)
        {
            try
            {
                DataTable dt = ctmService.SelectControlsByTemplateID(strBillTypeCode);//返回控件信息
                foreach (DataRow dr in dt.Rows)
                {
                    ComboxItem cbi = new ComboxItem(dr["CTIName"].ToString(), dr["CTIID"].ToString());
                    tm.cbbControls.Items.Add(cbi);//控件列表添加项
                    
                    #region 按类别加载控件
                    switch (dr["CTType"].ToString())
                    {
                        case "TextBox":
                            {                               
                                #region TextBox
                                ctxt = new CTextBox();
                                //ctxt.IsFlag = dr["IsFlag"].ToString();
                                //ctxt.IsUserFunction = dr["启用转换函数"].ToString();
                                ctxt.Text = dr["CTIName"].ToString();
                                ctxt.ControlId = Convert.ToInt32(dr["CTIID"]);
                                ctxt.BackColor = Color.FromArgb(int.Parse(dr["CTIBackColor"].ToString()));
                                ctxt.ForeColor = Color.FromArgb(int.Parse(dr["CTIFontColor"].ToString())); 
                                ctxt.ControlName = dr["CTIName"].ToString();
                                ctxt.TabIndex = Convert.ToInt32(dr["CTITabKey"]);
                                ctxt.Location = new Point(Convert.ToInt32(dr["CTILeft"]), Convert.ToInt32(dr["CTITop"]));
                                ctxt.Size = new Size(Convert.ToInt32(dr["CTIWidth"]), Convert.ToInt32(dr["CTIHeight"]));
                                ctxt.Font = cc.GetFontByString(dr["CTIFont"].ToString());                               
                                ctxt.Visible = Convert.ToInt32(dr["CTIVisiable"]) == 0 ? false : true;
                                ctxt.ReadOnly = Convert.ToInt32(dr["CTIIsReadOnly"]) == 0 ? true : false;
                                ctxt.BorderStyle = Convert.ToInt32(dr["CTIIsReadOnly"]) == 1 ? BorderStyle.None : BorderStyle.FixedSingle;
                                ctxt.cbbItem = tm.cbbControls;
                                this.Controls.Add(ctxt);
                                break;
                                #endregion
                            }
                        case "CheckBox":
                            {
                                #region CheckBox
                                chb = new CCheckBox();
                                //ctxt.IsFlag = dr["IsFlag"].ToString();
                                //ctxt.IsUserFunction = dr["启用转换函数"].ToString();
                                chb.Text = dr["CTIName"].ToString();
                                chb.ControlId = Convert.ToInt32(dr["CTIID"]);
                                chb.BackColor = Color.FromArgb(int.Parse(dr["CTIBackColor"].ToString()));
                                chb.ForeColor = Color.FromArgb(int.Parse(dr["CTIFontColor"].ToString()));
                                chb.ControlName = dr["CTIName"].ToString();
                                chb.TabIndex = Convert.ToInt32(dr["CTITabKey"]);
                                chb.Location = new Point(Convert.ToInt32(dr["CTILeft"]), Convert.ToInt32(dr["CTITop"]));
                                chb.Size = new Size(Convert.ToInt32(dr["CTIWidth"]), Convert.ToInt32(dr["CTIHeight"]));
                                chb.Font = cc.GetFontByString(dr["CTIFont"].ToString());
                                chb.Visible = Convert.ToInt32(dr["CTIVisiable"]) == 0 ? false : true;
                                //chb.ReadOnly = Convert.ToInt32(dr["CTIIsReadOnly"]) == 0 ? true : false;
                                //chb.BorderStyle = Convert.ToInt32(dr["CTIIsReadOnly"]) == 1 ? BorderStyle.None : BorderStyle.FixedSingle;
                                this.Controls.Add(chb);
                                break;
                                #endregion
                            }
                        case "ComboBox":
                            {
                                #region ComboBox
                                cbxt = new CComboBox();
                                //ctxt.IsFlag = dr["IsFlag"].ToString();
                                //ctxt.IsUserFunction = dr["启用转换函数"].ToString();
                                cbxt.Text = dr["CTIName"].ToString();
                                cbxt.ControlId = Convert.ToInt32(dr["CTIID"]);
                                cbxt.BackColor = Color.FromArgb(int.Parse(dr["CTIBackColor"].ToString()));
                                cbxt.ForeColor = Color.FromArgb(int.Parse(dr["CTIFontColor"].ToString()));
                                cbxt.ControlName = dr["CTIName"].ToString();
                                cbxt.TabIndex = Convert.ToInt32(dr["CTITabKey"]);
                                cbxt.Location = new Point(Convert.ToInt32(dr["CTILeft"]), Convert.ToInt32(dr["CTITop"]));
                                cbxt.Size = new Size(Convert.ToInt32(dr["CTIWidth"]), Convert.ToInt32(dr["CTIHeight"]));
                                chb.Font = cc.GetFontByString(dr["CTIFont"].ToString());
                                cbxt.Visible = Convert.ToInt32(dr["CTIVisiable"]) == 0 ? false : true;
                                //cbxt.ReadOnly = Convert.ToInt32(dr["CTIIsReadOnly"]) == 0 ? true : false;
                                //cbxt.BorderStyle = Convert.ToInt32(dr["CTIIsReadOnly"]) == 1 ? BorderStyle.None : BorderStyle.FixedSingle;
                                this.Controls.Add(cbxt);
                                break;
                                #endregion
                            }
                        case "DateTimePicker":
                            {
                                #region DateTimePicker
                                cdtp = new CDateTimePicker();
                                //ctxt.IsFlag = dr["IsFlag"].ToString();
                                //ctxt.IsUserFunction = dr["启用转换函数"].ToString();
                                cdtp.Text = dr["CTIName"].ToString();
                                cdtp.ControlId = Convert.ToInt32(dr["CTIID"]);
                                cdtp.BackColor = Color.FromArgb(int.Parse(dr["CTIBackColor"].ToString()));
                                cdtp.ForeColor = Color.FromArgb(int.Parse(dr["CTIFontColor"].ToString()));
                                cdtp.ControlName = dr["CTIName"].ToString();
                                cdtp.TabIndex = Convert.ToInt32(dr["CTITabKey"]);
                                cdtp.Location = new Point(Convert.ToInt32(dr["CTILeft"]), Convert.ToInt32(dr["CTITop"]));
                                cdtp.Size = new Size(Convert.ToInt32(dr["CTIWidth"]), Convert.ToInt32(dr["CTIHeight"]));
                                cdtp.Font = cc.GetFontByString(dr["CTIFont"].ToString());
                                cdtp.Visible = Convert.ToInt32(dr["CTIVisiable"]) == 0 ? false : true;
                                //cdtp.ReadOnly = Convert.ToInt32(dr["CTIIsReadOnly"]) == 0 ? true : false;
                                //cdtp.BorderStyle = Convert.ToInt32(dr["CTIIsReadOnly"]) == 1 ? BorderStyle.None : BorderStyle.FixedSingle;
                                this.Controls.Add(cdtp);
                                break;
                                #endregion
                            }
                        case "Label":
                            {

                                #region Label
                                clb = new CLabel();
                                //ctxt.IsFlag = dr["IsFlag"].ToString();
                                //ctxt.IsUserFunction = dr["启用转换函数"].ToString();
                                clb.Text = dr["CTIName"].ToString();
                                clb.ControlId = Convert.ToInt32(dr["CTIID"]);
                                clb.BackColor = Color.FromArgb(int.Parse(dr["CTIBackColor"].ToString()));
                                clb.ForeColor = Color.FromArgb(int.Parse(dr["CTIFontColor"].ToString()));
                                clb.ControlName = dr["CTIName"].ToString();
                                clb.TabIndex = Convert.ToInt32(dr["CTITabKey"]);
                                clb.Location = new Point(Convert.ToInt32(dr["CTILeft"]), Convert.ToInt32(dr["CTITop"]));
                                clb.Size = new Size(Convert.ToInt32(dr["CTIWidth"]), Convert.ToInt32(dr["CTIHeight"]));
                                clb.Font = cc.GetFontByString(dr["CTIFont"].ToString());
                                clb.Visible = Convert.ToInt32(dr["CTIVisiable"]) == 0 ? false : true;
                                //clb.ReadOnly = Convert.ToInt32(dr["CTIIsReadOnly"]) == 0 ? true : false;
                                clb.BorderStyle = Convert.ToInt32(dr["CTIIsReadOnly"]) == 1 ? BorderStyle.None : BorderStyle.FixedSingle;
                                this.Controls.Add(clb);
                                break;
                                #endregion
                            }
                        default:
                            {
                                MessageBox.Show("载入控件出错：找不到相应的控件类别！", "软件提示");
                                break;

                            }
                    
                    }
                    #endregion
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "软件提示");
            }
        }

        /// <summary>
        /// 窗体自动调整大小并居中
        /// </summary>
        /// <param name="size">窗体新的size</param>
        public void FormAutoResize(Size size)
        {
            //获取窗体原始Size
            int intOldWidth = this.Width;
            int intOldHeight = this.Height;
            //设置窗体新的Size
            this.Width = size.Width + 50;
            this.Height = size.Height + 70;
            //设置新的位置(Location)居中
            this.Location = new Point(this.Location.X - (this.Width - intOldWidth) / 2,
                                                             this.Location.Y - (this.Height - intOldHeight) / 2);
        }

        private void FormSetTemplate_MouseMove(object sender, MouseEventArgs e)
        {
            try
            {
                foreach (Control c in this.Controls)
                {
                    if (e.X == c.Location.X + c.Size.Width)
                    {
                        if (e.Y == c.Location.Y + c.Size.Height)
                        {
                            c.Cursor = Cursors.SizeNWSE;
                        }
                        else
                        {
                            c.Cursor = Cursors.SizeWE;
                        }
                    }
                    else if (e.Y == c.Location.Y + c.Size.Height)
                    {
                        c.Cursor = Cursors.SizeNS;
                    }
                    else
                    {
                        c.Cursor = Cursors.SizeAll;
                    }
                }
            }
            catch
            {
                MessageBox.Show("控件绘制出错", "软件提示");
            }
        }

      

        private void FormSetTemplate_Load(object sender, EventArgs e)
        {
            //获取分辨率
            fDpiX = this.CreateGraphics().DpiX;
            fDpiY = this.CreateGraphics().DpiY;            
            //dr = dt.Rows[0];
            InitTemplate(BillCode);
            this.Invalidate();

        }

        private void FormSetTemplate_Paint(object sender, PaintEventArgs e)
        {
            //光标相对的原点是屏幕的左上角顶点；而控件相对的原点是所在窗体的左上角顶点
            offset = new Point(this.Location.X, this.Location.Y);
            //引入图片
            Image img = imageHelper.GetImageByByte(dt.Rows[0]["TIBackground"] as byte[]);
            //左上角顶点
            Point point = new Point(0, 0);
            //新的大小
            SizeF newSize = new SizeF(MillimetersToPixel(Convert.ToInt32(dt.Rows[0]["TIWidth"].ToString()), fDpiX),
                                      MillimetersToPixel(Convert.ToInt32(dt.Rows[0]["TIHeight"].ToString()), fDpiY));
            //新的矩形
            RectangleF NewRect = new RectangleF(point, newSize);
            //原始图形的参数
            SizeF oldSize = new SizeF(img.Width, img.Height);
            //原始图形的大小
            RectangleF OldRect = new RectangleF(point, oldSize);
            //缩放图形处理
            e.Graphics.DrawImage(img, NewRect, OldRect, System.Drawing.GraphicsUnit.Pixel);
            //若新图形的宽度或高度大于窗体的宽度或高度，窗体会自行调整
            if (newSize.Width > this.Width || newSize.Height > this.Height)
            {
                Size size = new Size(Convert.ToInt32(MillimetersToPixel(Convert.ToInt32(dt.Rows[0]["TIWidth"].ToString()), fDpiX)),
                                     Convert.ToInt32(MillimetersToPixel(Convert.ToInt32(dt.Rows[0]["TIHeight"].ToString()), fDpiY)));
                FormAutoResize(size);
            }
        }

        private float MillimetersToPixel(float fValue, float fDPI)
        {
            return (fValue / 25.4f) * fDPI;
        }
        #region 保存控件到数据库
        /*
        public void ControlToDatabase(bool boolIsFlag, string strSql, List<CTextBox> ctxts, Control control, string strBillTypeCode, List<string> strSqls, EventArgs e)
        {

            ctxts = this.GetCTextBoxes(this);
            foreach (CTextBox ctxt in ctxts)
            {
                //查找被设置为单据号的控件
                if (ctxt.IsFlag == "1")
                {
                    boolIsFlag = true;
                }
                //判断控件的新旧
                if (ctxt.ControlId == 0)  //若该控件为新添加的
                {
                    strSql = "INSERT INTO 控件明细表(模版编号,X,Y,宽度,高度,IsFlag,控件名称,默认值,Tab跳转控件,控件类别,字体,启用转换函数) VALUES( '" + strBillTypeCode + "','" + ctxt.Location.X + "','" + ctxt.Location.Y + "','" + ctxt.Width + "','" + ctxt.Height + "','" + ctxt.IsFlag + "','" + ctxt.ControlName + "','" + ctxt.DefaultValue + "','" + ctxt.TurnControlName + "','CTextBox','" + cc.GetStringByFont(ctxt.Font) + "','" + ctxt.IsUserFunction + "')";
                }
                else  //若该控件为旧的控件
                {
                    strSql = "Update 控件明细表 Set 模版编号 = '" + strBillTypeCode + "',X = '" + ctxt.Location.X + "',Y='" + ctxt.Location.Y + "',宽度= '" + ctxt.Width + "',高度 = '" + ctxt.Height + "',IsFlag = '" + ctxt.IsFlag + "',控件名称 = '" + ctxt.ControlName + "',默认值 = '" + ctxt.DefaultValue + "',Tab跳转控件 = '" + ctxt.TurnControlName + "',字体 = '" + cc.GetStringByFont(ctxt.Font) + "',启用转换函数 = '" + ctxt.IsUserFunction + "' Where 控件编号 = '" + ctxt.ControlId + "'";
                }
                strSqls.Add(strSql);
            }

            //判断单据号输入框
            if (!boolIsFlag)
            {
                if (e.GetType() == typeof(FormClosingEventArgs))//若是关闭操作调用的保存处理
                {
                    ((FormClosingEventArgs)e).Cancel = true;//禁止关闭
                }
                MessageBox.Show("请设置单据号输入框，否则程序无法保存！", "软件提示");
                return;
            }
            //判断单据号输入框

        }
        public void ControlToDatabase(bool boolIsFlag, string strSql, List<CComboBox> ctxts, Control control, string strBillTypeCode, List<string> strSqls, EventArgs e)
        {

            ctxts = this.GetCComboBox(this);
            foreach (CComboBox ctxt in ctxts)
            {

                if (ctxt.ControlId == 0)  //若该控件为新添加的
                {
                    strSql = "INSERT INTO 控件明细表(模版编号,X,Y,宽度,高度,IsFlag,控件名称,默认值,Tab跳转控件,控件类别,字体,启用转换函数) VALUES( '" + strBillTypeCode + "','" + ctxt.Location.X + "','" + ctxt.Location.Y + "','" + ctxt.Width + "','" + ctxt.Height + "','0','" + ctxt.ControlName + "','" + ctxt.DefaultValue + "','" + ctxt.TurnControlName + "','CComboBox','" + cc.GetStringByFont(ctxt.Font) + "','0')";
                }
                else  //若该控件为旧的控件
                {
                    strSql = "Update 控件明细表 Set 模版编号 = '" + strBillTypeCode + "',X = '" + ctxt.Location.X + "',Y='" + ctxt.Location.Y + "',宽度= '" + ctxt.Width + "',高度 = '" + ctxt.Height + "',IsFlag = '0',控件名称 = '" + ctxt.ControlName + "',默认值 = '" + ctxt.DefaultValue + "',Tab跳转控件 = '" + ctxt.TurnControlName + "',字体 = '" + cc.GetStringByFont(ctxt.Font) + "' Where 控件编号 = '" + ctxt.ControlId + "'";
                }
                strSqls.Add(strSql);
            }
        }
        public void ControlToDatabase(bool boolIsFlag, string strSql, List<CDateTimePicker> ctxts, Control control, string strBillTypeCode, List<string> strSqls, EventArgs e)
        {
            ctxts = this.GetCDateTimePicker(this);
            foreach (CDateTimePicker ctxt in ctxts)
            {   //判断控件的新旧
                if (ctxt.ControlId == 0)  //若该控件为新添加的
                {
                    strSql = "INSERT INTO 控件明细表(模版编号,X,Y,宽度,高度,IsFlag,控件名称,默认值,Tab跳转控件,控件类别,字体,启用转换函数) VALUES( '" + strBillTypeCode + "','" + ctxt.Location.X + "','" + ctxt.Location.Y + "','" + ctxt.Width + "','" + ctxt.Height + "','0','" + ctxt.ControlName + "','" + ctxt.DefaultValue + "','" + ctxt.TurnControlName + "','CDateTimePicker','" + cc.GetStringByFont(ctxt.Font) + "','0')";
                }
                else  //若该控件为旧的控件
                {
                    strSql = "Update 控件明细表 Set 模版编号 = '" + strBillTypeCode + "',X = '" + ctxt.Location.X + "',Y='" + ctxt.Location.Y + "',宽度= '" + ctxt.Width + "',高度 = '" + ctxt.Height + "',IsFlag = '0',控件名称 = '" + ctxt.ControlName + "',默认值 = '" + ctxt.DefaultValue + "',Tab跳转控件 = '" + ctxt.TurnControlName + "',字体 = '" + cc.GetStringByFont(ctxt.Font) + "' Where 控件编号 = '" + ctxt.ControlId + "'";
                }
                strSqls.Add(strSql);
            }



        }
        public void ControlToDatabase(bool boolIsFlag, string strSql, List<CLabel> ctxts, Control control, string strBillTypeCode, List<string> strSqls, EventArgs e)
        {
            ctxts = this.GetClabels(this);
            foreach (CLabel ctxt in ctxts)
            {    //判断控件的新旧
                if (ctxt.ControlId == 0)  //若该控件为新添加的
                {
                    strSql = "INSERT INTO 控件明细表(模版编号,X,Y,宽度,高度,IsFlag,控件名称,默认值,Tab跳转控件,控件类别,字体,启用转换函数) VALUES( '" + strBillTypeCode + "','" + ctxt.Location.X + "','" + ctxt.Location.Y + "','" + ctxt.Width + "','" + ctxt.Height + "','0','" + ctxt.ControlName + "','" + ctxt.DefaultValue + "','" + ctxt.TurnControlName + "','CLabel','" + cc.GetStringByFont(ctxt.Font) + "','0')";
                }
                else  //若该控件为旧的控件
                {
                    strSql = "Update 控件明细表 Set 模版编号 = '" + strBillTypeCode + "',X = '" + ctxt.Location.X + "',Y='" + ctxt.Location.Y + "',宽度= '" + ctxt.Width + "',高度 = '" + ctxt.Height + "',IsFlag = '0',控件名称 = '" + ctxt.ControlName + "',默认值 = '" + ctxt.DefaultValue + "',Tab跳转控件 = '" + ctxt.TurnControlName + "',字体 = '" + cc.GetStringByFont(ctxt.Font) + "' Where 控件编号 = '" + ctxt.ControlId + "'";
                }
                strSqls.Add(strSql);
            }
        }
        public void ControlToDatabase(bool boolIsFlag, string strSql, List<CCheckBox> ctxts, Control control, string strBillTypeCode, List<string> strSqls, EventArgs e)
        {
            ctxts = this.GetCCheckBoxs(this);
            foreach (CCheckBox ctxt in ctxts)
            {  
                //判断控件的新旧
                if (ctxt.ControlId == 0)  //若该控件为新添加的
                {
                    strSql = "INSERT INTO 控件明细表(模版编号,X,Y,宽度,高度,IsFlag,控件名称,默认值,Tab跳转控件,控件类别,字体,启用转换函数) VALUES( '" + strBillTypeCode + "','" + ctxt.Location.X + "','" + ctxt.Location.Y + "','" + ctxt.Width + "','" + ctxt.Height + "','0','" + ctxt.ControlName + "','" + ctxt.DefaultValue + "','" + ctxt.TurnControlName + "','CCheckBox','" + cc.GetStringByFont(ctxt.Font) + "','0')";
                }
                else  //若该控件为旧的控件
                {
                    strSql = "Update 控件明细表 Set 模版编号 = '" + strBillTypeCode + "',X = '" + ctxt.Location.X + "',Y='" + ctxt.Location.Y + "',宽度= '" + ctxt.Width + "',高度 = '" + ctxt.Height + "',IsFlag = '0',控件名称 = '" + ctxt.ControlName + "',默认值 = '" + ctxt.DefaultValue + "',Tab跳转控件 = '" + ctxt.TurnControlName + "',字体 = '" + cc.GetStringByFont(ctxt.Font) + "' Where 控件编号 = '" + ctxt.ControlId + "'";
                }
                strSqls.Add(strSql);
            }
        }
       */
        #endregion
        private void toolSave_Click(object sender, EventArgs e)
        {
            #region
            /*
            //判断是否设置单据号输入框的逻辑标记
            bool boolIsFlag = false;
            string strSql = null;
            //表示单据类型代码的字符串
            string strBillTypeCode = dt.Rows[0]["模版编号"].ToString();
            //List<T>泛型
            List<string> strSqls = new List<string>();
            List<CTextBox> ctxts = null;
            List<CCheckBox> chbs = null;
            List<CComboBox> cbxts = null;
            List<CDateTimePicker> cdtps = null;
            List<CLabel> clbs = null;
            //ControlToDatabase(boolIsFlag, strSql, ctxts, this, strBillTypeCode, strSqls, e);
            //ControlToDatabase(boolIsFlag, strSql, chbs, this, strBillTypeCode, strSqls, e);
            //ControlToDatabase(boolIsFlag, strSql, cbxts, this, strBillTypeCode, strSqls, e);
            //ControlToDatabase(boolIsFlag, strSql, cdtps, this, strBillTypeCode, strSqls, e);
            //ControlToDatabase(boolIsFlag, strSql, clbs, this, strBillTypeCode, strSqls, e);

            if (strSqls.Count > 0)
            {
                if (MessageBox.Show("确定要保存吗？", "软件提示", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes)
                {
                    if (dataOper.ExecDataBySqls(strSqls))
                    {
                        //DisposeAllCTextBoxes(this);  //
                        DisposeAllControls(this);//清除现有的控件布局
                        InitTemplate(strBillTypeCode);  //重新加载窗体上面的控件布局
                        MessageBox.Show("保存模板成功！", "软件提示");
                    }
                    else
                    {
                        MessageBox.Show("保存模板失败！", "软件提示");
                    }
                }
            }
            else
            {
                MessageBox.Show("未添加输入框，无需保存！", "软件提示");

            }
             * */
            #endregion
        }

        private void toolExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// 窗口关闭时检查有无控件更新
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FormSetTemplate_FormClosing(object sender, FormClosingEventArgs e)
        {

            e.Cancel = false;//可以关闭
            List<Control> con = new List<Control>();
            if (con.Exists(itm => itm.BackColor == Color.Red))
            {
                if (MessageBox.Show("模板设置信息已被更新，是否保存？", "软件提示", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                {
                    toolSave_Click(sender, e);
                }

            }
        }
        
        /// <summary>
        /// 关闭窗口
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FormSetTemplate_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Dispose();
        }
     
        private void 文本框_Click(object sender, EventArgs e)
        {
            ctxt = new CTextBox();
            ctxt.IsFlag = "0";  //系统默认不为单据编号对应的输入框
            ctxt.ControlId = 0; //系统默认的控件编号为零
            ctxt.IsUserFunction = "0";//默认不启用转换函数
            ctxt.Text = "请输入名称";
            ctxt.Location = new Point(MousePosition.X - offset.X, MousePosition.Y - offset.Y);
            ctxt.ReadOnly = true;
            ctxt.BackColor = Color.Red;
            this.Controls.Add(ctxt);
            PropertyForm pf=new PropertyForm(ctxt);
            loadPropertyForm(pf);
            ctxt.Focus();
            ctxt.SelectAll();
        }

        private void 下拉框_Click(object sender, EventArgs e)
        {
            cbxt = new CComboBox();
            //cbxt.IsFlag = "0";  //系统默认不为单据编号对应的输入框
            cbxt.ControlId = 0; //系统默认的控件编号为零
            cbxt.Text = "请输入名称";
            // cbxt.FormattingEnabled = true;
            cbxt.FormParent = this;
            cbxt.Location = new Point(MousePosition.X - offset.X, MousePosition.Y - offset.Y);
            //cbxt.ReadOnly = true;
            // cbxt.Enabled = false;
            cbxt.BackColor = Color.Red;
            this.Controls.Add(cbxt);
            //---选择默认的文本
            cbxt.Focus();
            cbxt.SelectAll();
        }

        private void 标签_Click(object sender, EventArgs e)
        {
            clb = new CLabel();
            // clb.IsFlag = "0";  //系统默认不为单据编号对应的输入框
            clb.ControlId = 0; //系统默认的控件编号为零
            clb.Text = "请设置名称";
            clb.FormParent = this;
            clb.Location = new Point(MousePosition.X - offset.X, MousePosition.Y - offset.Y);
            //ctxt.ReadOnly = true;
            clb.BackColor = Color.Red;
            this.Controls.Add(clb);
            //---选择默认的文本
            //ctxt.Focus();
            //ctxt.SelectAll();
        }

        private void 日历_Click(object sender, EventArgs e)
        {
            cdtp = new CDateTimePicker();

            //cdtp.IsFlag = "0";
            cdtp.ControlId = 0;
            cdtp.FormParent = this;
            cdtp.Location = new Point(MousePosition.X - offset.X, MousePosition.Y - offset.Y);
           
            cdtp.BackColor = Color.Red;
            this.Controls.Add(cdtp);
             //---选择默认的文本
            cdtp.Focus();
            //cdtp.SelectAll();
        }

        private void 多选框_Click(object sender, EventArgs e)
        {
            chb = new CCheckBox();
            //chb.IsFlag = "0";
            chb.ControlId = 0;
            chb.FormParent = this;
            chb.Location = new Point(MousePosition.X - offset.X, MousePosition.Y - offset.Y);
            chb.BackColor = Color.Red;
            this.Controls.Add(chb);
            //---选择默认的文本
            chb.Focus();
            //cdtp.SelectAll();
        }


        private void 退出_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void 保存模版_Click(object sender, EventArgs e)
        {
            toolSave_Click(sender, e);
        }
        public void loadPropertyForm(PropertyForm child)
        {
            this.tm.splitContainer1.Panel2.Controls.Clear();
            child.TopLevel = false;
            child.Dock = System.Windows.Forms.DockStyle.Fill;
            child.FormBorderStyle = FormBorderStyle.None;
            this.tm.splitContainer1.Panel2.Controls.Add(child);
            child.Show();
        }

        private void 文本框_MouseHover(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text = "点击添加文本框";
        }

        private void 金额明细_Click(object sender, EventArgs e)
        {

        }





    }
}
