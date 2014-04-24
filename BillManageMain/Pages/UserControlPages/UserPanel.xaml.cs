using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Forms;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace BillManageMain.UserControls
{
    /// <summary>
    /// UserPanel.xaml 的交互逻辑
    /// </summary>
    public partial class UserPanel : System.Windows.Controls.UserControl
    {
        String myNames = String.Empty;
        System.Windows.Forms.ImageList imageList = new ImageList();
        public UserPanel()
        {
            InitializeComponent();
        }
        public UserPanel(String Name)
        {
            InitializeComponent();

            this.myNames = Name;
        }
        public List<ListView> lsvs = new List<ListView>();
        public List<ImageList> imgls = new List<ImageList>();
        public void UpdataView(string type)
        {
            
        }
        private ListView SelectForce(List<ListView> lsvs)
        {
            int mark = 0;
            foreach (ListView lsv in lsvs)
            {
                if (lsv.SelectedItems.Count > 0)
                {
                    mark = 1;
                    return lsv;
                }
            }
            if (mark == 0)
            {
               // MessageBox.Show("请先选择票据！", "软件提示");
            }
            return null;
        }
        public void LoadImage(int PageIndex, ListView lsvItem, ImageList imlist)
        {
            lsvItem.Items.Clear();
            lsvItem.Dock = DockStyle.Fill;
            imlist.Images.Clear();
            //tcrMeum.TabPages[PageIndex].Controls.Add(lsvItem);
            //string sql = "select 模版编号,模版名称,缩略图 from 模版信息表 where 类别名称 = '" + tcrMeum.TabPages[PageIndex].Text + "'";
            //dt = cc.GetDataTable(sql);
            //imlist.ImageSize = new Size(250, 125);
            //lsvItem.LargeImageList = imlist;
            //lsvItem.SmallImageList = imlist;
            //for (int i = 0; i < dt.Rows.Count; i++)
            //{
            //    Image m_image = cc.GetImageByPath(dt.Rows[i][2].ToString());
            //    imlist.Images.Add(m_image);
            //    lsvItem.Items.Add(dt.Rows[i][1].ToString());
            //    lsvItem.Items[i].Name = dt.Rows[i][0].ToString();
            //    lsvItem.Items[i].ImageIndex = i;
            //}
        }
        public void doListView(int i)
        {
            ListView lsv = new ListView();
            //lsv.DoubleClick += new EventHandler(lsv_DoubleClick);
            lsvs.Add(lsv);
            lsvs[i].Name = lsv.Name + i.ToString();
            ImageList imgl = new ImageList();
            imgls.Add(imgl);
        }
        private void DoLoad()
        {
            //tcrMeum.TabPages.Clear();
            //string sql = "select 类别名称 from 模版类别表";// where 账套名称 = '" + Users.op_bill + "'";
            //dt = cc.GetDataTable(sql);
            //for (int i = 0; i < dt.Rows.Count; i++)
            //{
            //    tcrMeum.TabPages.Add(dt.Rows[i][0].ToString());
            //}

            //for (int i = 0; i < tcrMeum.TabCount; i++)
            //{
            //    doListView(i);
            //    LoadImage(i, lsvs[i], imgls[i]);
            //}
        }
        
        private void UListView_Loaded(object sender, RoutedEventArgs e)
        {

        }
    }
}
