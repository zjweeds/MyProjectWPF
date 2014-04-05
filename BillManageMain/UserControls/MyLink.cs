using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FirstFloor.ModernUI.Presentation;

namespace BillManageMain.UserControls
{
    public class MyLink:Link
    {
       // new System.EventHandler
        public delegate void BtnClickHandle(object sender, EventArgs e);
        //定义事件
        public event BtnClickHandle UserControlBtnClicked;

        

        public void LinkBtnClick(string name)
        {

        }
    }
}
