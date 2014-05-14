using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Controllers.Models;
using Controllers.Common;
using Controllers.DataAccess;
using BillManageWPF.Forms;
using System.Data;
using BillManageWPF.MyCode;
using FirstFloor.ModernUI.Windows.Controls;
using System.Windows.Navigation;
namespace BillManageWPF.Content.Template
{
    /// <summary>
    /// TemplateProperyEdit.xaml 的交互逻辑
    /// </summary>
    public partial class TemplateProperyEdit : Window
    {
        #region 构造函数
        public TemplateProperyEdit()
        {
            InitializeComponent();
        }
        /// <summary>
        /// 新增模板属性
        /// </summary>
        /// <param name="t"></param>
        public TemplateProperyEdit(String templateType)
        {
            InitializeComponent();
            this.Type = "Add";
            this.TemplateTypeName = templateType;
        }

        ///// <summary>
        ///// 修改模板属性
        ///// </summary>
        ///// <param name="t"></param>
        ///// <param name="code"></param>
        //public TemplateProperyEdit(String templateType, int code)
        //{
        //    InitializeComponent();
        //    this.Type ="Update";
        //    btm.TIID = code;
        //    this.TemplateTypeName = templateType;
        //}

        /// <summary>
        /// 修改模板属性
        /// </summary>
        /// <param name="t"></param>
        /// <param name="code"></param>
        public TemplateProperyEdit(BillTemplatModel m_btm)
        {
            InitializeComponent();
            this.Type = "Update";
            btm = m_btm;
        }
        #endregion

        #region 变量初始化
        public ImageHelper imaHelper = new ImageHelper();//图片帮助类
        public String Type = String.Empty; //操作类型（修改、添加）
        public String TemplateTypeName ; // 模板类型名称
        //public BitmapImage bitImage = null; //保存图片
        public System.Drawing.Image bgimage = null;//保存图片
        public BillTemplatModel btm = new BillTemplatModel(); //模板实体
        private System.Windows.Forms.OpenFileDialog dlgPicture = new System.Windows.Forms.OpenFileDialog(); //文件选择对话框
        public BillTemplateService btmserice = new BillTemplateService();//模板业务对象
        public DataTable dttype = new DataTable();
        public BillTemplateTypeService btts = new BillTemplateTypeService();
        #endregion

        #region 自定义方法
        /// <summary>
        /// 检查必填项是否为空
        /// </summary>
        /// <returns></returns>
        private bool CheckIsNull()
        {
            if (txtTemplateName.Text == String.Empty)
            {
                txtTemplateName.Focus();
                txtTemplateName.BorderBrush = new SolidColorBrush(Colors.Red);
                return false;
            }
            else if (Convert.ToInt32(txtBillCodeLength.Text) == 0)
            {
                txtBillCodeLength.Focus();
                txtBillCodeLength.BorderBrush = new SolidColorBrush(Colors.Red);
                return false;
            }
            else if (Convert.ToInt32(txtTemplateHeigth.Text) == 0)
            {
                txtTemplateHeigth.Focus();
                txtTemplateHeigth.BorderBrush = new SolidColorBrush(Colors.Red);
                return false;
            }
            else if (Convert.ToInt32(txtTemplateWidth.Text) == 0)
            {
                txtBillCodeLength.Focus();
                txtTemplateWidth.BorderBrush = new SolidColorBrush(Colors.Red);
                return false;
            }
            else
            {
                return true;
            }
        }
        #endregion
        #region  窗体的事件
        /// <summary>
        /// 打开图片选择框
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (dlgPicture.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                txtBgPath.Text = dlgPicture.FileName;
                Uri uri = new Uri(dlgPicture.FileName, UriKind.RelativeOrAbsolute);
                BitmapImage bitmap = new BitmapImage(uri);
                ImageBG.Source = bitmap;
            }
        }

        /// <summary>
        /// 提交
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Submit_Click(object sender, RoutedEventArgs e)
        {
            if (CheckIsNull())
            {               
                #region 获取实体
                btm.TIName = txtTemplateName.Text;
                btm.TICodeLegth = Convert.ToInt32(txtBillCodeLength.Text);
                btm.TIHeight = Convert.ToInt32(txtTemplateHeigth.Text);
                btm.TIWidth = Convert.ToInt32(txtTemplateWidth.Text);
                if (RadioIsBG.IsChecked == false && txtBgPath.Text != String.Empty)
                {
                    btm.TIBackground = imaHelper.GetBytesByImagepath(txtBgPath.Text);
                    btm.TIIsVoidBg = 1;
                }
                else
                {
                    btm.TIBackground = imaHelper.GetBytesByImagepath(AppDomain.CurrentDomain.BaseDirectory + "\\Resource\\defaulticon.jpg");
                    btm.TIIsVoidBg = 0;
                }
                if (RadioIsPrint.IsChecked == true)
                {
                    btm.TIIsPrintBg = 1;
                }
                else
                {
                    btm.TIIsPrintBg = 0;
                }
                btm.TITTID = btts.GetTemplateTypeIdByName(cbbTemplatetype.Text);
                #endregion

                if (Type != "Update")
                {
                    //新增
                    btm.TIID = btmserice.AddByBillTemplatModel(btm);
                    if (btm.TIID != 0)
                    {
                        ModernDialog.ShowMessage("更新成功！", "提示", MessageBoxButton.OK);
                        TemplateMain sss = new TemplateMain(btm.TIID);
                        sss.Show();
                        this.Close();
                    }
                }
                else
                {
                    //更新
                    if (btmserice.UpdateByBillTemplatModel(btm) > 0)
                    {
                        ModernDialog.ShowMessage("更新成功！", "提示", MessageBoxButton.OK);
                        this.Close();
                    }
                }
            }
            else
            {
                MessageBox.Show("你有必填项为空，或填写不正确，请检查后在提交！", "提示");
            }
        }

        /// <summary>
        /// 窗体载入事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
           
            dttype = btts.GetAllTypeByBillsetID("测试账套");
            new ComHelper().SetComboBoxItemByDataTable(dttype, cbbTemplatetype, "TTName");
            if (Type == "Update")
            {
                //更新

                cbbTemplatetype.Text = new BillTemplateTypeService().GetTemplateTypeNameById(btm.TITTID);
                txtTemplateName.Text = btm.TIName;
                txtTemplateHeigth.Text = btm.TIHeight.ToString();
                txtTemplateWidth.Text = btm.TIWidth.ToString();
                txtBillCodeLength.Text = btm.TICodeLegth.ToString();
                //ImageBG.Image = new ImageHelper().GetImageByByte(btm.TIBackground);
                if (btm.TIIsPrintBg != 0)
                {
                    RadioIsPrint.IsChecked = true;
                }
                if (btm.TIIsVoidBg != 0)
                {
                    RadioIsBG.IsChecked = true;  
                }
            }
            else
            {
                //新增
                cbbTemplatetype.Text = this.TemplateTypeName;
            }
        }
        

        private void exit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
        #endregion
    }
}
