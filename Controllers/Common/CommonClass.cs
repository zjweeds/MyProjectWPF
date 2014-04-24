using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Controllers.Common
{
    public class CommonClass
    {
        public Font GetFontByString(string str)
        {
            try
            {
                FontConverter fc = new FontConverter();
                return (Font)fc.ConvertFromString(str);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
    public class ComboxItem
    {
        public string Text = "";

        public string Value = "";
        public ComboxItem(string _Text, string _Value)
        {
            Text = _Text;
            Value = _Value;
        }

        public override string ToString()
        {
            return Text;
        }
    }
}
