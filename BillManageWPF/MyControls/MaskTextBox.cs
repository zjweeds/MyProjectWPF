using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows;
using System.Windows.Media;

namespace BillManageWPF.MyControls
{

    public class MaskTextBox : TextBox
    {
        #region MaskText
        /// <summary>
        /// view sort style, desc arrow
        /// </summary>
        public static readonly DependencyProperty MaskTextProperty =
                   DependencyProperty.Register("MaskText", typeof(String), typeof(MaskTextBox));

        public String MaskText
        {
            get { return (String)GetValue(MaskTextProperty); }
            set { SetValue(MaskTextProperty, value); }
        }
        #endregion

        public MaskTextBox()
        {
            Loaded += (sender, args) =>
            {
                if (String.IsNullOrEmpty(base.Text))
                {
                    base.Text = MaskText;
                    base.Foreground = Brushes.Gray;
                }
            };

            base.GotFocus += (sender, args) =>
            {
                base.Foreground = Brushes.Black;
                if (base.Text == MaskText)
                    base.Text = String.Empty;
            };
            base.LostFocus += (sender, args) =>
            {
                if (!String.IsNullOrEmpty(base.Text))
                    return;

                base.Text = MaskText;
                base.Foreground = Brushes.Gray;
            };
        }

        public new String Text
        {
            get
            {
                if (base.Text == MaskText)
                    return String.Empty;
                else
                    return base.Text;
            }
            set { base.Text = value; }
        }
    }
}
