using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using Controllers.DataAccess.DAL;
using System.Data;
using System.Windows.Forms;

namespace Controllers.Common
{
    public class CommonClass
    {
        /// <summary>
        /// 字体对象格式化成字符串
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public Font GetFontByString(String str)
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
        /// <summary>
        /// 显示文本
        /// </summary>
        public String Text = "";

        /// <summary>
        /// 值
        /// </summary>
        public String Value = "";
        public ComboxItem(String _Text, String _Value)
        {
            Text = _Text;
            Value = _Value;
        }

        public override String ToString()
        {
            return Text;
        }
    }
}
