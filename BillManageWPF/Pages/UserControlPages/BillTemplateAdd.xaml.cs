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
using System.Windows.Navigation;
using System.Windows.Shapes;
using Controllers.Moders.TableModers;
using Controllers.Common;
using Controllers.Business;
using BillManageWPF.Forms;

namespace BillManageWPF.Pages.UserControlPages
{
    /// <summary>
    /// BillTemplateAdd.xaml 的交互逻辑
    /// </summary>
    public partial class BillTemplateAdd : UserControl
    {
        public BillTemplateAdd()
        {
            InitializeComponent();
        }

        #region 变量初始化
        ImageHelper imaHelper = new ImageHelper();//图片帮助类
        String Type =String.Empty; //操作类型（修改、添加）
        int TemplateTypeID = 0; // 模板类型编号
        BitmapImage bitImage = null; //保存图片
        System.Drawing.Image bgimage = null;//保存图片
        BillTemplatModer btm = null; //模板实体
        private System.Windows.Forms.OpenFileDialog dlgPicture =new System.Windows.Forms.OpenFileDialog(); //文件选择对话框
        BillTemplateService btmserice = new BillTemplateService();//模板业务对象
        #endregion

        /// <summary>
        /// 选择图片
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (dlgPicture.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                tbImagePath.Text = dlgPicture.FileName;
                bitImage = new BitmapImage(new Uri(tbImagePath.Text.Trim(), UriKind.Absolute));
                ImageBG.Source = bitImage;
                bgimage = System.Drawing.Image.FromFile(tbImagePath.Text);
                System.Windows.Forms.PictureBox picbox = new System.Windows.Forms.PictureBox();
                picbox.Image = bgimage;
            }
        }

        /// <summary>
        /// 窗体加载
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BillTemplateAdd_Loaded(object sender, RoutedEventArgs e)
        {
            if (Type == "Update")
            {
                       
            }
        }

        /// <summary>
        /// 下一步
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tbNext_Click(object sender, RoutedEventArgs e)
        {
            btm = new BillTemplatModer();
            btm.TIName = tbBillName.Text; //模板名称
            btm.TICodeLegth = Convert.ToInt32(tbBillCodeLegth.Text);//模板单据号长度
            btm.TIWidth = Convert.ToInt32(tbWidth.Text);//木板背景宽度
            btm.TIHeight = Convert.ToInt32(tbHeigth.Text);//模板高度
            if (bitImage != null)
            {
                btm.TIIcon = imaHelper.GetBytesByBitmapImage(tbImagePath.Text.Trim());//图片
                btm.TIBackground = imaHelper.GetBytesByImage(bgimage);
            }
            btm.TITTID = TemplateTypeID;//模板类型编号
            btm.TIID=btmserice.AddByBillTemplatModer(btm);//添加返回自增ID
            //FormSetTemplate fst = new FormSetTemplate(btm.TIID); //实例化模板设置窗体
            //fst.Show();
            TemplateMain sss = new TemplateMain(btm.TIID);
            sss.Show();
        }
    }
}
