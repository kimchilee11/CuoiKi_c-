using System;
using System.Windows.Forms;
using DAL;
using BLL;

namespace GUI
{
    public partial class DetailForm : Form
    {
        public delegate void del();
        public del ShowList;
        static int num = 21;
        int status = 0;
        String ID_MA_NL = "";
        String name = "";
        public DetailForm()
        {
            InitializeComponent();
        }
        public void LoadInfor(String name = "", int s = 0 , MonAn_NguyenLieu item = null)
        {
            foreach (var i in BLL_QLMA.Instance.GetAllNL())
            cbbTenNguyenLieu.Items.Add(i);

            cbbTenNguyenLieu.SelectedIndex = 0;
            this.name = name;
            status = s;
            if(item!= null)
            {
                ID_MA_NL = item.Id;
                cbbDV.Text = item.DonViTinh;
                cbbTenNguyenLieu.Text = item.NguyenLieu.Ten;
                cbbTT.Text = item.NguyenLieu.TinhTrang.ToString();
                txtSL.Text = item.SoLuong.ToString();
            }
            var l = BLL_QLMA.Instance.GetNLMonAn(name);
            num = int.Parse(l[l.Count - 1].Id) + 1;
        }
        private void btnOK_Click(object sender, EventArgs e)
        {
            if(status == 0)
            {
                int idMA = BLL_QLMA.Instance.GetMonAnByName(name);
                int nglieu = int.Parse(cbbTenNguyenLieu.SelectedIndex.ToString()) + 1;
                String id_s = "000" + num.ToString() ;
                MonAn_NguyenLieu item = new MonAn_NguyenLieu { Id = id_s, IdNguyenLieu= nglieu , IdMonAn = idMA, SoLuong = int.Parse(txtSL.Text), DonViTinh = cbbDV.Text };
                BLL_QLMA.Instance.InsertRecord(item);
            }
            else
            {
                int idMA = BLL_QLMA.Instance.GetMonAnByName(name);
                int nglieu = int.Parse(cbbTenNguyenLieu.SelectedIndex.ToString()) + 1;
                MonAn_NguyenLieu item = new MonAn_NguyenLieu {  IdNguyenLieu = nglieu, IdMonAn = idMA, SoLuong = int.Parse(txtSL.Text), DonViTinh = cbbDV.Text };
                BLL_QLMA.Instance.EditNLMonAn(item, ID_MA_NL);
            }
            ShowList();
            this.Dispose();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
    }
}
