﻿using System;
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
using BillManageWPF.Pages.UserControlPages;

namespace BillManageWPF.Pages
{
    /// <summary>
    /// Interaction logic for ViewBasicPage.xaml
    /// </summary>
    public partial class ViewBasicPage : UserControl
    {
        public ViewBasicPage()
        {
            InitializeComponent();
        }

        private void TemplateEdit_Loaded(object sender, RoutedEventArgs e)
        {
            BillTemplateAdd bta=new BillTemplateAdd();   
            panel.Children.Add(bta);
        }
    }
}
