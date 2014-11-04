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
using Controllers.Business;
using Controllers.Models;
using BillManageWPF.Page;

namespace BillManageWPF.Content.Template
{
    /// <summary>
    /// TemplateTypeEdit.xaml 的交互逻辑
    /// </summary>
    public partial class TemplateTypeEdit : Window
    {
        #region 构造函数
        public TemplateTypeEdit()
        {
            InitializeComponent();
        }
        public TemplateTypeEdit(TemplateViewList tv)
        {
            InitializeComponent();
            this.tlvl = tv;
        }
        public TemplateTypeEdit(String typeName,TemplateViewList tv )
        {
            InitializeComponent();
            this.templateType = typeName;
            this.tlvl = tv;
        }
        #endregion

        #region 页面变量
        private String templateType = String.Empty; //保存传入的类别，为empty 表示新增
        private TemplateViewList tlvl = null;
        #endregion 

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                if (templateType != String.Empty)
                {
                    //修改类型
                    txtTypeName.Text = templateType;
                }
            }
            catch (Exception ex)
            {
            }
        }

        /// <summary>
        /// 更新类别名称
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnQueDing_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (templateType == String.Empty)
                {
                    //新增票夹
                    if (!BillTemplateTypeManage.IsTypeNameExsit(txtTypeName.Text.Trim(), SoftUser.Op_Bill))
                    {
                        //名称不重复
                        if (BillTemplateTypeManage.AddTemplateType
                            (txtTypeName.Text, SoftUser.Op_Bill, SoftUser.UserCode) > 0)
                        {
                            //添加成功
                            tlvl.templateName = txtTypeName.Text;
                            MessageBox.Show("添加成功", "软件提示");
                            this.Close();
                        }
                        else
                        {
                            MessageBox.Show("添加失败", "软件提示");
                        }
                    }
                    else
                    {
                        //名称重复
                        MessageBox.Show("您输入的票夹名称在当前账套下已存在，请重新输入！", "软件提示");
                        txtTypeName.Text = String.Empty;
                        txtTypeName.Focus();
                    }
                }
                else
                {
                    //修改票夹
                    if (txtTypeName.Text.Trim() == templateType)
                    {
                        MessageBox.Show("未作修改", "软件提示");
                        this.Close();
                    }
                    else
                    {
                        if (!BillTemplateTypeManage.IsTypeNameExsit(txtTypeName.Text.Trim(), SoftUser.Op_Bill))
                        {
                            //新名称不重复
                            if (BillTemplateTypeManage.UpdateTemplateName
                                (txtTypeName.Text, templateType, SoftUser.Op_Bill) > 0)
                            {
                                //修改成功
                                tlvl.templateName = txtTypeName.Text;
                                MessageBox.Show("修改成功", "软件提示");
                                this.Close();
                            }
                            else
                            {
                                MessageBox.Show("修改失败", "软件提示");
                            }
                        }
                        else
                        {
                            MessageBox.Show("您输入的票夹名称在当前账套下已存在，请重新输入！", "软件提示");
                            txtTypeName.Text = String.Empty;
                            txtTypeName.Focus();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
            }
        }

        /// <summary>
        /// 取消
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnQuXiao_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
